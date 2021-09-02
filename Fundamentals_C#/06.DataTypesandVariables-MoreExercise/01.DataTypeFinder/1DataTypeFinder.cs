using System;

namespace _01DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
             string command = Console.ReadLine();
             while (command != "END")
             {
                 bool isDouble = false;
                 foreach (var item in command)
                 {
                     if (item == '.')
                     {
                         isDouble = true;
                         if (command[0] == '.')
                         {
                             isDouble = false;
                         }
                     }
                 }
                 bool isNumberDoublee = false;
                 if (isDouble)
                 {
                     isNumberDoublee = double.TryParse(command, out double resultd);
            
                     if (isNumberDoublee)
                     {
                         Console.WriteLine($"{command} is floating point type");
                         command = Console.ReadLine();
                         continue;
                     }
            
                 }
                 bool isNumberInteger = int.TryParse(command, out int result);
                 if (isNumberInteger)
                 {
                     Console.WriteLine($"{command} is integer type");
                     command = Console.ReadLine();
                     continue;
                 }
                 if (command.ToLower() == "true" || command.ToLower() == "false")
                 {
                     Console.WriteLine("{0} is boolean type", command);
                 }
                 else if (command.Length == 1)
                 {
                     Console.WriteLine("{0} is character type", command);
                 }
                 else if (command.Length > 1)
                 {
                     Console.WriteLine($"{command} is string type");
                 }
            
                 command = Console.ReadLine();
             }
        }
    }
}
