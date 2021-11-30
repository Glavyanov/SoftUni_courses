using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            string[] personsAssign = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsAssign = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (var item in personsAssign)
                {
                    var personsElements = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = personsElements[0];
                    double money = double.Parse(personsElements[1]);
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
                foreach (var item in productsAssign)
                {
                    var productElements = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = productElements[0];
                    double price = double.Parse(productElements[1]);
                    Product product = new Product(name, price);
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                string product = cmdArgs[1];
                try
                {
                    if (persons.Any(p => p.Name == name) && products.Any(p => p.Name == product))
                    {
                        var person = persons.FirstOrDefault(p => p.Name == name);
                        var productToBuy = products.FirstOrDefault(p => p.Name == product);
                        person.Buying(productToBuy);
                        Console.WriteLine($"{name} bought {product}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            foreach (var item in persons)
            {
                if (item.Bag.Count == 0)
                {
                    Console.WriteLine($"{item.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{item.Name} - {string.Join(", ", item.Bag.Select(p => p.Name))}");
                }
            }
        }
    }
}
