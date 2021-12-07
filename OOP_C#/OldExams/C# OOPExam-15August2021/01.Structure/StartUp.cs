namespace CarRacing
{
    using CarRacing.Models.Cars;
    using CarRacing.Repositories;
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            /*TunedCar car = new TunedCar("VW", "Golf", "wvwzzzauzep564512", 105);
            CarRepository carRepo = new CarRepository();
            carRepo.Add(car);*/
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
