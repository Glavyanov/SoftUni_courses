using System;

namespace fruitMarket
{
class fruitMarket
{
    static void Main(string[] args)
    {
        double priceStrawberry = double.Parse(Console.ReadLine());
        double numberBananaKilo = double.Parse(Console.ReadLine());
        double numberOrangeKilo = double.Parse(Console.ReadLine());
        double numberRaspberryKilo = double.Parse(Console.ReadLine());
        double numberStrawberryKilo = double.Parse(Console.ReadLine());

        double priceRaspberry = priceStrawberry / 2;
        double priceOrange = priceRaspberry - (priceRaspberry * 0.4);
        double priceBanana = priceRaspberry - (priceRaspberry * 0.8);

        double sumStrawberry = numberStrawberryKilo * priceStrawberry;
        double sumBanana = numberBananaKilo * priceBanana;
        double sumOrange = numberOrangeKilo * priceOrange;
        double sumRaspberry = numberRaspberryKilo * priceRaspberry;
        double sum = sumStrawberry + sumBanana + sumOrange + sumRaspberry;
        Console.WriteLine($"{sum:f2}");
    }
}
}
