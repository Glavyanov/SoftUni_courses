using System;

namespace _04Walking
{
    class Walking
    {
        static void Main(string[] args)
        {
            //string name = Console.ReadLine();

            //int corvert = name.Length;
            //    int sum = 0;
            //for(int i = 0; i < corvert; i++)
            //{
            //  char nameOne =name[i];
            //  int nameTwo = (int)nameOne;
            //    sum += nameTwo;

            //}

            //  Console.WriteLine(sum);



            int goalSteps = 10000;
            string step = string.Empty;
            int stepIn = 0;
            int totalSteps = 0;
            int diff = 0;
            while (goalSteps > totalSteps)
            {
                step = Console.ReadLine();
                if (step == "Going home")
                {
                    stepIn = int.Parse(Console.ReadLine());
                    totalSteps += stepIn;
                    diff = goalSteps - totalSteps;
                    if (diff > 0)
                    {
                        Console.WriteLine($"{diff} more steps to reach goal.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{Math.Abs(diff)} steps over the goal!");
                        return;
                    }
                }
                stepIn = int.Parse(step);
                totalSteps += stepIn;
            }
            diff = totalSteps - goalSteps;
            Console.WriteLine("Goal reached! Good job!");
            Console.WriteLine($"{diff} steps over the goal!");
        }
    }
}
