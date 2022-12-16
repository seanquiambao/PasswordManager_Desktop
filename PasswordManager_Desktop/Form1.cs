using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;

using System.Data.SqlClient;

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
            if (isEmptyInput())
            {
                MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Program.sql.ExistInTable(textBox1.Text, "Username", "UserDatabase"))
            {
                MessageBox.Show("Username or Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isEmptyInput())
            {
                MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Program.sql.ExistInTable(textBox1.Text, "Username", "UserDatabase"))
            {
                MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Random rand = new Random();
            int iteration = rand.Next(1000, 9999);
            string hashedPassword = Program.HashAlgorithm.PasswordHashing(textBox2.Text, iteration);
            string[] s = { textBox1.Text, hashedPassword, iteration.ToString() };
            Program.sql.InsertTable(s, "UserDatabase");
            MessageBox.Show("Registered", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private bool isEmptyInput()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)) return true;
            return false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
