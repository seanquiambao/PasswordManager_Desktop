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
        public DataGridView userAccounts;
        public Form2()
        {
            InitializeComponent();
            userAccounts = new DataGridView();
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

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {

            

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
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void refreshTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserTable(userAccounts);
        }
    }
}
