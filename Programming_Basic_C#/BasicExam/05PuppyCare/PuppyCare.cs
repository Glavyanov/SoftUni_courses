using System;

namespace _05PuppyCare
{
    class PuppyCare
    {
        static void Main(string[] args)
        {
            int foodPuppy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int foodPuppyy = foodPuppy * 1000;
            
            while (command != "Adopted")
            {
                int eatingFood = int.Parse(command);
                foodPuppyy -= eatingFood;


                command = Console.ReadLine();
            }
            if (foodPuppyy < 0)
            {
                int needed = Math.Abs(foodPuppyy);
                Console.WriteLine($"Food is not enough. You need {needed} grams more.");
            }
            else
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodPuppyy} grams.");
            }
        }
    }
}
