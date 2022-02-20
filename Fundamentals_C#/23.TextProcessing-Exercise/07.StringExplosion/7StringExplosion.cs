using System;
using System.Text;

namespace _07.StringExplosion
{
    class StringExplosion
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            bool flag = false;
            bool moreThanOne = false;
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (current == '>')
                {
                    result.Append(current);
                    flag = true;
                    if (moreThanOne)
                    {

                    }
                    continue;
                }
                if (char.IsDigit(current) && flag)
                {

                    int bombPower = int.Parse(current.ToString());
                    if (moreThanOne)
                    {
                        counter += bombPower;
                        counter--;
                        continue;
                    }
                    if (bombPower == 0)
                    {
                        result.Append(current);
                    }
                    else if (bombPower < 2)
                    {
                        flag = false;
                        bombPower--;
                        continue;
                    }
                    else
                    {
                        moreThanOne = true;
                        counter = bombPower;
                        counter--;
                        flag = false;
                        continue;
                    }

                }
                if (moreThanOne)
                {
                    flag = false;
                    counter--;
                    if (counter == 0)
                    {
                        moreThanOne = false;
                    }
                    continue;

                }
                result.Append(current);

            }
            Console.WriteLine(result);
        }
    }
}
