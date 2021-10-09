using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _06.ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = Regex.Split(command, ", ");
                if (cmdArgs[0].ToUpper() == "IN")
                {
                    cars.Add(cmdArgs[1]);
                }
                else if (cmdArgs[0].ToUpper() == "OUT")
                {
                    if (cars.Contains(cmdArgs[1]))
                    {
                        cars.Remove(cmdArgs[1]);
                    }
                }

            }
            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
