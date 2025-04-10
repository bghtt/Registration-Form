namespace Registration_Form
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginField = new TextBox();
            passwordField = new TextBox();
            buttonLogin = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // loginField
            // 
            loginField.Location = new Point(116, 62);
            loginField.Name = "loginField";
            loginField.Size = new Size(147, 23);
            loginField.TabIndex = 0;
            // 
            // passwordField
            // 
            passwordField.Location = new Point(116, 91);
            passwordField.Name = "passwordField";
            passwordField.Size = new Size(147, 23);
            passwordField.TabIndex = 1;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(144, 120);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "Войти";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // button2
            // 
            button2.Location = new Point(125, 149);
            button2.Name = "button2";
            button2.Size = new Size(119, 28);
            button2.TabIndex = 3;
            button2.Text = "Регистрация";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 62);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 4;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 94);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 5;
            label2.Text = "Пароль";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 229);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(buttonLogin);
            Controls.Add(passwordField);
            Controls.Add(loginField);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginField;
        private TextBox passwordField;
        private Button buttonLogin;
        private Button button2;
        private Label label1;
        private Label label2;
    }
}
