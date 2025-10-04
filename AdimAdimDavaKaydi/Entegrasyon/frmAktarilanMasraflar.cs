using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    //frmshowmasraf formu test edildikten sonra bu form kaldırılacak. MB

    public partial class frmAktarilanMasraflar : Form
    {
        public frmAktarilanMasraflar()
        {
            InitializeComponent();
        }

        private void frmAktarilanMasraflar_Load(object sender, EventArgs e)
        {
            ////Sisteme giriş yapan avukatın sorumlu olduğu klasörler.
            //var sorumluKlasorList = DataRepository.AV001_TDIE_BIL_PROJE_SORUMLUProvider.GetByCARI_ID(AvukatProLib.Kimlik.Bilgi.CARI_ID.Value).FindAll(vi => vi.YETKILI_MI.HasValue ? !vi.YETKILI_MI.Value : false).Select(vi => vi.PROJE_ID);

            //List<string> krediBorclusuMusteriNoList = new List<string>();

            //if (BelgeUtil.Inits._per_CariGetir == null)
            //    BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

            //if (sorumluKlasorList.Count() > 0)
            //{
            //    foreach (var item in sorumluKlasorList)
            //    {
            //        var klasorKrediBorclusuList = DataRepository.AV001_TDIE_BIL_PROJE_KREDI_BORCLUSUProvider.GetByPROJE_ID(item);

            //        DataRepository.AV001_TDIE_BIL_PROJE_KREDI_BORCLUSUProvider.DeepLoad(klasorKrediBorclusuList, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

            //        krediBorclusuMusteriNoList.AddRange(klasorKrediBorclusuList.Select(vi => vi.KREDI_BORCLUSU_CARI_IDSource.MUSTERI_NO));
            //    }
            //}
            //else
            //{
            //    var sorumluTakipList = DataRepository.AV001_TI_BIL_FOY_SORUMLU_AVUKATProvider.GetBySORUMLU_AVUKAT_CARI_ID(AvukatProLib.Kimlik.Bilgi.CARI_ID.Value).FindAll(vi => !vi.YETKILI_MI).Select(vi => vi.ICRA_FOY_ID.Value);

            //    foreach (var item in sorumluTakipList)
            //    {
            //        var takipKrediBorclusuList = DataRepository.AV001_TI_BIL_FOY_KREDI_BORCLUSUProvider.GetByICRA_FOY_ID(item);

            //        DataRepository.AV001_TI_BIL_FOY_KREDI_BORCLUSUProvider.DeepLoad(takipKrediBorclusuList, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

            //        krediBorclusuMusteriNoList.AddRange(takipKrediBorclusuList.Select(vi => vi.KREDI_BORCLUSU_CARI_IDSource.MUSTERI_NO));

            //    }
            //}

            //TList<AKT_AKTARILAN_MASRAFLAR_XML> masrafList = new TList<AKT_AKTARILAN_MASRAFLAR_XML>();
            //foreach (var item in krediBorclusuMusteriNoList)
            //{
            //    var masraf = DataRepository.AKT_AKTARILAN_MASRAFLAR_XMLProvider.Find(string.Format("MUSTERI_NO = {0}", item));
            //    if (masraf != null && masraf.Count > 0) masrafList.AddRange(masraf);
            //}

            //DialogResult drKullaniciOnay = MessageBox.Show("Masraflardan referansı ve tutarı tutunlar otomatik eşleşsin mi?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (drKullaniciOnay == DialogResult.Yes)
            //{
            //    MethodsForMasrafTahsilat.ControlToMasraf(masrafList);
            //}
            //else
            //{
            //    gcMasraflar.DataSource = masrafList;
            //}
        }

        private void masrafEşleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var selectedMasraf = gvMasraflar.GetFocusedRow() as AKT_AKTARILAN_MASRAFLAR_XML;
            //MethodsForMasrafTahsilat.CheckMasrafAvans(selectedMasraf);

            //if (MethodsForMasrafTahsilat.MasrafIslendi)
            //{
            //    (gcMasraflar.DataSource as TList<AKT_AKTARILAN_MASRAFLAR_XML>).Remove(selectedMasraf);
            //    gcMasraflar.RefreshDataSource();
            //}
        }
    }
}