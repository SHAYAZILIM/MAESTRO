using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.Forms.Icra;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;

namespace AdimAdimDavaKaydi
{
    public partial class ucSozlesmeDetaylari : XtraUserControl
    {
        private AV001_TI_BIL_FOY myFoy;

        private AV001_TDI_BIL_SOZLESME mySozlesme;

        private AV001_TI_BIL_GAYRIMENKUL_TARAF trf;

        private TList<AV001_TI_BIL_GAYRIMENKUL_TARAF> trfList;

        public ucSozlesmeDetaylari()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    try
                    {
                        if (this.DesignMode) return;
                        ucSozlesmeDerece1.MyFoy = this.MyFoy;
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDI_BIL_SOZLESME MySozlesme
        {
            get { return mySozlesme; }
            set
            {
                mySozlesme = value;
                if (value != null && !this.DesignMode)
                {
                    try
                    {
                        initDataSource(MySozlesme);                       
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }
            }
        }

        internal void TarafOlustur(TList<AV001_TDI_BIL_SOZLESME_TARAF> tList)
        {
            if (trfList == null)
                trfList = new TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>();
            foreach (var item in tList)
            {
                if (item.TARAF_KODU == (short)TarafKodu.KarsiTaraf)
                {
                    trf = new AV001_TI_BIL_GAYRIMENKUL_TARAF();
                    trf.TARAF_CARI_ID = item.CARI_ID;
                    trf.TARAF_SIFAT_ID = 1;
                    trfList.Add(trf);
                }
            }
        }

        private void GayriMenkul_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_GAYRIMENKUL gayri = new AV001_TI_BIL_GAYRIMENKUL();
            gayri.KONTROL_KIM_ID = AvukatProLib.Kimlik.Bilgi.ID;
            gayri.KONTROL_NE_ZAMAN = DateTime.Now;
            gayri.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            gayri.KAYIT_TARIHI = DateTime.Now;
            gayri.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            if (trfList != null)
            {
                if (ucMenkulTaraf.MyDataSource == null)
                    ucMenkulTaraf.MyDataSource = new TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>();
                ucMenkulTaraf.MyDataSource.AddRange(trfList);
            }
            e.NewObject = gayri;
        }

        private void GayriMenkulTaraf_AddingNew(object sender, AddingNewEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        private void initDataSource(AV001_TDI_BIL_SOZLESME sozlesme)
        {
            if (this.DesignMode) return;

            ucMenkulTaraf.MyDataSource = null;
            ucGayriMenkul.MyDataSource = null;
            ucTakyidat.MyDataSource = null;
            try
            {
                sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.AddingNew
                    += GayriMenkul_AddingNew;
                ucGayriMenkul.MyDataSource = sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL;

                foreach (
                    AV001_TI_BIL_GAYRIMENKUL menkul in
                        sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL)
                {
                    menkul.AV001_TI_BIL_GAYRIMENKUL_TARAFCollection.AddingNew
                        += GayriMenkulTaraf_AddingNew;

                    menkul.AV001_TDI_BIL_SOZLESME_DERECECollection.AddingNew
                        += SozlesmeDerece_AddingNew;
                }
                int i;
                if (ucGayriMenkul.RecordIndex == null)
                    i = 0;
                else
                    i = ucGayriMenkul.RecordIndex;

                if (sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL.Count > 0)
                {
                    DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.DeepLoad(
                        sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL[i], false,
                        DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_GAYRIMENKUL_TARAF>));
                    ucMenkulTaraf.MyDataSource =
                        sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL[i].
                            AV001_TI_BIL_GAYRIMENKUL_TARAFCollection;
                    ucKiymetTakdiri1.MyDataSource =
                        sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL[i].
                            AV001_TI_BIL_KIYMET_TAKDIRICollection;
                    ucSozlesmeDerece1.MyDerece =
                        sozlesme.AV001_TI_BIL_GAYRIMENKULCollection_From_NN_SOZLESME_GAYRIMENKUL[i].
                            AV001_TDI_BIL_SOZLESME_DERECECollection;
                }

                sozlesme.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATCollection.AddingNew
                    += Takyidat_AddingNew;
                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(sozlesme, false, DeepLoadType.IncludeChildren,
                                                                       typeof(
                                                                           TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>));
                ucTakyidat.MyDataSource = sozlesme.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATCollection;

                ucGayriMenkul.MySozlesme = sozlesme;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void SozlesmeDerece_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                AV001_TDI_BIL_SOZLESME_DERECE addNew = e.NewObject as AV001_TDI_BIL_SOZLESME_DERECE;
                if (addNew == null)
                    addNew = new AV001_TDI_BIL_SOZLESME_DERECE();

                addNew.ADMIN_KAYIT_MI = false;
                addNew.KAYIT_TARIHI = DateTime.Now;
                addNew.KONTROL_KIM_ID = 1;
                addNew.SUBE_ID = 2;

                e.NewObject = addNew;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void Takyidat_AddingNew(object sender, AddingNewEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

    }
}