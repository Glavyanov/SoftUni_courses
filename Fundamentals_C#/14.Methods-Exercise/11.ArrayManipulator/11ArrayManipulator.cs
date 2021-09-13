using System;
using System.Linq;
using System.Text;

namespace _11ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            string[] command = Console.ReadLine()
                                      .ToLower()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0].ToLower() != "end")
            {
                switch (command[0].ToLower())
                {
                    case "exchange":
                        int numIndex = int.Parse(command[1]);
                        GetExchange(numbers, numIndex);
                        break;
                    case "max":
                        GetMax(numbers, command[1]);
                        break;
                    case "min":
                        GetMin(numbers, command[1]);
                        break;
                    case "first":
                        int counterFirst = int.Parse(command[1]);
                        GetFirst(numbers, counterFirst, command[2]);
                        break;
                    case "last":
                        int counterLast = int.Parse(command[1]);
                        GetLast(numbers, counterLast, command[2]);
                        break;
                    default:
                        break;
                }


                

                command = Console.ReadLine()
                                 .ToLower()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static void GetLast(int[] arr, int num, string evenOrOdd)
        {
            if (num > arr.Length  || num < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            StringBuilder result = new StringBuilder();
            int count = 0;
            if (evenOrOdd == "odd")
            {
                for (int i = arr.Length-1; i >= 0; i--)
                {
                    if (count == num)
                    {
                        break;
                    }
                    if (arr[i] % 2 != 0)
                    {
                        result.Append(" ").Append(arr[i].ToString());
                        count++;
                    }

                }

            }
            else if (evenOrOdd == "even")
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (count == num)
                    {
                        break;
                    }
                    if (arr[i] % 2 == 0)
                    {
                        result.Append(" ").Append(arr[i].ToString());
                        count++;
                    }

                }
            }
            string total = result.ToString();
            string[] totall = total.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

            Console.WriteLine($"[{string.Join(", ", totall)}]");
        }

        private static void GetFirst(int[] arr, int num, string evenOrOdd)
        {
            int counter = 0;
            if (num > arr.Length  || num < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            StringBuilder result = new StringBuilder();
            if (evenOrOdd == "odd")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (counter == num)
                    {
                        break;
                    }
                    if (arr[i] % 2 != 0)
                    {
                        result.Append(" ").Append(arr[i].ToString());
                        counter++;
                    }

                }

            }
            else if (evenOrOdd == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (counter == num)
                    {
                        break;
                    }
                    if (arr[i] % 2 == 0)
                    {
                        result.Append(" ").Append(arr[i].ToString());
                        counter++;
                    }

                }
            }
            string total = result.ToString();
            string[] totall = total.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            
            Console.WriteLine($"[{string.Join(", ",totall)}]");
        }

        private static void GetMin(int[] arr, string evenOrOdd)
        {
            int minElement = 0;
            bool flag = false;
            int current = int.MaxValue;
            if (evenOrOdd == "even")
            {

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0 && arr[i] <= current)
                    {
                        current = arr[i];
                        minElement = i;
                        flag = true;
                    }

                }

            }
            else if (evenOrOdd == "odd")
            {

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0 && arr[i] <= current)
                    {
                        current = arr[i];
                        minElement = i;
                        flag = true;
                    }

                }

            }
            if (flag)
            {
                Console.WriteLine(minElement);

            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void GetMax(int[] arr, string evenOrOdd)
        {
            int maxElement = 0;
            bool flag = false;
            int current = int.MinValue;
            if (evenOrOdd == "even")
            {

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0 && arr[i] >= current)
                    {
                        current = arr[i];
                        maxElement = i;
                        flag = true;
                    }

                }

            }
            else if (evenOrOdd == "odd")
            {

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0 && arr[i] >= current)
                    {
                        current = arr[i];
                        maxElement = i;
                        flag = true;
                    }

                }

            }
            if (flag)
            {
                Console.WriteLine(maxElement);

            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void GetExchange(int[] arr, int num)
        {
            if (num > arr.Length-1 || num < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            for (int i = 0; i <= num; i++)
            {
                int current = arr[0];
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[arr.Length - 1] = current;

            }
        }
    }
}
