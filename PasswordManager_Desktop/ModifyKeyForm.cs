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
    public partial class ModifyKeyForm : Form
    {
        private DataTable data;
        public ModifyKeyForm()
        {
            InitializeComponent();
        }

        private void ModifyKeyForm_Load(object sender, EventArgs e)
        {
            DataRow row = data.Rows[0];
            titleTextBox.Text = row[1].ToString();
            usernameTextBox.Text = row[2].ToString();

            string plainTextPassword = getPlainTextPassword();
            passwordTextBox.Text = plainTextPassword;

            urlTextBox.Text = row[4].ToString();
        }

        public void SetDataTable(DataTable dt)
        {
            this.data = dt;
        }

        private string getPlainTextPassword()
        {
            string username = Program.GetUsername();
            DataTable AESData = Program.Query.GetDataFromTable(username, "username", "UserDatabase");
            DataRow AESRow = AESData.Rows[0];
            DataRow userRow = data.Rows[0];
            byte[] key = (byte[])AESRow[3];
            byte[] iv = (byte[])AESRow[4];
            byte[] cipherPassword = (byte[])userRow[3];
            string plainPassword = Program.AESAlgorithm.DecryptStringFromBytes(cipherPassword, key, iv);

            return plainPassword;
        }

        private byte[] getCipherPassword(string plaintext)
        {
            string username = Program.GetUsername();
            DataTable AESData = Program.Query.GetDataFromTable(username, "username", "UserDatabase");
            DataRow AESRow = AESData.Rows[0];
            DataRow userRow = data.Rows[0];
            byte[] key = (byte[])AESRow[3];
            byte[] iv = (byte[])AESRow[4];
            return Program.AESAlgorithm.EncryptStringToBytes(plaintext, key, iv);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = (passwordTextBox.UseSystemPasswordChar) ? false : true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEmptyPrompt())
            {
                MessageBox.Show("Missing Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to modify these changes?", "Modify Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;


            DataRow row = data.Rows[0];
            string formerTitle = row[1].ToString();
            string[] modifiedValues = { titleTextBox.Text, usernameTextBox.Text, urlTextBox.Text };
            byte[] modifiedPassword = getCipherPassword(passwordTextBox.Text);
            string username = Program.GetUsername();

            Program.NonQuery.UpdateUserAccountRow(formerTitle, modifiedValues, modifiedPassword, username);
        }

        private bool isEmptyPrompt()
        {
            return (titleTextBox.Text == String.Empty || usernameTextBox.Text == String.Empty || passwordTextBox.Text == String.Empty || urlTextBox.Text == String.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit? You may have unsaved changes.", "Modify Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            this.Close();
        }
    }
}
