using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _02.AverageStudentGrades
{
    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (!students.TryAdd(studentInfo[0], new List<decimal>() { decimal.Parse(studentInfo[1]) }))
                {
                    students[studentInfo[0]].Add(decimal.Parse(studentInfo[1]));
                }
            }
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x=> x.ToString("F2")))} (avg: {student.Value.Average():F2})");
            }

        }
    }
}
