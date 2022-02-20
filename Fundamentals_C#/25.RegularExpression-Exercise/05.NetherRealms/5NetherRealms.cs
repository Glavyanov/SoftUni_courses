using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Demon
    {
        public Demon()
        {

        }
        public string Name { get; set; }
        public int Health { get; set; }
        public decimal Damage { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:F2} damage";
        }

    }
    class NetherRealms
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Regex healthCatch = new Regex(@"[^0-9+\-*\/.]");
            Regex damageCatch = new Regex(@"-?[0-9]+([\.][0-9]+)?");
            List<Demon> allDemons = new List<Demon>();
            for (int i = 0; i < names.Length; i++)
            {
                string accepted = names[i];
                var healthssss = accepted
                    .Where(s => !char.IsDigit(s)
                    && s != '+' && s != '-' && s != '*' && s != '/' && s != '.')
                    .Sum(s => (int)s);
                MatchCollection demonHealth = healthCatch.Matches(accepted);
                int health = 0;
                for (int j = 0; j < demonHealth.Count; j++)
                {
                    char current = char.Parse(demonHealth[j].Value);
                    health += current;
                }
                decimal damage = 0M;
                if (accepted.Any(x=> char.IsDigit(x)))
                {
                    MatchCollection demonDamage = damageCatch.Matches(accepted);
                    for (int k = 0; k < demonDamage.Count; k++)
                    {
                        string current = demonDamage[k].Value;
                        decimal number = decimal.Parse(current);
                        damage += number;
                    }
                    if (accepted.Contains('*') || accepted.Contains('/'))
                    {
                        foreach (var item in accepted)
                        {
                            if (item == '*')
                            {
                                damage *= 2;
                            }
                            else if (item == '/')
                            {
                                damage /= 2;
                            }
                        }
                    }
                }
                Demon demon = new Demon()
                {
                    Name = accepted,
                    Health = health,
                    Damage = damage

                };
                allDemons.Add(demon);
                
            }
            foreach (var item in allDemons.OrderBy(x=> x.Name))
            {
                Console.WriteLine(item);
            }
        }
    }
}
