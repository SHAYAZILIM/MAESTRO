using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using TablesDatasConverter;

namespace AdimAdimDavaKaydi.Belge.UserControls
{
    public partial class ucTaraf : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTaraf()
        {
            InitializeComponent();
        }

        private List<Taraf> _dataSourceTaraf;

        private IEntity _Record;

        private TList<AV001_TDIE_BIL_BELGE_TARAF> lstBelgeTaraf = new TList<AV001_TDIE_BIL_BELGE_TARAF>();


        [Browsable(false)]
        public List<Taraf> DataSourceTaraf
        {
            get
            {
                if (DesignMode)
                    return null;

                List<Taraf> lstTarafs = new List<Taraf>();
                BindingList<Taraf> lstTarafs2 = (BindingList<Taraf>)this.c_gcTaraf.DataSource;

                for (int i = 0; i < lstTarafs2.Count; i++)
                {
                    lstTarafs.Add(lstTarafs2[i]);
                }
                return lstTarafs;
            }
            set
            {
                if (DesignMode || value == null)
                    return;

                _dataSourceTaraf = value;
                BindingList<Taraf> lstTarafs = new BindingList<Taraf>();

                for (int i = 0; i < value.Count; i++)
                {
                    if (value[i].SozlesmeTarafimi)
                    {
                        value[i].SifatId = value[i].SozlesmeSifat.ID;
                    }
                    lstTarafs.Add(value[i]);
                }

                this.c_gcTaraf.DataSource = lstTarafs;
            }
        }

        [Browsable(false)]
        public IEntity Record
        {
            get
            {
                if (DesignMode)
                    return null;

                return _Record;
            }
            set
            {
                if (DesignMode || value == null)
                    return;

                _Record = value;

                List<Taraf> dst = new List<Taraf>();

                if (value is AV001_TDIE_BIL_BELGE)
                {
                    if (((AV001_TDIE_BIL_BELGE)value).AV001_TDIE_BIL_BELGE_TARAFCollection == null || ((AV001_TDIE_BIL_BELGE)value).AV001_TDIE_BIL_BELGE_TARAFCollection.Count == 0)
                        DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepLoad((AV001_TDIE_BIL_BELGE)value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_BELGE_TARAF>));
                    for (int i = 0; i < ((AV001_TDIE_BIL_BELGE)value).AV001_TDIE_BIL_BELGE_TARAFCollection.Count; i++)
                    {
                        Taraf trf = new Taraf();
                        trf.Kodu = ((AV001_TDIE_BIL_BELGE)value).AV001_TDIE_BIL_BELGE_TARAFCollection[i].KODU;
                        trf.CariId =
                            ((AV001_TDIE_BIL_BELGE)value).AV001_TDIE_BIL_BELGE_TARAFCollection[i].CARI_ID.Value;
                        trf.SifatId =
                            ((AV001_TDIE_BIL_BELGE)value).AV001_TDIE_BIL_BELGE_TARAFCollection[i].SIFAT_ID.Value;
                        trf.TARAF = ((AV001_TDIE_BIL_BELGE)value).AV001_TDIE_BIL_BELGE_TARAFCollection[i];
                        trf.Id = ((AV001_TDIE_BIL_BELGE)value).AV001_TDIE_BIL_BELGE_TARAFCollection[i].ID;
                        dst.Add(trf);
                    }
                }
                else
                    dst = TablesDatasConverter.TableTarafData.GetTaraf(value);

                this.DataSourceTaraf = dst;
            }
        }

        [Browsable(false)]
        public TList<AV001_TDIE_BIL_BELGE_TARAF> Taraflar
        {
            get
            {
                if (this.DesignMode)
                    return null;

                return (TList<AV001_TDIE_BIL_BELGE_TARAF>)TablesDatasConverter.TableTarafData.SetTaraf(_dataSourceTaraf, Record);
            }
        }

        public void Save()
        {
            //AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGE_TARAFProvider.Save(lstBelgeTaraf);
        }

        private void c_gcTaraf_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null)
                return;

            else if (e.Button.Tag.ToString() == "Sil")
            {
                BindingList<Taraf> taraflarList = c_gcTaraf.DataSource as BindingList<Taraf>;

                Taraf taraf = new Taraf();
                if (taraflarList != null)
                {
                    taraf = taraflarList[gridView1.FocusedRowHandle];

                    if (taraf != null)
                    {
                        if (taraf.Id > 0)
                        {
                            AdimAdimDavaKaydi.Util.frmKayitSil kayitSil = new AdimAdimDavaKaydi.Util.frmKayitSil("AV001_TDIE_BIL_BELGE_TARAF", "ID = " + taraf.Id);
                            kayitSil.Show();
                        }

                        gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    }
                }
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            lstBelgeTaraf = (TList<AV001_TDIE_BIL_BELGE_TARAF>)TablesDatasConverter.TableTarafData.SetTaraf(DataSourceTaraf, Record);
        }

        private void rlueCari_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != string.Empty && e.Button.Tag == "YeniKayit")
            {
                try
                {
                    frmCariGenelGiris cari = new frmCariGenelGiris();
                    LookUpEdit lue = sender as LookUpEdit;
                    cari.tmpCariAd = lue.Text;

                    // cari.MdiParent = null;
                    cari.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    cari.Show();
                    cari.FormClosed += delegate
                                           {
                                               DialogResult dr = cari.KayitBasarili;
                                               if (dr == System.Windows.Forms.DialogResult.OK)
                                               {
                                                   //Inits.perCariGetirRefresh();
                                                   AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCari);
                                               }
                                           };
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void ucTaraf_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            if (this.c_gcTaraf.DataSource == null)
                this.c_gcTaraf.DataSource = new BindingList<Taraf>();

            rlueCari.NullText = "Seç";
            rlueSifat.NullText = "Seç";
            rlueTarafKodu.NullText = "Seç";
            BelgeUtil.Inits.TarafKoduGetir(rlueTarafKodu);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(rlueCari);
            BelgeUtil.Inits.TarafSifatGetir(this.rlueSifat);
            this.gridView1.ValidateRow += gridView1_ValidateRow;
        }
    }
}