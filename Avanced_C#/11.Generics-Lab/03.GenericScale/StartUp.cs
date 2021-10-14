using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var intCheck = new EqualityScale<int>(5, 8);
            var intCheckNext = new EqualityScale<int>(6, 6);

            Console.WriteLine(intCheck.AreEqual());
            Console.WriteLine(intCheckNext.AreEqual());
        }
    }
}
