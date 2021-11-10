using _04.WildFarm.Interfaces;

namespace _04.WildFarm.AbstractModels
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get ; set ; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{ this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
