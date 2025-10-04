using System.Collections.Generic;

namespace AdimAdimDavaKaydi
{
    public partial class AramaKutucugum : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public AramaKutucugum()
        {
            InitializeComponent();
            groupControl1.Visible = false;
        }

        public List<T> FindItem<T>(string[] props, object value, List<T> DataSource)
        {
            List<T> ReturnValue = new List<T>();
            List<T> col = DataSource;
            foreach (object itm in col)
            {
                foreach (string strprops in props)
                {
                    if (itm.GetType().GetProperty(strprops) == null)
                    {
                        continue;
                    }
                    if (itm.GetType().GetProperty(strprops).GetValue(itm, null) == null)
                    {
                        continue;
                    }
                    if ((itm.GetType().GetProperty(strprops).GetValue(itm, null).ToString().Contains(value.ToString())))
                    {
                        ReturnValue.Add((T)itm);
                    }
                }
            }
            return ReturnValue;
        }

        //internal void RaporlariAra<T>(List<AvukatProLib.Entity.Sablon_Rapor> ds,AramaTipi tip)
        //{
        //    dsRapor = ds;
        //    switch (tip)
        //    {
        //        case AramaTipi.Rapor:

        //            break;
        //        case AramaTipi.Nesne:
        //            dsNesne = ds;
        //            break;
        //        default:
        //            break;
        //    }

        //}

        //private List<AvukatProLib.Entity.Sablon_Rapor> dsRapor = new List<AvukatProLib.Entity.Sablon_Rapor>();
        //private List<AvukatProLib.Entity.Sablon_Rapor_IliskiliNesne> dsNesne = new List<AvukatProLib.Entity.Sablon_Rapor_IliskiliNesne>();

        //public delegate void OnAramaOk(object Datasource);
        //public event OnAramaOk AramaOk;
        //private void btnRaporAra_Click(object sender, EventArgs e)
        //{
        //    groupControl1.Visible = true;
        //    List<AvukatProLib.Entity.Sablon_Rapor> rprSonuc =    (FindItem<AvukatProLib.Entity.Sablon_Rapor>(new string[]{"Adi","Aciklama","Deger"},txtArama.Text,this.dsRapor));
        //    AramaOk(AvukatProLib.Facade.General.SearchRapors(txtArama.Text, chkKalip.Checked, chkIlýsýkNesne.Checked, chkAciklama.Checked, chkAdi.Checked));
        //    groupControl1.Visible = false;
        //}
        //internal enum AramaTipi
        //{
        //    Rapor,Nesne
        //}
    }
}