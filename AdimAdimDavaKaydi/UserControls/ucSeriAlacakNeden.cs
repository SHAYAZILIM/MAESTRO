using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucSeriAlacakNeden : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucSeriAlacakNeden()
        {
            InitializeComponent();
        }

        private void ucSeriAlacakNeden_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            BelgeUtil.Inits.AlacakNedenKodGetir(rLueAlacakNeden);

            BelgeUtil.Inits.DovizTipGetir(rLueDovizId);
        }

        public TList<AV001_TI_BIL_ALACAK_NEDEN> MyDataSource
        {
            get
            {
                if (lstAlacakNedenleri.DataSource is TList<AV001_TI_BIL_ALACAK_NEDEN>)
                    return (TList<AV001_TI_BIL_ALACAK_NEDEN>)lstAlacakNedenleri.DataSource;
                else
                    return null;
            }
            set
            {
                lstAlacakNedenleri.DataSource = value;
                if (value != null && !DesignMode)
                    MyDataSource.AddingNew += MyDataSource_AddingNew;
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ALACAK_NEDEN addNew = new AV001_TI_BIL_ALACAK_NEDEN();

            if (secilenObj.ALACAK_FAIZ_TIP_ID.HasValue)
                addNew.ALACAK_NEDEN_KOD_ID = secilenObj.ALACAK_NEDEN_KOD_ID.Value;
            addNew.DUZENLENME_TARIHI = secilenObj.DUZENLENME_TARIHI;
            addNew.HESAPLAMA_MODU = secilenObj.HESAPLAMA_MODU;
            addNew.TUTARI = secilenObj.TUTARI;
            addNew.TUTAR_DOVIZ_ID = secilenObj.TUTAR_DOVIZ_ID;
            addNew.ISLEME_KONAN_TUTAR = secilenObj.ISLEME_KONAN_TUTAR;
            addNew.ISLEME_KONAN_TUTAR_DOVIZ_ID = secilenObj.ISLEME_KONAN_TUTAR_DOVIZ_ID;
            addNew.TO_ALACAK_FAIZ_TIP_ID = secilenObj.TO_ALACAK_FAIZ_TIP_ID;
            addNew.TO_UYGULANACAK_FAIZ_ORANI = secilenObj.TO_UYGULANACAK_FAIZ_ORANI;
            //addNew.VADE_TARIHI = DateTime.Today;
            addNew.ALACAK_FAIZ_TIP_ID = secilenObj.ALACAK_FAIZ_TIP_ID;
            addNew.UYGULANACAK_FAIZ_ORANI = secilenObj.UYGULANACAK_FAIZ_ORANI;
            addNew.SABIT_FAIZ_UYGULA = secilenObj.SABIT_FAIZ_UYGULA;
            addNew.CEK_TAZMINATI = secilenObj.CEK_TAZMINATI;
            addNew.CEK_TAZMINATI_DOVIZ_ID = secilenObj.CEK_TAZMINATI_DOVIZ_ID;
            addNew.IHTAR_GIDERI = secilenObj.IHTAR_GIDERI;
            addNew.IHTAR_GIDERI_DOVIZ_ID = secilenObj.IHTAR_GIDERI_DOVIZ_ID;
            addNew.PROTESTO_GIDERI = secilenObj.PROTESTO_GIDERI;
            addNew.PROTESTO_GIDERI_DOVIZ_ID = secilenObj.PROTESTO_GIDERI_DOVIZ_ID;
            addNew.KOMISYONU = secilenObj.KOMISYONU;
            addNew.KOMISYONU_DOVIZ_ID = secilenObj.KOMISYONU_DOVIZ_ID;
            addNew.ACIKLAMA = secilenObj.ACIKLAMA;
            addNew.REFERANS_NO = secilenObj.REFERANS_NO;
            addNew.REFERANS_NO2 = secilenObj.REFERANS_NO2;
            addNew.REFERANS_NO3 = secilenObj.REFERANS_NO3;
            addNew.BSMV_HESAPLANSIN = secilenObj.BSMV_HESAPLANSIN;
            addNew.KKDV_HESAPLANSIN = secilenObj.KKDV_HESAPLANSIN;
            e.NewObject = addNew;
        }

        public enum Monts
        {
            Ocak = 1,
            Subat = 2,
            Mart = 3,
            Nisan = 4,
            Mayis = 5,
            Haziran = 6,
            Temmuz = 7,
            Agustos = 8,
            Eylul = 9,
            Ekim = 10,
            Kasim = 11,
            Aralik = 12,
        }

        private void SetInputs(AV001_TI_BIL_ALACAK_NEDEN obj)
        {
            if (obj.VADE_TARIHI.HasValue)
            {
                gun.Value = ((DateTime)obj.VADE_TARIHI).Day;
            }

            ay.Value = 1;

            adet.Value = 1;
        }

        private AV001_TI_BIL_ALACAK_NEDEN secilenObj;

        private void lstAlacakNedenleri_FocusedNodeChanged(object sender,
                                                           DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                secilenObj = (AV001_TI_BIL_ALACAK_NEDEN)e.Node.TreeList.GetDataRecordByNode(e.Node);

                SetInputs(secilenObj);
            }
        }

        private void btnSeriKayit_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            if (secilenObj == null)
            {
                MyDataSource = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
                secilenObj = MyDataSource.AddNew();
            }
            Monts m = (Monts)secilenObj.VADE_TARIHI.Value.Month;

            if (ay.Value == 1)
            {
                str = m + " ayýnýn" + " " + gun.Value + " " + ".gününe" + " " + "ayda bir olmak üzere" + " " +
                      adet.Value + " " + "adet alacak nedeni oluþturulacaktýr. Devam etmek istiyor musunuz ?";
            }

            else
            {
                str = "Her ayýn" + " " + gun.Value + " " + ".gününe" + " " + ay.Value + " " + "ayda bir olmak üzere" +
                      " " + adet.Value + " " + "adet alacak nedeni oluþturulacaktýr. Devam etmek istiyor musunuz ?";
            }

            DialogResult ds = XtraMessageBox.Show(str, "Seri Kayýt Baþlat", MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (ds == DialogResult.Yes)
            {
                SeriEkle(DateTime.Now.Year, secilenObj.VADE_TARIHI.Value.Month, secilenObj.VADE_TARIHI.Value.Day);
            }
        }

        private void SeriEkle(int year, int month, int day)
        {
            Monts m = (Monts)month;
            int g = 0;

            switch (m)
            {
                case Monts.Ocak:
                    g = 31;
                    break;
                case Monts.Subat:

                    int sonuc = DateTime.Now.Year / 4;
                    if (sonuc == 0)
                    {
                        g = 29;
                    }
                    else
                        g = 28;

                    break;
                case Monts.Mart:
                    g = 30;
                    break;
                case Monts.Nisan:
                    g = 31;
                    break;
                case Monts.Mayis:
                    g = 31;
                    break;
                case Monts.Haziran:
                    g = 30;
                    break;
                case Monts.Temmuz:
                    g = 31;
                    break;
                case Monts.Agustos:
                    g = 31;
                    break;
                case Monts.Eylul:
                    g = 30;
                    break;
                case Monts.Ekim:
                    g = 31;
                    break;
                case Monts.Kasim:
                    g = 30;
                    break;
                case Monts.Aralik:
                    g = 31;
                    break;
            }

            for (int j = 0; j < (int)adet.Value; j++)
            {
                for (int i = 1; i <= g; i++)
                {
                    if (i == (int)gun.Value)
                    {
                        AV001_TI_BIL_ALACAK_NEDEN alckNeden = MyDataSource.AddNew();

                        alckNeden.VADE_TARIHI = new DateTime(year, month, day);

                        break;
                    }
                }
            }
        }
    }
}