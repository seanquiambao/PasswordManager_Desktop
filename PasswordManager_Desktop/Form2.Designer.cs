namespace PasswordManager_Desktop
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testDBDataSet = new PasswordManager_Desktop.TestDBDataSet();
            this.testDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userAccounts = new System.Windows.Forms.DataGridView();
            this.exportCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newKeyToolStripMenuItem,
            this.refreshTableToolStripMenuItem,
            this.exportCSVToolStripMenuItem,
            this.importCSVToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newKeyToolStripMenuItem
            // 
            this.newKeyToolStripMenuItem.Name = "newKeyToolStripMenuItem";
            this.newKeyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newKeyToolStripMenuItem.Text = "New Key";
            this.newKeyToolStripMenuItem.Click += new System.EventHandler(this.newKeyToolStripMenuItem_Click);
            // 
            // refreshTableToolStripMenuItem
            // 
            this.refreshTableToolStripMenuItem.Name = "refreshTableToolStripMenuItem";
            this.refreshTableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshTableToolStripMenuItem.Text = "Refresh Table";
            this.refreshTableToolStripMenuItem.Click += new System.EventHandler(this.refreshTableToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // testDBDataSet
            // 
            this.testDBDataSet.DataSetName = "TestDBDataSet";
            this.testDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testDBDataSetBindingSource
            // 
            this.testDBDataSetBindingSource.DataSource = this.testDBDataSet;
            this.testDBDataSetBindingSource.Position = 0;
            // 
            // userAccounts
            // 
            this.userAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userAccounts.Location = new System.Drawing.Point(262, 188);
            this.userAccounts.Name = "userAccounts";
            this.userAccounts.Size = new System.Drawing.Size(240, 150);
            this.userAccounts.TabIndex = 1;
            this.userAccounts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userAccounts_CellDoubleClick);
            this.userAccounts.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userAccounts_MouseClick);
            // 
            // exportCSVToolStripMenuItem
            // 
            this.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            this.exportCSVToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportCSVToolStripMenuItem.Text = "Export CSV";
            this.exportCSVToolStripMenuItem.Click += new System.EventHandler(this.exportCSVToolStripMenuItem_Click);
            // 
            // importCSVToolStripMenuItem
            // 
            this.importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            this.importCSVToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importCSVToolStripMenuItem.Text = "Import CSV";
            this.importCSVToolStripMenuItem.Click += new System.EventHandler(this.importCSVToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.userAccounts);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "  ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private TestDBDataSet testDBDataSet;
        private System.Windows.Forms.BindingSource testDBDataSetBindingSource;
        private System.Windows.Forms.ToolStripMenuItem refreshTableToolStripMenuItem;
        private System.Windows.Forms.DataGridView userAccounts;
        private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCSVToolStripMenuItem;
    }
}