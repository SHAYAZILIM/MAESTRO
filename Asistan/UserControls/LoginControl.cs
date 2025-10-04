using Asistan.LinqDAL;
using System;
using System.Windows.Forms;

public partial class LoginControl : UserControl
{
    public LoginControl()
    {
        InitializeComponent();
    }

    public event EventHandler OnLogon;

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (!Security.Logon(txUserName.Text, txPassword.Text))
        {
            lbMessage.Text = "Giriş Başarısız";
        }
        else
        {
            this.Visible = false;
            if (OnLogon != null)
                OnLogon(Security.User, new EventArgs());
            lbMessage.Text = "";
        }
        txPassword.Text = "";
        txUserName.Text = "";
    }

    private void LoginControl_Load(object sender, EventArgs e)
    {
        this.Visible = !Security.IsLogin;
        this.ParentForm.AcceptButton = this.btnLogin;
        Security.OnLogOut += new EventHandler(Security_OnLogOut);
    }

    private void Security_OnLogOut(object sender, EventArgs e)
    {
        this.Visible = !Security.IsLogin;
    }
}