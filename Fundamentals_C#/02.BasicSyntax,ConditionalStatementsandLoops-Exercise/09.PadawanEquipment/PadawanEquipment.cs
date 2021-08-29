using System;

namespace _09PadawanEquipment
{
    class PadawanEquipment
    {
        static void Main(string[] args)
        {
            double moneyAmount = double.Parse(Console.ReadLine());
            int countStudents = int.Parse(Console.ReadLine());
            double priceOneLightSaber = double.Parse(Console.ReadLine());
            double priceOneRobe = double.Parse(Console.ReadLine());
            double priceOneBelt = double.Parse(Console.ReadLine());

            double priceAllSaber = Math.Ceiling(countStudents * 1.10) * priceOneLightSaber;
            double priceAllRobes = countStudents * priceOneRobe;
            double priceAllBelts = (countStudents - (countStudents / 6)) * priceOneBelt;
            double neededMoney = priceAllSaber + priceAllRobes + priceAllBelts;
            if (moneyAmount >= neededMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {neededMoney:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {neededMoney - moneyAmount:F2}lv more.");
            }
        }
    }
}
