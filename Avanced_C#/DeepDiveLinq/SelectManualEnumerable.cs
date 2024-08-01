using System.Collections;

namespace DeepDiveLinq
{
    sealed class SelectManualEnumerable<TSource, TResult> : IEnumerable<TResult>, IEnumerator<TResult>
    {
        private int _threadId = Environment.CurrentManagedThreadId;
        private readonly IEnumerable<TSource> _source;
        private readonly Func<TSource, TResult> _selector;
        private TResult _current = default!;
        private IEnumerator<TSource>? _enumerator;
        private int _state = 0;

        public SelectManualEnumerable(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            this._source = source;
            this._selector = selector;
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            if (this._threadId == Environment.CurrentManagedThreadId && this._state == 0)
            {
                this._state = 1;
                return this;
            }
            return new SelectManualEnumerable<TSource, TResult>(this._source, this._selector)
            {
                _state = 1
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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
