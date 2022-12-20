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
    public partial class AddKeyForm : Form
    {
        
        public AddKeyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEmptyPrompt())
            {
                MessageBox.Show("Missing Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string username = Program.GetUsername();
            if (Program.Query.ExistInTable(titleTextBox.Text, "Title", username))
            {
                MessageBox.Show($"Account already exists in {titleTextBox.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable data = Program.Query.GetDataFromTable(username, "username", "UserDatabase");
            DataRow row = data.Rows[0];

            byte[] key = (byte[])row[3];
            byte[] iv = (byte[])row[4];
            
            byte[] encryptedPassword = Program.AESAlgorithm.EncryptStringToBytes(passwordTextBox.Text, key, iv);
            string[] columns = { titleTextBox.Text, usernameTextBox.Text, urlTextBox.Text };
            Program.NonQuery.InsertTable(columns, encryptedPassword ,username);

            titleTextBox.Text = String.Empty;
            usernameTextBox.Text = String.Empty;
            passwordTextBox.Text = String.Empty;
            urlTextBox.Text = String.Empty;


            MessageBox.Show("Success! Please refresh the table to view your inserted values!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private bool isEmptyPrompt()
        {
            return (titleTextBox.Text == String.Empty || usernameTextBox.Text == String.Empty || passwordTextBox.Text == String.Empty || urlTextBox.Text == String.Empty);
        }

        private void AddKeyForm_Load(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = (passwordTextBox.UseSystemPasswordChar) ? false : true;
        }
    }
}
