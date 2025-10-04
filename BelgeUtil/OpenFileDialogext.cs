//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows.Forms;

//namespace  BelgeUtil
//{
//    class OpenFileDialogext : FileDialog,IFormattable
//    {
//        public OpenFileDialogext()
//        {
//            this.Extensions.Adding += new OnProcess(Extensions_Adding);
//            this.Extensions.Removing += new OnProcess(Extensions_Removing);
//        }

// void Extensions_Removing(object sender, Extensions item) { this.Filter=
// this.Filter.Replace(createFilterText(item),""); }

// string createFilterText(Extensions item) { return item.Desc +"("+item.Ext +")|" + item.Ext+"|"; }

// void Extensions_Adding(object sender, Extensions item) { this.Filter += createFilterText(item); }

// private ExtensionCollection _extensions; public ExtensionCollection Extensions { get { return
// _extensions; } set { _extensions = value; } }

// }

// public delegate void OnProcess(object sender, Extensions item);

// public class ExtensionCollection { public event OnProcess Removing; public event OnProcess
// Adding;

// private List<Extensions> _extensions; public List<Extensions> Extensions { get { return
// _extensions; } set { _extensions = value; } }

// public Extensions this[int index] { get { return Extensions[index]; } set { this.Adding(this,
// value) ; Extensions[index] = value; } }

// public void Add(Extensions ext) { this.Adding(this, ext); this.Extensions.Add(ext); }

// public void Remove(Extensions ext) { this.Removing(this, ext); this.Extensions.Remove(ext);

// }

// public int Count { get { return this.Extensions.Count; } }

// }

// public class Extensions { private string _desc; public string Desc { get { return _desc; } set {
// _desc = value; } }

// private string _ext; public string Ext { get { return _ext; } set { _ext = value; } } }
//}