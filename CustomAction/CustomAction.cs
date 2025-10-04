//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Configuration.Install;
//using System.Linq;


//namespace CustomAction
//{
//    [RunInstaller(true)]
//    public partial class CustomAction : System.Configuration.Install.Installer
//    {
//        public CustomAction()
//        {
//            InitializeComponent();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.ComponentModel;
using SetupFormalari;
using AvukatProLib;
using System.IO;


namespace CustomAction
{
    [RunInstaller(true)]
    public partial class CustomAction : Installer
    {
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            bool DevamMi = false;

            Form1 frmDialog = new Form1(this.Context, DevamMi);
            frmDialog.ShowDialog();
            
            if (DevamMi)
                base.Install(stateSaver);
            //else
            //    base.Uninstall(stateSaver);
        }

        //public override void Uninstall(System.Collections.IDictionary savedState)
        //{

        //    base.Uninstall(savedState);
        //}
    }

}
