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
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEmptyInput())
            {
                MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Program.Query.ExistInTable(textBox1.Text, "Username", "UserDatabase"))
            {
                MessageBox.Show("Username or Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable userData = Program.Query.GetDataFromTable(textBox1.Text, "Username", "UserDatabase");
            DataRow row = userData.Rows[0];
            string givenHashedPassword = Program.HashAlgorithm.PasswordHashing(textBox2.Text);

            Console.WriteLine(givenHashedPassword);
            Console.WriteLine(row[2].ToString());

            if(givenHashedPassword != row[2].ToString())
            {
                MessageBox.Show("Username or Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Logged in!", "Logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);

            

            Program.SetUsername(textBox1.Text);

            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;

            var mainProgram = new Form2();
            mainProgram.Show();
            this.Hide();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isEmptyInput())
            {
                MessageBox.Show("Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Program.Query.ExistInTable(textBox1.Text, "Username", "UserDatabase"))
            {
                MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string hashedPassword = Program.HashAlgorithm.PasswordHashing(textBox2.Text);
            string[] s = { textBox1.Text, hashedPassword };
            Program.NonQuery.InsertTable(s, "UserDatabase");
            MessageBox.Show("Registered", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Program.NonQuery.CreateUserTable(textBox1.Text);
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;

        }

        private bool isEmptyInput()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)) return true;
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = (textBox2.UseSystemPasswordChar) ? false : true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
