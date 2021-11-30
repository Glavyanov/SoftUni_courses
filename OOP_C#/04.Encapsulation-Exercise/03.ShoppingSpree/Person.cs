using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private const double MinMoney = 0;

        private string name;

        private double money;

        private readonly List<Product> bag;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            this.bag = new List<Product>();
        }

        public double Money
        {
            get { return money; }
            private set 
            {
                if (value < MinMoney)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value; 
            }
        }

        public List<Product> Bag => this.bag;
        
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value; 
            }
        }

        public void Buying(Product product)
        {
            if (product.Price <= this.Money)
            {
                this.Money -= product.Price;
                this.bag.Add(product);
            }
            else
            {
                throw new ArgumentException($"{this.Name} can't afford {product.Name}");
            }
        }
    }
}
