using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            IBuyer buyer = null;
            for (int i = 0; i < n; i++)
            {
                string[] assignBuyer = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = assignBuyer[0];
                int age = int.Parse(assignBuyer[1]);
                if (assignBuyer.Length > 3)
                {
                    buyer = new Citizen(name, age, assignBuyer[2], assignBuyer[3]);
                }
                else if (assignBuyer.Length == 3)
                {
                    buyer = new Rebel(name, age, assignBuyer[2]);
                }
                if (buyer != null)
                {
                    if (!buyers.ContainsKey(name))
                    {
                        buyers.Add(name, buyer);
                    }
                }
            }
            string searchedName;
            while ((searchedName = Console.ReadLine()) != "End")
            {
                if (buyers.ContainsKey(searchedName))
                {
                    buyers[searchedName].BuyFood();
                }

            }
            Console.WriteLine(buyers.Select(p => p.Value.Food).Sum());
        }
    }
}
