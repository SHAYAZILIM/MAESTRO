using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Entegrasyon
{
    //frmshowtahsilat formu test edildikten sonra bu form kaldırılacak. MB

    public partial class frmAktarilanTahsilatlar : Form
    {
        public frmAktarilanTahsilatlar()
        {
            InitializeComponent();
        }

        private void frmAktarilanTahsilatlar_Load(object sender, EventArgs e)
        {
            //Sisteme giriş yapan avukatın sorumlu olduğu klasörler.
            var sorumluKlasorList = DataRepository.AV001_TDIE_BIL_PROJE_SORUMLUProvider.GetByCARI_ID(AvukatProLib.Kimlik.Bilgi.CARI_ID.Value).FindAll(vi => vi.YETKILI_MI.HasValue ? !vi.YETKILI_MI.Value : false).Select(vi => vi.PROJE_ID);

            List<string> krediBorclusuMusteriNoList = new List<string>();

            if (BelgeUtil.Inits._per_CariGetir == null)
                BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.ToList();

            foreach (var item in sorumluKlasorList)
            {
                var klasorKrediBorclusuList = DataRepository.AV001_TDIE_BIL_PROJE_KREDI_BORCLUSUProvider.GetByPROJE_ID(item);

                DataRepository.AV001_TDIE_BIL_PROJE_KREDI_BORCLUSUProvider.DeepLoad(klasorKrediBorclusuList, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));

                krediBorclusuMusteriNoList.AddRange(klasorKrediBorclusuList.Select(vi => vi.KREDI_BORCLUSU_CARI_IDSource.MUSTERI_NO));
            }

            TList<AKT_AKTARILAN_TAHSILATLAR_XML> tahsilatList = new TList<AKT_AKTARILAN_TAHSILATLAR_XML>();
            foreach (var item in krediBorclusuMusteriNoList)
            {
                var tahsilat = DataRepository.AKT_AKTARILAN_TAHSILATLAR_XMLProvider.Find(string.Format("MUSTERI_NO = {0}", item));
                if (tahsilat != null && tahsilat.Count > 0) tahsilatList.AddRange(tahsilat);
            }

            gcTahsilatlar.DataSource = tahsilatList;
        }

        private void tahsilatEşleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var item = (gvTahsilatlar.GetFocusedRow() as AKT_AKTARILAN_TAHSILATLAR_XML);
            //MethodsForMasrafTahsilat.CheckTahsilat(item);

            //if (MethodsForMasrafTahsilat.TahsilatIslendi)
            //{
            //    (gcTahsilatlar.DataSource as TList<AKT_AKTARILAN_TAHSILATLAR_XML>).Remove(item);
            //    gcTahsilatlar.RefreshDataSource();
            //}
        }
    }
}