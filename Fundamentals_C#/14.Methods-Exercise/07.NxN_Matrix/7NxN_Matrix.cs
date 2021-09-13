using System;

namespace _07NxN_Matrix
{
    class NxN_Matrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintMatrixN(n);
        }
        
        private static void PrintMatrixN(int n)
        {
            for(int i = 0;i<n ;i++ )
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0} ", n);
                }
                Console.WriteLine();
            }
        }
    }
}
