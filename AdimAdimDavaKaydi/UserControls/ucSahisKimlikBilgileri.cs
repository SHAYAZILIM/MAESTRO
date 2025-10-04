using System;
using System.ComponentModel;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSahisKimlikBilgileri : DevExpress.XtraEditors.XtraUserControl
    {
        private VList<per_TDI_KOD_ILCE> cloneIlce;

        public ucSahisKimlikBilgileri()
        {
            InitializeComponent();
            vGridCariBilgi.ShownEditor += vGridCariBilgi_ShownEditor;
            vGridCariBilgi.ValidateRecord += vGridCariBilgi_ValidateRecord;
        }

        private void vGridCariBilgi_ValidateRecord(object sender,
                                                   DevExpress.XtraVerticalGrid.Events.ValidateRecordEventArgs e)
        {
            if (e.RecordIndex > 0)
            {
                AV001_TDI_BIL_CARI_KIMLIK kimlik = MyDataSource[e.RecordIndex];
                kimlik.NKO_MAHALLE_KOY = kimlik.NKO_MAHALLE_KOY.ToUpper();
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_CARI_KIMLIK> MyDataSource
        {
            get
            {
                if (vGridCariBilgi.DataSource is TList<AV001_TDI_BIL_CARI_KIMLIK>)
                    return (TList<AV001_TDI_BIL_CARI_KIMLIK>)this.vGridCariBilgi.DataSource;
                return null;
            }
            set { this.vGridCariBilgi.DataSource = value; }
        }

        private void ucSahisKimlikBilgileri_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;
            rLueKayitliIl.NullText = "Seç";
            rLueKayitliIlce.NullText = "Seç";
            rLueCuzdaninVerilmeNedeni.NullText = "Seç";
            rLueMedeniHal.NullText = "Seç";
            rLueUyruk.NullText = "Seç";
            rLueKanGrup.NullText = "Seç";
            rLueKimlikTuru.NullText = "Seç";
            rlkCinsiyet.NullText = "Seç";
            rLueCariID.NullText = "Seç";
            rLueBelgeTuru.NullText = "Seç";
            BelgeUtil.Inits.IlGetir(rLueKayitliIl);
            BelgeUtil.Inits.IlceGetirTumu(rLueKayitliIlce);
            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.BelgeTurGetir(rLueBelgeTuru);
            BelgeUtil.Inits.KimlikVerilisNedenGetir(rLueCuzdaninVerilmeNedeni);
            BelgeUtil.Inits.MedeniHalGetir(rLueMedeniHal);
            BelgeUtil.Inits.UyrukGetir(rLueUyruk);
            BelgeUtil.Inits.KanGrupGetir(rLueKanGrup);
            BelgeUtil.Inits.KimlikTurGetir(rLueKimlikTuru);
            BelgeUtil.Inits.CinsiyetGetir(rlkCinsiyet);
        }

        private void vGridCariBilgi_ShownEditor(object sender, EventArgs e)
        {
            VGridControl gonderen = sender as VGridControl;
            if (gonderen.FocusedRow.Properties.FieldName == "NKO_ILCE_ID" && gonderen.ActiveEditor is LookUpEdit)
            {
                LookUpEdit edit = (LookUpEdit)gonderen.ActiveEditor;

                if (edit.Properties.DisplayField == "ILCE")
                {
                    VList<per_TDI_KOD_ILCE> ilceler = edit.Properties.DataSource as VList<per_TDI_KOD_ILCE>;
                    cloneIlce = new VList<per_TDI_KOD_ILCE>(ilceler);
                    AV001_TDI_BIL_CARI_KIMLIK cari =
                        gonderen.GetRecordObject(gonderen.FocusedRecord) as AV001_TDI_BIL_CARI_KIMLIK;
                    if (cari.NKO_IL_ID.HasValue)
                        cloneIlce.Filter = "IL_ID = " + cari.NKO_IL_ID.Value;
                    else
                        cloneIlce.Filter = "IL_ID = 0"; // Hiç bir kayýt göstermiyoruz

                    edit.Properties.DataSource = cloneIlce;
                }
            }
        }

        private void vGridCariBilgi_HiddenEditor(object sender, EventArgs e)
        {
            if (cloneIlce != null)
            {
                cloneIlce.Dispose();
                cloneIlce = null;
            }
        }
    }
}