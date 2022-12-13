using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager_Desktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEmptyPrompt()) MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(isEmptyPrompt()) MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            string password = textBox2.Text;
            string[] s = {textBox1.Text, textBox2.Text};




        }

        private bool isEmptyPrompt()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)) return true;
            return false;
        }
 
    }
}
