using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Registration_Form
{
    public class UserRegistration
    {
        private readonly string _connectionString;

        public UserRegistration(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool RegisterUser(string login, string password)
        {
            if (UserExsist(login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string passwordHash = PasswordHasher.HashPassword(password);

            try
            {
                using(var connection = new NpgsqlConnection(_connectionString))
                using(var cmd = new NpgsqlCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;

                    cmd.CommandText = @"INSERT INTO ""Пользователи"" (""Name"", ""password"") VALUES(@login, @password)";
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", passwordHash);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Регистрация прошла успешно!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch
            {
                MessageBox.Show($"Ошибка при регистрации", "Ошибка",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool UserExsist(string login)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                using (var cmd = new NpgsqlCommand())
                {
                    connection.Open();
                    cmd.Connection = connection;

                    cmd.CommandText = @"SELECT 1 FROM ""Пользователи"" WHERE ""Name"" = @login LIMIT 1";
                    cmd.Parameters.AddWithValue("@login", login);

                    return cmd.ExecuteScalar() != null;
                }

            }
            catch
            {
                return false;
            }
        }
    }

}
