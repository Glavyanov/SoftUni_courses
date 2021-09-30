using System;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            if (number == "0" || multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }
            StringBuilder result = new StringBuilder();
            int currentReminder = 0;
            bool haveReminder = false;
            while (number.Length != 0)
            {
                int current = int.Parse(number[number.Length-1].ToString());
                int multiply = current * multiplier;
                if (multiply > 9)
                {
                    int numToAdd = multiply % 10;
                    int reminder = multiply / 10;
                    if (haveReminder)
                    {
                        numToAdd = (numToAdd + currentReminder) % 10;
                        reminder = (multiply+ currentReminder) / 10;

                    }
                    result.Insert(0, numToAdd);

                    currentReminder = reminder;
                    haveReminder = true;
                }
                else
                {
                    if (haveReminder)
                    {
                        multiply += currentReminder;
                        if (multiply > 9)
                        {
                            int numToAdd = multiply % 10;
                            int reminder = multiply  / 10;

                            result.Insert(0, numToAdd);

                            currentReminder = reminder;
                            haveReminder = true;
                        }
                        else
                        {
                            result.Insert(0, multiply);
                            currentReminder = 0;
                            haveReminder = false;
                        }
                    }
                    else
                    {
                        result.Insert(0, multiply);
                    }
                }
                number = number.Remove(number.Length - 1);

            }
            if (haveReminder)
            {
                result.Insert(0, currentReminder);
            }
            Console.WriteLine(result);
        }
    }
}
