using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _05.DrumSet
{
    class DrumSet
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            List<int> copiedDrums = new List<int>(drumSet.Count);

            for (int i = 0; i < drumSet.Count; i++)
            {
                copiedDrums.Add(drumSet[i]);
            }
            double currentSavings = 0;
            string command = Console.ReadLine();

            while (command != "Hit it again, Gabsy!")
            {
                int hit = int.Parse(command);

                for (int i = 0; i < copiedDrums.Count; i++)
                {
                    copiedDrums[i] -= hit;
                    if (copiedDrums[i] < 1)
                    {
                        currentSavings = savings;
                        savings -= drumSet[i] * 3;
                        if (savings >= 0)
                        {
                            copiedDrums[i] = drumSet[i];
                        }
                        else
                        {
                            copiedDrums.RemoveAt(i);
                            drumSet.RemoveAt(i);
                            savings = currentSavings;
                            i--;
                        }

                    }

                }
                command = Console.ReadLine();

            }

            Console.WriteLine(string.Join(' ', copiedDrums));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}
