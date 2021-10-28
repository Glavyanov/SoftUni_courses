using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<Animal> animals = new List<Animal>();
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] assign = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = assign[0];
                int age = int.Parse(assign[1]);
                string gender = assign[2];
                Animal animal = new Animal();
                if (input == "Cat")
                {
                    try
                    {
                        animal = new Cat(name, age, gender);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
                else if (input == "Dog")
                {
                    try
                    {
                        animal = new Dog(name, age, gender);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "Frog")
                {
                    try
                    {
                        animal = new Frog(name, age, gender);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "Kitten")
                {
                    try
                    {
                        animal = new Kitten(name, age);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "Tomcat")
                {
                    try
                    {
                        animal = new Tomcat(name, age);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
                if (animal.Name != null)
                {
                    animals.Add(animal);
                }

            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
