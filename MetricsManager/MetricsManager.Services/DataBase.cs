using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MetricsManager.Dto;

namespace MetricsManager.Services
{
    public class DataBase
    {
        public void CreateRandomDB(string nameDB)
        {
            // Создаем строку подключения в виде базы данных
            string connectionString = $"Data Source=c:\\temp\\Metrics.db; Version=3";
            // Создаем соединение с базой данных
            using (var connection = new SQLiteConnection(connectionString))
            {
                // Открываем соединение
                connection.Open();
                // Создаем объект через который будут выполняться команды к базе данных
                using (var command = new SQLiteCommand(connection))
                    {
                        // задаем новый текст команды для выполнения
                        // удаляем таблицу с метриками если она существует в базе
                        // данных
                        command.CommandText = $"DROP TABLE IF EXISTS {nameDB}";
                        // отправляем запрос в базу данных
                        command.ExecuteNonQuery();
                        // создаем таблицу с метриками
                        command.CommandText = @$"CREATE TABLE {nameDB}(id INTEGER PRIMARY KEY, value INT, time INT)";
                        command.ExecuteNonQuery();

                        // создаем запрос на вставку данных
                        command.CommandText = $"INSERT INTO {nameDB}(value, time) VALUES({new Random().Next(0, 100)}, {new Random().Next(0, 100)})";
                        command.ExecuteNonQuery();
                        command.CommandText = $"INSERT INTO {nameDB}(value, time) VALUES({new Random().Next(0, 100)}, {new Random().Next(0, 100)})";
                        command.ExecuteNonQuery();
                        command.CommandText = $"INSERT INTO {nameDB}(value, time) VALUES({new Random().Next(0, 100)}, {new Random().Next(0, 100)})";
                        command.ExecuteNonQuery();
                        command.CommandText = $"INSERT INTO {nameDB}(value, time) VALUES({new Random().Next(0, 100)}, {new Random().Next(0, 100)})";
                        command.ExecuteNonQuery();
                }
            }
        }
    }
}