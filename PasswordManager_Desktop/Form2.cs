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
    public partial class Form2 : Form
    {

        private int rowIndex = 0;
        public Form2()
        {
            InitializeComponent();
            CreateTable(userAccounts);
            LoadUserTable(userAccounts);
        }

        private void newKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AddKeyWindows = new AddKeyForm();
            AddKeyWindows.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }

        private void CreateTable(DataGridView userAccounts)
        {

            DataGridViewTextBoxColumn titleCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn userCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn passwordCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn urlCol = new DataGridViewTextBoxColumn();

            

            titleCol.HeaderText = "Title";
            userCol.HeaderText = "Username";
            passwordCol.HeaderText = "Password";
            urlCol.HeaderText = "URL";

            userAccounts.Columns.AddRange(titleCol, userCol, passwordCol, urlCol);
            userAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            userAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            userAccounts.ReadOnly = true;

            userAccounts.Location = new Point(122, 108);
            userAccounts.Size = new Size(545, 325);
            this.Controls.Add(userAccounts);

        }

        private void LoadUserTable(DataGridView userAccounts)
        {
            userAccounts.Rows.Clear();
            userAccounts.Refresh();

            string username = Program.GetUsername();
            DataTable data = Program.Query.FetchTable(username);

            for(int i = 0; i < data.Rows.Count; ++i)
            {
                DataRow row = data.Rows[i];
                userAccounts.Rows.Add(row[1].ToString(), row[2].ToString(), "***********", row[4].ToString());
            }
        }

        private void refreshTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserTable(userAccounts);
        }

        private void userAccounts_MouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                this.rowIndex = e.RowIndex;
                ContextMenu menu = new ContextMenu();
                menu.MenuItems.Add(new MenuItem("Add Key", new EventHandler(newKeyToolStripMenuItem_Click)));
                menu.MenuItems.Add(new MenuItem("Edit Key"));
                menu.MenuItems.Add(new MenuItem("Delete Key", new EventHandler(deleteKey)));
                menu.Show(userAccounts, new Point(e.X, e.Y));
            }
        }

        private void userAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string username = Program.GetUsername();
            Console.WriteLine("Test");

            DataTable userData = Program.Query.FetchTable(username);
            DataRow userRow = userData.Rows[e.RowIndex];

            
            if (e.ColumnIndex == 2)
            {
                DataTable AESData = Program.Query.GetDataFromTable(username, "username", "UserDatabase");
                DataRow AESRow = AESData.Rows[0];
                byte[] key = (byte[])AESRow[3];
                byte[] iv = (byte[])AESRow[4];
                byte[] cipherPassword = (byte[])userRow[3];
                string plainPassword = Program.AESAlgorithm.DecryptStringFromBytes(cipherPassword, key, iv);

                Clipboard.SetText(plainPassword);

            }
            MessageBox.Show("Copied password to clipboard", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteKey(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the key?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            DataGridViewRow row = userAccounts.Rows[this.rowIndex];
            string target = row.Cells[0].Value.ToString();

            string username = Program.GetUsername();

            Program.NonQuery.DeleteDataFromTable(target, "Title", username);

            LoadUserTable(userAccounts);
            
        }


    }
}
