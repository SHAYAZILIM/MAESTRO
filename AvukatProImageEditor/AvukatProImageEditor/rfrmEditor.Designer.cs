namespace  AvukatProImageEditor
{
    partial class rfrmEditor
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
            this.textBox1 = new System.Windows.Forms.TextBox();

            this.button1 = new System.Windows.Forms.Button();

            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.mover1 = new AvukatProImageEditor.Mover();
            this.resizer1 = new AvukatProImageEditor.Resizer();

            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(12, 35);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(403, 22);
            this.textBox1.TabIndex = 1;
            // 
            // avP_NHA_NGDataSet1
            // 
          
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(555, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // alphaBlendTextBox1
            // 
    
            // 
            // panelControl1
            // 
       
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.textBox2);
   
            this.panelControl1.Location = new System.Drawing.Point(12, 77);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(851, 574);
            this.panelControl1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));

            this.label1.Location = new System.Drawing.Point(421, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(131, 289);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "6546546";
            // 
            // mover1
            // 
            this.mover1.MoveAll = true;
         
            this.mover1.Parent = this.panelControl1;
            // 
            // resizer1
            // 
            this.resizer1.MyControl = null;
            // 
            // rfrmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 663);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.textBox1);
            this.Name = "rfrmEditor";
            this.Text = "rfrmEditor";
            this.Load += new System.EventHandler(this.rfrmEditor_Load);
    
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button button1;
        private Mover mover1;
        private Resizer resizer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;

    }
}