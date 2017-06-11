using Npgsql;
using System;

namespace Gym.PostgreSQL
{
    public class PostgreSql
    {
        private string conntectionString = "server=localhost;user id=postgres;password=3343568;database=Gym";

        public PostgreSql() { }

        public void GetData(string tableName)
        {
            using (var psql = new NpgsqlConnection(this.conntectionString))
            {
                psql.Open();

                var command = new NpgsqlCommand("select * from " + tableName, psql);
                
                var result = command.ExecuteReader();
                
                while(result.Read())
                {
                    Console.WriteLine("ID: " + result[0] + " Name: " + result[1]);
                }
                
                psql.Close();
            }
        }
    }
}
