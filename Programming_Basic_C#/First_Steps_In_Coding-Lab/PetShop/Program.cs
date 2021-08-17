using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPet = int.Parse(Console.ReadLine());
            int petNeiborgh = int.Parse(Console.ReadLine());
            double pricePet = 2.50;
            double priceNeigborgh = 4;
            Console.WriteLine((numberPet * pricePet) + (petNeiborgh * priceNeigborgh) + " lv.");
        }
    }
}
