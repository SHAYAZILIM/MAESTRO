using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace AdimAdimDavaKaydi
{
    [DesignTimeVisible(true)]
    [System.Drawing.ToolboxBitmap(typeof(LookUpEdit))]
    public class LookUpExtender : Control
    {
        private List<LookUpEdit> _LookUpEditCollection;
        private List<RepositoryItemLookUpEdit> _RepoLookUpEditCollection;
        public event ButtonPressedEventHandler ButtonClick;
        public event ProcessNewValueEventHandler ProcessNewValue;
        public event LookUpExtenderEventHandler OnClickOrProcessNewValue;
        private List<string> _myList = new List<string>();

        public LookUpEdit[] LookUpEditCollection
        {
            get { return _LookUpEditCollection.ToArray(); }
            set
            {
                _LookUpEditCollection.Clear();
                _LookUpEditCollection.AddRange(value);
            }
        }

        public RepositoryItemLookUpEdit[] RepoLookUpEditCollection
        {
            get { return _RepoLookUpEditCollection.ToArray(); }
            set
            {
                _RepoLookUpEditCollection.Clear();
                _RepoLookUpEditCollection.AddRange(value);
            }
        }

        public LookUpEdit AddLookUp
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    _LookUpEditCollection.Add(value);
                    ProcessLookUp(value);
                }
            }
        }

        public LookUpEdit RemoveLookUp
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    _LookUpEditCollection.Remove(value);
                    ProcessDeleteLookUp(value);
                }
            }
        }

        public RepositoryItemLookUpEdit AddRepoLookUp
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    _RepoLookUpEditCollection.Add(value);
                    ProcessRepoLookUp(value);
                }
            }
        }

        public RepositoryItemLookUpEdit RemoveRepoLookUp
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    _RepoLookUpEditCollection.Remove(value);
                    ProcessDeleteRepoLookUp(value);
                }
            }
        }

        private void ProcessDeleteRepoLookUp(RepositoryItemLookUpEdit value)
        {
            value.AllowNullInput = DefaultBoolean.Default;
            value.TextEditStyle = TextEditStyles.DisableTextEditor;
            if (value.Buttons.Count == 2)
            {
                value.Buttons.RemoveAt(1);
            }
        }

        private void ProcessDeleteLookUp(LookUpEdit value)
        {
            value.Properties.AllowNullInput = DefaultBoolean.Default;
            value.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            if (value.Properties.Buttons.Count == 2)
            {
                value.Properties.Buttons.RemoveAt(1);
            }
        }

        private void ProcessRepoLookUp(RepositoryItemLookUpEdit value)
        {
            value.AllowNullInput = DefaultBoolean.True;
            value.TextEditStyle = TextEditStyles.Standard;
            EditorButton btn = new EditorButton(ButtonPredefines.Plus, "Ekle");
            btn.Tag = "mEkle";
            if (value.Buttons.Count == 1)
            {
                value.Buttons.Add(btn);
            }
        }

        protected override void InitLayout()
        {
            ParentiBosOlaniGetir(this).ParentChanged += control_ParentChanged;
        }

        private Control ParentiBosOlaniGetir(Control c)
        {
            if (c.Parent != null)
            {
                return ParentiBosOlaniGetir(c.Parent);
            }
            return c;
        }

        private bool calistimi;

        private void control_ParentChanged(object sender, EventArgs e)
        {
            Control con = (Control)sender;
            if ((_LookUpEditCollection.Count > 0 || _RepoLookUpEditCollection.Count > 0) && !calistimi)
            {
                frm_Load(null, null);
            }
            if (con.Parent is Form)
            {
                Form frm = (Form)con.Parent;
                frm.Load += frm_Load;
            }
            else
            {
                if (con.Parent != null)
                    con.Parent.ParentChanged += control_ParentChanged;
            }
        }

        private void frm_Load(object sender, EventArgs e)
        {
            foreach (LookUpEdit edit in _LookUpEditCollection)
            {
                if (edit != null)
                {
                    edit.Properties.ButtonClick += Properties_ButtonClick;
                    edit.Properties.ProcessNewValue += Properties_ProcessNewValue;
                }
            }
            foreach (RepositoryItemLookUpEdit rdt in _RepoLookUpEditCollection)
            {
                if (rdt != null)
                {
                    rdt.ButtonClick += Properties_ButtonClick;
                    rdt.ProcessNewValue += Properties_ProcessNewValue;
                }
            }
            calistimi = true;
        }

        private void ProcessLookUp(LookUpEdit value)
        {
            value.Properties.AllowNullInput = DefaultBoolean.True;
            value.Properties.TextEditStyle = TextEditStyles.Standard;
            EditorButton btn = new EditorButton(ButtonPredefines.Plus, "Ekle");
            btn.Tag = "mEkle";
            if (value.Properties.Buttons.Count == 1)
            {
                value.Properties.Buttons.Add(btn);
            }
        }

        private void Properties_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            LookUpEdit lkp = (LookUpEdit)sender;
            if (e.DisplayValue != null && string.IsNullOrEmpty(e.DisplayValue.ToString()))
                return;
            if (_myList.Contains(e.DisplayValue.ToString()))
                return;
            DialogResult dr = DialogResult.Cancel;
            if (lkp.Properties.Columns.Count > 0)
            {
                string alanIsmi = string.Empty;
                if (lkp.Properties.Columns[0].Caption == "ID" && lkp.Properties.Columns.Count > 1)
                    alanIsmi = lkp.Properties.Columns[1].Caption;
                else
                    alanIsmi = lkp.Properties.Columns[0].Caption;
                dr =
                    MessageBox.Show(
                        alanIsmi +
                        " alanýnda böyle bir kayýt bulunamadý yeni eklemek istermisiniz ?", "Kayýt Bulunamadý",
                        MessageBoxButtons.YesNo);
            }
            else
                dr =
                    MessageBox.Show("Böyle bir kayýt bulunamadý yeni eklemek istermisiniz ?", "Kayýt Bulunamadý",
                                    MessageBoxButtons.YesNo);
            _myList.Clear();
            _myList.Add(e.DisplayValue.ToString());
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                //MessageBox.Show("Yeni kayýt eklemek istediniz");
                if (this.ProcessNewValue != null)
                    ProcessNewValue(sender, e);
                if (this.OnClickOrProcessNewValue != null)
                {
                    OnClickOrProcessNewValue(this,
                                             new LookUpExtenderEventArgs(lkp, null, true, e.DisplayValue.ToString()));
                    e.Handled = true;
                }
                //string s = e.DisplayValue.ToString();
                //e.DisplayValue = "";
            }

            //lkp.EditValue = null;
            //e.Handled = true;
        }

        private void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "mEkle")
            {
                if (this.ButtonClick != null)
                    ButtonClick(sender, e);
                if (this.OnClickOrProcessNewValue != null)
                    OnClickOrProcessNewValue(this,
                                             new LookUpExtenderEventArgs((LookUpEdit)sender, null, false, string.Empty));
            }
        }

        public LookUpExtender()
        {
            this._LookUpEditCollection = new List<LookUpEdit>();
            this._RepoLookUpEditCollection = new List<RepositoryItemLookUpEdit>();
            this.Visible = false;
        }
    }

    public delegate void LookUpExtenderEventHandler(object sender, LookUpExtenderEventArgs e);

    public class LookUpExtenderEventArgs : EventArgs
    {
        public LookUpEdit SenderLookUp { get; set; }

        public bool IsTypedValue { get; set; }

        public string TypedValue { get; set; }

        public RepositoryItemLookUpEdit SenderRepoLookUp { get; set; }

        public LookUpExtenderEventArgs()
        {
        }

        public LookUpExtenderEventArgs(LookUpEdit lue, RepositoryItemLookUpEdit rlk, bool istypedvalue,
                                       string typedvalue)
        {
            SenderLookUp = lue;
            SenderRepoLookUp = rlk;
            IsTypedValue = istypedvalue;
            TypedValue = typedvalue;
        }
    }
}