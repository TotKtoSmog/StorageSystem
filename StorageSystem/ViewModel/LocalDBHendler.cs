﻿using Microsoft.Data.SqlClient;
using StorageSystem.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public async static Task<List<DocumentStatus>> GetDocumentStatus()
        {
            List<DocumentStatus> documentTypes = new List<DocumentStatus>();
            string sqlExpression = "SELECT * FROM Document_Status;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            documentTypes.Add(
                                new DocumentStatus(
                                    (int)reader["Document_status_ID"],
                                    (string)reader["Document_status_name"]
                                    )
                                );
                        }
                    }
                }
            }
            return documentTypes;
        }
        public async static Task<List<DocumentType>> GetDocumentType()
        {
            List<DocumentType> documentTypes = new List<DocumentType>();
            string sqlExpression = "SELECT * FROM Document_Type;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            documentTypes.Add(
                                new DocumentType( 
                                    (int)reader["Document_type_ID"],
                                    (string)reader["Document_type_name"]
                                    )
                                );
                        }
                    }
                }
            }
            return documentTypes;
        }
        public async static Task<List<DocumentView>> GetDocumentInfo()
        {
            List<DocumentView> documentViews = new List<DocumentView>();
            string sqlExpression = "SELECT * FROM document_info;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            documentViews.Add(
                                new DocumentView(
                                    (int)reader["Document_ID"],
                                    reader["Document_title"].ToString(),
                                    reader["Document_type"].ToString(),
                                    reader["Creator"].ToString(),
                                    reader["Document_description"].ToString(),
                                    reader["Document_date"].ToString(),
                                    reader["Document_posting_date"].ToString(),
                                    reader["Partner"].ToString(), 
                                    reader["Based_On"].ToString(),
                                    reader["Document_status"].ToString(), 
                                    reader["Total_Price_Without_Taxes"].ToString(),
                                    reader["Total_Price_With_Taxes"].ToString(),
                                    reader["Source_Warehouse"].ToString(),
                                    reader["Destination_Warehouse"].ToString(),
                                    reader["Documnet_viewed"].ToString()
                                    )
                                );
                        }
                    }
                }
            }
            return documentViews;
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
                            (string)reader["Position_title"],
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
        public async static Task<string> UpdateStorekeeper(Storekeeper storekeeper)
        {
            string resutl = "Данные обновлены";
            string sqlExpression = $"UPDATE Employee SET Last_name = @last_name, " +
                $"First_name = @first_name, Patronymic = @partonymic, " +
                $"Phone_Number = @phone_number, Email = @email, " +
                $"Login = @login, Password = @password WHERE Employee_id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@last_name", storekeeper.Last_name));
                command.Parameters.Add(new SqlParameter("@first_name", storekeeper.First_name));
                command.Parameters.Add(new SqlParameter("@partonymic", storekeeper.Patronymic));
                command.Parameters.Add(new SqlParameter("@phone_number", storekeeper.PhoneNumber));
                command.Parameters.Add(new SqlParameter("@email", storekeeper.Email));
                command.Parameters.Add(new SqlParameter("@login", storekeeper.Login));
                command.Parameters.Add(new SqlParameter("@password", storekeeper.Password));
                command.Parameters.Add(new SqlParameter("@id", storekeeper.Id));

                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                { 
                    resutl = $"Ошибка при обновлении данных {ex.Message}";
                }
                return resutl;
            }
        }
    }
}