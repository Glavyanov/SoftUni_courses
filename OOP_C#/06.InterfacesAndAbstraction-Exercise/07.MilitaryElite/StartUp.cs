using _07.MilitaryElite.Models;
using _07.MilitaryElite.Soldiers;
using System;
using System.Collections.Generic;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArgs[0];

                Soldier soldier = null;

                if (type == "Private")
                {
                    soldier = new Private(int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3], decimal.Parse(cmdArgs[4]));

                }
                else if (type == "LieutenantGeneral")
                {
                    soldier = new LieutenantGeneral(int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3], decimal.Parse(cmdArgs[4]));
                    for (int i = 5; i < cmdArgs.Length; i++)
                    {
                        if (soldiers.ContainsKey(int.Parse(cmdArgs[i])))
                        {
                            var soldierToGeneral = soldier as LieutenantGeneral;
                            soldierToGeneral.Privates.Add(soldiers[int.Parse(cmdArgs[i])]);

                        }
                    }

                }
                else if (type == "Engineer")
                {
                    bool isValidCorps = Enum.TryParse(cmdArgs[5], out Corps corps);
                    if (!isValidCorps)
                    {
                        continue;
                    }
                    soldier = new Engineer(int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3], decimal.Parse(cmdArgs[4]), corps);
                    for (int i = 6; i < cmdArgs.Length; i += 2)
                    {
                        Repair repair = new Repair(cmdArgs[i], int.Parse(cmdArgs[i + 1]));
                        var soldierToEngineer = soldier as Engineer;
                        soldierToEngineer.Repairs.Add(repair);
                    }

                }
                else if (type == "Commando")
                {
                    bool isValidCorps = Enum.TryParse(cmdArgs[5], out Corps corps);
                    if (!isValidCorps)
                    {
                        continue;
                    }
                    soldier = new Commando(int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3], decimal.Parse(cmdArgs[4]), corps);
                    for (int i = 6; i < cmdArgs.Length; i += 2)
                    {
                        bool isValidStatus = Enum.TryParse(cmdArgs[i + 1], out Status status);
                        if (!isValidStatus)
                        {
                            continue;
                        }
                        IMission mission = new Mission(cmdArgs[i], status);
                        var soldierToCommando = soldier as Commando;
                        soldierToCommando.Missions.Add(mission);
                    }
                }
                else if (type == "Spy")
                {
                    soldier = new Spy(int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3], int.Parse(cmdArgs[4]));
                }
                if (!soldiers.ContainsKey(int.Parse(cmdArgs[1])))
                {
                    if (soldier != null)
                    {
                        soldiers.Add(int.Parse(cmdArgs[1]), soldier);
                    }
                }

            }
            foreach (var item in soldiers)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
