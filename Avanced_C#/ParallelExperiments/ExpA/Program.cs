Parallel.Invoke(
    () => Console.WriteLine("Vista"),
    () => Console.WriteLine("Buena"));
Console.WriteLine("Done");

//https://www.youtube.com/watch?v=18w4QOWGJso&t=2108s
static void ParallelInvoke(params Action[] actions)
{
    if(actions.Length < 10)
    {
        var tasks = from action in actions select Task.Run(action);
        Task.WaitAll(tasks.ToArray());
    }
    else
    {
        Parallel.ForEach(actions, action => action());
    }
}

ParallelInvoke(
    () => Console.WriteLine("Vista1"),
    () => Console.WriteLine("Vista2"),
    () => Console.WriteLine("Vista3"),
    () => Console.WriteLine("Vista4"),
    () => Console.WriteLine("Vista5"),
    () => Console.WriteLine("Vista6"),
    () => Console.WriteLine("Vista7"),
    () => Console.WriteLine("Vista8"),
    () => Console.WriteLine("Vista9"),
    () => Console.WriteLine("Vista10"),
    () => Console.WriteLine("Vista11"),
    () => Console.WriteLine("Vista12"),
    () => Console.WriteLine("Vista13"),
    () => Console.WriteLine("Buena14"));