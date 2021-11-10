using _04.WildFarm.AbstractModels;

namespace _04.WildFarm.Implemetation
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (!(food is Meat))
            {
                ThrowInvalidFood(this, food);
            }
            base.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * 0.40;
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
