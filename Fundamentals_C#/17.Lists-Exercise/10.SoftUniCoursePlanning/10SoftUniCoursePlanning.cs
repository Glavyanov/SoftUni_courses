using System;
using System.Linq;
using System.Collections.Generic;

namespace _10SoftUniCoursePlanning
{
    class SoftUniCoursePlanning
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                                          .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                          .ToList();

            string command = Console.ReadLine();
            while (command != "course start")
            {
                string[] cmdArg = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArg[0];
                if (action == "Add")
                {
                    string nameLesson = cmdArg[1];
                    if (!lessons.Contains(nameLesson))
                    {
                        lessons.Add(nameLesson);
                    }
                }
                else if (action == "Insert")
                {
                    string nameLesson = cmdArg[1];
                    if (!lessons.Contains(nameLesson))
                    {
                        int index = int.Parse(cmdArg[2]);
                        if (index >= 0 && index < lessons.Count)
                        {
                            lessons.Insert(index, nameLesson);
                        }
                    }
                }
                else if (action == "Remove")
                {
                    string nameLesson = cmdArg[1];
                    //lessons.Remove(nameLesson);
                    lessons.RemoveAll(x => x.StartsWith(nameLesson));

                }
                else if (action == "Swap")
                {
                    string nameLesson1 = cmdArg[1];
                    string nameLesson2 = cmdArg[2];
                    if (lessons.Contains(nameLesson1))
                    {
                        if (lessons.Contains(nameLesson2))
                        {
                            int index1 = lessons.FindIndex(x => x == nameLesson1);
                            int index2 = lessons.FindIndex(x => x == nameLesson2);
                            lessons[index1] = nameLesson2;
                            lessons[index2] = nameLesson1;
                            if (lessons.Contains(nameLesson1 +"-Exercise"))
                            {
                                int index = lessons.FindIndex(x => x == nameLesson1 + "-Exercise");
                                lessons.Insert(index2 + 1, nameLesson1 + "-Exercise");
                                lessons.RemoveAt(index);

                            }
                            if (lessons.Contains(nameLesson2 + "-Exercise"))
                            {
                                int index = lessons.FindIndex(x => x == nameLesson2 + "-Exercise");
                                lessons.Insert(index1 + 1, nameLesson2 + "-Exercise");
                                lessons.RemoveAt(index + 1);

                            }
                        }
                    }
                }
                else if (action == "Exercise")
                {
                    string nameLesson = cmdArg[1];
                    if (lessons.Contains(nameLesson))
                    {
                        if (!lessons.Contains(nameLesson +"-"+ action))
                        {
                            int index = lessons.FindIndex(x => x == nameLesson);
                            lessons.Insert(index+1, nameLesson + "-" + action);
                        }

                    }
                    else
                    {
                        lessons.Add(nameLesson);
                        lessons.Add(nameLesson + "-" + action);
                    }
                }

                command = Console.ReadLine();
            }
            for (int i = 1; i <= lessons.Count; i++)
            {
                Console.WriteLine($"{i}.{lessons[i-1]}");
            }


        }
    }
}
