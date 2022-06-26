using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace _04AddMinion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine()
                                         .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1]
                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .ToArray();
            string villainName = Console.ReadLine()
                                          .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1];
            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];
            StringBuilder result = new StringBuilder();

            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();
            SqlTransaction addMinionTransaction = sqlConnection.BeginTransaction();
            try
            {
                string getTownIdQuery = @"SELECT Id FROM Towns WHERE Name = @townName";
                int townId;
                SqlCommand getTownCmd = new SqlCommand(getTownIdQuery, sqlConnection, addMinionTransaction);
                getTownCmd.Parameters.AddWithValue("@townName", minionTown);
                object townIdCheck = getTownCmd.ExecuteScalar();
                if (townIdCheck == null)
                {
                    string insertTownQuery = @"INSERT INTO Towns (Name) VALUES (@townName)";
                    SqlCommand insertTownCmd = new SqlCommand(insertTownQuery, sqlConnection, addMinionTransaction);
                    insertTownCmd.Parameters.AddWithValue("@townName", minionTown);
                    insertTownCmd.ExecuteNonQuery();
                    townId = (int)getTownCmd.ExecuteScalar();
                    result.AppendLine($"Town {minionTown} was added to the database.");
                }
                else
                {
                    townId = (int)townIdCheck;
                }

                string getVillainIdQuery = @"SELECT Id FROM Villains WHERE Name = @Name";
                int villainId;
                SqlCommand getVillainCmd = new SqlCommand(getVillainIdQuery, sqlConnection, addMinionTransaction);
                getVillainCmd.Parameters.AddWithValue("@Name", villainName);
                object villainIdCheck = getVillainCmd.ExecuteScalar();
                if (villainIdCheck == null)
                {
                    string insertVillainQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                    SqlCommand insertVillainCmd = new SqlCommand(insertVillainQuery, sqlConnection, addMinionTransaction);
                    insertVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                    insertVillainCmd.ExecuteNonQuery();
                    villainId = (int)getVillainCmd.ExecuteScalar();
                    result.AppendLine($"Villain {villainName} was added to the database.");
                }
                else
                {
                    villainId = (int)villainIdCheck;
                }

                string insertMinionQuery = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";
                SqlCommand insertMinionCmd = new SqlCommand(insertMinionQuery, sqlConnection, addMinionTransaction);
                insertMinionCmd.Parameters.AddWithValue("@nam", minionName);
                insertMinionCmd.Parameters.AddWithValue("@age", minionAge);
                insertMinionCmd.Parameters.AddWithValue("@townId", townId);
                insertMinionCmd.ExecuteNonQuery();

                string getMinionIdQuery = @"SELECT Id 
                                              FROM Minions 
                                             WHERE [Name] = @Name AND [Age] = @Age AND [TownId] = @TownId";
                SqlCommand getMinionCmd = new SqlCommand(getMinionIdQuery, sqlConnection, addMinionTransaction);
                getMinionCmd.Parameters.AddWithValue("@Name", minionName);
                getMinionCmd.Parameters.AddWithValue("@Age", minionAge);
                getMinionCmd.Parameters.AddWithValue("@TownId", townId);
                int minionId = (int)getMinionCmd.ExecuteScalar();


                string insertMinionsVillainQuery = @"INSERT INTO MinionsVillains (MinionId, VillainId)
                                                            VALUES 
                                                                  (@minionId, @villainId)";

                SqlCommand insertMinionsVillainCmd =
                    new SqlCommand(insertMinionsVillainQuery, sqlConnection, addMinionTransaction);
                insertMinionsVillainCmd.Parameters.AddWithValue("@villainId", villainId);
                insertMinionsVillainCmd.Parameters.AddWithValue("@minionId", minionId);
                insertMinionsVillainCmd.ExecuteNonQuery();
                result.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                addMinionTransaction.Commit();
            }
            catch (Exception ex)
            {
                addMinionTransaction.Rollback();
                sqlConnection.Close();
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(result.ToString().TrimEnd());
            sqlConnection.Close();
        }

    }
}