using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Logging;
using Npgsql;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Registration_Form
{
    internal class Autorizathion
    {
        private static AppDbContext Context = new AppDbContext();

        public static bool ValidateUser(string login, string password)
        {
            if(string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return false;
            }

            if (VerifyPassword(login, password))
            {
                return true;
            }

            MessageBox.Show("Incorrect password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public static bool GetUserExists(string login)
        {
            return Context.Users.Any(x => x.Name == login);
        }

        private static bool VerifyPassword(string login, string inputPassword)
        {
            return PasswordHasher.VerifyPassword(inputPassword, Context.Users.FirstOrDefault(x => x.Name == login).Password);
        }
    }
}