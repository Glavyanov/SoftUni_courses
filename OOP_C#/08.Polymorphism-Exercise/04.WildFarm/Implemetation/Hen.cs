using _04.WildFarm.AbstractModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Implemetation
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit || food is Meat || food is Seeds)
            {
                base.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.35;
            }
            else
            {
                ThrowInvalidFood(this, food);
            }
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
