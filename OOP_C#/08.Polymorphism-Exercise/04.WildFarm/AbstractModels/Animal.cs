using _04.WildFarm.Interfaces;
using System;

namespace _04.WildFarm.AbstractModels
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public virtual int FoodEaten { get; set; }

        public abstract void Eat(Food food);

        public abstract string ProduceSound();
        
        public void ThrowInvalidFood(Animal animal, Food food)
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
