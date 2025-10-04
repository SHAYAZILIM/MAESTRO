namespace  AdimAdimDavaKaydi.Belge.UserControls
{
    partial class ucBelgeOnizleme
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.c_Video = new AxWMPLib.AxWindowsMediaPlayer();
            this.c_PicBox = new AdimAdimDavaKaydi.Util.XtendPicBox();
            this.c_WebCnt = new System.Windows.Forms.WebBrowser();
            this.c_TextCnt = new TXTextControl.TextControl();
            this.c_tbGrids = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.c_Video)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_tbGrids)).BeginInit();
            this.SuspendLayout();
            // 
            // c_Video
            // 
            this.c_Video.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_Video.Enabled = true;
            this.c_Video.Location = new System.Drawing.Point(0, 0);
            this.c_Video.Name = "c_Video";
            this.c_Video.Size = new System.Drawing.Size(764, 481);
            this.c_Video.TabIndex = 0;
            // 
            // c_PicBox
            // 
            this.c_PicBox.AutoScroll = true;
            this.c_PicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_PicBox.Location = new System.Drawing.Point(0, 0);
            this.c_PicBox.MinimumSize = new System.Drawing.Size(20, 20);
            this.c_PicBox.Name = "c_PicBox";
            this.c_PicBox.PictureFile = "";
            this.c_PicBox.Size = new System.Drawing.Size(764, 503);
            this.c_PicBox.TabIndex = 7;
            // 
            // c_WebCnt
            // 
            this.c_WebCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_WebCnt.Location = new System.Drawing.Point(0, 0);
            this.c_WebCnt.MinimumSize = new System.Drawing.Size(20, 20);
            this.c_WebCnt.Name = "c_WebCnt";
            this.c_WebCnt.Size = new System.Drawing.Size(764, 503);
            this.c_WebCnt.TabIndex = 1;
            // 
            // c_TextCnt
            // 
            this.c_TextCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_TextCnt.Font = new System.Drawing.Font("Arial", 10F);
            this.c_TextCnt.Location = new System.Drawing.Point(0, 0);
            this.c_TextCnt.Name = "c_TextCnt";
            this.c_TextCnt.Size = new System.Drawing.Size(764, 503);
            this.c_TextCnt.TabIndex = 3;
            this.c_TextCnt.Text = "textControl1";
            // 
            // c_tbGrids
            // 
            this.c_tbGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_tbGrids.Location = new System.Drawing.Point(0, 0);
            this.c_tbGrids.Name = "c_tbGrids";
            this.c_tbGrids.Size = new System.Drawing.Size(764, 503);
            this.c_tbGrids.TabIndex = 6;
            // 
            // ucBelgeOnizleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.c_tbGrids);
            this.Controls.Add(this.c_WebCnt);
            this.Controls.Add(this.c_PicBox);
            this.Controls.Add(this.c_TextCnt);
            this.Name = "ucBelgeOnizleme";
            this.Size = new System.Drawing.Size(764, 503);
            ((System.ComponentModel.ISupportInitialize)(this.c_Video)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_tbGrids)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer c_Video;
        //private CrystalDecisions.Windows.Forms.CrystalReportViewer c_CrView;
        private AdimAdimDavaKaydi.Util.XtendPicBox c_PicBox;
        private TXTextControl.TextControl c_TextCnt;
        private DevExpress.XtraTab.XtraTabControl c_tbGrids;
        private System.Windows.Forms.WebBrowser c_WebCnt;
    }
}
