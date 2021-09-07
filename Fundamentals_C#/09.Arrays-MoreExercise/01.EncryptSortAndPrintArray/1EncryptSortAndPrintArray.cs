using System;
using System.Linq;

namespace _01EncryptSortAndPrintArray
{
    class EncryptSortAndPrintArray
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] array = new string[num];
            int[] arrNumber = new int[num];
            int condenseSymbol = 0;
            for (int i = 0; i < array.Length; i++)
            {
                string name = Console.ReadLine();
                array[i] = name;
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    char symbol = array[i][j];
                    switch(symbol)
                    {
                        case 'A':
                        case 'a':
                        case 'E':
                        case 'e':
                        case 'I':
                        case 'i':
                        case 'O':
                        case 'o':
                        case 'U':
                        case 'u':
                            condenseSymbol = (int)symbol * name.Length;
                            break;
                        default:
                            condenseSymbol = (int)symbol / name.Length;
                            break;
                    }
                    sum += condenseSymbol;
                }
                arrNumber[i] = sum;
            }
            Array.Sort(arrNumber);
            for (int i = 0; i < arrNumber.Length; i++)
            {
                Console.WriteLine(arrNumber[i]);
            }
        }
    }
}
