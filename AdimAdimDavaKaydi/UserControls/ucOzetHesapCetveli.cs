using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucOzetHesapCetveli : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucOzetHesapCetveli()
        {
            InitializeComponent();
        }

        private HesapAraclari.OzetHesap _myDataSource;

        [DefaultValue(false)]
        [Browsable(false)]
        public HesapAraclari.OzetHesap MyDataSource
        {
            get { return _myDataSource; }
            set
            {
                DegerleriAyarla(value);

                _myDataSource = value;
            }
        }

        public ParaVeDovizId deger { get; set; }

        private void DegerleriAyarla(HesapAraclari.OzetHesap ozet)
        {
            if (ozet == null)
            {
                paraKalanAnaPara.Tutar = new ParaVeDovizId();
                paraKalanBankaAlacagindanKalan.Tutar = new ParaVeDovizId();
                paraKalanFaiz.Tutar = new ParaVeDovizId();
                paraKalanGiderVergisi.Tutar = new ParaVeDovizId();
                paraKalanHarc.Tutar = new ParaVeDovizId();
                paraKalanKalan.Tutar = new ParaVeDovizId();
                paraKalanKomTaz.Tutar = new ParaVeDovizId();
                paraKalanMasraf.Tutar = new ParaVeDovizId();
                paraKalanVekaletUcreti.Tutar = new ParaVeDovizId();

                paraOdemeAnaPara.Tutar = new ParaVeDovizId();
                paraOdemeBankaAlacagindanKalan.Tutar = new ParaVeDovizId();
                paraOdemeFaiz.Tutar = new ParaVeDovizId();
                paraOdemeGiderVergisi.Tutar = new ParaVeDovizId();
                paraOdemeHarclar.Tutar = new ParaVeDovizId();
                paraOdemeKalan.Tutar = new ParaVeDovizId();
                paraOdemeKomTaz.Tutar = new ParaVeDovizId();
                paraOdemeMasraf.Tutar = new ParaVeDovizId();
                paraOdemeVekaletUcreti.Tutar = new ParaVeDovizId();

                paraIndirimAnaPara.Tutar = new ParaVeDovizId();
                paraIndirimBankaAlacagi.Tutar = new ParaVeDovizId();
                paraIndirimFaiz.Tutar = new ParaVeDovizId();
                paraIndirimGiderVergisi.Tutar = new ParaVeDovizId();
                paraIndirimHarclar.Tutar = new ParaVeDovizId();
                paraIndirimKalan.Tutar = new ParaVeDovizId();
                paraIndirimKomisyonTazminat.Tutar = new ParaVeDovizId();
                paraIndirimMasraf.Tutar = new ParaVeDovizId();
                paraIndirimVekaletUcreti.Tutar = new ParaVeDovizId();

                paraTutarAnaPara.Tutar = new ParaVeDovizId();
                paraTutarBankaAlacagindanKalan.Tutar = new ParaVeDovizId();
                paraTutarFaiz.Tutar = new ParaVeDovizId();
                paraTutarGiderVergisi.Tutar = new ParaVeDovizId();
                paraTutarHarclar.Tutar = new ParaVeDovizId();
                paraTutarKalan.Tutar = new ParaVeDovizId();
                paraTutarKomTaz.Tutar = new ParaVeDovizId();
                paraTutarMasraf.Tutar = new ParaVeDovizId();
                paraTutarVekaletUcreti.Tutar = new ParaVeDovizId();

                paraNakitBakiye.Tutar = new ParaVeDovizId();
                paraGayriNakitBakiye.Tutar = new ParaVeDovizId();
                paraBankaAlacagi.Tutar = new ParaVeDovizId();
                paraVekaletUcreti.Tutar = new ParaVeDovizId();
                paraOdememisHarclar.Tutar = new ParaVeDovizId();
                paraToplamAlacak.Tutar = new ParaVeDovizId();
                paraGayrinakitDepo.Tutar = new ParaVeDovizId();
            }
            else
            {
                if (ozet.MyProje == null) return;

                paraOdemeAnaPara.Tutar = ozet.OdenenAnaPara;
                paraOdemeBankaAlacagindanKalan.Tutar = ParaVeDovizId.Cikart(ozet.OdenenKalan, ozet.OdenenVekaletUcreti);  //ozet.OdenenBankaAlacagindanKaln;
                paraOdemeFaiz.Tutar = ozet.OdenenFaiz;
                paraOdemeGiderVergisi.Tutar = ozet.OdenenGiderVergisi;
                paraOdemeHarclar.Tutar = ozet.OdenenHarclar;
                paraOdemeKalan.Tutar = ozet.OdenenKalan;
                paraOdemeKomTaz.Tutar = ozet.OdenenKomistonTazminat;
                paraOdemeMasraf.Tutar = ozet.OdenenMasraf;
                paraOdemeVekaletUcreti.Tutar = ozet.OdenenVekaletUcreti;

                if (ozet.MyProje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].TUTAR_KOM_TAZ != 0)
                {
                    paraTutarBankaAlacagindanKalan.Tutar = ozet.TutarBankaAlacagindanKaln = ParaVeDovizId.Topla(ozet.TutarBankaAlacagindanKaln, new ParaVeDovizId(ozet.MyProje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].TUTAR_KOM_TAZ, ozet.MyProje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].TUTAR_KOM_TAZ_DOVIZ_ID)); ;
                    paraTutarKomTaz.Tutar = ozet.TutarKomistonTazminat = new ParaVeDovizId(ozet.MyProje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].TUTAR_KOM_TAZ, ozet.MyProje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].TUTAR_KOM_TAZ_DOVIZ_ID);
                }
                else
                {
                    paraTutarBankaAlacagindanKalan.Tutar = ozet.TutarBankaAlacagindanKaln;
                    paraTutarKomTaz.Tutar = ozet.TutarKomistonTazminat;
                }
                paraTutarAnaPara.Tutar = ozet.TutarAnaPara;
                paraTutarFaiz.Tutar = ozet.TutarFaiz;
                paraTutarGiderVergisi.Tutar = ozet.TutarGiderVergisi;
                paraTutarHarclar.Tutar = ozet.TutarHarclar;
                paraTutarKalan.Tutar = ozet.TutarKalan;
                paraTutarMasraf.Tutar = ozet.TutarMasraf;
                paraTutarVekaletUcreti.Tutar = ozet.TutarVekaletUcreti;

                if (ozet.MyProje.DURUM_ID != 28)//İNDİRİMLİ TAHSİLAT (İndirimle Kapama)
                {
                    paraIndirimAnaPara.Tutar = ozet.IndirimAnaPara;
                    paraIndirimBankaAlacagi.Tutar = ozet.IndirimBankaAlacagindanKaln;
                    paraIndirimFaiz.Tutar = ozet.IndirimFaiz;
                    paraIndirimGiderVergisi.Tutar = ozet.IndirimGiderVergisi;
                    paraIndirimHarclar.Tutar = ozet.IndirimHarclar;
                    paraIndirimKalan.Tutar = ozet.IndirimKalan;
                    paraIndirimKomisyonTazminat.Tutar = ozet.IndirimKomistonTazminat;
                    paraIndirimMasraf.Tutar = ozet.IndirimMasraf;

                    if (ozet.MyProje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].INDIRIM_VEKALET_UCRETI != 0)
                    {
                        paraIndirimVekaletUcreti.Tutar = ozet.IndirimVekaletUcreti = new ParaVeDovizId(ozet.MyProje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].INDIRIM_VEKALET_UCRETI, ozet.MyProje.AV001_TDIE_BIL_PROJE_HESAPCollection[0].INDIRIM_VEKALET_UCRETI_DOVIZ_ID);
                        paraKalanVekaletUcreti.Tutar = ozet.KalanVekaletUcreti = ParaVeDovizId.Cikart(ozet.KalanVekaletUcreti, ozet.IndirimVekaletUcreti);
                    }
                    else
                    {
                        paraIndirimVekaletUcreti.Tutar = ozet.IndirimVekaletUcreti;
                        paraKalanVekaletUcreti.Tutar = ozet.KalanVekaletUcreti;
                    }

                    paraKalanAnaPara.Tutar = ozet.KalanAnaPara;
                    paraKalanBankaAlacagindanKalan.Tutar = ParaVeDovizId.Cikart(ozet.TutarBankaAlacagindanKaln, ParaVeDovizId.Topla(ParaVeDovizId.Cikart(ozet.OdenenKalan, ozet.OdenenVekaletUcreti), ozet.IndirimBankaAlacagindanKaln)); //ozet.KalanBankaAlacagindanKaln;
                    paraKalanFaiz.Tutar = ozet.KalanFaiz;
                    paraKalanGiderVergisi.Tutar = ozet.KalanGiderVergisi;
                    paraKalanHarc.Tutar = ozet.KalanHarclar;
                    paraKalanKalan.Tutar = ozet.KalanKalan;

                    if (ozet.TutarKomistonTazminat.Para != 0)
                        paraKalanKomTaz.Tutar = ozet.KalanKomistonTazminat = ParaVeDovizId.Topla(ozet.KalanKomistonTazminat, ozet.TutarKomistonTazminat);
                    else
                        paraKalanKomTaz.Tutar = ozet.KalanKomistonTazminat;

                    paraKalanMasraf.Tutar = ozet.KalanMasraf;
                    //paraKalanVekaletUcreti.Tutar = ozet.KalanVekaletUcreti;
                }
                else
                {
                    paraIndirimAnaPara.Tutar = ozet.KalanAnaPara;// ozet.IndirimAnaPara;
                    paraIndirimBankaAlacagi.Tutar = ParaVeDovizId.Cikart(ozet.TutarBankaAlacagindanKaln, ParaVeDovizId.Topla(ParaVeDovizId.Cikart(ozet.OdenenKalan, ozet.OdenenVekaletUcreti), ozet.IndirimBankaAlacagindanKaln)); //ozet.KalanBankaAlacagindanKaln;// ozet.IndirimBankaAlacagindanKaln;
                    paraIndirimFaiz.Tutar = ozet.KalanFaiz;// ozet.IndirimFaiz;
                    paraIndirimGiderVergisi.Tutar = ozet.KalanGiderVergisi;// ozet.IndirimGiderVergisi;
                    paraIndirimHarclar.Tutar = ozet.KalanHarclar;// ozet.IndirimHarclar;
                    paraIndirimKalan.Tutar = ozet.KalanKalan;// ozet.IndirimKalan;
                    paraIndirimKomisyonTazminat.Tutar = ParaVeDovizId.Topla(ozet.KalanKomistonTazminat, ozet.TutarKomistonTazminat);// paraKalanKomTaz.Tutar;// ozet.KalanKomistonTazminat;// ozet.IndirimKomistonTazminat;
                    paraIndirimMasraf.Tutar = ozet.KalanMasraf;// ozet.IndirimMasraf;
                    paraIndirimVekaletUcreti.Tutar = ozet.KalanVekaletUcreti;// ozet.IndirimVekaletUcreti;

                    ParaVeDovizId para = new ParaVeDovizId();
                    para.Para = 0;
                    para.DovizId = 1;

                    paraKalanAnaPara.Tutar = para;// ozet.KalanAnaPara;
                    paraKalanBankaAlacagindanKalan.Tutar = para;// ParaVeDovizId.Cikart(ozet.TutarBankaAlacagindanKaln, ParaVeDovizId.Topla(ParaVeDovizId.Cikart(ozet.OdenenKalan, ozet.OdenenVekaletUcreti), ozet.IndirimBankaAlacagindanKaln)); //ozet.KalanBankaAlacagindanKaln;
                    paraKalanFaiz.Tutar = para;// ozet.KalanFaiz;
                    paraKalanGiderVergisi.Tutar = para;// ozet.KalanGiderVergisi;
                    paraKalanHarc.Tutar = para;// ozet.KalanHarclar;
                    paraKalanKalan.Tutar = para;// ozet.KalanKalan;
                    paraKalanKomTaz.Tutar = para;// ozet.KalanKomistonTazminat;
                    paraKalanMasraf.Tutar = para;// ozet.KalanMasraf;
                    paraKalanVekaletUcreti.Tutar = para;// ozet.KalanVekaletUcreti;
                }

                #region <MB-20110301>

                //Klasör hesabında ekran düzenlendi, yeni alanlar eklendi.

                //Cezaevi YPD masrafının gösterilmesi sağlanıyor.
                var cezaeviYBPMasrafiList = ozet.MyProje.AV001_TDI_BIL_MASRAF_AVANSCollection_From_AV001_TDIE_BIL_PROJE_MASRAF_AVANS;
                foreach (var item in cezaeviYBPMasrafiList)
                {
                    var tutar = item.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection.FindAll(vi => vi.HAREKET_ALT_KATEGORI_ID == 859).FirstOrDefault();
                    if (tutar != null)
                    {
                        ParaVeDovizId para = new ParaVeDovizId();
                        para.DovizId = tutar.TOPLAM_TUTAR_DOVIZ_ID;
                        para.Para = tutar.TOPLAM_TUTAR;

                        paraCezaeviYBPMasrafi.Tutar = para;
                    }
                }

                List<ParaVeDovizId> gayriParaList = new List<ParaVeDovizId>();
                var list = ozet.MyProje.AV001_TI_BIL_ALACAK_NEDENCollection_From_AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI;
                List<int> listReferansAlacakID = new List<int>();//Her takipteki alacaklar ortak olduğundan bir kere alınanın bir daha alınmaması için eklendi. MB
                List<decimal> gayriDepoMiktariList = new List<decimal>();

                foreach (var item in list)
                {
                    if (!HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item)) continue;

                    if (!item.REFERANS_ALACAK_NEDEN_ID.HasValue)//Eski kayıtlarda REFERANS_ALACAK_NEDEN_ID alanı değer almıyordu.
                    {
                        AV001_TI_BIL_ALACAK_NEDEN aNedenTakipli = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(item.ID);

                        TList<AV001_TDIE_BIL_PROJE_ALACAK_NEDEN> projeTakipsizList = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.GetByPROJE_ID(ozet.MyProje.ID);

                        foreach (var takipsizAlacak in projeTakipsizList)
                        {
                            var aNedenTakipsiz = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(takipsizAlacak.ALACAK_NEDEN_ID);
                            if (aNedenTakipsiz.DIGER_ALACAK_NEDENI == aNedenTakipli.DIGER_ALACAK_NEDENI && aNedenTakipsiz.TUTARI == aNedenTakipli.TUTARI)
                            {
                                if (listReferansAlacakID.Contains(aNedenTakipsiz.ID)) continue;

                                ParaVeDovizId para = new ParaVeDovizId();
                                para.DovizId = aNedenTakipsiz.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;
                                para.Para = aNedenTakipsiz.ISLEME_KONAN_TUTAR;
                                gayriParaList.Add(para);
                                listReferansAlacakID.Add(aNedenTakipsiz.ID);

                                var depoMiktarList = BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.Where(vi => vi.ALACAK_NEDEN_ID == item.ID);
                                if (depoMiktarList == null || depoMiktarList.Count() == 0) continue;
                                else
                                    gayriDepoMiktariList.AddRange(depoMiktarList.Select(vi => vi.DEPO_TUTARI.Value));
                            }
                        }
                    }
                    else
                    {
                        if (listReferansAlacakID.Contains(item.REFERANS_ALACAK_NEDEN_ID.Value)) continue;
                        ParaVeDovizId para = new ParaVeDovizId();
                        para.DovizId = item.ISLEME_KONAN_TUTAR_DOVIZ_ID.Value;
                        para.Para = item.ISLEME_KONAN_TUTAR;
                        gayriParaList.Add(para);
                        listReferansAlacakID.Add(item.REFERANS_ALACAK_NEDEN_ID.Value);

                        var depoMiktarList = BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.Where(vi => vi.ALACAK_NEDEN_ID == item.REFERANS_ALACAK_NEDEN_ID.Value && vi.DEPO_TARIHI.HasValue);
                        if (depoMiktarList == null || depoMiktarList.Count() == 0) continue;
                        else
                            gayriDepoMiktariList.AddRange(depoMiktarList.Select(vi => vi.DEPO_TUTARI.Value));
                    }
                }

                paraNakitBakiye.Tutar = paraKalanBankaAlacagindanKalan.Tutar;
                paraGayriNakitBakiye.Tutar = ParaVeDovizId.Topla(gayriParaList);
                paraBankaAlacagi.Tutar = ParaVeDovizId.Topla(paraNakitBakiye.Tutar, paraGayriNakitBakiye.Tutar);
                paraVekaletUcreti.Tutar = paraKalanVekaletUcreti.Tutar;// ozet.KalanVekaletUcreti;
                //paraOdememisHarclar.Tutar
                paraToplamAlacak.Tutar = ParaVeDovizId.Topla(paraNakitBakiye.Tutar, paraGayriNakitBakiye.Tutar, paraVekaletUcreti.Tutar, paraOdememisHarclar.Tutar);
                paraGayrinakitDepo.Tutar = new ParaVeDovizId(gayriDepoMiktariList.Sum(), 1);

                #endregion
            }
        }

        private void paraTutarKomTaz_TutarDegisti(object sender, System.EventArgs e)
        {
            (this.ParentForm as Forms.frmKlasorYeni).AktifProjeyiGetir(false).AV001_TDIE_BIL_PROJE_HESAPCollection[0].TUTAR_KOM_TAZ = (sender as AdimAdimDavaKaydi.Util.UcDovizliTutarAlani).Tutar.Para; //MyDataSource.TutarKomistonTazminat.Para;
            (this.ParentForm as Forms.frmKlasorYeni).AktifProjeyiGetir(false).AV001_TDIE_BIL_PROJE_HESAPCollection[0].TUTAR_KOM_TAZ_DOVIZ_ID = (sender as AdimAdimDavaKaydi.Util.UcDovizliTutarAlani).Tutar.DovizId;

            DataRepository.AV001_TDIE_BIL_PROJE_HESAPProvider.Save((this.ParentForm as Forms.frmKlasorYeni).AktifProjeyiGetir(false).AV001_TDIE_BIL_PROJE_HESAPCollection);

            //MessageBox.Show("Girilen değerin hesaba yansıması için \r\nhesap işlemini yeniden yaptırınız.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void paraIndirimVekaletUcreti_TutarDegisti(object sender, System.EventArgs e)
        {
            (this.ParentForm as Forms.frmKlasorYeni).AktifProjeyiGetir(false).AV001_TDIE_BIL_PROJE_HESAPCollection[0].INDIRIM_VEKALET_UCRETI = (sender as AdimAdimDavaKaydi.Util.UcDovizliTutarAlani).Tutar.Para;
            (this.ParentForm as Forms.frmKlasorYeni).AktifProjeyiGetir(false).AV001_TDIE_BIL_PROJE_HESAPCollection[0].INDIRIM_VEKALET_UCRETI_DOVIZ_ID = (sender as AdimAdimDavaKaydi.Util.UcDovizliTutarAlani).Tutar.DovizId;

            DataRepository.AV001_TDIE_BIL_PROJE_HESAPProvider.Save((this.ParentForm as Forms.frmKlasorYeni).AktifProjeyiGetir(false).AV001_TDIE_BIL_PROJE_HESAPCollection);

            //MessageBox.Show("Girilen değerin hesaba yansıması için \r\nhesap işlemini yeniden yaptırınız.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}