using _04.WildFarm.AbstractModels;
using _04.WildFarm.Implemetation;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class WildFarm
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string animalType = cmdArgs[0];
                Animal animal = null;
                if (animalType == "Hen")
                {
                    animal = new Hen(cmdArgs[1], double.Parse(cmdArgs[2]), double.Parse(cmdArgs[3]));
                }
                else if (animalType == "Owl")
                {
                    animal = new Owl(cmdArgs[1], double.Parse(cmdArgs[2]), double.Parse(cmdArgs[3]));

                }
                else if (animalType == "Mouse")
                {
                    animal = new Mouse(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3]);
                }
                else if (animalType == "Dog")
                {
                    animal = new Dog(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3]);

                }
                else if (animalType == "Cat")
                {
                    animal = new Cat(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]);
                }
                else if (animalType == "Tiger")
                {
                    animal = new Tiger(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]);
                }
                Console.WriteLine(animal.ProduceSound());
                animals.Add(animal);
                string[] foodArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodArgs[0];
                int quantity = int.Parse(foodArgs[1]);
                Food food = null;
                if (foodType == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(quantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(quantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(quantity);
                }
                try
                {
                    animal.Eat(food);

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                if (foodType == "End")
                {
                    break;
                }

            }
            animals.ForEach(Console.WriteLine);

        }
    }
}
