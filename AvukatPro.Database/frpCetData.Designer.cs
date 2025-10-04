namespace AvukatPro.Database
{
    partial class frpCetData
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cetKodTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ısIdentityDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ısConditionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ısUpdateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDataGrid = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cetKodTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.cetKodTableBindingSource;
            this.listBox1.DisplayMember = "Name";
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(335, 545);
            this.listBox1.TabIndex = 0;
            this.listBox1.ValueMember = "Name";
            // 
            // cetKodTableBindingSource
            // 
            this.cetKodTableBindingSource.DataSource = typeof(AvukatPro.Database.CetKodTable);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ısIdentityDataGridViewCheckBoxColumn,
            this.ısConditionDataGridViewCheckBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.ısUpdateDataGridViewCheckBoxColumn,
            this.dataTypeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.columnsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(433, 546);
            this.dataGridView1.TabIndex = 1;
            // 
            // ısIdentityDataGridViewCheckBoxColumn
            // 
            this.ısIdentityDataGridViewCheckBoxColumn.DataPropertyName = "IsIdentity";
            this.ısIdentityDataGridViewCheckBoxColumn.HeaderText = "IsIdentity";
            this.ısIdentityDataGridViewCheckBoxColumn.Name = "ısIdentityDataGridViewCheckBoxColumn";
            this.ısIdentityDataGridViewCheckBoxColumn.Width = 55;
            // 
            // ısConditionDataGridViewCheckBoxColumn
            // 
            this.ısConditionDataGridViewCheckBoxColumn.DataPropertyName = "IsCondition";
            this.ısConditionDataGridViewCheckBoxColumn.HeaderText = "IsCondition";
            this.ısConditionDataGridViewCheckBoxColumn.Name = "ısConditionDataGridViewCheckBoxColumn";
            this.ısConditionDataGridViewCheckBoxColumn.Width = 65;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // ısUpdateDataGridViewCheckBoxColumn
            // 
            this.ısUpdateDataGridViewCheckBoxColumn.DataPropertyName = "IsUpdate";
            this.ısUpdateDataGridViewCheckBoxColumn.HeaderText = "IsUpdate";
            this.ısUpdateDataGridViewCheckBoxColumn.Name = "ısUpdateDataGridViewCheckBoxColumn";
            this.ısUpdateDataGridViewCheckBoxColumn.Width = 56;
            // 
            // dataTypeDataGridViewTextBoxColumn
            // 
            this.dataTypeDataGridViewTextBoxColumn.DataPropertyName = "DataType";
            this.dataTypeDataGridViewTextBoxColumn.HeaderText = "DataType";
            this.dataTypeDataGridViewTextBoxColumn.Name = "dataTypeDataGridViewTextBoxColumn";
            this.dataTypeDataGridViewTextBoxColumn.Width = 79;
            // 
            // columnsBindingSource
            // 
            this.columnsBindingSource.DataMember = "Columns";
            this.columnsBindingSource.DataSource = this.cetKodTableBindingSource;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load Xml";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(84, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Xml";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(0, 568);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(335, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 33);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(335, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 591);
            this.panel2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cetKodTableBindingSource, "Name", true));
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(433, 45);
            this.textBox1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listBox1);
            this.panel3.Controls.Add(this.btnDataGrid);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(335, 591);
            this.panel3.TabIndex = 7;
            // 
            // btnDataGrid
            // 
            this.btnDataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDataGrid.Location = new System.Drawing.Point(0, 545);
            this.btnDataGrid.Name = "btnDataGrid";
            this.btnDataGrid.Size = new System.Drawing.Size(335, 23);
            this.btnDataGrid.TabIndex = 4;
            this.btnDataGrid.Text = "ShowData";
            this.btnDataGrid.UseVisualStyleBackColor = true;
            this.btnDataGrid.Click += new System.EventHandler(this.btnDataGrid_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(246, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Select Table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frpCetData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 624);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frpCetData";
            this.Text = "frpCetData";
            ((System.ComponentModel.ISupportInitialize)(this.cetKodTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnsBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.BindingSource cetKodTableBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource columnsBindingSource;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ısIdentityDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ısConditionDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ısUpdateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDataGrid;
        private System.Windows.Forms.Button button2;
    }
}