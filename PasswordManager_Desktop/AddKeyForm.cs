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
            
            string[] columns = { titleTextBox.Text, usernameTextBox.Text, passwordTextBox.Text, urlTextBox.Text };
            Program.NonQuery.InsertTable(columns, username);

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
    }
}
