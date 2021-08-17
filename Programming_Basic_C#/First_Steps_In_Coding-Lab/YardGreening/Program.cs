using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());
            double Price = area * 7.61;
            double finalPrice = Price - Price * 0.18;
            double discount = Price * 0.18;
            Console.WriteLine("The final price is: " + finalPrice + " lv.");
            Console.WriteLine("The discount is: " + discount + " lv.");
        }
    }
}
