using _04.WildFarm.AbstractModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Implemetation
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                ThrowInvalidFood(this, food);
            }
            base.FoodEaten += food.Quantity;
            this.Weight += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
