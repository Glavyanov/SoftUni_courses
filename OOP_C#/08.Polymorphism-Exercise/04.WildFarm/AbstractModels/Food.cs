using _04.WildFarm.Interfaces;

namespace _04.WildFarm.AbstractModels
{
    public abstract class Food : IFood
    {
        protected Food( int quantity)
        {
            Quantity = quantity;
        }

        
        public int Quantity { get; set ; }
    }
}
