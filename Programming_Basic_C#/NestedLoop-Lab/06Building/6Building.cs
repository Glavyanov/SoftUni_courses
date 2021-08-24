using System;

namespace _06Building
{
    class Building
    {
        static void Main(string[] args)
        {
            int numFloor = int.Parse(Console.ReadLine());
            int numRoom = int.Parse(Console.ReadLine());
            int extension = 0;
            int lastFloor = 0;
            while (numFloor != 0)
            {
                for (int i = numRoom; i > 0; i--)
                {
                    if (numFloor == numFloor && lastFloor == 0)
                    {
                        for (int j = numRoom; j > 0; j--)
                        {
                            Console.Write($"L{numFloor}{extension} ");
                            extension++;
                        }
                        extension = 0;
                        lastFloor = 1;
                        break;
                    }
                    if (lastFloor == 1)
                    {
                        if (numFloor % 2 == 0)
                        {
                            for (int l = numFloor; l > 1; l--)
                            {

                                for (int j = numRoom; j > 0; j--)
                                {
                                    Console.Write($"O{l}{extension} ");
                                    extension++;
                                }
                                extension = 0;
                                Console.WriteLine();
                                l--;
                                for (int k = numRoom; k > 0; k--)
                                {
                                    Console.Write($"A{l}{extension} ");
                                    extension++;
                                }
                                extension = 0;
                                Console.WriteLine();
                            }
                            return;
                        }
                        else
                        {
                            for (int l = numFloor; l > 0; l--)
                            {
                                for (int j = numRoom; j > 0; j--)
                                {
                                    Console.Write($"A{l}{extension} ");
                                    extension++;
                                }
                                extension = 0;
                                Console.WriteLine();
                                l--;
                                if (l == 0)
                                {
                                    return;
                                }
                                for (int k = numRoom; k > 0; k--)
                                {
                                    Console.Write($"O{l}{extension} ");
                                    extension++;
                                }
                                extension = 0;
                                Console.WriteLine();
                            }
                            return;
                        }
                    }
                }
                Console.WriteLine();
                numFloor--;
            }
        }
    }
}
