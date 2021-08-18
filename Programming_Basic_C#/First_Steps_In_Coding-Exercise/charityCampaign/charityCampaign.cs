using System;

namespace charityCampaign
{
class charityCampaign
{
static void Main(string[] args)
{
            
    int numberDays = int.Parse(Console.ReadLine());
    int numberBakers = int.Parse(Console.ReadLine());
    int numberCakes = int.Parse(Console.ReadLine());
    int numberWaffle = int.Parse(Console.ReadLine());
    int numberPancakes = int.Parse(Console.ReadLine());

    int priceCakes = numberCakes * 45;
    double waffle = numberWaffle * 5.80;
    double pancakes = numberPancakes * 3.20;
    double sumDay = (priceCakes + waffle + pancakes) * numberBakers;
    double sumCampaign = sumDay * numberDays;
    double sumAfterPaid = sumCampaign - sumCampaign / 8;
    Console.WriteLine(sumAfterPaid);





}
}
}
