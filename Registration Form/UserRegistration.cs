using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Registration_Form
{
    public class UserRegistration
    {
        private static AppDbContext Context = new AppDbContext();

        public static async void RegisterUser(string login, string password)
        {
            if (UserExsist(login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string passwordHash = PasswordHasher.HashPassword(password);

            await Context.AddAsync(new User { Name = login, Password = passwordHash });
            await Context.SaveChangesAsync();

            MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static bool UserExsist(string login)
        {
            return Context.Users.Any(x => x.Name == login);
        }
    }

}
