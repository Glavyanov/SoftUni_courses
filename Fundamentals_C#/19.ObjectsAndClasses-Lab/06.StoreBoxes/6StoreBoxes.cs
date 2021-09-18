using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    class Item
    {
        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public double Price { get; set; }

    }
    class Box
    {
        public Box(long serialNumber, string item, int itemQuan, double itemPrice)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuan;
            ItemPrice = itemPrice;
        }
        public long SerialNumber { get; set; }
        public string Item { get; set; }
        public int ItemQuantity { get; set; }
        public double ItemPrice { get; set; }
    }
    class _6StoreBoxes
    {
        static void Main(string[] args)
        {
            string command;
            List<Item> items = new List<Item>();
            List<Box> boxs = new List<Box>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                long cmdNumber = long.Parse(cmdArg[0]);
                string cmdName = cmdArg[1];
                int cmdQuantity = int.Parse(cmdArg[2]);
                double cmdPrice = double.Parse(cmdArg[3]);

                Item item = new Item(cmdName, cmdPrice);
                items.Add(item);
                Box box = new Box(cmdNumber, cmdName, cmdQuantity, (cmdPrice * cmdQuantity));
                boxs.Add(box);

            }
            boxs = boxs.OrderByDescending(x => x.ItemPrice).ToList();
            foreach (Box item in boxs)
            {

                List<double> current = items.Where(x => x.Name == item.Item).Select(x=> x.Price).ToList();
                
                    Console.WriteLine(item.SerialNumber);
                    Console.WriteLine($" -- {item.Item} - ${current[0]:F2}: {item.ItemQuantity}");
                    Console.WriteLine($" -- ${item.ItemPrice:f2}");
               

            }

        }
    }
}
