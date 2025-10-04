using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmListedenGayrimenkulGetir : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        //Sözleşme kayıt ekranında Gayrimenkullerin listeden getirme işleminin yapılabilmesi için eklendi. MB

        public frmListedenGayrimenkulGetir()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmListedenGayrimenkulGetir_Load);
        }

        private void BindLookUps()
        {
            BelgeUtil.Inits.perCariGetir(lueMaliki);
            BelgeUtil.Inits.IlGetir(rlueIl);
            BelgeUtil.Inits.IlceGetirTumu(rlueIlce);
        }

        private void frmListedenGayrimenkulGetir_Load(object sender, EventArgs e)
        {
            BindLookUps();
        }

        private TList<AV001_TI_BIL_GAYRIMENKUL> GayrimenkulGetir(int malikID)
        {
            TList<AV001_TI_BIL_GAYRIMENKUL> gayrimenkulList = new TList<AV001_TI_BIL_GAYRIMENKUL>();

            foreach (var item in DataRepository.AV001_TI_BIL_GAYRIMENKUL_TARAFProvider.GetByTARAF_CARI_ID(malikID))
            {
                if (!item.GAYRI_MENKUL_ID.HasValue) continue;
                var gayrimenkul = DataRepository.AV001_TI_BIL_GAYRIMENKULProvider.GetByID(item.GAYRI_MENKUL_ID.Value);
                if (gayrimenkul != null && gayrimenkulList.Find(vi => vi.ID == gayrimenkul.ID) == null)
                    gayrimenkulList.Add(gayrimenkul);
            }
            return gayrimenkulList;
        }

        private void sbtnGayrimenkulGetir_Click(object sender, EventArgs e)
        {
            if (lueMaliki.EditValue != null)
                gcGayrimenkul.DataSource = GayrimenkulGetir((int)lueMaliki.EditValue);
        }

        private void sbtnGonder_Click(object sender, EventArgs e)
        {
            Sozlesme.Forms.frmSozlesmeKayitLayout.SelectedGayrimenkulList = (gcGayrimenkul.DataSource as TList<AV001_TI_BIL_GAYRIMENKUL>).FindAll(vi => vi.IsSelected);
            Sozlesme.Forms.frmSozlesmeKayitLayout.MalikID = (int)lueMaliki.EditValue;

            this.Close();
        }
    }
}