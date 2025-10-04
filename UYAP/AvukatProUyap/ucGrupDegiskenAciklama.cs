using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Editor.UserControls
{
    public class DegiskenAciklama
    {
        private TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN _degisken;

        private TIE_KOD_ALACAK_NEDEN_GRUP _grup;

        private TList<TI_KOD_ALACAK_NEDEN> AlacakNedenleri;

        public string Aciklama
        {
            get { return Degisken.ACIKLAMA; }
            set { Degisken.ACIKLAMA = value; }
        }

        public bool AlacakNedeniVeyaIle
        {
            get { return Grup.VEYA_ILE_MI_BAGLI.Value; }
            set { Grup.VEYA_ILE_MI_BAGLI = value; }
        }

        public TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN Degisken
        {
            get { return _degisken; }
            set { _degisken = value; }
        }

        public int DOVIZ_ISLEM_TIPI
        {
            get { return Degisken.DOVIZ_ISLEM_TIPI_ID.Value; }
            set { Degisken.DOVIZ_ISLEM_TIPI_ID = value; }
        }

        public bool DovizliMi
        {
            get { return Grup.DOVIZLI_MI.Value; }
            set { Grup.DOVIZLI_MI = value; }
        }

        public bool FAIZ_YOK_MU
        {
            get { return Degisken.FAIZ_YOK_MU.Value; }
            set { Degisken.FAIZ_YOK_MU = value; }
        }

        public int Form_Tipi
        {
            get { return Degisken.FORM_TIPI.Value; }
            set { Degisken.FORM_TIPI = value; }
        }

        public TIE_KOD_ALACAK_NEDEN_GRUP Grup
        {
            get { return _grup; }
            set { _grup = value; }
        }

        // private TList<TI_KOD_ALACAK_NEDEN> _kodAlacakNedenler = new TList<TI_KOD_ALACAK_NEDEN>();
        public TList<TI_KOD_ALACAK_NEDEN> KodAlacakNedenler
        {
            get
            {
                //  TList<TI_KOD_ALACAK_NEDEN> alacakNedenleri = new TList<TI_KOD_ALACAK_NEDEN>();
                //TList<TIE_KOD_ALACAK_NEDEN_GRUP> Grublar=AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.Find(string.Format("GRUP_NO='{0}'",Grup.GRUP_NO));
                //for (int i = 0; i < Grublar.Count; i++)
                //{
                //    alacakNedenleri.Add(Grublar[i].ALACAK_NEDEN_IDSource);
                //}

                return AlacakNedenleri;
            }
            set
            {
                this.AlacakNedenleri = value;
            }
        }

        public bool YtlLiMi
        {
            get { return Grup.YTL_MI.Value; }
            set { Grup.YTL_MI = value; }
        }
    }

    public class GrupAciklama
    {
        private int _DOVIZ_ISLEM_TIPI;

        private bool _dovizliMi;

        private List<TDI_KOD_DOVIZ_TIP> _DovizSource;

        private bool _FAIZ_YOK_MU;

        private int _Form_Tipi;

        private TList<TI_KOD_ALACAK_NEDEN> _kodAlacakNedenler = new TList<TI_KOD_ALACAK_NEDEN>();

        private bool _ytlLiMi;

        private decimal sozlesmeToplami = decimal.Zero;

        private TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> TumDegiskenler = null;

        public int DOVIZ_ISLEM_TIPI
        {
            get { return _DOVIZ_ISLEM_TIPI; }
            set { _DOVIZ_ISLEM_TIPI = value; }
        }

        public bool DovizliMi
        {
            get { return _dovizliMi; }
            set { _dovizliMi = value; }
        }

        public List<TDI_KOD_DOVIZ_TIP> DovizSource
        {
            get
            {
                if (_DovizSource == null)
                    _DovizSource = new List<TDI_KOD_DOVIZ_TIP>(DataRepository.TDI_KOD_DOVIZ_TIPProvider.GetAll());
                return _DovizSource;
            }
        }

        public bool FAIZ_YOK_MU
        {
            get { return _FAIZ_YOK_MU; }
            set { _FAIZ_YOK_MU = value; }
        }

        public int Form_Tipi
        {
            get { return _Form_Tipi; }
            set { _Form_Tipi = value; }
        }

        public TList<TI_KOD_ALACAK_NEDEN> KodAlacakNedenler
        {
            get { return _kodAlacakNedenler; }
            set { _kodAlacakNedenler = value; }
        }

        public bool YtlLiMi
        {
            get { return _ytlLiMi; }
            set { _ytlLiMi = value; }
        }

        public void AciklamayiSonHalineGetir(TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN degisken, AV001_TI_BIL_FOY myfoy)
        {
            ///ipotekli acýuklama için acýklama sonuna ipotekli acýklama eklenerek yapýlmýþtý. Sonra acýklama onune eklendi.
            ///
            //if (myfoy.TAKIP_CIKISI>sozlesmeToplami)
            //{
            //    degisken.ACIKLAMA += GetIpotekliAciklama(myfoy);

            //}
            //else
            //{
            //    degisken.ACIKLAMA =  GetIpotekliAciklama(myfoy) + degisken.ACIKLAMA;
            //}
        }
        
        /// <summary>
        /// foy içerisindeki alacaknedenleri ve form tipine gore gruplarý getiriri.
        /// </summary>
        /// <param name="AlacakNeden"></param>
        /// <param name="formTipi"></param>
        /// <param name="myfoy"></param>
        /// <returns></returns>
        public TList<TIE_KOD_ALACAK_NEDEN_GRUP> GetGroupByAlacakNeden(AV001_TI_BIL_FOY myfoy)
        {
            TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstAlacakNedenGrup = new TList<TIE_KOD_ALACAK_NEDEN_GRUP>();

            //SqlConnection con = new SqlConnection("server=192.9.0.199; database=AVP_NHA_NG; uid=ersin; pwd=123");
            for (int i = 0; i < KodAlacakNedenler.Count; i++)
            {
                lstAlacakNedenGrup.AddRange(AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.GetByALACAK_NEDEN_ID(KodAlacakNedenler[i].ID));

                // using (SqlCommand cmd = new SqlCommand("select * from TIE_KOD_ALACAK_NEDEN_GRUP
                // where ALACAK_NEDEN_ID = " + .ToString(), con)) { con.Open(); SqlDataReader dr =
                // cmd.ExecuteReader(CommandBehavior.CloseConnection); while (dr.Read()) {
                // TIE_KOD_ALACAK_NEDEN_GRUP ag = new TIE_KOD_ALACAK_NEDEN_GRUP(); ag.ID =
                // Convert.ToInt32(dr["ID"]); ag.ALACAK_NEDEN_ID =
                // Convert.ToInt32(dr["ALACAK_NEDEN_ID"]); ag.DOVIZLI_MI =
                // Convert.ToBoolean(dr["DOVIZLI_MI"]); ag.FAIZ_YOK_MU =
                // Convert.ToBoolean((dr["FAIZ_YOK_MU"] == DBNull.Value ? false :
                // dr["FAIZ_YOK_MU"])); ag.FORM_TIPI_ID = Convert.ToInt32(dr["FORM_TIPI_ID"]);
                // ag.GRUP_NO = Convert.ToInt32(dr["GRUP_NO"]); ag.VEYA_ILE_MI_BAGLI =
                // Convert.ToBoolean(dr["VEYA_ILE_MI_BAGLI"]); ag.YTL_MI =
                // Convert.ToBoolean(dr["YTL_MI"]);

                // ag.DOVIZ_ISLEM_TIPI_ID = Convert.ToInt32((dr["DOVIZ_ISLEM_TIPI_ID"] ==
                // DBNull.Value ? false : dr["DOVIZ_ISLEM_TIPI_ID"])); lstAlacakNedenGrup.Add(ag);

                // } dr.Close();

                // }
            }

            // lstAlacakNedenGrup.Add(AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.GetByID(2855));

            // TList<TIE_KOD_ALACAK_NEDEN_GRUP> returnValues = new
            // TList<TIE_KOD_ALACAK_NEDEN_GRUP>();

            //TList<TI_KOD_ALACAK_NEDEN> lstAlacakNedens = GetAlacakNedens(myfoy);

            //filterAlacakNedens(lstAlacakNedenGrup, KodAlacakNedenler);
            TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstGroups = new TList<TIE_KOD_ALACAK_NEDEN_GRUP>();
            TList<TIE_KOD_ALACAK_NEDEN_GRUP> Gruplar = new TList<TIE_KOD_ALACAK_NEDEN_GRUP>();
            bool veli = false;
            for (int i = 0; i < myfoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
            {
                AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i], false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TI_KOD_DOVIZ_HESAPLAMA_TIPI));

                for (int y = 0; y < lstAlacakNedenGrup.Count; y++)
                {
                    TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstGroupPs = new TList<TIE_KOD_ALACAK_NEDEN_GRUP>();
                    lstGroupPs = AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.Find("GRUP_NO='" + lstAlacakNedenGrup[y].GRUP_NO + "'");
                    if (lstGroupPs.Count > 1 && lstAlacakNedenGrup[y].VEYA_ILE_MI_BAGLI.Value == false)
                    {
                        // TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstGroupp=
                        // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.Find("GRUP_NO='"
                        // + lstAlacakNedenGrup[y].GRUP_NO + "'"); for (int d = 0; d
                        // < lstGroupp.Count; d++) { if (lstGroupp[d].ALACAK_NEDEN_ID ==
                        // KodAlacakNedenler) { } }
                        veli = true;
                    }

                    if (ValidateGrup(lstAlacakNedenGrup[y], myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].HESAPLAMA_MODU, myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].FAIZ_YOK, myfoy.FORM_TIP_ID.Value, (myfoy.ASIL_ALACAK_DOVIZ_ID.Value == 1 ? false : true)))
                    {
                        lstGroups.Add(lstAlacakNedenGrup[y]);

                        // Gruplar.Add(lstAlacakNedenGrup[y]);
                    }
                }
            }

            if (lstGroups.Count == 0)
            {
                TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstfindedGroups = AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.Find("GRUP_NO='3001'");
                if (lstfindedGroups.Count > 0)
                {
                    lstGroups.Add(lstfindedGroups[0]);
                }
            }
            if (veli)
            {
                int sayac = 0;
                for (int g = 0; g < lstGroups.Count; g++)
                {
                    for (int k = 0; k < KodAlacakNedenler.Count; k++)
                    {
                        if (lstGroups[g].ALACAK_NEDEN_ID == KodAlacakNedenler[k].ID)
                        {
                            sayac++;
                        }
                    }
                    if (sayac == KodAlacakNedenler.Count)
                    {
                        Gruplar.Add(lstGroups[g]);
                    }
                }
            }
            else
            {
                Gruplar.AddRange(lstGroups);
            }

            return Gruplar;
        }

        private TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> getGrupDegiskenByKOD_ALACAK_NEDEN_GRUP_ID(int grupNo)
        {
            if (TumDegiskenler == null)
            {
                TumDegiskenler = AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKENProvider.GetAll();
            }
            TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> returnValues = new TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>();
            for (int i = 0; i < TumDegiskenler.Count; i++)
            {
                if (TumDegiskenler[i].KOD_ALACAK_NEDEN_GRUP_ID.HasValue)
                {
                    if (TumDegiskenler[i].KOD_ALACAK_NEDEN_GRUP_ID.Value == grupNo)
                    {
                        returnValues.Add(TumDegiskenler[i]);
                    }
                }
            }
            return returnValues;
        }

        /// <summary>
        /// Foy içerisindeki tum alanak neden kodlarýný bulur .
        /// </summary>
        /// <param name="myfoy"></param>
        /// <returns></returns>
        private void SetFields(AV001_TI_BIL_FOY myfoy)
        {
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myfoy, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(myfoy.AV001_TI_BIL_ALACAK_NEDENCollection, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));
            for (int i = 0; i < myfoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
            {
                _kodAlacakNedenler.Add(myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_IDSource);

                if (!myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].FAIZ_YOK)
                {
                    this.FAIZ_YOK_MU = myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].FAIZ_YOK;
                }
            }
        }

        private bool ValidateGrup(TIE_KOD_ALACAK_NEDEN_GRUP grp, int hesaplamaModu, bool faiz, int ftip, bool dovizli)
        {
            bool ytl = !dovizli;
            if (grp.FAIZ_YOK_MU == null)
            {
                grp.FAIZ_YOK_MU = false;
            }
            if (grp.FORM_TIPI_ID == ftip && grp.DOVIZ_ISLEM_TIPI_ID == hesaplamaModu && grp.FAIZ_YOK_MU == faiz && (grp.YTL_MI == ytl && grp.DOVIZLI_MI == dovizli || (grp.YTL_MI == true && grp.DOVIZLI_MI == true)))
            {
                return true;
            }
            return false;
        }
    }

    public partial class ucGrupDegiskenAciklama : XtraUserControl
    {
        public ucGrupDegiskenAciklama()
        {
            InitializeComponent();
        }

        private AV001_TI_BIL_FOY _myFoy;

        public delegate void OnButtonClick(object sender, AV001_TI_BIL_FOY myFoy);

        public event OnButtonClick TamamButton;

        public event OnButtonClick VazgecButton;
        
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.labelControl1.Text = string.Format("{0} / {1}", this.bindingSource1.Position, this.bindingSource1.Count);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.VazgecButton != null)
            {
                this.VazgecButton(this, _myFoy);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.TamamButton != null)
            {
                this.TamamButton(this, _myFoy);
            }

            if (this.bindingSource1.DataSource is BindingList<DegiskenAciklama>)
            {
                BindingList<DegiskenAciklama> degiskenAciklamalarý = (BindingList<DegiskenAciklama>)this.bindingSource1.DataSource;
                for (int i = 0; i < degiskenAciklamalarý.Count; i++)
                {
                    AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.Save(degiskenAciklamalarý[i].Grup);
                    AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKENProvider.Save(degiskenAciklamalarý[i].Degisken);
                }
            }
        }

        private void ucGrupDegiskenAciklama_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            //LOAD
            //rLueTakipTalepKodu
            //Inits.TakipTalepleriResimliGetir(repositoryItemImageComboBox1);
            //Inits.AlacakNedenKodGetir(rLuealacakNedenGetir);
            //Inits.FormTipiGetir(lueFormTipi);
            //Inits.IcraDovizIslemTipiGetir(lueDovizIslemTipi);

            //
        }

        //        public void Load(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
        //        {
        //// TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN yazi = new TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN();
          ////            yazi.ACIKLAMA="Bu alan için Bir Deðer Bulunamadý ... ";

        //// decimal harcaEsasDeger = decimal.MinValue; decimal DovizTakipCikisi = decimal.MinValue;

        //// double vorn = 0; bool kdvsiVarmi = false; bool oivsiVarmi = false;

        //// DateTime tata = foyum.TAKIP_TARIHI.Value; int ftid = 0; int dtip = 0;
        //// AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, true,
        //// DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
        //// TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenler =
        //// foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
        //// TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP> lstGruplar =
        //// AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.GetAll();

        //// TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>
        //// kritereGoreAlacakNedenler = new TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>(); bool
        //// Dovizlimi = false; bool YtlLiMi = false; bool takipTarihinde = false; for (int i = 0; i
        //// < AlacakNedenler.Count; i++) { if (AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value
        //// == 2) { Dovizlimi = true; } if (AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value ==
        //// 1) { YtlLiMi = true; }

        //// } if (foyum.HESAPLAMA_TIPI == 1) { takipTarihinde = true; } if (foyum.HESAPLAMA_TIPI ==
        //// 2) { takipTarihinde = false; } int hesapTipi = 3; if (Dovizlimi) { hesapTipi = 1;

        //// }

        //// if (YtlLiMi) { hesapTipi = 2; } if (Dovizlimi && YtlLiMi) { hesapTipi = 3;

        //// }

        //// for (int i = 0; i < AlacakNedenler.Count; i++) { if
        //// (AlacakNedenler[i].ALACAK_NEDEN_KOD_ID.HasValue) { harcaEsasDeger =
        //// AlacakNedenler[i].HARCA_ESAS_DEGER;

        //// AvukatProLib2.Entities.TI_KOD_ALACAK_NEDEN kodAlancakNeden = AvukatProLib2.Data.DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(AlacakNedenler[i].ALACAK_NEDEN_KOD_ID.Value);

        //// kritereGoreAlacakNedenler.AddRange( GetGroupByAlacakNeden(kodAlancakNeden, hesapTipi, Convert.ToInt32(AvukatProLib2.Data.DataRepository.TI_KOD_FORM_TIPProvider.GetByID(foyum.FORM_TIP_ID.Value).FORM_ORNEK_NO),
        //// AlacakNedenler[i].HESAPLAMA_MODU, AlacakNedenler[i].FAIZ_YOK )); lstGruplar =
        //// FindAlacaknedenGroup(lstGruplar, kodAlancakNeden);

        //// if (AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_ID != null) { ftid =
        //// AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_ID.Value; }

        //// dtip = AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;

        //// if (kdvsiVarmi) { vorn =
        //// FaizHelper.KDVOraniGetir(Convert.ToInt32(AlacakNedenler[i].KDV_TIP_ID.Value), tata); }
        //// if (oivsiVarmi) { if (AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.GetByFAIZ_TIP_IDTARIFE_GECERLILIK_BASLANGIC_TARIHIDOVIZ_TIP_ID(ftid,
        //// tata, dtip) != null) { vorn = AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.GetByFAIZ_TIP_IDTARIFE_GECERLILIK_BASLANGIC_TARIHIDOVIZ_TIP_ID(ftid,
        //// tata, dtip).TARIFE_TUTARI; } } } }

        //// if (lstGruplar.Count != 0 && kritereGoreAlacakNedenler.Count != 0) { yazi =
        //// GetAciklamaByGrupInAlacakNedenDegiskenList(kritereGoreAlacakNedenler, lstGruplar);
        //// memoEdit4.Text = yazi.ACIKLAMA; if (yazi!=null) { //yazi.ACIKLAMA = Replace("YFM",
        //// yazi.ACIKLAMA,FaizHelper.FaizOraniGetir(ftid, dtip, tata).ToString()); double yafm =
        //// FaizHelper.FaizOraniGetir(ftid, dtip, tata); if (yafm!=0) { yazi.ACIKLAMA =
        //// Replace("YFM", yazi.ACIKLAMA, yafm); } else { yazi.ACIKLAMA = Replace("YFM,",
        //// yazi.ACIKLAMA, ""); yazi.ACIKLAMA = Replace("YFM", yazi.ACIKLAMA, "");

        //// }

        ////                    if (vorn!=0)
        ////                    {
        ////yazi.ACIKLAMA = Replace("&VERGIORN&", yazi.ACIKLAMA, vorn);
        ////                    }
        ////                    else
        ////                    {
        ////                        yazi.ACIKLAMA = Replace("&VERGIORN&,", yazi.ACIKLAMA, "");
        ////                        yazi.ACIKLAMA = Replace("&VERGIORN&", yazi.ACIKLAMA, "");
        ////                    }

        //// yazi.ACIKLAMA = Replace("&GDK&", yazi.ACIKLAMA, foyum.TAKIP_CIKISI_DOVIZ_ID);
        //// yazi.ACIKLAMA = Replace("ASIL ALACAK", yazi.ACIKLAMA, foyum.ASIL_ALACAK.ToString());
        //// decimal DovizKuru = DovizHelper.CevirYTL(1, foyum.ASIL_ALACAK_DOVIZ_ID,
        //// foyum.TAKIP_TARIHI.Value); yazi.ACIKLAMA = Replace("DÖVÝZ KURU", yazi.ACIKLAMA,
        //// DovizKuru.ToString()); yazi.ACIKLAMA = Replace("HARCA ESAS DEÐER", yazi.ACIKLAMA,
        //// harcaEsasDeger.ToString()); //yazi= Replace("&DTC&",yazi,); if (foyum.TAKIP_CIKISI!=0)
        //// { yazi.ACIKLAMA = Replace("&ATK&", yazi.ACIKLAMA, foyum.TAKIP_CIKISI); } else {
        //// yazi.ACIKLAMA = Replace("&ATK&,", yazi.ACIKLAMA, ""); yazi.ACIKLAMA = Replace("&ATK&",
        //// yazi.ACIKLAMA, ""); }

        //// //yazi=Replace("&KUVTURKYTLACK&",yazi," //yazi=Replace("&SOZLESMEMIK&",yazi,);
        //// yazi.ACIKLAMA = Replace("&ILAMACIK&", yazi.ACIKLAMA, foyum);

        ////                    double faizOrani =  FaizHelper.FaizOraniGetir(ftid, dtip, tata);
        ////                    if (faizOrani!=0)
        ////                    {
        ////   yazi.ACIKLAMA = Replace("&FO&", yazi.ACIKLAMA,faizOrani);
        ////                    }
        ////                    else
        ////                    {
        ////                        yazi.ACIKLAMA = Replace("&FO&,", yazi.ACIKLAMA, "");
        ////                        yazi.ACIKLAMA = Replace("&FO&", yazi.ACIKLAMA, "");
        ////                    }
        ////                    if (foyum.KDV_TO!=0)
        ////                    {
        ////yazi.ACIKLAMA = Replace("&KDV&", yazi.ACIKLAMA, foyum.KDV_TO);
        ////                    }
        ////                    else
        ////                    {
        ////                        yazi.ACIKLAMA = Replace("&KDV&,", yazi.ACIKLAMA, "");
        ////                        yazi.ACIKLAMA = Replace("&KDV&", yazi.ACIKLAMA, "");
        ////                    }
        //                 GrupAciklama ga = new GrupAciklama();
        //             TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN yazi =   ga.GetVar(foyum);

        // if (yazi.ID==0) { }

        // memoEdit2.Text = yazi.ACIKLAMA; memoEdit3.Text = yazi.DOVIZ_TIPI; memoEdit1.Text =
        // yazi.GRUPLAR; lblalacakNedeni.Text = AvukatProLib2.Data.DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(yazi.KOD_ALACAK_NEDEN_GRUP_ID.Value).ALACAK_NEDENI;
        // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKENProvider.DeepLoad(yazi,false,
        // DeepLoadType.IncludeChildren,typeof(TI_KOD_DOVIZ_ISLEM_TIPI)); lblDovizislemTipi.Text =
        // yazi.DOVIZ_ISLEM_TIPI_IDSource.KOD; lblHesapLamaTipi.Text = ((AvukatProLib.Extras.IcraDovizIslemTipi)Enum.ToObject(typeof(AvukatProLib.Extras.IcraDovizIslemTipi),
        // yazi.DOVIZ_HESAPLAMA_TIPI_ID.Value)).ToString();

        // }

        // string Replace(string var, string data, object newValue) { if (data.Contains(var)) {
        // return data.Replace(var, newValue.ToString()); } return data; }

        // private static TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN
        // GetAciklamaByGrupInAlacakNedenDegiskenList(
        // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> lstAlacakNedenler,
        // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP> grup) {
        // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> rv = new
        // TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>(); for (int i = 0; i
        // < lstAlacakNedenler.Count; i++) { for (int y = 0; y < grup.Count; y++) { if
        // (lstAlacakNedenler[i].KOD_ALACAK_NEDEN_GRUP_ID.Value == grup[y].GRUP_NO) {
        // rv.Add(lstAlacakNedenler[i]);

        // } } } if (rv.Count == 0) { return null; }

        // return rv[0]; }

        // static TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>
        // GetGroupByAlacakNeden(AvukatProLib2.Entities.TI_KOD_ALACAK_NEDEN alacakNedeni, int
        // dovizIslemTipi, int formTipi, int dovizHesapTipi, bool faizYokmu) { if (dovizIslemTipi ==
        // 0) { dovizIslemTipi = 1;

        // } if (dovizHesapTipi == 0) { dovizHesapTipi = 1; }
        // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> returnValue = new
        // TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>();
        // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> lstAlacakNedenler =
        // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKENProvider.GetAll();
        // for (int i = 0; i < lstAlacakNedenler.Count; i++) { for (int y = 0; y
        // < returnValue.Count; y++) { if (returnValue[y].ID == lstAlacakNedenler[i].ID) { break; }
        // } if (lstAlacakNedenler[i].FORM_TIPI.Value == formTipi &&
        // lstAlacakNedenler[i].DOVIZ_HESAPLAMA_TIPI_ID.Value == dovizHesapTipi &&
        // lstAlacakNedenler[i].FAIZ_YOK_MU == faizYokmu &&
        // lstAlacakNedenler[i].DOVIZ_ISLEM_TIPI_ID.Value == dovizIslemTipi ||
        // lstAlacakNedenler[i].DOVIZ_ISLEM_TIPI_ID.Value == 3) {
        // returnValue.Add(lstAlacakNedenler[i]); }

        // } return returnValue; }

        // static TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP>
        // FindAlacaknedenGroup(TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP> lstGrroup,
        // AvukatProLib2.Entities.TI_KOD_ALACAK_NEDEN alacakNedeni) {
        // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP> returnValue = new
        // TList<TIE_KOD_ALACAK_NEDEN_GRUP>(); for (int i = 0; i < lstGrroup.Count; i++) { if
        // (lstGrroup[i].ALACAK_NEDEN_ID == alacakNedeni.ID) { returnValue.Add(lstGrroup[i]); } }
        // return returnValue; }

        // private void simpleButton1_Click(object sender, EventArgs e) { this.Visible = false; }

        // private void lblDovizislemTipi_Click(object sender, EventArgs e) { }

        // public void LoadControls() { Inits.FormTipiGetir(lookUpEdit1);
        // Inits.IcraDovizIslemTipiGetir(comboBoxEdit1);

        // }

        // public void LoadDatas(AV001_TI_BIL_FOY myFoy) { LoadControls();
        // TList<TI_KOD_ALACAK_NEDEN> lstAlacakNeden = new TList<TI_KOD_ALACAK_NEDEN>();

        // bool Dovizli = false; bool Ytli = false; bool Faiz = false; bool Veya = false;
        //int dovizIslemTipi  = 0;
        //            int FormTipi =1;
        //            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy,false, DeepLoadType.IncludeChildren,typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
        //            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection,false, DeepLoadType.IncludeChildren,typeof(TI_KOD_ALACAK_NEDEN));
        //            for (int i = 0; i < myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
        //            {
        //             lstAlacakNeden.Add(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_IDSource);
        //               Dovizli= (myFoy.ASIL_ALACAK_DOVIZ_ID.Value == 1 ? false : true);
        //                Ytli = (myFoy.ASIL_ALACAK_DOVIZ_ID.Value != 1 ? false : true);
        //                Faiz = myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].FAIZ_YOK;
        //               dovizIslemTipi = myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].HESAPLAMA_MODU;

        // }

        // TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstGroups =
        // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.GetAll(); for (int i
        // = 0; i < lstGroups.Count; i++) { if (lstGroups[i].GRUP_NO>maxGrupNo) { maxGrupNo =
        // lstGroups[i].GRUP_NO; } }

        // maxGrupNo++;

        // this.gridControl1.DataSource = lstAlacakNeden;

        // checkEdit1.Checked = Dovizli; checkEdit2.Checked = Ytli; checkEdit3.Checked = Faiz;
        // checkEdit4.Checked = Veya;

        // this.memoEdit5.Text = "";

        // this.lookUpEdit1.EditValue = FormTipi; this.comboBoxEdit1.SelectedIndex = dovizIslemTipi;
        // }

        // int maxGrupNo = 0;

        // private void simpleButton2_Click(object sender, EventArgs e) {
        // TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstGroups = new TList<TIE_KOD_ALACAK_NEDEN_GRUP>(); for
        // (int i = 0; i < gridView1.RowCount; i++) { TIE_KOD_ALACAK_NEDEN_GRUP grp = new
        // TIE_KOD_ALACAK_NEDEN_GRUP(); grp.ALACAK_NEDEN_ID =
        // ((TI_KOD_ALACAK_NEDEN)gridView1.GetRow(i)).ID; grp.DOVIZ_ISLEM_TIPI_ID =
        // Convert.ToInt32(this.comboBoxEdit1.SelectedIndex); grp.FORM_TIPI_ID =
        // Convert.ToInt32(this.lookUpEdit1.EditValue); grp.VEYA_ILE_MI_BAGLI = checkEdit4.Checked;
        // grp.YTL_MI = checkEdit2.Checked; grp.DOVIZLI_MI = checkEdit1.Checked; grp.FAIZ_YOK_MU =
        // checkEdit3.Checked; grp.GRUP_NO = maxGrupNo; lstGroups.Add(grp); }

        // TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN degisken = new TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN();
        // degisken.ACIKLAMA = this.memoEdit5.Text; degisken.KOD_ALACAK_NEDEN_GRUP_ID = maxGrupNo;
        // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.Save(lstGroups);
        // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKENProvider.Save(degisken);
        // }
    }

    // public partial class ucGrupDegiskenAciklama : XtraUserControl { public
    // ucGrupDegiskenAciklama() { InitializeComponent(); }

    //        public void Load(AvukatProLib2.Entities.AV001_TI_BIL_FOY foyum)
    //        {
    //// TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN yazi = new TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN();
      ////            yazi.ACIKLAMA="Bu alan için Bir Deðer Bulunamadý ... ";

    //// decimal harcaEsasDeger = decimal.MinValue; decimal DovizTakipCikisi = decimal.MinValue;

    //// double vorn = 0; bool kdvsiVarmi = false; bool oivsiVarmi = false;

    //// DateTime tata = foyum.TAKIP_TARIHI.Value; int ftid = 0; int dtip = 0;
    //// AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foyum, true,
    //// DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
    //// TList<AvukatProLib2.Entities.AV001_TI_BIL_ALACAK_NEDEN> AlacakNedenler =
    //// foyum.AV001_TI_BIL_ALACAK_NEDENCollection;
    //// TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP> lstGruplar =
    //// AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.GetAll();

    //// TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> kritereGoreAlacakNedenler
    //// = new TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>(); bool Dovizlimi = false; bool YtlLiMi =
    //// false; bool takipTarihinde = false; for (int i = 0; i < AlacakNedenler.Count; i++) { if
    //// (AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value == 2) { Dovizlimi = true; } if
    //// (AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value == 1) { YtlLiMi = true; }

    //// } if (foyum.HESAPLAMA_TIPI == 1) { takipTarihinde = true; } if (foyum.HESAPLAMA_TIPI == 2)
    //// { takipTarihinde = false; } int hesapTipi = 3; if (Dovizlimi) { hesapTipi = 1;

    //// }

    //// if (YtlLiMi) { hesapTipi = 2; } if (Dovizlimi && YtlLiMi) { hesapTipi = 3;

    //// }

    //// for (int i = 0; i < AlacakNedenler.Count; i++) { if
    //// (AlacakNedenler[i].ALACAK_NEDEN_KOD_ID.HasValue) { harcaEsasDeger =
    //// AlacakNedenler[i].HARCA_ESAS_DEGER;

    //// AvukatProLib2.Entities.TI_KOD_ALACAK_NEDEN kodAlancakNeden = AvukatProLib2.Data.DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(AlacakNedenler[i].ALACAK_NEDEN_KOD_ID.Value);

    //// kritereGoreAlacakNedenler.AddRange( GetGroupByAlacakNeden(kodAlancakNeden, hesapTipi, Convert.ToInt32(AvukatProLib2.Data.DataRepository.TI_KOD_FORM_TIPProvider.GetByID(foyum.FORM_TIP_ID.Value).FORM_ORNEK_NO),
    //// AlacakNedenler[i].HESAPLAMA_MODU, AlacakNedenler[i].FAIZ_YOK )); lstGruplar =
    //// FindAlacaknedenGroup(lstGruplar, kodAlancakNeden);

    //// if (AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_ID != null) { ftid =
    //// AlacakNedenler[i].TO_ALACAK_FAIZ_TIP_ID.Value; }

    //// dtip = AlacakNedenler[i].ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;

    //// if (kdvsiVarmi) { vorn =
    //// FaizHelper.KDVOraniGetir(Convert.ToInt32(AlacakNedenler[i].KDV_TIP_ID.Value), tata); } if
    //// (oivsiVarmi) { if (AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.GetByFAIZ_TIP_IDTARIFE_GECERLILIK_BASLANGIC_TARIHIDOVIZ_TIP_ID(ftid,
    //// tata, dtip) != null) { vorn = AvukatProLib2.Data.DataRepository.TDI_CET_FAIZ_TARIFEProvider.GetByFAIZ_TIP_IDTARIFE_GECERLILIK_BASLANGIC_TARIHIDOVIZ_TIP_ID(ftid,
    //// tata, dtip).TARIFE_TUTARI; } } } }

    //// if (lstGruplar.Count != 0 && kritereGoreAlacakNedenler.Count != 0) { yazi =
    //// GetAciklamaByGrupInAlacakNedenDegiskenList(kritereGoreAlacakNedenler, lstGruplar);
    //// memoEdit4.Text = yazi.ACIKLAMA; if (yazi!=null) { //yazi.ACIKLAMA = Replace("YFM",
    //// yazi.ACIKLAMA,FaizHelper.FaizOraniGetir(ftid, dtip, tata).ToString()); double yafm =
    //// FaizHelper.FaizOraniGetir(ftid, dtip, tata); if (yafm!=0) { yazi.ACIKLAMA = Replace("YFM",
    //// yazi.ACIKLAMA, yafm); } else { yazi.ACIKLAMA = Replace("YFM,", yazi.ACIKLAMA, "");
    //// yazi.ACIKLAMA = Replace("YFM", yazi.ACIKLAMA, "");

    //// }

    ////                    if (vorn!=0)
    ////                    {
    ////yazi.ACIKLAMA = Replace("&VERGIORN&", yazi.ACIKLAMA, vorn);
    ////                    }
    ////                    else
    ////                    {
    ////                        yazi.ACIKLAMA = Replace("&VERGIORN&,", yazi.ACIKLAMA, "");
    ////                        yazi.ACIKLAMA = Replace("&VERGIORN&", yazi.ACIKLAMA, "");
    ////                    }

    //// yazi.ACIKLAMA = Replace("&GDK&", yazi.ACIKLAMA, foyum.TAKIP_CIKISI_DOVIZ_ID); yazi.ACIKLAMA
    //// = Replace("ASIL ALACAK", yazi.ACIKLAMA, foyum.ASIL_ALACAK.ToString()); decimal DovizKuru =
    //// DovizHelper.CevirYTL(1, foyum.ASIL_ALACAK_DOVIZ_ID, foyum.TAKIP_TARIHI.Value);
    //// yazi.ACIKLAMA = Replace("DÖVÝZ KURU", yazi.ACIKLAMA, DovizKuru.ToString()); yazi.ACIKLAMA =
    //// Replace("HARCA ESAS DEÐER", yazi.ACIKLAMA, harcaEsasDeger.ToString()); //yazi=
    //// Replace("&DTC&",yazi,); if (foyum.TAKIP_CIKISI!=0) { yazi.ACIKLAMA = Replace("&ATK&",
    //// yazi.ACIKLAMA, foyum.TAKIP_CIKISI); } else { yazi.ACIKLAMA = Replace("&ATK&,",
    //// yazi.ACIKLAMA, ""); yazi.ACIKLAMA = Replace("&ATK&", yazi.ACIKLAMA, ""); }

    //// //yazi=Replace("&KUVTURKYTLACK&",yazi," //yazi=Replace("&SOZLESMEMIK&",yazi,);
    //// yazi.ACIKLAMA = Replace("&ILAMACIK&", yazi.ACIKLAMA, foyum);

    ////                    double faizOrani =  FaizHelper.FaizOraniGetir(ftid, dtip, tata);
    ////                    if (faizOrani!=0)
    ////                    {
    ////   yazi.ACIKLAMA = Replace("&FO&", yazi.ACIKLAMA,faizOrani);
    ////                    }
    ////                    else
    ////                    {
    ////                        yazi.ACIKLAMA = Replace("&FO&,", yazi.ACIKLAMA, "");
    ////                        yazi.ACIKLAMA = Replace("&FO&", yazi.ACIKLAMA, "");
    ////                    }
    ////                    if (foyum.KDV_TO!=0)
    ////                    {
    ////yazi.ACIKLAMA = Replace("&KDV&", yazi.ACIKLAMA, foyum.KDV_TO);
    ////                    }
    ////                    else
    ////                    {
    ////                        yazi.ACIKLAMA = Replace("&KDV&,", yazi.ACIKLAMA, "");
    ////                        yazi.ACIKLAMA = Replace("&KDV&", yazi.ACIKLAMA, "");
    ////                    }
    //                 GrupAciklama ga = new GrupAciklama();
    //             TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN yazi =   ga.GetVar(foyum);

    // if (yazi.ID==0) { }

    // memoEdit2.Text = yazi.ACIKLAMA; memoEdit3.Text = yazi.DOVIZ_TIPI; memoEdit1.Text =
    // yazi.GRUPLAR; lblalacakNedeni.Text = AvukatProLib2.Data.DataRepository.TI_KOD_ALACAK_NEDENProvider.GetByID(yazi.KOD_ALACAK_NEDEN_GRUP_ID.Value).ALACAK_NEDENI;
    // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKENProvider.DeepLoad(yazi,false,
    // DeepLoadType.IncludeChildren,typeof(TI_KOD_DOVIZ_ISLEM_TIPI)); lblDovizislemTipi.Text =
    // yazi.DOVIZ_ISLEM_TIPI_IDSource.KOD; lblHesapLamaTipi.Text = ((AvukatProLib.Extras.IcraDovizIslemTipi)Enum.ToObject(typeof(AvukatProLib.Extras.IcraDovizIslemTipi),
    // yazi.DOVIZ_HESAPLAMA_TIPI_ID.Value)).ToString();

    // }

    // string Replace(string var, string data, object newValue) { if (data.Contains(var)) { return
    // data.Replace(var, newValue.ToString()); } return data; }

    // private static TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN GetAciklamaByGrupInAlacakNedenDegiskenList(
    // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> lstAlacakNedenler,
    // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP> grup) {
    // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> rv = new
    // TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>(); for (int i = 0; i
    // < lstAlacakNedenler.Count; i++) { for (int y = 0; y < grup.Count; y++) { if
    // (lstAlacakNedenler[i].KOD_ALACAK_NEDEN_GRUP_ID.Value == grup[y].GRUP_NO) {
    // rv.Add(lstAlacakNedenler[i]);

    // } } } if (rv.Count == 0) { return null; }

    // return rv[0]; }

    // static TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>
    // GetGroupByAlacakNeden(AvukatProLib2.Entities.TI_KOD_ALACAK_NEDEN alacakNedeni, int
    // dovizIslemTipi, int formTipi, int dovizHesapTipi, bool faizYokmu) { if (dovizIslemTipi == 0)
    // { dovizIslemTipi = 1; } if (dovizHesapTipi == 0) { dovizHesapTipi = 1; }
    // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> returnValue = new
    // TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN>();
    // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> lstAlacakNedenler =
    // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKENProvider.GetAll(); for
    // (int i = 0; i < lstAlacakNedenler.Count; i++) { for (int y = 0; y < returnValue.Count; y++) {
    // if (returnValue[y].ID == lstAlacakNedenler[i].ID) { break; } } if
    // (lstAlacakNedenler[i].FORM_TIPI.Value == formTipi &&
    // lstAlacakNedenler[i].DOVIZ_HESAPLAMA_TIPI_ID.Value == dovizHesapTipi &&
    // lstAlacakNedenler[i].FAIZ_YOK_MU == faizYokmu &&
    // lstAlacakNedenler[i].DOVIZ_ISLEM_TIPI_ID.Value == dovizIslemTipi ||
    // lstAlacakNedenler[i].DOVIZ_ISLEM_TIPI_ID.Value == 3) { returnValue.Add(lstAlacakNedenler[i]);
    // } } return returnValue; }

    // static TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP>
    // FindAlacaknedenGroup(TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP> lstGrroup,
    // AvukatProLib2.Entities.TI_KOD_ALACAK_NEDEN alacakNedeni) {
    // TList<AvukatProLib2.Entities.TIE_KOD_ALACAK_NEDEN_GRUP> returnValue = new
    // TList<TIE_KOD_ALACAK_NEDEN_GRUP>(); for (int i = 0; i < lstGrroup.Count; i++) { if
    // (lstGrroup[i].ALACAK_NEDEN_ID == alacakNedeni.ID) { returnValue.Add(lstGrroup[i]); } } return
    // returnValue; }

    // private void simpleButton1_Click(object sender, EventArgs e) { this.Visible = false; }

    // private void lblDovizislemTipi_Click(object sender, EventArgs e) { }

    // public void LoadControls() { }

    // public void LoadDatas(AV001_TI_BIL_FOY myFoy) { LoadControls(); TList<TI_KOD_ALACAK_NEDEN>
    // lstAlacakNeden = new TList<TI_KOD_ALACAK_NEDEN>();

    // bool Dovizli = false; bool Ytli = false; bool Faiz = false; bool Veya = false;
    //int dovizIslemTipi  = 0;
    //            int FormTipi =1;
    //            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myFoy,false, DeepLoadType.IncludeChildren,typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
    //            AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection,false, DeepLoadType.IncludeChildren,typeof(TI_KOD_ALACAK_NEDEN));
    //            for (int i = 0; i < myFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++)
    //            {
    //             lstAlacakNeden.Add(myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_IDSource);
    //               Dovizli= (myFoy.ASIL_ALACAK_DOVIZ_ID.Value == 1 ? false : true);
    //                Ytli = (myFoy.ASIL_ALACAK_DOVIZ_ID.Value != 1 ? false : true);
    //                Faiz = myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].FAIZ_YOK;
    //               dovizIslemTipi = myFoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].HESAPLAMA_MODU;

    // }

    // TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstGroups =
    // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.GetAll(); for (int i = 0;
    // i < lstGroups.Count; i++) { if (lstGroups[i].GRUP_NO>maxGrupNo) { maxGrupNo =
    // lstGroups[i].GRUP_NO; } }

    // maxGrupNo++;

    // this.gridControl1.DataSource = lstAlacakNeden;

    // checkEdit1.Checked = Dovizli; checkEdit2.Checked = Ytli; checkEdit3.Checked = Faiz;
    // checkEdit4.Checked = Veya;

    // this.memoEdit5.Text = "";

    // this.lookUpEdit1.EditValue = FormTipi; this.comboBoxEdit1.SelectedIndex = dovizIslemTipi; }

    // int maxGrupNo = 0;

    // private void simpleButton2_Click(object sender, EventArgs e) {
    // TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstGroups = new TList<TIE_KOD_ALACAK_NEDEN_GRUP>(); for (int
    // i = 0; i < gridView1.RowCount; i++) { TIE_KOD_ALACAK_NEDEN_GRUP grp = new
    // TIE_KOD_ALACAK_NEDEN_GRUP(); grp.ALACAK_NEDEN_ID =
    // ((TI_KOD_ALACAK_NEDEN)gridView1.GetRow(i)).ID; grp.DOVIZ_ISLEM_TIPI_ID= Convert.ToInt32(
    // this.comboBoxEdit1.SelectedIndex); grp.FORM_TIPI_ID= Convert.ToInt32(
    // this.lookUpEdit1.EditValue); grp.VEYA_ILE_MI_BAGLI= checkEdit4.Checked;
    // grp.YTL_MI=checkEdit2.Checked; grp.DOVIZLI_MI= checkEdit1.Checked; grp.FAIZ_YOK_MU=
    // checkEdit3.Checked; grp.GRUP_NO=maxGrupNo; lstGroups.Add(grp); }

    // TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN degisken = new TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN();
    // degisken.ACIKLAMA = this.memoEdit5.Text; degisken.KOD_ALACAK_NEDEN_GRUP_ID = maxGrupNo;
    // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.Save(lstGroups);
    // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKENProvider.Save(degisken);
    // }

    // private void ucGrupDegiskenAciklama_Load(object sender, EventArgs e) { } }

    // public class GrupAciklama { /// <summary> /// foy içerisindeki alacaknedenleri ve form tipine
    // gore gruplarý getiriri. /// </summary> /// <param name="AlacakNeden"></param> ///
    // <param name="formTipi"></param> /// <param name="myfoy"></param> /// <returns></returns>
    // public TList<TIE_KOD_ALACAK_NEDEN_GRUP> GetGroupByAlacakNeden(AV001_TI_BIL_FOY myfoy) {
    // TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstAlacakNedenGrup = new TList<TIE_KOD_ALACAK_NEDEN_GRUP>();

    // //SqlConnection con = new SqlConnection("server=192.9.0.199; database=AVP_NHA_NG; uid=ersin;
    // pwd=123"); for (int i = 0; i < KodAlacakNedenler.Count; i++) { lstAlacakNedenGrup= AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.GetByALACAK_NEDEN_ID(KodAlacakNedenler[i].ID);

    // // using (SqlCommand cmd = new SqlCommand("select * from TIE_KOD_ALACAK_NEDEN_GRUP where
    // ALACAK_NEDEN_ID = " + .ToString(), con)) // { // con.Open(); // SqlDataReader dr =
    // cmd.ExecuteReader(CommandBehavior.CloseConnection); // while (dr.Read()) // { //
    // TIE_KOD_ALACAK_NEDEN_GRUP ag = new TIE_KOD_ALACAK_NEDEN_GRUP(); // ag.ID =
    // Convert.ToInt32(dr["ID"]); // ag.ALACAK_NEDEN_ID = Convert.ToInt32(dr["ALACAK_NEDEN_ID"]); //
    // ag.DOVIZLI_MI = Convert.ToBoolean(dr["DOVIZLI_MI"]); // ag.FAIZ_YOK_MU =
    // Convert.ToBoolean((dr["FAIZ_YOK_MU"] == DBNull.Value ? false : dr["FAIZ_YOK_MU"])); //
    // ag.FORM_TIPI_ID = Convert.ToInt32(dr["FORM_TIPI_ID"]); // ag.GRUP_NO =
    // Convert.ToInt32(dr["GRUP_NO"]); // ag.VEYA_ILE_MI_BAGLI =
    // Convert.ToBoolean(dr["VEYA_ILE_MI_BAGLI"]); // ag.YTL_MI = Convert.ToBoolean(dr["YTL_MI"]);

    // // ag.DOVIZ_ISLEM_TIPI_ID = Convert.ToInt32((dr["DOVIZ_ISLEM_TIPI_ID"] == DBNull.Value ?
    // false : dr["DOVIZ_ISLEM_TIPI_ID"])); // lstAlacakNedenGrup.Add(ag);

    // // } // dr.Close();

    // // } } // lstAlacakNedenGrup.Add(AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.GetByID(2855));

    // // TList<TIE_KOD_ALACAK_NEDEN_GRUP> returnValues = new TList<TIE_KOD_ALACAK_NEDEN_GRUP>();

    // //TList<TI_KOD_ALACAK_NEDEN> lstAlacakNedens = GetAlacakNedens(myfoy);

    // //filterAlacakNedens(lstAlacakNedenGrup, KodAlacakNedenler); TList<TIE_KOD_ALACAK_NEDEN_GRUP>
    // lstGroups = new TList<TIE_KOD_ALACAK_NEDEN_GRUP>();

    // for (int i = 0; i < myfoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++) { AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i],
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TI_KOD_DOVIZ_HESAPLAMA_TIPI));

    // for (int y = 0; y < lstAlacakNedenGrup.Count; y++) { TList<TIE_KOD_ALACAK_NEDEN_GRUP>
    // lstGroupPs = new TList<TIE_KOD_ALACAK_NEDEN_GRUP>(); lstGroupPs =
    // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.Find("GRUP_NO='" +
    // lstAlacakNedenGrup[y].GRUP_NO + "'");

    // if (lstGroupPs.Count > 1 && lstGroupPs[0].VEYA_ILE_MI_BAGLI.Value == false) { continue; }

    // if (ValidateGrup(lstAlacakNedenGrup[y],
    // myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].HESAPLAMA_MODU,
    // myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].FAIZ_YOK, myfoy.FORM_TIP_ID.Value,
    // (myfoy.ASIL_ALACAK_DOVIZ_ID.Value == 1 ? false : true))) {
    // lstGroups.Add(lstAlacakNedenGrup[y]); } } } if (lstGroups.Count==0) {
    // TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstfindedGroups =
    // AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUPProvider.Find("GRUP_NO='3001'");
    // if (lstfindedGroups.Count>0) { lstGroups.Add(lstfindedGroups[0]); }

    // } return lstGroups; }

    // bool ValidateGrup(TIE_KOD_ALACAK_NEDEN_GRUP grp, int hesaplamaModu, bool faiz, int ftip, bool
    // dovizli) { bool ytl = !dovizli;

    // if (grp.FORM_TIPI_ID == ftip && grp.DOVIZ_ISLEM_TIPI_ID == hesaplamaModu && grp.FAIZ_YOK_MU
    // == faiz && (grp.YTL_MI == ytl && grp.DOVIZLI_MI == dovizli || (grp.YTL_MI == true &&
    // grp.DOVIZLI_MI == true))) { return true; } return false; }

    // /// <summary> /// Alacak neden gruplarýný alacak nedenine gore filtreler. Bir grupta gelen
    // tum alacak nedenleri aranýr ve geriye tum alacak nedenlerini içeren gruplar dondurulur. ///
    // </summary> /// <param name="lstGroups"></param> /// <param name="lstAlacakNedens"></param>
    // void filterAlacakNedens(TList<TIE_KOD_ALACAK_NEDEN_GRUP> lstGroups,
    // TList<TI_KOD_ALACAK_NEDEN> lstAlacakNedens) { for (int y = 0; y < lstAlacakNedens.Count; y++)
    // { bool isOk = false; while (lstGroups.Count >= 1) { if (lstAlacakNedens[y].ID !=
    // lstGroups[0].ALACAK_NEDEN_ID) { lstGroups.Remove(lstGroups[0]); } } } }

    // /// <summary> /// Foy içerisindeki tum alanak neden kodlarýný bulur . /// </summary> ///
    // <param name="myfoy"></param> /// <returns></returns> void SetFields(AV001_TI_BIL_FOY myfoy) {
    // AvukatProLib2.Data.DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(myfoy, false,
    // AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>)); AvukatProLib2.Data.DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(myfoy.AV001_TI_BIL_ALACAK_NEDENCollection,
    // false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN)); for
    // (int i = 0; i < myfoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count; i++) {
    // _kodAlacakNedenler.Add(myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].ALACAK_NEDEN_KOD_IDSource);

    // if (!myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].FAIZ_YOK) { this.FAIZ_YOK_MU =
    // myfoy.AV001_TI_BIL_ALACAK_NEDENCollection[i].FAIZ_YOK; } }

    // }

    // private TList<TI_KOD_ALACAK_NEDEN> _kodAlacakNedenler = new TList<TI_KOD_ALACAK_NEDEN>();
    // public TList<TI_KOD_ALACAK_NEDEN> KodAlacakNedenler { get { return _kodAlacakNedenler; } set
    // { _kodAlacakNedenler = value; } }

    // private int _DOVIZ_ISLEM_TIPI; public int DOVIZ_ISLEM_TIPI { get { return _DOVIZ_ISLEM_TIPI;
    // } set { _DOVIZ_ISLEM_TIPI = value; } }

    // private int _Form_Tipi; public int Form_Tipi { get { return _Form_Tipi; } set { _Form_Tipi =
    // value; } }

    // private bool _FAIZ_YOK_MU; public bool FAIZ_YOK_MU { get { return _FAIZ_YOK_MU; } set {
    // _FAIZ_YOK_MU = value; } }

    // private bool _dovizliMi; public bool DovizliMi { get { return _dovizliMi; } set { _dovizliMi
    // = value; } }

    // private bool _ytlLiMi; public bool YtlLiMi { get { return _ytlLiMi; } set { _ytlLiMi = value;
    // } }

    // public TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN GetVar(AV001_TI_BIL_FOY myfoy) { SetFields(myfoy);
    // TList<TIE_KOD_ALACAK_NEDEN_GRUP> Groups = GetGroupByAlacakNeden(myfoy); if (Groups.Count
    // <= 0) { MessageBox.Show("Her hangi bir açýklama bulunamadý"); } else {
    // TList<TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN> DGS = AvukatProLib2.Data.DataRepository.TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKENProvider.Find(string.Format("KOD_ALACAK_NEDEN_GRUP_ID={0}",Groups[0].GRUP_NO));
    // for (int i = 0; i < DGS.Count; i++) { if ((DGS[i].FAIZ_YOK_MU == null ? false :
    // DGS[i].FAIZ_YOK_MU) == this.FAIZ_YOK_MU) { return DGS[i]; } } }

    // return new TIE_KOD_ALACAK_NEDEN_GRUP_DEGISKEN(); } }
}