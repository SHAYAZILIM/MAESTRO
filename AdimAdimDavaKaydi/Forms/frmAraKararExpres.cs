using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmAraKararExpres : Util.BaseClasses.AvpXtraForm
    {
        public frmAraKararExpres()
        {
            InitializeComponent();
        }

        private string AraKarar;

        private int? AraKararTipID;

        private TList<AV001_TD_BIL_ARA_KARAR> MyDataSource;

        private DateTime? TamamlanmaTarihi;

        private DateTime? Tarihi;

        private byte? YerineGetirenCariID;

        private bool? YerineGetirildi;

        private DateTime? YerineGetirmeTarihi;
        
        private static void FormlariTemizle(Control.ControlCollection coll)
        {
            try
            {
                foreach (Control con in coll)
                {
                    if (con is LookUpEdit)
                    {
                        (con as LookUpEdit).EditValue = null;
                    }
                    else if (con is DateEdit)
                    {
                        ((DateEdit)con).EditValue = null;
                    }
                    else if (con is TextEdit)
                    {
                        con.Text = string.Empty;
                    }
                    else if (con is SpinEdit)
                    {
                        (con as SpinEdit).EditValue = null;
                    }
                }
            }
            catch 
            {
            }
        }

        private void dtTamamlanmaTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTamamlanmaTarihi.EditValue != null)
                TamamlanmaTarihi = (DateTime?)dtTamamlanmaTarihi.EditValue;
            else
                TamamlanmaTarihi = null;
        }

        private void dtTarih_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTarih.EditValue != null)
                Tarihi = (DateTime?)dtTarih.EditValue;
            else
                Tarihi = null;
        }

        private void dtYerineGetirmeTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (dtYerineGetirmeTarihi.EditValue != null)
                YerineGetirmeTarihi = (DateTime?)dtYerineGetirmeTarihi.EditValue;
            else
                YerineGetirmeTarihi = null;
        }

        private void frmAraKararExpres_Load(object sender, EventArgs e)
        {
            MyDataSource = new TList<AV001_TD_BIL_ARA_KARAR>();
            DataRepository.AV001_TD_BIL_ARA_KARARProvider.DeepLoad(MyDataSource, false, DeepLoadType.IncludeChildren,
                                                                   typeof(TList<AV001_TD_BIL_ARA_KARAR>));
            gridDavaAraKarar.DataSource = MyDataSource;

            LoadData();
        }

        private void gridDavaAraKarar_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == null)
                return;

            else if (e.Button.Tag.ToString() == "FormAc")
            {
                Forms.Dava.rfrmAraKararKayit AraKararKayit = new AdimAdimDavaKaydi.Forms.Dava.rfrmAraKararKayit();

                //AraKararKayit.MdiParent = null;
                AraKararKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                AraKararKayit.IsModul = true;
                AraKararKayit.Show();
            }
        }

        private void LoadData()
        {
            lueAraKArarTipID.Properties.NullText = "Seç";
            lueAraKArarTipID.Enter += delegate { BelgeUtil.Inits.AraKararTipGetir(lueAraKArarTipID.Properties); };

            lueYerineGetirenCariID.Properties.NullText = "Seç";
            lueYerineGetirenCariID.Enter +=
                delegate { BelgeUtil.Inits.KimYerineGetirecekEnumGetir(lueYerineGetirenCariID.Properties); };

            lueAraKArarTipID.Properties.NullText = "Seç";
            lueAraKArarTipID.Enter += delegate { BelgeUtil.Inits.AraKararKodTipGetir(lueAraKArarTipID.Properties); };

            //gridDavaAraKarar
            BelgeUtil.Inits.FoyDurumGetir(rlueFoyDurum);
            BelgeUtil.Inits.SubeKodGetir(rlueSubeKodID);
            BelgeUtil.Inits.KontrolKimGetir(rlueKontrolKimID);
        }

        private void lueAraKArarTipID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAraKArarTipID.EditValue != null)
                AraKararTipID = (int?)lueAraKArarTipID.EditValue;
            else
                AraKararTipID = null;
        }

        private void lueYerineGetirenCariID_EditValueChanged(object sender, EventArgs e)
        {
            if (lueYerineGetirenCariID.EditValue != null)
                YerineGetirenCariID = (byte?)lueYerineGetirenCariID.EditValue;
            else
                YerineGetirenCariID = null;
        }

        private void rgYerineGetirildi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgYerineGetirildi.Properties.Items[rgYerineGetirildi.SelectedIndex].Value == null)
            {
                YerineGetirildi = null;
            }
            else
            {
                YerineGetirildi =
                    Convert.ToBoolean(rgYerineGetirildi.Properties.Items[rgYerineGetirildi.SelectedIndex].Value);
            }
        }

        private void sbtnSorgula_Click(object sender, EventArgs e)
        {
            TList<AV001_TD_BIL_ARA_KARAR> AraKararBilgileriList = new TList<AV001_TD_BIL_ARA_KARAR>();
            AraKararBilgileriList = DataRepository.AV001_TD_BIL_ARA_KARARProvider.GetByFiltre(null, null, Tarihi, null,
                                                                                              YerineGetirmeTarihi,
                                                                                              AraKarar, AraKararTipID,
                                                                                              YerineGetirenCariID,
                                                                                              YerineGetirildi,
                                                                                              TamamlanmaTarihi);
            VList<ARA_KARAR_DAVA_GENEL_TARAFLI> ArakararView = new VList<ARA_KARAR_DAVA_GENEL_TARAFLI>();
            foreach (var item in AraKararBilgileriList)
            {
                ArakararView.Add(
                    DataRepository.ARA_KARAR_DAVA_GENEL_TARAFLIProvider.Get(string.Format("ID = {0}", item.ID), "ID").
                        FirstOrDefault());
            }
            gridDavaAraKarar.DataSource = ArakararView;
        }

        private void sbtnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle(layoutControl1.Controls);
            gridDavaAraKarar.DataSource = null;
            rgYerineGetirildi.SelectedIndex = 3;
        }

        private void txtAraKArar_EditValueChanged(object sender, EventArgs e)
        {
            AraKarar = "%" + txtAraKArar.Text + "%";
            if (txtAraKArar.Text == string.Empty)
                AraKarar = null;
        }
    }
}