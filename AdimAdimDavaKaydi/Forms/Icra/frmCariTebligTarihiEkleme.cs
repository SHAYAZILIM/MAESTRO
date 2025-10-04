using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms.Icra
{
    public partial class frmCariTebligTarihiEkleme : Form
    {
        public frmCariTebligTarihiEkleme()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmCariTebligTarihiEkleme_Load);
        }

        public int KiymetTakdiriID { get; set; }

        public int SatisMasterID { get; set; }

        public List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERI> TebligList { get; set; }

        public void Show(AV001_TI_BIL_FOY foy, int kiymetSatisID, AvukatProLib.Extras.TebligTip tebligTip, AvukatProLib.Extras.MalTip malTip, int? malID)
        {
            if (tebligTip == AvukatProLib.Extras.TebligTip.KiymetTakdiri)
                this.KiymetTakdiriID = kiymetSatisID;
            else if (tebligTip == AvukatProLib.Extras.TebligTip.Satis)
                this.SatisMasterID = kiymetSatisID;

            this.Show(foy, malTip, malID);
        }

        public void Show(AV001_TI_BIL_FOY foy, AvukatProLib.Extras.MalTip malTip, int? malID)
        {
            //İcra dosyasının Alacaklıları, Borçluları,Takyidat ilgilileri,Borçlu olmayan diğer hissedarlar getirilecek. O Kıymet Takdi.
            List<int> cariIDList = new List<int>();

            if (foy.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_FOY_TARAF>));

            cariIDList.AddRange(foy.AV001_TI_BIL_FOY_TARAFCollection.Select(vi => vi.CARI_ID.Value));

            TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT> takyidatList = new TList<AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDAT>();
            if (malTip == AvukatProLib.Extras.MalTip.Gayrimenkul)
                takyidatList = DataRepository.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATProvider.GetByGAYRIMENKUL_ID(malID);
            else if (malTip == AvukatProLib.Extras.MalTip.GemiUcakArac)
                takyidatList = DataRepository.AV001_TDI_BIL_SOZLESME_DETAY_TAKYIDATProvider.GetByGEMI_UCAK_ARAC_ID(malID);

            foreach (var item in takyidatList)
            {
                if (item.ILGILI_CARI_ID.HasValue)
                    cariIDList.Add(item.ILGILI_CARI_ID.Value);
            }

            gcTarihler.DataSource = SetTebligTarihleri(cariIDList);
            this.Show();
        }

        private void frmCariTebligTarihiEkleme_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.perCariGetir(rlueCari);
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            BelgeUtil.Inits.context.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERIs.InsertAllOnSubmit(gcTarihler.DataSource as List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERI>);

            try
            {
                BelgeUtil.Inits.context.SubmitChanges();
                MessageBox.Show("Kayıt Tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Logger.ErrorException("Hata", ex);
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERI> SetTebligTarihleri(List<int> cariIDList)
        {
            List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERI> tebligTarihList = new List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERI>();
            List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERI> kayitliTebligatList = new List<AvukatProLib.Arama.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERI>();
            if (this.KiymetTakdiriID != 0)
                kayitliTebligatList = BelgeUtil.Inits.context.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERIs.Where(vi => vi.KIYMET_TAKDIRI_ID == this.KiymetTakdiriID).ToList();
            else if (this.SatisMasterID != 0)
                kayitliTebligatList = BelgeUtil.Inits.context.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERIs.Where(vi => vi.SATIS_ID == this.SatisMasterID).ToList();

            foreach (var item in cariIDList)
            {
                if (kayitliTebligatList.Find(vi => vi.CARI_ID == item) != null)
                {
                    tebligTarihList.Add(kayitliTebligatList.Find(vi => vi.CARI_ID == item));
                    continue;
                }
                AvukatProLib.Arama.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERI tebligTarih = new AvukatProLib.Arama.AV001_TDI_BIL_CARI_TEBLIG_TARIHLERI();
                tebligTarih.CARI_ID = item;
                if (this.KiymetTakdiriID != 0)
                    tebligTarih.KIYMET_TAKDIRI_ID = KiymetTakdiriID;
                if (this.SatisMasterID != 0)
                    tebligTarih.SATIS_ID = SatisMasterID;

                //tebligTarih.TEBLIG_TARIHI = DateTime.Now.Date;

                tebligTarihList.Add(tebligTarih);
            }
            return tebligTarihList;
        }
    }
}