namespace AVPTransfer
{
    partial class GenerateColumnList
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
            this.btnGenerate = new DevExpress.XtraEditors.SimpleButton();
            this.txtCommand = new DevExpress.XtraEditors.MemoEdit();
            this.txtFieldList = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCommand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(423, 45);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Olu?tur";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(12, 10);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(405, 96);
            this.txtCommand.TabIndex = 1;
            // 
            // txtFieldList
            // 
            this.txtFieldList.Location = new System.Drawing.Point(12, 112);
            this.txtFieldList.Name = "txtFieldList";
            this.txtFieldList.Size = new System.Drawing.Size(405, 248);
            this.txtFieldList.TabIndex = 1;
            // 
            // GenerateColumnList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 365);
            this.Controls.Add(this.txtFieldList);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.btnGenerate);
            this.Name = "GenerateColumnList";
            this.Text = "GenerateColumnList";
            ((System.ComponentModel.ISupportInitialize)(this.txtCommand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldList.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnGenerate;
        private DevExpress.XtraEditors.MemoEdit txtCommand;
        private DevExpress.XtraEditors.MemoEdit txtFieldList;
    }
}