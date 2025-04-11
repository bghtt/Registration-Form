using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_Form
{
    public partial class Form2 : Form
    {
        private readonly Form _previousForm;
        public Form2(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;

            this.FormClosed += (s, args) =>
            {
                _previousForm.Close();
            };
        }
    }
}
