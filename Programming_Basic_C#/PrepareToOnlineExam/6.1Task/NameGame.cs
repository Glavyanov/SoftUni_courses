using System;

namespace SixxTask
{
    class NameGame
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();
            int points = 0;
            int curPoints = 0;
            string Win = "";
            int pointsWin = 0;
            while (name != "Stop")
            {
                for (int i = 0; i < name.Length; i++)
                {
                    int num = int.Parse(Console.ReadLine());
                    char curNum = name[i];
                    int newNum = (int)curNum;
                    if (num == newNum)
                    {
                        curPoints += 10;
                    }
                    else
                    {
                        curPoints += 2;
                    }
                }
                if (curPoints >= points)
                {
                    Win = name;
                    pointsWin = curPoints;
                }
                points = curPoints;
                curPoints = 0;
                name = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {Win} with {pointsWin} points!");
        }
    }
}
