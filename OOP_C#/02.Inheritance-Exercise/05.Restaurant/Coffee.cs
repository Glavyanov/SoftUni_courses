namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;

        private const decimal CofeePrice = 3.50M;

        public Coffee(string name, double caffeine) 
            : base(name, CofeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
