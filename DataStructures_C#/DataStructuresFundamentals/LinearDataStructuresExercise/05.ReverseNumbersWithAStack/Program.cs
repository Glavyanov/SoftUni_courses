using System.Collections.Generic;

namespace _05.ReverseNumbersWithAStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
			string input = Console.ReadLine()!;

			try
			{
				Stack<int> stack =
					new(input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

				List<int> list = new();

				while (stack.Count != 0)
				{
					list.Add(stack.Pop());
				}

				Console.WriteLine(string.Join(' ', list));
			}
			catch (Exception)
			{
				Console.WriteLine(input);
			}
		}
    }
}