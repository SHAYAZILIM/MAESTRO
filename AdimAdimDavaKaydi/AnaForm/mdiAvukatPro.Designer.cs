using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing;
namespace AdimAdimDavaKaydi.AnaForm
{
    partial class mdiAvukatPro
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }

                base.Dispose(disposing);
            }
            catch (System.Exception ex)
            {
                BelgeUtil.ErrorHandler.Logger.ErrorException("MDIAvukatPro", ex);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiAvukatPro));
            this.c_mnUstMenu = new System.Windows.Forms.MenuStrip();
            this.c_titemDosya = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaProjeDosya = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaProjeDosyaBulProje = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaProjeDosyaKlasorAra = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaProjeDosyaYeniProje = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaIcra = new System.Windows.Forms.ToolStripMenuItem();
            this.icraH�zl�AramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaIcraDosyaBul = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaIcraYeniIcraKayit = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaIcraYeniStandartFormIle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaIcraYeniSihirbazIle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaIcraYeniEditorIle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDava = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDavaDosyaBul = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDavaDosyaGelismisBul = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDavaYeniDava = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDavaEkleStandartFormIle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDavaYeniSihirbazIle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDavaYeniEditorIle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDegisikIsler = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDegisikIslerDosyasiBul = new System.Windows.Forms.ToolStripMenuItem();
            this.ihtiyatiHacizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ihtiyatiTedbirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDegisikIslerIhtiyatiHaciz = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDegisikIslerIhtiyatiTedbir = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDegisikIslerTespitKaydet = new System.Windows.Forms.ToolStripMenuItem();
            this.teminatMektuplar�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duru�maKe�ifAraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSorusturma = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaDavaSorusturmaBul = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSorusturmaYeni = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSorusturmaYeniStandartFormIle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSorusturmaYeniSihirbazFormIle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSorusturmaYeniEditorIle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSozlesme = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSozlesmeBul = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSozlesmeYenie = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSozlesmeYeniStandartFormIleEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.krediS�zle�mesiEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krediKart�S�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genelKrediS�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finansmanS�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hesapRehinS�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krediKart��yelikS�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krediliMenkulK�ymetS�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genelKrediTaahh�tnamesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankac�l�kHizmetS�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konutKredisiS�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ihtiya�KredisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ta��tKredisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gayrimenkul�pote�iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gemi�pote�iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.havaArac��pote�iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ara�RehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticari��letmeRehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menkulMalRehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menkulK�ymetRehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mevduatRehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticariSenetRehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hatRehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markaRehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticariPlakaRehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kanbiyoSenediRehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hisseSenediRehniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genelS�zle�meToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markaPatentS�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakemS�zle�mesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSozlesmeYeniSihirbazFormIleEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaSozlesmeYeniEditorIleEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaRucuveHasarBilgileri = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaRucuHasarPoliceveHaqsarBilgileri = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaRucuveHasarRucuBilgileri = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaRucuveHasarRucuBilgileriRucuBul = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaRucuveHasarRucuBilgileriYeniRucuEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaBelge = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaBelgeBelgeBul = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaBelgeYeniBelge = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaEvrak = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaEvrakBul = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaEvrakYeniEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaGorusme = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaGorusmeKayitBul = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaGorusmeYeniGorusme = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaAjanda = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemBenimAjandam = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemSubemdekiAvukatlarinAjandasi = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDetayliAjanda = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaYapilcakIs = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaYapilcakIsAra = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaYapilcakIsEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.�cretlendirilmi���lerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duru�maSat��Ke�ifBilgilerimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.araKararlar�mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplant�lar�mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g�nl�k��lerimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notlar�mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaKisi = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaKisiBulKisi = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaKisiYeniKisi = new System.Windows.Forms.ToolStripMenuItem();
            this.m�kerrer�ah�slar�Birle�tirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaVekalet = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaVekaletBulVekalet = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaVekaletYeniVekalet = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemDosyaHukukMuhasebesi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.c_titemDosyaCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemHizliIslemler = new System.Windows.Forms.ToolStripMenuItem();
            this.hemenBulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adEsasNoDosyaNoyaGoreBulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tapuBilgisindenBulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ara�BilgisindenBulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cekSenetBilgisindenBulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hemenEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�ah�sEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vekaletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.belgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evrakTebligatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masrafAvansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplant�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duru�maToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.araKararToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ke�if�ncelemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hacizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sat��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bor�luOdemesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daval��demesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m�vekkile�demeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.i�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g�r��meToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klas�rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s�kKullan�lanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemGorunum = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimciAlanlar = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemGorunumGuncelIslemler = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemStiller = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimCubugu = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemFormHerZamanUstte = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYaziTipi = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemSaydamlik = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemSaydamlikYuzde10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemArkaPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemArkaPlanResim = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemArkaPlanRenk = new System.Windows.Forms.ToolStripMenuItem();
            this.g�ncel��lemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d�vizKurlar�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resmiGazeteHaberleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hukukHaberleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekranGorunumleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemTanimlar = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemTanimlarKodVeCetvelAna = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemTanimlarKodVeCetvelAnaKodFormlar = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemTanimlarAntetTanimlarAlt = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemTanimlarHesapTanimlarAlt = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemTanimlarIsTanimlari = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemEditorTanim = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemEditorDegiskenTanim = new System.Windows.Forms.ToolStripMenuItem();
            this.muvekkilSozlesmeleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.davaSozlesmeleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IcraSozlesmeleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsUcretlendirmeSozlesmeleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemSistemIslemleriKullaniciSecenekleri = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemSistemIslemleriParolaDegistirme = new System.Windows.Forms.ToolStripMenuItem();
            this.kullan�c�De�i�tirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�irketDe�i�tirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYazismalar = new System.Windows.Forms.ToolStripMenuItem();
            this.standartYaz��malarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formlarEdit�rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topluYaz��maVeUYAPEdit�r�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemRaporlar = new System.Windows.Forms.ToolStripMenuItem();
            this.standartRaporlarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.icraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m�vekkilHesaplar�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hacizToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sat��ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bor�lu�demeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilamBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taahh�tBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itirazBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarafGeli�meleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bo�lununT�mMallar�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ihtiyatiHacizToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.davaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.araKararToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ihtiyatiTedbirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.duru�maKe�ifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duru�maSat��Ke�ifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.karara��kanDosyalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temyizEdilenDosyalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�zelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gelismisRaporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemStandartRaporlar = new System.Windows.Forms.ToolStripMenuItem();
            this.d�nemselRaporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envanterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.muallakRaporToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hasarBilgileriToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.poli�eBilgileriToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ticariRiskRaporuEntegreliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticariRiskRaporuDosyadanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemKimNerede = new System.Windows.Forms.ToolStripMenuItem();
            this.s�kKullan�lanlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g�sterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kimNeredeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hariciSimulasyonHesabiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kurGiri�iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entegrasyonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genelBilgilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.masraflarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tahsilatlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d�vizKurlar�ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aktar�lanMasraflarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktar�lanTahsilatlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.da��t�lmam��TahsilatlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.da��t�lmam��MasraflarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemSistemIslemleri = new System.Windows.Forms.ToolStripMenuItem();
            this.asistan��al��t�rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemSistemIslemleriSistemBakimi = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemSistemIslemleriYedekAl = new System.Windows.Forms.ToolStripMenuItem();
            this.yedekD�nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemSistemIslemleriServis = new System.Windows.Forms.ToolStripMenuItem();
            this.ekran�zelle�tirmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�r�nAktivasyonuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guncellemeAyarlariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guncellemeParametreleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guncellemeServisiniBaslatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bak�mAyarlar�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardim = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimAltDosyasi = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimKullanimKlavuzu = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimPratikYardim = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimIcendekiler = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimTeknikDestek = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimEgitimDestek = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimEnCokArananlar = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimAra = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.c_titemYardimLisanslama = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimMusteriGeriBesleme = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemYardimAvukatproYardim = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemTebligatBarkodAraligiTanimlama = new System.Windows.Forms.ToolStripMenuItem();
            this.c_titemPencere = new System.Windows.Forms.ToolStripMenuItem();
            this.tabWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yatayYerlestirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dikeyYerlestirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basamaklaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�a�r�MerkeziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anaEkranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c_pnlUst = new DevExpress.XtraEditors.PanelControl();
            this.c_comenUstKoseMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.c_tspnlMenuPanel = new System.Windows.Forms.ToolStripPanel();
            this.c_opfArkaPlan = new System.Windows.Forms.OpenFileDialog();
            this.c_opfFormuKaydet = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextModuleEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmYetkilendirme = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.c_pnlAlt = new DevExpress.XtraEditors.PanelControl();
            this.txtYapilacakIsler = new DevExpress.XtraEditors.TextEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dckPanelCagriMerkezi = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xtraTabHatlar = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabHat1 = new DevExpress.XtraTab.XtraTabPage();
            this.grpBoxCagriBilgileriHat1 = new System.Windows.Forms.GroupBox();
            this.tbControlCagriBilgileriHat1 = new System.Windows.Forms.TabControl();
            this.tbPageGiden = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.gridControlGidenHat1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewGidenHat1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnYeniAramaGidenHat1 = new System.Windows.Forms.Button();
            this.rdButtonHariciHat1 = new System.Windows.Forms.RadioButton();
            this.rdButtonDahiliHat1 = new System.Windows.Forms.RadioButton();
            this.btnGidenBulHat1 = new System.Windows.Forms.Button();
            this.txtBoxTcNoGidenHat1 = new System.Windows.Forms.TextBox();
            this.btnKonferansGidenHat1 = new System.Windows.Forms.Button();
            this.SlueArananGidenHat1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.btnYonlendirGidenHat1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnKapatGidenHat1 = new System.Windows.Forms.Button();
            this.btnAraGidenHat1 = new System.Windows.Forms.Button();
            this.cmbBoxTelNoGidenHat1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxMusteriNoGidenHat1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPageGelen = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridControlGelenHat1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewGelenHat1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnGelenBulHat1 = new System.Windows.Forms.Button();
            this.txtBoxTcNoGelenHat1 = new System.Windows.Forms.TextBox();
            this.SlueArayanGelenHat1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYeniAramaGelenHat1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKapatGelenHat1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKonferansGelenHat1 = new System.Windows.Forms.Button();
            this.txtBoxMusteriNoGelenHat1 = new System.Windows.Forms.TextBox();
            this.btnYonlendirGelenHat1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGeriCevirGelenHat1 = new System.Windows.Forms.Button();
            this.txtBoxTelNoGelenHat1 = new System.Windows.Forms.TextBox();
            this.btnCevaplaGelenHat1 = new System.Windows.Forms.Button();
            this.tbPageGorusmeTutanagi = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnGorusmeKaydetHat1 = new System.Windows.Forms.Button();
            this.tbPageEski = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnEskiGorusmeGetirHat1 = new System.Windows.Forms.Button();
            this.rdBtnSahisEskiGorusmeHat1 = new System.Windows.Forms.RadioButton();
            this.rdBtnDosyaEskiGorusmeHat1 = new System.Windows.Forms.RadioButton();
            this.tbPageIcraHesapHat1 = new System.Windows.Forms.TabPage();
            this.panel18 = new System.Windows.Forms.Panel();
            this.xtraTabHat2 = new DevExpress.XtraTab.XtraTabPage();
            this.grpBoxCagriBilgileriHat2 = new System.Windows.Forms.GroupBox();
            this.tbControlCagriBilgileriHat2 = new System.Windows.Forms.TabControl();
            this.tbPageGidenHat2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControlGidenHat2 = new DevExpress.XtraGrid.GridControl();
            this.gridViewGidenHat2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel19 = new System.Windows.Forms.Panel();
            this.btnYeniAramaGidenHat2 = new System.Windows.Forms.Button();
            this.rdButtonHariciHat2 = new System.Windows.Forms.RadioButton();
            this.rdButtonDahiliHat2 = new System.Windows.Forms.RadioButton();
            this.btnGidenBulHat2 = new System.Windows.Forms.Button();
            this.txtBoxTcNoGidenHat2 = new System.Windows.Forms.TextBox();
            this.btnKonferansGidenHat2 = new System.Windows.Forms.Button();
            this.SlueArananGidenHat2 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.btnYonlendirGidenHat2 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnKapatGidenHat2 = new System.Windows.Forms.Button();
            this.btnAraGidenHat2 = new System.Windows.Forms.Button();
            this.cmbBoxTelNoGidenHat2 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBoxMusteriNoGidenHat2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbPageGelenHat2 = new System.Windows.Forms.TabPage();
            this.panel20 = new System.Windows.Forms.Panel();
            this.gridControlGelenHat2 = new DevExpress.XtraGrid.GridControl();
            this.gridViewGelenHat2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel21 = new System.Windows.Forms.Panel();
            this.btnGelenBulHat2 = new System.Windows.Forms.Button();
            this.txtBoxTcNoGelenHat2 = new System.Windows.Forms.TextBox();
            this.SlueArayanGelenHat2 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.btnYeniAramaGelenHat2 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnKapatGelenHat2 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnKonferansGelenHat2 = new System.Windows.Forms.Button();
            this.txtBoxMusteriNoGelenHat2 = new System.Windows.Forms.TextBox();
            this.btnYonlendirGelenHat2 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btnGeriCevirGelenHat2 = new System.Windows.Forms.Button();
            this.txtBoxTelNoGelenHat2 = new System.Windows.Forms.TextBox();
            this.btnCevaplaGelenHat2 = new System.Windows.Forms.Button();
            this.tbPageGorusmeTutanagiHat2 = new System.Windows.Forms.TabPage();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.btnGorusmeKaydetHat2 = new System.Windows.Forms.Button();
            this.tbPageEskiGorusmelerHat2 = new System.Windows.Forms.TabPage();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.btnEskiGorusmeGetirHat2 = new System.Windows.Forms.Button();
            this.rdBtnSahisEskiGorusmeHat2 = new System.Windows.Forms.RadioButton();
            this.rdBtnDosyaEskiGorusmeHat2 = new System.Windows.Forms.RadioButton();
            this.tbPageIcraHesapHat2 = new System.Windows.Forms.TabPage();
            this.panel26 = new System.Windows.Forms.Panel();
            this.xtraTabHat3 = new DevExpress.XtraTab.XtraTabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.xtraTabHat4 = new DevExpress.XtraTab.XtraTabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.xtraTabSmsFaxMail = new DevExpress.XtraTab.XtraTabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblHatBilgisi4 = new System.Windows.Forms.Label();
            this.lblHatBilgisi3 = new System.Windows.Forms.Label();
            this.lblHatBilgisi2 = new System.Windows.Forms.Label();
            this.lblHatBilgisi1 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.�mageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit31 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit32 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit33 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView13 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn78 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox12 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn79 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn80 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit34 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn81 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit36 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn82 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit35 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn83 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn84 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn85 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit12 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit13 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit14 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit15 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox7 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit16 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit17 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn48 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit18 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox8 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn51 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn52 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit19 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn54 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit20 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn55 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit21 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemLookUpEdit22 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueBirim = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.repositoryItemImageComboBox9 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemLookUpEdit23 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit24 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn57 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn58 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn59 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn60 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn61 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn62 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn63 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox10 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemLookUpEdit25 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit26 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit27 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn64 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn65 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn66 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn67 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn68 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn69 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn70 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.repositoryItemImageComboBox11 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemLookUpEdit28 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit29 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit30 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView12 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn71 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn72 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn73 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn74 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn75 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn76 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn77 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.c_mnUstMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlUst)).BeginInit();
            this.c_pnlUst.SuspendLayout();
            this.c_comenUstKoseMenu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAlt)).BeginInit();
            this.c_pnlAlt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYapilacakIsler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dckPanelCagriMerkezi.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabHatlar)).BeginInit();
            this.xtraTabHatlar.SuspendLayout();
            this.xtraTabHat1.SuspendLayout();
            this.grpBoxCagriBilgileriHat1.SuspendLayout();
            this.tbControlCagriBilgileriHat1.SuspendLayout();
            this.tbPageGiden.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGidenHat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGidenHat1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlueArananGidenHat1.Properties)).BeginInit();
            this.tbPageGelen.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGelenHat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGelenHat1)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlueArayanGelenHat1.Properties)).BeginInit();
            this.tbPageGorusmeTutanagi.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tbPageEski.SuspendLayout();
            this.panel12.SuspendLayout();
            this.tbPageIcraHesapHat1.SuspendLayout();
            this.xtraTabHat2.SuspendLayout();
            this.grpBoxCagriBilgileriHat2.SuspendLayout();
            this.tbControlCagriBilgileriHat2.SuspendLayout();
            this.tbPageGidenHat2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGidenHat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGidenHat2)).BeginInit();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlueArananGidenHat2.Properties)).BeginInit();
            this.tbPageGelenHat2.SuspendLayout();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGelenHat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGelenHat2)).BeginInit();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlueArayanGelenHat2.Properties)).BeginInit();
            this.tbPageGorusmeTutanagiHat2.SuspendLayout();
            this.panel23.SuspendLayout();
            this.tbPageEskiGorusmelerHat2.SuspendLayout();
            this.panel25.SuspendLayout();
            this.tbPageIcraHesapHat2.SuspendLayout();
            this.xtraTabHat3.SuspendLayout();
            this.xtraTabHat4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueBirim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGorev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // c_mnUstMenu
            // 
            this.c_mnUstMenu.AutoSize = false;
            this.c_mnUstMenu.BackColor = System.Drawing.Color.White;
            this.c_mnUstMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_mnUstMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosya,
            this.c_titemHizliIslemler,
            this.c_titemGorunum,
            this.c_titemTanimlar,
            this.c_titemYazismalar,
            this.c_titemRaporlar,
            this.c_titemKimNerede,
            this.c_titemSistemIslemleri,
            this.c_titemYardim,
            this.c_titemPencere,
            this.�a�r�MerkeziToolStripMenuItem,
            this.anaEkranToolStripMenuItem});
            this.c_mnUstMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.c_mnUstMenu.Location = new System.Drawing.Point(2, 2);
            this.c_mnUstMenu.MdiWindowListItem = this.c_titemPencere;
            this.c_mnUstMenu.Name = "c_mnUstMenu";
            this.c_mnUstMenu.Size = new System.Drawing.Size(1099, 29);
            this.c_mnUstMenu.TabIndex = 0;
            this.c_mnUstMenu.Text = "Ust Menu";
            // 
            // c_titemDosya
            // 
            this.c_titemDosya.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaProjeDosya,
            this.c_titemDosyaIcra,
            this.c_titemDosyaDava,
            this.c_titemDosyaSorusturma,
            this.c_titemDosyaSozlesme,
            this.c_titemDosyaRucuveHasarBilgileri,
            this.c_titemDosyaBelge,
            this.c_titemDosyaEvrak,
            this.c_titemDosyaGorusme,
            this.c_titemDosyaAjanda,
            this.c_titemDosyaYapilcakIs,
            this.c_titemDosyaKisi,
            this.c_titemDosyaVekalet,
            this.c_titemDosyaHukukMuhasebesi,
            this.toolStripSeparator1,
            this.c_titemDosyaCikis});
            this.c_titemDosya.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosya.Image")));
            this.c_titemDosya.Name = "c_titemDosya";
            this.c_titemDosya.Size = new System.Drawing.Size(65, 25);
            this.c_titemDosya.Text = "Dosya";
            // 
            // c_titemDosyaProjeDosya
            // 
            this.c_titemDosyaProjeDosya.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaProjeDosyaBulProje,
            this.c_titemDosyaProjeDosyaKlasorAra,
            this.c_titemDosyaProjeDosyaYeniProje});
            this.c_titemDosyaProjeDosya.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaProjeDosya.Image")));
            this.c_titemDosyaProjeDosya.Name = "c_titemDosyaProjeDosya";
            this.c_titemDosyaProjeDosya.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaProjeDosya.Text = "Klas�r Y�netimi";
            this.c_titemDosyaProjeDosya.Visible = false;
            // 
            // c_titemDosyaProjeDosyaBulProje
            // 
            this.c_titemDosyaProjeDosyaBulProje.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaProjeDosyaBulProje.Image")));
            this.c_titemDosyaProjeDosyaBulProje.Name = "c_titemDosyaProjeDosyaBulProje";
            this.c_titemDosyaProjeDosyaBulProje.Size = new System.Drawing.Size(218, 22);
            this.c_titemDosyaProjeDosyaBulProje.Text = "Klas�r Y�netimi(Bul,�al��,Yeni)";
            this.c_titemDosyaProjeDosyaBulProje.Click += new System.EventHandler(this.c_titemDosyaProjeDosyaBulProje_Click);
            // 
            // c_titemDosyaProjeDosyaKlasorAra
            // 
            this.c_titemDosyaProjeDosyaKlasorAra.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaProjeDosyaKlasorAra.Image")));
            this.c_titemDosyaProjeDosyaKlasorAra.Name = "c_titemDosyaProjeDosyaKlasorAra";
            this.c_titemDosyaProjeDosyaKlasorAra.Size = new System.Drawing.Size(218, 22);
            this.c_titemDosyaProjeDosyaKlasorAra.Text = "Klas�r Ara";
            this.c_titemDosyaProjeDosyaKlasorAra.Click += new System.EventHandler(this.c_titemDosyaProjeDosyaKlasorAra_Click);
            // 
            // c_titemDosyaProjeDosyaYeniProje
            // 
            this.c_titemDosyaProjeDosyaYeniProje.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaProjeDosyaYeniProje.Image")));
            this.c_titemDosyaProjeDosyaYeniProje.Name = "c_titemDosyaProjeDosyaYeniProje";
            this.c_titemDosyaProjeDosyaYeniProje.Size = new System.Drawing.Size(218, 22);
            this.c_titemDosyaProjeDosyaYeniProje.Text = "Yeni Klas�r Ekle";
            this.c_titemDosyaProjeDosyaYeniProje.Visible = false;
            this.c_titemDosyaProjeDosyaYeniProje.Click += new System.EventHandler(this.c_titemDosyaProjeDosyaYeniProje_Click);
            // 
            // c_titemDosyaIcra
            // 
            this.c_titemDosyaIcra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.icraH�zl�AramaToolStripMenuItem,
            this.c_titemDosyaIcraDosyaBul,
            this.c_titemDosyaIcraYeniIcraKayit});
            this.c_titemDosyaIcra.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaIcra.Image")));
            this.c_titemDosyaIcra.Name = "c_titemDosyaIcra";
            this.c_titemDosyaIcra.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaIcra.Text = "&�cra";
            // 
            // icraH�zl�AramaToolStripMenuItem
            // 
            this.icraH�zl�AramaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("icraH�zl�AramaToolStripMenuItem.Image")));
            this.icraH�zl�AramaToolStripMenuItem.Name = "icraH�zl�AramaToolStripMenuItem";
            this.icraH�zl�AramaToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.icraH�zl�AramaToolStripMenuItem.Text = "�cra Dosyas� Ara";
            this.icraH�zl�AramaToolStripMenuItem.Click += new System.EventHandler(this.icraH�zl�AramaToolStripMenuItem_Click);
            // 
            // c_titemDosyaIcraDosyaBul
            // 
            this.c_titemDosyaIcraDosyaBul.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaIcraDosyaBul.Image")));
            this.c_titemDosyaIcraDosyaBul.Name = "c_titemDosyaIcraDosyaBul";
            this.c_titemDosyaIcraDosyaBul.Size = new System.Drawing.Size(207, 22);
            this.c_titemDosyaIcraDosyaBul.Text = "�cra Dosyas� Geli�mi� Arama";
            this.c_titemDosyaIcraDosyaBul.Click += new System.EventHandler(this.c_titemDosyaIcraDosyaBul_Click);
            // 
            // c_titemDosyaIcraYeniIcraKayit
            // 
            this.c_titemDosyaIcraYeniIcraKayit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaIcraYeniStandartFormIle,
            this.c_titemDosyaIcraYeniSihirbazIle,
            this.c_titemDosyaIcraYeniEditorIle});
            this.c_titemDosyaIcraYeniIcraKayit.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaIcraYeniIcraKayit.Image")));
            this.c_titemDosyaIcraYeniIcraKayit.Name = "c_titemDosyaIcraYeniIcraKayit";
            this.c_titemDosyaIcraYeniIcraKayit.Size = new System.Drawing.Size(207, 22);
            this.c_titemDosyaIcraYeniIcraKayit.Text = "Yeni �cra Dosyas� Ekle";
            // 
            // c_titemDosyaIcraYeniStandartFormIle
            // 
            this.c_titemDosyaIcraYeniStandartFormIle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaIcraYeniStandartFormIle.Image")));
            this.c_titemDosyaIcraYeniStandartFormIle.Name = "c_titemDosyaIcraYeniStandartFormIle";
            this.c_titemDosyaIcraYeniStandartFormIle.Size = new System.Drawing.Size(180, 22);
            this.c_titemDosyaIcraYeniStandartFormIle.Text = "Standart Form �le Ekle";
            this.c_titemDosyaIcraYeniStandartFormIle.Click += new System.EventHandler(this.c_titemDosyaIcraYeniStandartFormIle_Click);
            // 
            // c_titemDosyaIcraYeniSihirbazIle
            // 
            this.c_titemDosyaIcraYeniSihirbazIle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaIcraYeniSihirbazIle.Image")));
            this.c_titemDosyaIcraYeniSihirbazIle.Name = "c_titemDosyaIcraYeniSihirbazIle";
            this.c_titemDosyaIcraYeniSihirbazIle.Size = new System.Drawing.Size(180, 22);
            this.c_titemDosyaIcraYeniSihirbazIle.Text = "Sihirbaz �le Ekle";
            this.c_titemDosyaIcraYeniSihirbazIle.Visible = false;
            this.c_titemDosyaIcraYeniSihirbazIle.Click += new System.EventHandler(this.c_titemDosyaIcraYeniSihirbazIle_Click);
            // 
            // c_titemDosyaIcraYeniEditorIle
            // 
            this.c_titemDosyaIcraYeniEditorIle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaIcraYeniEditorIle.Image")));
            this.c_titemDosyaIcraYeniEditorIle.Name = "c_titemDosyaIcraYeniEditorIle";
            this.c_titemDosyaIcraYeniEditorIle.Size = new System.Drawing.Size(180, 22);
            this.c_titemDosyaIcraYeniEditorIle.Text = "Edit�r �le Ekle";
            this.c_titemDosyaIcraYeniEditorIle.Visible = false;
            // 
            // c_titemDosyaDava
            // 
            this.c_titemDosyaDava.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaDavaDosyaBul,
            this.c_titemDosyaDavaDosyaGelismisBul,
            this.c_titemDosyaDavaYeniDava,
            this.c_titemDosyaDegisikIsler,
            this.duru�maKe�ifAraToolStripMenuItem});
            this.c_titemDosyaDava.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDava.Image")));
            this.c_titemDosyaDava.Name = "c_titemDosyaDava";
            this.c_titemDosyaDava.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaDava.Text = "Dava";
            // 
            // c_titemDosyaDavaDosyaBul
            // 
            this.c_titemDosyaDavaDosyaBul.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDavaDosyaBul.Image")));
            this.c_titemDosyaDavaDosyaBul.Name = "c_titemDosyaDavaDosyaBul";
            this.c_titemDosyaDavaDosyaBul.Size = new System.Drawing.Size(213, 22);
            this.c_titemDosyaDavaDosyaBul.Text = "Dava Dosyas� Ara";
            this.c_titemDosyaDavaDosyaBul.Click += new System.EventHandler(this.c_titemDosyaDavaDosyaBul_Click);
            // 
            // c_titemDosyaDavaDosyaGelismisBul
            // 
            this.c_titemDosyaDavaDosyaGelismisBul.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDavaDosyaGelismisBul.Image")));
            this.c_titemDosyaDavaDosyaGelismisBul.Name = "c_titemDosyaDavaDosyaGelismisBul";
            this.c_titemDosyaDavaDosyaGelismisBul.Size = new System.Drawing.Size(213, 22);
            this.c_titemDosyaDavaDosyaGelismisBul.Text = "Dava Dosyas� Geli�mi� Arama";
            this.c_titemDosyaDavaDosyaGelismisBul.Click += new System.EventHandler(this.c_titemDosyaDavaDosyaGelismisBul_Click);
            // 
            // c_titemDosyaDavaYeniDava
            // 
            this.c_titemDosyaDavaYeniDava.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaDavaEkleStandartFormIle,
            this.c_titemDosyaDavaYeniSihirbazIle,
            this.c_titemDosyaDavaYeniEditorIle});
            this.c_titemDosyaDavaYeniDava.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDavaYeniDava.Image")));
            this.c_titemDosyaDavaYeniDava.Name = "c_titemDosyaDavaYeniDava";
            this.c_titemDosyaDavaYeniDava.Size = new System.Drawing.Size(213, 22);
            this.c_titemDosyaDavaYeniDava.Text = "Yeni Dava Dosyas� Ekle";
            // 
            // c_titemDosyaDavaEkleStandartFormIle
            // 
            this.c_titemDosyaDavaEkleStandartFormIle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDavaEkleStandartFormIle.Image")));
            this.c_titemDosyaDavaEkleStandartFormIle.Name = "c_titemDosyaDavaEkleStandartFormIle";
            this.c_titemDosyaDavaEkleStandartFormIle.Size = new System.Drawing.Size(180, 22);
            this.c_titemDosyaDavaEkleStandartFormIle.Text = "Standart Form �le Ekle";
            this.c_titemDosyaDavaEkleStandartFormIle.Click += new System.EventHandler(this.c_titemDosyaDavaEkleStandartFormIle_Click);
            // 
            // c_titemDosyaDavaYeniSihirbazIle
            // 
            this.c_titemDosyaDavaYeniSihirbazIle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDavaYeniSihirbazIle.Image")));
            this.c_titemDosyaDavaYeniSihirbazIle.Name = "c_titemDosyaDavaYeniSihirbazIle";
            this.c_titemDosyaDavaYeniSihirbazIle.Size = new System.Drawing.Size(180, 22);
            this.c_titemDosyaDavaYeniSihirbazIle.Text = "Sihirbaz �le Ekle";
            this.c_titemDosyaDavaYeniSihirbazIle.Visible = false;
            // 
            // c_titemDosyaDavaYeniEditorIle
            // 
            this.c_titemDosyaDavaYeniEditorIle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDavaYeniEditorIle.Image")));
            this.c_titemDosyaDavaYeniEditorIle.Name = "c_titemDosyaDavaYeniEditorIle";
            this.c_titemDosyaDavaYeniEditorIle.Size = new System.Drawing.Size(180, 22);
            this.c_titemDosyaDavaYeniEditorIle.Text = "Edit�r �le Ekle";
            this.c_titemDosyaDavaYeniEditorIle.Visible = false;
            // 
            // c_titemDosyaDegisikIsler
            // 
            this.c_titemDosyaDegisikIsler.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaDegisikIslerDosyasiBul,
            this.c_titemDosyaDegisikIslerIhtiyatiHaciz,
            this.c_titemDosyaDegisikIslerIhtiyatiTedbir,
            this.c_titemDosyaDegisikIslerTespitKaydet,
            this.teminatMektuplar�ToolStripMenuItem});
            this.c_titemDosyaDegisikIsler.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDegisikIsler.Image")));
            this.c_titemDosyaDegisikIsler.Name = "c_titemDosyaDegisikIsler";
            this.c_titemDosyaDegisikIsler.Size = new System.Drawing.Size(213, 22);
            this.c_titemDosyaDegisikIsler.Text = "De�i�ik ��ler";
            // 
            // c_titemDosyaDegisikIslerDosyasiBul
            // 
            this.c_titemDosyaDegisikIslerDosyasiBul.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ihtiyatiHacizToolStripMenuItem,
            this.ihtiyatiTedbirToolStripMenuItem});
            this.c_titemDosyaDegisikIslerDosyasiBul.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDegisikIslerDosyasiBul.Image")));
            this.c_titemDosyaDegisikIslerDosyasiBul.Name = "c_titemDosyaDegisikIslerDosyasiBul";
            this.c_titemDosyaDegisikIslerDosyasiBul.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaDegisikIslerDosyasiBul.Text = "De�i�ik �� Dosyas� Ara";
            this.c_titemDosyaDegisikIslerDosyasiBul.Visible = false;
            // 
            // ihtiyatiHacizToolStripMenuItem
            // 
            this.ihtiyatiHacizToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ihtiyatiHacizToolStripMenuItem.Image")));
            this.ihtiyatiHacizToolStripMenuItem.Name = "ihtiyatiHacizToolStripMenuItem";
            this.ihtiyatiHacizToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.ihtiyatiHacizToolStripMenuItem.Text = "�htiyati Haciz";
            this.ihtiyatiHacizToolStripMenuItem.Click += new System.EventHandler(this.ihtiyatiHacizToolStripMenuItem_Click);
            // 
            // ihtiyatiTedbirToolStripMenuItem
            // 
            this.ihtiyatiTedbirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ihtiyatiTedbirToolStripMenuItem.Image")));
            this.ihtiyatiTedbirToolStripMenuItem.Name = "ihtiyatiTedbirToolStripMenuItem";
            this.ihtiyatiTedbirToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.ihtiyatiTedbirToolStripMenuItem.Text = "�htiyati Tedbir";
            this.ihtiyatiTedbirToolStripMenuItem.Click += new System.EventHandler(this.ihtiyatiTedbirToolStripMenuItem_Click);
            // 
            // c_titemDosyaDegisikIslerIhtiyatiHaciz
            // 
            this.c_titemDosyaDegisikIslerIhtiyatiHaciz.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDegisikIslerIhtiyatiHaciz.Image")));
            this.c_titemDosyaDegisikIslerIhtiyatiHaciz.Name = "c_titemDosyaDegisikIslerIhtiyatiHaciz";
            this.c_titemDosyaDegisikIslerIhtiyatiHaciz.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaDegisikIslerIhtiyatiHaciz.Text = "�htiyati Haciz Kaydet";
            this.c_titemDosyaDegisikIslerIhtiyatiHaciz.Click += new System.EventHandler(this.c_titemDosyaDegisikIslerIhtiyatiHaciz_Click);
            // 
            // c_titemDosyaDegisikIslerIhtiyatiTedbir
            // 
            this.c_titemDosyaDegisikIslerIhtiyatiTedbir.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDegisikIslerIhtiyatiTedbir.Image")));
            this.c_titemDosyaDegisikIslerIhtiyatiTedbir.Name = "c_titemDosyaDegisikIslerIhtiyatiTedbir";
            this.c_titemDosyaDegisikIslerIhtiyatiTedbir.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaDegisikIslerIhtiyatiTedbir.Text = "�htiyati Tedbir Kaydet";
            this.c_titemDosyaDegisikIslerIhtiyatiTedbir.Click += new System.EventHandler(this.c_titemDosyaDegisikIslerIhtiyatiTedbir_Click);
            // 
            // c_titemDosyaDegisikIslerTespitKaydet
            // 
            this.c_titemDosyaDegisikIslerTespitKaydet.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDegisikIslerTespitKaydet.Image")));
            this.c_titemDosyaDegisikIslerTespitKaydet.Name = "c_titemDosyaDegisikIslerTespitKaydet";
            this.c_titemDosyaDegisikIslerTespitKaydet.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaDegisikIslerTespitKaydet.Text = "Tespit Kaydet";
            this.c_titemDosyaDegisikIslerTespitKaydet.Click += new System.EventHandler(this.c_titemDosyaDegisikIslerTespitKaydet_Click);
            // 
            // teminatMektuplar�ToolStripMenuItem
            // 
            this.teminatMektuplar�ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("teminatMektuplar�ToolStripMenuItem.Image")));
            this.teminatMektuplar�ToolStripMenuItem.Name = "teminatMektuplar�ToolStripMenuItem";
            this.teminatMektuplar�ToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.teminatMektuplar�ToolStripMenuItem.Text = "Teminat Mektuplar�";
            this.teminatMektuplar�ToolStripMenuItem.Click += new System.EventHandler(this.teminatMektuplar�ToolStripMenuItem_Click);
            // 
            // duru�maKe�ifAraToolStripMenuItem
            // 
            this.duru�maKe�ifAraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("duru�maKe�ifAraToolStripMenuItem.Image")));
            this.duru�maKe�ifAraToolStripMenuItem.Name = "duru�maKe�ifAraToolStripMenuItem";
            this.duru�maKe�ifAraToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.duru�maKe�ifAraToolStripMenuItem.Text = "Duru�ma - Ke�if Ara";
            this.duru�maKe�ifAraToolStripMenuItem.Click += new System.EventHandler(this.durusmaKesifAraToolStripMenuItem_Click);
            // 
            // c_titemDosyaSorusturma
            // 
            this.c_titemDosyaSorusturma.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaDavaSorusturmaBul,
            this.c_titemDosyaSorusturmaYeni});
            this.c_titemDosyaSorusturma.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSorusturma.Image")));
            this.c_titemDosyaSorusturma.Name = "c_titemDosyaSorusturma";
            this.c_titemDosyaSorusturma.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaSorusturma.Text = "Soru�turma";
            // 
            // c_titemDosyaDavaSorusturmaBul
            // 
            this.c_titemDosyaDavaSorusturmaBul.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaDavaSorusturmaBul.Image")));
            this.c_titemDosyaDavaSorusturmaBul.Name = "c_titemDosyaDavaSorusturmaBul";
            this.c_titemDosyaDavaSorusturmaBul.Size = new System.Drawing.Size(214, 22);
            this.c_titemDosyaDavaSorusturmaBul.Text = "Soru�turma Dosyas� Ara";
            this.c_titemDosyaDavaSorusturmaBul.Click += new System.EventHandler(this.c_titemDosyaDavaSorusturmaBul_Click);
            // 
            // c_titemDosyaSorusturmaYeni
            // 
            this.c_titemDosyaSorusturmaYeni.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaSorusturmaYeniStandartFormIle,
            this.c_titemDosyaSorusturmaYeniSihirbazFormIle,
            this.c_titemDosyaSorusturmaYeniEditorIle});
            this.c_titemDosyaSorusturmaYeni.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSorusturmaYeni.Image")));
            this.c_titemDosyaSorusturmaYeni.Name = "c_titemDosyaSorusturmaYeni";
            this.c_titemDosyaSorusturmaYeni.Size = new System.Drawing.Size(214, 22);
            this.c_titemDosyaSorusturmaYeni.Text = "Yeni Soru�turma Dosyas� Ekle";
            // 
            // c_titemDosyaSorusturmaYeniStandartFormIle
            // 
            this.c_titemDosyaSorusturmaYeniStandartFormIle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSorusturmaYeniStandartFormIle.Image")));
            this.c_titemDosyaSorusturmaYeniStandartFormIle.Name = "c_titemDosyaSorusturmaYeniStandartFormIle";
            this.c_titemDosyaSorusturmaYeniStandartFormIle.Size = new System.Drawing.Size(180, 22);
            this.c_titemDosyaSorusturmaYeniStandartFormIle.Text = "Standart Form �le Ekle";
            this.c_titemDosyaSorusturmaYeniStandartFormIle.Click += new System.EventHandler(this.c_titemDosyaSorusturmaYeniStandartFormIle_Click);
            // 
            // c_titemDosyaSorusturmaYeniSihirbazFormIle
            // 
            this.c_titemDosyaSorusturmaYeniSihirbazFormIle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSorusturmaYeniSihirbazFormIle.Image")));
            this.c_titemDosyaSorusturmaYeniSihirbazFormIle.Name = "c_titemDosyaSorusturmaYeniSihirbazFormIle";
            this.c_titemDosyaSorusturmaYeniSihirbazFormIle.Size = new System.Drawing.Size(180, 22);
            this.c_titemDosyaSorusturmaYeniSihirbazFormIle.Text = "Sihirbaz Form �le Ekle";
            this.c_titemDosyaSorusturmaYeniSihirbazFormIle.Visible = false;
            // 
            // c_titemDosyaSorusturmaYeniEditorIle
            // 
            this.c_titemDosyaSorusturmaYeniEditorIle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSorusturmaYeniEditorIle.Image")));
            this.c_titemDosyaSorusturmaYeniEditorIle.Name = "c_titemDosyaSorusturmaYeniEditorIle";
            this.c_titemDosyaSorusturmaYeniEditorIle.Size = new System.Drawing.Size(180, 22);
            this.c_titemDosyaSorusturmaYeniEditorIle.Text = "Edit�r �le Ekle";
            this.c_titemDosyaSorusturmaYeniEditorIle.Visible = false;
            // 
            // c_titemDosyaSozlesme
            // 
            this.c_titemDosyaSozlesme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaSozlesmeBul,
            this.c_titemDosyaSozlesmeYenie});
            this.c_titemDosyaSozlesme.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSozlesme.Image")));
            this.c_titemDosyaSozlesme.Name = "c_titemDosyaSozlesme";
            this.c_titemDosyaSozlesme.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaSozlesme.Text = "S�zle�me";
            // 
            // c_titemDosyaSozlesmeBul
            // 
            this.c_titemDosyaSozlesmeBul.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSozlesmeBul.Image")));
            this.c_titemDosyaSozlesmeBul.Name = "c_titemDosyaSozlesmeBul";
            this.c_titemDosyaSozlesmeBul.Size = new System.Drawing.Size(167, 22);
            this.c_titemDosyaSozlesmeBul.Text = "S�zle�me Kayd� Ara";
            this.c_titemDosyaSozlesmeBul.Click += new System.EventHandler(this.c_titemDosyaSozlesmeBul_Click);
            // 
            // c_titemDosyaSozlesmeYenie
            // 
            this.c_titemDosyaSozlesmeYenie.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaSozlesmeYeniStandartFormIleEkle,
            this.krediS�zle�mesiEkleToolStripMenuItem,
            this.krediToolStripMenuItem,
            this.genelS�zle�meToolStripMenuItem,
            this.markaPatentS�zle�mesiToolStripMenuItem,
            this.hakemS�zle�mesiToolStripMenuItem,
            this.c_titemDosyaSozlesmeYeniSihirbazFormIleEkle,
            this.c_titemDosyaSozlesmeYeniEditorIleEkle});
            this.c_titemDosyaSozlesmeYenie.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSozlesmeYenie.Image")));
            this.c_titemDosyaSozlesmeYenie.Name = "c_titemDosyaSozlesmeYenie";
            this.c_titemDosyaSozlesmeYenie.Size = new System.Drawing.Size(167, 22);
            this.c_titemDosyaSozlesmeYenie.Text = "S�zle�me Kaydet";
            // 
            // c_titemDosyaSozlesmeYeniStandartFormIleEkle
            // 
            this.c_titemDosyaSozlesmeYeniStandartFormIleEkle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSozlesmeYeniStandartFormIleEkle.Image")));
            this.c_titemDosyaSozlesmeYeniStandartFormIleEkle.Name = "c_titemDosyaSozlesmeYeniStandartFormIleEkle";
            this.c_titemDosyaSozlesmeYeniStandartFormIleEkle.Size = new System.Drawing.Size(224, 22);
            this.c_titemDosyaSozlesmeYeniStandartFormIleEkle.Text = "Kira S�zle�mesi Ekle";
            this.c_titemDosyaSozlesmeYeniStandartFormIleEkle.Click += new System.EventHandler(this.c_titemDosyaSozlesmeYeniStandartFormIleEkle_Click);
            // 
            // krediS�zle�mesiEkleToolStripMenuItem
            // 
            this.krediS�zle�mesiEkleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.krediKart�S�zle�mesiToolStripMenuItem,
            this.genelKrediS�zle�mesiToolStripMenuItem,
            this.finansmanS�zle�mesiToolStripMenuItem,
            this.hesapRehinS�zle�mesiToolStripMenuItem,
            this.bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem,
            this.krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem,
            this.krediKart��yelikS�zle�mesiToolStripMenuItem,
            this.krediliMenkulK�ymetS�zle�mesiToolStripMenuItem,
            this.genelKrediTaahh�tnamesiToolStripMenuItem,
            this.bankac�l�kHizmetS�zle�mesiToolStripMenuItem,
            this.konutKredisiS�zle�mesiToolStripMenuItem,
            this.ihtiya�KredisiToolStripMenuItem,
            this.ta��tKredisiToolStripMenuItem});
            this.krediS�zle�mesiEkleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("krediS�zle�mesiEkleToolStripMenuItem.Image")));
            this.krediS�zle�mesiEkleToolStripMenuItem.Name = "krediS�zle�mesiEkleToolStripMenuItem";
            this.krediS�zle�mesiEkleToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.krediS�zle�mesiEkleToolStripMenuItem.Text = "Kredi  S�zle�mesi Ekle";
            this.krediS�zle�mesiEkleToolStripMenuItem.Click += new System.EventHandler(this.krediS�zle�mesiEkleToolStripMenuItem_Click);
            // 
            // krediKart�S�zle�mesiToolStripMenuItem
            // 
            this.krediKart�S�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("krediKart�S�zle�mesiToolStripMenuItem.Image")));
            this.krediKart�S�zle�mesiToolStripMenuItem.Name = "krediKart�S�zle�mesiToolStripMenuItem";
            this.krediKart�S�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.krediKart�S�zle�mesiToolStripMenuItem.Tag = "4";
            this.krediKart�S�zle�mesiToolStripMenuItem.Text = "Kredi Kart� S�zle�mesi  Ekle";
            this.krediKart�S�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // genelKrediS�zle�mesiToolStripMenuItem
            // 
            this.genelKrediS�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("genelKrediS�zle�mesiToolStripMenuItem.Image")));
            this.genelKrediS�zle�mesiToolStripMenuItem.Name = "genelKrediS�zle�mesiToolStripMenuItem";
            this.genelKrediS�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.genelKrediS�zle�mesiToolStripMenuItem.Tag = "14";
            this.genelKrediS�zle�mesiToolStripMenuItem.Text = "Genel Kredi S�zle�mesi  Ekle";
            this.genelKrediS�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // finansmanS�zle�mesiToolStripMenuItem
            // 
            this.finansmanS�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("finansmanS�zle�mesiToolStripMenuItem.Image")));
            this.finansmanS�zle�mesiToolStripMenuItem.Name = "finansmanS�zle�mesiToolStripMenuItem";
            this.finansmanS�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.finansmanS�zle�mesiToolStripMenuItem.Tag = "71";
            this.finansmanS�zle�mesiToolStripMenuItem.Text = "Finansman S�zle�mesi  Ekle";
            this.finansmanS�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // hesapRehinS�zle�mesiToolStripMenuItem
            // 
            this.hesapRehinS�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hesapRehinS�zle�mesiToolStripMenuItem.Image")));
            this.hesapRehinS�zle�mesiToolStripMenuItem.Name = "hesapRehinS�zle�mesiToolStripMenuItem";
            this.hesapRehinS�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.hesapRehinS�zle�mesiToolStripMenuItem.Tag = "83";
            this.hesapRehinS�zle�mesiToolStripMenuItem.Text = "Hesap Rehin S�zle�mesi  Ekle";
            this.hesapRehinS�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem
            // 
            this.bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem.Image")));
            this.bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem.Name = "bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem";
            this.bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem.Tag = "179";
            this.bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem.Text = "Bireysel Bankac�l�k Hizmet S�zle�mesi  Ekle";
            this.bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem
            // 
            this.krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem.Image")));
            this.krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem.Name = "krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem";
            this.krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem.Tag = "115";
            this.krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem.Text = "Kredi Kart� �ye ��yeri Program� S�zle�mesi  Ekle";
            this.krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // krediKart��yelikS�zle�mesiToolStripMenuItem
            // 
            this.krediKart��yelikS�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("krediKart��yelikS�zle�mesiToolStripMenuItem.Image")));
            this.krediKart��yelikS�zle�mesiToolStripMenuItem.Name = "krediKart��yelikS�zle�mesiToolStripMenuItem";
            this.krediKart��yelikS�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.krediKart��yelikS�zle�mesiToolStripMenuItem.Tag = "116";
            this.krediKart��yelikS�zle�mesiToolStripMenuItem.Text = "Kredi Kart� �yelik S�zle�mesi  Ekle";
            this.krediKart��yelikS�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // krediliMenkulK�ymetS�zle�mesiToolStripMenuItem
            // 
            this.krediliMenkulK�ymetS�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("krediliMenkulK�ymetS�zle�mesiToolStripMenuItem.Image")));
            this.krediliMenkulK�ymetS�zle�mesiToolStripMenuItem.Name = "krediliMenkulK�ymetS�zle�mesiToolStripMenuItem";
            this.krediliMenkulK�ymetS�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.krediliMenkulK�ymetS�zle�mesiToolStripMenuItem.Tag = "117";
            this.krediliMenkulK�ymetS�zle�mesiToolStripMenuItem.Text = "Kredili Menkul K�ymet S�zle�mesi  Ekle";
            this.krediliMenkulK�ymetS�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // genelKrediTaahh�tnamesiToolStripMenuItem
            // 
            this.genelKrediTaahh�tnamesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("genelKrediTaahh�tnamesiToolStripMenuItem.Image")));
            this.genelKrediTaahh�tnamesiToolStripMenuItem.Name = "genelKrediTaahh�tnamesiToolStripMenuItem";
            this.genelKrediTaahh�tnamesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.genelKrediTaahh�tnamesiToolStripMenuItem.Tag = "167";
            this.genelKrediTaahh�tnamesiToolStripMenuItem.Text = "Genel Kredi Taahh�tnamesi  Ekle";
            this.genelKrediTaahh�tnamesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // bankac�l�kHizmetS�zle�mesiToolStripMenuItem
            // 
            this.bankac�l�kHizmetS�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bankac�l�kHizmetS�zle�mesiToolStripMenuItem.Image")));
            this.bankac�l�kHizmetS�zle�mesiToolStripMenuItem.Name = "bankac�l�kHizmetS�zle�mesiToolStripMenuItem";
            this.bankac�l�kHizmetS�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.bankac�l�kHizmetS�zle�mesiToolStripMenuItem.Tag = "168";
            this.bankac�l�kHizmetS�zle�mesiToolStripMenuItem.Text = "Bankac�l�k Hizmet S�zle�mesi  Ekle";
            this.bankac�l�kHizmetS�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // konutKredisiS�zle�mesiToolStripMenuItem
            // 
            this.konutKredisiS�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("konutKredisiS�zle�mesiToolStripMenuItem.Image")));
            this.konutKredisiS�zle�mesiToolStripMenuItem.Name = "konutKredisiS�zle�mesiToolStripMenuItem";
            this.konutKredisiS�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.konutKredisiS�zle�mesiToolStripMenuItem.Tag = "169";
            this.konutKredisiS�zle�mesiToolStripMenuItem.Text = "Konut Kredisi S�zle�mesi  Ekle";
            this.konutKredisiS�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // ihtiya�KredisiToolStripMenuItem
            // 
            this.ihtiya�KredisiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ihtiya�KredisiToolStripMenuItem.Image")));
            this.ihtiya�KredisiToolStripMenuItem.Name = "ihtiya�KredisiToolStripMenuItem";
            this.ihtiya�KredisiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.ihtiya�KredisiToolStripMenuItem.Tag = "170";
            this.ihtiya�KredisiToolStripMenuItem.Text = "�htiya� Kredisi  Ekle";
            this.ihtiya�KredisiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // ta��tKredisiToolStripMenuItem
            // 
            this.ta��tKredisiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ta��tKredisiToolStripMenuItem.Image")));
            this.ta��tKredisiToolStripMenuItem.Name = "ta��tKredisiToolStripMenuItem";
            this.ta��tKredisiToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.ta��tKredisiToolStripMenuItem.Tag = "171";
            this.ta��tKredisiToolStripMenuItem.Text = "Ta��t Kredisi  Ekle";
            this.ta��tKredisiToolStripMenuItem.Click += new System.EventHandler(this.krediKart�S�zle�mesiToolStripMenuItem_Click);
            // 
            // krediToolStripMenuItem
            // 
            this.krediToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gayrimenkul�pote�iToolStripMenuItem,
            this.gemi�pote�iToolStripMenuItem,
            this.havaArac��pote�iToolStripMenuItem,
            this.ara�RehniToolStripMenuItem,
            this.ticari��letmeRehniToolStripMenuItem,
            this.menkulMalRehniToolStripMenuItem,
            this.menkulK�ymetRehniToolStripMenuItem,
            this.mevduatRehniToolStripMenuItem,
            this.ticariSenetRehniToolStripMenuItem,
            this.hatRehniToolStripMenuItem,
            this.markaRehniToolStripMenuItem,
            this.ticariPlakaRehniToolStripMenuItem,
            this.kanbiyoSenediRehniToolStripMenuItem,
            this.hisseSenediRehniToolStripMenuItem});
            this.krediToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("krediToolStripMenuItem.Image")));
            this.krediToolStripMenuItem.Name = "krediToolStripMenuItem";
            this.krediToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.krediToolStripMenuItem.Text = "Resmi Senet Ekle";
            // 
            // gayrimenkul�pote�iToolStripMenuItem
            // 
            this.gayrimenkul�pote�iToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gayrimenkul�pote�iToolStripMenuItem.Image")));
            this.gayrimenkul�pote�iToolStripMenuItem.Name = "gayrimenkul�pote�iToolStripMenuItem";
            this.gayrimenkul�pote�iToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.gayrimenkul�pote�iToolStripMenuItem.Tag = "5";
            this.gayrimenkul�pote�iToolStripMenuItem.Text = "Gayrimenkul �pote�i  Ekle";
            this.gayrimenkul�pote�iToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // gemi�pote�iToolStripMenuItem
            // 
            this.gemi�pote�iToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gemi�pote�iToolStripMenuItem.Image")));
            this.gemi�pote�iToolStripMenuItem.Name = "gemi�pote�iToolStripMenuItem";
            this.gemi�pote�iToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.gemi�pote�iToolStripMenuItem.Tag = "6";
            this.gemi�pote�iToolStripMenuItem.Text = "Gemi �pote�i  Ekle";
            this.gemi�pote�iToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // havaArac��pote�iToolStripMenuItem
            // 
            this.havaArac��pote�iToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("havaArac��pote�iToolStripMenuItem.Image")));
            this.havaArac��pote�iToolStripMenuItem.Name = "havaArac��pote�iToolStripMenuItem";
            this.havaArac��pote�iToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.havaArac��pote�iToolStripMenuItem.Tag = "7";
            this.havaArac��pote�iToolStripMenuItem.Text = "Hava Arac� �pote�i  Ekle";
            this.havaArac��pote�iToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // ara�RehniToolStripMenuItem
            // 
            this.ara�RehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ara�RehniToolStripMenuItem.Image")));
            this.ara�RehniToolStripMenuItem.Name = "ara�RehniToolStripMenuItem";
            this.ara�RehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ara�RehniToolStripMenuItem.Tag = "8";
            this.ara�RehniToolStripMenuItem.Text = "Ara� Rehni  Ekle";
            this.ara�RehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // ticari��letmeRehniToolStripMenuItem
            // 
            this.ticari��letmeRehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ticari��letmeRehniToolStripMenuItem.Image")));
            this.ticari��letmeRehniToolStripMenuItem.Name = "ticari��letmeRehniToolStripMenuItem";
            this.ticari��letmeRehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ticari��letmeRehniToolStripMenuItem.Tag = "9";
            this.ticari��letmeRehniToolStripMenuItem.Text = "Ticari ��letme Rehni  Ekle";
            this.ticari��letmeRehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // menkulMalRehniToolStripMenuItem
            // 
            this.menkulMalRehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("menkulMalRehniToolStripMenuItem.Image")));
            this.menkulMalRehniToolStripMenuItem.Name = "menkulMalRehniToolStripMenuItem";
            this.menkulMalRehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.menkulMalRehniToolStripMenuItem.Tag = "10";
            this.menkulMalRehniToolStripMenuItem.Text = "Menkul Mal Rehni  Ekle";
            this.menkulMalRehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // menkulK�ymetRehniToolStripMenuItem
            // 
            this.menkulK�ymetRehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("menkulK�ymetRehniToolStripMenuItem.Image")));
            this.menkulK�ymetRehniToolStripMenuItem.Name = "menkulK�ymetRehniToolStripMenuItem";
            this.menkulK�ymetRehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.menkulK�ymetRehniToolStripMenuItem.Tag = "11";
            this.menkulK�ymetRehniToolStripMenuItem.Text = "Menkul K�ymet Rehni  Ekle";
            this.menkulK�ymetRehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // mevduatRehniToolStripMenuItem
            // 
            this.mevduatRehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mevduatRehniToolStripMenuItem.Image")));
            this.mevduatRehniToolStripMenuItem.Name = "mevduatRehniToolStripMenuItem";
            this.mevduatRehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.mevduatRehniToolStripMenuItem.Tag = "12";
            this.mevduatRehniToolStripMenuItem.Text = "Mevduat Rehni  Ekle";
            this.mevduatRehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // ticariSenetRehniToolStripMenuItem
            // 
            this.ticariSenetRehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ticariSenetRehniToolStripMenuItem.Image")));
            this.ticariSenetRehniToolStripMenuItem.Name = "ticariSenetRehniToolStripMenuItem";
            this.ticariSenetRehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ticariSenetRehniToolStripMenuItem.Tag = "13";
            this.ticariSenetRehniToolStripMenuItem.Text = "Ticari Senet Rehni  Ekle";
            this.ticariSenetRehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // hatRehniToolStripMenuItem
            // 
            this.hatRehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hatRehniToolStripMenuItem.Image")));
            this.hatRehniToolStripMenuItem.Name = "hatRehniToolStripMenuItem";
            this.hatRehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.hatRehniToolStripMenuItem.Tag = "172";
            this.hatRehniToolStripMenuItem.Text = "Hat Rehni  Ekle";
            this.hatRehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // markaRehniToolStripMenuItem
            // 
            this.markaRehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("markaRehniToolStripMenuItem.Image")));
            this.markaRehniToolStripMenuItem.Name = "markaRehniToolStripMenuItem";
            this.markaRehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.markaRehniToolStripMenuItem.Tag = "173";
            this.markaRehniToolStripMenuItem.Text = "Marka Rehni  Ekle";
            this.markaRehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // ticariPlakaRehniToolStripMenuItem
            // 
            this.ticariPlakaRehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ticariPlakaRehniToolStripMenuItem.Image")));
            this.ticariPlakaRehniToolStripMenuItem.Name = "ticariPlakaRehniToolStripMenuItem";
            this.ticariPlakaRehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ticariPlakaRehniToolStripMenuItem.Tag = "174";
            this.ticariPlakaRehniToolStripMenuItem.Text = "Ticari Plaka Rehni  Ekle";
            this.ticariPlakaRehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // kanbiyoSenediRehniToolStripMenuItem
            // 
            this.kanbiyoSenediRehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kanbiyoSenediRehniToolStripMenuItem.Image")));
            this.kanbiyoSenediRehniToolStripMenuItem.Name = "kanbiyoSenediRehniToolStripMenuItem";
            this.kanbiyoSenediRehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.kanbiyoSenediRehniToolStripMenuItem.Tag = "176";
            this.kanbiyoSenediRehniToolStripMenuItem.Text = "Kanbiyo Senedi Rehni  Ekle";
            this.kanbiyoSenediRehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // hisseSenediRehniToolStripMenuItem
            // 
            this.hisseSenediRehniToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hisseSenediRehniToolStripMenuItem.Image")));
            this.hisseSenediRehniToolStripMenuItem.Name = "hisseSenediRehniToolStripMenuItem";
            this.hisseSenediRehniToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.hisseSenediRehniToolStripMenuItem.Tag = "175";
            this.hisseSenediRehniToolStripMenuItem.Text = "Hisse Senedi Rehni  Ekle";
            this.hisseSenediRehniToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkul�pote�iToolStripMenuItem_Click);
            // 
            // genelS�zle�meToolStripMenuItem
            // 
            this.genelS�zle�meToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("genelS�zle�meToolStripMenuItem.Image")));
            this.genelS�zle�meToolStripMenuItem.Name = "genelS�zle�meToolStripMenuItem";
            this.genelS�zle�meToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.genelS�zle�meToolStripMenuItem.Text = "Genel S�zle�me S�zle�mesi Ekle";
            this.genelS�zle�meToolStripMenuItem.Click += new System.EventHandler(this.genelS�zle�meToolStripMenuItem_Click);
            // 
            // markaPatentS�zle�mesiToolStripMenuItem
            // 
            this.markaPatentS�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("markaPatentS�zle�mesiToolStripMenuItem.Image")));
            this.markaPatentS�zle�mesiToolStripMenuItem.Name = "markaPatentS�zle�mesiToolStripMenuItem";
            this.markaPatentS�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.markaPatentS�zle�mesiToolStripMenuItem.Text = "Marka Patent S�zle�mesi Ekle";
            this.markaPatentS�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.markaPatentS�zle�mesiToolStripMenuItem_Click);
            // 
            // hakemS�zle�mesiToolStripMenuItem
            // 
            this.hakemS�zle�mesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hakemS�zle�mesiToolStripMenuItem.Image")));
            this.hakemS�zle�mesiToolStripMenuItem.Name = "hakemS�zle�mesiToolStripMenuItem";
            this.hakemS�zle�mesiToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.hakemS�zle�mesiToolStripMenuItem.Text = "Hakem S�zle�mesi Ekle";
            this.hakemS�zle�mesiToolStripMenuItem.Click += new System.EventHandler(this.hakemS�zle�mesiToolStripMenuItem_Click);
            // 
            // c_titemDosyaSozlesmeYeniSihirbazFormIleEkle
            // 
            this.c_titemDosyaSozlesmeYeniSihirbazFormIleEkle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSozlesmeYeniSihirbazFormIleEkle.Image")));
            this.c_titemDosyaSozlesmeYeniSihirbazFormIleEkle.Name = "c_titemDosyaSozlesmeYeniSihirbazFormIleEkle";
            this.c_titemDosyaSozlesmeYeniSihirbazFormIleEkle.Size = new System.Drawing.Size(224, 22);
            this.c_titemDosyaSozlesmeYeniSihirbazFormIleEkle.Text = "Sihirbaz �le Ekle";
            this.c_titemDosyaSozlesmeYeniSihirbazFormIleEkle.Visible = false;
            // 
            // c_titemDosyaSozlesmeYeniEditorIleEkle
            // 
            this.c_titemDosyaSozlesmeYeniEditorIleEkle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaSozlesmeYeniEditorIleEkle.Image")));
            this.c_titemDosyaSozlesmeYeniEditorIleEkle.Name = "c_titemDosyaSozlesmeYeniEditorIleEkle";
            this.c_titemDosyaSozlesmeYeniEditorIleEkle.Size = new System.Drawing.Size(224, 22);
            this.c_titemDosyaSozlesmeYeniEditorIleEkle.Text = "Edit�r �le Ekle";
            this.c_titemDosyaSozlesmeYeniEditorIleEkle.Visible = false;
            // 
            // c_titemDosyaRucuveHasarBilgileri
            // 
            this.c_titemDosyaRucuveHasarBilgileri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaRucuHasarPoliceveHaqsarBilgileri,
            this.c_titemDosyaRucuveHasarRucuBilgileri});
            this.c_titemDosyaRucuveHasarBilgileri.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaRucuveHasarBilgileri.Image")));
            this.c_titemDosyaRucuveHasarBilgileri.Name = "c_titemDosyaRucuveHasarBilgileri";
            this.c_titemDosyaRucuveHasarBilgileri.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaRucuveHasarBilgileri.Text = "R�cu ve Hasar Bilgileri";
            this.c_titemDosyaRucuveHasarBilgileri.Visible = false;
            // 
            // c_titemDosyaRucuHasarPoliceveHaqsarBilgileri
            // 
            this.c_titemDosyaRucuHasarPoliceveHaqsarBilgileri.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaRucuHasarPoliceveHaqsarBilgileri.Image")));
            this.c_titemDosyaRucuHasarPoliceveHaqsarBilgileri.Name = "c_titemDosyaRucuHasarPoliceveHaqsarBilgileri";
            this.c_titemDosyaRucuHasarPoliceveHaqsarBilgileri.Size = new System.Drawing.Size(182, 22);
            this.c_titemDosyaRucuHasarPoliceveHaqsarBilgileri.Text = "Hasar ve Poli�e Bilgileri";
            // 
            // c_titemDosyaRucuveHasarRucuBilgileri
            // 
            this.c_titemDosyaRucuveHasarRucuBilgileri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaRucuveHasarRucuBilgileriRucuBul,
            this.c_titemDosyaRucuveHasarRucuBilgileriYeniRucuEkle});
            this.c_titemDosyaRucuveHasarRucuBilgileri.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaRucuveHasarRucuBilgileri.Image")));
            this.c_titemDosyaRucuveHasarRucuBilgileri.Name = "c_titemDosyaRucuveHasarRucuBilgileri";
            this.c_titemDosyaRucuveHasarRucuBilgileri.Size = new System.Drawing.Size(182, 22);
            this.c_titemDosyaRucuveHasarRucuBilgileri.Text = "R�cu Bilgileri";
            // 
            // c_titemDosyaRucuveHasarRucuBilgileriRucuBul
            // 
            this.c_titemDosyaRucuveHasarRucuBilgileriRucuBul.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaRucuveHasarRucuBilgileriRucuBul.Image")));
            this.c_titemDosyaRucuveHasarRucuBilgileriRucuBul.Name = "c_titemDosyaRucuveHasarRucuBilgileriRucuBul";
            this.c_titemDosyaRucuveHasarRucuBilgileriRucuBul.Size = new System.Drawing.Size(171, 22);
            this.c_titemDosyaRucuveHasarRucuBilgileriRucuBul.Text = "R�cu Bilgisi Ara";
            // 
            // c_titemDosyaRucuveHasarRucuBilgileriYeniRucuEkle
            // 
            this.c_titemDosyaRucuveHasarRucuBilgileriYeniRucuEkle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaRucuveHasarRucuBilgileriYeniRucuEkle.Image")));
            this.c_titemDosyaRucuveHasarRucuBilgileriYeniRucuEkle.Name = "c_titemDosyaRucuveHasarRucuBilgileriYeniRucuEkle";
            this.c_titemDosyaRucuveHasarRucuBilgileriYeniRucuEkle.Size = new System.Drawing.Size(171, 22);
            this.c_titemDosyaRucuveHasarRucuBilgileriYeniRucuEkle.Text = "Yeni R�cu Bilgisi Ekle";
            // 
            // c_titemDosyaBelge
            // 
            this.c_titemDosyaBelge.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaBelgeBelgeBul,
            this.c_titemDosyaBelgeYeniBelge});
            this.c_titemDosyaBelge.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaBelge.Image")));
            this.c_titemDosyaBelge.Name = "c_titemDosyaBelge";
            this.c_titemDosyaBelge.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaBelge.Text = "Dok�man";
            // 
            // c_titemDosyaBelgeBelgeBul
            // 
            this.c_titemDosyaBelgeBelgeBul.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaBelgeBelgeBul.Image")));
            this.c_titemDosyaBelgeBelgeBul.Name = "c_titemDosyaBelgeBelgeBul";
            this.c_titemDosyaBelgeBelgeBul.Size = new System.Drawing.Size(163, 22);
            this.c_titemDosyaBelgeBelgeBul.Text = "Dok�man Ara";
            this.c_titemDosyaBelgeBelgeBul.Click += new System.EventHandler(this.c_titemDosyaBelgeBelgeBul_Click);
            // 
            // c_titemDosyaBelgeYeniBelge
            // 
            this.c_titemDosyaBelgeYeniBelge.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaBelgeYeniBelge.Image")));
            this.c_titemDosyaBelgeYeniBelge.Name = "c_titemDosyaBelgeYeniBelge";
            this.c_titemDosyaBelgeYeniBelge.Size = new System.Drawing.Size(163, 22);
            this.c_titemDosyaBelgeYeniBelge.Text = "Yeni Dok�man Ekle";
            this.c_titemDosyaBelgeYeniBelge.Click += new System.EventHandler(this.c_titemDosyaBelgeYeniBelge_Click);
            // 
            // c_titemDosyaEvrak
            // 
            this.c_titemDosyaEvrak.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaEvrakBul,
            this.c_titemDosyaEvrakYeniEkle});
            this.c_titemDosyaEvrak.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaEvrak.Image")));
            this.c_titemDosyaEvrak.Name = "c_titemDosyaEvrak";
            this.c_titemDosyaEvrak.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaEvrak.Text = "Evrak/Tebligat ";
            // 
            // c_titemDosyaEvrakBul
            // 
            this.c_titemDosyaEvrakBul.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaEvrakBul.Image")));
            this.c_titemDosyaEvrakBul.Name = "c_titemDosyaEvrakBul";
            this.c_titemDosyaEvrakBul.Size = new System.Drawing.Size(166, 22);
            this.c_titemDosyaEvrakBul.Text = "Evrak/Tebligat  Ara";
            this.c_titemDosyaEvrakBul.Click += new System.EventHandler(this.c_titemDosyaEvrakBul_Click);
            // 
            // c_titemDosyaEvrakYeniEkle
            // 
            this.c_titemDosyaEvrakYeniEkle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaEvrakYeniEkle.Image")));
            this.c_titemDosyaEvrakYeniEkle.Name = "c_titemDosyaEvrakYeniEkle";
            this.c_titemDosyaEvrakYeniEkle.Size = new System.Drawing.Size(166, 22);
            this.c_titemDosyaEvrakYeniEkle.Text = "Yeni Evrak Ekle";
            this.c_titemDosyaEvrakYeniEkle.Click += new System.EventHandler(this.c_titemDosyaEvrakYeniEkle_Click);
            // 
            // c_titemDosyaGorusme
            // 
            this.c_titemDosyaGorusme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaGorusmeKayitBul,
            this.c_titemDosyaGorusmeYeniGorusme});
            this.c_titemDosyaGorusme.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaGorusme.Image")));
            this.c_titemDosyaGorusme.Name = "c_titemDosyaGorusme";
            this.c_titemDosyaGorusme.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaGorusme.Text = "G�r��me";
            // 
            // c_titemDosyaGorusmeKayitBul
            // 
            this.c_titemDosyaGorusmeKayitBul.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaGorusmeKayitBul.Image")));
            this.c_titemDosyaGorusmeKayitBul.Name = "c_titemDosyaGorusmeKayitBul";
            this.c_titemDosyaGorusmeKayitBul.Size = new System.Drawing.Size(190, 22);
            this.c_titemDosyaGorusmeKayitBul.Text = "G�r��me Kayd� Ara";
            this.c_titemDosyaGorusmeKayitBul.Click += new System.EventHandler(this.c_titemDosyaGorusmeKayitBul_Click);
            // 
            // c_titemDosyaGorusmeYeniGorusme
            // 
            this.c_titemDosyaGorusmeYeniGorusme.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaGorusmeYeniGorusme.Image")));
            this.c_titemDosyaGorusmeYeniGorusme.Name = "c_titemDosyaGorusmeYeniGorusme";
            this.c_titemDosyaGorusmeYeniGorusme.Size = new System.Drawing.Size(190, 22);
            this.c_titemDosyaGorusmeYeniGorusme.Text = "Yeni G�r��me Kayd� Ekle";
            this.c_titemDosyaGorusmeYeniGorusme.Click += new System.EventHandler(this.c_titemDosyaGorusmeYeniGorusme_Click);
            // 
            // c_titemDosyaAjanda
            // 
            this.c_titemDosyaAjanda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemBenimAjandam,
            this.c_titemSubemdekiAvukatlarinAjandasi,
            this.c_titemDetayliAjanda});
            this.c_titemDosyaAjanda.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaAjanda.Image")));
            this.c_titemDosyaAjanda.Name = "c_titemDosyaAjanda";
            this.c_titemDosyaAjanda.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaAjanda.Text = "Ajanda";
            // 
            // c_titemBenimAjandam
            // 
            this.c_titemBenimAjandam.Image = ((System.Drawing.Image)(resources.GetObject("c_titemBenimAjandam.Image")));
            this.c_titemBenimAjandam.Name = "c_titemBenimAjandam";
            this.c_titemBenimAjandam.Size = new System.Drawing.Size(226, 22);
            this.c_titemBenimAjandam.Text = "Benim Ajandam";
            this.c_titemBenimAjandam.Click += new System.EventHandler(this.c_titemBenimAjandam_Click);
            // 
            // c_titemSubemdekiAvukatlarinAjandasi
            // 
            this.c_titemSubemdekiAvukatlarinAjandasi.Image = ((System.Drawing.Image)(resources.GetObject("c_titemSubemdekiAvukatlarinAjandasi.Image")));
            this.c_titemSubemdekiAvukatlarinAjandasi.Name = "c_titemSubemdekiAvukatlarinAjandasi";
            this.c_titemSubemdekiAvukatlarinAjandasi.Size = new System.Drawing.Size(226, 22);
            this.c_titemSubemdekiAvukatlarinAjandasi.Text = "Subemdeki Avukatlar�n Ajandas�";
            this.c_titemSubemdekiAvukatlarinAjandasi.Visible = false;
            this.c_titemSubemdekiAvukatlarinAjandasi.Click += new System.EventHandler(this.c_titemSubemdekiAvukatlarinAjandasi_Click);
            // 
            // c_titemDetayliAjanda
            // 
            this.c_titemDetayliAjanda.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDetayliAjanda.Image")));
            this.c_titemDetayliAjanda.Name = "c_titemDetayliAjanda";
            this.c_titemDetayliAjanda.Size = new System.Drawing.Size(226, 22);
            this.c_titemDetayliAjanda.Text = "Ajanda Kay�tlar�na Detayl� Bak";
            this.c_titemDetayliAjanda.Visible = false;
            this.c_titemDetayliAjanda.Click += new System.EventHandler(this.c_titemDetayliAjanda_Click);
            // 
            // c_titemDosyaYapilcakIs
            // 
            this.c_titemDosyaYapilcakIs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaYapilcakIsAra,
            this.c_titemDosyaYapilcakIsEkle,
            this.�cretlendirilmi���lerToolStripMenuItem,
            this.duru�maSat��Ke�ifBilgilerimToolStripMenuItem,
            this.araKararlar�mToolStripMenuItem,
            this.toplant�lar�mToolStripMenuItem,
            this.g�nl�k��lerimToolStripMenuItem,
            this.notlar�mToolStripMenuItem});
            this.c_titemDosyaYapilcakIs.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaYapilcakIs.Image")));
            this.c_titemDosyaYapilcakIs.Name = "c_titemDosyaYapilcakIs";
            this.c_titemDosyaYapilcakIs.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaYapilcakIs.Text = "�� Emirleri";
            // 
            // c_titemDosyaYapilcakIsAra
            // 
            this.c_titemDosyaYapilcakIsAra.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaYapilcakIsAra.Image")));
            this.c_titemDosyaYapilcakIsAra.Name = "c_titemDosyaYapilcakIsAra";
            this.c_titemDosyaYapilcakIsAra.Size = new System.Drawing.Size(170, 22);
            this.c_titemDosyaYapilcakIsAra.Text = "�� Emri Ara";
            this.c_titemDosyaYapilcakIsAra.Click += new System.EventHandler(this.c_titemDosyaYapilcakIsAra_Click);
            // 
            // c_titemDosyaYapilcakIsEkle
            // 
            this.c_titemDosyaYapilcakIsEkle.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaYapilcakIsEkle.Image")));
            this.c_titemDosyaYapilcakIsEkle.Name = "c_titemDosyaYapilcakIsEkle";
            this.c_titemDosyaYapilcakIsEkle.Size = new System.Drawing.Size(170, 22);
            this.c_titemDosyaYapilcakIsEkle.Text = "Yeni �� Emri Ekle";
            this.c_titemDosyaYapilcakIsEkle.Click += new System.EventHandler(this.c_titemDosyaYapilcakIsEkle_Click);
            // 
            // �cretlendirilmi���lerToolStripMenuItem
            // 
            this.�cretlendirilmi���lerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("�cretlendirilmi���lerToolStripMenuItem.Image")));
            this.�cretlendirilmi���lerToolStripMenuItem.Name = "�cretlendirilmi���lerToolStripMenuItem";
            this.�cretlendirilmi���lerToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.�cretlendirilmi���lerToolStripMenuItem.Text = "�cretlendirilmi� ��ler";
            this.�cretlendirilmi���lerToolStripMenuItem.Click += new System.EventHandler(this.ucretlendirilmisIslerToolStripMenuItem_Click);
            // 
            // duru�maSat��Ke�ifBilgilerimToolStripMenuItem
            // 
            this.duru�maSat��Ke�ifBilgilerimToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("duru�maSat��Ke�ifBilgilerimToolStripMenuItem.Image")));
            this.duru�maSat��Ke�ifBilgilerimToolStripMenuItem.Name = "duru�maSat��Ke�ifBilgilerimToolStripMenuItem";
            this.duru�maSat��Ke�ifBilgilerimToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.duru�maSat��Ke�ifBilgilerimToolStripMenuItem.Text = "Duru�ma-Sat��-Ke�if";
            this.duru�maSat��Ke�ifBilgilerimToolStripMenuItem.Click += new System.EventHandler(this.durusmaSatisKesifToolStripMenuItem_Click);
            // 
            // araKararlar�mToolStripMenuItem
            // 
            this.araKararlar�mToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("araKararlar�mToolStripMenuItem.Image")));
            this.araKararlar�mToolStripMenuItem.Name = "araKararlar�mToolStripMenuItem";
            this.araKararlar�mToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.araKararlar�mToolStripMenuItem.Text = "Ara Kararlar";
            this.araKararlar�mToolStripMenuItem.Click += new System.EventHandler(this.araKararlarToolStripMenuItem_Click);
            // 
            // toplant�lar�mToolStripMenuItem
            // 
            this.toplant�lar�mToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toplant�lar�mToolStripMenuItem.Image")));
            this.toplant�lar�mToolStripMenuItem.Name = "toplant�lar�mToolStripMenuItem";
            this.toplant�lar�mToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.toplant�lar�mToolStripMenuItem.Text = "Toplant�lar";
            this.toplant�lar�mToolStripMenuItem.Click += new System.EventHandler(this.toplantilarToolStripMenuItem_Click);
            // 
            // g�nl�k��lerimToolStripMenuItem
            // 
            this.g�nl�k��lerimToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("g�nl�k��lerimToolStripMenuItem.Image")));
            this.g�nl�k��lerimToolStripMenuItem.Name = "g�nl�k��lerimToolStripMenuItem";
            this.g�nl�k��lerimToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.g�nl�k��lerimToolStripMenuItem.Text = "G�nl�k ��ler";
            this.g�nl�k��lerimToolStripMenuItem.Click += new System.EventHandler(this.gunlukIslerToolStripMenuItem_Click);
            // 
            // notlar�mToolStripMenuItem
            // 
            this.notlar�mToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("notlar�mToolStripMenuItem.Image")));
            this.notlar�mToolStripMenuItem.Name = "notlar�mToolStripMenuItem";
            this.notlar�mToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.notlar�mToolStripMenuItem.Text = "Notlar";
            this.notlar�mToolStripMenuItem.Click += new System.EventHandler(this.notlarToolStripMenuItem_Click);
            // 
            // c_titemDosyaKisi
            // 
            this.c_titemDosyaKisi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaKisiBulKisi,
            this.c_titemDosyaKisiYeniKisi,
            this.m�kerrer�ah�slar�Birle�tirToolStripMenuItem});
            this.c_titemDosyaKisi.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaKisi.Image")));
            this.c_titemDosyaKisi.Name = "c_titemDosyaKisi";
            this.c_titemDosyaKisi.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaKisi.Text = "�ah�s";
            // 
            // c_titemDosyaKisiBulKisi
            // 
            this.c_titemDosyaKisiBulKisi.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaKisiBulKisi.Image")));
            this.c_titemDosyaKisiBulKisi.Name = "c_titemDosyaKisiBulKisi";
            this.c_titemDosyaKisiBulKisi.Size = new System.Drawing.Size(197, 22);
            this.c_titemDosyaKisiBulKisi.Text = "�ah�s Ara";
            this.c_titemDosyaKisiBulKisi.Click += new System.EventHandler(this.c_titemDosyaKisiBulKisi_Click);
            // 
            // c_titemDosyaKisiYeniKisi
            // 
            this.c_titemDosyaKisiYeniKisi.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaKisiYeniKisi.Image")));
            this.c_titemDosyaKisiYeniKisi.Name = "c_titemDosyaKisiYeniKisi";
            this.c_titemDosyaKisiYeniKisi.Size = new System.Drawing.Size(197, 22);
            this.c_titemDosyaKisiYeniKisi.Text = "Yeni �ah�s Kayd� Ekle";
            this.c_titemDosyaKisiYeniKisi.Click += new System.EventHandler(this.c_titemDosyaKisiYeniKisi_Click);
            // 
            // m�kerrer�ah�slar�Birle�tirToolStripMenuItem
            // 
            this.m�kerrer�ah�slar�Birle�tirToolStripMenuItem.Name = "m�kerrer�ah�slar�Birle�tirToolStripMenuItem";
            this.m�kerrer�ah�slar�Birle�tirToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.m�kerrer�ah�slar�Birle�tirToolStripMenuItem.Text = "M�kerrer �ah�slar� Birle�tir";
            this.m�kerrer�ah�slar�Birle�tirToolStripMenuItem.Click += new System.EventHandler(this.m�kerrer�ah�slar�Birle�tirToolStripMenuItem_Click);
            // 
            // c_titemDosyaVekalet
            // 
            this.c_titemDosyaVekalet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemDosyaVekaletBulVekalet,
            this.c_titemDosyaVekaletYeniVekalet});
            this.c_titemDosyaVekalet.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaVekalet.Image")));
            this.c_titemDosyaVekalet.Name = "c_titemDosyaVekalet";
            this.c_titemDosyaVekalet.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaVekalet.Text = "Vekalet";
            // 
            // c_titemDosyaVekaletBulVekalet
            // 
            this.c_titemDosyaVekaletBulVekalet.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaVekaletBulVekalet.Image")));
            this.c_titemDosyaVekaletBulVekalet.Name = "c_titemDosyaVekaletBulVekalet";
            this.c_titemDosyaVekaletBulVekalet.Size = new System.Drawing.Size(182, 22);
            this.c_titemDosyaVekaletBulVekalet.Text = "Vekalet Bilgisi Ara";
            this.c_titemDosyaVekaletBulVekalet.Click += new System.EventHandler(this.c_titemDosyaVekaletBulVekalet_Click);
            // 
            // c_titemDosyaVekaletYeniVekalet
            // 
            this.c_titemDosyaVekaletYeniVekalet.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaVekaletYeniVekalet.Image")));
            this.c_titemDosyaVekaletYeniVekalet.Name = "c_titemDosyaVekaletYeniVekalet";
            this.c_titemDosyaVekaletYeniVekalet.Size = new System.Drawing.Size(182, 22);
            this.c_titemDosyaVekaletYeniVekalet.Text = "Yeni Vekalet Bilgisi Ekle";
            this.c_titemDosyaVekaletYeniVekalet.Click += new System.EventHandler(this.c_titemDosyaVekaletYeniVekalet_Click);
            // 
            // c_titemDosyaHukukMuhasebesi
            // 
            this.c_titemDosyaHukukMuhasebesi.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaHukukMuhasebesi.Image")));
            this.c_titemDosyaHukukMuhasebesi.Name = "c_titemDosyaHukukMuhasebesi";
            this.c_titemDosyaHukukMuhasebesi.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaHukukMuhasebesi.Text = "Hukuk Muhasebesi";
            this.c_titemDosyaHukukMuhasebesi.Click += new System.EventHandler(this.c_titemDosyaHukukMuhasebesi_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // c_titemDosyaCikis
            // 
            this.c_titemDosyaCikis.Image = ((System.Drawing.Image)(resources.GetObject("c_titemDosyaCikis.Image")));
            this.c_titemDosyaCikis.Name = "c_titemDosyaCikis";
            this.c_titemDosyaCikis.Size = new System.Drawing.Size(179, 22);
            this.c_titemDosyaCikis.Text = "��k��";
            this.c_titemDosyaCikis.Click += new System.EventHandler(this.c_titemDosyaCikis_Click);
            // 
            // c_titemHizliIslemler
            // 
            this.c_titemHizliIslemler.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hemenBulToolStripMenuItem,
            this.hemenEkleToolStripMenuItem});
            this.c_titemHizliIslemler.Image = ((System.Drawing.Image)(resources.GetObject("c_titemHizliIslemler.Image")));
            this.c_titemHizliIslemler.Name = "c_titemHizliIslemler";
            this.c_titemHizliIslemler.Size = new System.Drawing.Size(93, 25);
            this.c_titemHizliIslemler.Text = "H�zl� ��lemler";
            // 
            // hemenBulToolStripMenuItem
            // 
            this.hemenBulToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adEsasNoDosyaNoyaGoreBulToolStripMenuItem,
            this.tapuBilgisindenBulToolStripMenuItem,
            this.ara�BilgisindenBulToolStripMenuItem,
            this.cekSenetBilgisindenBulToolStripMenuItem});
            this.hemenBulToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hemenBulToolStripMenuItem.Image")));
            this.hemenBulToolStripMenuItem.Name = "hemenBulToolStripMenuItem";
            this.hemenBulToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.hemenBulToolStripMenuItem.Text = "H�zl� Bul";
            // 
            // adEsasNoDosyaNoyaGoreBulToolStripMenuItem
            // 
            this.adEsasNoDosyaNoyaGoreBulToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("adEsasNoDosyaNoyaGoreBulToolStripMenuItem.Image")));
            this.adEsasNoDosyaNoyaGoreBulToolStripMenuItem.Name = "adEsasNoDosyaNoyaGoreBulToolStripMenuItem";
            this.adEsasNoDosyaNoyaGoreBulToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D)));
            this.adEsasNoDosyaNoyaGoreBulToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.adEsasNoDosyaNoyaGoreBulToolStripMenuItem.Text = "Ad - Esas No - Dosya Nodan Bul";
            this.adEsasNoDosyaNoyaGoreBulToolStripMenuItem.Click += new System.EventHandler(this.adEsasNoDosyaNoyaGoreBulToolStripMenuItem_Click);
            // 
            // tapuBilgisindenBulToolStripMenuItem
            // 
            this.tapuBilgisindenBulToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tapuBilgisindenBulToolStripMenuItem.Image")));
            this.tapuBilgisindenBulToolStripMenuItem.Name = "tapuBilgisindenBulToolStripMenuItem";
            this.tapuBilgisindenBulToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.G)));
            this.tapuBilgisindenBulToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.tapuBilgisindenBulToolStripMenuItem.Text = "Tapu Bilgisinden Bul";
            this.tapuBilgisindenBulToolStripMenuItem.Click += new System.EventHandler(this.tapuBilgisindenBulToolStripMenuItem_Click);
            // 
            // ara�BilgisindenBulToolStripMenuItem
            // 
            this.ara�BilgisindenBulToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ara�BilgisindenBulToolStripMenuItem.Image")));
            this.ara�BilgisindenBulToolStripMenuItem.Name = "ara�BilgisindenBulToolStripMenuItem";
            this.ara�BilgisindenBulToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.A)));
            this.ara�BilgisindenBulToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.ara�BilgisindenBulToolStripMenuItem.Text = "Ara� Bilgisinden Bul";
            this.ara�BilgisindenBulToolStripMenuItem.Click += new System.EventHandler(this.aracBilgisindenBulToolStripMenuItem_Click);
            // 
            // cekSenetBilgisindenBulToolStripMenuItem
            // 
            this.cekSenetBilgisindenBulToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cekSenetBilgisindenBulToolStripMenuItem.Image")));
            this.cekSenetBilgisindenBulToolStripMenuItem.Name = "cekSenetBilgisindenBulToolStripMenuItem";
            this.cekSenetBilgisindenBulToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.K)));
            this.cekSenetBilgisindenBulToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.cekSenetBilgisindenBulToolStripMenuItem.Text = "�ek - Senet Bilgisinden Bul";
            this.cekSenetBilgisindenBulToolStripMenuItem.Click += new System.EventHandler(this.cekSenetBilgisindenBulToolStripMenuItem_Click);
            // 
            // hemenEkleToolStripMenuItem
            // 
            this.hemenEkleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�ah�sEkleToolStripMenuItem,
            this.vekaletToolStripMenuItem,
            this.belgeToolStripMenuItem,
            this.evrakTebligatToolStripMenuItem,
            this.masrafAvansToolStripMenuItem,
            this.notToolStripMenuItem,
            this.toplant�ToolStripMenuItem,
            this.duru�maToolStripMenuItem,
            this.araKararToolStripMenuItem,
            this.ke�if�ncelemeToolStripMenuItem,
            this.hacizToolStripMenuItem,
            this.sat��ToolStripMenuItem,
            this.bor�luOdemesiToolStripMenuItem,
            this.daval��demesiToolStripMenuItem,
            this.m�vekkile�demeToolStripMenuItem,
            this.i�ToolStripMenuItem,
            this.g�r��meToolStripMenuItem,
            this.klas�rToolStripMenuItem,
            this.s�kKullan�lanToolStripMenuItem});
            this.hemenEkleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hemenEkleToolStripMenuItem.Image")));
            this.hemenEkleToolStripMenuItem.Name = "hemenEkleToolStripMenuItem";
            this.hemenEkleToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.hemenEkleToolStripMenuItem.Text = "H�zl� Ekle";
            // 
            // �ah�sEkleToolStripMenuItem
            // 
            this.�ah�sEkleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("�ah�sEkleToolStripMenuItem.Image")));
            this.�ah�sEkleToolStripMenuItem.Name = "�ah�sEkleToolStripMenuItem";
            this.�ah�sEkleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.�ah�sEkleToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.�ah�sEkleToolStripMenuItem.Text = "�ah�s";
            this.�ah�sEkleToolStripMenuItem.Click += new System.EventHandler(this.sahisEkleToolStripMenuItem_Click);
            // 
            // vekaletToolStripMenuItem
            // 
            this.vekaletToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("vekaletToolStripMenuItem.Image")));
            this.vekaletToolStripMenuItem.Name = "vekaletToolStripMenuItem";
            this.vekaletToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.vekaletToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.vekaletToolStripMenuItem.Text = "Vekalet";
            this.vekaletToolStripMenuItem.Click += new System.EventHandler(this.vekaletToolStripMenuItem_Click);
            // 
            // belgeToolStripMenuItem
            // 
            this.belgeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("belgeToolStripMenuItem.Image")));
            this.belgeToolStripMenuItem.Name = "belgeToolStripMenuItem";
            this.belgeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.belgeToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.belgeToolStripMenuItem.Text = "Belge";
            this.belgeToolStripMenuItem.Click += new System.EventHandler(this.belgeToolStripMenuItem_Click);
            // 
            // evrakTebligatToolStripMenuItem
            // 
            this.evrakTebligatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("evrakTebligatToolStripMenuItem.Image")));
            this.evrakTebligatToolStripMenuItem.Name = "evrakTebligatToolStripMenuItem";
            this.evrakTebligatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Z)));
            this.evrakTebligatToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.evrakTebligatToolStripMenuItem.Text = "Evrak - Tebligat";
            this.evrakTebligatToolStripMenuItem.Click += new System.EventHandler(this.evrakTebligatToolStripMenuItem_Click);
            // 
            // masrafAvansToolStripMenuItem
            // 
            this.masrafAvansToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("masrafAvansToolStripMenuItem.Image")));
            this.masrafAvansToolStripMenuItem.Name = "masrafAvansToolStripMenuItem";
            this.masrafAvansToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.masrafAvansToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.masrafAvansToolStripMenuItem.Text = "Masraf Avans";
            this.masrafAvansToolStripMenuItem.Click += new System.EventHandler(this.masrafAvansToolStripMenuItem_Click);
            // 
            // notToolStripMenuItem
            // 
            this.notToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("notToolStripMenuItem.Image")));
            this.notToolStripMenuItem.Name = "notToolStripMenuItem";
            this.notToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.notToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.notToolStripMenuItem.Text = "Not";
            this.notToolStripMenuItem.Click += new System.EventHandler(this.notToolStripMenuItem_Click);
            // 
            // toplant�ToolStripMenuItem
            // 
            this.toplant�ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toplant�ToolStripMenuItem.Image")));
            this.toplant�ToolStripMenuItem.Name = "toplant�ToolStripMenuItem";
            this.toplant�ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.toplant�ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.toplant�ToolStripMenuItem.Text = "Toplant�";
            this.toplant�ToolStripMenuItem.Click += new System.EventHandler(this.toplantiToolStripMenuItem_Click);
            // 
            // duru�maToolStripMenuItem
            // 
            this.duru�maToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("duru�maToolStripMenuItem.Image")));
            this.duru�maToolStripMenuItem.Name = "duru�maToolStripMenuItem";
            this.duru�maToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.J)));
            this.duru�maToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.duru�maToolStripMenuItem.Text = "Duru�ma";
            this.duru�maToolStripMenuItem.Click += new System.EventHandler(this.durusmaToolStripMenuItem_Click);
            // 
            // araKararToolStripMenuItem
            // 
            this.araKararToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("araKararToolStripMenuItem.Image")));
            this.araKararToolStripMenuItem.Name = "araKararToolStripMenuItem";
            this.araKararToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.araKararToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.araKararToolStripMenuItem.Text = "Ara Karar";
            this.araKararToolStripMenuItem.Click += new System.EventHandler(this.araKararToolStripMenuItem_Click);
            // 
            // ke�if�ncelemeToolStripMenuItem
            // 
            this.ke�if�ncelemeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ke�if�ncelemeToolStripMenuItem.Image")));
            this.ke�if�ncelemeToolStripMenuItem.Name = "ke�if�ncelemeToolStripMenuItem";
            this.ke�if�ncelemeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.K)));
            this.ke�if�ncelemeToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ke�if�ncelemeToolStripMenuItem.Text = "Ke�if - �nceleme";
            this.ke�if�ncelemeToolStripMenuItem.Click += new System.EventHandler(this.kesifIncelemeToolStripMenuItem_Click);
            // 
            // hacizToolStripMenuItem
            // 
            this.hacizToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hacizToolStripMenuItem.Image")));
            this.hacizToolStripMenuItem.Name = "hacizToolStripMenuItem";
            this.hacizToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.hacizToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.hacizToolStripMenuItem.Text = "Haciz";
            this.hacizToolStripMenuItem.Click += new System.EventHandler(this.hacizToolStripMenuItem_Click);
            // 
            // sat��ToolStripMenuItem
            // 
            this.sat��ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sat��ToolStripMenuItem.Image")));
            this.sat��ToolStripMenuItem.Name = "sat��ToolStripMenuItem";
            this.sat��ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.sat��ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.sat��ToolStripMenuItem.Text = "Sat��";
            this.sat��ToolStripMenuItem.Click += new System.EventHandler(this.satisToolStripMenuItem_Click);
            // 
            // bor�luOdemesiToolStripMenuItem
            // 
            this.bor�luOdemesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bor�luOdemesiToolStripMenuItem.Image")));
            this.bor�luOdemesiToolStripMenuItem.Name = "bor�luOdemesiToolStripMenuItem";
            this.bor�luOdemesiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.bor�luOdemesiToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.bor�luOdemesiToolStripMenuItem.Text = "Bor�lu �demesi";
            this.bor�luOdemesiToolStripMenuItem.Click += new System.EventHandler(this.borcluOdemesiToolStripMenuItem_Click);
            // 
            // daval��demesiToolStripMenuItem
            // 
            this.daval��demesiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("daval��demesiToolStripMenuItem.Image")));
            this.daval��demesiToolStripMenuItem.Name = "daval��demesiToolStripMenuItem";
            this.daval��demesiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.daval��demesiToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.daval��demesiToolStripMenuItem.Text = "Daval� �demesi";
            this.daval��demesiToolStripMenuItem.Click += new System.EventHandler(this.davaliOdemesiToolStripMenuItem_Click);
            // 
            // m�vekkile�demeToolStripMenuItem
            // 
            this.m�vekkile�demeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m�vekkile�demeToolStripMenuItem.Image")));
            this.m�vekkile�demeToolStripMenuItem.Name = "m�vekkile�demeToolStripMenuItem";
            this.m�vekkile�demeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.m�vekkile�demeToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.m�vekkile�demeToolStripMenuItem.Text = "M�vekkile �deme";
            this.m�vekkile�demeToolStripMenuItem.Click += new System.EventHandler(this.m�vekkile�demeToolStripMenuItem_Click);
            // 
            // i�ToolStripMenuItem
            // 
            this.i�ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("i�ToolStripMenuItem.Image")));
            this.i�ToolStripMenuItem.Name = "i�ToolStripMenuItem";
            this.i�ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.i�ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.i�ToolStripMenuItem.Text = "�� Emri";
            this.i�ToolStripMenuItem.Click += new System.EventHandler(this.isToolStripMenuItem_Click);
            // 
            // g�r��meToolStripMenuItem
            // 
            this.g�r��meToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("g�r��meToolStripMenuItem.Image")));
            this.g�r��meToolStripMenuItem.Name = "g�r��meToolStripMenuItem";
            this.g�r��meToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.g�r��meToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.g�r��meToolStripMenuItem.Text = "G�r��me";
            this.g�r��meToolStripMenuItem.Click += new System.EventHandler(this.gorusmeToolStripMenuItem_Click);
            // 
            // klas�rToolStripMenuItem
            // 
            this.klas�rToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("klas�rToolStripMenuItem.Image")));
            this.klas�rToolStripMenuItem.Name = "klas�rToolStripMenuItem";
            this.klas�rToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.klas�rToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.klas�rToolStripMenuItem.Text = "Klas�r";
            this.klas�rToolStripMenuItem.Click += new System.EventHandler(this.klasorToolStripMenuItem_Click);
            // 
            // s�kKullan�lanToolStripMenuItem
            // 
            this.s�kKullan�lanToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("s�kKullan�lanToolStripMenuItem.Image")));
            this.s�kKullan�lanToolStripMenuItem.Name = "s�kKullan�lanToolStripMenuItem";
            this.s�kKullan�lanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.s�kKullan�lanToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.s�kKullan�lanToolStripMenuItem.Text = "S�k Kullan�lan";
            this.s�kKullan�lanToolStripMenuItem.Click += new System.EventHandler(this.sikKullan�lanToolStripMenuItem_Click);
            // 
            // c_titemGorunum
            // 
            this.c_titemGorunum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemYardimciAlanlar,
            this.c_titemStiller,
            this.c_titemYardimCubugu,
            this.c_titemFormHerZamanUstte,
            this.c_titemYaziTipi,
            this.c_titemSaydamlik,
            this.c_titemArkaPlan,
            this.g�ncel��lemlerToolStripMenuItem,
            this.ekranGorunumleriToolStripMenuItem});
            this.c_titemGorunum.Image = ((System.Drawing.Image)(resources.GetObject("c_titemGorunum.Image")));
            this.c_titemGorunum.Name = "c_titemGorunum";
            this.c_titemGorunum.Size = new System.Drawing.Size(78, 25);
            this.c_titemGorunum.Text = "&G�r�n�m";
            // 
            // c_titemYardimciAlanlar
            // 
            this.c_titemYardimciAlanlar.BackColor = System.Drawing.Color.Transparent;
            this.c_titemYardimciAlanlar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemGorunumGuncelIslemler});
            this.c_titemYardimciAlanlar.Name = "c_titemYardimciAlanlar";
            this.c_titemYardimciAlanlar.Size = new System.Drawing.Size(174, 22);
            this.c_titemYardimciAlanlar.Text = "Yard�mc� Alanlar";
            this.c_titemYardimciAlanlar.Visible = false;
            // 
            // c_titemGorunumGuncelIslemler
            // 
            this.c_titemGorunumGuncelIslemler.Name = "c_titemGorunumGuncelIslemler";
            this.c_titemGorunumGuncelIslemler.Size = new System.Drawing.Size(146, 22);
            this.c_titemGorunumGuncelIslemler.Text = "G�ncel ��lemler";
            // 
            // c_titemStiller
            // 
            this.c_titemStiller.Name = "c_titemStiller";
            this.c_titemStiller.Size = new System.Drawing.Size(174, 22);
            this.c_titemStiller.Text = "&Stiller";
            this.c_titemStiller.Visible = false;
            // 
            // c_titemYardimCubugu
            // 
            this.c_titemYardimCubugu.Checked = true;
            this.c_titemYardimCubugu.CheckOnClick = true;
            this.c_titemYardimCubugu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.c_titemYardimCubugu.Name = "c_titemYardimCubugu";
            this.c_titemYardimCubugu.Size = new System.Drawing.Size(174, 22);
            this.c_titemYardimCubugu.Text = "Yardim �ubu�u";
            this.c_titemYardimCubugu.Visible = false;
            // 
            // c_titemFormHerZamanUstte
            // 
            this.c_titemFormHerZamanUstte.CheckOnClick = true;
            this.c_titemFormHerZamanUstte.Name = "c_titemFormHerZamanUstte";
            this.c_titemFormHerZamanUstte.Size = new System.Drawing.Size(174, 22);
            this.c_titemFormHerZamanUstte.Text = "Formu Hep �stte Tut";
            this.c_titemFormHerZamanUstte.Click += new System.EventHandler(this.c_titemFormHerZamanUstte_Click);
            // 
            // c_titemYaziTipi
            // 
            this.c_titemYaziTipi.Name = "c_titemYaziTipi";
            this.c_titemYaziTipi.Size = new System.Drawing.Size(174, 22);
            this.c_titemYaziTipi.Text = "Yaz� Tipi";
            // 
            // c_titemSaydamlik
            // 
            this.c_titemSaydamlik.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemSaydamlikYuzde10,
            this.toolStripMenuItem7,
            this.toolStripMenuItem12,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem11,
            this.toolStripMenuItem10});
            this.c_titemSaydamlik.Name = "c_titemSaydamlik";
            this.c_titemSaydamlik.Size = new System.Drawing.Size(174, 22);
            this.c_titemSaydamlik.Text = "Saydaml�k";
            this.c_titemSaydamlik.Visible = false;
            // 
            // c_titemSaydamlikYuzde10
            // 
            this.c_titemSaydamlikYuzde10.CheckOnClick = true;
            this.c_titemSaydamlikYuzde10.Name = "c_titemSaydamlikYuzde10";
            this.c_titemSaydamlikYuzde10.Size = new System.Drawing.Size(103, 22);
            this.c_titemSaydamlikYuzde10.Tag = "10";
            this.c_titemSaydamlikYuzde10.Text = "%10";
            this.c_titemSaydamlikYuzde10.Click += new System.EventHandler(this.c_titemSaydamlikYuzde10_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.CheckOnClick = true;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem7.Text = "%20";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.CheckOnClick = true;
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem12.Text = "%30";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.CheckOnClick = true;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem8.Tag = "50";
            this.toolStripMenuItem8.Text = "%50";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.c_titemSaydamlikYuzde10_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.CheckOnClick = true;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem9.Text = "%75";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.CheckOnClick = true;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem11.Tag = "90";
            this.toolStripMenuItem11.Text = "%90";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.c_titemSaydamlikYuzde10_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Checked = true;
            this.toolStripMenuItem10.CheckOnClick = true;
            this.toolStripMenuItem10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem10.Tag = "100";
            this.toolStripMenuItem10.Text = "%100";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.c_titemSaydamlikYuzde10_Click);
            // 
            // c_titemArkaPlan
            // 
            this.c_titemArkaPlan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemArkaPlanResim,
            this.c_titemArkaPlanRenk});
            this.c_titemArkaPlan.Name = "c_titemArkaPlan";
            this.c_titemArkaPlan.Size = new System.Drawing.Size(174, 22);
            this.c_titemArkaPlan.Text = "Arka Plan";
            this.c_titemArkaPlan.Visible = false;
            // 
            // c_titemArkaPlanResim
            // 
            this.c_titemArkaPlanResim.Name = "c_titemArkaPlanResim";
            this.c_titemArkaPlanResim.Size = new System.Drawing.Size(150, 22);
            this.c_titemArkaPlanResim.Text = "Arka Plan Resmi";
            this.c_titemArkaPlanResim.Click += new System.EventHandler(this.c_titemArkaPlanResim_Click);
            // 
            // c_titemArkaPlanRenk
            // 
            this.c_titemArkaPlanRenk.Name = "c_titemArkaPlanRenk";
            this.c_titemArkaPlanRenk.Size = new System.Drawing.Size(150, 22);
            this.c_titemArkaPlanRenk.Text = "Arka Plan Rengi";
            this.c_titemArkaPlanRenk.Visible = false;
            // 
            // g�ncel��lemlerToolStripMenuItem
            // 
            this.g�ncel��lemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saatToolStripMenuItem,
            this.d�vizKurlar�ToolStripMenuItem,
            this.notlarToolStripMenuItem,
            this.resmiGazeteHaberleriToolStripMenuItem,
            this.hukukHaberleriToolStripMenuItem,
            this.yeniToolStripMenuItem});
            this.g�ncel��lemlerToolStripMenuItem.Name = "g�ncel��lemlerToolStripMenuItem";
            this.g�ncel��lemlerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.g�ncel��lemlerToolStripMenuItem.Text = "G�ncel ��lemler";
            this.g�ncel��lemlerToolStripMenuItem.Visible = false;
            // 
            // saatToolStripMenuItem
            // 
            this.saatToolStripMenuItem.CheckOnClick = true;
            this.saatToolStripMenuItem.Name = "saatToolStripMenuItem";
            this.saatToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saatToolStripMenuItem.Text = "Saat";
            // 
            // d�vizKurlar�ToolStripMenuItem
            // 
            this.d�vizKurlar�ToolStripMenuItem.CheckOnClick = true;
            this.d�vizKurlar�ToolStripMenuItem.Name = "d�vizKurlar�ToolStripMenuItem";
            this.d�vizKurlar�ToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.d�vizKurlar�ToolStripMenuItem.Text = "D�viz Kurlar�";
            // 
            // notlarToolStripMenuItem
            // 
            this.notlarToolStripMenuItem.Name = "notlarToolStripMenuItem";
            this.notlarToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.notlarToolStripMenuItem.Text = "Notlar";
            // 
            // resmiGazeteHaberleriToolStripMenuItem
            // 
            this.resmiGazeteHaberleriToolStripMenuItem.Name = "resmiGazeteHaberleriToolStripMenuItem";
            this.resmiGazeteHaberleriToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.resmiGazeteHaberleriToolStripMenuItem.Text = "Resmi Gazete Haberleri";
            // 
            // hukukHaberleriToolStripMenuItem
            // 
            this.hukukHaberleriToolStripMenuItem.Name = "hukukHaberleriToolStripMenuItem";
            this.hukukHaberleriToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.hukukHaberleriToolStripMenuItem.Text = "Hukuk Haberleri";
            // 
            // yeniToolStripMenuItem
            // 
            this.yeniToolStripMenuItem.Name = "yeniToolStripMenuItem";
            this.yeniToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.yeniToolStripMenuItem.Text = "Yeni";
            // 
            // ekranGorunumleriToolStripMenuItem
            // 
            this.ekranGorunumleriToolStripMenuItem.Name = "ekranGorunumleriToolStripMenuItem";
            this.ekranGorunumleriToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ekranGorunumleriToolStripMenuItem.Text = "Ekran G�r�n�mleri";
            // 
            // c_titemTanimlar
            // 
            this.c_titemTanimlar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemTanimlarKodVeCetvelAna,
            this.c_titemTanimlarAntetTanimlarAlt,
            this.c_titemTanimlarHesapTanimlarAlt,
            this.c_titemTanimlarIsTanimlari,
            this.c_titemEditorTanim,
            this.muvekkilSozlesmeleriToolStripMenuItem,
            this.c_titemSistemIslemleriKullaniciSecenekleri,
            this.c_titemSistemIslemleriParolaDegistirme,
            this.kullan�c�De�i�tirToolStripMenuItem,
            this.�irketDe�i�tirToolStripMenuItem});
            this.c_titemTanimlar.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTanimlar.Image")));
            this.c_titemTanimlar.Name = "c_titemTanimlar";
            this.c_titemTanimlar.Size = new System.Drawing.Size(75, 25);
            this.c_titemTanimlar.Text = "Tan�mlar";
            // 
            // c_titemTanimlarKodVeCetvelAna
            // 
            this.c_titemTanimlarKodVeCetvelAna.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemTanimlarKodVeCetvelAnaKodFormlar});
            this.c_titemTanimlarKodVeCetvelAna.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTanimlarKodVeCetvelAna.Image")));
            this.c_titemTanimlarKodVeCetvelAna.Name = "c_titemTanimlarKodVeCetvelAna";
            this.c_titemTanimlarKodVeCetvelAna.Size = new System.Drawing.Size(175, 22);
            this.c_titemTanimlarKodVeCetvelAna.Text = "Kod ve Cetveller";
            // 
            // c_titemTanimlarKodVeCetvelAnaKodFormlar
            // 
            this.c_titemTanimlarKodVeCetvelAnaKodFormlar.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTanimlarKodVeCetvelAnaKodFormlar.Image")));
            this.c_titemTanimlarKodVeCetvelAnaKodFormlar.Name = "c_titemTanimlarKodVeCetvelAnaKodFormlar";
            this.c_titemTanimlarKodVeCetvelAnaKodFormlar.Size = new System.Drawing.Size(182, 22);
            this.c_titemTanimlarKodVeCetvelAnaKodFormlar.Text = "Kod ve Cetvel Formlar�";
            this.c_titemTanimlarKodVeCetvelAnaKodFormlar.Click += new System.EventHandler(this.c_titemTanimlarKodVeCetvelAnaKodFormlar_Click);
            // 
            // c_titemTanimlarAntetTanimlarAlt
            // 
            this.c_titemTanimlarAntetTanimlarAlt.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTanimlarAntetTanimlarAlt.Image")));
            this.c_titemTanimlarAntetTanimlarAlt.Name = "c_titemTanimlarAntetTanimlarAlt";
            this.c_titemTanimlarAntetTanimlarAlt.Size = new System.Drawing.Size(175, 22);
            this.c_titemTanimlarAntetTanimlarAlt.Text = "Antet Tan�mlar�";
            this.c_titemTanimlarAntetTanimlarAlt.Click += new System.EventHandler(this.c_titemTanimlarAntetTanimlarAlt_Click);
            // 
            // c_titemTanimlarHesapTanimlarAlt
            // 
            this.c_titemTanimlarHesapTanimlarAlt.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTanimlarHesapTanimlarAlt.Image")));
            this.c_titemTanimlarHesapTanimlarAlt.Name = "c_titemTanimlarHesapTanimlarAlt";
            this.c_titemTanimlarHesapTanimlarAlt.Size = new System.Drawing.Size(175, 22);
            this.c_titemTanimlarHesapTanimlarAlt.Text = "Hesap Tan�mlar�";
            this.c_titemTanimlarHesapTanimlarAlt.Visible = false;
            // 
            // c_titemTanimlarIsTanimlari
            // 
            this.c_titemTanimlarIsTanimlari.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran,
            this.c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran});
            this.c_titemTanimlarIsTanimlari.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTanimlarIsTanimlari.Image")));
            this.c_titemTanimlarIsTanimlari.Name = "c_titemTanimlarIsTanimlari";
            this.c_titemTanimlarIsTanimlari.Size = new System.Drawing.Size(175, 22);
            this.c_titemTanimlarIsTanimlari.Text = "�� Tan�mlar�";
            this.c_titemTanimlarIsTanimlari.Visible = false;
            // 
            // c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran
            // 
            this.c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran.Image")));
            this.c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran.Name = "c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran";
            this.c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran.Size = new System.Drawing.Size(191, 22);
            this.c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran.Text = "&Yeni �� Tan�mlama Ekran�";
            this.c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran.Click += new System.EventHandler(this.yeni��Tan�mlamaEkran�ToolStripMenuItem_Click);
            // 
            // c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran
            // 
            this.c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran.Image")));
            this.c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran.Name = "c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran";
            this.c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran.Size = new System.Drawing.Size(191, 22);
            this.c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran.Text = "Otomatik �� Tan�mla";
            this.c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran.Click += new System.EventHandler(this.c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran_Click);
            // 
            // c_titemEditorTanim
            // 
            this.c_titemEditorTanim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemEditorDegiskenTanim});
            this.c_titemEditorTanim.Image = ((System.Drawing.Image)(resources.GetObject("c_titemEditorTanim.Image")));
            this.c_titemEditorTanim.Name = "c_titemEditorTanim";
            this.c_titemEditorTanim.Size = new System.Drawing.Size(175, 22);
            this.c_titemEditorTanim.Text = "Yaz��ma De�i�kenleri";
            this.c_titemEditorTanim.Visible = false;
            // 
            // c_titemEditorDegiskenTanim
            // 
            this.c_titemEditorDegiskenTanim.Image = ((System.Drawing.Image)(resources.GetObject("c_titemEditorDegiskenTanim.Image")));
            this.c_titemEditorDegiskenTanim.Name = "c_titemEditorDegiskenTanim";
            this.c_titemEditorDegiskenTanim.Size = new System.Drawing.Size(162, 22);
            this.c_titemEditorDegiskenTanim.Text = "De�i�ken Tan�mlar�";
            this.c_titemEditorDegiskenTanim.Click += new System.EventHandler(this.c_titemEditorDegiskenTanim_Click);
            // 
            // muvekkilSozlesmeleriToolStripMenuItem
            // 
            this.muvekkilSozlesmeleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.davaSozlesmeleriToolStripMenuItem,
            this.IcraSozlesmeleriToolStripMenuItem,
            this.IsUcretlendirmeSozlesmeleriToolStripMenuItem});
            this.muvekkilSozlesmeleriToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("muvekkilSozlesmeleriToolStripMenuItem.Image")));
            this.muvekkilSozlesmeleriToolStripMenuItem.Name = "muvekkilSozlesmeleriToolStripMenuItem";
            this.muvekkilSozlesmeleriToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.muvekkilSozlesmeleriToolStripMenuItem.Text = "M�vekkil S�zle�meleri";
            // 
            // davaSozlesmeleriToolStripMenuItem
            // 
            this.davaSozlesmeleriToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("davaSozlesmeleriToolStripMenuItem.Image")));
            this.davaSozlesmeleriToolStripMenuItem.Name = "davaSozlesmeleriToolStripMenuItem";
            this.davaSozlesmeleriToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.davaSozlesmeleriToolStripMenuItem.Text = "Dava S�zle�meleri";
            this.davaSozlesmeleriToolStripMenuItem.Visible = false;
            // 
            // IcraSozlesmeleriToolStripMenuItem
            // 
            this.IcraSozlesmeleriToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("IcraSozlesmeleriToolStripMenuItem.Image")));
            this.IcraSozlesmeleriToolStripMenuItem.Name = "IcraSozlesmeleriToolStripMenuItem";
            this.IcraSozlesmeleriToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.IcraSozlesmeleriToolStripMenuItem.Text = "�cra S�zle�meleri";
            this.IcraSozlesmeleriToolStripMenuItem.Click += new System.EventHandler(this.IcraSozlesmeleriToolStripMenuItem_Click);
            // 
            // IsUcretlendirmeSozlesmeleriToolStripMenuItem
            // 
            this.IsUcretlendirmeSozlesmeleriToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("IsUcretlendirmeSozlesmeleriToolStripMenuItem.Image")));
            this.IsUcretlendirmeSozlesmeleriToolStripMenuItem.Name = "IsUcretlendirmeSozlesmeleriToolStripMenuItem";
            this.IsUcretlendirmeSozlesmeleriToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.IsUcretlendirmeSozlesmeleriToolStripMenuItem.Text = "�� �cretlendirme S�zle�meleri";
            this.IsUcretlendirmeSozlesmeleriToolStripMenuItem.Visible = false;
            this.IsUcretlendirmeSozlesmeleriToolStripMenuItem.Click += new System.EventHandler(this.IsUcretlendirmeSozlesmeleriToolStripMenuItem_Click);
            // 
            // c_titemSistemIslemleriKullaniciSecenekleri
            // 
            this.c_titemSistemIslemleriKullaniciSecenekleri.Image = ((System.Drawing.Image)(resources.GetObject("c_titemSistemIslemleriKullaniciSecenekleri.Image")));
            this.c_titemSistemIslemleriKullaniciSecenekleri.Name = "c_titemSistemIslemleriKullaniciSecenekleri";
            this.c_titemSistemIslemleriKullaniciSecenekleri.Size = new System.Drawing.Size(175, 22);
            this.c_titemSistemIslemleriKullaniciSecenekleri.Text = "Kullan�c� Se�enekleri";
            this.c_titemSistemIslemleriKullaniciSecenekleri.Click += new System.EventHandler(this.c_titemSistemIslemleriKullaniciSecenekleri_Click);
            // 
            // c_titemSistemIslemleriParolaDegistirme
            // 
            this.c_titemSistemIslemleriParolaDegistirme.Image = ((System.Drawing.Image)(resources.GetObject("c_titemSistemIslemleriParolaDegistirme.Image")));
            this.c_titemSistemIslemleriParolaDegistirme.Name = "c_titemSistemIslemleriParolaDegistirme";
            this.c_titemSistemIslemleriParolaDegistirme.Size = new System.Drawing.Size(175, 22);
            this.c_titemSistemIslemleriParolaDegistirme.Text = "�ifre De�i�tirme";
            this.c_titemSistemIslemleriParolaDegistirme.Click += new System.EventHandler(this.c_titemSistemIslemleriParolaDegistirme_Click);
            // 
            // kullan�c�De�i�tirToolStripMenuItem
            // 
            this.kullan�c�De�i�tirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kullan�c�De�i�tirToolStripMenuItem.Image")));
            this.kullan�c�De�i�tirToolStripMenuItem.Name = "kullan�c�De�i�tirToolStripMenuItem";
            this.kullan�c�De�i�tirToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.kullan�c�De�i�tirToolStripMenuItem.Text = "Kullan�c� De�i�tir";
            this.kullan�c�De�i�tirToolStripMenuItem.Click += new System.EventHandler(this.kullan�c�De�i�tirToolStripMenuItem_Click);
            // 
            // �irketDe�i�tirToolStripMenuItem
            // 
            this.�irketDe�i�tirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("�irketDe�i�tirToolStripMenuItem.Image")));
            this.�irketDe�i�tirToolStripMenuItem.Name = "�irketDe�i�tirToolStripMenuItem";
            this.�irketDe�i�tirToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.�irketDe�i�tirToolStripMenuItem.Text = "�irket De�i�tir";
            this.�irketDe�i�tirToolStripMenuItem.Visible = false;
            this.�irketDe�i�tirToolStripMenuItem.Click += new System.EventHandler(this.�irketDe�i�tirToolStripMenuItem_Click);
            // 
            // c_titemYazismalar
            // 
            this.c_titemYazismalar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standartYaz��malarToolStripMenuItem,
            this.formlarEdit�rToolStripMenuItem,
            this.topluYaz��maVeUYAPEdit�r�ToolStripMenuItem});
            this.c_titemYazismalar.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYazismalar.Image")));
            this.c_titemYazismalar.Name = "c_titemYazismalar";
            this.c_titemYazismalar.Size = new System.Drawing.Size(85, 25);
            this.c_titemYazismalar.Text = "Yaz��malar";
            // 
            // standartYaz��malarToolStripMenuItem
            // 
            this.standartYaz��malarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("standartYaz��malarToolStripMenuItem.Image")));
            this.standartYaz��malarToolStripMenuItem.Name = "standartYaz��malarToolStripMenuItem";
            this.standartYaz��malarToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.standartYaz��malarToolStripMenuItem.Text = "Standart Yaz��malar";
            this.standartYaz��malarToolStripMenuItem.Click += new System.EventHandler(this.standartYaz��malarToolStripMenuItem_Click);
            // 
            // formlarEdit�rToolStripMenuItem
            // 
            this.formlarEdit�rToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("formlarEdit�rToolStripMenuItem.Image")));
            this.formlarEdit�rToolStripMenuItem.Name = "formlarEdit�rToolStripMenuItem";
            this.formlarEdit�rToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.formlarEdit�rToolStripMenuItem.Text = "Formlar (Edit�r)";
            this.formlarEdit�rToolStripMenuItem.Click += new System.EventHandler(this.formlarEdit�rToolStripMenuItem_Click);
            // 
            // topluYaz��maVeUYAPEdit�r�ToolStripMenuItem
            // 
            this.topluYaz��maVeUYAPEdit�r�ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("topluYaz��maVeUYAPEdit�r�ToolStripMenuItem.Image")));
            this.topluYaz��maVeUYAPEdit�r�ToolStripMenuItem.Name = "topluYaz��maVeUYAPEdit�r�ToolStripMenuItem";
            this.topluYaz��maVeUYAPEdit�r�ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.topluYaz��maVeUYAPEdit�r�ToolStripMenuItem.Text = "Toplu Yaz��ma ve UYAP Edit�r�";
            this.topluYaz��maVeUYAPEdit�r�ToolStripMenuItem.Click += new System.EventHandler(this.topluYaz��maVeUYAPEdit�r�ToolStripMenuItem_Click);
            // 
            // c_titemRaporlar
            // 
            this.c_titemRaporlar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standartRaporlarToolStripMenuItem1,
            this.gelismisRaporlarToolStripMenuItem,
            this.c_titemStandartRaporlar});
            this.c_titemRaporlar.Image = ((System.Drawing.Image)(resources.GetObject("c_titemRaporlar.Image")));
            this.c_titemRaporlar.Name = "c_titemRaporlar";
            this.c_titemRaporlar.Size = new System.Drawing.Size(76, 25);
            this.c_titemRaporlar.Text = "Raporlar";
            // 
            // standartRaporlarToolStripMenuItem1
            // 
            this.standartRaporlarToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.icraToolStripMenuItem,
            this.davaToolStripMenuItem,
            this.�zelToolStripMenuItem});
            this.standartRaporlarToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("standartRaporlarToolStripMenuItem1.Image")));
            this.standartRaporlarToolStripMenuItem1.Name = "standartRaporlarToolStripMenuItem1";
            this.standartRaporlarToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.standartRaporlarToolStripMenuItem1.Text = "Standart Raporlar";
            // 
            // icraToolStripMenuItem
            // 
            this.icraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m�vekkilHesaplar�ToolStripMenuItem,
            this.hacizToolStripMenuItem1,
            this.sat��ToolStripMenuItem1,
            this.bor�lu�demeToolStripMenuItem,
            this.ilamBilgileriToolStripMenuItem,
            this.taahh�tBilgileriToolStripMenuItem,
            this.itirazBilgileriToolStripMenuItem,
            this.tarafGeli�meleriToolStripMenuItem,
            this.bo�lununT�mMallar�ToolStripMenuItem,
            this.ihtiyatiHacizToolStripMenuItem1});
            this.icraToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("icraToolStripMenuItem.Image")));
            this.icraToolStripMenuItem.Name = "icraToolStripMenuItem";
            this.icraToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.icraToolStripMenuItem.Text = "�cra";
            // 
            // m�vekkilHesaplar�ToolStripMenuItem
            // 
            this.m�vekkilHesaplar�ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m�vekkilHesaplar�ToolStripMenuItem.Image")));
            this.m�vekkilHesaplar�ToolStripMenuItem.Name = "m�vekkilHesaplar�ToolStripMenuItem";
            this.m�vekkilHesaplar�ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m�vekkilHesaplar�ToolStripMenuItem.Text = "M�vekkil Hesaplar�";
            this.m�vekkilHesaplar�ToolStripMenuItem.Click += new System.EventHandler(this.m�vekkilHesaplar�ToolStripMenuItem_Click);
            // 
            // hacizToolStripMenuItem1
            // 
            this.hacizToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("hacizToolStripMenuItem1.Image")));
            this.hacizToolStripMenuItem1.Name = "hacizToolStripMenuItem1";
            this.hacizToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.hacizToolStripMenuItem1.Text = "Haciz";
            this.hacizToolStripMenuItem1.Click += new System.EventHandler(this.hacizToolStripMenuItem1_Click);
            // 
            // sat��ToolStripMenuItem1
            // 
            this.sat��ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("sat��ToolStripMenuItem1.Image")));
            this.sat��ToolStripMenuItem1.Name = "sat��ToolStripMenuItem1";
            this.sat��ToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.sat��ToolStripMenuItem1.Text = "Sat��";
            this.sat��ToolStripMenuItem1.Click += new System.EventHandler(this.sat��ToolStripMenuItem1_Click);
            // 
            // bor�lu�demeToolStripMenuItem
            // 
            this.bor�lu�demeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bor�lu�demeToolStripMenuItem.Image")));
            this.bor�lu�demeToolStripMenuItem.Name = "bor�lu�demeToolStripMenuItem";
            this.bor�lu�demeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.bor�lu�demeToolStripMenuItem.Text = "Bor�lu �deme";
            this.bor�lu�demeToolStripMenuItem.Click += new System.EventHandler(this.bor�lu�demeToolStripMenuItem_Click);
            // 
            // ilamBilgileriToolStripMenuItem
            // 
            this.ilamBilgileriToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ilamBilgileriToolStripMenuItem.Image")));
            this.ilamBilgileriToolStripMenuItem.Name = "ilamBilgileriToolStripMenuItem";
            this.ilamBilgileriToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ilamBilgileriToolStripMenuItem.Text = "�lam Bilgileri";
            this.ilamBilgileriToolStripMenuItem.Click += new System.EventHandler(this.ilamBilgileriToolStripMenuItem_Click);
            // 
            // taahh�tBilgileriToolStripMenuItem
            // 
            this.taahh�tBilgileriToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("taahh�tBilgileriToolStripMenuItem.Image")));
            this.taahh�tBilgileriToolStripMenuItem.Name = "taahh�tBilgileriToolStripMenuItem";
            this.taahh�tBilgileriToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.taahh�tBilgileriToolStripMenuItem.Text = "Taahh�t Bilgileri";
            this.taahh�tBilgileriToolStripMenuItem.Click += new System.EventHandler(this.taahh�tBilgileriToolStripMenuItem_Click);
            // 
            // itirazBilgileriToolStripMenuItem
            // 
            this.itirazBilgileriToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("itirazBilgileriToolStripMenuItem.Image")));
            this.itirazBilgileriToolStripMenuItem.Name = "itirazBilgileriToolStripMenuItem";
            this.itirazBilgileriToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.itirazBilgileriToolStripMenuItem.Text = "�tiraz Bilgileri";
            this.itirazBilgileriToolStripMenuItem.Click += new System.EventHandler(this.itirazBilgileriToolStripMenuItem_Click);
            // 
            // tarafGeli�meleriToolStripMenuItem
            // 
            this.tarafGeli�meleriToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tarafGeli�meleriToolStripMenuItem.Image")));
            this.tarafGeli�meleriToolStripMenuItem.Name = "tarafGeli�meleriToolStripMenuItem";
            this.tarafGeli�meleriToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.tarafGeli�meleriToolStripMenuItem.Text = "Taraf Geli�meleri";
            this.tarafGeli�meleriToolStripMenuItem.Click += new System.EventHandler(this.tarafGeli�meleriToolStripMenuItem_Click);
            // 
            // bo�lununT�mMallar�ToolStripMenuItem
            // 
            this.bo�lununT�mMallar�ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bo�lununT�mMallar�ToolStripMenuItem.Image")));
            this.bo�lununT�mMallar�ToolStripMenuItem.Name = "bo�lununT�mMallar�ToolStripMenuItem";
            this.bo�lununT�mMallar�ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.bo�lununT�mMallar�ToolStripMenuItem.Text = "Bo�lunun T�m Mallar�";
            this.bo�lununT�mMallar�ToolStripMenuItem.Click += new System.EventHandler(this.bo�lununT�mMallar�ToolStripMenuItem_Click);
            // 
            // ihtiyatiHacizToolStripMenuItem1
            // 
            this.ihtiyatiHacizToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ihtiyatiHacizToolStripMenuItem1.Image")));
            this.ihtiyatiHacizToolStripMenuItem1.Name = "ihtiyatiHacizToolStripMenuItem1";
            this.ihtiyatiHacizToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.ihtiyatiHacizToolStripMenuItem1.Text = "�htiyati Haciz";
            this.ihtiyatiHacizToolStripMenuItem1.Click += new System.EventHandler(this.ihtiyatiHacizToolStripMenuItem1_Click);
            // 
            // davaToolStripMenuItem
            // 
            this.davaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.araKararToolStripMenuItem1,
            this.ihtiyatiTedbirToolStripMenuItem1,
            this.duru�maKe�ifToolStripMenuItem,
            this.duru�maSat��Ke�ifToolStripMenuItem,
            this.karara��kanDosyalarToolStripMenuItem,
            this.temyizEdilenDosyalarToolStripMenuItem});
            this.davaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("davaToolStripMenuItem.Image")));
            this.davaToolStripMenuItem.Name = "davaToolStripMenuItem";
            this.davaToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.davaToolStripMenuItem.Text = "Dava";
            // 
            // araKararToolStripMenuItem1
            // 
            this.araKararToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("araKararToolStripMenuItem1.Image")));
            this.araKararToolStripMenuItem1.Name = "araKararToolStripMenuItem1";
            this.araKararToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.araKararToolStripMenuItem1.Text = "Ara Karar";
            this.araKararToolStripMenuItem1.Click += new System.EventHandler(this.araKararToolStripMenuItem1_Click);
            // 
            // ihtiyatiTedbirToolStripMenuItem1
            // 
            this.ihtiyatiTedbirToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ihtiyatiTedbirToolStripMenuItem1.Image")));
            this.ihtiyatiTedbirToolStripMenuItem1.Name = "ihtiyatiTedbirToolStripMenuItem1";
            this.ihtiyatiTedbirToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.ihtiyatiTedbirToolStripMenuItem1.Text = "�htiyati Tedbir";
            this.ihtiyatiTedbirToolStripMenuItem1.Click += new System.EventHandler(this.ihtiyatiTedbirToolStripMenuItem1_Click);
            // 
            // duru�maKe�ifToolStripMenuItem
            // 
            this.duru�maKe�ifToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("duru�maKe�ifToolStripMenuItem.Image")));
            this.duru�maKe�ifToolStripMenuItem.Name = "duru�maKe�ifToolStripMenuItem";
            this.duru�maKe�ifToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.duru�maKe�ifToolStripMenuItem.Text = "Duru�ma Ke�if";
            this.duru�maKe�ifToolStripMenuItem.Click += new System.EventHandler(this.duru�maKe�ifToolStripMenuItem_Click);
            // 
            // duru�maSat��Ke�ifToolStripMenuItem
            // 
            this.duru�maSat��Ke�ifToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("duru�maSat��Ke�ifToolStripMenuItem.Image")));
            this.duru�maSat��Ke�ifToolStripMenuItem.Name = "duru�maSat��Ke�ifToolStripMenuItem";
            this.duru�maSat��Ke�ifToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.duru�maSat��Ke�ifToolStripMenuItem.Text = "Duru�ma - Sat�� - Ke�if";
            this.duru�maSat��Ke�ifToolStripMenuItem.Click += new System.EventHandler(this.duru�maSat��Ke�ifToolStripMenuItem_Click);
            // 
            // karara��kanDosyalarToolStripMenuItem
            // 
            this.karara��kanDosyalarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("karara��kanDosyalarToolStripMenuItem.Image")));
            this.karara��kanDosyalarToolStripMenuItem.Name = "karara��kanDosyalarToolStripMenuItem";
            this.karara��kanDosyalarToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.karara��kanDosyalarToolStripMenuItem.Text = "Karara ��kan Dosyalar";
            this.karara��kanDosyalarToolStripMenuItem.Click += new System.EventHandler(this.karara��kanDosyalarToolStripMenuItem_Click);
            // 
            // temyizEdilenDosyalarToolStripMenuItem
            // 
            this.temyizEdilenDosyalarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("temyizEdilenDosyalarToolStripMenuItem.Image")));
            this.temyizEdilenDosyalarToolStripMenuItem.Name = "temyizEdilenDosyalarToolStripMenuItem";
            this.temyizEdilenDosyalarToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.temyizEdilenDosyalarToolStripMenuItem.Text = "Temyiz Edilen Dosyalar";
            this.temyizEdilenDosyalarToolStripMenuItem.Click += new System.EventHandler(this.temyizEdilenDosyalarToolStripMenuItem_Click);
            // 
            // �zelToolStripMenuItem
            // 
            this.�zelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("�zelToolStripMenuItem.Image")));
            this.�zelToolStripMenuItem.Name = "�zelToolStripMenuItem";
            this.�zelToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.�zelToolStripMenuItem.Text = "�zel";
            // 
            // gelismisRaporlarToolStripMenuItem
            // 
            this.gelismisRaporlarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gelismisRaporlarToolStripMenuItem.Image")));
            this.gelismisRaporlarToolStripMenuItem.Name = "gelismisRaporlarToolStripMenuItem";
            this.gelismisRaporlarToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.gelismisRaporlarToolStripMenuItem.Text = "Geli�mi� Raporlar";
            this.gelismisRaporlarToolStripMenuItem.Click += new System.EventHandler(this.gelismisRaporlarToolStripMenuItem_Click);
            // 
            // c_titemStandartRaporlar
            // 
            this.c_titemStandartRaporlar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d�nemselRaporToolStripMenuItem,
            this.ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem,
            this.bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem,
            this.envanterToolStripMenuItem1,
            this.belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1,
            this.muallakRaporToolStripMenuItem1,
            this.hasarBilgileriToolStripMenuItem1,
            this.poli�eBilgileriToolStripMenuItem1,
            this.ticariRiskRaporuEntegreliToolStripMenuItem,
            this.ticariRiskRaporuDosyadanToolStripMenuItem});
            this.c_titemStandartRaporlar.Image = ((System.Drawing.Image)(resources.GetObject("c_titemStandartRaporlar.Image")));
            this.c_titemStandartRaporlar.Name = "c_titemStandartRaporlar";
            this.c_titemStandartRaporlar.Size = new System.Drawing.Size(160, 22);
            this.c_titemStandartRaporlar.Text = "�zel Raporlar";
            this.c_titemStandartRaporlar.Click += new System.EventHandler(this.c_titemStandartRaporlar_Click);
            // 
            // d�nemselRaporToolStripMenuItem
            // 
            this.d�nemselRaporToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("d�nemselRaporToolStripMenuItem.Image")));
            this.d�nemselRaporToolStripMenuItem.Name = "d�nemselRaporToolStripMenuItem";
            this.d�nemselRaporToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.d�nemselRaporToolStripMenuItem.Text = "Ticari Krediler T�m Alacaklar ��in D�nemsel Rapor";
            this.d�nemselRaporToolStripMenuItem.Click += new System.EventHandler(this.d�nemselRaporToolStripMenuItem_Click);
            // 
            // ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem
            // 
            this.ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Image")));
            this.ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Name = "ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem";
            this.ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Text = "Ticari Krediler Takipli Alacaklar ��in D�nemsel Rapor";
            this.ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Click += new System.EventHandler(this.ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem_Click);
            // 
            // bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem
            // 
            this.bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Image")));
            this.bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Name = "bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem";
            this.bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Text = "Bireysel Krediler Takipli Alacaklar ��in D�nemsel Rapor";
            this.bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem.Click += new System.EventHandler(this.bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem_Click);
            // 
            // envanterToolStripMenuItem1
            // 
            this.envanterToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("envanterToolStripMenuItem1.Image")));
            this.envanterToolStripMenuItem1.Name = "envanterToolStripMenuItem1";
            this.envanterToolStripMenuItem1.Size = new System.Drawing.Size(329, 22);
            this.envanterToolStripMenuItem1.Text = "T�m Mod�ller";
            this.envanterToolStripMenuItem1.Click += new System.EventHandler(this.envanterToolStripMenuItem1_Click);
            // 
            // belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1
            // 
            this.belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1.Image")));
            this.belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1.Name = "belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1";
            this.belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1.Size = new System.Drawing.Size(329, 22);
            this.belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1.Text = "Belge, Evrak, S�zle�me, �cra, Dava Soru�turma";
            this.belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1.Click += new System.EventHandler(this.belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1_Click);
            // 
            // muallakRaporToolStripMenuItem1
            // 
            this.muallakRaporToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("muallakRaporToolStripMenuItem1.Image")));
            this.muallakRaporToolStripMenuItem1.Name = "muallakRaporToolStripMenuItem1";
            this.muallakRaporToolStripMenuItem1.Size = new System.Drawing.Size(329, 22);
            this.muallakRaporToolStripMenuItem1.Text = "Muallak Rapor";
            this.muallakRaporToolStripMenuItem1.Click += new System.EventHandler(this.muallakRaporToolStripMenuItem1_Click);
            // 
            // hasarBilgileriToolStripMenuItem1
            // 
            this.hasarBilgileriToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("hasarBilgileriToolStripMenuItem1.Image")));
            this.hasarBilgileriToolStripMenuItem1.Name = "hasarBilgileriToolStripMenuItem1";
            this.hasarBilgileriToolStripMenuItem1.Size = new System.Drawing.Size(329, 22);
            this.hasarBilgileriToolStripMenuItem1.Text = "Hasar Bilgileri";
            this.hasarBilgileriToolStripMenuItem1.Click += new System.EventHandler(this.hasarBilgileriToolStripMenuItem1_Click);
            // 
            // poli�eBilgileriToolStripMenuItem1
            // 
            this.poli�eBilgileriToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("poli�eBilgileriToolStripMenuItem1.Image")));
            this.poli�eBilgileriToolStripMenuItem1.Name = "poli�eBilgileriToolStripMenuItem1";
            this.poli�eBilgileriToolStripMenuItem1.Size = new System.Drawing.Size(329, 22);
            this.poli�eBilgileriToolStripMenuItem1.Text = "Poli�e Bilgileri";
            this.poli�eBilgileriToolStripMenuItem1.Click += new System.EventHandler(this.poli�eBilgileriToolStripMenuItem1_Click);
            // 
            // ticariRiskRaporuEntegreliToolStripMenuItem
            // 
            this.ticariRiskRaporuEntegreliToolStripMenuItem.Name = "ticariRiskRaporuEntegreliToolStripMenuItem";
            this.ticariRiskRaporuEntegreliToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.ticariRiskRaporuEntegreliToolStripMenuItem.Text = "Ticari Risk Raporu (Entegreli)";
            this.ticariRiskRaporuEntegreliToolStripMenuItem.Click += new System.EventHandler(this.ticariRiskRaporuEntegreliToolStripMenuItem_Click);
            // 
            // ticariRiskRaporuDosyadanToolStripMenuItem
            // 
            this.ticariRiskRaporuDosyadanToolStripMenuItem.Name = "ticariRiskRaporuDosyadanToolStripMenuItem";
            this.ticariRiskRaporuDosyadanToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.ticariRiskRaporuDosyadanToolStripMenuItem.Text = "Ticari Risk Raporu (Dosyadan)";
            this.ticariRiskRaporuDosyadanToolStripMenuItem.Click += new System.EventHandler(this.ticariRiskRaporuDosyadanToolStripMenuItem_Click);
            // 
            // c_titemKimNerede
            // 
            this.c_titemKimNerede.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.s�kKullan�lanlarToolStripMenuItem,
            this.kimNeredeToolStripMenuItem,
            this.hariciSimulasyonHesabiToolStripMenuItem,
            this.kurGiri�iToolStripMenuItem,
            this.entegrasyonToolStripMenuItem,
            this.da��t�lmam��TahsilatlarToolStripMenuItem,
            this.da��t�lmam��MasraflarToolStripMenuItem});
            this.c_titemKimNerede.Image = ((System.Drawing.Image)(resources.GetObject("c_titemKimNerede.Image")));
            this.c_titemKimNerede.Name = "c_titemKimNerede";
            this.c_titemKimNerede.Size = new System.Drawing.Size(96, 25);
            this.c_titemKimNerede.Text = "�zel ��lemler";
            // 
            // s�kKullan�lanlarToolStripMenuItem
            // 
            this.s�kKullan�lanlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem,
            this.g�sterToolStripMenuItem});
            this.s�kKullan�lanlarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("s�kKullan�lanlarToolStripMenuItem.Image")));
            this.s�kKullan�lanlarToolStripMenuItem.Name = "s�kKullan�lanlarToolStripMenuItem";
            this.s�kKullan�lanlarToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.s�kKullan�lanlarToolStripMenuItem.Text = "S�k Kullan�lanlar";
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ekleToolStripMenuItem.Image")));
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ekleToolStripMenuItem.Text = "Ekle";
            this.ekleToolStripMenuItem.Click += new System.EventHandler(this.ekleToolStripMenuItem_Click);
            // 
            // g�sterToolStripMenuItem
            // 
            this.g�sterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("g�sterToolStripMenuItem.Image")));
            this.g�sterToolStripMenuItem.Name = "g�sterToolStripMenuItem";
            this.g�sterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.g�sterToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.g�sterToolStripMenuItem.Text = "G�ster";
            this.g�sterToolStripMenuItem.Click += new System.EventHandler(this.g�sterToolStripMenuItem_Click);
            // 
            // kimNeredeToolStripMenuItem
            // 
            this.kimNeredeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kimNeredeToolStripMenuItem.Image")));
            this.kimNeredeToolStripMenuItem.Name = "kimNeredeToolStripMenuItem";
            this.kimNeredeToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.kimNeredeToolStripMenuItem.Text = "Personel Nerede";
            this.kimNeredeToolStripMenuItem.Click += new System.EventHandler(this.kimNeredeToolStripMenuItem_Click);
            // 
            // hariciSimulasyonHesabiToolStripMenuItem
            // 
            this.hariciSimulasyonHesabiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hariciSimulasyonHesabiToolStripMenuItem.Image")));
            this.hariciSimulasyonHesabiToolStripMenuItem.Name = "hariciSimulasyonHesabiToolStripMenuItem";
            this.hariciSimulasyonHesabiToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.hariciSimulasyonHesabiToolStripMenuItem.Text = "Harici Sim�lasyon Hesab�";
            this.hariciSimulasyonHesabiToolStripMenuItem.Click += new System.EventHandler(this.hariciSimulasyonHesabiToolStripMenuItem_Click);
            // 
            // kurGiri�iToolStripMenuItem
            // 
            this.kurGiri�iToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kurGiri�iToolStripMenuItem.Image")));
            this.kurGiri�iToolStripMenuItem.Name = "kurGiri�iToolStripMenuItem";
            this.kurGiri�iToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.kurGiri�iToolStripMenuItem.Text = "Kur Giri�i";
            this.kurGiri�iToolStripMenuItem.Click += new System.EventHandler(this.kurGiri�iToolStripMenuItem_Click);
            // 
            // entegrasyonToolStripMenuItem
            // 
            this.entegrasyonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genelBilgilerToolStripMenuItem,
            this.toolStripMenuItem5,
            this.masraflarToolStripMenuItem,
            this.tahsilatlarToolStripMenuItem,
            this.d�vizKurlar�ToolStripMenuItem1,
            this.aktar�lanMasraflarToolStripMenuItem,
            this.aktar�lanTahsilatlarToolStripMenuItem});
            this.entegrasyonToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("entegrasyonToolStripMenuItem.Image")));
            this.entegrasyonToolStripMenuItem.Name = "entegrasyonToolStripMenuItem";
            this.entegrasyonToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.entegrasyonToolStripMenuItem.Text = "Entegrasyon";
            this.entegrasyonToolStripMenuItem.Visible = false;
            // 
            // genelBilgilerToolStripMenuItem
            // 
            this.genelBilgilerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("genelBilgilerToolStripMenuItem.Image")));
            this.genelBilgilerToolStripMenuItem.Name = "genelBilgilerToolStripMenuItem";
            this.genelBilgilerToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.genelBilgilerToolStripMenuItem.Text = "Bor�lular / Alacaklar�m�z / Teminatlar�m�z";
            this.genelBilgilerToolStripMenuItem.Click += new System.EventHandler(this.genelBilgilerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem5.Image")));
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(262, 22);
            this.toolStripMenuItem5.Text = "Kredi Kartlar� Verileri";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // masraflarToolStripMenuItem
            // 
            this.masraflarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("masraflarToolStripMenuItem.Image")));
            this.masraflarToolStripMenuItem.Name = "masraflarToolStripMenuItem";
            this.masraflarToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.masraflarToolStripMenuItem.Text = "Masraflar";
            this.masraflarToolStripMenuItem.Visible = false;
            this.masraflarToolStripMenuItem.Click += new System.EventHandler(this.masraflarToolStripMenuItem_Click);
            // 
            // tahsilatlarToolStripMenuItem
            // 
            this.tahsilatlarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tahsilatlarToolStripMenuItem.Image")));
            this.tahsilatlarToolStripMenuItem.Name = "tahsilatlarToolStripMenuItem";
            this.tahsilatlarToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.tahsilatlarToolStripMenuItem.Text = "Tahsilatlar";
            this.tahsilatlarToolStripMenuItem.Visible = false;
            this.tahsilatlarToolStripMenuItem.Click += new System.EventHandler(this.tahsilatlarToolStripMenuItem_Click);
            // 
            // d�vizKurlar�ToolStripMenuItem1
            // 
            this.d�vizKurlar�ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("d�vizKurlar�ToolStripMenuItem1.Image")));
            this.d�vizKurlar�ToolStripMenuItem1.Name = "d�vizKurlar�ToolStripMenuItem1";
            this.d�vizKurlar�ToolStripMenuItem1.Size = new System.Drawing.Size(262, 22);
            this.d�vizKurlar�ToolStripMenuItem1.Text = "D�viz Kurlar�";
            this.d�vizKurlar�ToolStripMenuItem1.Click += new System.EventHandler(this.d�vizKurlar�ToolStripMenuItem1_Click);
            // 
            // aktar�lanMasraflarToolStripMenuItem
            // 
            this.aktar�lanMasraflarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aktar�lanMasraflarToolStripMenuItem.Image")));
            this.aktar�lanMasraflarToolStripMenuItem.Name = "aktar�lanMasraflarToolStripMenuItem";
            this.aktar�lanMasraflarToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.aktar�lanMasraflarToolStripMenuItem.Text = "Aktar�lan Masraflar";
            this.aktar�lanMasraflarToolStripMenuItem.Visible = false;
            this.aktar�lanMasraflarToolStripMenuItem.Click += new System.EventHandler(this.aktar�lanMasraflarToolStripMenuItem_Click);
            // 
            // aktar�lanTahsilatlarToolStripMenuItem
            // 
            this.aktar�lanTahsilatlarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aktar�lanTahsilatlarToolStripMenuItem.Image")));
            this.aktar�lanTahsilatlarToolStripMenuItem.Name = "aktar�lanTahsilatlarToolStripMenuItem";
            this.aktar�lanTahsilatlarToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.aktar�lanTahsilatlarToolStripMenuItem.Text = "Aktar�lan Tahsilatlar";
            this.aktar�lanTahsilatlarToolStripMenuItem.Visible = false;
            this.aktar�lanTahsilatlarToolStripMenuItem.Click += new System.EventHandler(this.aktar�lanTahsilatlarToolStripMenuItem_Click);
            // 
            // da��t�lmam��TahsilatlarToolStripMenuItem
            // 
            this.da��t�lmam��TahsilatlarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("da��t�lmam��TahsilatlarToolStripMenuItem.Image")));
            this.da��t�lmam��TahsilatlarToolStripMenuItem.Name = "da��t�lmam��TahsilatlarToolStripMenuItem";
            this.da��t�lmam��TahsilatlarToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.da��t�lmam��TahsilatlarToolStripMenuItem.Text = "Da��t�lmam�� TAHS�LATLAR";
            this.da��t�lmam��TahsilatlarToolStripMenuItem.Visible = false;
            this.da��t�lmam��TahsilatlarToolStripMenuItem.Click += new System.EventHandler(this.da��t�lmam��TahsilatlarToolStripMenuItem_Click);
            // 
            // da��t�lmam��MasraflarToolStripMenuItem
            // 
            this.da��t�lmam��MasraflarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("da��t�lmam��MasraflarToolStripMenuItem.Image")));
            this.da��t�lmam��MasraflarToolStripMenuItem.Name = "da��t�lmam��MasraflarToolStripMenuItem";
            this.da��t�lmam��MasraflarToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.da��t�lmam��MasraflarToolStripMenuItem.Text = "Da��t�lmam�� MASRAFLAR";
            this.da��t�lmam��MasraflarToolStripMenuItem.Visible = false;
            this.da��t�lmam��MasraflarToolStripMenuItem.Click += new System.EventHandler(this.da��t�lmam��MasraflarToolStripMenuItem_Click);
            // 
            // c_titemSistemIslemleri
            // 
            this.c_titemSistemIslemleri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asistan��al��t�rToolStripMenuItem,
            this.c_titemSistemIslemleriSistemBakimi,
            this.c_titemSistemIslemleriYedekAl,
            this.yedekD�nToolStripMenuItem,
            this.c_titemSistemIslemleriServis,
            this.ekran�zelle�tirmeToolStripMenuItem,
            this.dataAktarToolStripMenuItem,
            this.�r�nAktivasyonuToolStripMenuItem,
            this.guncellemeAyarlariToolStripMenuItem,
            this.bak�mAyarlar�ToolStripMenuItem});
            this.c_titemSistemIslemleri.Image = ((System.Drawing.Image)(resources.GetObject("c_titemSistemIslemleri.Image")));
            this.c_titemSistemIslemleri.Name = "c_titemSistemIslemleri";
            this.c_titemSistemIslemleri.Size = new System.Drawing.Size(108, 25);
            this.c_titemSistemIslemleri.Text = "Sistem ��lemleri";
            // 
            // asistan��al��t�rToolStripMenuItem
            // 
            this.asistan��al��t�rToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("asistan��al��t�rToolStripMenuItem.Image")));
            this.asistan��al��t�rToolStripMenuItem.Name = "asistan��al��t�rToolStripMenuItem";
            this.asistan��al��t�rToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.asistan��al��t�rToolStripMenuItem.Text = "Asistan� �al��t�r";
            this.asistan��al��t�rToolStripMenuItem.Click += new System.EventHandler(this.asistan��al��t�rToolStripMenuItem_Click);
            // 
            // c_titemSistemIslemleriSistemBakimi
            // 
            this.c_titemSistemIslemleriSistemBakimi.Image = ((System.Drawing.Image)(resources.GetObject("c_titemSistemIslemleriSistemBakimi.Image")));
            this.c_titemSistemIslemleriSistemBakimi.Name = "c_titemSistemIslemleriSistemBakimi";
            this.c_titemSistemIslemleriSistemBakimi.Size = new System.Drawing.Size(168, 22);
            this.c_titemSistemIslemleriSistemBakimi.Text = "Sistem Bak�m�";
            this.c_titemSistemIslemleriSistemBakimi.Visible = false;
            // 
            // c_titemSistemIslemleriYedekAl
            // 
            this.c_titemSistemIslemleriYedekAl.Image = ((System.Drawing.Image)(resources.GetObject("c_titemSistemIslemleriYedekAl.Image")));
            this.c_titemSistemIslemleriYedekAl.Name = "c_titemSistemIslemleriYedekAl";
            this.c_titemSistemIslemleriYedekAl.Size = new System.Drawing.Size(168, 22);
            this.c_titemSistemIslemleriYedekAl.Text = "Yedek Al";
            this.c_titemSistemIslemleriYedekAl.Visible = false;
            this.c_titemSistemIslemleriYedekAl.Click += new System.EventHandler(this.c_titemSistemIslemleriYedekAl_Click);
            // 
            // yedekD�nToolStripMenuItem
            // 
            this.yedekD�nToolStripMenuItem.Name = "yedekD�nToolStripMenuItem";
            this.yedekD�nToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.yedekD�nToolStripMenuItem.Text = "Yedek D�n";
            this.yedekD�nToolStripMenuItem.Visible = false;
            this.yedekD�nToolStripMenuItem.Click += new System.EventHandler(this.yedekD�nToolStripMenuItem_Click);
            // 
            // c_titemSistemIslemleriServis
            // 
            this.c_titemSistemIslemleriServis.Image = ((System.Drawing.Image)(resources.GetObject("c_titemSistemIslemleriServis.Image")));
            this.c_titemSistemIslemleriServis.Name = "c_titemSistemIslemleriServis";
            this.c_titemSistemIslemleriServis.Size = new System.Drawing.Size(168, 22);
            this.c_titemSistemIslemleriServis.Text = "Servis";
            this.c_titemSistemIslemleriServis.Visible = false;
            // 
            // ekran�zelle�tirmeToolStripMenuItem
            // 
            this.ekran�zelle�tirmeToolStripMenuItem.Name = "ekran�zelle�tirmeToolStripMenuItem";
            this.ekran�zelle�tirmeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.ekran�zelle�tirmeToolStripMenuItem.Text = "Ekran �zelle�tirme";
            this.ekran�zelle�tirmeToolStripMenuItem.Click += new System.EventHandler(this.ekran�zelle�tirmeToolStripMenuItem_Click);
            // 
            // dataAktarToolStripMenuItem
            // 
            this.dataAktarToolStripMenuItem.Name = "dataAktarToolStripMenuItem";
            this.dataAktarToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.dataAktarToolStripMenuItem.Text = "Data Aktar";
            this.dataAktarToolStripMenuItem.Click += new System.EventHandler(this.dataAktarToolStripMenuItem_Click);
            // 
            // �r�nAktivasyonuToolStripMenuItem
            // 
            this.�r�nAktivasyonuToolStripMenuItem.Name = "�r�nAktivasyonuToolStripMenuItem";
            this.�r�nAktivasyonuToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.�r�nAktivasyonuToolStripMenuItem.Text = "Lisans Aktivasyonu";
            this.�r�nAktivasyonuToolStripMenuItem.Click += new System.EventHandler(this.urunAktivasyonuToolStripMenuItem_Click);
            // 
            // guncellemeAyarlariToolStripMenuItem
            // 
            this.guncellemeAyarlariToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guncellemeParametreleriToolStripMenuItem,
            this.guncellemeServisiniBaslatToolStripMenuItem});
            this.guncellemeAyarlariToolStripMenuItem.Name = "guncellemeAyarlariToolStripMenuItem";
            this.guncellemeAyarlariToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.guncellemeAyarlariToolStripMenuItem.Text = "G�ncelleme Ayarlar�";
            this.guncellemeAyarlariToolStripMenuItem.Visible = false;
            this.guncellemeAyarlariToolStripMenuItem.DropDownOpening += new System.EventHandler(this.guncellemeAyarlariToolStripMenuItem_DropDownOpening);
            // 
            // guncellemeParametreleriToolStripMenuItem
            // 
            this.guncellemeParametreleriToolStripMenuItem.Name = "guncellemeParametreleriToolStripMenuItem";
            this.guncellemeParametreleriToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            // 
            // guncellemeServisiniBaslatToolStripMenuItem
            // 
            this.guncellemeServisiniBaslatToolStripMenuItem.Name = "guncellemeServisiniBaslatToolStripMenuItem";
            this.guncellemeServisiniBaslatToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.guncellemeServisiniBaslatToolStripMenuItem.Text = "G�ncelleme Servisini Ba�lat";
            this.guncellemeServisiniBaslatToolStripMenuItem.Click += new System.EventHandler(this.guncellemeServisiniBaslatToolStripMenuItem_Click);
            // 
            // bak�mAyarlar�ToolStripMenuItem
            // 
            this.bak�mAyarlar�ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bak�mAyarlar�ToolStripMenuItem.Image")));
            this.bak�mAyarlar�ToolStripMenuItem.Name = "bak�mAyarlar�ToolStripMenuItem";
            this.bak�mAyarlar�ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.bak�mAyarlar�ToolStripMenuItem.Text = "Bak�m Ayarlar�";
            this.bak�mAyarlar�ToolStripMenuItem.Click += new System.EventHandler(this.bak�mAyarlar�ToolStripMenuItem_Click);
            // 
            // c_titemYardim
            // 
            this.c_titemYardim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_titemYardimAltDosyasi,
            this.c_titemYardimKullanimKlavuzu,
            this.c_titemYardimPratikYardim,
            this.c_titemYardimIcendekiler,
            this.c_titemYardimTeknikDestek,
            this.c_titemYardimEgitimDestek,
            this.c_titemYardimEnCokArananlar,
            this.c_titemYardimAra,
            this.toolStripSeparator5,
            this.c_titemYardimLisanslama,
            this.c_titemYardimMusteriGeriBesleme,
            this.c_titemYardimAvukatproYardim,
            this.c_titemTebligatBarkodAraligiTanimlama});
            this.c_titemYardim.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardim.Image")));
            this.c_titemYardim.Name = "c_titemYardim";
            this.c_titemYardim.Size = new System.Drawing.Size(67, 25);
            this.c_titemYardim.Text = "Yard�m";
            // 
            // c_titemYardimAltDosyasi
            // 
            this.c_titemYardimAltDosyasi.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimAltDosyasi.Image")));
            this.c_titemYardimAltDosyasi.Name = "c_titemYardimAltDosyasi";
            this.c_titemYardimAltDosyasi.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimAltDosyasi.Text = "Yard�m Dosyas�";
            this.c_titemYardimAltDosyasi.Visible = false;
            // 
            // c_titemYardimKullanimKlavuzu
            // 
            this.c_titemYardimKullanimKlavuzu.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimKullanimKlavuzu.Image")));
            this.c_titemYardimKullanimKlavuzu.Name = "c_titemYardimKullanimKlavuzu";
            this.c_titemYardimKullanimKlavuzu.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimKullanimKlavuzu.Text = "Kullan�m Klavuzu";
            this.c_titemYardimKullanimKlavuzu.Visible = false;
            // 
            // c_titemYardimPratikYardim
            // 
            this.c_titemYardimPratikYardim.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimPratikYardim.Image")));
            this.c_titemYardimPratikYardim.Name = "c_titemYardimPratikYardim";
            this.c_titemYardimPratikYardim.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimPratikYardim.Text = "Pratik Yard�m";
            this.c_titemYardimPratikYardim.Visible = false;
            // 
            // c_titemYardimIcendekiler
            // 
            this.c_titemYardimIcendekiler.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimIcendekiler.Image")));
            this.c_titemYardimIcendekiler.Name = "c_titemYardimIcendekiler";
            this.c_titemYardimIcendekiler.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimIcendekiler.Text = "��indekiler";
            this.c_titemYardimIcendekiler.Visible = false;
            // 
            // c_titemYardimTeknikDestek
            // 
            this.c_titemYardimTeknikDestek.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimTeknikDestek.Image")));
            this.c_titemYardimTeknikDestek.Name = "c_titemYardimTeknikDestek";
            this.c_titemYardimTeknikDestek.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimTeknikDestek.Text = "Teknik Destek";
            this.c_titemYardimTeknikDestek.Visible = false;
            // 
            // c_titemYardimEgitimDestek
            // 
            this.c_titemYardimEgitimDestek.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimEgitimDestek.Image")));
            this.c_titemYardimEgitimDestek.Name = "c_titemYardimEgitimDestek";
            this.c_titemYardimEgitimDestek.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimEgitimDestek.Text = "E�itim Destek";
            this.c_titemYardimEgitimDestek.Visible = false;
            // 
            // c_titemYardimEnCokArananlar
            // 
            this.c_titemYardimEnCokArananlar.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimEnCokArananlar.Image")));
            this.c_titemYardimEnCokArananlar.Name = "c_titemYardimEnCokArananlar";
            this.c_titemYardimEnCokArananlar.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimEnCokArananlar.Text = "En �ok Aranan Yard�mlar";
            this.c_titemYardimEnCokArananlar.Visible = false;
            // 
            // c_titemYardimAra
            // 
            this.c_titemYardimAra.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimAra.Image")));
            this.c_titemYardimAra.Name = "c_titemYardimAra";
            this.c_titemYardimAra.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimAra.Text = "Ara";
            this.c_titemYardimAra.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(227, 6);
            // 
            // c_titemYardimLisanslama
            // 
            this.c_titemYardimLisanslama.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimLisanslama.Image")));
            this.c_titemYardimLisanslama.Name = "c_titemYardimLisanslama";
            this.c_titemYardimLisanslama.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimLisanslama.Text = "Lisanslama";
            this.c_titemYardimLisanslama.Visible = false;
            // 
            // c_titemYardimMusteriGeriBesleme
            // 
            this.c_titemYardimMusteriGeriBesleme.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimMusteriGeriBesleme.Image")));
            this.c_titemYardimMusteriGeriBesleme.Name = "c_titemYardimMusteriGeriBesleme";
            this.c_titemYardimMusteriGeriBesleme.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimMusteriGeriBesleme.Text = "M��teri Geri Besleme Se�enekleri";
            this.c_titemYardimMusteriGeriBesleme.Visible = false;
            // 
            // c_titemYardimAvukatproYardim
            // 
            this.c_titemYardimAvukatproYardim.Image = ((System.Drawing.Image)(resources.GetObject("c_titemYardimAvukatproYardim.Image")));
            this.c_titemYardimAvukatproYardim.Name = "c_titemYardimAvukatproYardim";
            this.c_titemYardimAvukatproYardim.Size = new System.Drawing.Size(230, 22);
            this.c_titemYardimAvukatproYardim.Text = "Avukatpro Hakk�nda";
            this.c_titemYardimAvukatproYardim.Click += new System.EventHandler(this.c_titemYardimAvukatproYardim_Click);
            // 
            // c_titemTebligatBarkodAraligiTanimlama
            // 
            this.c_titemTebligatBarkodAraligiTanimlama.Image = ((System.Drawing.Image)(resources.GetObject("c_titemTebligatBarkodAraligiTanimlama.Image")));
            this.c_titemTebligatBarkodAraligiTanimlama.Name = "c_titemTebligatBarkodAraligiTanimlama";
            this.c_titemTebligatBarkodAraligiTanimlama.Size = new System.Drawing.Size(230, 22);
            this.c_titemTebligatBarkodAraligiTanimlama.Text = "Tebligat Aral��� Tan�mlama";
            this.c_titemTebligatBarkodAraligiTanimlama.Click += new System.EventHandler(this.c_titemTebligatBarkodAraligiTanimlama_Click);
            // 
            // c_titemPencere
            // 
            this.c_titemPencere.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabWindowToolStripMenuItem,
            this.yatayYerlestirToolStripMenuItem,
            this.dikeyYerlestirToolStripMenuItem,
            this.basamaklaToolStripMenuItem});
            this.c_titemPencere.Image = ((System.Drawing.Image)(resources.GetObject("c_titemPencere.Image")));
            this.c_titemPencere.Name = "c_titemPencere";
            this.c_titemPencere.Size = new System.Drawing.Size(74, 25);
            this.c_titemPencere.Text = "Pencere";
            // 
            // tabWindowToolStripMenuItem
            // 
            this.tabWindowToolStripMenuItem.CheckOnClick = true;
            this.tabWindowToolStripMenuItem.Name = "tabWindowToolStripMenuItem";
            this.tabWindowToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.tabWindowToolStripMenuItem.Text = "Tab - Window";
            this.tabWindowToolStripMenuItem.Click += new System.EventHandler(this.tabToolStripMenuItem_Click);
            // 
            // yatayYerlestirToolStripMenuItem
            // 
            this.yatayYerlestirToolStripMenuItem.Name = "yatayYerlestirToolStripMenuItem";
            this.yatayYerlestirToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.yatayYerlestirToolStripMenuItem.Text = "Yatay Yerle�tir";
            this.yatayYerlestirToolStripMenuItem.Click += new System.EventHandler(this.yatayYerlestirToolStripMenuItem_Click);
            // 
            // dikeyYerlestirToolStripMenuItem
            // 
            this.dikeyYerlestirToolStripMenuItem.Name = "dikeyYerlestirToolStripMenuItem";
            this.dikeyYerlestirToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.dikeyYerlestirToolStripMenuItem.Text = "Dikey Yerle�tir";
            this.dikeyYerlestirToolStripMenuItem.Click += new System.EventHandler(this.dikeyYerlestirToolStripMenuItem_Click);
            // 
            // basamaklaToolStripMenuItem
            // 
            this.basamaklaToolStripMenuItem.Name = "basamaklaToolStripMenuItem";
            this.basamaklaToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.basamaklaToolStripMenuItem.Text = "Basamakla";
            this.basamaklaToolStripMenuItem.Click += new System.EventHandler(this.basamaklaToolStripMenuItem_Click);
            // 
            // �a�r�MerkeziToolStripMenuItem
            // 
            this.�a�r�MerkeziToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.�a�r�MerkeziToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("�a�r�MerkeziToolStripMenuItem.Image")));
            this.�a�r�MerkeziToolStripMenuItem.Name = "�a�r�MerkeziToolStripMenuItem";
            this.�a�r�MerkeziToolStripMenuItem.Size = new System.Drawing.Size(99, 25);
            this.�a�r�MerkeziToolStripMenuItem.Text = "�a�r� Merkezi";
            this.�a�r�MerkeziToolStripMenuItem.Click += new System.EventHandler(this.�a�r�MerkeziToolStripMenuItem_Click);
            // 
            // anaEkranToolStripMenuItem
            // 
            this.anaEkranToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.anaEkranToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("anaEkranToolStripMenuItem.Image")));
            this.anaEkranToolStripMenuItem.Name = "anaEkranToolStripMenuItem";
            this.anaEkranToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.anaEkranToolStripMenuItem.Text = "Ana Ekran";
            this.anaEkranToolStripMenuItem.Click += new System.EventHandler(this.anaEkranToolStripMenuItem_Click);
            // 
            // c_pnlUst
            // 
            this.c_pnlUst.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.c_pnlUst.Appearance.Options.UseBackColor = true;
            this.c_pnlUst.Controls.Add(this.c_mnUstMenu);
            this.c_pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.c_pnlUst.Location = new System.Drawing.Point(0, 0);
            this.c_pnlUst.Name = "c_pnlUst";
            this.c_pnlUst.Size = new System.Drawing.Size(1103, 33);
            this.c_pnlUst.TabIndex = 1;
            // 
            // c_comenUstKoseMenu
            // 
            this.c_comenUstKoseMenu.BackColor = System.Drawing.Color.Transparent;
            this.c_comenUstKoseMenu.Font = new System.Drawing.Font("Verdana", 9F);
            this.c_comenUstKoseMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.c_comenUstKoseMenu.Name = "c_comenUstKoseMenu";
            this.c_comenUstKoseMenu.Size = new System.Drawing.Size(134, 70);
            this.c_comenUstKoseMenu.Text = "H�zl� Eri�im";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem1.Text = "deneme2";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem2.Text = "deneme3";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem3.Text = "deneme4";
            // 
            // c_tspnlMenuPanel
            // 
            this.c_tspnlMenuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.c_tspnlMenuPanel.Location = new System.Drawing.Point(0, 562);
            this.c_tspnlMenuPanel.Name = "c_tspnlMenuPanel";
            this.c_tspnlMenuPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.c_tspnlMenuPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.c_tspnlMenuPanel.Size = new System.Drawing.Size(1103, 0);
            // 
            // c_opfArkaPlan
            // 
            this.c_opfArkaPlan.Filter = "Resim Dosyalar�|*.jpg;*.jpeg;*.bmp;*.gif;*.png";
            // 
            // c_opfFormuKaydet
            // 
            this.c_opfFormuKaydet.DefaultExt = "*.avpfrm";
            this.c_opfFormuKaydet.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextModuleEkle});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 26);
            // 
            // contextModuleEkle
            // 
            this.contextModuleEkle.Name = "contextModuleEkle";
            this.contextModuleEkle.Size = new System.Drawing.Size(130, 22);
            this.contextModuleEkle.Text = "Mod�le Ekle";
            this.contextModuleEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmYetkilendirme
            // 
            this.cmYetkilendirme.Name = "cmYetkilendirme";
            this.cmYetkilendirme.Size = new System.Drawing.Size(61, 4);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            this.xtraTabbedMdiManager1.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((DevExpress.XtraTab.TabButtons.Close | DevExpress.XtraTab.TabButtons.Default)));
            this.xtraTabbedMdiManager1.MdiParent = null;
            this.xtraTabbedMdiManager1.SetNextMdiChildMode = DevExpress.XtraTabbedMdi.SetNextMdiChildMode.TabControl;
            this.xtraTabbedMdiManager1.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.True;
            // 
            // c_pnlAlt
            // 
            this.c_pnlAlt.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.c_pnlAlt.Appearance.BackColor2 = System.Drawing.Color.Black;
            this.c_pnlAlt.Appearance.Options.UseBackColor = true;
            this.c_pnlAlt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.c_pnlAlt.Controls.Add(this.txtYapilacakIsler);
            this.c_pnlAlt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.c_pnlAlt.Location = new System.Drawing.Point(0, 535);
            this.c_pnlAlt.Name = "c_pnlAlt";
            this.c_pnlAlt.Size = new System.Drawing.Size(1103, 27);
            this.c_pnlAlt.TabIndex = 3;
            this.c_pnlAlt.Visible = false;
            // 
            // txtYapilacakIsler
            // 
            this.txtYapilacakIsler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtYapilacakIsler.Location = new System.Drawing.Point(0, 0);
            this.txtYapilacakIsler.Name = "txtYapilacakIsler";
            this.txtYapilacakIsler.Properties.Appearance.BackColor = System.Drawing.Color.Khaki;
            this.txtYapilacakIsler.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYapilacakIsler.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtYapilacakIsler.Properties.Appearance.Options.UseBackColor = true;
            this.txtYapilacakIsler.Properties.Appearance.Options.UseFont = true;
            this.txtYapilacakIsler.Properties.Appearance.Options.UseForeColor = true;
            this.txtYapilacakIsler.Properties.ReadOnly = true;
            this.txtYapilacakIsler.Size = new System.Drawing.Size(1103, 26);
            this.txtYapilacakIsler.TabIndex = 10;
            this.txtYapilacakIsler.Visible = false;
            this.txtYapilacakIsler.DoubleClick += new System.EventHandler(this.txtYapilacakIsler_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 350;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dckPanelCagriMerkezi});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dckPanelCagriMerkezi
            // 
            this.dckPanelCagriMerkezi.Controls.Add(this.dockPanel1_Container);
            this.dckPanelCagriMerkezi.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dckPanelCagriMerkezi.ID = new System.Guid("f8388916-dd4a-4951-b31a-97faa10a581c");
            this.dckPanelCagriMerkezi.Location = new System.Drawing.Point(0, 0);
            this.dckPanelCagriMerkezi.Name = "dckPanelCagriMerkezi";
            this.dckPanelCagriMerkezi.OriginalSize = new System.Drawing.Size(585, 200);
            this.dckPanelCagriMerkezi.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dckPanelCagriMerkezi.SavedIndex = 0;
            this.dckPanelCagriMerkezi.Size = new System.Drawing.Size(585, 673);
            this.dckPanelCagriMerkezi.Text = "Avukatpro �a�r� Merkezi";
            this.dckPanelCagriMerkezi.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panelControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(577, 646);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSize = true;
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.panel5);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(577, 646);
            this.panelControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xtraTabHatlar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 567);
            this.panel1.TabIndex = 2;
            // 
            // xtraTabHatlar
            // 
            this.xtraTabHatlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabHatlar.Location = new System.Drawing.Point(0, 0);
            this.xtraTabHatlar.Name = "xtraTabHatlar";
            this.xtraTabHatlar.SelectedTabPage = this.xtraTabHat1;
            this.xtraTabHatlar.Size = new System.Drawing.Size(573, 567);
            this.xtraTabHatlar.TabIndex = 1;
            this.xtraTabHatlar.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabHat1,
            this.xtraTabHat2,
            this.xtraTabHat3,
            this.xtraTabHat4,
            this.xtraTabSmsFaxMail});
            this.xtraTabHatlar.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabHatlar_SelectedPageChanged);
            // 
            // xtraTabHat1
            // 
            this.xtraTabHat1.Controls.Add(this.grpBoxCagriBilgileriHat1);
            this.xtraTabHat1.Name = "xtraTabHat1";
            this.xtraTabHat1.Size = new System.Drawing.Size(567, 539);
            this.xtraTabHat1.Text = "Hat 1";
            // 
            // grpBoxCagriBilgileriHat1
            // 
            this.grpBoxCagriBilgileriHat1.Controls.Add(this.tbControlCagriBilgileriHat1);
            this.grpBoxCagriBilgileriHat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxCagriBilgileriHat1.Location = new System.Drawing.Point(0, 0);
            this.grpBoxCagriBilgileriHat1.Name = "grpBoxCagriBilgileriHat1";
            this.grpBoxCagriBilgileriHat1.Size = new System.Drawing.Size(567, 539);
            this.grpBoxCagriBilgileriHat1.TabIndex = 2;
            this.grpBoxCagriBilgileriHat1.TabStop = false;
            this.grpBoxCagriBilgileriHat1.Text = "�a�r� Bilgileri";
            // 
            // tbControlCagriBilgileriHat1
            // 
            this.tbControlCagriBilgileriHat1.Controls.Add(this.tbPageGiden);
            this.tbControlCagriBilgileriHat1.Controls.Add(this.tbPageGelen);
            this.tbControlCagriBilgileriHat1.Controls.Add(this.tbPageGorusmeTutanagi);
            this.tbControlCagriBilgileriHat1.Controls.Add(this.tbPageEski);
            this.tbControlCagriBilgileriHat1.Controls.Add(this.tbPageIcraHesapHat1);
            this.tbControlCagriBilgileriHat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlCagriBilgileriHat1.Location = new System.Drawing.Point(3, 16);
            this.tbControlCagriBilgileriHat1.Name = "tbControlCagriBilgileriHat1";
            this.tbControlCagriBilgileriHat1.SelectedIndex = 0;
            this.tbControlCagriBilgileriHat1.Size = new System.Drawing.Size(561, 520);
            this.tbControlCagriBilgileriHat1.TabIndex = 3;
            this.tbControlCagriBilgileriHat1.SelectedIndexChanged += new System.EventHandler(this.tbControlCagriBilgileri_SelectedIndexChanged);
            // 
            // tbPageGiden
            // 
            this.tbPageGiden.Controls.Add(this.panel6);
            this.tbPageGiden.Controls.Add(this.panel4);
            this.tbPageGiden.Location = new System.Drawing.Point(4, 22);
            this.tbPageGiden.Name = "tbPageGiden";
            this.tbPageGiden.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageGiden.Size = new System.Drawing.Size(553, 494);
            this.tbPageGiden.TabIndex = 1;
            this.tbPageGiden.Text = "Giden";
            this.tbPageGiden.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.gridControlGidenHat1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 209);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(547, 282);
            this.panel6.TabIndex = 39;
            // 
            // gridControlGidenHat1
            // 
            this.gridControlGidenHat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlGidenHat1.Location = new System.Drawing.Point(0, 0);
            this.gridControlGidenHat1.MainView = this.gridViewGidenHat1;
            this.gridControlGidenHat1.Name = "gridControlGidenHat1";
            this.gridControlGidenHat1.Size = new System.Drawing.Size(547, 282);
            this.gridControlGidenHat1.TabIndex = 0;
            this.gridControlGidenHat1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGidenHat1});
            // 
            // gridViewGidenHat1
            // 
            this.gridViewGidenHat1.GridControl = this.gridControlGidenHat1;
            this.gridViewGidenHat1.Name = "gridViewGidenHat1";
            this.gridViewGidenHat1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewGiden_RowClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnYeniAramaGidenHat1);
            this.panel4.Controls.Add(this.rdButtonHariciHat1);
            this.panel4.Controls.Add(this.rdButtonDahiliHat1);
            this.panel4.Controls.Add(this.btnGidenBulHat1);
            this.panel4.Controls.Add(this.txtBoxTcNoGidenHat1);
            this.panel4.Controls.Add(this.btnKonferansGidenHat1);
            this.panel4.Controls.Add(this.SlueArananGidenHat1);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.btnYonlendirGidenHat1);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.btnKapatGidenHat1);
            this.panel4.Controls.Add(this.btnAraGidenHat1);
            this.panel4.Controls.Add(this.cmbBoxTelNoGidenHat1);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtBoxMusteriNoGidenHat1);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(547, 206);
            this.panel4.TabIndex = 37;
            // 
            // btnYeniAramaGidenHat1
            // 
            this.btnYeniAramaGidenHat1.Location = new System.Drawing.Point(33, 175);
            this.btnYeniAramaGidenHat1.Name = "btnYeniAramaGidenHat1";
            this.btnYeniAramaGidenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnYeniAramaGidenHat1.TabIndex = 40;
            this.btnYeniAramaGidenHat1.Text = "Yeni Arama";
            this.btnYeniAramaGidenHat1.UseVisualStyleBackColor = true;
            this.btnYeniAramaGidenHat1.Click += new System.EventHandler(this.btnYeniAramaGiden_Click);
            // 
            // rdButtonHariciHat1
            // 
            this.rdButtonHariciHat1.AutoSize = true;
            this.rdButtonHariciHat1.Checked = true;
            this.rdButtonHariciHat1.Location = new System.Drawing.Point(109, 8);
            this.rdButtonHariciHat1.Name = "rdButtonHariciHat1";
            this.rdButtonHariciHat1.Size = new System.Drawing.Size(52, 17);
            this.rdButtonHariciHat1.TabIndex = 39;
            this.rdButtonHariciHat1.TabStop = true;
            this.rdButtonHariciHat1.Text = "Harici";
            this.rdButtonHariciHat1.UseVisualStyleBackColor = true;
            this.rdButtonHariciHat1.CheckedChanged += new System.EventHandler(this.rdButtonHarici_CheckedChanged);
            // 
            // rdButtonDahiliHat1
            // 
            this.rdButtonDahiliHat1.AutoSize = true;
            this.rdButtonDahiliHat1.Location = new System.Drawing.Point(223, 8);
            this.rdButtonDahiliHat1.Name = "rdButtonDahiliHat1";
            this.rdButtonDahiliHat1.Size = new System.Drawing.Size(51, 17);
            this.rdButtonDahiliHat1.TabIndex = 38;
            this.rdButtonDahiliHat1.Text = "Dahili";
            this.rdButtonDahiliHat1.UseVisualStyleBackColor = true;
            // 
            // btnGidenBulHat1
            // 
            this.btnGidenBulHat1.Location = new System.Drawing.Point(332, 31);
            this.btnGidenBulHat1.Name = "btnGidenBulHat1";
            this.btnGidenBulHat1.Size = new System.Drawing.Size(37, 23);
            this.btnGidenBulHat1.TabIndex = 37;
            this.btnGidenBulHat1.Text = "BUL";
            this.btnGidenBulHat1.UseVisualStyleBackColor = true;
            this.btnGidenBulHat1.Click += new System.EventHandler(this.btnGidenBul_Click);
            // 
            // txtBoxTcNoGidenHat1
            // 
            this.txtBoxTcNoGidenHat1.Location = new System.Drawing.Point(80, 59);
            this.txtBoxTcNoGidenHat1.Name = "txtBoxTcNoGidenHat1";
            this.txtBoxTcNoGidenHat1.ReadOnly = true;
            this.txtBoxTcNoGidenHat1.Size = new System.Drawing.Size(246, 20);
            this.txtBoxTcNoGidenHat1.TabIndex = 19;
            // 
            // btnKonferansGidenHat1
            // 
            this.btnKonferansGidenHat1.Location = new System.Drawing.Point(133, 175);
            this.btnKonferansGidenHat1.Name = "btnKonferansGidenHat1";
            this.btnKonferansGidenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnKonferansGidenHat1.TabIndex = 31;
            this.btnKonferansGidenHat1.Text = "Konferans";
            this.btnKonferansGidenHat1.UseVisualStyleBackColor = true;
            this.btnKonferansGidenHat1.Click += new System.EventHandler(this.btnKonferansGiden_Click);
            // 
            // SlueArananGidenHat1
            // 
            this.SlueArananGidenHat1.Location = new System.Drawing.Point(80, 31);
            this.SlueArananGidenHat1.Name = "SlueArananGidenHat1";
            this.SlueArananGidenHat1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SlueArananGidenHat1.Size = new System.Drawing.Size(246, 20);
            this.SlueArananGidenHat1.TabIndex = 36;
            this.SlueArananGidenHat1.EditValueChanged += new System.EventHandler(this.SlueArananGiden_EditValueChanged);
            this.SlueArananGidenHat1.Enter += new System.EventHandler(this.SlueArananGiden_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Aranan:";
            // 
            // btnYonlendirGidenHat1
            // 
            this.btnYonlendirGidenHat1.Location = new System.Drawing.Point(236, 175);
            this.btnYonlendirGidenHat1.Name = "btnYonlendirGidenHat1";
            this.btnYonlendirGidenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnYonlendirGidenHat1.TabIndex = 28;
            this.btnYonlendirGidenHat1.Text = "Y�nlendir";
            this.btnYonlendirGidenHat1.UseVisualStyleBackColor = true;
            this.btnYonlendirGidenHat1.Click += new System.EventHandler(this.btnYonlendirGiden_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "TC No:";
            // 
            // btnKapatGidenHat1
            // 
            this.btnKapatGidenHat1.Location = new System.Drawing.Point(236, 145);
            this.btnKapatGidenHat1.Name = "btnKapatGidenHat1";
            this.btnKapatGidenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnKapatGidenHat1.TabIndex = 27;
            this.btnKapatGidenHat1.Text = "Kapat";
            this.btnKapatGidenHat1.UseVisualStyleBackColor = true;
            this.btnKapatGidenHat1.Click += new System.EventHandler(this.btnKapatGiden_Click);
            // 
            // btnAraGidenHat1
            // 
            this.btnAraGidenHat1.Location = new System.Drawing.Point(33, 145);
            this.btnAraGidenHat1.Name = "btnAraGidenHat1";
            this.btnAraGidenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnAraGidenHat1.TabIndex = 26;
            this.btnAraGidenHat1.Text = "Ara";
            this.btnAraGidenHat1.UseVisualStyleBackColor = true;
            this.btnAraGidenHat1.Click += new System.EventHandler(this.btnAraGiden_Click);
            // 
            // cmbBoxTelNoGidenHat1
            // 
            this.cmbBoxTelNoGidenHat1.FormattingEnabled = true;
            this.cmbBoxTelNoGidenHat1.Location = new System.Drawing.Point(81, 117);
            this.cmbBoxTelNoGidenHat1.Name = "cmbBoxTelNoGidenHat1";
            this.cmbBoxTelNoGidenHat1.Size = new System.Drawing.Size(246, 21);
            this.cmbBoxTelNoGidenHat1.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "M��teri No:";
            // 
            // txtBoxMusteriNoGidenHat1
            // 
            this.txtBoxMusteriNoGidenHat1.Location = new System.Drawing.Point(80, 88);
            this.txtBoxMusteriNoGidenHat1.Name = "txtBoxMusteriNoGidenHat1";
            this.txtBoxMusteriNoGidenHat1.ReadOnly = true;
            this.txtBoxMusteriNoGidenHat1.Size = new System.Drawing.Size(246, 20);
            this.txtBoxMusteriNoGidenHat1.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Telefon No:";
            // 
            // tbPageGelen
            // 
            this.tbPageGelen.Controls.Add(this.panel3);
            this.tbPageGelen.Controls.Add(this.panel7);
            this.tbPageGelen.Location = new System.Drawing.Point(4, 22);
            this.tbPageGelen.Name = "tbPageGelen";
            this.tbPageGelen.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageGelen.Size = new System.Drawing.Size(553, 494);
            this.tbPageGelen.TabIndex = 0;
            this.tbPageGelen.Text = "Gelen";
            this.tbPageGelen.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridControlGelenHat1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 178);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(547, 313);
            this.panel3.TabIndex = 19;
            // 
            // gridControlGelenHat1
            // 
            this.gridControlGelenHat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlGelenHat1.Location = new System.Drawing.Point(0, 0);
            this.gridControlGelenHat1.MainView = this.gridViewGelenHat1;
            this.gridControlGelenHat1.Name = "gridControlGelenHat1";
            this.gridControlGelenHat1.Size = new System.Drawing.Size(547, 313);
            this.gridControlGelenHat1.TabIndex = 1;
            this.gridControlGelenHat1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGelenHat1});
            // 
            // gridViewGelenHat1
            // 
            this.gridViewGelenHat1.GridControl = this.gridControlGelenHat1;
            this.gridViewGelenHat1.Name = "gridViewGelenHat1";
            this.gridViewGelenHat1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewGelenHat1_RowClick_1);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnGelenBulHat1);
            this.panel7.Controls.Add(this.txtBoxTcNoGelenHat1);
            this.panel7.Controls.Add(this.SlueArayanGelenHat1);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.btnYeniAramaGelenHat1);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.btnKapatGelenHat1);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.btnKonferansGelenHat1);
            this.panel7.Controls.Add(this.txtBoxMusteriNoGelenHat1);
            this.panel7.Controls.Add(this.btnYonlendirGelenHat1);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.btnGeriCevirGelenHat1);
            this.panel7.Controls.Add(this.txtBoxTelNoGelenHat1);
            this.panel7.Controls.Add(this.btnCevaplaGelenHat1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(547, 175);
            this.panel7.TabIndex = 17;
            // 
            // btnGelenBulHat1
            // 
            this.btnGelenBulHat1.Location = new System.Drawing.Point(330, 2);
            this.btnGelenBulHat1.Name = "btnGelenBulHat1";
            this.btnGelenBulHat1.Size = new System.Drawing.Size(37, 23);
            this.btnGelenBulHat1.TabIndex = 17;
            this.btnGelenBulHat1.Text = "BUL";
            this.btnGelenBulHat1.UseVisualStyleBackColor = true;
            this.btnGelenBulHat1.Click += new System.EventHandler(this.btnGelenBul_Click);
            // 
            // txtBoxTcNoGelenHat1
            // 
            this.txtBoxTcNoGelenHat1.Location = new System.Drawing.Point(76, 31);
            this.txtBoxTcNoGelenHat1.Name = "txtBoxTcNoGelenHat1";
            this.txtBoxTcNoGelenHat1.ReadOnly = true;
            this.txtBoxTcNoGelenHat1.Size = new System.Drawing.Size(246, 20);
            this.txtBoxTcNoGelenHat1.TabIndex = 3;
            // 
            // SlueArayanGelenHat1
            // 
            this.SlueArayanGelenHat1.Location = new System.Drawing.Point(76, 6);
            this.SlueArayanGelenHat1.Name = "SlueArayanGelenHat1";
            this.SlueArayanGelenHat1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SlueArayanGelenHat1.Size = new System.Drawing.Size(246, 20);
            this.SlueArayanGelenHat1.TabIndex = 16;
            this.SlueArayanGelenHat1.EditValueChanged += new System.EventHandler(this.SlueArayanGelen_EditValueChanged);
            this.SlueArayanGelenHat1.Enter += new System.EventHandler(this.SlueArayanGelen_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arayan:";
            // 
            // btnYeniAramaGelenHat1
            // 
            this.btnYeniAramaGelenHat1.Location = new System.Drawing.Point(26, 144);
            this.btnYeniAramaGelenHat1.Name = "btnYeniAramaGelenHat1";
            this.btnYeniAramaGelenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnYeniAramaGelenHat1.TabIndex = 15;
            this.btnYeniAramaGelenHat1.Text = "Yeni Arama";
            this.btnYeniAramaGelenHat1.UseVisualStyleBackColor = true;
            this.btnYeniAramaGelenHat1.Click += new System.EventHandler(this.btnYeniAramaGelen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TC No:";
            // 
            // btnKapatGelenHat1
            // 
            this.btnKapatGelenHat1.Location = new System.Drawing.Point(233, 116);
            this.btnKapatGelenHat1.Name = "btnKapatGelenHat1";
            this.btnKapatGelenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnKapatGelenHat1.TabIndex = 14;
            this.btnKapatGelenHat1.Text = "Kapat";
            this.btnKapatGelenHat1.UseVisualStyleBackColor = true;
            this.btnKapatGelenHat1.Click += new System.EventHandler(this.btnKapatGelen_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "M��teri No:";
            // 
            // btnKonferansGelenHat1
            // 
            this.btnKonferansGelenHat1.Location = new System.Drawing.Point(131, 144);
            this.btnKonferansGelenHat1.Name = "btnKonferansGelenHat1";
            this.btnKonferansGelenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnKonferansGelenHat1.TabIndex = 13;
            this.btnKonferansGelenHat1.Text = "Konferans";
            this.btnKonferansGelenHat1.UseVisualStyleBackColor = true;
            this.btnKonferansGelenHat1.Click += new System.EventHandler(this.btnKonferansGelen_Click);
            // 
            // txtBoxMusteriNoGelenHat1
            // 
            this.txtBoxMusteriNoGelenHat1.Location = new System.Drawing.Point(76, 60);
            this.txtBoxMusteriNoGelenHat1.Name = "txtBoxMusteriNoGelenHat1";
            this.txtBoxMusteriNoGelenHat1.ReadOnly = true;
            this.txtBoxMusteriNoGelenHat1.Size = new System.Drawing.Size(246, 20);
            this.txtBoxMusteriNoGelenHat1.TabIndex = 5;
            // 
            // btnYonlendirGelenHat1
            // 
            this.btnYonlendirGelenHat1.Location = new System.Drawing.Point(233, 143);
            this.btnYonlendirGelenHat1.Name = "btnYonlendirGelenHat1";
            this.btnYonlendirGelenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnYonlendirGelenHat1.TabIndex = 12;
            this.btnYonlendirGelenHat1.Text = "Y�nlendir";
            this.btnYonlendirGelenHat1.UseVisualStyleBackColor = true;
            this.btnYonlendirGelenHat1.Click += new System.EventHandler(this.btnYonlendirGelen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Telefon No:";
            // 
            // btnGeriCevirGelenHat1
            // 
            this.btnGeriCevirGelenHat1.Location = new System.Drawing.Point(131, 115);
            this.btnGeriCevirGelenHat1.Name = "btnGeriCevirGelenHat1";
            this.btnGeriCevirGelenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnGeriCevirGelenHat1.TabIndex = 11;
            this.btnGeriCevirGelenHat1.Text = "Geri �evir";
            this.btnGeriCevirGelenHat1.UseVisualStyleBackColor = true;
            this.btnGeriCevirGelenHat1.Click += new System.EventHandler(this.btnGeriCevirGelen_Click);
            // 
            // txtBoxTelNoGelenHat1
            // 
            this.txtBoxTelNoGelenHat1.Location = new System.Drawing.Point(76, 88);
            this.txtBoxTelNoGelenHat1.Name = "txtBoxTelNoGelenHat1";
            this.txtBoxTelNoGelenHat1.ReadOnly = true;
            this.txtBoxTelNoGelenHat1.Size = new System.Drawing.Size(246, 20);
            this.txtBoxTelNoGelenHat1.TabIndex = 7;
            this.txtBoxTelNoGelenHat1.TextChanged += new System.EventHandler(this.txtBoxTelNoGelenHat1_TextChanged);
            // 
            // btnCevaplaGelenHat1
            // 
            this.btnCevaplaGelenHat1.Location = new System.Drawing.Point(25, 115);
            this.btnCevaplaGelenHat1.Name = "btnCevaplaGelenHat1";
            this.btnCevaplaGelenHat1.Size = new System.Drawing.Size(90, 23);
            this.btnCevaplaGelenHat1.TabIndex = 10;
            this.btnCevaplaGelenHat1.Text = "Cevapla";
            this.btnCevaplaGelenHat1.UseVisualStyleBackColor = true;
            this.btnCevaplaGelenHat1.Click += new System.EventHandler(this.btnCevaplaGelen_Click);
            // 
            // tbPageGorusmeTutanagi
            // 
            this.tbPageGorusmeTutanagi.Controls.Add(this.panel8);
            this.tbPageGorusmeTutanagi.Controls.Add(this.panel9);
            this.tbPageGorusmeTutanagi.Location = new System.Drawing.Point(4, 22);
            this.tbPageGorusmeTutanagi.Name = "tbPageGorusmeTutanagi";
            this.tbPageGorusmeTutanagi.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageGorusmeTutanagi.Size = new System.Drawing.Size(553, 494);
            this.tbPageGorusmeTutanagi.TabIndex = 3;
            this.tbPageGorusmeTutanagi.Text = "G�r��me Tutana��";
            this.tbPageGorusmeTutanagi.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 48);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(547, 443);
            this.panel8.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnGorusmeKaydetHat1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(547, 45);
            this.panel9.TabIndex = 1;
            // 
            // btnGorusmeKaydetHat1
            // 
            this.btnGorusmeKaydetHat1.Location = new System.Drawing.Point(17, 14);
            this.btnGorusmeKaydetHat1.Name = "btnGorusmeKaydetHat1";
            this.btnGorusmeKaydetHat1.Size = new System.Drawing.Size(75, 25);
            this.btnGorusmeKaydetHat1.TabIndex = 0;
            this.btnGorusmeKaydetHat1.Text = "Kaydet";
            this.btnGorusmeKaydetHat1.UseVisualStyleBackColor = true;
            this.btnGorusmeKaydetHat1.Click += new System.EventHandler(this.btnGorusmeKaydet_Click);
            // 
            // tbPageEski
            // 
            this.tbPageEski.Controls.Add(this.panel10);
            this.tbPageEski.Controls.Add(this.panel12);
            this.tbPageEski.Location = new System.Drawing.Point(4, 22);
            this.tbPageEski.Name = "tbPageEski";
            this.tbPageEski.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageEski.Size = new System.Drawing.Size(553, 494);
            this.tbPageEski.TabIndex = 2;
            this.tbPageEski.Text = "Eski G�r��meler";
            this.tbPageEski.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(3, 35);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(547, 456);
            this.panel10.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnEskiGorusmeGetirHat1);
            this.panel12.Controls.Add(this.rdBtnSahisEskiGorusmeHat1);
            this.panel12.Controls.Add(this.rdBtnDosyaEskiGorusmeHat1);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(3, 3);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(547, 32);
            this.panel12.TabIndex = 1;
            // 
            // btnEskiGorusmeGetirHat1
            // 
            this.btnEskiGorusmeGetirHat1.Location = new System.Drawing.Point(428, 5);
            this.btnEskiGorusmeGetirHat1.Name = "btnEskiGorusmeGetirHat1";
            this.btnEskiGorusmeGetirHat1.Size = new System.Drawing.Size(44, 23);
            this.btnEskiGorusmeGetirHat1.TabIndex = 2;
            this.btnEskiGorusmeGetirHat1.Text = "Bul";
            this.btnEskiGorusmeGetirHat1.UseVisualStyleBackColor = true;
            this.btnEskiGorusmeGetirHat1.Click += new System.EventHandler(this.btnEskiGorusmeGetir_Click);
            // 
            // rdBtnSahisEskiGorusmeHat1
            // 
            this.rdBtnSahisEskiGorusmeHat1.AutoSize = true;
            this.rdBtnSahisEskiGorusmeHat1.Location = new System.Drawing.Point(187, 9);
            this.rdBtnSahisEskiGorusmeHat1.Name = "rdBtnSahisEskiGorusmeHat1";
            this.rdBtnSahisEskiGorusmeHat1.Size = new System.Drawing.Size(229, 17);
            this.rdBtnSahisEskiGorusmeHat1.TabIndex = 1;
            this.rdBtnSahisEskiGorusmeHat1.Text = "Se�ili �ahs�n t�m dosyalar�ndaki g�r��meleri";
            this.rdBtnSahisEskiGorusmeHat1.UseVisualStyleBackColor = true;
            // 
            // rdBtnDosyaEskiGorusmeHat1
            // 
            this.rdBtnDosyaEskiGorusmeHat1.AutoSize = true;
            this.rdBtnDosyaEskiGorusmeHat1.Checked = true;
            this.rdBtnDosyaEskiGorusmeHat1.Location = new System.Drawing.Point(7, 9);
            this.rdBtnDosyaEskiGorusmeHat1.Name = "rdBtnDosyaEskiGorusmeHat1";
            this.rdBtnDosyaEskiGorusmeHat1.Size = new System.Drawing.Size(175, 17);
            this.rdBtnDosyaEskiGorusmeHat1.TabIndex = 0;
            this.rdBtnDosyaEskiGorusmeHat1.TabStop = true;
            this.rdBtnDosyaEskiGorusmeHat1.Text = "Se�ili dosyadaki t�m g�r��meler";
            this.rdBtnDosyaEskiGorusmeHat1.UseVisualStyleBackColor = true;
            // 
            // tbPageIcraHesapHat1
            // 
            this.tbPageIcraHesapHat1.Controls.Add(this.panel18);
            this.tbPageIcraHesapHat1.Location = new System.Drawing.Point(4, 22);
            this.tbPageIcraHesapHat1.Name = "tbPageIcraHesapHat1";
            this.tbPageIcraHesapHat1.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageIcraHesapHat1.Size = new System.Drawing.Size(553, 494);
            this.tbPageIcraHesapHat1.TabIndex = 4;
            this.tbPageIcraHesapHat1.Text = "�cra Hesap";
            this.tbPageIcraHesapHat1.UseVisualStyleBackColor = true;
            // 
            // panel18
            // 
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(3, 3);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(547, 488);
            this.panel18.TabIndex = 2;
            // 
            // xtraTabHat2
            // 
            this.xtraTabHat2.Controls.Add(this.grpBoxCagriBilgileriHat2);
            this.xtraTabHat2.Name = "xtraTabHat2";
            this.xtraTabHat2.Size = new System.Drawing.Size(567, 539);
            this.xtraTabHat2.Text = "Hat 2";
            // 
            // grpBoxCagriBilgileriHat2
            // 
            this.grpBoxCagriBilgileriHat2.Controls.Add(this.tbControlCagriBilgileriHat2);
            this.grpBoxCagriBilgileriHat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxCagriBilgileriHat2.Location = new System.Drawing.Point(0, 0);
            this.grpBoxCagriBilgileriHat2.Name = "grpBoxCagriBilgileriHat2";
            this.grpBoxCagriBilgileriHat2.Size = new System.Drawing.Size(567, 539);
            this.grpBoxCagriBilgileriHat2.TabIndex = 3;
            this.grpBoxCagriBilgileriHat2.TabStop = false;
            this.grpBoxCagriBilgileriHat2.Text = "�a�r� Bilgileri";
            // 
            // tbControlCagriBilgileriHat2
            // 
            this.tbControlCagriBilgileriHat2.Controls.Add(this.tbPageGidenHat2);
            this.tbControlCagriBilgileriHat2.Controls.Add(this.tbPageGelenHat2);
            this.tbControlCagriBilgileriHat2.Controls.Add(this.tbPageGorusmeTutanagiHat2);
            this.tbControlCagriBilgileriHat2.Controls.Add(this.tbPageEskiGorusmelerHat2);
            this.tbControlCagriBilgileriHat2.Controls.Add(this.tbPageIcraHesapHat2);
            this.tbControlCagriBilgileriHat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlCagriBilgileriHat2.Location = new System.Drawing.Point(3, 16);
            this.tbControlCagriBilgileriHat2.Name = "tbControlCagriBilgileriHat2";
            this.tbControlCagriBilgileriHat2.SelectedIndex = 0;
            this.tbControlCagriBilgileriHat2.Size = new System.Drawing.Size(561, 520);
            this.tbControlCagriBilgileriHat2.TabIndex = 3;
            // 
            // tbPageGidenHat2
            // 
            this.tbPageGidenHat2.Controls.Add(this.panel2);
            this.tbPageGidenHat2.Controls.Add(this.panel19);
            this.tbPageGidenHat2.Location = new System.Drawing.Point(4, 22);
            this.tbPageGidenHat2.Name = "tbPageGidenHat2";
            this.tbPageGidenHat2.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageGidenHat2.Size = new System.Drawing.Size(553, 494);
            this.tbPageGidenHat2.TabIndex = 1;
            this.tbPageGidenHat2.Text = "Giden";
            this.tbPageGidenHat2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControlGidenHat2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 281);
            this.panel2.TabIndex = 39;
            // 
            // gridControlGidenHat2
            // 
            this.gridControlGidenHat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlGidenHat2.Location = new System.Drawing.Point(0, 0);
            this.gridControlGidenHat2.MainView = this.gridViewGidenHat2;
            this.gridControlGidenHat2.Name = "gridControlGidenHat2";
            this.gridControlGidenHat2.Size = new System.Drawing.Size(547, 281);
            this.gridControlGidenHat2.TabIndex = 0;
            this.gridControlGidenHat2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGidenHat2});
            // 
            // gridViewGidenHat2
            // 
            this.gridViewGidenHat2.GridControl = this.gridControlGidenHat2;
            this.gridViewGidenHat2.Name = "gridViewGidenHat2";
            this.gridViewGidenHat2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewGiden_RowClick);
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.btnYeniAramaGidenHat2);
            this.panel19.Controls.Add(this.rdButtonHariciHat2);
            this.panel19.Controls.Add(this.rdButtonDahiliHat2);
            this.panel19.Controls.Add(this.btnGidenBulHat2);
            this.panel19.Controls.Add(this.txtBoxTcNoGidenHat2);
            this.panel19.Controls.Add(this.btnKonferansGidenHat2);
            this.panel19.Controls.Add(this.SlueArananGidenHat2);
            this.panel19.Controls.Add(this.label13);
            this.panel19.Controls.Add(this.btnYonlendirGidenHat2);
            this.panel19.Controls.Add(this.label14);
            this.panel19.Controls.Add(this.btnKapatGidenHat2);
            this.panel19.Controls.Add(this.btnAraGidenHat2);
            this.panel19.Controls.Add(this.cmbBoxTelNoGidenHat2);
            this.panel19.Controls.Add(this.label15);
            this.panel19.Controls.Add(this.txtBoxMusteriNoGidenHat2);
            this.panel19.Controls.Add(this.label16);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(3, 3);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(547, 207);
            this.panel19.TabIndex = 37;
            // 
            // btnYeniAramaGidenHat2
            // 
            this.btnYeniAramaGidenHat2.Location = new System.Drawing.Point(33, 175);
            this.btnYeniAramaGidenHat2.Name = "btnYeniAramaGidenHat2";
            this.btnYeniAramaGidenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnYeniAramaGidenHat2.TabIndex = 41;
            this.btnYeniAramaGidenHat2.Text = "Yeni Arama";
            this.btnYeniAramaGidenHat2.UseVisualStyleBackColor = true;
            this.btnYeniAramaGidenHat2.Click += new System.EventHandler(this.btnYeniAramaGiden_Click);
            // 
            // rdButtonHariciHat2
            // 
            this.rdButtonHariciHat2.AutoSize = true;
            this.rdButtonHariciHat2.Checked = true;
            this.rdButtonHariciHat2.Location = new System.Drawing.Point(109, 8);
            this.rdButtonHariciHat2.Name = "rdButtonHariciHat2";
            this.rdButtonHariciHat2.Size = new System.Drawing.Size(52, 17);
            this.rdButtonHariciHat2.TabIndex = 39;
            this.rdButtonHariciHat2.TabStop = true;
            this.rdButtonHariciHat2.Text = "Harici";
            this.rdButtonHariciHat2.UseVisualStyleBackColor = true;
            this.rdButtonHariciHat2.CheckedChanged += new System.EventHandler(this.rdButtonHarici_CheckedChanged);
            // 
            // rdButtonDahiliHat2
            // 
            this.rdButtonDahiliHat2.AutoSize = true;
            this.rdButtonDahiliHat2.Location = new System.Drawing.Point(223, 8);
            this.rdButtonDahiliHat2.Name = "rdButtonDahiliHat2";
            this.rdButtonDahiliHat2.Size = new System.Drawing.Size(51, 17);
            this.rdButtonDahiliHat2.TabIndex = 38;
            this.rdButtonDahiliHat2.Text = "Dahili";
            this.rdButtonDahiliHat2.UseVisualStyleBackColor = true;
            // 
            // btnGidenBulHat2
            // 
            this.btnGidenBulHat2.Location = new System.Drawing.Point(332, 31);
            this.btnGidenBulHat2.Name = "btnGidenBulHat2";
            this.btnGidenBulHat2.Size = new System.Drawing.Size(37, 23);
            this.btnGidenBulHat2.TabIndex = 37;
            this.btnGidenBulHat2.Text = "BUL";
            this.btnGidenBulHat2.UseVisualStyleBackColor = true;
            this.btnGidenBulHat2.Click += new System.EventHandler(this.btnGidenBul_Click);
            // 
            // txtBoxTcNoGidenHat2
            // 
            this.txtBoxTcNoGidenHat2.Location = new System.Drawing.Point(80, 59);
            this.txtBoxTcNoGidenHat2.Name = "txtBoxTcNoGidenHat2";
            this.txtBoxTcNoGidenHat2.ReadOnly = true;
            this.txtBoxTcNoGidenHat2.Size = new System.Drawing.Size(246, 20);
            this.txtBoxTcNoGidenHat2.TabIndex = 19;
            // 
            // btnKonferansGidenHat2
            // 
            this.btnKonferansGidenHat2.Location = new System.Drawing.Point(133, 175);
            this.btnKonferansGidenHat2.Name = "btnKonferansGidenHat2";
            this.btnKonferansGidenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnKonferansGidenHat2.TabIndex = 31;
            this.btnKonferansGidenHat2.Text = "Konferans";
            this.btnKonferansGidenHat2.UseVisualStyleBackColor = true;
            this.btnKonferansGidenHat2.Click += new System.EventHandler(this.btnKonferansGiden_Click);
            // 
            // SlueArananGidenHat2
            // 
            this.SlueArananGidenHat2.Location = new System.Drawing.Point(80, 31);
            this.SlueArananGidenHat2.Name = "SlueArananGidenHat2";
            this.SlueArananGidenHat2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SlueArananGidenHat2.Size = new System.Drawing.Size(246, 20);
            this.SlueArananGidenHat2.TabIndex = 36;
            this.SlueArananGidenHat2.EditValueChanged += new System.EventHandler(this.SlueArananGiden_EditValueChanged);
            this.SlueArananGidenHat2.Enter += new System.EventHandler(this.SlueArananGiden_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Aranan:";
            // 
            // btnYonlendirGidenHat2
            // 
            this.btnYonlendirGidenHat2.Location = new System.Drawing.Point(236, 175);
            this.btnYonlendirGidenHat2.Name = "btnYonlendirGidenHat2";
            this.btnYonlendirGidenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnYonlendirGidenHat2.TabIndex = 28;
            this.btnYonlendirGidenHat2.Text = "Y�nlendir";
            this.btnYonlendirGidenHat2.UseVisualStyleBackColor = true;
            this.btnYonlendirGidenHat2.Click += new System.EventHandler(this.btnYonlendirGiden_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "TC No:";
            // 
            // btnKapatGidenHat2
            // 
            this.btnKapatGidenHat2.Location = new System.Drawing.Point(236, 145);
            this.btnKapatGidenHat2.Name = "btnKapatGidenHat2";
            this.btnKapatGidenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnKapatGidenHat2.TabIndex = 27;
            this.btnKapatGidenHat2.Text = "Kapat";
            this.btnKapatGidenHat2.UseVisualStyleBackColor = true;
            this.btnKapatGidenHat2.Click += new System.EventHandler(this.btnKapatGiden_Click);
            // 
            // btnAraGidenHat2
            // 
            this.btnAraGidenHat2.Location = new System.Drawing.Point(33, 145);
            this.btnAraGidenHat2.Name = "btnAraGidenHat2";
            this.btnAraGidenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnAraGidenHat2.TabIndex = 26;
            this.btnAraGidenHat2.Text = "Ara";
            this.btnAraGidenHat2.UseVisualStyleBackColor = true;
            this.btnAraGidenHat2.Click += new System.EventHandler(this.btnAraGiden_Click);
            // 
            // cmbBoxTelNoGidenHat2
            // 
            this.cmbBoxTelNoGidenHat2.FormattingEnabled = true;
            this.cmbBoxTelNoGidenHat2.Location = new System.Drawing.Point(81, 117);
            this.cmbBoxTelNoGidenHat2.Name = "cmbBoxTelNoGidenHat2";
            this.cmbBoxTelNoGidenHat2.Size = new System.Drawing.Size(246, 21);
            this.cmbBoxTelNoGidenHat2.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "M��teri No:";
            // 
            // txtBoxMusteriNoGidenHat2
            // 
            this.txtBoxMusteriNoGidenHat2.Location = new System.Drawing.Point(80, 88);
            this.txtBoxMusteriNoGidenHat2.Name = "txtBoxMusteriNoGidenHat2";
            this.txtBoxMusteriNoGidenHat2.ReadOnly = true;
            this.txtBoxMusteriNoGidenHat2.Size = new System.Drawing.Size(246, 20);
            this.txtBoxMusteriNoGidenHat2.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Telefon No:";
            // 
            // tbPageGelenHat2
            // 
            this.tbPageGelenHat2.Controls.Add(this.panel20);
            this.tbPageGelenHat2.Controls.Add(this.panel21);
            this.tbPageGelenHat2.Location = new System.Drawing.Point(4, 22);
            this.tbPageGelenHat2.Name = "tbPageGelenHat2";
            this.tbPageGelenHat2.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageGelenHat2.Size = new System.Drawing.Size(553, 493);
            this.tbPageGelenHat2.TabIndex = 0;
            this.tbPageGelenHat2.Text = "Gelen";
            this.tbPageGelenHat2.UseVisualStyleBackColor = true;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.gridControlGelenHat2);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(3, 178);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(547, 312);
            this.panel20.TabIndex = 19;
            // 
            // gridControlGelenHat2
            // 
            this.gridControlGelenHat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlGelenHat2.Location = new System.Drawing.Point(0, 0);
            this.gridControlGelenHat2.MainView = this.gridViewGelenHat2;
            this.gridControlGelenHat2.Name = "gridControlGelenHat2";
            this.gridControlGelenHat2.Size = new System.Drawing.Size(547, 312);
            this.gridControlGelenHat2.TabIndex = 1;
            this.gridControlGelenHat2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGelenHat2});
            // 
            // gridViewGelenHat2
            // 
            this.gridViewGelenHat2.GridControl = this.gridControlGelenHat2;
            this.gridViewGelenHat2.Name = "gridViewGelenHat2";
            this.gridViewGelenHat2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewGelenHat1_RowClick_1);
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.btnGelenBulHat2);
            this.panel21.Controls.Add(this.txtBoxTcNoGelenHat2);
            this.panel21.Controls.Add(this.SlueArayanGelenHat2);
            this.panel21.Controls.Add(this.label17);
            this.panel21.Controls.Add(this.btnYeniAramaGelenHat2);
            this.panel21.Controls.Add(this.label18);
            this.panel21.Controls.Add(this.btnKapatGelenHat2);
            this.panel21.Controls.Add(this.label19);
            this.panel21.Controls.Add(this.btnKonferansGelenHat2);
            this.panel21.Controls.Add(this.txtBoxMusteriNoGelenHat2);
            this.panel21.Controls.Add(this.btnYonlendirGelenHat2);
            this.panel21.Controls.Add(this.label20);
            this.panel21.Controls.Add(this.btnGeriCevirGelenHat2);
            this.panel21.Controls.Add(this.txtBoxTelNoGelenHat2);
            this.panel21.Controls.Add(this.btnCevaplaGelenHat2);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(3, 3);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(547, 175);
            this.panel21.TabIndex = 17;
            // 
            // btnGelenBulHat2
            // 
            this.btnGelenBulHat2.Location = new System.Drawing.Point(330, 2);
            this.btnGelenBulHat2.Name = "btnGelenBulHat2";
            this.btnGelenBulHat2.Size = new System.Drawing.Size(37, 23);
            this.btnGelenBulHat2.TabIndex = 17;
            this.btnGelenBulHat2.Text = "BUL";
            this.btnGelenBulHat2.UseVisualStyleBackColor = true;
            this.btnGelenBulHat2.Click += new System.EventHandler(this.btnGelenBul_Click);
            // 
            // txtBoxTcNoGelenHat2
            // 
            this.txtBoxTcNoGelenHat2.Location = new System.Drawing.Point(76, 31);
            this.txtBoxTcNoGelenHat2.Name = "txtBoxTcNoGelenHat2";
            this.txtBoxTcNoGelenHat2.ReadOnly = true;
            this.txtBoxTcNoGelenHat2.Size = new System.Drawing.Size(246, 20);
            this.txtBoxTcNoGelenHat2.TabIndex = 3;
            // 
            // SlueArayanGelenHat2
            // 
            this.SlueArayanGelenHat2.Location = new System.Drawing.Point(76, 6);
            this.SlueArayanGelenHat2.Name = "SlueArayanGelenHat2";
            this.SlueArayanGelenHat2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SlueArayanGelenHat2.Size = new System.Drawing.Size(246, 20);
            this.SlueArayanGelenHat2.TabIndex = 16;
            this.SlueArayanGelenHat2.EditValueChanged += new System.EventHandler(this.SlueArayanGelen_EditValueChanged);
            this.SlueArayanGelenHat2.Enter += new System.EventHandler(this.SlueArayanGelen_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Arayan:";
            // 
            // btnYeniAramaGelenHat2
            // 
            this.btnYeniAramaGelenHat2.Location = new System.Drawing.Point(26, 144);
            this.btnYeniAramaGelenHat2.Name = "btnYeniAramaGelenHat2";
            this.btnYeniAramaGelenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnYeniAramaGelenHat2.TabIndex = 15;
            this.btnYeniAramaGelenHat2.Text = "Yeni Arama";
            this.btnYeniAramaGelenHat2.UseVisualStyleBackColor = true;
            this.btnYeniAramaGelenHat2.Click += new System.EventHandler(this.btnYeniAramaGelen_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "TC No:";
            // 
            // btnKapatGelenHat2
            // 
            this.btnKapatGelenHat2.Location = new System.Drawing.Point(233, 115);
            this.btnKapatGelenHat2.Name = "btnKapatGelenHat2";
            this.btnKapatGelenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnKapatGelenHat2.TabIndex = 14;
            this.btnKapatGelenHat2.Text = "Kapat";
            this.btnKapatGelenHat2.UseVisualStyleBackColor = true;
            this.btnKapatGelenHat2.Click += new System.EventHandler(this.btnKapatGelen_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "M��teri No:";
            // 
            // btnKonferansGelenHat2
            // 
            this.btnKonferansGelenHat2.Location = new System.Drawing.Point(131, 144);
            this.btnKonferansGelenHat2.Name = "btnKonferansGelenHat2";
            this.btnKonferansGelenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnKonferansGelenHat2.TabIndex = 13;
            this.btnKonferansGelenHat2.Text = "Konferans";
            this.btnKonferansGelenHat2.UseVisualStyleBackColor = true;
            this.btnKonferansGelenHat2.Click += new System.EventHandler(this.btnKonferansGelen_Click);
            // 
            // txtBoxMusteriNoGelenHat2
            // 
            this.txtBoxMusteriNoGelenHat2.Location = new System.Drawing.Point(76, 60);
            this.txtBoxMusteriNoGelenHat2.Name = "txtBoxMusteriNoGelenHat2";
            this.txtBoxMusteriNoGelenHat2.ReadOnly = true;
            this.txtBoxMusteriNoGelenHat2.Size = new System.Drawing.Size(246, 20);
            this.txtBoxMusteriNoGelenHat2.TabIndex = 5;
            // 
            // btnYonlendirGelenHat2
            // 
            this.btnYonlendirGelenHat2.Location = new System.Drawing.Point(233, 143);
            this.btnYonlendirGelenHat2.Name = "btnYonlendirGelenHat2";
            this.btnYonlendirGelenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnYonlendirGelenHat2.TabIndex = 12;
            this.btnYonlendirGelenHat2.Text = "Y�nlendir";
            this.btnYonlendirGelenHat2.UseVisualStyleBackColor = true;
            this.btnYonlendirGelenHat2.Click += new System.EventHandler(this.btnYonlendirGelen_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Telefon No:";
            // 
            // btnGeriCevirGelenHat2
            // 
            this.btnGeriCevirGelenHat2.Location = new System.Drawing.Point(131, 115);
            this.btnGeriCevirGelenHat2.Name = "btnGeriCevirGelenHat2";
            this.btnGeriCevirGelenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnGeriCevirGelenHat2.TabIndex = 11;
            this.btnGeriCevirGelenHat2.Text = "Geri �evir";
            this.btnGeriCevirGelenHat2.UseVisualStyleBackColor = true;
            this.btnGeriCevirGelenHat2.Click += new System.EventHandler(this.btnGeriCevirGelen_Click);
            // 
            // txtBoxTelNoGelenHat2
            // 
            this.txtBoxTelNoGelenHat2.Location = new System.Drawing.Point(76, 88);
            this.txtBoxTelNoGelenHat2.Name = "txtBoxTelNoGelenHat2";
            this.txtBoxTelNoGelenHat2.ReadOnly = true;
            this.txtBoxTelNoGelenHat2.Size = new System.Drawing.Size(246, 20);
            this.txtBoxTelNoGelenHat2.TabIndex = 7;
            this.txtBoxTelNoGelenHat2.TextChanged += new System.EventHandler(this.txtBoxTelNoGelenHat2_TextChanged);
            // 
            // btnCevaplaGelenHat2
            // 
            this.btnCevaplaGelenHat2.Location = new System.Drawing.Point(25, 115);
            this.btnCevaplaGelenHat2.Name = "btnCevaplaGelenHat2";
            this.btnCevaplaGelenHat2.Size = new System.Drawing.Size(90, 23);
            this.btnCevaplaGelenHat2.TabIndex = 10;
            this.btnCevaplaGelenHat2.Text = "Cevapla";
            this.btnCevaplaGelenHat2.UseVisualStyleBackColor = true;
            this.btnCevaplaGelenHat2.Click += new System.EventHandler(this.btnCevaplaGelen_Click);
            // 
            // tbPageGorusmeTutanagiHat2
            // 
            this.tbPageGorusmeTutanagiHat2.Controls.Add(this.panel22);
            this.tbPageGorusmeTutanagiHat2.Controls.Add(this.panel23);
            this.tbPageGorusmeTutanagiHat2.Location = new System.Drawing.Point(4, 22);
            this.tbPageGorusmeTutanagiHat2.Name = "tbPageGorusmeTutanagiHat2";
            this.tbPageGorusmeTutanagiHat2.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageGorusmeTutanagiHat2.Size = new System.Drawing.Size(553, 493);
            this.tbPageGorusmeTutanagiHat2.TabIndex = 3;
            this.tbPageGorusmeTutanagiHat2.Text = "G�r��me Tutana��";
            this.tbPageGorusmeTutanagiHat2.UseVisualStyleBackColor = true;
            // 
            // panel22
            // 
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(3, 48);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(547, 442);
            this.panel22.TabIndex = 2;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.btnGorusmeKaydetHat2);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(3, 3);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(547, 45);
            this.panel23.TabIndex = 1;
            // 
            // btnGorusmeKaydetHat2
            // 
            this.btnGorusmeKaydetHat2.Location = new System.Drawing.Point(17, 14);
            this.btnGorusmeKaydetHat2.Name = "btnGorusmeKaydetHat2";
            this.btnGorusmeKaydetHat2.Size = new System.Drawing.Size(75, 25);
            this.btnGorusmeKaydetHat2.TabIndex = 0;
            this.btnGorusmeKaydetHat2.Text = "Kaydet";
            this.btnGorusmeKaydetHat2.UseVisualStyleBackColor = true;
            this.btnGorusmeKaydetHat2.Click += new System.EventHandler(this.btnGorusmeKaydet_Click);
            // 
            // tbPageEskiGorusmelerHat2
            // 
            this.tbPageEskiGorusmelerHat2.Controls.Add(this.panel24);
            this.tbPageEskiGorusmelerHat2.Controls.Add(this.panel25);
            this.tbPageEskiGorusmelerHat2.Location = new System.Drawing.Point(4, 22);
            this.tbPageEskiGorusmelerHat2.Name = "tbPageEskiGorusmelerHat2";
            this.tbPageEskiGorusmelerHat2.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageEskiGorusmelerHat2.Size = new System.Drawing.Size(553, 493);
            this.tbPageEskiGorusmelerHat2.TabIndex = 2;
            this.tbPageEskiGorusmelerHat2.Text = "Eski G�r��meler";
            this.tbPageEskiGorusmelerHat2.UseVisualStyleBackColor = true;
            // 
            // panel24
            // 
            this.panel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel24.Location = new System.Drawing.Point(3, 35);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(547, 455);
            this.panel24.TabIndex = 2;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.btnEskiGorusmeGetirHat2);
            this.panel25.Controls.Add(this.rdBtnSahisEskiGorusmeHat2);
            this.panel25.Controls.Add(this.rdBtnDosyaEskiGorusmeHat2);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel25.Location = new System.Drawing.Point(3, 3);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(547, 32);
            this.panel25.TabIndex = 1;
            // 
            // btnEskiGorusmeGetirHat2
            // 
            this.btnEskiGorusmeGetirHat2.Location = new System.Drawing.Point(428, 5);
            this.btnEskiGorusmeGetirHat2.Name = "btnEskiGorusmeGetirHat2";
            this.btnEskiGorusmeGetirHat2.Size = new System.Drawing.Size(44, 23);
            this.btnEskiGorusmeGetirHat2.TabIndex = 2;
            this.btnEskiGorusmeGetirHat2.Text = "Bul";
            this.btnEskiGorusmeGetirHat2.UseVisualStyleBackColor = true;
            this.btnEskiGorusmeGetirHat2.Click += new System.EventHandler(this.btnEskiGorusmeGetir_Click);
            // 
            // rdBtnSahisEskiGorusmeHat2
            // 
            this.rdBtnSahisEskiGorusmeHat2.AutoSize = true;
            this.rdBtnSahisEskiGorusmeHat2.Location = new System.Drawing.Point(187, 9);
            this.rdBtnSahisEskiGorusmeHat2.Name = "rdBtnSahisEskiGorusmeHat2";
            this.rdBtnSahisEskiGorusmeHat2.Size = new System.Drawing.Size(229, 17);
            this.rdBtnSahisEskiGorusmeHat2.TabIndex = 1;
            this.rdBtnSahisEskiGorusmeHat2.Text = "Se�ili �ahs�n t�m dosyalar�ndaki g�r��meleri";
            this.rdBtnSahisEskiGorusmeHat2.UseVisualStyleBackColor = true;
            // 
            // rdBtnDosyaEskiGorusmeHat2
            // 
            this.rdBtnDosyaEskiGorusmeHat2.AutoSize = true;
            this.rdBtnDosyaEskiGorusmeHat2.Checked = true;
            this.rdBtnDosyaEskiGorusmeHat2.Location = new System.Drawing.Point(7, 9);
            this.rdBtnDosyaEskiGorusmeHat2.Name = "rdBtnDosyaEskiGorusmeHat2";
            this.rdBtnDosyaEskiGorusmeHat2.Size = new System.Drawing.Size(175, 17);
            this.rdBtnDosyaEskiGorusmeHat2.TabIndex = 0;
            this.rdBtnDosyaEskiGorusmeHat2.TabStop = true;
            this.rdBtnDosyaEskiGorusmeHat2.Text = "Se�ili dosyadaki t�m g�r��meler";
            this.rdBtnDosyaEskiGorusmeHat2.UseVisualStyleBackColor = true;
            // 
            // tbPageIcraHesapHat2
            // 
            this.tbPageIcraHesapHat2.Controls.Add(this.panel26);
            this.tbPageIcraHesapHat2.Location = new System.Drawing.Point(4, 22);
            this.tbPageIcraHesapHat2.Name = "tbPageIcraHesapHat2";
            this.tbPageIcraHesapHat2.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageIcraHesapHat2.Size = new System.Drawing.Size(553, 493);
            this.tbPageIcraHesapHat2.TabIndex = 4;
            this.tbPageIcraHesapHat2.Text = "�cra Hesap";
            this.tbPageIcraHesapHat2.UseVisualStyleBackColor = true;
            // 
            // panel26
            // 
            this.panel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel26.Location = new System.Drawing.Point(3, 3);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(547, 487);
            this.panel26.TabIndex = 2;
            // 
            // xtraTabHat3
            // 
            this.xtraTabHat3.Controls.Add(this.tabControl2);
            this.xtraTabHat3.Name = "xtraTabHat3";
            this.xtraTabHat3.Size = new System.Drawing.Size(567, 539);
            this.xtraTabHat3.Text = "Hat 3";
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(567, 539);
            this.tabControl2.TabIndex = 1;
            // 
            // xtraTabHat4
            // 
            this.xtraTabHat4.Controls.Add(this.tabControl3);
            this.xtraTabHat4.Name = "xtraTabHat4";
            this.xtraTabHat4.Size = new System.Drawing.Size(567, 539);
            this.xtraTabHat4.Text = "Hat 4";
            // 
            // tabControl3
            // 
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(567, 539);
            this.tabControl3.TabIndex = 1;
            // 
            // xtraTabSmsFaxMail
            // 
            this.xtraTabSmsFaxMail.Name = "xtraTabSmsFaxMail";
            this.xtraTabSmsFaxMail.Size = new System.Drawing.Size(567, 539);
            this.xtraTabSmsFaxMail.Text = "SMS-FAX-MA�L";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel13);
            this.panel5.Controls.Add(this.panel11);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(2, 569);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(573, 75);
            this.panel5.TabIndex = 1;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.lblHatBilgisi4);
            this.panel13.Controls.Add(this.lblHatBilgisi3);
            this.panel13.Controls.Add(this.lblHatBilgisi2);
            this.panel13.Controls.Add(this.lblHatBilgisi1);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(190, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(383, 75);
            this.panel13.TabIndex = 1;
            // 
            // lblHatBilgisi4
            // 
            this.lblHatBilgisi4.AutoSize = true;
            this.lblHatBilgisi4.Location = new System.Drawing.Point(6, 58);
            this.lblHatBilgisi4.Name = "lblHatBilgisi4";
            this.lblHatBilgisi4.Size = new System.Drawing.Size(36, 13);
            this.lblHatBilgisi4.TabIndex = 3;
            this.lblHatBilgisi4.Text = "Hat 4:";
            // 
            // lblHatBilgisi3
            // 
            this.lblHatBilgisi3.AutoSize = true;
            this.lblHatBilgisi3.Location = new System.Drawing.Point(5, 40);
            this.lblHatBilgisi3.Name = "lblHatBilgisi3";
            this.lblHatBilgisi3.Size = new System.Drawing.Size(36, 13);
            this.lblHatBilgisi3.TabIndex = 2;
            this.lblHatBilgisi3.Text = "Hat 3:";
            // 
            // lblHatBilgisi2
            // 
            this.lblHatBilgisi2.AutoSize = true;
            this.lblHatBilgisi2.Location = new System.Drawing.Point(5, 22);
            this.lblHatBilgisi2.Name = "lblHatBilgisi2";
            this.lblHatBilgisi2.Size = new System.Drawing.Size(36, 13);
            this.lblHatBilgisi2.TabIndex = 1;
            this.lblHatBilgisi2.Text = "Hat 2:";
            // 
            // lblHatBilgisi1
            // 
            this.lblHatBilgisi1.AutoSize = true;
            this.lblHatBilgisi1.Location = new System.Drawing.Point(4, 4);
            this.lblHatBilgisi1.Name = "lblHatBilgisi1";
            this.lblHatBilgisi1.Size = new System.Drawing.Size(36, 13);
            this.lblHatBilgisi1.TabIndex = 0;
            this.lblHatBilgisi1.Text = "Hat 1:";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel17);
            this.panel11.Controls.Add(this.panel16);
            this.panel11.Controls.Add(this.panel15);
            this.panel11.Controls.Add(this.panel14);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(190, 75);
            this.panel11.TabIndex = 0;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.label12);
            this.panel17.Controls.Add(this.pictureBox4);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(141, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(47, 75);
            this.panel17.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Hat 4";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(47, 55);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.label11);
            this.panel16.Controls.Add(this.pictureBox3);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(94, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(47, 75);
            this.panel16.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Hat 3";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 55);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label6);
            this.panel15.Controls.Add(this.pictureBox2);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(47, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(47, 75);
            this.panel15.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Hat 2";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 55);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label5);
            this.panel14.Controls.Add(this.pictureBox1);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(47, 75);
            this.panel14.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Hat 1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 55);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn13,
            this.gridColumn12,
            this.gridColumn14});
            this.gridView2.GroupCount = 1;
            this.gridView2.IndicatorWidth = 20;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tipi";
            this.gridColumn1.ColumnEdit = this.repositoryItemImageComboBox2;
            this.gridColumn1.FieldName = "TIPI";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            this.repositoryItemImageComboBox2.SmallImages = this.�mageList1;
            // 
            // �mageList1
            // 
            this.�mageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.�mageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.�mageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Dosya No";
            this.gridColumn9.FieldName = "FOY_NO";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Adliye";
            this.gridColumn10.ColumnEdit = this.repositoryItemLookUpEdit31;
            this.gridColumn10.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit31
            // 
            this.repositoryItemLookUpEdit31.AutoHeight = false;
            this.repositoryItemLookUpEdit31.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit31.Name = "repositoryItemLookUpEdit31";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "No";
            this.gridColumn11.ColumnEdit = this.repositoryItemLookUpEdit32;
            this.gridColumn11.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            // 
            // repositoryItemLookUpEdit32
            // 
            this.repositoryItemLookUpEdit32.AutoHeight = false;
            this.repositoryItemLookUpEdit32.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit32.Name = "repositoryItemLookUpEdit32";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "G�rev";
            this.gridColumn13.ColumnEdit = this.repositoryItemLookUpEdit33;
            this.gridColumn13.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            // 
            // repositoryItemLookUpEdit33
            // 
            this.repositoryItemLookUpEdit33.AutoHeight = false;
            this.repositoryItemLookUpEdit33.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit33.Name = "repositoryItemLookUpEdit33";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Esas No";
            this.gridColumn12.FieldName = "ESAS_NO";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Takip Tarihi";
            this.gridColumn14.FieldName = "TAKIP_TARIHI";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 5;
            // 
            // gridView13
            // 
            this.gridView13.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn78,
            this.gridColumn79,
            this.gridColumn80,
            this.gridColumn81,
            this.gridColumn82,
            this.gridColumn83,
            this.gridColumn84,
            this.gridColumn85});
            this.gridView13.GroupCount = 1;
            this.gridView13.IndicatorWidth = 20;
            this.gridView13.Name = "gridView13";
            this.gridView13.OptionsView.ShowAutoFilterRow = true;
            this.gridView13.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn78, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn78
            // 
            this.gridColumn78.Caption = "Tipi";
            this.gridColumn78.ColumnEdit = this.repositoryItemImageComboBox12;
            this.gridColumn78.FieldName = "TIPI";
            this.gridColumn78.Name = "gridColumn78";
            this.gridColumn78.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn78.Visible = true;
            this.gridColumn78.VisibleIndex = 0;
            // 
            // repositoryItemImageComboBox12
            // 
            this.repositoryItemImageComboBox12.AutoHeight = false;
            this.repositoryItemImageComboBox12.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox12.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox12.Name = "repositoryItemImageComboBox12";
            this.repositoryItemImageComboBox12.SmallImages = this.�mageList1;
            // 
            // gridColumn79
            // 
            this.gridColumn79.Caption = "Dosya No";
            this.gridColumn79.FieldName = "FOY_NO";
            this.gridColumn79.Name = "gridColumn79";
            this.gridColumn79.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn79.Visible = true;
            this.gridColumn79.VisibleIndex = 0;
            // 
            // gridColumn80
            // 
            this.gridColumn80.Caption = "Adliye";
            this.gridColumn80.ColumnEdit = this.repositoryItemLookUpEdit34;
            this.gridColumn80.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn80.Name = "gridColumn80";
            this.gridColumn80.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn80.Visible = true;
            this.gridColumn80.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit34
            // 
            this.repositoryItemLookUpEdit34.AutoHeight = false;
            this.repositoryItemLookUpEdit34.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit34.Name = "repositoryItemLookUpEdit34";
            // 
            // gridColumn81
            // 
            this.gridColumn81.Caption = "No";
            this.gridColumn81.ColumnEdit = this.repositoryItemLookUpEdit36;
            this.gridColumn81.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn81.Name = "gridColumn81";
            this.gridColumn81.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn81.Visible = true;
            this.gridColumn81.VisibleIndex = 2;
            // 
            // repositoryItemLookUpEdit36
            // 
            this.repositoryItemLookUpEdit36.AutoHeight = false;
            this.repositoryItemLookUpEdit36.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit36.Name = "repositoryItemLookUpEdit36";
            // 
            // gridColumn82
            // 
            this.gridColumn82.Caption = "G�rev";
            this.gridColumn82.ColumnEdit = this.repositoryItemLookUpEdit35;
            this.gridColumn82.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn82.Name = "gridColumn82";
            this.gridColumn82.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn82.Visible = true;
            this.gridColumn82.VisibleIndex = 3;
            // 
            // repositoryItemLookUpEdit35
            // 
            this.repositoryItemLookUpEdit35.AutoHeight = false;
            this.repositoryItemLookUpEdit35.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit35.Name = "repositoryItemLookUpEdit35";
            // 
            // gridColumn83
            // 
            this.gridColumn83.Caption = "Esas No";
            this.gridColumn83.FieldName = "ESAS_NO";
            this.gridColumn83.Name = "gridColumn83";
            this.gridColumn83.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn83.Visible = true;
            this.gridColumn83.VisibleIndex = 4;
            // 
            // gridColumn84
            // 
            this.gridColumn84.Caption = "Takip Tarihi";
            this.gridColumn84.FieldName = "TAKIP_TARIHI";
            this.gridColumn84.Name = "gridColumn84";
            this.gridColumn84.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn84.Visible = true;
            this.gridColumn84.VisibleIndex = 5;
            // 
            // gridColumn85
            // 
            this.gridColumn85.Caption = "isSelected";
            this.gridColumn85.Name = "gridColumn85";
            this.gridColumn85.Visible = true;
            this.gridColumn85.VisibleIndex = 6;
            // 
            // gridView1
            // 
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21});
            this.gridView3.GroupCount = 1;
            this.gridView3.IndicatorWidth = 20;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowAutoFilterRow = true;
            this.gridView3.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn15, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Tipi";
            this.gridColumn15.ColumnEdit = this.repositoryItemImageComboBox3;
            this.gridColumn15.FieldName = "TIPI";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            this.gridColumn15.Width = 87;
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Raf No";
            this.gridColumn16.FieldName = "FOY_NO";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 0;
            this.gridColumn16.Width = 62;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Esas No";
            this.gridColumn17.FieldName = "ESAS_NO";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 1;
            this.gridColumn17.Width = 61;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Adliye";
            this.gridColumn18.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.gridColumn18.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            this.gridColumn18.Width = 63;
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "No";
            this.gridColumn19.ColumnEdit = this.repositoryItemLookUpEdit5;
            this.gridColumn19.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 3;
            this.gridColumn19.Width = 40;
            // 
            // repositoryItemLookUpEdit5
            // 
            this.repositoryItemLookUpEdit5.AutoHeight = false;
            this.repositoryItemLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit5.Name = "repositoryItemLookUpEdit5";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "G�rev";
            this.gridColumn20.ColumnEdit = this.repositoryItemLookUpEdit6;
            this.gridColumn20.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 4;
            this.gridColumn20.Width = 68;
            // 
            // repositoryItemLookUpEdit6
            // 
            this.repositoryItemLookUpEdit6.AutoHeight = false;
            this.repositoryItemLookUpEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit6.Name = "repositoryItemLookUpEdit6";
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Takip T.";
            this.gridColumn21.FieldName = "TAKIP_TARIHI";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 5;
            this.gridColumn21.Width = 89;
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28});
            this.gridView4.GroupCount = 1;
            this.gridView4.IndicatorWidth = 20;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsView.ShowAutoFilterRow = true;
            this.gridView4.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn22, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Tipi";
            this.gridColumn22.ColumnEdit = this.repositoryItemImageComboBox4;
            this.gridColumn22.FieldName = "TIPI";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 0;
            this.gridColumn22.Width = 87;
            // 
            // repositoryItemImageComboBox4
            // 
            this.repositoryItemImageComboBox4.AutoHeight = false;
            this.repositoryItemImageComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox4.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox4.Name = "repositoryItemImageComboBox4";
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Raf No";
            this.gridColumn23.FieldName = "FOY_NO";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.ReadOnly = true;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 0;
            this.gridColumn23.Width = 62;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Esas No";
            this.gridColumn24.FieldName = "ESAS_NO";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.ReadOnly = true;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 1;
            this.gridColumn24.Width = 61;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Adliye";
            this.gridColumn25.ColumnEdit = this.repositoryItemLookUpEdit7;
            this.gridColumn25.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.ReadOnly = true;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 2;
            this.gridColumn25.Width = 63;
            // 
            // repositoryItemLookUpEdit7
            // 
            this.repositoryItemLookUpEdit7.AutoHeight = false;
            this.repositoryItemLookUpEdit7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit7.Name = "repositoryItemLookUpEdit7";
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "No";
            this.gridColumn26.ColumnEdit = this.repositoryItemLookUpEdit8;
            this.gridColumn26.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.ReadOnly = true;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 3;
            this.gridColumn26.Width = 40;
            // 
            // repositoryItemLookUpEdit8
            // 
            this.repositoryItemLookUpEdit8.AutoHeight = false;
            this.repositoryItemLookUpEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit8.Name = "repositoryItemLookUpEdit8";
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "G�rev";
            this.gridColumn27.ColumnEdit = this.repositoryItemLookUpEdit9;
            this.gridColumn27.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.ReadOnly = true;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 4;
            this.gridColumn27.Width = 68;
            // 
            // repositoryItemLookUpEdit9
            // 
            this.repositoryItemLookUpEdit9.AutoHeight = false;
            this.repositoryItemLookUpEdit9.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit9.Name = "repositoryItemLookUpEdit9";
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Takip T.";
            this.gridColumn28.FieldName = "TAKIP_TARIHI";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.ReadOnly = true;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 5;
            this.gridColumn28.Width = 89;
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35});
            this.gridView5.GroupCount = 1;
            this.gridView5.IndicatorWidth = 20;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsView.ShowAutoFilterRow = true;
            this.gridView5.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn29, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Tipi";
            this.gridColumn29.ColumnEdit = this.repositoryItemImageComboBox5;
            this.gridColumn29.FieldName = "TIPI";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.ReadOnly = true;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 0;
            this.gridColumn29.Width = 87;
            // 
            // repositoryItemImageComboBox5
            // 
            this.repositoryItemImageComboBox5.AutoHeight = false;
            this.repositoryItemImageComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox5.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox5.Name = "repositoryItemImageComboBox5";
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Raf No";
            this.gridColumn30.FieldName = "FOY_NO";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.ReadOnly = true;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 0;
            this.gridColumn30.Width = 62;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Esas No";
            this.gridColumn31.FieldName = "ESAS_NO";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.ReadOnly = true;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 1;
            this.gridColumn31.Width = 61;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Adliye";
            this.gridColumn32.ColumnEdit = this.repositoryItemLookUpEdit10;
            this.gridColumn32.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.ReadOnly = true;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 2;
            this.gridColumn32.Width = 63;
            // 
            // repositoryItemLookUpEdit10
            // 
            this.repositoryItemLookUpEdit10.AutoHeight = false;
            this.repositoryItemLookUpEdit10.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit10.Name = "repositoryItemLookUpEdit10";
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "No";
            this.gridColumn33.ColumnEdit = this.repositoryItemLookUpEdit11;
            this.gridColumn33.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.ReadOnly = true;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 3;
            this.gridColumn33.Width = 40;
            // 
            // repositoryItemLookUpEdit11
            // 
            this.repositoryItemLookUpEdit11.AutoHeight = false;
            this.repositoryItemLookUpEdit11.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit11.Name = "repositoryItemLookUpEdit11";
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "G�rev";
            this.gridColumn34.ColumnEdit = this.repositoryItemLookUpEdit12;
            this.gridColumn34.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.ReadOnly = true;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 4;
            this.gridColumn34.Width = 68;
            // 
            // repositoryItemLookUpEdit12
            // 
            this.repositoryItemLookUpEdit12.AutoHeight = false;
            this.repositoryItemLookUpEdit12.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit12.Name = "repositoryItemLookUpEdit12";
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Takip T.";
            this.gridColumn35.FieldName = "TAKIP_TARIHI";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.ReadOnly = true;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 5;
            this.gridColumn35.Width = 89;
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41,
            this.gridColumn42});
            this.gridView6.GroupCount = 1;
            this.gridView6.IndicatorWidth = 20;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsView.ShowAutoFilterRow = true;
            this.gridView6.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn36, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Tipi";
            this.gridColumn36.ColumnEdit = this.repositoryItemImageComboBox6;
            this.gridColumn36.FieldName = "TIPI";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.ReadOnly = true;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 0;
            this.gridColumn36.Width = 87;
            // 
            // repositoryItemImageComboBox6
            // 
            this.repositoryItemImageComboBox6.AutoHeight = false;
            this.repositoryItemImageComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox6.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox6.Name = "repositoryItemImageComboBox6";
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Raf No";
            this.gridColumn37.FieldName = "FOY_NO";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.ReadOnly = true;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 0;
            this.gridColumn37.Width = 62;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "Esas No";
            this.gridColumn38.FieldName = "ESAS_NO";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.ReadOnly = true;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 1;
            this.gridColumn38.Width = 61;
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "Adliye";
            this.gridColumn39.ColumnEdit = this.repositoryItemLookUpEdit13;
            this.gridColumn39.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsColumn.ReadOnly = true;
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 2;
            this.gridColumn39.Width = 63;
            // 
            // repositoryItemLookUpEdit13
            // 
            this.repositoryItemLookUpEdit13.AutoHeight = false;
            this.repositoryItemLookUpEdit13.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit13.Name = "repositoryItemLookUpEdit13";
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "No";
            this.gridColumn40.ColumnEdit = this.repositoryItemLookUpEdit14;
            this.gridColumn40.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsColumn.ReadOnly = true;
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 3;
            this.gridColumn40.Width = 40;
            // 
            // repositoryItemLookUpEdit14
            // 
            this.repositoryItemLookUpEdit14.AutoHeight = false;
            this.repositoryItemLookUpEdit14.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit14.Name = "repositoryItemLookUpEdit14";
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "G�rev";
            this.gridColumn41.ColumnEdit = this.repositoryItemLookUpEdit15;
            this.gridColumn41.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.OptionsColumn.ReadOnly = true;
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 4;
            this.gridColumn41.Width = 68;
            // 
            // repositoryItemLookUpEdit15
            // 
            this.repositoryItemLookUpEdit15.AutoHeight = false;
            this.repositoryItemLookUpEdit15.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit15.Name = "repositoryItemLookUpEdit15";
            // 
            // gridColumn42
            // 
            this.gridColumn42.Caption = "Takip T.";
            this.gridColumn42.FieldName = "TAKIP_TARIHI";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.OptionsColumn.ReadOnly = true;
            this.gridColumn42.Visible = true;
            this.gridColumn42.VisibleIndex = 5;
            this.gridColumn42.Width = 89;
            // 
            // gridView7
            // 
            this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn43,
            this.gridColumn44,
            this.gridColumn45,
            this.gridColumn46,
            this.gridColumn47,
            this.gridColumn48,
            this.gridColumn49});
            this.gridView7.GroupCount = 1;
            this.gridView7.IndicatorWidth = 20;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsView.ShowAutoFilterRow = true;
            this.gridView7.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn43, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn43
            // 
            this.gridColumn43.Caption = "Tipi";
            this.gridColumn43.ColumnEdit = this.repositoryItemImageComboBox7;
            this.gridColumn43.FieldName = "TIPI";
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn43.OptionsColumn.ReadOnly = true;
            this.gridColumn43.Visible = true;
            this.gridColumn43.VisibleIndex = 0;
            this.gridColumn43.Width = 87;
            // 
            // repositoryItemImageComboBox7
            // 
            this.repositoryItemImageComboBox7.AutoHeight = false;
            this.repositoryItemImageComboBox7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox7.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox7.Name = "repositoryItemImageComboBox7";
            // 
            // gridColumn44
            // 
            this.gridColumn44.Caption = "Raf No";
            this.gridColumn44.FieldName = "FOY_NO";
            this.gridColumn44.Name = "gridColumn44";
            this.gridColumn44.OptionsColumn.ReadOnly = true;
            this.gridColumn44.Visible = true;
            this.gridColumn44.VisibleIndex = 0;
            this.gridColumn44.Width = 62;
            // 
            // gridColumn45
            // 
            this.gridColumn45.Caption = "Esas No";
            this.gridColumn45.FieldName = "ESAS_NO";
            this.gridColumn45.Name = "gridColumn45";
            this.gridColumn45.OptionsColumn.ReadOnly = true;
            this.gridColumn45.Visible = true;
            this.gridColumn45.VisibleIndex = 1;
            this.gridColumn45.Width = 61;
            // 
            // gridColumn46
            // 
            this.gridColumn46.Caption = "Adliye";
            this.gridColumn46.ColumnEdit = this.repositoryItemLookUpEdit16;
            this.gridColumn46.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn46.Name = "gridColumn46";
            this.gridColumn46.OptionsColumn.ReadOnly = true;
            this.gridColumn46.Visible = true;
            this.gridColumn46.VisibleIndex = 2;
            this.gridColumn46.Width = 63;
            // 
            // repositoryItemLookUpEdit16
            // 
            this.repositoryItemLookUpEdit16.AutoHeight = false;
            this.repositoryItemLookUpEdit16.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit16.Name = "repositoryItemLookUpEdit16";
            // 
            // gridColumn47
            // 
            this.gridColumn47.Caption = "No";
            this.gridColumn47.ColumnEdit = this.repositoryItemLookUpEdit17;
            this.gridColumn47.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn47.Name = "gridColumn47";
            this.gridColumn47.OptionsColumn.ReadOnly = true;
            this.gridColumn47.Visible = true;
            this.gridColumn47.VisibleIndex = 3;
            this.gridColumn47.Width = 40;
            // 
            // repositoryItemLookUpEdit17
            // 
            this.repositoryItemLookUpEdit17.AutoHeight = false;
            this.repositoryItemLookUpEdit17.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit17.Name = "repositoryItemLookUpEdit17";
            // 
            // gridColumn48
            // 
            this.gridColumn48.Caption = "G�rev";
            this.gridColumn48.ColumnEdit = this.repositoryItemLookUpEdit18;
            this.gridColumn48.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn48.Name = "gridColumn48";
            this.gridColumn48.OptionsColumn.ReadOnly = true;
            this.gridColumn48.Visible = true;
            this.gridColumn48.VisibleIndex = 4;
            this.gridColumn48.Width = 68;
            // 
            // repositoryItemLookUpEdit18
            // 
            this.repositoryItemLookUpEdit18.AutoHeight = false;
            this.repositoryItemLookUpEdit18.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit18.Name = "repositoryItemLookUpEdit18";
            // 
            // gridColumn49
            // 
            this.gridColumn49.Caption = "Takip T.";
            this.gridColumn49.FieldName = "TAKIP_TARIHI";
            this.gridColumn49.Name = "gridColumn49";
            this.gridColumn49.OptionsColumn.ReadOnly = true;
            this.gridColumn49.Visible = true;
            this.gridColumn49.VisibleIndex = 5;
            this.gridColumn49.Width = 89;
            // 
            // gridView8
            // 
            this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn50,
            this.gridColumn51,
            this.gridColumn52,
            this.gridColumn53,
            this.gridColumn54,
            this.gridColumn55,
            this.gridColumn56});
            this.gridView8.GroupCount = 1;
            this.gridView8.IndicatorWidth = 20;
            this.gridView8.Name = "gridView8";
            this.gridView8.OptionsView.ShowAutoFilterRow = true;
            this.gridView8.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn50, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn50
            // 
            this.gridColumn50.Caption = "Tipi";
            this.gridColumn50.ColumnEdit = this.repositoryItemImageComboBox8;
            this.gridColumn50.FieldName = "TIPI";
            this.gridColumn50.Name = "gridColumn50";
            this.gridColumn50.OptionsColumn.ReadOnly = true;
            this.gridColumn50.Visible = true;
            this.gridColumn50.VisibleIndex = 0;
            this.gridColumn50.Width = 87;
            // 
            // repositoryItemImageComboBox8
            // 
            this.repositoryItemImageComboBox8.AutoHeight = false;
            this.repositoryItemImageComboBox8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox8.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox8.Name = "repositoryItemImageComboBox8";
            // 
            // gridColumn51
            // 
            this.gridColumn51.Caption = "Raf No";
            this.gridColumn51.FieldName = "FOY_NO";
            this.gridColumn51.Name = "gridColumn51";
            this.gridColumn51.OptionsColumn.ReadOnly = true;
            this.gridColumn51.Visible = true;
            this.gridColumn51.VisibleIndex = 0;
            this.gridColumn51.Width = 62;
            // 
            // gridColumn52
            // 
            this.gridColumn52.Caption = "Esas No";
            this.gridColumn52.FieldName = "ESAS_NO";
            this.gridColumn52.Name = "gridColumn52";
            this.gridColumn52.OptionsColumn.ReadOnly = true;
            this.gridColumn52.Visible = true;
            this.gridColumn52.VisibleIndex = 1;
            this.gridColumn52.Width = 61;
            // 
            // gridColumn53
            // 
            this.gridColumn53.Caption = "Adliye";
            this.gridColumn53.ColumnEdit = this.repositoryItemLookUpEdit19;
            this.gridColumn53.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn53.Name = "gridColumn53";
            this.gridColumn53.OptionsColumn.ReadOnly = true;
            this.gridColumn53.Visible = true;
            this.gridColumn53.VisibleIndex = 2;
            this.gridColumn53.Width = 63;
            // 
            // repositoryItemLookUpEdit19
            // 
            this.repositoryItemLookUpEdit19.AutoHeight = false;
            this.repositoryItemLookUpEdit19.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit19.Name = "repositoryItemLookUpEdit19";
            // 
            // gridColumn54
            // 
            this.gridColumn54.Caption = "No";
            this.gridColumn54.ColumnEdit = this.repositoryItemLookUpEdit20;
            this.gridColumn54.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn54.Name = "gridColumn54";
            this.gridColumn54.OptionsColumn.ReadOnly = true;
            this.gridColumn54.Visible = true;
            this.gridColumn54.VisibleIndex = 3;
            this.gridColumn54.Width = 40;
            // 
            // repositoryItemLookUpEdit20
            // 
            this.repositoryItemLookUpEdit20.AutoHeight = false;
            this.repositoryItemLookUpEdit20.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit20.Name = "repositoryItemLookUpEdit20";
            // 
            // gridColumn55
            // 
            this.gridColumn55.Caption = "G�rev";
            this.gridColumn55.ColumnEdit = this.repositoryItemLookUpEdit21;
            this.gridColumn55.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn55.Name = "gridColumn55";
            this.gridColumn55.OptionsColumn.ReadOnly = true;
            this.gridColumn55.Visible = true;
            this.gridColumn55.VisibleIndex = 4;
            this.gridColumn55.Width = 68;
            // 
            // repositoryItemLookUpEdit21
            // 
            this.repositoryItemLookUpEdit21.AutoHeight = false;
            this.repositoryItemLookUpEdit21.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit21.Name = "repositoryItemLookUpEdit21";
            // 
            // gridColumn56
            // 
            this.gridColumn56.Caption = "Takip T.";
            this.gridColumn56.FieldName = "TAKIP_TARIHI";
            this.gridColumn56.Name = "gridColumn56";
            this.gridColumn56.OptionsColumn.ReadOnly = true;
            this.gridColumn56.Visible = true;
            this.gridColumn56.VisibleIndex = 5;
            this.gridColumn56.Width = 89;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // repositoryItemLookUpEdit22
            // 
            this.repositoryItemLookUpEdit22.AutoHeight = false;
            this.repositoryItemLookUpEdit22.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit22.Name = "repositoryItemLookUpEdit22";
            // 
            // rlueBirim
            // 
            this.rlueBirim.AutoHeight = false;
            this.rlueBirim.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueBirim.Name = "rlueBirim";
            // 
            // rlueGorev
            // 
            this.rlueGorev.AutoHeight = false;
            this.rlueGorev.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlueGorev.Name = "rlueGorev";
            // 
            // gridView9
            // 
            this.gridView9.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView9.GroupCount = 1;
            this.gridView9.IndicatorWidth = 20;
            this.gridView9.Name = "gridView9";
            this.gridView9.OptionsView.ShowAutoFilterRow = true;
            this.gridView9.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn8, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tipi";
            this.gridColumn8.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn8.FieldName = "TIPI";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 87;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Raf No";
            this.gridColumn2.FieldName = "FOY_NO";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 62;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Esas No";
            this.gridColumn3.FieldName = "ESAS_NO";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 61;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Adliye";
            this.gridColumn4.ColumnEdit = this.repositoryItemLookUpEdit22;
            this.gridColumn4.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 63;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "No";
            this.gridColumn5.ColumnEdit = this.rlueBirim;
            this.gridColumn5.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 40;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "G�rev";
            this.gridColumn6.ColumnEdit = this.rlueGorev;
            this.gridColumn6.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 68;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Takip T.";
            this.gridColumn7.FieldName = "TAKIP_TARIHI";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 89;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(549, 332);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Bottom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(93, 13);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // repositoryItemImageComboBox9
            // 
            this.repositoryItemImageComboBox9.AutoHeight = false;
            this.repositoryItemImageComboBox9.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox9.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox9.Name = "repositoryItemImageComboBox9";
            // 
            // repositoryItemLookUpEdit23
            // 
            this.repositoryItemLookUpEdit23.AutoHeight = false;
            this.repositoryItemLookUpEdit23.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit23.Name = "repositoryItemLookUpEdit23";
            // 
            // repositoryItemLookUpEdit24
            // 
            this.repositoryItemLookUpEdit24.AutoHeight = false;
            this.repositoryItemLookUpEdit24.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit24.Name = "repositoryItemLookUpEdit24";
            // 
            // gridView10
            // 
            this.gridView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn57,
            this.gridColumn58,
            this.gridColumn59,
            this.gridColumn60,
            this.gridColumn61,
            this.gridColumn62,
            this.gridColumn63});
            this.gridView10.GroupCount = 1;
            this.gridView10.IndicatorWidth = 20;
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsView.ShowAutoFilterRow = true;
            this.gridView10.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn57, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn57
            // 
            this.gridColumn57.Caption = "Tipi";
            this.gridColumn57.ColumnEdit = this.repositoryItemImageComboBox9;
            this.gridColumn57.FieldName = "TIPI";
            this.gridColumn57.Name = "gridColumn57";
            this.gridColumn57.OptionsColumn.ReadOnly = true;
            this.gridColumn57.Visible = true;
            this.gridColumn57.VisibleIndex = 0;
            this.gridColumn57.Width = 87;
            // 
            // gridColumn58
            // 
            this.gridColumn58.Caption = "Raf No";
            this.gridColumn58.FieldName = "FOY_NO";
            this.gridColumn58.Name = "gridColumn58";
            this.gridColumn58.OptionsColumn.ReadOnly = true;
            this.gridColumn58.Visible = true;
            this.gridColumn58.VisibleIndex = 0;
            this.gridColumn58.Width = 62;
            // 
            // gridColumn59
            // 
            this.gridColumn59.Caption = "Esas No";
            this.gridColumn59.FieldName = "ESAS_NO";
            this.gridColumn59.Name = "gridColumn59";
            this.gridColumn59.OptionsColumn.ReadOnly = true;
            this.gridColumn59.Visible = true;
            this.gridColumn59.VisibleIndex = 1;
            this.gridColumn59.Width = 61;
            // 
            // gridColumn60
            // 
            this.gridColumn60.Caption = "Adliye";
            this.gridColumn60.ColumnEdit = this.repositoryItemLookUpEdit22;
            this.gridColumn60.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn60.Name = "gridColumn60";
            this.gridColumn60.OptionsColumn.ReadOnly = true;
            this.gridColumn60.Visible = true;
            this.gridColumn60.VisibleIndex = 2;
            this.gridColumn60.Width = 63;
            // 
            // gridColumn61
            // 
            this.gridColumn61.Caption = "No";
            this.gridColumn61.ColumnEdit = this.repositoryItemLookUpEdit23;
            this.gridColumn61.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn61.Name = "gridColumn61";
            this.gridColumn61.OptionsColumn.ReadOnly = true;
            this.gridColumn61.Visible = true;
            this.gridColumn61.VisibleIndex = 3;
            this.gridColumn61.Width = 40;
            // 
            // gridColumn62
            // 
            this.gridColumn62.Caption = "G�rev";
            this.gridColumn62.ColumnEdit = this.repositoryItemLookUpEdit24;
            this.gridColumn62.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn62.Name = "gridColumn62";
            this.gridColumn62.OptionsColumn.ReadOnly = true;
            this.gridColumn62.Visible = true;
            this.gridColumn62.VisibleIndex = 4;
            this.gridColumn62.Width = 68;
            // 
            // gridColumn63
            // 
            this.gridColumn63.Caption = "Takip T.";
            this.gridColumn63.FieldName = "TAKIP_TARIHI";
            this.gridColumn63.Name = "gridColumn63";
            this.gridColumn63.OptionsColumn.ReadOnly = true;
            this.gridColumn63.Visible = true;
            this.gridColumn63.VisibleIndex = 5;
            this.gridColumn63.Width = 89;
            // 
            // repositoryItemImageComboBox10
            // 
            this.repositoryItemImageComboBox10.AutoHeight = false;
            this.repositoryItemImageComboBox10.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox10.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox10.Name = "repositoryItemImageComboBox10";
            // 
            // repositoryItemLookUpEdit25
            // 
            this.repositoryItemLookUpEdit25.AutoHeight = false;
            this.repositoryItemLookUpEdit25.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit25.Name = "repositoryItemLookUpEdit25";
            // 
            // repositoryItemLookUpEdit26
            // 
            this.repositoryItemLookUpEdit26.AutoHeight = false;
            this.repositoryItemLookUpEdit26.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit26.Name = "repositoryItemLookUpEdit26";
            // 
            // repositoryItemLookUpEdit27
            // 
            this.repositoryItemLookUpEdit27.AutoHeight = false;
            this.repositoryItemLookUpEdit27.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit27.Name = "repositoryItemLookUpEdit27";
            // 
            // gridView11
            // 
            this.gridView11.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn64,
            this.gridColumn65,
            this.gridColumn66,
            this.gridColumn67,
            this.gridColumn68,
            this.gridColumn69,
            this.gridColumn70});
            this.gridView11.GroupCount = 1;
            this.gridView11.IndicatorWidth = 20;
            this.gridView11.Name = "gridView11";
            this.gridView11.OptionsView.ShowAutoFilterRow = true;
            this.gridView11.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn64, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn64
            // 
            this.gridColumn64.Caption = "Tipi";
            this.gridColumn64.ColumnEdit = this.repositoryItemImageComboBox10;
            this.gridColumn64.FieldName = "TIPI";
            this.gridColumn64.Name = "gridColumn64";
            this.gridColumn64.OptionsColumn.ReadOnly = true;
            this.gridColumn64.Visible = true;
            this.gridColumn64.VisibleIndex = 0;
            this.gridColumn64.Width = 87;
            // 
            // gridColumn65
            // 
            this.gridColumn65.Caption = "Raf No";
            this.gridColumn65.FieldName = "FOY_NO";
            this.gridColumn65.Name = "gridColumn65";
            this.gridColumn65.OptionsColumn.ReadOnly = true;
            this.gridColumn65.Visible = true;
            this.gridColumn65.VisibleIndex = 0;
            this.gridColumn65.Width = 62;
            // 
            // gridColumn66
            // 
            this.gridColumn66.Caption = "Esas No";
            this.gridColumn66.FieldName = "ESAS_NO";
            this.gridColumn66.Name = "gridColumn66";
            this.gridColumn66.OptionsColumn.ReadOnly = true;
            this.gridColumn66.Visible = true;
            this.gridColumn66.VisibleIndex = 1;
            this.gridColumn66.Width = 61;
            // 
            // gridColumn67
            // 
            this.gridColumn67.Caption = "Adliye";
            this.gridColumn67.ColumnEdit = this.repositoryItemLookUpEdit25;
            this.gridColumn67.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn67.Name = "gridColumn67";
            this.gridColumn67.OptionsColumn.ReadOnly = true;
            this.gridColumn67.Visible = true;
            this.gridColumn67.VisibleIndex = 2;
            this.gridColumn67.Width = 63;
            // 
            // gridColumn68
            // 
            this.gridColumn68.Caption = "No";
            this.gridColumn68.ColumnEdit = this.repositoryItemLookUpEdit26;
            this.gridColumn68.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn68.Name = "gridColumn68";
            this.gridColumn68.OptionsColumn.ReadOnly = true;
            this.gridColumn68.Visible = true;
            this.gridColumn68.VisibleIndex = 3;
            this.gridColumn68.Width = 40;
            // 
            // gridColumn69
            // 
            this.gridColumn69.Caption = "G�rev";
            this.gridColumn69.ColumnEdit = this.repositoryItemLookUpEdit27;
            this.gridColumn69.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn69.Name = "gridColumn69";
            this.gridColumn69.OptionsColumn.ReadOnly = true;
            this.gridColumn69.Visible = true;
            this.gridColumn69.VisibleIndex = 4;
            this.gridColumn69.Width = 68;
            // 
            // gridColumn70
            // 
            this.gridColumn70.Caption = "Takip T.";
            this.gridColumn70.FieldName = "TAKIP_TARIHI";
            this.gridColumn70.Name = "gridColumn70";
            this.gridColumn70.OptionsColumn.ReadOnly = true;
            this.gridColumn70.Visible = true;
            this.gridColumn70.VisibleIndex = 5;
            this.gridColumn70.Width = 89;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem6";
            this.layoutControlItem1.Size = new System.Drawing.Size(549, 332);
            this.layoutControlItem1.Text = "layoutControlItem6";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Bottom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(93, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // repositoryItemImageComboBox11
            // 
            this.repositoryItemImageComboBox11.AutoHeight = false;
            this.repositoryItemImageComboBox11.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox11.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Dava", "DAVA", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�cra", "�CRA", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Soru�turma", "SORU�TURMA", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("S�zle�me", "S�ZLE�ME", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Belge", "BELGE", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tebligat", "TEBL�GAT", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Klas�r", "KLAS�R", 6)});
            this.repositoryItemImageComboBox11.Name = "repositoryItemImageComboBox11";
            // 
            // repositoryItemLookUpEdit28
            // 
            this.repositoryItemLookUpEdit28.AutoHeight = false;
            this.repositoryItemLookUpEdit28.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit28.Name = "repositoryItemLookUpEdit28";
            // 
            // repositoryItemLookUpEdit29
            // 
            this.repositoryItemLookUpEdit29.AutoHeight = false;
            this.repositoryItemLookUpEdit29.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit29.Name = "repositoryItemLookUpEdit29";
            // 
            // repositoryItemLookUpEdit30
            // 
            this.repositoryItemLookUpEdit30.AutoHeight = false;
            this.repositoryItemLookUpEdit30.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit30.Name = "repositoryItemLookUpEdit30";
            // 
            // gridView12
            // 
            this.gridView12.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn71,
            this.gridColumn72,
            this.gridColumn73,
            this.gridColumn74,
            this.gridColumn75,
            this.gridColumn76,
            this.gridColumn77});
            this.gridView12.GroupCount = 1;
            this.gridView12.IndicatorWidth = 20;
            this.gridView12.Name = "gridView12";
            this.gridView12.OptionsView.ShowAutoFilterRow = true;
            this.gridView12.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn71, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn71
            // 
            this.gridColumn71.Caption = "Tipi";
            this.gridColumn71.ColumnEdit = this.repositoryItemImageComboBox11;
            this.gridColumn71.FieldName = "TIPI";
            this.gridColumn71.Name = "gridColumn71";
            this.gridColumn71.OptionsColumn.ReadOnly = true;
            this.gridColumn71.Visible = true;
            this.gridColumn71.VisibleIndex = 0;
            this.gridColumn71.Width = 87;
            // 
            // gridColumn72
            // 
            this.gridColumn72.Caption = "Raf No";
            this.gridColumn72.FieldName = "FOY_NO";
            this.gridColumn72.Name = "gridColumn72";
            this.gridColumn72.OptionsColumn.ReadOnly = true;
            this.gridColumn72.Visible = true;
            this.gridColumn72.VisibleIndex = 0;
            this.gridColumn72.Width = 62;
            // 
            // gridColumn73
            // 
            this.gridColumn73.Caption = "Esas No";
            this.gridColumn73.FieldName = "ESAS_NO";
            this.gridColumn73.Name = "gridColumn73";
            this.gridColumn73.OptionsColumn.ReadOnly = true;
            this.gridColumn73.Visible = true;
            this.gridColumn73.VisibleIndex = 1;
            this.gridColumn73.Width = 61;
            // 
            // gridColumn74
            // 
            this.gridColumn74.Caption = "Adliye";
            this.gridColumn74.ColumnEdit = this.repositoryItemLookUpEdit28;
            this.gridColumn74.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.gridColumn74.Name = "gridColumn74";
            this.gridColumn74.OptionsColumn.ReadOnly = true;
            this.gridColumn74.Visible = true;
            this.gridColumn74.VisibleIndex = 2;
            this.gridColumn74.Width = 63;
            // 
            // gridColumn75
            // 
            this.gridColumn75.Caption = "No";
            this.gridColumn75.ColumnEdit = this.repositoryItemLookUpEdit29;
            this.gridColumn75.FieldName = "ADLI_BIRIM_NO_ID";
            this.gridColumn75.Name = "gridColumn75";
            this.gridColumn75.OptionsColumn.ReadOnly = true;
            this.gridColumn75.Visible = true;
            this.gridColumn75.VisibleIndex = 3;
            this.gridColumn75.Width = 40;
            // 
            // gridColumn76
            // 
            this.gridColumn76.Caption = "G�rev";
            this.gridColumn76.ColumnEdit = this.repositoryItemLookUpEdit30;
            this.gridColumn76.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.gridColumn76.Name = "gridColumn76";
            this.gridColumn76.OptionsColumn.ReadOnly = true;
            this.gridColumn76.Visible = true;
            this.gridColumn76.VisibleIndex = 4;
            this.gridColumn76.Width = 68;
            // 
            // gridColumn77
            // 
            this.gridColumn77.Caption = "Takip T.";
            this.gridColumn77.FieldName = "TAKIP_TARIHI";
            this.gridColumn77.Name = "gridColumn77";
            this.gridColumn77.OptionsColumn.ReadOnly = true;
            this.gridColumn77.Visible = true;
            this.gridColumn77.VisibleIndex = 5;
            this.gridColumn77.Width = 89;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "*.avpis";
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // mdiAvukatPro
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(1103, 562);
            this.Controls.Add(this.c_pnlAlt);
            this.Controls.Add(this.c_tspnlMenuPanel);
            this.Controls.Add(this.c_pnlUst);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.c_mnUstMenu;
            this.MinimumSize = new System.Drawing.Size(800, 589);
            this.Name = "mdiAvukatPro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mdiAvukatPro_Load);
            this.MdiChildActivate += new System.EventHandler(this.mdiAvukatPro_MdiChildActivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mdiAvukatPro_KeyDown);
            this.c_mnUstMenu.ResumeLayout(false);
            this.c_mnUstMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlUst)).EndInit();
            this.c_pnlUst.ResumeLayout(false);
            this.c_comenUstKoseMenu.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_pnlAlt)).EndInit();
            this.c_pnlAlt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtYapilacakIsler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dckPanelCagriMerkezi.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabHatlar)).EndInit();
            this.xtraTabHatlar.ResumeLayout(false);
            this.xtraTabHat1.ResumeLayout(false);
            this.grpBoxCagriBilgileriHat1.ResumeLayout(false);
            this.tbControlCagriBilgileriHat1.ResumeLayout(false);
            this.tbPageGiden.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGidenHat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGidenHat1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlueArananGidenHat1.Properties)).EndInit();
            this.tbPageGelen.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGelenHat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGelenHat1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlueArayanGelenHat1.Properties)).EndInit();
            this.tbPageGorusmeTutanagi.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tbPageEski.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.tbPageIcraHesapHat1.ResumeLayout(false);
            this.xtraTabHat2.ResumeLayout(false);
            this.grpBoxCagriBilgileriHat2.ResumeLayout(false);
            this.tbControlCagriBilgileriHat2.ResumeLayout(false);
            this.tbPageGidenHat2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGidenHat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGidenHat2)).EndInit();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlueArananGidenHat2.Properties)).EndInit();
            this.tbPageGelenHat2.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGelenHat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGelenHat2)).EndInit();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlueArayanGelenHat2.Properties)).EndInit();
            this.tbPageGorusmeTutanagiHat2.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.tbPageEskiGorusmelerHat2.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.tbPageIcraHesapHat2.ResumeLayout(false);
            this.xtraTabHat3.ResumeLayout(false);
            this.xtraTabHat4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueBirim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlueGorev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        public bool _EventlerKullanilacakMi;
        public ToolStripMenuItem c_titemTanimlarIsTanimlari;
        public ToolStripMenuItem c_titemTanimlarIsTanimlariYeniIsTanimlamaEkran;
        public ToolStripMenuItem c_titemEditorTanim;
        public ToolStripMenuItem c_titemEditorDegiskenTanim;
        public ToolStripMenuItem c_titemRaporlar;
        public ToolStripMenuItem c_titemGorunumGuncelIslemler;
        public PanelControl c_pnlSag = new PanelControl();
        public PanelControl c_pnlSol = new PanelControl();
        public ToolStripMenuItem c_titemBenimAjandam;
        public ToolStripMenuItem c_titemSubemdekiAvukatlarinAjandasi;
        public ToolStripMenuItem c_titemDetayliAjanda;
        public ToolStripMenuItem c_titemDosyaDegisikIsler;
        public ToolStripMenuItem c_titemDosyaDegisikIslerIhtiyatiHaciz;
        public ToolStripMenuItem c_titemDosyaDegisikIslerIhtiyatiTedbir;
        public ToolStripMenuItem c_titemDosyaDegisikIslerTespitKaydet;
        public ToolStripMenuItem c_titemDosyaDegisikIslerDosyasiBul;
        public ToolStripMenuItem c_titemTanimlarIsTanimlariOtomatikIsTanimlamaEkran;
        public ContextMenuStrip contextMenuStrip1;
        public ToolStripMenuItem contextModuleEkle;
        public ContextMenuStrip cmYetkilendirme;
        public CheckEdit c_chkAyarlariSakla;
        public OpenFileDialog c_opfFormuKaydet;
        public ToolStripItemCollection _DockPaneller;
        public MenuStrip c_mnUstMenu;
        public ToolStripMenuItem c_titemDosya;
        public PanelControl c_pnlUst;
        public ContextMenuStrip c_comenUstKoseMenu;
        public ToolStripMenuItem toolStripMenuItem1;
        public ToolStripMenuItem toolStripMenuItem2;
        public ToolStripMenuItem toolStripMenuItem3;
        public ToolStripMenuItem c_titemDosyaIcra;
        public ToolStripMenuItem c_titemYardim;
        public ToolStripMenuItem c_titemYardimAltDosyasi;
        public ToolStripMenuItem c_titemYardimIcendekiler;
        public ToolStripMenuItem c_titemYardimAra;
        public ToolStripSeparator toolStripSeparator5;
        public ToolStripMenuItem c_titemYardimAvukatproYardim;
        public ToolStripMenuItem c_titemGorunum;
        public ToolStripMenuItem c_titemYardimciAlanlar;
        public ToolStripMenuItem c_titemStiller;
        public ToolStripMenuItem c_titemYardimCubugu;
        public ToolStripMenuItem c_titemFormHerZamanUstte;
        public ToolStripMenuItem c_titemYaziTipi;
        public ToolStripMenuItem c_titemSaydamlik;
        public ToolStripMenuItem c_titemSaydamlikYuzde10;
        public ToolStripMenuItem toolStripMenuItem7;
        public ToolStripMenuItem toolStripMenuItem8;
        public ToolStripMenuItem toolStripMenuItem9;
        public ToolStripMenuItem toolStripMenuItem11;
        public ToolStripMenuItem toolStripMenuItem10;
        public ToolStripMenuItem toolStripMenuItem12;
        public ToolStripMenuItem c_titemArkaPlan;
        public ToolStripMenuItem c_titemArkaPlanResim;
        public ToolStripMenuItem c_titemArkaPlanRenk;
        public OpenFileDialog c_opfArkaPlan;
        public ToolStripMenuItem c_titemDosyaIcraYeniIcraKayit;
        public ToolStripMenuItem c_titemDosyaIcraYeniStandartFormIle;
        public ToolStripMenuItem c_titemDosyaIcraYeniSihirbazIle;
        public ToolStripMenuItem c_titemDosyaIcraYeniEditorIle;
        public ToolStripMenuItem c_titemDosyaIcraDosyaBul;
        public ToolStripMenuItem c_titemDosyaDava;
        public ToolStripMenuItem c_titemDosyaDavaYeniDava;
        public ToolStripMenuItem c_titemDosyaDavaDosyaBul;
        public ToolStripMenuItem c_titemDosyaDavaEkleStandartFormIle;
        public ToolStripMenuItem c_titemDosyaDavaYeniSihirbazIle;
        public ToolStripMenuItem c_titemDosyaDavaYeniEditorIle;
        public ToolStripMenuItem c_titemDosyaSorusturma;
        public ToolStripMenuItem c_titemDosyaSorusturmaYeni;
        public ToolStripMenuItem c_titemDosyaSorusturmaYeniStandartFormIle;
        public ToolStripMenuItem c_titemDosyaSorusturmaYeniSihirbazFormIle;
        public ToolStripMenuItem c_titemDosyaSorusturmaYeniEditorIle;
        public ToolStripMenuItem c_titemDosyaDavaSorusturmaBul;
        public ToolStripMenuItem c_titemDosyaBelge;
        public ToolStripMenuItem c_titemDosyaBelgeYeniBelge;
        public ToolStripMenuItem c_titemDosyaBelgeBelgeBul;
        public ToolStripMenuItem c_titemDosyaEvrak;
        public ToolStripMenuItem c_titemDosyaEvrakYeniEkle;
        public ToolStripMenuItem c_titemDosyaEvrakBul;
        public ToolStripMenuItem c_titemDosyaGorusme;
        public ToolStripMenuItem c_titemDosyaGorusmeYeniGorusme;
        public ToolStripMenuItem c_titemDosyaGorusmeKayitBul;
        public ToolStripMenuItem c_titemDosyaSozlesme;
        public ToolStripMenuItem c_titemDosyaSozlesmeYenie;
        public ToolStripMenuItem c_titemDosyaSozlesmeYeniStandartFormIleEkle;
        public ToolStripMenuItem c_titemDosyaSozlesmeYeniSihirbazFormIleEkle;
        public ToolStripMenuItem c_titemDosyaSozlesmeYeniEditorIleEkle;
        public ToolStripMenuItem c_titemDosyaSozlesmeBul;
        public ToolStripMenuItem c_titemDosyaYapilcakIs;
        public ToolStripMenuItem c_titemDosyaYapilcakIsAra;
        public ToolStripMenuItem c_titemDosyaYapilcakIsEkle;
        public ToolStripMenuItem c_titemDosyaRucuveHasarBilgileri;
        public ToolStripMenuItem c_titemDosyaRucuHasarPoliceveHaqsarBilgileri;
        public ToolStripMenuItem c_titemDosyaRucuveHasarRucuBilgileri;
        public ToolStripMenuItem c_titemDosyaRucuveHasarRucuBilgileriYeniRucuEkle;
        public ToolStripMenuItem c_titemDosyaRucuveHasarRucuBilgileriRucuBul;
        public ToolStripMenuItem c_titemDosyaVekalet;
        public ToolStripMenuItem c_titemDosyaVekaletYeniVekalet;
        public ToolStripMenuItem c_titemDosyaVekaletBulVekalet;
        public ToolStripMenuItem c_titemDosyaKisi;
        public ToolStripMenuItem c_titemDosyaKisiYeniKisi;
        public ToolStripMenuItem c_titemDosyaKisiBulKisi;
        public ToolStripMenuItem c_titemDosyaAjanda;
        public ToolStripMenuItem c_titemDosyaHukukMuhasebesi;
        public ToolStripMenuItem c_titemDosyaProjeDosya;
        public ToolStripMenuItem c_titemDosyaProjeDosyaYeniProje;
        public ToolStripMenuItem c_titemDosyaProjeDosyaBulProje;
        public ToolStripMenuItem c_titemTanimlar;
        public ToolStripMenuItem c_titemTanimlarKodVeCetvelAna;
        public ToolStripMenuItem c_titemTanimlarKodVeCetvelAnaKodFormlar;
        public ToolStripMenuItem c_titemTanimlarAntetTanimlarAlt;
        public ToolStripMenuItem c_titemTanimlarHesapTanimlarAlt;
        public ToolStripMenuItem g�ncel��lemlerToolStripMenuItem;
        public ToolStripMenuItem saatToolStripMenuItem;
        public ToolStripMenuItem d�vizKurlar�ToolStripMenuItem;
        public ToolStripMenuItem notlarToolStripMenuItem;
        public ToolStripMenuItem resmiGazeteHaberleriToolStripMenuItem;
        public ToolStripMenuItem hukukHaberleriToolStripMenuItem;
        public ToolStripMenuItem yeniToolStripMenuItem;
        public ToolStripMenuItem c_titemSistemIslemleri;
        public ToolStripMenuItem c_titemSistemIslemleriSistemBakimi;
        public ToolStripMenuItem c_titemSistemIslemleriYedekAl;
        public ToolStripMenuItem c_titemSistemIslemleriServis;
        public ToolStripMenuItem c_titemYardimKullanimKlavuzu;
        public ToolStripMenuItem c_titemYardimPratikYardim;
        public ToolStripMenuItem c_titemYardimTeknikDestek;
        public ToolStripMenuItem c_titemYardimEgitimDestek;
        public ToolStripMenuItem c_titemYardimEnCokArananlar;
        public ToolStripMenuItem c_titemYardimLisanslama;
        public ToolStripMenuItem c_titemYardimMusteriGeriBesleme;
        public ToolStripMenuItem c_titemTebligatBarkodAraligiTanimlama;


        public ToolStripSeparator toolStripSeparator1;
        public ToolStripMenuItem c_titemDosyaCikis;
        public ToolStripPanel c_tspnlMenuPanel;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private ToolStripMenuItem c_titemPencere;
        private ToolStripMenuItem tabWindowToolStripMenuItem;
        private ToolStripMenuItem yatayYerlestirToolStripMenuItem;
        private ToolStripMenuItem dikeyYerlestirToolStripMenuItem;
        private ToolStripMenuItem basamaklaToolStripMenuItem;
        private ToolStripMenuItem muvekkilSozlesmeleriToolStripMenuItem;
        private ToolStripMenuItem davaSozlesmeleriToolStripMenuItem;
        private ToolStripMenuItem IcraSozlesmeleriToolStripMenuItem;
        private ToolStripMenuItem IsUcretlendirmeSozlesmeleriToolStripMenuItem;
        private ToolStripMenuItem c_titemDosyaProjeDosyaKlasorAra;
        private ToolStripMenuItem c_titemKimNerede;
        private ToolStripMenuItem kimNeredeToolStripMenuItem;
        private ToolStripMenuItem c_titemSistemIslemleriKullaniciSecenekleri;
        private ToolStripMenuItem c_titemSistemIslemleriParolaDegistirme;
        private ToolStripMenuItem c_titemStandartRaporlar;
        private ToolStripMenuItem ekran�zelle�tirmeToolStripMenuItem;
        private ToolStripMenuItem dataAktarToolStripMenuItem;
        public PanelControl c_pnlAlt;
        private Timer timer1;
        private TextEdit txtYapilacakIsler;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private ToolStripMenuItem �r�nAktivasyonuToolStripMenuItem;
        private ToolStripMenuItem yedekD�nToolStripMenuItem;
        private ToolStripMenuItem guncellemeAyarlariToolStripMenuItem;
        private ToolStripMenuItem guncellemeParametreleriToolStripMenuItem;
        private ToolStripMenuItem guncellemeServisiniBaslatToolStripMenuItem;
        private ToolStripMenuItem krediS�zle�mesiEkleToolStripMenuItem;
        private ToolStripMenuItem krediToolStripMenuItem;
        private ToolStripMenuItem krediKart�S�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem genelKrediS�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem finansmanS�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem hesapRehinS�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem bireyselBankac�l�kHizmetS�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem krediKart��ye��yeriProgram�S�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem krediKart��yelikS�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem krediliMenkulK�ymetS�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem genelKrediTaahh�tnamesiToolStripMenuItem;
        private ToolStripMenuItem bankac�l�kHizmetS�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem konutKredisiS�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem ihtiya�KredisiToolStripMenuItem;
        private ToolStripMenuItem ta��tKredisiToolStripMenuItem;
        private ToolStripMenuItem gayrimenkul�pote�iToolStripMenuItem;
        private ToolStripMenuItem gemi�pote�iToolStripMenuItem;
        private ToolStripMenuItem havaArac��pote�iToolStripMenuItem;
        private ToolStripMenuItem ara�RehniToolStripMenuItem;
        private ToolStripMenuItem ticari��letmeRehniToolStripMenuItem;
        private ToolStripMenuItem menkulMalRehniToolStripMenuItem;
        private ToolStripMenuItem menkulK�ymetRehniToolStripMenuItem;
        private ToolStripMenuItem mevduatRehniToolStripMenuItem;
        private ToolStripMenuItem ticariSenetRehniToolStripMenuItem;
        private ToolStripMenuItem hatRehniToolStripMenuItem;
        private ToolStripMenuItem markaRehniToolStripMenuItem;
        private ToolStripMenuItem ticariPlakaRehniToolStripMenuItem;
        private ToolStripMenuItem hisseSenediRehniToolStripMenuItem;
        private ToolStripMenuItem kanbiyoSenediRehniToolStripMenuItem;
        private ToolStripMenuItem genelS�zle�meToolStripMenuItem;
        private ToolStripMenuItem markaPatentS�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem hakemS�zle�mesiToolStripMenuItem;
        private ToolStripMenuItem ihtiyatiHacizToolStripMenuItem;
        private ToolStripMenuItem ihtiyatiTedbirToolStripMenuItem;
        private ToolStripMenuItem ekranGorunumleriToolStripMenuItem;
        private ToolStripMenuItem d�nemselRaporToolStripMenuItem;
        private ToolStripMenuItem ticariKredilerTakipliAlacaklar��inRaporToolStripMenuItem;
        private ToolStripMenuItem bireyselKredilerTakipliAlacaklar��inRaporToolStripMenuItem;
        private ToolStripMenuItem hariciSimulasyonHesabiToolStripMenuItem;
        private ToolStripMenuItem c_titemDosyaDavaDosyaGelismisBul;
        private ToolStripMenuItem asistan��al��t�rToolStripMenuItem;
        private ToolStripMenuItem kurGiri�iToolStripMenuItem;
        private ToolStripMenuItem icraH�zl�AramaToolStripMenuItem;
        private ToolStripMenuItem entegrasyonToolStripMenuItem;
        private ToolStripMenuItem genelBilgilerToolStripMenuItem;
        private ToolStripMenuItem masraflarToolStripMenuItem;
        private ToolStripMenuItem tahsilatlarToolStripMenuItem;
        private ToolStripMenuItem d�vizKurlar�ToolStripMenuItem1;
        private ToolStripMenuItem da��t�lmam��MasraflarToolStripMenuItem;
        private ToolStripMenuItem da��t�lmam��TahsilatlarToolStripMenuItem;
        private ToolStripMenuItem aktar�lanMasraflarToolStripMenuItem;
        private ToolStripMenuItem aktar�lanTahsilatlarToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem �cretlendirilmi���lerToolStripMenuItem;
        private ToolStripMenuItem duru�maSat��Ke�ifBilgilerimToolStripMenuItem;
        private ToolStripMenuItem araKararlar�mToolStripMenuItem;
        private ToolStripMenuItem toplant�lar�mToolStripMenuItem;
        private ToolStripMenuItem g�nl�k��lerimToolStripMenuItem;
        private ToolStripMenuItem notlar�mToolStripMenuItem;
        private ToolStripMenuItem duru�maKe�ifAraToolStripMenuItem;
        private ToolStripMenuItem c_titemHizliIslemler;
        private ToolStripMenuItem hemenBulToolStripMenuItem;
        private ToolStripMenuItem adEsasNoDosyaNoyaGoreBulToolStripMenuItem;
        private ToolStripMenuItem tapuBilgisindenBulToolStripMenuItem;
        private ToolStripMenuItem ara�BilgisindenBulToolStripMenuItem;
        private ToolStripMenuItem cekSenetBilgisindenBulToolStripMenuItem;
        private ToolStripMenuItem hemenEkleToolStripMenuItem;
        private ToolStripMenuItem �ah�sEkleToolStripMenuItem;
        private ToolStripMenuItem vekaletToolStripMenuItem;
        private ToolStripMenuItem belgeToolStripMenuItem;
        private ToolStripMenuItem evrakTebligatToolStripMenuItem;
        private ToolStripMenuItem masrafAvansToolStripMenuItem;
        private ToolStripMenuItem notToolStripMenuItem;
        private ToolStripMenuItem toplant�ToolStripMenuItem;
        private ToolStripMenuItem duru�maToolStripMenuItem;
        private ToolStripMenuItem araKararToolStripMenuItem;
        private ToolStripMenuItem ke�if�ncelemeToolStripMenuItem;
        private ToolStripMenuItem hacizToolStripMenuItem;
        private ToolStripMenuItem sat��ToolStripMenuItem;
        private ToolStripMenuItem bor�luOdemesiToolStripMenuItem;
        private ToolStripMenuItem daval��demesiToolStripMenuItem;
        private ToolStripMenuItem m�vekkile�demeToolStripMenuItem;
        private ToolStripMenuItem i�ToolStripMenuItem;
        private ToolStripMenuItem g�r��meToolStripMenuItem;
        private ToolStripMenuItem klas�rToolStripMenuItem;
        private ToolStripMenuItem s�kKullan�lanToolStripMenuItem;
        private ToolStripMenuItem teminatMektuplar�ToolStripMenuItem;
        private ToolStripMenuItem s�kKullan�lanlarToolStripMenuItem;
        private ToolStripMenuItem ekleToolStripMenuItem;
        private ToolStripMenuItem g�sterToolStripMenuItem;
        private ToolStripMenuItem c_titemYazismalar;
        private ToolStripMenuItem standartRaporlarToolStripMenuItem1;
        private ToolStripMenuItem gelismisRaporlarToolStripMenuItem;
        private ToolStripMenuItem icraToolStripMenuItem;
        private ToolStripMenuItem davaToolStripMenuItem;
        private ToolStripMenuItem �zelToolStripMenuItem;
        private ToolStripMenuItem m�vekkilHesaplar�ToolStripMenuItem;
        private ToolStripMenuItem envanterToolStripMenuItem1;
        private ToolStripMenuItem belgeEvrakS�zle�me�craDavaSoru�turmaToolStripMenuItem1;
        private ToolStripMenuItem muallakRaporToolStripMenuItem1;
        private ToolStripMenuItem standartYaz��malarToolStripMenuItem;
        private ToolStripMenuItem formlarEdit�rToolStripMenuItem;
        private ToolStripMenuItem topluYaz��maVeUYAPEdit�r�ToolStripMenuItem;
        private ToolStripMenuItem hacizToolStripMenuItem1;
        private ToolStripMenuItem sat��ToolStripMenuItem1;
        private ToolStripMenuItem bor�lu�demeToolStripMenuItem;
        private ToolStripMenuItem ilamBilgileriToolStripMenuItem;
        private ToolStripMenuItem taahh�tBilgileriToolStripMenuItem;
        private ToolStripMenuItem itirazBilgileriToolStripMenuItem;
        private ToolStripMenuItem tarafGeli�meleriToolStripMenuItem;
        private ToolStripMenuItem hasarBilgileriToolStripMenuItem1;
        private ToolStripMenuItem poli�eBilgileriToolStripMenuItem1;
        private ToolStripMenuItem araKararToolStripMenuItem1;
        private ToolStripMenuItem bo�lununT�mMallar�ToolStripMenuItem;
        private ToolStripMenuItem ihtiyatiHacizToolStripMenuItem1;
        private ToolStripMenuItem ihtiyatiTedbirToolStripMenuItem1;
        private ToolStripMenuItem duru�maKe�ifToolStripMenuItem;
        private ToolStripMenuItem duru�maSat��Ke�ifToolStripMenuItem;
        private ToolStripMenuItem bak�mAyarlar�ToolStripMenuItem;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dckPanelCagriMerkezi;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private PanelControl panelControl1;


        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;


        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn44;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn45;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn46;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn47;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn48;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn49;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn50;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn51;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn52;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn53;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn54;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn55;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn56;


        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueBirim;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueGorev;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit22;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit23;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit24;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn57;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn58;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn59;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn60;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn61;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn62;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn63;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit25;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit26;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit27;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn64;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn65;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn66;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn67;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn68;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn69;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn70;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit28;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit29;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit30;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn71;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn72;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn73;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn74;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn75;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn76;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn77;
        private ImageList �mageList1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn78;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn79;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn80;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn81;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn82;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn83;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn84;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn85;
        private Panel panel1;
        private DevExpress.XtraTab.XtraTabControl xtraTabHatlar;
        private DevExpress.XtraTab.XtraTabPage xtraTabHat1;
        private GroupBox grpBoxCagriBilgileriHat1;
        private TabControl tbControlCagriBilgileriHat1;
        private TabPage tbPageGiden;
        private Panel panel6;
        private DevExpress.XtraGrid.GridControl gridControlGidenHat1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGidenHat1;
        private Panel panel4;
        private Button btnGidenBulHat1;
        public TextBox txtBoxTcNoGidenHat1;
        public Button btnKonferansGidenHat1;
        public SearchLookUpEdit SlueArananGidenHat1;
        private Label label10;
        public Button btnYonlendirGidenHat1;
        private Label label9;
        public Button btnKapatGidenHat1;
        //private Button btnAraGidenHat1;
        public System.Windows.Forms.ComboBox cmbBoxTelNoGidenHat1;
        private Label label8;
        public TextBox txtBoxMusteriNoGidenHat1;
        private Label label7;
        private TabPage tbPageGelen;
        private Panel panel3;
        private DevExpress.XtraGrid.GridControl gridControlGelenHat1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGelenHat1;
        private Panel panel7;
        private Button btnGelenBulHat1;
        private TextBox txtBoxTcNoGelenHat1;
        private SearchLookUpEdit SlueArayanGelenHat1;
        private Label label1;
        private Button btnYeniAramaGelenHat1;
        private Label label2;
        private Button btnKapatGelenHat1;
        private Label label4;
        private Button btnKonferansGelenHat1;
        private TextBox txtBoxMusteriNoGelenHat1;
        private Button btnYonlendirGelenHat1;
        private Label label3;
        private Button btnGeriCevirGelenHat1;
        private TextBox txtBoxTelNoGelenHat1;
        private Button btnCevaplaGelenHat1;
        private TabPage tbPageGorusmeTutanagi;
        private Panel panel8;
        private UserControls.ucGorusmeKayit ucGorusmeKayitHat1;
        private Panel panel9;
        private Button btnGorusmeKaydetHat1;
        private TabPage tbPageEski;
        private Panel panel10;
        private UserControls.IcraTakipUserControls.ucGorusmeler ucGorusmelerHat1;
        private Panel panel12;
        private Button btnEskiGorusmeGetirHat1;
        private RadioButton rdBtnSahisEskiGorusmeHat1;
        private RadioButton rdBtnDosyaEskiGorusmeHat1;
        private TabPage tbPageIcraHesapHat1;
        private Panel panel18;
        private UserControls.ucIcraHesapCetveli ucIcraHesapCetveliHat1;
        private DevExpress.XtraTab.XtraTabPage xtraTabHat2;
        private DevExpress.XtraTab.XtraTabPage xtraTabHat3;
        private DevExpress.XtraTab.XtraTabPage xtraTabHat4;
        private Panel panel5;
        private Panel panel13;
        private Label lblHatBilgisi4;
        private Label lblHatBilgisi3;
        private Label lblHatBilgisi2;
        private Label lblHatBilgisi1;
        private Panel panel11;
        private Panel panel17;
        private Label label12;
        private PictureBox pictureBox4;
        private Panel panel16;
        private Label label11;
        private PictureBox pictureBox3;
        private Panel panel15;
        private Label label6;
        private PictureBox pictureBox2;
        private Panel panel14;
        private Label label5;
        private PictureBox pictureBox1;
        private DevExpress.XtraTab.XtraTabPage xtraTabSmsFaxMail;
        private TabControl tabControl2;
        private TabControl tabControl3;
        public RadioButton rdButtonHariciHat1;
        public RadioButton rdButtonDahiliHat1;
        private GroupBox grpBoxCagriBilgileriHat2;
        private TabControl tbControlCagriBilgileriHat2;
        private TabPage tbPageGidenHat2;
        private Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControlGidenHat2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGidenHat2;
        private Panel panel19;
        public RadioButton rdButtonHariciHat2;
        public RadioButton rdButtonDahiliHat2;
        private Button btnGidenBulHat2;
        public TextBox txtBoxTcNoGidenHat2;
        public Button btnKonferansGidenHat2;
        public SearchLookUpEdit SlueArananGidenHat2;
        private Label label13;
        public Button btnYonlendirGidenHat2;
        private Label label14;
        public Button btnKapatGidenHat2;
        private Button btnAraGidenHat2;
        public System.Windows.Forms.ComboBox cmbBoxTelNoGidenHat2;
        private Label label15;
        public TextBox txtBoxMusteriNoGidenHat2;
        private Label label16;
        private TabPage tbPageGelenHat2;
        private Panel panel20;
        private DevExpress.XtraGrid.GridControl gridControlGelenHat2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGelenHat2;
        private Panel panel21;
        private Button btnGelenBulHat2;
        private TextBox txtBoxTcNoGelenHat2;
        private SearchLookUpEdit SlueArayanGelenHat2;
        private Label label17;
        private Button btnYeniAramaGelenHat2;
        private Label label18;
        private Button btnKapatGelenHat2;
        private Label label19;
        private Button btnKonferansGelenHat2;
        private TextBox txtBoxMusteriNoGelenHat2;
        private Button btnYonlendirGelenHat2;
        private Label label20;
        private Button btnGeriCevirGelenHat2;
        private TextBox txtBoxTelNoGelenHat2;
        private Button btnCevaplaGelenHat2;
        private TabPage tbPageGorusmeTutanagiHat2;
        private Panel panel22;
        private UserControls.ucGorusmeKayit ucGorusmeKayitHat2;
        private Panel panel23;
        private Button btnGorusmeKaydetHat2;
        private TabPage tbPageEskiGorusmelerHat2;
        private Panel panel24;
        private UserControls.IcraTakipUserControls.ucGorusmeler ucGorusmelerHat2;
        private Panel panel25;
        private Button btnEskiGorusmeGetirHat2;
        private RadioButton rdBtnSahisEskiGorusmeHat2;
        private RadioButton rdBtnDosyaEskiGorusmeHat2;
        private TabPage tbPageIcraHesapHat2;
        private Panel panel26;
        private UserControls.ucIcraHesapCetveli ucIcraHesapCetveliHat2;
        private Button btnAraGidenHat1;
        private Button btnYeniAramaGidenHat1;
        private Button btnYeniAramaGidenHat2;
        private ToolStripMenuItem kullan�c�De�i�tirToolStripMenuItem;
        private ToolStripMenuItem �irketDe�i�tirToolStripMenuItem;
        private ToolStripMenuItem �a�r�MerkeziToolStripMenuItem;
        private ToolStripMenuItem karara��kanDosyalarToolStripMenuItem;
        private ToolStripMenuItem temyizEdilenDosyalarToolStripMenuItem;
        private ToolStripMenuItem anaEkranToolStripMenuItem;
        private ToolStripMenuItem m�kerrer�ah�slar�Birle�tirToolStripMenuItem;
        private ToolStripMenuItem ticariRiskRaporuEntegreliToolStripMenuItem;
        private ToolStripMenuItem ticariRiskRaporuDosyadanToolStripMenuItem;
        private System.IO.FileSystemWatcher fileSystemWatcher1;





    }
}

