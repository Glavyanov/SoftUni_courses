using System;

namespace _07HotelRoom
{
    class HotelRoom
    {
        static void Main(string[] args)
        {
            //          Май и октомври          Юни и септември                   Юли и август
            //Студио –     50 лв./ нощувка   Студио – 75.20 лв./ нощувка      Студио – 76 лв./ нощувка
            //Апартамент – 65 лв./ нощувка   Апартамент – 68.70 лв./ нощувка  Апартамент – 77 лв./ нощувка

            // •За студио, при повече от 7 нощувки през май и октомври: 5 % намаление.
            //•	За студио, при повече от 14 нощувки през май и октомври: 30 % намаление.
            //•	За студио, при повече от 14 нощувки през юни и септември: 20 % намаление.
            //•	За апартамент, при повече от 14 нощувки, без значение от месеца : 10 % намаление.

            string month = Console.ReadLine();
            int countNights = int.Parse(Console.ReadLine());
            double priceStudio = 0.0;
            double priceApartament = 0.0;
            switch (month)
            {
                case "May":
                case "October":
                    if (countNights < 8)
                    {
                        priceStudio = countNights * 50;
                        priceApartament = countNights * 65;
                    }
                    else if (countNights > 7 && countNights < 15)
                    {
                        priceStudio = (countNights * 50) * 0.95 ;
                        priceApartament = countNights * 65;
                    }
                    else if (countNights > 14)
                    {
                        priceStudio = (countNights * 50) * 0.70;
                        priceApartament = (countNights * 65) * 0.90;
                    }
                    break;
                case "June":
                case "September":
                    if (countNights > 14)
                    {
                        priceStudio = (countNights * 75.20) * 0.80;
                        priceApartament = (countNights * 68.70) * 0.90;
                    }
                    else
                    {
                        priceStudio = countNights * 75.20;
                        priceApartament = countNights * 68.70;
                    }
                    break;
                case "July":
                case "August":
                    if (countNights > 14)
                    {
                        priceApartament = (countNights * 77) * 0.90;
                        priceStudio = countNights * 76;
                    }
                    else
                    {
                        priceStudio = countNights * 76;
                        priceApartament = countNights * 77;
                    }   
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Apartment: {priceApartament:f2} lv.");
            Console.WriteLine($"Studio: {priceStudio:f2} lv.");

        }
    }
}
