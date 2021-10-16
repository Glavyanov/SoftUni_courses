using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebrationCAdvancedRetakeExam_18August2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>();
            int[] assignGuests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (var item in assignGuests)
            {
                guests.Enqueue(item);
            }
            Stack<int> plates = new Stack<int>();
            int[] assignPlates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (var item in assignPlates)
            {
                plates.Push(item);
            }
            int wastedGramsFood = 0;
            while (guests.Count != 0 | plates.Count != 0)
            {
                int guestGrams = guests.Peek();
                int platesGrames = plates.Pop();
                if (guestGrams <= platesGrames)
                {
                    guests.Dequeue();
                    wastedGramsFood += (platesGrames - guestGrams);
                }
                else
                {
                    guestGrams -= platesGrames;
                    while (guestGrams > 0)
                    {
                        guestGrams -= plates.Pop();
                        if (guestGrams < 0)
                        {
                            wastedGramsFood += Math.Abs(guestGrams);
                        }
                    }
                    guests.Dequeue();
                }

            }
            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");
                Console.WriteLine($"Wasted grams of food: {wastedGramsFood}");
            }
            if (plates.Count > 0 )
            {
                Console.WriteLine($"Plates: {string.Join(' ', plates)}");
                Console.WriteLine($"Wasted grams of food: {wastedGramsFood}");
            }

        }
    }
}
