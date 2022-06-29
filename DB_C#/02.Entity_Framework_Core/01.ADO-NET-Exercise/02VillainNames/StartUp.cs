using System;
using System.Text;
using Microsoft.Data.SqlClient;


namespace _02VillainNames
{
    public static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        sqlConnection.Open();

        string villainsQuery = @"     SELECT v.[Name] 
                                               , COUNT(mv.MinionId) AS [Count]
                                            FROM Villains AS v
                                            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                        GROUP BY v.[Name]
                                          HAVING COUNT(mv.MinionId) > 3
                                        ORDER BY [Count] DESC";

        SqlCommand villiansNamesCmd = new SqlCommand(villainsQuery, sqlConnection);
        using SqlDataReader readerVillains = villiansNamesCmd.ExecuteReader();
        while (readerVillains.Read())
        {
            sb.AppendLine($"{readerVillains["Name"]} - {readerVillains["Count"]}");
        }

        readerVillains.Close();
        sqlConnection.Close();

        Console.WriteLine(sb.ToString().TrimEnd());
    }
}
