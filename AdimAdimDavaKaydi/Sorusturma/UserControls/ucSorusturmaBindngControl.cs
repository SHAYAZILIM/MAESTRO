using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Sorusturma.UserControls
{
    public partial class ucSorusturmaBindngControl : AvpXUserControl
    {
        private TList<AV001_TD_BIL_HAZIRLIK> _MyDataSource;

        private TList<AV001_TD_BIL_HAZIRLIK> hazirliklist = new TList<AV001_TD_BIL_HAZIRLIK>();

        private LookUpEdit lue = new LookUpEdit();

        private int selIndex;

        private List<Control> temp = new List<Control>();

        private TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN> tempAlacakNdn =
            new TList<AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN>();

        private TList<AV001_TD_BIL_HAZIRLIK> tmpHzr = new TList<AV001_TD_BIL_HAZIRLIK>();

        private TextEdit txt = new TextEdit();

        public ucSorusturmaBindngControl()
        {
            this.Load += ucSorusturmaBindngControl_Load;
        }

        public enum AramaKriterleri
        {
            Dosya_No = 0,
            Sorusturma_No = 1,
            Sorusturma_Esas_No = 2,
            IDDIANAME_KARAR_NO = 3,
            Özel_Kod = 4,
            Hasar_No = 5,
            Poliçe_No = 6,
            Çek_Seri_No = 7,
            Dosya_Taraflari = 8
        }

        public enum Modul
        {
            Banka = 0,
            Sigorta = 1
        }

        public Modul Mod { get; set; }

        public TList<AV001_TD_BIL_HAZIRLIK> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        public void BindData()
        {
            this.dataNavigator1.DataSource = MyDataSource;
        }

        private void AddLueControl()
        {
            foreach (Control con in panelMaster.Controls)
            {
                if (con == panelChild)
                {
                    if (!temp.Contains(con))
                        temp.Add(con);
                }
                panelMaster.Controls.Clear();
                panelMaster.Controls.Add(lue);
                lue.Dock = DockStyle.Fill;
            }
        }

        private void AddtempControl()
        {
            panelMaster.Controls.Clear();
            panelMaster.Controls.Add(temp[0]);
        }

        private void AddTxtControl()
        {
            foreach (Control con in panelMaster.Controls)
            {
                if (con == panelChild)
                {
                    if (!temp.Contains(con))
                        temp.Add(con);
                }
                panelMaster.Controls.Clear();
                panelMaster.Controls.Add(txt);
                txt.Dock = DockStyle.Fill;
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            switch ((AramaKriterleri)selIndex)
            {
                case AramaKriterleri.Dosya_No:
                    if (txtNo.Text == "" && txtKod.Text == "") return;
                    FindSorusturmaNo(MyDataSource, txtKod.Text, (Convert.ToInt32(txtNo.Text)));
                    break;

                case AramaKriterleri.Çek_Seri_No:
                case AramaKriterleri.Hasar_No:
                case AramaKriterleri.IDDIANAME_KARAR_NO:
                case AramaKriterleri.Poliçe_No:
                case AramaKriterleri.Sorusturma_Esas_No:

                    FindNo((AramaKriterleri)selIndex, MyDataSource, txt.Text);
                    break;

                case AramaKriterleri.Özel_Kod:
                    if (lue.EditValue == null) return;
                    FindOzelNo((int)lue.EditValue);
                    break;

                case AramaKriterleri.Dosya_Taraflari:
                    break;

                default:
                    break;
            }
        }

        private void ChangeFindControl(AramaKriterleri aramaKriterleri)
        {
            switch (aramaKriterleri)
            {
                case AramaKriterleri.Dosya_No:
                    AddtempControl();
                    break;

                case AramaKriterleri.Hasar_No:
                    AddTxtControl();
                    break;

                case AramaKriterleri.Çek_Seri_No:
                case AramaKriterleri.Poliçe_No:
                    AddTxtControl();
                    break;

                case AramaKriterleri.IDDIANAME_KARAR_NO:
                    AddTxtControl();
                    break;

                case AramaKriterleri.Özel_Kod:
                    AddLueControl();
                    BelgeUtil.Inits.FoyOzelKodGetir(lue);
                    break;

                case AramaKriterleri.Sorusturma_Esas_No:
                    AddTxtControl();
                    break;

                case AramaKriterleri.Dosya_Taraflari:
                    AddLueControl();
                    BelgeUtil.Inits.perCariGetir(lue.Properties);
                    break;

                case AramaKriterleri.Sorusturma_No:
                    AddtempControl();
                    break;
                default:
                    break;
            }
        }

        private void comboKriter_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxEdit cmb = sender as ComboBoxEdit;
            if (cmb.SelectedItem != null)
            {
                selIndex = cmb.SelectedIndex;
                if (selIndex > 2)
                    ChangeFindControl((AramaKriterleri)selIndex);
                selIndex++;
            }
        }

        private void FindNo(AramaKriterleri kriter, TList<AV001_TD_BIL_HAZIRLIK> hzr, string strNo)
        {
            int i = 0;
            bool varMi = false;
            switch (kriter)
            {
                case AramaKriterleri.Hasar_No:
                    foreach (AV001_TD_BIL_HAZIRLIK var in hzr)
                    {
                        foreach (
                            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN ndn in var.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection
                            )
                        {
                            if (ndn.REFERANS_NO_1 == strNo)
                            {
                                varMi = true;
                                break;
                            }
                            i++;
                        }
                    }
                    if (varMi)
                    {
                        dataNavigator1.Position = i;
                    }
                    else
                        XtraMessageBox.Show("Aradýðýnýz Hasar Numarasýna Göre Dosya Bulunamadý", "Dosya Arama",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case AramaKriterleri.Poliçe_No:
                    foreach (AV001_TD_BIL_HAZIRLIK var in hzr)
                    {
                        foreach (
                            AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDEN ndn in var.AV001_TD_BIL_HAZIRLIK_SIKAYET_NEDENCollection
                            )
                        {
                            if (ndn.REFERANS_NO_2 == strNo)
                            {
                                varMi = true;
                                break;
                            }
                            i++;
                        }
                    }
                    if (varMi)
                    {
                        dataNavigator1.Position = i;
                    }
                    else
                        XtraMessageBox.Show("Aradýðýnýz Poliçe Numarasýna Göre Dosya Bulunmadý", "Dosya Arama",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case AramaKriterleri.Sorusturma_Esas_No:
                    foreach (AV001_TD_BIL_HAZIRLIK var in hzr)
                    {
                        if (var.HAZIRLIK_ESAS_NO == strNo)
                        {
                            varMi = true;
                            break;
                        }
                        i++;
                    }
                    if (varMi)
                    {
                        dataNavigator1.Position = i;
                    }
                    else
                        XtraMessageBox.Show("Aradýðýnýz Esas Numarasýna Göre Dosya Bulunamadý", "Dosya Arama",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                #region ÇekSeri no Aramasý Eklenecek

                //case AramaKriterleri.Çek_Seri_No:
                //    foreach (AV001_TD_BIL_HAZIRLIK var in hzr)
                //    {
                //        foreach (AV001_TDI_BIL_KIYMETLI_EVRAK kiymetli in)
                //        {
                //            if (kiymetli.CEK_NO == strNo)
                //            {
                //                varMi = true;
                //                break;
                //            }
                //            i++;
                //        }
                //        if (varMi)
                //        {
                //            dataNavigator1.Position = i;
                //        }
                //        else
                //            XtraMessageBox.Show("Aradýðýnýz ÇekSeri Numarasýna  Göre Dosya bulunamadý", "Dosya Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        break;
                //    }
                //    break;

                #endregion ÇekSeri no Aramasý Eklenecek

                case AramaKriterleri.IDDIANAME_KARAR_NO:
                    foreach (AV001_TD_BIL_HAZIRLIK var in hzr)
                    {
                        foreach (AV001_TD_BIL_HAZIRLIK_SUREC surec in var.AV001_TD_BIL_HAZIRLIK_SURECCollection)
                        {
                            if (surec.IDDIANAME_KARAR_NO == strNo)
                            {
                                varMi = true;
                                i++;
                            }
                        }
                        if (varMi)
                        {
                            dataNavigator1.Position = i;
                        }
                        else
                            XtraMessageBox.Show("Aradýðýnýz Iddýaname Numarasýna Göre Dosya Bulunamadý", "Dosya Arama",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                default:
                    break;
            }
        }

        private void FindOzelNo(int Id)
        {
            int i = 0;
            tmpHzr.Clear();
            foreach (AV001_TD_BIL_HAZIRLIK hzr in MyDataSource)
            {
                if (hzr.OZEL_KOD_1_ID.HasValue)
                {
                    if (hzr.OZEL_KOD_1_ID.Value == Id)
                    {
                        tmpHzr.Add(hzr);
                        i++;
                    }
                }
                if (hzr.OZEL_KOD_2_ID.HasValue)
                {
                    if (hzr.OZEL_KOD_2_ID.Value == Id)
                    {
                        tmpHzr.Add(hzr);
                        i++;
                    }
                }
                if (hzr.OZEL_KOD_3_ID.HasValue)
                {
                    if (hzr.OZEL_KOD_3_ID.Value == Id)
                    {
                        tmpHzr.Add(hzr);
                        i++;
                    }
                }
                if (hzr.OZEL_KOD_4_ID.HasValue)
                {
                    if (hzr.OZEL_KOD_4_ID.Value == Id)
                    {
                        tmpHzr.Add(hzr);
                        i++;
                    }
                }
                if (tmpHzr.Count > 0)
                {
                    dataNavigator1.DataSource = tmpHzr;
                    dataNavigator1.Position = i;
                    btnAra.Enabled = false;
                }
                else
                    XtraMessageBox.Show("Aradýðýnýz Özel Koda Göre Dosya Bulunamadý", "Dosya Arama",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FindSorusturmaNo(TList<AV001_TD_BIL_HAZIRLIK> hazirlik, string HazirlikKod, int HazirlikSayý)
        {
            int i = 0;
            bool varMi = false;
            tmpHzr.Clear();
            foreach (AV001_TD_BIL_HAZIRLIK var in hazirlik)
            {
                if (txtKod.Text != "" && txtNo.Text != "")
                {
                    if (var.HAZIRLIK_NO == txtKod.Text + "~" + txtNo.Text)
                    {
                        varMi = true;
                        break;
                    }
                    i++;
                }
                else if (txtKod.Text != "")
                {
                    if (var.HAZIRLIK_NO == HazirlikKod)
                    {
                        varMi = true;
                        break;
                    }
                    i++;
                }
                else if (txtNo.Text != "")
                {
                    if (var.HAZIRLIK_NO_Sayi == HazirlikSayý)
                    {
                        varMi = true;
                        break;
                    }
                    i++;
                }
            }
            if (varMi)
            {
                this.dataNavigator1.Position = i;
                btnAra.Enabled = false;
            }
            else
                XtraMessageBox.Show("Aradýðýnýz Soruþturma Numarasýna Ait Kayýt Bulunamadý", "Kayýt Bulunamadý",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadData()
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtKod.Text = string.Empty;
            txtNo.Text = string.Empty;
            lue.EditValue = null;
            dataNavigator1.DataSource = null;
            dataNavigator1.DataSource = MyDataSource;
            btnAra.Enabled = true;
        }

        private void ucSorusturmaBindngControl_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            IsLoaded = true;
            if (!this.DesignMode)
            {
                BindData();
                LoadData();
                temp.Add(panelMaster.Controls[0]);
                cmbKriter.SelectedIndex = 0;
                dataNavigator1.DataSource = new TList<AV001_TD_BIL_HAZIRLIK>();
            }
        }
    }
}