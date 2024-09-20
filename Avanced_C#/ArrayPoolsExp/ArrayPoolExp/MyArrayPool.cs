using System.Collections.Concurrent;
using System.Numerics;

namespace ArrayPoolExp
{
    static class MyArrayPool<T>
    {
        private static readonly ConcurrentQueue<T[]>[] s_arrays =
            Enumerable.Range(0, 30).Select(_ => new ConcurrentQueue<T[]>()).ToArray();
        public static T[] Rent(int minimumLength)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(minimumLength, nameof(minimumLength));
            if (minimumLength == default)
            {
                return Array.Empty<T>();
            }

            ConcurrentQueue<T[]> queue = s_arrays[BitOperations.Log2((uint)minimumLength - 1)];

            if (queue.TryDequeue(out T[]? array))
            {
                return array;
            }

            return new T[BitOperations.RoundUpToPowerOf2((uint)minimumLength)];
        }

        public static void Return(T[] array)
        {
            ArgumentNullException.ThrowIfNull(array, nameof(array));
            if (array.Length == default)
            {
                return;
            }

            if (!BitOperations.IsPow2(array.Length))
            {
                throw new Exception();
            }

            ConcurrentQueue<T[]> queue = s_arrays[BitOperations.Log2((uint)array.Length - 1)];
            queue.Enqueue(array);
        }
    }
}
