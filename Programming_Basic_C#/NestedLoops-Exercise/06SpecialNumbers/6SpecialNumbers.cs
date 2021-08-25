using System;

namespace _06SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1111; i <= 9999; i++)
            {
                string convertI = i.ToString();
                for (int j = 0; j < 1; j++)
                {
                    int convertNumOne = int.Parse(convertI[j].ToString());
                    for (int k = 1; k < 2; k++)
                    {
                        int convertNumTwo = int.Parse(convertI[k].ToString());
                        for (int l = 2; l < 3; l++)
                        {
                            int convertNumThree = int.Parse(convertI[l].ToString());
                            for (int m = 3; m < 4; m++)
                            {
                                int convertNumFour = int.Parse(convertI[m].ToString());
                                if (convertNumOne != 0 && convertNumTwo != 0 && convertNumThree != 0 && convertNumFour != 0)
                                {
                                    if (number % convertNumOne == 0 && number % convertNumTwo == 0 && number % convertNumThree == 0 && number % convertNumFour == 0)
                                    {
                                        Console.Write(convertI + " ");
                                    }
                                }

                            }

                        }

                    }

                }

            }


        }
    }
}
