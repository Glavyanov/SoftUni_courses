using System;
using System.Collections.Generic;
using System.Linq;


namespace _06.Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string course = cmdArgs[0];
                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }
                courses[course].Add(cmdArgs[1]);

            }
            foreach (var (course, list) in courses.OrderByDescending(x=> x.Value.Count))
            {
                Console.WriteLine($"{course}: {list.Count}");
                foreach (var item in list.OrderBy(x=> x))
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
