using System;
using System.Linq;

namespace _01.Action_Print
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> namesPrint = array => Console.WriteLine(string.Join(Environment.NewLine, array));
            namesPrint(names);
            
        }
    }
}
