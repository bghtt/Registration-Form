
using System.Data;
using System.Net.Http.Headers;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Registration_Form
{
    public partial class Form1 : Form
    {
        private readonly string _connectionString = "server=localhost;Port=5432;Database=aboba;User Id = postgres; Password=rootroot";
        private readonly Autorizathion _authService;
        public Form1()
        {
            InitializeComponent();
            _authService = new Autorizathion(_connectionString);
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = loginField.Text;
            string password = passwordField.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var auth = new Autorizathion(_connectionString))
                    {
                        bool userExists = auth.GetUserExist(connection, login);

                        if (!userExists)
                        {

                            var result = MessageBox.Show("Пользователь не найден. Хотите зарегистрироваться?",
                                                      "Регистрация",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                button2.PerformClick();
                            }
                            return;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show($"Ошибка авторизации", "Ошибка",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_authService.validateUser(login, password, this))
            {
                this.Hide();
                using (var mainForm = new Form2(this))
                {
                    mainForm.ShowDialog();
                }
                this.Close();
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
                using (UserRegistration reg = new UserRegistration(_connectionString))
                {
                    bool isRegistered = reg.RegisterUser(login, password);

                    if (isRegistered)
                    {
                        MessageBox.Show("Регистрация прошла успешно!", "Успех",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось зарегистрировать пользователя", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
