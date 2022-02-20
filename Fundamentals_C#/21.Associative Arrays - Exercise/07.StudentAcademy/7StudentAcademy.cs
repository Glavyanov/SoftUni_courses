using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.StudentAcademy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var logger = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!logger.ContainsKey(name))
                {
                    logger.Add(name, new List<double>());
                }
                logger[name].Add(grade);

            }
            var highOrEqual4dot50 = logger.Where(x => x.Value.Average() >= 4.50).ToDictionary(x => x.Key, x => x.Value.Sum()/x.Value.Count);// От един речник <string, List<double>> се произвежда друг с <string, double>

           // var high = logger.Where(x => x.Value.Average() >= 4.50).Select(x => x.Value.Average()).ToDictionary(x => x.ToString());

            //var highOrEqual4dot50 = new Dictionary<string, double>();
            //
            //foreach (var item in logger)
            //{
            //    if (item.Value.Average() >= 4.50)
            //    {
            //        highOrEqual4dot50.Add(item.Key, item.Value.Sum()/item.Value.Count);
            //
            //    }
            //}
            foreach (var item in highOrEqual4dot50.OrderByDescending(x=> x.Value))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }
            //?????????????????????????????????????????????????????????????
            //var some = logger.SelectMany(logger =>  new KeyValuePair<string, List<double>>() { }).Where(x => x.Value.Average() >= 4.50);

            // var highOrEqual4dot50 = logger.Where(x => (x.Value.Sum() / x.Value.Count) >= 4.50).Select(x => x.Key).ToDictionary(x => x, x => 1.1);
            //x => logger.Where(x => (x.Value.Sum() / x.Value.Count) >= 4.50).Select(x => x.Value));
            //var highOrEqual4dot50 = logger.Where(x => x.Value.Average() >= 4.50);
            //foreach (var (name, grade) in logger)
            //{
            //    highOrEqual4dot50.Add();
            //}
            //
            //
            //var kind = logger.Where(x => x.Value.Average() >= 4.50);
            //    //Where(x => (x.Value.Sum() / x.Value.Count) >= 4.50).Select(x => x.Value));
            //var some = logger.Where(x => (x.Value.Sum() / x.Value.Count) >= 4.50).Select(x => x.Key).ToString();
            //
            ////(logger.Where(x => (x.Value.Sum() / x.Value.Count) >= 4.50).Select(x => x.Key),
            ////logger.Where(x => (x.Value.Sum() / x.Value.Count) >= 4.50).Select(x => x.Value)).To;
            //List<double> test = new List<double>() { 2.50, 3.50};
            //test.Average();

            /*
             * gfgdfgfd
             * fggadgfdgg
             * gfdagfg
             * agfggggggggggga
             * ag
             */// int fdsfavsfvgsf;
            /*{
                Console.WriteLine("Hello World!");
                Console.WriteLine("Hello World!");  --->  ctrl+shift + /
                Console.WriteLine("Hello World!");
                Console.WriteLine("Hello World!");
            }*/

        }
    }
}
