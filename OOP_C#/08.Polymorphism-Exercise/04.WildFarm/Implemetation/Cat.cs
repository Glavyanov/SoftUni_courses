using _04.WildFarm.AbstractModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Implemetation
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                base.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.30;
            }
            else
            {
                ThrowInvalidFood(this, food);
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
