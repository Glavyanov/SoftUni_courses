using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05ChangeTownNamesCasing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string country = Console.ReadLine();
            List<string> result = new List<string>();

            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string updateTownsQuery = @"UPDATE Towns
                                           SET Name = UPPER(Name)
                                         WHERE CountryCode = (SELECT c.Id 
                                                                FROM Countries AS c 
                                                               WHERE c.Name = @countryName)";
                SqlCommand updateTownsCmd = new SqlCommand(updateTownsQuery, sqlConnection, sqlTransaction);
                updateTownsCmd.Parameters.AddWithValue("@countryName", country);
                int rows = updateTownsCmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine($"{rows} town names were affected.");
                    string getTownNamesQuery = @"SELECT t.Name 
                                               FROM Towns as t
                                               JOIN Countries AS c ON c.Id = t.CountryCode
                                              WHERE c.Name = @countryName";

                    SqlCommand getTownNamesCmd = new SqlCommand(getTownNamesQuery, sqlConnection, sqlTransaction);
                    getTownNamesCmd.Parameters.AddWithValue(@"countryName", country);
                    using SqlDataReader townNamesReader = getTownNamesCmd.ExecuteReader();

                    while (townNamesReader.Read())
                    {
                        result.Add(townNamesReader["Name"].ToString());
                    }
                    townNamesReader.Close();
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                Console.WriteLine(ex.ToString());
            }

            sqlConnection.Close();

        }

    }
}