using AdimAdimDavaKaydi.Util.BaseClasses.AvpFormData;

namespace AdimAdimDavaKaydi.Util.BaseClasses.AvpFormClass.AvpFormUtil
{
    #region Delagetes

    public delegate void OnDigerMenuItemClick(object sender, AvpFormChildOpenEventArgs e);

    //   public delegate void OnYenikayit(object sender, AvpFormEventArgs e);
    public delegate void OnYeniKayit(object sender, AvpFormDataEventArgs e);

    // public delegate void OnAc(object sender, AvpFormEventArgs e);
    public delegate void OnAc(object sender, AvpFormDataEventArgs e);

    //  public delegate void OnFarkliKayit(object sender, AvpFormEventArgs e);
    public delegate void OnFarkliKayit(object sender, AvpFormDataEventArgs e);

    // public delegate void OnKaydet(object sender, AvpFormEventArgs e);
    public delegate void OnKayit(object sender, AvpFormDataEventArgs e);

    // public delegate void OnYeni(object sender, AvpFormEventArgs e);
    public delegate void OnYeniAc(object sender, AvpFormDataEventArgs e);

    // public delegate void OnSil(object sender, AvpFormEventArgs e);
    public delegate void OnSil(object sender, AvpFormDataEventArgs e);

    // public delegate void OnKes(object sender, AvpFormEventArgs e);
    public delegate void OnKes(object sender, AvpFormDataEventArgs e);

    //  public delegate void OnKopyala(object sender, AvpFormEventArgs e);
    public delegate void OnKopyala(object sender, AvpFormDataEventArgs e);

    // public delegate void OnYapistir(object sender, AvpFormEventArgs e);
    public delegate void OnYapistir(object sender, AvpFormDataEventArgs e);

    //   public delegate void OnGeriAl(object sender, AvpFormEventArgs e);
    public delegate void OnGeriAl(object sender, AvpFormAvpDataSourceEventArgs e);

    //  public delegate void OnYeniden(object sender, AvpFormEventArgs e);
    public delegate void OnYenidenAl(object sende, AvpFormAvpDataSourceEventArgs e);

    // public delegate void OnYazdir(object sender, AvpFormEventArgs e);
    public delegate void OnYazdir(object sender, AvpFormAvpDataSourceEventArgs e);

    //  public delegate void OnTarihce(object sender, AvpFormEventArgs e);
    public delegate void OnTarihce(object sender, AvpFormDataEventArgs e);

    public delegate void OnGizle(object sender, AvpFormDataEventArgs e);

    // public delegate void OnGizlendi(object sende, IEntity gizlendi, AvpFormEventArgs e);

    public delegate void OnHesapla(object sender, AvpFormDataEventArgs e);

    //public delegate void OnHesaplandi(object sender, IEntity hesaplandi, AvpFormEventArgs e);

    public delegate void OnDeepLoad(object sender, AvpFormDataEventArgs e);

    // public delegate void OnDeepLoaded(object sender, IEntity deepLoaded, AvpFormEventArgs e);

    public delegate void OnSikKullanilanlarEkle(object sender, AvpFormDataEventArgs e);

    // public delegate void OnSikKullanilanlaraEklendi(object sender, IEntity sikKullanilanlaraEklendi, AvpFormEventArgs e);

    public delegate void OnVerilerYuklenecek(object sender, AvpFormAvpDataSourceEventArgs e);

    //public delegate void OnVerilerYuklendi(object sender, AvpFormAvpDataSourceEventArgs e);

    public delegate void OnVeriEkleme(object sender, AvpFormDataEventArgs e);

    //  public delegate void OnVerilerEklendi(object sender, AvpFormDataEventArgs e);

    public delegate void OnSeciliKayitlarDegistirme(object sender, AvpFormDataEventArgs e);

    // public delegate void OnSeciliKayitlarDegisti(object sender, AvpFormDataEventArgs e);

    public delegate void OnCikis(object sender, AvpFormAvpDataSourceEventArgs e);

    public delegate void OnCommandButtonClick(object sender, AvpFormAvpDataSourceEventArgs e);

    public delegate void OnSakla(object sender, AvpFormAvpDataSourceEventArgs e, bool checkState);

    public delegate void OnGonder(object sender, AvpFormExportEventArgs e);

    public delegate void OnYenile(object sender, AvpFormAvpDataSourceEventArgs e);

    public delegate void OnAddData(object sender, AvpFormAddNewEventArgs e);

    public delegate void OnAjandayaGonder(object sender, AvpFormChildRecordFormOpenEventArgs e);

    public delegate void OnTakipYazismalari(object sender, AvpFormChildRecordFormOpenEventArgs e);

    public delegate void OnIliskiliDosyalar(object sender, AvpFormChildRecordFormOpenEventArgs e);

    #endregion
}