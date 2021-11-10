using _04.WildFarm.AbstractModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Implemetation
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                base.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.10;
            }   
            else
            {
                ThrowInvalidFood(this, food);
            }
           
        }  

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
