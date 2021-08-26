using System;

namespace FirsttTask
{
    class Repainting
    {
        static void Main(string[] args)
        {
            int quantityNylon = int.Parse(Console.ReadLine());
            int quantityPaint = int.Parse(Console.ReadLine());
            int quantityAceton = int.Parse(Console.ReadLine());
            int hoursWork = int.Parse(Console.ReadLine());

            double priceNylon = (quantityNylon + 2) * 1.50;
            double pricePaint = (quantityPaint * 1.10) * 14.50;
            double priceAceton = quantityAceton * 5.00;

            double costMaterials = priceAceton + priceNylon + pricePaint + 0.40;
            double costWorkers = (costMaterials * 0.30) * hoursWork;
            double totalExpenses = costMaterials + costWorkers;
            Console.WriteLine("Total expenses: {0:0.##} lv.", totalExpenses);

        }
    }
}
