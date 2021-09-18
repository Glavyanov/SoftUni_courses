using System;
using System.Collections.Generic;

namespace _01.AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] phrs = {
                 "Excellent product.",
                 "Such a great product.",
                 "I always use that product.",
                 "Best product of its category.",
                 "Exceptional product.",
                 "I can’t live without this product."
            };

            string[] evn = {
                 "Now I feel good.",
                 "I have succeeded with this product.",
                 "Makes miracles. I am happy of the results!",
                 "I cannot believe but now I feel awesome.",
                 "Try it yourself, I am very satisfied.",
                 "I feel great!"
            };

            string[] auth = {
                 "Diana",
                 "Petya",
                 "Stella",
                 "Elena",
                 "Katya",
                 "Iva",
                 "Annie",
                 "Eva"
            };

            string[] citie = {
                 "Burgas",
                 "Sofia",
                 "Plovdiv",
                 "Ruse",
                 "Varna"
            };
            Phrase phrase = new Phrase(phrs, evn, auth, citie);

            for (int i = 0; i < n; i++)
            {
                Random rnd = new Random();
                int phrase1 = rnd.Next(5);
                int events1 = rnd.Next(5);
                int author1 = rnd.Next(7);
                int city1 = rnd.Next(4);
                Console.WriteLine($"{phrase.Phrases[phrase1]} {phrase.Events[events1]} {phrase.Authors[author1]} - {phrase.Cities[city1]}");

            }


        }// Phrase(string[] phrase, string[] events, string[] author, string[] city)
    }
    class Phrase
    {
        public Phrase(string[] phrase , string[] evn, string[] auth, string[] city)
        {
            Events = evn;
            Authors = auth;
            Phrases = phrase;
            Cities = city;
                
        }

        public string[] Phrases { get; set; }
        public string[] Events { get; set; }
        public string[] Authors { get; set; }
        public string[] Cities { get; set; }
    }

}
