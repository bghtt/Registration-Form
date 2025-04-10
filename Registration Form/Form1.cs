
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
        private readonly Form2 _mainForm;
        public Form1()
        {
            InitializeComponent();
            _mainForm = new Form2();
            _authService = new Autorizathion(_connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = loginField.Text;
            string password = passwordField.Text;

            if (new Autorizathion(_connectionString).validateUser(login, password, this,_mainForm))
            {
                return;
            }
            var result = MessageBox.Show("Пользователь не найден. Хотите зарегистрироваться?",
                                   "Регистрация",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                button2.PerformClick();
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
            UserRegistration reg = new UserRegistration(_connectionString);
            reg.RegisterUser(login, password);
        }
    }
}
