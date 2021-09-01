using System;

namespace _0001SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double third = double.Parse(Console.ReadLine());
            double max = 0;
            double middle = 0;
            double min = 0;
            if (first >= second && first >= third)
            {
                max = first;
                if (second>=third)
                {
                    middle = second;
                    min = third;
                }
                else if (third >= second)
                {
                    middle = third;
                    min =  second;
                }
            }
            else if (second >= first && second >= third)
            {
                max = second;
                if (first >= third)
                {
                    middle = first;
                    min = third;
                }
                else if (third >= first)
                {
                    middle = third;
                    min = first;
                }
            }
            else if (third >= first && third >= second)
            {
                max = third;
                if (first >= second)
                {
                    middle = first;
                    min = second;
                }
                else if (second >= first)
                {
                    middle = second;
                    min = first;
                }
            }
            Console.WriteLine(max);
            Console.WriteLine(middle);
            Console.WriteLine(min);

        }
    }
}
