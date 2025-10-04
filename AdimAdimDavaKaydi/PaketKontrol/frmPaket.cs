using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.VisualBasic;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public partial class frmPaket : Form
    {
        private Form ActiveForm;
        private List<bool> checkBoxState = new List<bool>();
        private RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
        private List<Form> Forms = new List<Form>();

        public frmPaket()
        {
            InitializeComponent();
        }

        public frmPaket(Form form)
        {
            InitializeComponent();
            Forms.Add(form);
        }

        public frmPaket(List<Form> forms)
        {
            InitializeComponent();
            Forms.AddRange(forms);
        }

        public void DrawCheckBox(Graphics g, Rectangle r, Boolean Checked)
        {
            CheckEditViewInfo info;
            CheckEditPainter painter;
            ControlGraphicsInfoArgs args;
            info = (CheckEditViewInfo)edit.CreateViewInfo();
            painter = (CheckEditPainter)edit.CreatePainter();
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new ControlGraphicsInfoArgs(info, new GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }

        public void SetBorder(Point p, Size s)
        {
            Control p1 = ActiveForm.Controls["Border1"];
            Control p2 = ActiveForm.Controls["Border2"];
            Control p3 = ActiveForm.Controls["Border3"];
            Control p4 = ActiveForm.Controls["Border4"];

            p1.BringToFront();
            p2.BringToFront();
            p3.BringToFront();
            p4.BringToFront();

            p1.Height = s.Height;
            p1.Location = p;

            p3.Height = s.Height;
            p3.Location = new Point(p.X + s.Width - 2, p.Y);

            p2.Width = s.Width;
            p2.Location = p;

            p4.Width = s.Width;
            p4.Location = new Point(p.X, p.Y + s.Height - 2);
        }

        private void btnCopyPacket_Click(object sender, EventArgs e)
        {
            if (paketBindingSource.Current != null)
            {
                Paket paket = (Paket)paketBindingSource.Current;
                string newpacketname = Interaction.InputBox("Yeni Paket Adı", "Yeni Paket", paket.PaketAdi);
                if (PaketHelper.Paketler.Any(q => q.PaketAdi.ToLower() == newpacketname.ToLower()))
                {
                    MessageBox.Show("Bu isimde apket zaten bulunmakta lütfen başka isim deneyiniz.");
                    return;
                }
                this.Enabled = false;
                Paket newpaket = new Paket() { PaketAdi = newpacketname, Aciklama = paket.Aciklama };
                newpaket.PaketId = newpaket.GetHashCode();
                paketBindingSource.Add(newpaket);
                PaketHelper.Paketler.Save();
                PaketHelper.IsEdit = false;
                foreach (var form in PaketFormHelper.Forms)
                {
                    foreach (var control in form.Controls)
                    {
                        foreach (var property in control.Properties.Where(q => q.PaketId == paket.PaketId).ToList())
                        {
                            var newproperty = new PaketControlProperty();
                            newproperty.Aktif = property.Aktif;
                            newproperty.Gorunur = property.Gorunur;
                            newproperty.PaketId = newpaket.PaketId;
                            newproperty.Sepet = property.Sepet;
                            newproperty.Yetkilendirme = property.Yetkilendirme;
                            control.Properties.Add(newproperty);

                            foreach (var gproperty in property.GroupProperties)
                            {
                                var newgproperty = new PaketUserGroupProperty();
                                newgproperty.Aktif = gproperty.Aktif;
                                newgproperty.Gorunur = gproperty.Gorunur;
                                newgproperty.Sepet = gproperty.Sepet;
                                newgproperty.GroupId = gproperty.GroupId;
                                newgproperty.Yetkilendirme = gproperty.Yetkilendirme;
                                newproperty.GroupProperties.Add(newgproperty);
                            }
                        }
                    }
                }
                PaketHelper.IsEdit = true;
                PaketFormHelper.Forms.Save();
                this.Enabled = true;
            }
        }

        private void btnDeletePacket_Click(object sender, EventArgs e)
        {
            if (paketBindingSource.Current != null)
            {
                Paket paket = (Paket)paketBindingSource.Current;
                if (MessageBox.Show(string.Format("'{0}' Paketini Silmek İstediğinize Eminmisiniz ?", paket.PaketAdi), "Dikkat", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Enabled = false;
                    PaketHelper.Paketler.Remove(paket);
                    PaketHelper.Paketler.Save();
                    paketBindingSource.DataSource = PaketHelper.Paketler;
                    this.Enabled = true;
                }
            }
        }

        private void btnNewPacket_Click(object sender, EventArgs e)
        {
            if (paketBindingSource.DataSource != null)
            {
                string newpacketname = Interaction.InputBox("Yeni Paket Adı", "Yeni Paket", "");
                if (PaketHelper.Paketler.Any(q => q.PaketAdi.ToLower() == newpacketname.ToLower()))
                {
                    MessageBox.Show("Bu isimde apket zaten bulunmakta lütfen başka isim deneyiniz.");
                    return;
                }
                this.Enabled = false;
                Paket newpaket = new Paket() { PaketAdi = newpacketname };
                newpaket.PaketId = newpaket.GetHashCode();
                paketBindingSource.Add(newpaket);
                PaketHelper.Paketler.Save();
                this.Enabled = true;
            }
        }

        private void btnSaveForm_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (paketFormBindingSource.DataSource != null)
            {
                PaketFormHelper.Forms.Save();
            }
            this.Enabled = true;
        }

        private void btnSavePacket_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (paketBindingSource.DataSource != null)
            {
                PaketHelper.Paketler.Save();
            }
            this.Enabled = true;
        }

        private void controlsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (controlsBindingSource.Current != null && controlsBindingSource.Current is PaketControl)
            {
                var fcontrol = controlsBindingSource.Current as PaketControl;
                Point point = Point.Empty;
                Size size = Size.Empty;
                try
                {
                    if (fcontrol.Location != null)
                        point = fcontrol.Location;

                    if (fcontrol.Size != null)
                        size = fcontrol.Size;
                }
                catch { }

                SetBorder(point, size);
            }
        }

        private void formControlBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Controls.RemoveByKey("Border1");
                ActiveForm.Controls.RemoveByKey("Border2");
                ActiveForm.Controls.RemoveByKey("Border3");
                ActiveForm.Controls.RemoveByKey("Border4");
            }

            ActiveForm = (Form)((PaketForm)paketFormBindingSource.Current).Form;
            ActiveForm.Activate();

            if (ActiveForm != null)
            {
                Control p1 = ActiveForm.Controls["Border1"];
                Control p2 = ActiveForm.Controls["Border2"];
                Control p3 = ActiveForm.Controls["Border3"];
                Control p4 = ActiveForm.Controls["Border4"];

                if (p1 == null)
                {
                    p1 = new Panel();
                    p1.Name = "Border1";
                    ActiveForm.Controls.Add(p1);
                }
                if (p2 == null)
                {
                    p2 = new Panel();
                    p2.Name = "Border2";
                    ActiveForm.Controls.Add(p2);
                }
                if (p3 == null)
                {
                    p3 = new Panel();
                    p3.Name = "Border3";
                    ActiveForm.Controls.Add(p3);
                }
                if (p4 == null)
                {
                    p4 = new Panel();
                    p4.Name = "Border4";
                    ActiveForm.Controls.Add(p4);
                }

                p1.BackColor = Color.Red;
                p2.BackColor = Color.Red;
                p3.BackColor = Color.Red;
                p4.BackColor = Color.Red;
                p1.Width = 2;
                p3.Width = 2;
                p2.Height = 2;
                p4.Height = 2;

                p1.BringToFront();
                p2.BringToFront();
                p3.BringToFront();
                p4.BringToFront();
            }
        }

        private void frmPaket_FormClosing(object sender, FormClosingEventArgs e)
        {
            PaketHelper.IsEdit = true;

            foreach (var item in Forms)
            {
                item.Controls.RemoveByKey("Border1");
                item.Controls.RemoveByKey("Border2");
                item.Controls.RemoveByKey("Border3");
                item.Controls.RemoveByKey("Border4");
            }
        }

        private void frmPaket_Load(object sender, EventArgs e)
        {
            PaketHelper.IsEdit = true;

            //PaketHelper.Paketler.Clear();
            //foreach (var item in PaketHelper.DataContext.CsKodPaket.ToList())
            //{
            //    var packet = new Paket() { PaketAdi = item.PaketAdi };
            //    packet.PaketId = packet.GetHashCode();
            //    PaketHelper.Paketler.Add(packet);
            //}

            Text += " - Aktif Paket : " + PaketHelper.AktifPaket.PaketAdi;
            Text += " - Aktif Grup : " + PaketHelper.AktifGroup.Adi;
            paketBindingSource.DataSource = PaketHelper.Paketler;

            List<PaketForm> paketForms = new List<PaketForm>();
            foreach (var item in Forms)
            {
                var d = item.GetPaketFormForPacket();
                paketForms.Add(d);

                if (item.IsMdiContainer)
                    ActiveForm = item.ActiveMdiChild;
            }

            paketFormBindingSource.DataSource = paketForms;
        }

        private void gridView2_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.VisibleIndex > 0)
            {
                if (checkBoxState.Count <= (e.Column.VisibleIndex - 1))
                    checkBoxState.Add(true);

                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, checkBoxState[e.Column.VisibleIndex - 1]);
                e.Handled = true;
            }
        }

        private void gridView2_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            if (propertiesBindingSource.Current != null)
            {
                PaketControlProperty pcontrol = propertiesBindingSource.Current as PaketControlProperty;
                if (pcontrol != null)
                {
                    foreach (var pgroup in pcontrol.GroupProperties)
                    {
                        if (pcontrol.Aktif.HasValue && !pgroup.Aktif.HasValue)
                            pgroup.Aktif = pcontrol.Aktif;
                        if (pcontrol.Gorunur.HasValue && !pgroup.Gorunur.HasValue)
                            pgroup.Gorunur = pcontrol.Gorunur;
                        if (pcontrol.Sepet.HasValue && !pgroup.Sepet.HasValue)
                            pgroup.Sepet = pcontrol.Sepet;
                        if (pcontrol.Yetkilendirme.HasValue && !pgroup.Yetkilendirme.HasValue)
                            pgroup.Yetkilendirme = pcontrol.Yetkilendirme;
                    }
                }
            }
        }

        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {
            var gridView = sender as GridView;
            GridHitInfo info;
            var pt = gridView.GridControl.PointToClient(Control.MousePosition);
            info = gridView.CalcHitInfo(pt);
            if (info.InColumn && info.Column.VisibleIndex > 0)
            {
                checkBoxState[info.Column.VisibleIndex - 1] = !checkBoxState[info.Column.VisibleIndex - 1];
                gridView.InvalidateColumnHeader(info.Column);

                for (int i = 0; i < gridView.RowCount; i++)
                {
                    gridView.SetRowCellValue(gridView.GetRowHandle(i), info.Column, checkBoxState[info.Column.VisibleIndex - 1]);
                }
            }
        }

        private void gridView3_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
        }
    }
}