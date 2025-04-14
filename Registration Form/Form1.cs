
using System.Data;
using System.Net;
using System.Net.Http.Headers;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Registration_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = loginField.Text;
            string password = passwordField.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Autorizathion.GetUserExists(login))
            {
                var result = MessageBox.Show("Пользователь не найден. Хотите зарегистрироваться?",
                                          "Регистрация",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    button2.PerformClick();

                return;
            }

            if (Autorizathion.ValidateUser(login, password))
            {
                Hide();
                using (var mainForm = new Form2(this))
                {
                    mainForm.ShowDialog();
                }
                Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = loginField.Text;
            string password = passwordField.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            try
            {
                UserRegistration.RegisterUser(login, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
