using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace AdimAdimDavaKaydi.Util
{
    public class ExtendedRepositoryItemLookUpEdit : RepositoryItemLookUpEdit
    {
        public ExtendedRepositoryItemLookUpEdit()
        {
            this.KeyDown += ExtendedRepositoryItemLookUpEdit_KeyDown;
            //this.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete));
            //this.EditValueChanged += SilgiButtonClick;
            this.Modified += SilgiButtonClick;
        }

        private DevExpress.XtraEditors.Controls.EditorButton btn =
            new DevExpress.XtraEditors.Controls.EditorButton("Silgi",
                                                             DevExpress.XtraEditors.Controls.ButtonPredefines.Delete);

        private void SilgiButtonClick(object sender, EventArgs e)
        {
            if (((LookUpEdit)sender).EditValue != null)
            {
                if (!Buttons.Contains(btn))
                {
                    Buttons.Add(btn);
                    ButtonClick += SilgiClickEvent;
                }
            }
            else if (((LookUpEdit)sender).EditValue == null)
            {
                if (Buttons.Contains(btn))
                {
                    Buttons.RemoveAt(Buttons.IndexOf(btn));
                    ButtonClick -= SilgiClickEvent;
                }
            }
        }

        private void SilgiClickEvent(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null)
                if (e.Button.Tag.ToString() == "Silgi")
                {
                    if (sender is LookUpEdit)
                    {
                        (sender as LookUpEdit).EditValue = null;
                        // SilgiButtonClick(this, new EventArgs());
                    }
                }
        }

        private void ExtendedRepositoryItemLookUpEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit edit = sender as DevExpress.XtraEditors.LookUpEdit;
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                edit.CancelPopup();
                edit.EditValue = null;
            }
        }
    }
}