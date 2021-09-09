using System;
using System.Linq;

namespace _09PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SameBackwardAsForward(input);

        }


        private static void SameBackwardAsForward(string input)
        {
            while (input != "END")
            {
                int[] inputconvert = new int[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    int number = int.Parse(input[i].ToString());
                    inputconvert[i] = number;
                }
                int[] reversed = new int[inputconvert.Length];
                for (int i = 0; i < inputconvert.Length; i++)
                {
                    var value = inputconvert[i];
                    reversed[reversed.Length - i - 1] = inputconvert[i];
                }
                bool flag = true;
                for (int i = 0; i < inputconvert.Length; i++)
                {
                    if (inputconvert[i] != reversed[i])
                    {
                        flag = false;
                        break;
                    }
        
                }
                if (flag)
                {
                    Console.WriteLine(flag);
                }
                else
                {
                    Console.WriteLine(flag);
                }
                input = Console.ReadLine();
            }
        }
        
    }
}
