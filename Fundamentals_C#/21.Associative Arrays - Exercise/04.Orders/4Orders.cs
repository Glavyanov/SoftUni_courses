using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, double[]>();
            string command = Console.ReadLine();
            while (command != "buy")
            {
                string[] cmdArgs = command.Split();
                string name = cmdArgs[0];
                double price = double.Parse(cmdArgs[1]);
                double quantity = double.Parse(cmdArgs[2]);
                if (!products.ContainsKey(name))
                {
                    products.Add(name, new double[] { price, quantity});
                }
                else
                {
                    if (products[name][0] != price)
                    {
                        products[name][0] = price;
                    }
                    products[name][1] += quantity; 
                }

                command = Console.ReadLine();
            }
            foreach (var (name, priceQnt) in products)
            {
                Console.WriteLine($"{name} -> {(priceQnt[0] * priceQnt[1]):F2}");
            }
        }
    }
}
