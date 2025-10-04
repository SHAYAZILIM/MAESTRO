
partial class LoginControl
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
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.txUserName = new System.Windows.Forms.TextBox();
        this.txPassword = new System.Windows.Forms.TextBox();
        this.btnLogin = new System.Windows.Forms.Button();
        this.lbMessage = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        this.label1.Location = new System.Drawing.Point(65, 78);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(77, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Kullanıcı Adı";
        // 
        // label2
        // 
        this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        this.label2.Location = new System.Drawing.Point(65, 104);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(33, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "Şifre";
        // 
        // txUserName
        // 
        this.txUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.txUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txUserName.Location = new System.Drawing.Point(148, 76);
        this.txUserName.Name = "txUserName";
        this.txUserName.Size = new System.Drawing.Size(100, 20);
        this.txUserName.TabIndex = 2;
        // 
        // txPassword
        // 
        this.txPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.txPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txPassword.Location = new System.Drawing.Point(148, 102);
        this.txPassword.Name = "txPassword";
        this.txPassword.PasswordChar = '*';
        this.txPassword.Size = new System.Drawing.Size(100, 20);
        this.txPassword.TabIndex = 3;
        this.txPassword.UseSystemPasswordChar = true;
        // 
        // btnLogin
        // 
        this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.btnLogin.BackColor = System.Drawing.Color.LightGray;
        this.btnLogin.Location = new System.Drawing.Point(204, 128);
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Size = new System.Drawing.Size(44, 21);
        this.btnLogin.TabIndex = 4;
        this.btnLogin.Text = "Giriş";
        this.btnLogin.UseVisualStyleBackColor = false;
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        // 
        // lbMessage
        // 
        this.lbMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.lbMessage.ForeColor = System.Drawing.Color.Red;
        this.lbMessage.Location = new System.Drawing.Point(47, 152);
        this.lbMessage.Name = "lbMessage";
        this.lbMessage.Size = new System.Drawing.Size(201, 32);
        this.lbMessage.TabIndex = 5;
        this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // LoginControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.Controls.Add(this.lbMessage);
        this.Controls.Add(this.btnLogin);
        this.Controls.Add(this.txPassword);
        this.Controls.Add(this.txUserName);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "LoginControl";
        this.Size = new System.Drawing.Size(268, 197);
        this.Load += new System.EventHandler(this.LoginControl_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txUserName;
    private System.Windows.Forms.TextBox txPassword;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Label lbMessage;
}

