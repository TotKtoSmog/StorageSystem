﻿using Microsoft.Data.SqlClient;
using StorageSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StorageSystem.ViewModel
{
    public static class LocalDBHendler
    {
        private static string path = $@"{Directory.GetCurrentDirectory()}\DataBase\StorageSystemDB.mdf";
        private static readonly string connectionString = 
            $"Server=(localdb)\\mssqllocaldb; AttachDbFilename={path}; Trusted_Connection=True;";
        public async static void TestingLocalDBConneting()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
            }
        }
        public async static Task<Storekeeper> LogIn(string loing, string password)
        {
            Storekeeper result = null;
            string sqlExpression = $"SELECT * FROM EmployeeDate WHERE Login = @loing and Password = @password;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@loing", loing));
                command.Parameters.Add(new SqlParameter("@password", password));
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result = new Storekeeper(
                            (int)reader["Employee_ID"],
                            (string)reader["Last_name"],
                            (string)reader["First_name"],
                            (string)reader["Patronymic"],
                            (string)reader["Login"],
                            (string)reader["Password"],
                            (string)reader["Position"],
                            (string)reader["Phone_Number"],
                            (string)reader["Email"]
                            );
                        }
                    }
                }
            }
            if(result == null)
                Console.WriteLine("Пользователь не найден");
            else
                Console.WriteLine($"{result.Id} {result.Last_name} {result.First_name} {result.Patronymic} {result.PhoneNumber} {result.Email} {result.Position} {result.Login} {result.Password}");
            return result;
        }
    }
}
