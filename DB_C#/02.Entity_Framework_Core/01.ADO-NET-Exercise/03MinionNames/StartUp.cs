using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace WorkTable
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();
            string getNameQuery = @"SELECT [Name] 
                                      FROM Villains
                                     WHERE [Id] = @ID";

            SqlCommand getVillainNameCmd = new SqlCommand(getNameQuery, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@ID", id);
            string villainName = (string)getVillainNameCmd.ExecuteScalar();

            if (string.IsNullOrEmpty(villainName))
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
                sqlConnection.Close();
                Environment.Exit(0);
            }
            sb.AppendLine($"Villain: {villainName}");
            string getMinionsQuery = @" SELECT m.[Name]
                                             , m.[Age]
                                          FROM MinionsVillains AS mv
                                          JOIN Minions AS m ON mv.MinionId = m.Id
                                         WHERE mv.VillainId = @ID";

            SqlCommand getMInionsCmd = new SqlCommand(getMinionsQuery, sqlConnection);
            getMInionsCmd.Parameters.AddWithValue("@ID", id);
            using SqlDataReader minionsReader = getMInionsCmd.ExecuteReader();

            if (!minionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
                Console.WriteLine(sb.ToString().TrimEnd());
                sqlConnection.Close();
            }
            else
            {
                int row = 1;
                while (minionsReader.Read())
                {
                    sb.AppendLine($"{row++}. {minionsReader["Name"]} {minionsReader["Age"]}");
                }
                Console.WriteLine(sb.ToString().TrimEnd());
                minionsReader.Close();
                sqlConnection.Close();

            }

        }

    }
}

