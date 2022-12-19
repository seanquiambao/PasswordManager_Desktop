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
        public Form2()
        {
            InitializeComponent();
            CreateTable(dataGridView1);
            LoadUserTable(dataGridView1);
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

        private void CreateTable(DataGridView dataGridView1)
        {

            DataGridViewTextBoxColumn titleCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn userCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn passwordCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn urlCol = new DataGridViewTextBoxColumn();

            

            titleCol.HeaderText = "Title";
            userCol.HeaderText = "Username";
            passwordCol.HeaderText = "Password";
            urlCol.HeaderText = "URL";

            dataGridView1.Columns.AddRange(titleCol, userCol, passwordCol, urlCol);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;

            dataGridView1.Location = new Point(122, 108);
            dataGridView1.Size = new Size(545, 325);
            this.Controls.Add(dataGridView1);

        }

        private void LoadUserTable(DataGridView dataGridView1)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            string username = Program.GetUsername();
            DataTable data = Program.Query.FetchTable(username);

            for(int i = 0; i < data.Rows.Count; ++i)
            {
                DataRow row = data.Rows[i];
                dataGridView1.Rows.Add(row[1].ToString(), row[2].ToString(), "***********", row[4].ToString());
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void refreshTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserTable(dataGridView1);
        }
    }
}
