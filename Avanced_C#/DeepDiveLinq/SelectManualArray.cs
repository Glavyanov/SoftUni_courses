namespace DeepDiveLinq
{
    sealed class SelectManualArray<TSource, TResult> : IEnumerable<TResult>, IEnumerator<TResult>
    {
        private int _threadId = Environment.CurrentManagedThreadId;
        private readonly TSource[] _source;
        private readonly Func<TSource, TResult> _selector;
        private TResult _current = default!;
        private int _state = 0;

        public SelectManualArray(TSource[] source, Func<TSource, TResult> selector)
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
            return new SelectManualArray<TSource, TResult>(this._source, this._selector)
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
        }

        public bool MoveNext()
        {
            int i = this._state - 1;
            TSource[] source = this._source;

            if ((uint)i < (uint)source.Length)
            {
                this._state++;
                this._current = this._selector(source[i]);
                return true;
                //yield return
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
