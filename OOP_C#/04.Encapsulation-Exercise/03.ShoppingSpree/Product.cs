using System;

namespace ShoppingSpree
{
    public class Product
    {
        private const double MinPrice = 0;

        private string name;

        private double price;

        public Product(string name,  double price)
        {
            Name = name;
            Price = price;
        }

        public double Price
        {
            get { return price; }
            private set 
            {
                if (value < MinPrice)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                price = value; 
            }
        }


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

    }
}
