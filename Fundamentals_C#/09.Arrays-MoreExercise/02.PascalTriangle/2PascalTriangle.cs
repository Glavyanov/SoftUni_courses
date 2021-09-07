using System;

namespace _02PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args) 
        {
            int num = int.Parse(Console.ReadLine());
            int[]? currentArr = null;

            for (int i = 1; i <= num; i++)
            {

                for (int j = 1; j <= i; j++)
                {
                    int[] arr = new int[i];
                    int count = 1;
                    if (i <= 2)
                    {

                        for (int k = 0; k < arr.Length; k++)
                        {
                            arr[k] = count;
                        }
                        currentArr = arr;
                        Console.WriteLine(string.Join(" ", arr));
                        break;
                    }
                    else
                    {
                        arr = new int[i];
                        arr[0] = count;
                        arr[arr.Length - 1] = count;
                        if (i > 2 && i < 4)
                        {
                            int sum = 0;

                            for (int l = 0; l < currentArr.Length; l++)
                            {
                                if (l > currentArr.Length - 1)
                                {
                                    break;
                                }

                                sum += currentArr[l]; // събирам сумата за 3 ред
                            }

                            for (int m = 0; m < arr.Length; m++)
                            {

                                if (m == arr.Length - 2)
                                {
                                    break;
                                }
                                arr[m + 1] = sum;
                            }

                        }
                        if (i >= 4)
                        {

                            for (int o = 0; o < currentArr.Length; o++)
                            {
                                if (o == currentArr.Length - 1)
                                {
                                    break;
                                }
                                arr[o + 1] = currentArr[o] + currentArr[o + 1];

                            }

                        }
                        currentArr = arr;

                        Console.WriteLine(string.Join(" ", arr));
                        break;

                    }
                }
            }
        }
    }
}
