using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using BelgeUtil;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.Sozlesme.Forms;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucKiymetliEvrakGiris : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKiymetliEvrakGiris()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME MySozlesme { get; set; }

        public TList<AV001_TDI_BIL_KIYMETLI_EVRAK>
            MyDataSource
        {
            get
            {
                if (exGridKiymetliEvrak.DataSource is TList<AV001_TDI_BIL_KIYMETLI_EVRAK>)
                    return (TList<AV001_TDI_BIL_KIYMETLI_EVRAK>)exGridKiymetliEvrak.DataSource;
                return null;
            }
            set
            {
                if (value == null)
                {
                    exGridKiymetliEvrak.DataSource = value;
                }

                if (value != null && !this.DesignMode)
                {
                    exGridKiymetliEvrak.DataSource = value;
                    extendedGridControl1.DataSource = value;
                }
            }
        }

        private void ucKiymetliEvrakGiris_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;

            BelgeUtil.Inits.KiymetliEvrakTipiGetir(rLueEvrakTur);
            BelgeUtil.Inits.DovizTipGetir(rLueDovizTip);
            BelgeUtil.Inits.BankaGetir(rLueBankaID);
            AvukatPro.Services.Implementations.DevExpressService.BankaSubeGetir(rLueBankaSube, null);
            //BelgeUtil.Inits.BankaSubeGetir(rLueBankaSube);
            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.KiymetliEvrakStatuDurumGetir(rLueKiymetliEvrakSurecDurum);
            BelgeUtil.Inits.KiymetliEvrakTarafTipGetir(rLueKiymetliEvrakTarafTip);
            BelgeUtil.Inits.KEAhzolunmaSekliGetir(rLueNasýlAhzolundugu);
            BelgeUtil.Inits.KESonucuGetir(rLueSorulmaSonucu);
            BelgeUtil.Inits.TarafSifatGetir(rlueK);
            BelgeUtil.Inits.FoyOzelKodGetir(rlueOzelKod);
            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.DosyaDurumGetir(rLueFoyDurum);
            BelgeUtil.Inits.FoyBirimGetir(rLueDosyaBirim);
            BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
            BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
            BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
            BelgeUtil.Inits.ModulGetir(rLueModul);
            BelgeUtil.Inits.KiymetliEvrakTipiGetir(repositoryItemLookUpEdit1);
            BelgeUtil.Inits.DovizTipGetir(repositoryItemLookUpEdit2);
            BelgeUtil.Inits.BankaGetir(repositoryItemLookUpEdit3);
            AvukatPro.Services.Implementations.DevExpressService.BankaSubeGetir(repositoryItemLookUpEdit4, null);
            //BelgeUtil.Inits.BankaSubeGetir(repositoryItemLookUpEdit4);
            BelgeUtil.Inits.perCariGetir(repositoryItemLookUpEdit5);

            exGridKiymetliEvrak.ButtonCevirClick += exGridKiymetliEvrak_ButtonCevirClick;
            extendedGridControl1.ButtonCevirClick += exGridKiymetliEvrak_ButtonCevirClick;
        }

        private void exGridKiymetliEvrak_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (exGridKiymetliEvrak.Visible)
            {
                exGridKiymetliEvrak.Visible = false;
                extendedGridControl1.Visible = true;
            }
            else
            {
                exGridKiymetliEvrak.Visible = true;
                extendedGridControl1.Visible = false;
            }
        }

        private void gridView1_MasterRowExpanding(object sender,
                                                  DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs e)
        {
            AV001_TDI_BIL_KIYMETLI_EVRAK gelen = (AV001_TDI_BIL_KIYMETLI_EVRAK)gridView1.GetRow(e.RowHandle);
            if (gelen.R_BIRLESIK_TAKIPLER_TUMU_KIYMETLI_EVRAKCollection != null) return;

            gelen.R_BIRLESIK_TAKIPLER_TUMU_KIYMETLI_EVRAKCollection =
                DataRepository.R_BIRLESIK_TAKIPLER_TUMU_KIYMETLI_EVRAKProvider.Get(
                    string.Format("KIYMETLI_EVRAK_ID={0}", gelen.ID), "KAYIT_TARIHI ASC");
        }

        private void kiymetli_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MySozlesme != null)
            {
                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(MySozlesme, false, DeepLoadType.IncludeChildren
                                                                       , typeof(TList<NN_SOZLESME_KIYMETLI_EVRAK>));
                MyDataSource = MySozlesme.AV001_TDI_BIL_KIYMETLI_EVRAKCollection_From_NN_SOZLESME_KIYMETLI_EVRAK;
            }
        }

        private void kiymetli_KiymetliEvrakKaydedildi(object sender, KiymetliEvrakKaydedildiEventArgs e)
        {
            if (MySozlesme != null)
            {
                if (e.KiymetliFoy != null)
                {
                    foreach (var item in e.KiymetliFoy)
                    {
                        if (
                            MySozlesme.NN_SOZLESME_KIYMETLI_EVRAKCollection.FindAll(
                                NN_SOZLESME_KIYMETLI_EVRAKColumn.KIYMETLI_EVRAK_ID, item.ID).Count == 0)
                        {
                            NN_SOZLESME_KIYMETLI_EVRAK sKiymetli = new NN_SOZLESME_KIYMETLI_EVRAK();
                            sKiymetli.SOZLESME_ID = MySozlesme.ID;
                            sKiymetli.KIYMETLI_EVRAK_ID = item.ID;
                            DataRepository.NN_SOZLESME_KIYMETLI_EVRAKProvider.DeepSave(sKiymetli);
                        }
                    }
                }
            }
        }

        private void exGridKiymetliEvrak_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == "FormdanEkle")
            {
                frmKiymetliEvrakKayit kiymetli = new frmKiymetliEvrakKayit();
                //kiymetli.MdiParent = null;
                kiymetli.StartPosition = FormStartPosition.WindowsDefaultLocation;
                kiymetli.FormClosed += kiymetli_FormClosed;
                kiymetli.KiymetliEvrakKaydedildi += kiymetli_KiymetliEvrakKaydedildi;
                kiymetli.MyDataSource = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                kiymetli.Show();
            }
            if (e.Button.Tag == "KaydiDuzenle")
            {
                frmKiymetliEvrakKayit kiymetli = new frmKiymetliEvrakKayit();
                // kiymetli.MdiParent = null;
                kiymetli.StartPosition = FormStartPosition.WindowsDefaultLocation;
                kiymetli.FormClosed += kiymetli_FormClosed;
                kiymetli.KiymetliEvrakKaydedildi += kiymetli_KiymetliEvrakKaydedildi;
                TList<AV001_TDI_BIL_KIYMETLI_EVRAK> kList = new TList<AV001_TDI_BIL_KIYMETLI_EVRAK>();
                DataRepository.AV001_TDI_BIL_KIYMETLI_EVRAKProvider.DeepLoad(MyDataSource[gridView1.FocusedRowHandle], false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_KIYMETLI_EVRAK_TARAF>));
                kList.Add(MyDataSource[gridView1.FocusedRowHandle]);
                kiymetli.kiymetList = kList;
                kiymetli.MyDataSource = kList;
                kiymetli.Show();
            }
        }

        private void gridView5_DoubleClick(object sender, EventArgs e)
        {
            int foyID = (int)((sender as GridView).GetFocusedRow() as R_BIRLESIK_TAKIPLER_TUMU_KIYMETLI_EVRAK).ID;
            int modulID = (int)((sender as GridView).GetFocusedRow() as R_BIRLESIK_TAKIPLER_TUMU_KIYMETLI_EVRAK).MODUL;
            if (foyID > 0)
            {
                switch (modulID)
                {
                    case 1:
                        _frmIcraTakip frmIcra = new _frmIcraTakip();
                        frmIcra.Show(foyID);
                        break;
                    case 2:
                        frmDavaTakip frmDava = new frmDavaTakip();
                        frmDava.Show(foyID);
                        break;
                    case 3:
                        rFrmSorusturmaTakip frmSorusturma = new rFrmSorusturmaTakip();
                        frmSorusturma.Show(foyID);
                        break;
                    case 5:
                        frmSozlesmeTakip frmSozlesme = new frmSozlesmeTakip();
                        frmSozlesme.Show(foyID);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}