using System;
using System.Linq;

namespace _03.Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] adresses = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            SmartPhone phoneSmart = new SmartPhone();
            StationaryPnone phoneStat = new StationaryPnone();
            
            foreach (var item in numbers)
            {
                if (item.Length > 7)
                {
                    phoneSmart.Calling(item);
                }
                else
                {
                    phoneStat.Calling(item);
                }
            }
            foreach (var item in adresses)
            {
                phoneSmart.Browsing(item);
            }
        }
    }
}
