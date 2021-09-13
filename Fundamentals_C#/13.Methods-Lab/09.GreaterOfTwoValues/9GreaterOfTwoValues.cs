using System;

namespace _09GreaterOfTwoValues
{
    class GreaterOfTwoValues
    {
        static void Main(string[] args)
        {
            string typeValue = Console.ReadLine();
            string valueOne = Console.ReadLine();
            string valueTwo = Console.ReadLine();
            switch (typeValue)
            {
                case "int":
                    int convertValueOne = int.Parse(valueOne);
                    int convertValueTwo = int.Parse(valueTwo);
                    int result = GetMax(convertValueOne, convertValueTwo);
                    Console.WriteLine(result);
                    break;
                case "char":
                    char convertchrValueOne = char.Parse(valueOne);
                    char convertchrValueTwo = char.Parse(valueTwo);
                    char resultchr = GetMax(convertchrValueOne, convertchrValueTwo);
                    Console.WriteLine(resultchr);
                    break;
                case "string":
                    string resultstr = GetMax(valueOne, valueTwo);
                    Console.WriteLine(resultstr);
                    break;
                default:
                    break;
            }

        }

        private static int GetMax(int valueOne, int valueTwo)
        {
            int result = 0;
            if (valueOne > valueTwo)
            {
                result = valueOne;
            }
            else if (valueOne < valueTwo)
            {
                result = valueTwo;
            }  
            else
            {
                result = valueTwo;
            }
            return result;
        }
        private static char GetMax(char valueOne, char valueTwo)
        {
            char result = '\0' ;
            if (valueOne.CompareTo(valueTwo) > 0)
            {
                result = valueOne;
            }
            else
            {
                result = valueTwo;
            }
            return result;
        }
        private static string GetMax(string valueOne, string valueTwo)
        {
            string result = string.Empty;
            if (valueOne.CompareTo(valueTwo) > 0)
            {
                result = valueOne;
            }
            else
            {
                result = valueTwo;
            }
            return result;

        }
    }
}
