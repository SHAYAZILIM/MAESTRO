using System.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using RaporDataSource.TableDB;

namespace AvukatProRaporlar.RaporSource
{
    public class GenelMetotlar
    {
        public RibbonPage Bicimlendirmeler()
        {
            //BarButtonItem btnKusulluBicimlendir = new BarButtonItem();
            //btnKusulluBicimlendir.ItemClick += new ItemClickEventHandler(btnKusulluBicimlendir_ItemClick);
            //BarButtonItem btnGorunumuKaydet = new BarButtonItem();
            //btnGorunumuKaydet.ItemClick += new ItemClickEventHandler(btnGorunumuKaydet_ItemClick);
            //BarButtonItem btnFiltreleriDuzenle = new BarButtonItem();
            //btnFiltreleriDuzenle.ItemClick += new ItemClickEventHandler(btnFiltreleriDuzenle_ItemClick);
            //btnKusulluBicimlendir.Caption = "Koşullu Biçimlendir";
            //btnKusulluBicimlendir.Id = 1;
            //btnKusulluBicimlendir.LargeGlyph = global::AvukatProRaporlar.Properties.Resources;
            //btnKusulluBicimlendir.Name = "barButtonItem9";
            //btnGorunumuKaydet.Caption = "Koşullu Biçimlendir";
            //btnGorunumuKaydet.Id = 1;
            //btnGorunumuKaydet.LargeGlyph = global::AvukatProRaporlar.Properties.Resources;
            //btnGorunumuKaydet.Name = "barButtonItem9";
            //btnFiltreleriDuzenle.Caption = "Koşullu Biçimlendir";
            //btnFiltreleriDuzenle.Id = 1;
            //btnFiltreleriDuzenle.LargeGlyph = global::AvukatProRaporlar.Properties.Resources;
            //btnFiltreleriDuzenle.Name = "barButtonItem9";
            //RibbonPageGroup pg = new RibbonPageGroup();
            //pg.KeyTip = "0";
            //pg.Name = "rbBicimlendir";
            //pg.ItemLinks.Add(btnFiltreleriDuzenle);
            //pg.ItemLinks.Add(btnGorunumuKaydet);
            //pg.ItemLinks.Add(btnKusulluBicimlendir);
            //RibbonPage bicim = new RibbonPage();
            //this.bicim.Image = global::AvukatProRaporlar.Properties.Resources.sihirbaz2;
            //this.bicim.KeyTip = "B";
            //this.bicim.Name = "ribbonPage1";
            //this.bicim.Text = "Düzenlemeler";
            //bicim.Groups.Add(pg);
            return null;
        }

        public void btnFiltreleriDuzenle_ItemClick(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void btnGorunumuKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void btnKusulluBicimlendir_ItemClick(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public string BuroAdiGetir(int? key)
        {
            DBDataContext dbV = Program.db;
            var name = dbV.TDIE_BIL_KULLANICI_SUBELERIs.Where(vii => vii.ID == key).Select(vi => vi.SUBE_ADI).FirstOrDefault();
            if (string.IsNullOrEmpty(name))
                return "Büro Bilgisi Girilmemiş";
            return name.ToString();
        }
    }
}