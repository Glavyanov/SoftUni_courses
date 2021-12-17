using Gym.Models.Equipment.Contracts;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        protected Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }

        public double Weight { get; private set; }

        public decimal Price { get; private set; }
    }
}
