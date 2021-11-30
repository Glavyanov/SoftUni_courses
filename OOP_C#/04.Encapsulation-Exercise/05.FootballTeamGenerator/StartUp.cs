using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            List<Team> teams = new List<Team>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action == "Team")
                {
                    try
                    {
                        Team team = new Team(cmdArgs[1]);
                        teams.Add(team);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }

                }
                else if (action == "Add")
                {
                    if (teams.Any(t => t.Name == cmdArgs[1]))
                    {
                        try
                        {
                            int endurance = int.Parse(cmdArgs[3]);
                            int sprint = int.Parse(cmdArgs[4]);
                            int dribble = int.Parse(cmdArgs[5]);
                            int passing = int.Parse(cmdArgs[6]);
                            int shooting = int.Parse(cmdArgs[7]);
                            var player = new Player(cmdArgs[2], endurance, sprint, dribble, passing, shooting);
                            teams.FirstOrDefault(t => t.Name == cmdArgs[1]).AddPlayer(player);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {cmdArgs[1]} does not exist.");
                        continue;
                    }

                }
                else if (action == "Remove")
                {
                    if (teams.Any(t => t.Name == cmdArgs[1]))
                    {
                        try
                        {
                            teams.FirstOrDefault(t => t.Name == cmdArgs[1]).RemovePlayer(cmdArgs[2]);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {cmdArgs[1]} does not exist.");
                        continue;
                    }

                }
                else if (action == "Rating")
                {
                    if (teams.Any(t => t.Name == cmdArgs[1]))
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == cmdArgs[1]);
                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                    else
                    {
                        Console.WriteLine($"Team {cmdArgs[1]} does not exist.");
                        continue;
                    }
                }

            }

        }
    }
}
