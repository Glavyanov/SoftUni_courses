//https://www.youtube.com/watch?v=18w4QOWGJso&t=2108s
using System.Runtime.CompilerServices;

int length = 80_000;
Parallel.Invoke(() => DoWork(0, length/4),
    () => DoWork(length / 4, length / 2 ),
    () => DoWork(length / 2, length / 4 * 3),
    () => DoWork(length / 4 * 3, length));

static void DoWork(int from, int to)
{
    Console.WriteLine($"{nameof(DoWork)} from {from} to {to}.");
	for (int i = from; i < to; i++)
	{
		Handle(i);
	}
    Console.WriteLine($"{nameof(DoWork)} from {from} to {to} done.");

    [MethodImpl(MethodImplOptions.NoInlining)]
    static void Handle(int index)
	{
		Thread.SpinWait(index / 2);
	}
}