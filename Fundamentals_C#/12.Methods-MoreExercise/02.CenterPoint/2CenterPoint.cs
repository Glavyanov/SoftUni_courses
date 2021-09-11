using System;

namespace MethodsMoreExersice1
{
    class CenterPoint
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            int result = GetPointCloseToZero(GetFirstPoint(x1, y1), GetSecondPoint(x2, y2));
            if (result < 0)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (result > 0)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");
            }
        }

        private static int GetPointCloseToZero(double result1, double result2)
        {
            if (result1 < result2)
            {
                return -1;
            }
            else if (result2 < result1)
            {
                return 1;
            }
            return 0;
        }
        private static double GetFirstPoint(double x1, double y1)
        {
            double result = Math.Sqrt(Math.Abs(x1 * x1) + Math.Abs(y1 * y1));
            return result;
        }

        private static double GetSecondPoint(double x2, double y2)
        {
            double result = Math.Sqrt(Math.Abs(x2 * x2) + Math.Abs(y2 * y2));
            return result;
        }


    }
}
