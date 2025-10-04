using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdimAdimDavaKaydi.UserControls.IcraTakipUserControls;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.IcraTakipForms
{
    public partial class rFrmItiraz : Util.BaseClasses.AvpXtraForm
    {
        private TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> addNewList;
        private int cariId;
        private bool isModul;

        private AV001_TI_BIL_FOY myFoy;

        public rFrmItiraz()
        {
            InitializeComponent();
            InitializeEvents();
            this.Load += rFrmItiraz_Load;
            this.FormClosed += rFrmItiraz_FormClosed;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> AddNewList
        {
            get { return addNewList; }
            set
            {
                addNewList = value;

                if (value != null)
                {
                    if (MyFoy != null)
                    {
                        dataNavigatorExtended1.DataSource = AddNewList;
                        vGridControl1.DataSource = dataNavigatorExtended1.DataSource;
                        gcItýraz.DataSource = dataNavigatorExtended1.DataSource;
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsModul
        {
            get { return isModul; }
            set
            {
                isModul = value;
                panelControl1.Visible = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> ItirazAlacakNeden { get; set; }

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
                    BelgeUtil.Inits.AlacakNedenByFoy(MyFoy, grlueAlacakNeden);
                    BelgeUtil.Inits.OdemeBorcluTarafByFoy(MyFoy, new[] { rlueBorcluCari });

                    //AddNewList.AddNew();
                    TList<AV001_TI_BIL_FOY_TARAF> t =
                        AdimAdimDavaKaydi.IcraTakipForms.ucIcraTarafBilgileri.BorcluTaraflariGetir(MyFoy);
                    if (t.Count > 0)
                        cariId = Convert.ToInt32(t[0].CARI_ID);
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY_TARAF_GELISME MyGelisme { get; set; }

        public void Show(AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz)
        {
            TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> result = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
            result.Add(itiraz);

            LoadData(result);

            this.Show();
        }

        public void Show(AvukatProLib.Arama.per_TAKIP_ALACAK_NEDEN_ITIRAZ itirazView)
        {
            TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> result = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
            AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz = DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.GetByID(itirazView.ID);
            result.Add(itiraz);

            LoadData(result);

            this.Show();
        }

        public void Show(TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> itiraz)
        {
            if (itiraz == null || itiraz.Count == 0)
            {
                itiraz = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
                LoadData(itiraz);
                this.Show();
            }
            else
            {
                LoadData(itiraz);
                this.Show();
            }
        }

        public void Show(AV001_TI_BIL_FOY foy)
        {
            this.MyFoy = foy;
            TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> itiraz = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();
            LoadData(itiraz);
            this.Show();
        }

        private void addNew_ColumnChanged(object sender, AV001_TI_BIL_ITIRAZ_ALACAK_NEDENEventArgs e)
        {
            AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN itiraz = (AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN)sender;
            if (itiraz == null)
                return;

            if (e.Column == AV001_TI_BIL_ITIRAZ_ALACAK_NEDENColumn.BORCA_ITIRAZ_VARMI)
            {
                if (itiraz.BORCA_ITIRAZ_VARMI)
                {
                    AV001_TI_BIL_ALACAK_NEDEN alacakNedeni =
                        DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(itiraz.ALACAK_NEDEN_ID);
                    List<AV001_TI_BIL_FAIZ> faiz = null;

                    if (alacakNedeni != null)
                        faiz = DataRepository.AV001_TI_BIL_FAIZProvider.GetByICRA_ALACAK_NEDEN_ID(alacakNedeni.ID).Where(vi => vi.FAIZ_TAKIPDEN_ONCE_MI == 1).ToList();

                    decimal toplamFaiz = 0;

                    if (faiz != null)
                    {
                        foreach (var item in faiz)
                        {
                            toplamFaiz += item.FAIZ_TUTARI;
                        }
                    }

                    if (alacakNedeni != null)
                        itiraz.ANA_PARA_ITIRAZ_TUTARI = alacakNedeni.ISLEME_KONAN_TUTAR;
                    itiraz.FAIZE_ITIRAZ_TUTARI = toplamFaiz;
                }
                else
                {
                    itiraz.ANA_PARA_ITIRAZ_TUTARI = 0;
                    itiraz.FAIZE_ITIRAZ_TUTARI = 0;
                }
            }
        }

        private void AddNewList_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (MyFoy != null)
            {
                AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN addNew = e.NewObject as AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN;
                if (addNew == null)
                    addNew = new AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN();
                if (MyFoy.ADLI_BIRIM_ADLIYE_ID.HasValue)
                    addNew.ADLI_BIRIM_ADLIYE_ID = MyFoy.ADLI_BIRIM_ADLIYE_ID.Value;
                if (MyFoy.ADLI_BIRIM_GOREV_ID.HasValue)
                    addNew.ADLI_BIRIM_GOREV_ID = MyFoy.ADLI_BIRIM_GOREV_ID.Value;
                if (MyFoy.ADLI_BIRIM_NO_ID.HasValue)
                    addNew.ADLI_BIRIM_NO_ID = MyFoy.ADLI_BIRIM_NO_ID.Value;
                addNew.ICRA_FOY_ID = MyFoy.ID;
                addNew.ITIRAZ_EDEN_TARAF_ID = cariId;
                addNew.ITIRAZ_ESAS_NO = MyFoy.ESAS_NO;

                addNew.ColumnChanged += addNew_ColumnChanged;

                e.NewObject = addNew;
            }
        }

        private void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (gcItýraz.Visible)
            {
                gcItýraz.Visible = false;
                vGridControl1.Visible = true;
                gcItýraz.BringToFront();
            }
            else if (!gcItýraz.Visible)
            {
                vGridControl1.Visible = false;
                gcItýraz.Visible = true;
                vGridControl1.BringToFront();
            }
        }

        private void glueDosya_EditValueChanged(object sender, EventArgs e)
        {
            MyFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID((int)glueDosya.EditValue);
            AddNewList = MyFoy.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += rFrmItiraz_Button_Kaydet_Click;
        }

        private void LoadData(TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN> list)
        {
            if (AddNewList == null)
            {
                if (list == null)
                    list = new TList<AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN>();

                AddNewList = list;

                //AddNewList.AddNew();
                AddNewList.AddingNew += AddNewList_AddingNew;
            }

            if (MyFoy != null)
            {
                dataNavigatorExtended1.DataSource = AddNewList;
                vGridControl1.DataSource = dataNavigatorExtended1.DataSource;
                gcItýraz.DataSource = dataNavigatorExtended1.DataSource;
            }
            foreach (var item in list)
            {
                item.ColumnChanged += addNew_ColumnChanged;
            }
        }

        private void rFrmItiraz_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                XtraMessageBox.Show("Deðiþiklikler kaydedildi.", "Kaydet ve Çýk",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Deðiþiklikler Kayýt Edilemedi..", "UYARI",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void rFrmItiraz_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MyGelisme != null)
            {
                ucIcraTarafGelismeleri.ItirazTarihiHesapla(MyGelisme, MyFoy);
                ucIcraTarafGelismeleri.KesinlesmeTarihiHesapla(MyGelisme, MyFoy);
            }
        }

        private void rFrmItiraz_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                rlueItirazSonucu.NullText = "Seç";
                rLueMahkeme.NullText = "Seç";
                rLueGorev.NullText = "Seç";
                rLueBirimNo.NullText = "Seç";
                rlueDoviz.NullText = "Seç";
                rLueDovizId.NullText = "Seç";
                seTutar.NullText = "Seç";
                BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
                BelgeUtil.Inits.DovizTipGetir(rLueDovizId);
                BelgeUtil.Inits.ParaBicimiAyarla(seTutar);
                rlueItirazSonucu.Enter += delegate { BelgeUtil.Inits.ItirazSonucuGetir(rlueItirazSonucu); };
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueMahkeme); //Takipten bilgi geldiði için lookup dolu getirilmeli.
                BelgeUtil.Inits.AdliBirimGorevGetir(rLueGorev);//Takipten bilgi geldiði için lookup dolu getirilmeli.
                BelgeUtil.Inits.AdliBirimNoGetir(rLueBirimNo); //Takipten bilgi geldiði için lookup dolu getirilmeli.
            }
            if (isModul)
            {
                glueDosya.Enter += delegate { glueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur("Icra"); };
                glueDosya.Properties.DisplayMember = "FOY_NO";
                glueDosya.Properties.ValueMember = "ID";
                glueDosya.Properties.NullText = "Dosya seçiniz...";
            }
        }

        private bool Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                int index = -1;
                if (MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                for (int i = 0; i < AddNewList.Count; i++)
                {
                    index = MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection.FindIndex(delegate
                    {
                        AddNewList[i].ICRA_FOY_ID = MyFoy.ID;
                        AddNewList[i].ALACAK_NEDEN_ID = AddNewList[i].ALACAK_NEDEN_ID;
                        return (AddNewList[i].ALACAK_NEDEN_ID == AddNewList[i].ALACAK_NEDEN_ID);
                    });

                    MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection[index].AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection.Add(AddNewList[i]);
                }
                foreach (AV001_TI_BIL_ALACAK_NEDEN neden in MyFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    DataRepository.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENProvider.Save(trans, neden.AV001_TI_BIL_ITIRAZ_ALACAK_NEDENCollection);
                }
                trans.Commit();
                ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);

                return false;
            }
            return true;
        }
    }
}