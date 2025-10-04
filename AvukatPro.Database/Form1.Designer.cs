namespace AvukatPro.Database
{
    partial class Form1
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
            this.txtScript = new System.Windows.Forms.RichTextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proceduresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foyDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cetDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtScript
            // 
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(5, 5);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(767, 33);
            this.txtScript.TabIndex = 0;
            this.txtScript.Text = "";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(699, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run Script";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(698, 45);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(588, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Show Results";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(716, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 45);
            this.button5.TabIndex = 5;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.updateDatabaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(777, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewsToolStripMenuItem,
            this.proceduresToolStripMenuItem,
            this.tablesToolStripMenuItem,
            this.cetDataToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Visible = false;
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            this.viewsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewsToolStripMenuItem.Text = "Views";
            this.viewsToolStripMenuItem.Click += new System.EventHandler(this.viewsToolStripMenuItem_Click);
            // 
            // proceduresToolStripMenuItem
            // 
            this.proceduresToolStripMenuItem.Name = "proceduresToolStripMenuItem";
            this.proceduresToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.proceduresToolStripMenuItem.Text = "Procedures";
            this.proceduresToolStripMenuItem.Click += new System.EventHandler(this.proceduresToolStripMenuItem_Click);
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tablesToolStripMenuItem.Text = "Tables";
            this.tablesToolStripMenuItem.Click += new System.EventHandler(this.tablesToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foyDeleteToolStripMenuItem});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Visible = false;
            // 
            // foyDeleteToolStripMenuItem
            // 
            this.foyDeleteToolStripMenuItem.Name = "foyDeleteToolStripMenuItem";
            this.foyDeleteToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.foyDeleteToolStripMenuItem.Text = "Foy Delete";
            this.foyDeleteToolStripMenuItem.Click += new System.EventHandler(this.foyDeleteToolStripMenuItem_Click);
            // 
            // updateDatabaseToolStripMenuItem
            // 
            this.updateDatabaseToolStripMenuItem.Name = "updateDatabaseToolStripMenuItem";
            this.updateDatabaseToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.updateDatabaseToolStripMenuItem.Text = "Update Database";
            this.updateDatabaseToolStripMenuItem.Click += new System.EventHandler(this.updateDatabaseToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtVt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 84);
            this.panel1.TabIndex = 7;
            // 
            // txtVt
            // 
            this.txtVt.Location = new System.Drawing.Point(91, 52);
            this.txtVt.Name = "txtVt";
            this.txtVt.Size = new System.Drawing.Size(296, 20);
            this.txtVt.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Veritabanı Adı";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtScript);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(777, 43);
            this.panel2.TabIndex = 8;
            this.panel2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRun);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 151);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(777, 32);
            this.panel3.TabIndex = 9;
            this.panel3.Visible = false;
            // 
            // cetDataToolStripMenuItem
            // 
            this.cetDataToolStripMenuItem.Name = "cetDataToolStripMenuItem";
            this.cetDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cetDataToolStripMenuItem.Text = "Cet Data";
            this.cetDataToolStripMenuItem.Click += new System.EventHandler(this.cetDataToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 183);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Script Runner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtScript;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proceduresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foyDeleteToolStripMenuItem;
        private System.Windows.Forms.TextBox txtVt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem updateDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cetDataToolStripMenuItem;
    }
}

