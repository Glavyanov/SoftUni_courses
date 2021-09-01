using System;

namespace _09SpiceMustFlow
{
    class SpiceMustFlow
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int day = 0;
            int reminder = 0;
            int sum = 0;
            for (int i = num; i >= 100; i -= 10)
            {
                day++;
                reminder = i - 26;
                sum += reminder;
            }
            sum -= 26;
            if (sum < 0)
            {
                sum = 0;
            }
            Console.WriteLine(day);
            Console.WriteLine(sum);
        }
    }
}
