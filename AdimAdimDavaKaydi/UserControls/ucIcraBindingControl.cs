using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucIcraBindingControl : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucIcraBindingControl()
        {
            InitializeComponent();
            this.Load += ucIcraBindingControl_Load;
            this.cmbKriter.SelectedValueChanged += cmbKriter_SelectedValueChanged;
            this.btnTemizle.Click += btnTemizle_Click;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txt.Text = "";
            txtKod.Text = "";
            txtNo.Text = "";
            //lue.Properties.DataSource = null;
            lue.EditValue = null;

            dataNavigator1.DataSource = null;
            dataNavigator1.DataSource = masterFoy;
            btnAra.Enabled = true;
        }

        private TextEdit txt = new TextEdit();
        private LookUpEdit lue = new LookUpEdit();
        private List<Control> temp = new List<Control>();
        private int selIndex;

        private void cmbKriter_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxEdit cb = sender as ComboBoxEdit;

            if (cb.SelectedItem != null)
            {
                selIndex = cb.SelectedIndex;
                if (selIndex > 2)
                    selIndex++;

                ChangeFindControl((AramaKriterleri)selIndex);
            }
        }

        private void ucIcraBindingControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                LoadItem();

                temp.Add(panelMaster.Controls[0]);

                cmbKriter.SelectedIndex = 0;

                this.dataNavigator1.DataSource = MyDataSource;
            }
        }

        public enum Modul
        {
            Banka = 0,
            Sigorta = 1,
        }

        public enum AramaKriterleri
        {
            Dosya_No = 0,
            Hasar_No = 1,
            Kredi_Kartý_No = 2,
            Poliçe_No = 3,
            Esas_No = 4,
            Özel_Kod = 5,
            Dosya_Taraflarý = 6,
        }

        public Modul Mod { get; set; }

        private void AddTxtControl()
        {
            foreach (Control c in panelMaster.Controls)
            {
                if (c == panelChild)
                {
                    if (!temp.Contains(c))
                        temp.Add(c);
                }

                panelMaster.Controls.Clear();
                panelMaster.Controls.Add(txt);
                txt.Dock = DockStyle.Fill;
            }
        }

        private void AddLueControl()
        {
            foreach (Control c in panelMaster.Controls)
            {
                if (c == panelChild)
                {
                    if (!temp.Contains(c))
                        temp.Add(c);
                }

                panelMaster.Controls.Clear();
                panelMaster.Controls.Add(lue);
                lue.Dock = DockStyle.Fill;
            }
        }

        private void AddTempControl()
        {
            panelMaster.Controls.Clear();
            panelMaster.Controls.Add(temp[0]);
        }

        private void ChangeFindControl(AramaKriterleri k)
        {
            switch (k)
            {
                case AramaKriterleri.Dosya_No:
                    AddTempControl();

                    break;

                case AramaKriterleri.Hasar_No:
                    AddTxtControl();

                    break;
                case AramaKriterleri.Kredi_Kartý_No:
                case AramaKriterleri.Poliçe_No:
                    AddTxtControl();

                    break;
                case AramaKriterleri.Esas_No:
                    AddTxtControl();

                    break;
                case AramaKriterleri.Özel_Kod:
                    AddLueControl();
                    BelgeUtil.Inits.FoyOzelKodGetir(lue);

                    break;
                case AramaKriterleri.Dosya_Taraflarý:
                    AddLueControl();
                    BelgeUtil.Inits.perCariGetir(lue.Properties);

                    break;
                default:
                    break;
            }
        }

        private TList<AV001_TI_BIL_FOY> masterFoy = new TList<AV001_TI_BIL_FOY>();

        public TList<AV001_TI_BIL_FOY> MyDataSource
        {
            get { return masterFoy; }
            set
            {
                masterFoy = value;
//#if ESKISI
                //if (masterFoy.Count == 0 && value!=null)
                //    this.masterFoy = (TList<AV001_TI_BIL_FOY>)MyDataSource.Clone();
//#else
//                this.masterFoy = value;
//#endif
            }
        }

        private void LoadItem()
        {
            int i = 0;
            foreach (AramaKriterleri var in Enum.GetValues(typeof(AramaKriterleri)))
            {
                if (Mod == Modul.Banka)
                {
                    if (var.ToString().Contains("Hasar_No"))
                        continue;
                    else
                        cmbKriter.Properties.Items.Insert(i, var.ToString().Replace('_', ' '));
                }
                else if (Mod == Modul.Sigorta)
                {
                    if (var.ToString().Contains("Kredi_Kartý_No"))
                        continue;
                    else
                        cmbKriter.Properties.Items.Insert(i, var.ToString().Replace('_', ' '));
                }

                i++;
            }
        }

        private void FindFoyNo(TList<AV001_TI_BIL_FOY> foy, string foyKod, int foySayi)
        {
            int i = 0;
            bool varmi = false;

            tempFoy.Clear();
            foreach (var var in foy)
            {
                string[] dizi = var.FOY_NO.Split('~');
                if (txtKod.Text != "" && txtNo.Text != "")
                {
                    if (var.FOY_NO == txtKod.Text + "~" + txtNo.Text)
                    {
                        varmi = true;
                        break;
                    }
                    i++;
                }
                else if (txtKod.Text != "")
                {
                    if (dizi[0] == foyKod)
                    {
                        varmi = true;
                        break;
                    }
                    i++;
                }
                else if (txtNo.Text != "")
                {
                    if (dizi[1] == foySayi.ToString())
                    {
                        varmi = true;
                        break;
                    }
                    i++;
                }
            }

            if (varmi)
            {
                this.dataNavigator1.Position = i;
                btnAra.Enabled = false;
            }
            else
                XtraMessageBox.Show("Aradýðýnýz föy numarasýna ait kayýt bulunamadý", "Kayýt Bulunamadý",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private TList<AV001_TI_BIL_ALACAK_NEDEN> tempAlacakNeden = new TList<AV001_TI_BIL_ALACAK_NEDEN>();

        private void FindNo(AramaKriterleri k, TList<AV001_TI_BIL_FOY> foy, string strNo)
        {
            int i = 0;
            bool varmi = false;

            switch (k)
            {
                case AramaKriterleri.Hasar_No:
                    foreach (var var in foy)
                    {
                        var refNoList = BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.Where(item => item.ICRA_FOY_ID == var.ID).Select(vi => vi.REFERANS_NO);
                        foreach (var refNo in refNoList)
                        {
                            if (refNo == strNo)
                            {
                                varmi = true;
                                break;
                            }
                            i++;
                        }
                    }

                    if (varmi)
                    {
                        dataNavigator1.Position = i;
                    }
                    else
                        XtraMessageBox.Show("Aradýðýnýz hasar numarasýna göre dosya bulunamadý.", "Dosya Arama",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case AramaKriterleri.Poliçe_No:
                    foreach (var var in foy)
                    {
                        var refNoList = BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.Where(item => item.ICRA_FOY_ID == var.ID).Select(vi => vi.REFERANS_NO);
                        foreach (var refNo in refNoList)
                        {
                            if (refNo == strNo)
                            {
                                varmi = true;
                                break;
                            }
                            i++;
                        }
                    }

                    if (varmi)
                    {
                        dataNavigator1.Position = i;
                    }
                    else
                        XtraMessageBox.Show("Aradýðýnýz poliçe numarasýna göre dosya bulunamadý.", "Dosya Arama",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case AramaKriterleri.Kredi_Kartý_No:
                    foreach (var var in foy)
                    {
                        var refNoList = BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.Where(item => item.ICRA_FOY_ID == var.ID).Select(vi => vi.REFERANS_NO);
                        foreach (var refNo in refNoList)
                        {
                            if (refNo == strNo)
                            {
                                varmi = true;
                                break;
                            }
                            i++;
                        }
                    }

                    if (varmi)
                    {
                        dataNavigator1.Position = i;
                    }
                    else
                        XtraMessageBox.Show("Aradýðýnýz kredi kartý numarasýna göre dosya bulunamadý.", "Dosya Arama",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case AramaKriterleri.Esas_No:

                    foreach (var var in foy)
                    {
                        var refNoList = BelgeUtil.Inits.context.per_AV001_TI_BIL_ALACAK_NEDENs.Where(item => item.ICRA_FOY_ID == var.ID).Select(vi => vi.REFERANS_NO);
                        foreach (var refNo in refNoList)
                        {
                            if (refNo == strNo)
                            {
                                varmi = true;
                                break;
                            }
                            i++;
                        }
                    }
                    if (varmi)
                        dataNavigator1.Position = i;
                    else
                        XtraMessageBox.Show("Aradýðýnýz esas numarasýna göre dosya bulunamadý.", "Dosya Arama",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                default:
                    break;
            }
        }

        private TList<AV001_TI_BIL_FOY> tempFoy = new TList<AV001_TI_BIL_FOY>();

        private void FindFoyOzelKod(int Id)
        {
            //bool varmi = false;
            int i = 0;

            tempFoy.Clear();
            foreach (var var in MyDataSource)
            {
                if (var.ICRA_OZEL_KOD1_ID.HasValue)
                {
                    if (var.ICRA_OZEL_KOD1_ID.Value == Id)
                    {
                        tempFoy.Add(var);
                        i++;
                    }
                }
                if (var.ICRA_OZEL_KOD2_ID.HasValue)
                {
                    if (var.ICRA_OZEL_KOD2_ID.Value == Id)
                    {
                        tempFoy.Add(var);
                        i++;
                    }
                }
                if (var.ICRA_OZEL_KOD3_ID.HasValue)
                {
                    if (var.ICRA_OZEL_KOD3_ID.Value == Id)
                    {
                        tempFoy.Add(var);
                        i++;
                    }
                }
                if (var.ICRA_OZEL_KOD4_ID.HasValue)
                {
                    if (var.ICRA_OZEL_KOD4_ID.Value == Id)
                    {
                        tempFoy.Add(var);
                        i++;
                    }
                }
            }
            if (tempFoy.Count > 0)
            {
                dataNavigator1.DataSource = tempFoy;
                dataNavigator1.Position = i;
                btnAra.Enabled = false;
            }
            else
            {
                XtraMessageBox.Show("Aradýðýnýz özel koda göre dosya bulunamadý.", "Dosya Arama", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            switch ((AramaKriterleri)selIndex)
            {
                case AramaKriterleri.Dosya_No:

                    if (txtKod.Text == "" && txtNo.Text == "") return;
                    FindFoyNo(MyDataSource, txtKod.Text, (Convert.ToInt32(txtNo.Text)));

                    break;
                case AramaKriterleri.Hasar_No:
                case AramaKriterleri.Kredi_Kartý_No:
                case AramaKriterleri.Poliçe_No:
                case AramaKriterleri.Esas_No:
                    FindNo((AramaKriterleri)selIndex, MyDataSource, txt.Text);
                    break;

                case AramaKriterleri.Özel_Kod:
                    if (lue.EditValue == null) return;
                    FindFoyOzelKod((int)lue.EditValue);
                    break;

                case AramaKriterleri.Dosya_Taraflarý:

                    break;
                default:
                    break;
            }
        }
    }
}