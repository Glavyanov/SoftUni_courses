using System;

namespace _01DataTypes
{
    class DataTypes
    {
        static void Main(string[] args)
        {
            string typeData = Console.ReadLine();
            string input = Console.ReadLine();
            GetAllOperations(typeData, input);
        }

        private static void GetAllOperations(string type, string value)
        {
            switch (type)
            {
                case "int":
                    int inputNum = int.Parse(value);
                    inputNum *= 2;
                    Console.WriteLine(inputNum);
                    break;
                case "real":
                    double inputReal = double.Parse(value);
                    inputReal *= 1.5;
                    Console.WriteLine($"{inputReal:f2}");
                    break;
                case "string":
                    Console.WriteLine("${0}$", value);
                    break;
                default:
                    break;
            }
        }
       
    }
}
