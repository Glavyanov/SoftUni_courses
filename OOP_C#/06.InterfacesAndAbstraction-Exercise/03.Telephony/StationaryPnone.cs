using System;
using System.Linq;

namespace _03.Telephony
{
    public class StationaryPnone : IPhone
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
                    Console.WriteLine($"Dialing... {number}");
                }
            }
            else
            {
                Console.WriteLine(error);
            }
        }
    }
}
