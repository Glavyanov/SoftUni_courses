using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Masterchef
    {
        static void Main(string[] args)
        {
            //Dish         Freshness Level needed
            //Dipping sauce   150
            //Green salad     250
            //Chocolate cake  300
            //Lobster         400
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> freshnessLevel = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> dishes = new Dictionary<string, int>() { { "Dipping sauce", 0 }, { "Green salad", 0 }, { "Chocolate cake", 0 }, { "Lobster", 0 } };
            while (ingredients.Count != 0 && freshnessLevel.Count != 0)
            {
               int currentIngredient = ingredients.Peek();
               int currentFreshLevel = freshnessLevel.Peek();
                if (currentIngredient <= 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                int totalFreshLevel = currentFreshLevel * currentIngredient;
                if (totalFreshLevel == 400)
                {
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                    dishes["Lobster"]++;
                }
                else if (totalFreshLevel == 300)
                {
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                    dishes["Chocolate cake"]++;
                }
                else if (totalFreshLevel == 250)
                {
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                    dishes["Green salad"]++;
                }
                else if (totalFreshLevel == 150)
                {
                    ingredients.Dequeue();
                    freshnessLevel.Pop();
                    dishes["Dipping sauce"]++;
                }
                else
                {
                    ingredients.Enqueue(currentIngredient += 5);
                    ingredients.Dequeue();
                    freshnessLevel.Pop();

                }

            }
            if (dishes.All(d => d.Value > 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes! ");
                var ordered = dishes.Where(d => d.Value > 0).OrderBy(d => d.Key).ToDictionary(k => k.Key, v => v.Value);
                foreach (var item in ordered)
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
                
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (ingredients.Count > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                var ordered = dishes.Where(d => d.Value > 0).OrderBy(d => d.Key).ToDictionary(k => k.Key, v => v.Value);
                foreach (var item in ordered)
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }

            }


        }
    }
}
