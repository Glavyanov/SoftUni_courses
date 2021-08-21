using System;

namespace _01Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeProjection = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());
            double price = 0.0;
            if (typeProjection == "Premiere")
            {
                price = row * column * 12.00;
            }
            else if (typeProjection == "Normal")
            {
                price = row * column * 7.50;
            }
            else if (typeProjection == "Discount")
            {
                price = row * column * 5.00;
            }
            Console.WriteLine("{0:0.##} leva", price);

        }
    }
}
