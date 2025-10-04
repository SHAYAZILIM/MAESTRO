using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib;

namespace AdimAdimDavaKaydi.Util
{
    public partial class frmKayitSil : Form
    {
        #region Constructor

        public DialogResult SilmeOnayi;

        public frmKayitSil(string tableName, string where)
        {
            this.TableName = tableName;
            this.Where = where;

            InitializeComponent();
        }

        public frmKayitSil(string tableName, string where, bool isTable)
        {
            if (isTable)
                this.TableName = tableName;
            else
                this.TableName = GetTableName(tableName);
            this.Where = where;

            InitializeComponent();
        }

        #endregion

        #region Fields

        private List<IliskiNode> IliskiListesi = new List<IliskiNode>();

        #endregion

        #region properties

        private string TableName { get; set; }

        private string Where { get; set; }

        #endregion

        #region Events

        private void con_InfoMessagePreview(object sender, SqlInfoMessageEventArgs e)
        {
            var dizi = e.Message.Split('&');

            if (dizi.Length == 2)
            {
                string son = string.Empty;
                if (ıliskiNodeBindingSource.List.OfType<IliskiNode>().Where(vi => vi.Name == dizi[1]).Count() > 0)
                {
                    son = "#" + ıliskiNodeBindingSource.Count;
                }
                ıliskiNodeBindingSource.Add(new IliskiNode { ParentName = dizi[0], Name = dizi[1] + son });
            }
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            try
            {
                RunDelete();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        CompInfo cmpNfo;
        private void FrmKayitSil_Load(object sender, EventArgs e)
        {
            bndFormKontrol.DataSource = new FormKontrol();
            RunDeletePreview();

            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            cmpNfo = cmpNfoList[0];

            if (cmpNfo.DegistirmeSilmeSifresiAktif)
            {
                lblSifre.Visible = true;
                txtSifre.Visible = true;
                checkEdit1.Visible = false;
            }
            else
            {
                lblSifre.Visible = false;
                txtSifre.Visible = false;
                checkEdit1.Visible = true;
            }
        }

        #endregion

        #region Methots

        private string GetTableName(string tableName)
        {
            switch (tableName)
            {
                case "per_TAKIP_ALACAK_NEDEN": return "AV001_TI_BIL_ALACAK_NEDEN";
                case "per_TAKIP_ALACAK_NEDEN_ITIRAZ": return "AV001_TI_BIL_ITIRAZ_ALACAK_NEDEN";
                case "per_AV001_TDIE_BIL_BELGE": return "AV001_TDIE_BIL_BELGE";
                case "per_AV001_TI_BIL_ICRA_Arama":
                case "per_ICRA_HIZLI_ARAMA":
                    return "AV001_TI_BIL_FOY";
                case "per_AV001_TI_BIL_DAVA_Arama":
                case "per_DAVA_HIZLI_ARAMA":
                    return "AV001_TD_BIL_FOY";
                case "per_AV001_TDIE_BIL_PROJE": return "AV001_TDIE_BIL_PROJE";

                default: return tableName;
            }
        }

        private void RunDeletePreview()
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.InfoMessage += con_InfoMessagePreview;

            SqlCommand cmd = new SqlCommand("spDeleteRowsPreview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cTableName", TableName);
            cmd.Parameters.AddWithValue("@cCriteria", Where);
            cmd.Parameters.AddWithValue("@iRowsAffected", 0);
            cmd.Parameters.AddWithValue("@UstTable", "ROOT");
            cmd.Parameters["@iRowsAffected"].Direction = ParameterDirection.Output;
            cmd.CommandTimeout = 2000;

            con.Open();
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("spDeleteRowsPreview") && !ex.Message.Contains("expects parameter"))
                {
                    AvukatProLib.Hesap.HesapAraclari.Tools.ProsedureOlustur(
                        AvukatProLib.Hesap.HesapAraclari.Tools.ProsedureList.spDeletePreview);
                    RunDeletePreview();
                    return;
                }
                MessageBox.Show("Silme İşlemi Gerçekleşemedi");
                this.DialogResult = DialogResult.Cancel;
            }
            finally
            {
                con.Close();
            }
        }

        private void RunDelete(string _tableName, string _where)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            //con.InfoMessage += new SqlInfoMessageEventHandler(con_InfoMessage);

            SqlCommand cmd = new SqlCommand("spDeleteRows", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //if (_tableName == "Av001TdiBilKasaEntity")
            //    _tableName = "AV001_TDI_BIL_KASA";

            cmd.Parameters.AddWithValue("@cTableName", _tableName);
            cmd.Parameters.AddWithValue("@cCriteria", _where);
            cmd.Parameters.AddWithValue("@iRowsAffected", 0);
            cmd.Parameters["@iRowsAffected"].Direction = ParameterDirection.Output;
            cmd.CommandTimeout = 0;

            con.Open();
            try
            {
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("spDeleteRows"))
                {
                    AvukatProLib.Hesap.HesapAraclari.Tools.ProsedureOlustur(
                        AvukatProLib.Hesap.HesapAraclari.Tools.ProsedureList.spDeleteRow);
                    RunDelete(_tableName, _where);
                    return;
                }
                MessageBox.Show("Silme İşlemi Gerçekleşemedi");
            }
            finally
            {
                con.Close();
            }
        }

        private void RunDelete()
        {
            if (TableName != "AV001_TDIE_BIL_PROJE")
            {
                RunDelete(TableName, Where);
            }
            else
            {
                List<KlasorSecenekleri> secenekler = frmKlasorSilmeSecenekleri.SecenekleriGoster();
                if (secenekler != null)
                {
                    int projeID = -1;

                    try
                    {
                        projeID = Int32.Parse(Where.Split('=')[1].Trim());
                    }
                    catch
                    { }

                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_ICRA_FOY> pIcraTakipleri = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_ICRA_FOYProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_DAVA_FOY> pDavalar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_DAVA_FOYProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_HAZIRLIK> pSorusturmalar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_HAZIRLIKProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN> pAlacaklar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_BELGE> pBelgeler = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_BELGEProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_BORCLU_MAL> pBorcluMallar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_BORCLU_MALProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_GENEL_NOT> pGenelNotlar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_GENEL_NOTProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_GORUSME> pGorusmeler = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_GORUSMEProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_HATIRLATMA> pHatirlatmalar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_HATIRLATMAProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_HESAP> pHesaplar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_HESAPProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME> pOdemeler = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEMEProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_IHTARNAME> pIhtarnameler = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_IHTARNAMEProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ> pIhtiyatiHacizler = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR> pIhtiyatiTedbirler = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIRProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_ILAM_BILGILERI> pIlamlar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_ILAM_BILGILERIProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_IS> pIsler = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_ISProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK> pKiymetliEvraklar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAKProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_MASRAF_AVANS> pMasraflar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_MASRAF_AVANSProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_SORUMLU> pSorumlular = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_SORUMLUProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_SOZLESME> pSozlesmeler = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_SOZLESMEProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_TARAF> pTaraflar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_TARAFProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_TEBLIGAT> pTebligatlar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_TEBLIGATProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_TEKLIF_KARAR> pTeklifKararlar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_TEKLIF_KARARProvider.GetByPROJE_ID(projeID);
                    AvukatProLib2.Entities.TList<AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_TEMINAT> pTeminatlar = AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_PROJE_TEMINATProvider.GetByPROJE_ID(projeID);

                    if (secenekler.Contains(KlasorSecenekleri.Icra))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_ICRA_FOY tmpIcra in pIcraTakipleri)
                        {
                            RunDelete("AV001_TI_BIL_FOY", "ID = " + tmpIcra.ICRA_FOY_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Dava))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_DAVA_FOY tmpDava in pDavalar)
                        {
                            RunDelete("AV001_TD_BIL_FOY", "ID = " + tmpDava.DAVA_FOY_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Sorusturma))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_HAZIRLIK tmpSorusturma in pSorusturmalar)
                        {
                            RunDelete("AV001_TD_BIL_HAZIRLIK", "ID = " + tmpSorusturma.HAZIRLIK_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Alacak))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN tmpAlacaklar in pAlacaklar)
                        {
                            RunDelete("AV001_TI_BIL_ALACAK_NEDEN", "ID = " + tmpAlacaklar.ALACAK_NEDEN_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Teminat))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_TEMINAT tmpTeminatlar in pTeminatlar)
                        {
                            RunDelete("AV001_TDI_BIL_SOZLESME", "ID = " + tmpTeminatlar.SOZLESME_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Sozlesme))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_SOZLESME tmpSozlesmeler in pSozlesmeler)
                        {
                            RunDelete("AV001_TDI_BIL_SOZLESME", "ID = " + tmpSozlesmeler.SOZLESME_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.IhtiyatiHaciz))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_IHTIYATI_HACIZ tmpIhtiyatiHacizler in pIhtiyatiHacizler)
                        {
                            RunDelete("AV001_TI_BIL_IHTIYATI_HACIZ", "ID = " + tmpIhtiyatiHacizler.IHTIYATI_HACIZ_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.IhtiyatiTedbir))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_IHTIYATI_TEDBIR tmpIhtiyatiTedbirler in pIhtiyatiTedbirler)
                        {
                            RunDelete("AV001_TDI_BIL_IHTIYATI_TEDBIR", "ID = " + tmpIhtiyatiTedbirler.IHTIYATI_TEDBIR_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Odeme))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME tmpOdemeler in pOdemeler)
                        {
                            RunDelete("AV001_TI_BIL_BORCLU_ODEME", "ID = " + tmpOdemeler.BORCLU_ODEME_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Masraf))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_MASRAF_AVANS tmpMasraf in pMasraflar)
                        {
                            RunDelete("AV001_TDI_BIL_MASRAF_AVANS", "ID = " + tmpMasraf.MASRAF_AVANS_ID.ToString());
                        }

                    if (secenekler.Contains(KlasorSecenekleri.Mal))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_BORCLU_MAL tmpMal in pBorcluMallar)
                        {
                            RunDelete("TDI_BIL_BORCLU_MAL", "ID = " + tmpMal.BORCLU_MAL_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Ilam))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_ILAM_BILGILERI tmpIlam in pIlamlar)
                        {
                            RunDelete("AV001_TI_BIL_ILAM_MAHKEMESI", "ID = " + tmpIlam.ILAM_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Ihtarname))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_IHTARNAME tmpIhtarname in pIhtarnameler)
                        {
                            RunDelete("AV001_TDI_BIL_TEBLIGAT", "ID = " + tmpIhtarname.TEBLIGAT_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Tebligatlar))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_TEBLIGAT tmpTebligat in pTebligatlar)
                        {
                            RunDelete("AV001_TDI_BIL_TEBLIGAT", "ID = " + tmpTebligat.TEBLIGAT_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.AlacakSenedi))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_KIYMETLI_EVRAK tmpKiymetliEvraklar in pKiymetliEvraklar)
                        {
                            RunDelete("AV001_TDI_BIL_KIYMETLI_EVRAK", "ID = " + tmpKiymetliEvraklar.KIYMETLI_EVRAK_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Belge))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_BELGE tmpBelge in pBelgeler)
                        {
                            RunDelete("AV001_TDIE_BIL_BELGE", "ID = " + tmpBelge.BELGE_ID.ToString());
                        }
                    if (secenekler.Contains(KlasorSecenekleri.Is))
                        foreach (AvukatProLib2.Entities.AV001_TDIE_BIL_PROJE_IS tmpIs in pIsler)
                        {
                            RunDelete("AV001_TDI_BIL_IS", "ID = " + tmpIs.IS_ID.ToString());
                        }

                    try
                    {
                        RunDelete("AV001_TDIE_BIL_PROJE", "ID = " + projeID.ToString());
                    }
                    catch { }
                }
                else
                {
                    this.SilmeOnayi = DialogResult.Cancel;
                }
            }
        }

        private string GetConnectionString()
        {
            return AvukatProLib.Kimlik.SirketBilgisi.ConStr;
        }

        #endregion

        #region Class

        private class FormKontrol
        {
        }

        public class IliskiNode
        {
            public string ParentName { get; set; }

            public string Name { get; set; }

        }

        #endregion

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.SilmeOnayi = DialogResult.Cancel;
        }

        private void txtSifre_EditValueChanged(object sender, EventArgs e)
        {
            if (cmpNfo == null)
            {
                List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
                cmpNfo = cmpNfoList[0];
            }
            if (txtSifre.Text == cmpNfo.DegistirmeSilmeSifresi)
                btnTamam.Enabled = true;
            else
                btnTamam.Enabled = false;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            btnTamam.Enabled = checkEdit1.Checked;
        }
    }
}