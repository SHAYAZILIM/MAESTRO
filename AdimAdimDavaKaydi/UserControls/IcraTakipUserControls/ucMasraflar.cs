using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Muhasebe;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucMasraflar : AvpXUserControl
    {
        private AV001_TI_BIL_FOY _myFoy;

        private Dictionary<int, decimal> MasrafToplami = new Dictionary<int, decimal>();

        private AV001_TD_BIL_FOY myDavaFoy;

        private AV001_TD_BIL_HAZIRLIK myHazirlikFoy;

        private AV001_TDI_BIL_SOZLESME mySozlesmeFoy;

        public ucMasraflar()
        {
            if (DesignMode) InitializeComponent();
            this.Load += ucMasraflar_Load;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TDI_BIL_MASRAF_AVANS> MyDataSource { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TD_BIL_FOY MyDavaFoy
        {
            get { return myDavaFoy; }
            set
            {
                if (value != null && !DesignMode)
                {
                    myDavaFoy = value;
                    this.MyDataSource = value.AV001_TDI_BIL_MASRAF_AVANSCollection;
                    SetMyDataSource(this.MyDataSource);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return _myFoy; }
            set
            {
                _myFoy = value;
                if (value != null && !DesignMode)
                {
                    if (value.AV001_TDI_BIL_MASRAF_AVANSCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(_myFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                    this.MyDataSource = value.AV001_TDI_BIL_MASRAF_AVANSCollection;
                    SetMyDataSource(this.MyDataSource);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TD_BIL_HAZIRLIK MyHazirlikFoy
        {
            get { return myHazirlikFoy; }
            set
            {
                myHazirlikFoy = value;

                if (value != null && !DesignMode)
                {
                    this.MyDataSource = value.AV001_TDI_BIL_MASRAF_AVANSCollection;
                    SetMyDataSource(this.MyDataSource);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TDI_BIL_SOZLESME MySozlesmeFoy
        {
            get { return mySozlesmeFoy; }
            set
            {
                mySozlesmeFoy = value;

                if (value != null && !DesignMode)
                {
                    if (value.AV001_TDI_BIL_MASRAF_AVANSCollection.Count == 0)
                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                    this.MyDataSource = value.AV001_TDI_BIL_MASRAF_AVANSCollection;
                    SetMyDataSource(this.MyDataSource);
                }
            }
        }

        public static TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> GetSelectedFoy(TList<AV001_TDI_BIL_MASRAF_AVANS> masraflar)
        {
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> seciliMasrafDetaylari = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();

            foreach (AV001_TDI_BIL_MASRAF_AVANS masraf in masraflar)
            {
                if (masraf.IsSelected)
                {
                    DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(masraf, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                    seciliMasrafDetaylari.AddRange(masraf.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection);
                }
            }
            return seciliMasrafDetaylari;
        }

        public void gridMasrafAvans_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "ccbKOLAYKAYIT")
            {
                rfrmMuhasebeGiris frmMasrafKaydet = new rfrmMuhasebeGiris();
                //frmMasrafKaydet.MdiParent = null;
                frmMasrafKaydet.StartPosition = FormStartPosition.WindowsDefaultLocation;
                frmMasrafKaydet.KayitTamamlandi += frmMasrafKaydet_KayitTamamlandi;
                if (MyDavaFoy != null)
                    frmMasrafKaydet.Show(MyDavaFoy);
                else if (MyFoy != null)
                    frmMasrafKaydet.Show(MyFoy);
                else if (MyHazirlikFoy != null)
                    frmMasrafKaydet.Show(MyHazirlikFoy);

                frmMasrafKaydet.FormClosed += frmMasrafKaydet_FormClosed;
            }
            else if (e.Button.Tag.ToString() == "FormAc")
            {
                if (BelgeUtil.Inits.PaketAdi == 1)
                {
                    Forms.frmMasrafKayit frm = new AdimAdimDavaKaydi.Forms.frmMasrafKayit();
                    frm.FormClosed += frmMasrafKaydet_FormClosed;
                    if (MyFoy != null)
                    {
                        var proje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByICRA_FOY_IDFromAV001_TDIE_BIL_PROJE_ICRA_FOY(MyFoy.ID);
                        if (proje.Count > 0)
                            frm.Show(MyFoy, proje[0]);
                        else
                            frm.Show(MyFoy);
                    }
                    else if (MyDavaFoy != null)
                    {
                        var proje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByDAVA_FOY_IDFromAV001_TDIE_BIL_PROJE_DAVA_FOY(MyDavaFoy.ID);
                        if (proje.Count > 0)
                            frm.Show(MyDavaFoy, proje[0]);
                        else
                            frm.Show(MyDavaFoy);
                    }
                    else if (MyHazirlikFoy != null)
                    {
                        var proje = DataRepository.AV001_TDIE_BIL_PROJEProvider.GetByHAZIRLIK_IDFromAV001_TDIE_BIL_PROJE_HAZIRLIK(MyHazirlikFoy.ID);
                        if (proje.Count > 0)
                            frm.Show(MyHazirlikFoy, proje[0]);
                        else
                            frm.Show(MyHazirlikFoy);
                    }
                    else if (MySozlesmeFoy != null)
                        frm.Show(MySozlesmeFoy);
                }
                else
                {
                    IcraTakipForms.frmMasrafAvansKayitHizli frmMini = new AdimAdimDavaKaydi.IcraTakipForms.frmMasrafAvansKayitHizli();
                    frmMini.AcilisYeri = AdimAdimDavaKaydi.IcraTakipForms.MasrafFormuAcilisiYeri.TakipEkrani;

                    if (MyFoy != null)
                    {
                        frmMini.FormClosed += frmMasrafKaydet_FormClosed;
                        frmMini.Show(MyFoy);
                    }
                    else if (MyDavaFoy != null)
                    {
                        frmMini.FormClosed += frmMasrafKaydet_FormClosed;
                        frmMini.Show(MyDavaFoy);
                    }
                    else if (MyHazirlikFoy != null)
                    {
                        frmMini.FormClosed += frmMasrafKaydet_FormClosed;
                        frmMini.Show(MyHazirlikFoy);
                    }
                    else if (MySozlesmeFoy != null)
                    {
                        frmMini.FormClosed += frmMasrafKaydet_FormClosed;
                        frmMini.Show(MySozlesmeFoy);
                    }
                }
            }
            else if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                Forms.frmMasrafKayit frm = new AdimAdimDavaKaydi.Forms.frmMasrafKayit();
                frm.Masraf = gwMasrafAvans.GetFocusedRow() as AV001_TDI_BIL_MASRAF_AVANS;

                if (MyFoy != null) frm.Show(MyFoy);
                else if (MyDavaFoy != null) frm.Show(MyDavaFoy);
                else if (MyHazirlikFoy != null) frm.Show(MyHazirlikFoy);
                else if (MySozlesmeFoy != null) frm.Show(MySozlesmeFoy);
            }
        }

        private void BindData()
        {
            if (MyFoy != null)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                MyDataSource = MyFoy.AV001_TDI_BIL_MASRAF_AVANSCollection;
            }
            else if (MyDavaFoy != null)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyDavaFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                MyDataSource = MyDavaFoy.AV001_TDI_BIL_MASRAF_AVANSCollection;
            }
            else if (MyHazirlikFoy != null)
            {
                DataRepository.AV001_TD_BIL_HAZIRLIKProvider.DeepLoad(MyHazirlikFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                MyDataSource = MyHazirlikFoy.AV001_TDI_BIL_MASRAF_AVANSCollection;
            }
            else if (MySozlesmeFoy != null)
            {
                DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(MySozlesmeFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>));
                MyDataSource = MySozlesmeFoy.AV001_TDI_BIL_MASRAF_AVANSCollection;
            }

            SetMyDataSource(MyDataSource);
            gridMasrafAvans.DataSource = MyDataSource;
        }

        private void frmMasrafKaydet_FormClosed(object sender, FormClosedEventArgs e)
        {
            BindData();
        }

        private void frmMasrafKaydet_KayitTamamlandi(object sender, EventArgs e)
        {
            BindData();
        }

        private void gridMasrafAvans_ButtonEditorClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> detaylar = GetSelectedFoy((gridMasrafAvans.DataSource as TList<AV001_TDI_BIL_MASRAF_AVANS>));

            foreach (var item in detaylar)
            {
                if (item.BIRIM_FIYAT < 0)
                    item.BIRIM_FIYAT *= -1;
                if (item.TOPLAM_TUTAR < 0)
                    item.TOPLAM_TUTAR *= -1;
            }
            Editor.Degiskenler.Util.MasrafMakbuzu.MasrafMakbuzuGetir(detaylar);

            foreach (var item in detaylar)
            {
                if (item.BIRIM_FIYAT > 0 && item.BORC_ALACAK_ID == 2)
                    item.BIRIM_FIYAT *= -1;
                if (item.TOPLAM_TUTAR > 0 && item.BORC_ALACAK_ID == 2)
                    item.TOPLAM_TUTAR *= -1;
            }
        }

        private void gwMasrafAvans_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Tag == null) return;
            if ((int)e.Column.Tag == 1)
            {
                if (e.RowHandle < 0) return;
                var masraf = gwMasrafAvans.GetRow(e.RowHandle) as AV001_TDI_BIL_MASRAF_AVANS;
                e.DisplayText = MasrafToplami.FirstOrDefault(vi => vi.Key == masraf.ID).Value.ToString();
            }
        }

        private void SetMyDataSource(TList<AV001_TDI_BIL_MASRAF_AVANS> masrafList)
        {
            foreach (var item in masrafList)
            {
                if (MasrafToplami.FirstOrDefault(vi => vi.Key == item.ID).Key != 0 && MasrafToplami.FirstOrDefault(vi => vi.Key == item.ID).Value != 0) continue;
                var detayList = DataRepository.AV001_TDI_BIL_MASRAF_AVANS_DETAYProvider.GetByMASRAF_AVANS_ID(item.ID);
                if (detayList.Count > 0)
                    MasrafToplami.Add(item.ID, detayList.Sum(vi => vi.TOPLAM_TUTAR));
            }
        }

        private void ucMasraflar_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            try
            {
                gridMasrafAvans.ShowOnlyPredefinedDetails = true;

                BelgeUtil.Inits.perCariGetir(rlueCariPersonel);

                gridMasrafAvans.DataSource = MyDataSource;
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }
    }
}