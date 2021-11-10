using _04.WildFarm.AbstractModels;

namespace _04.WildFarm.Implemetation
{
    public class Owl : Bird
    {
        public Owl(string name, double weight , double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                base.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.25;
            }
            else
            {
                ThrowInvalidFood(this, food);
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
