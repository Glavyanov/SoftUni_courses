using System.Collections;

namespace DeepDiveLinq
{
    sealed class Enumerator<TSource, TResult> : IEnumerator<TResult>
    {
        private IEnumerable<TSource> _source;
        private Func<TSource, TResult> _selector;
        private TResult _current = default!;
        private IEnumerator<TSource>? _enumerator;
        private int _state = 1;

        public Enumerator(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            this._source = source;
            this._selector = selector;
        }

        public TResult Current => this._current;

        object? IEnumerator.Current => this.Current;

        public void Dispose()
        {
            this._state = -1;
            this._enumerator?.Dispose();
        }

        public bool MoveNext()
        {
            switch (this._state)
            {
                case 1:
                    this._enumerator = this._source.GetEnumerator();
                    this._state = 2;
                    goto case 2;
                case 2:
                    try
                    {
                        if (this._enumerator.MoveNext())
                        {
                            this._current = this._selector(this._enumerator.Current);
                            return true;
                            //yield return
                        }
                    }
                    catch
                    {
                        Dispose();
                        throw;
                    }
                    break;
            }

            Dispose();
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
}