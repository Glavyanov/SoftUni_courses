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
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
