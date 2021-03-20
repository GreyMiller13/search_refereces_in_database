using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Search_references_in_DB
{
    class DB
    {
        public List<string> db_list = new List<string>();

        public static string conn_str = "Server = mysql60.hostland.ru; Database = host1323541_itstep32; Uid = host1323541_itstep; Pwd = 269f43dc;";
        public static MySqlConnection connection = new MySqlConnection(conn_str);
        public static string sql = "SELECT reference FROM search_system_referens_table;";
        public MySqlCommand command = new MySqlCommand
        {
            Connection = connection,
            CommandText = sql
        };

        public DB()
        {
            connection.Open();
            var result = command.ExecuteReader();
            while(result.Read())
            {
                var tempReference = result.GetString("reference");
                db_list.Add(tempReference);
            }
            connection.Close();
        }

        public void ShowDBList()
        {
            foreach (var item in db_list)
            {
                Console.WriteLine($"{item}");
            }
        }

        public void InsertIntoDB()
        {
            connection.Open();
            for (int i = 0; i < db_list.Count; i++)
            {
                sql = $"INSERT INTO search_system_referens_table (reference) VALUES ('{db_list[i]}');";
                command.CommandText = sql;
                var res = command.ExecuteNonQuery();
                if (res == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные не добавились");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Данные добавились");
                    Console.ResetColor();
                }
            }
            connection.Close();
        }
    }
}
