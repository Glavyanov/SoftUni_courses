using System;
using System.Linq;

namespace _03.Telephony
{
    public class SmartPhone : IPhone, IBrowsing
    {
        
        public void Calling(string number)
        {
            string error = "Invalid number!";
            bool haveError = false;
            if (!string.IsNullOrWhiteSpace(number))
            {
                foreach (var item in number)
                {
                    if (!char.IsDigit(item))
                    {
                        Console.WriteLine(error);
                        haveError = true;
                        break;
                    }
                }
                if (!haveError)
                {
                    Console.WriteLine($"Calling... {number}");
                }
            }
            else
            {
                Console.WriteLine(error);
            }
        }
        public void Browsing(string adress)
        {
            string error = "Invalid URL!";
            bool haveError = false;
            if (!string.IsNullOrWhiteSpace(adress))
            {
                foreach (var item in adress)
                {
                    if (char.IsDigit(item))
                    {
                        Console.WriteLine(error);
                        haveError = true;
                        break;
                    }
                }
                if (!haveError)
                {
                    Console.WriteLine($"Browsing: {adress}!");
                }
            }
            else
            {
                Console.WriteLine(error);
            }
        }
    }
}
