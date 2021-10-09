using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] inputArgs = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (shops.ContainsKey(inputArgs[0]))
                {
                    if (shops[inputArgs[0]].ContainsKey(inputArgs[1]))
                    {
                        shops[inputArgs[0]][inputArgs[1]] = double.Parse(inputArgs[2]);
                    }
                    else
                    {
                        shops[inputArgs[0]].Add(inputArgs[1], double.Parse(inputArgs[2]));
                    }
                }
                else
                {
                    shops.Add(inputArgs[0], new Dictionary<string, double>() {  [inputArgs[1]] = double.Parse(inputArgs[2]) } );
                }

            }
            foreach (var shop in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
