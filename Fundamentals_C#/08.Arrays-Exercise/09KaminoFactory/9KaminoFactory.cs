using System;
using System.Linq;

namespace _09KaminoFactory
{
    class KaminoFactory
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int counterBest = 0;
            int counterDna = 0;
            int counterDnaBest = 0;
            int bestIndex = int.MaxValue;
            int[] arrBest = new int[num];
            int sumBest = 0;
            string[] array = command.Split("!", StringSplitOptions.RemoveEmptyEntries);
            
            while (command != "Clone them!")
            {
                int[] arr = array.Select(int.Parse).ToArray();
                int counter = 0;
                counterDna++;
                int index = 0;
                int sum = 0;
                int currentBestIndex = int.MaxValue;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr.Length == 1 && arr[i] == 1)
                    {
                        sum += arr[i];
                        break;
                    }

                    if (i == arr.Length-1)
                    {
                        break;
                    }
                    if ((arr[i] == arr[i + 1] && arr[i] == 1))
                    {
                        counter++;
                        index = i;
                        if (currentBestIndex > index)
                        {
                            currentBestIndex = index;
                        }
                    }
                    sum += arr[i];
                    if (i == arr.Length - 2)
                    {
                        sum += arr[i + 1];
                    }
                }
                if (counter > counterBest || (counter == counterBest && currentBestIndex < bestIndex)
                    ||(counter == counterBest && currentBestIndex == bestIndex && sum>sumBest) || counterDna == 1)
                {
                    counterBest = counter;
                    counterDnaBest = counterDna;
                    arrBest = arr;
                    sumBest = sum;
                    bestIndex = currentBestIndex;
                }
                command = Console.ReadLine();
                array = command.Split("!", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Best DNA sample {counterDnaBest} with sum: {sumBest}.");
            Console.WriteLine(string.Join(" ", arrBest));
        }
    }
}
