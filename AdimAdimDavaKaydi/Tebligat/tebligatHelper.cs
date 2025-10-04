using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Tebligat
{
    internal class tebligatHelper
    {
        #region <TIO - 20090606> Haciz Ihbarname 89/1 leri aldık 89/2 yaptık

        /*
         * tebligatlarda 89/1 kaıtları aldık
         * Muhattap collectionları üzerinde Tebligatın kesinleşme tarihi bugün ve bugünden küçük olanları seçtik
         * daha önce 89/2 kayıt yapılıp yapılmadığını Muhatap Cari  ve Alt Cari den kontrol ettik
         * bu kayıtlardan 89/2 haciz ihbarnameli yeni birer tebligat kaydı oluşturuldu
         */

        /// <summary>
        /// 89/1 Ilk Haciz İhbarnamesini aldığım List
        /// </summary>
        private TList<AV001_TDI_BIL_TEBLIGAT> tebligatKonuIlkIhbarname = new TList<AV001_TDI_BIL_TEBLIGAT>();

        #endregion <TIO - 20090606> Haciz Ihbarname 89/1 leri aldık 89/2 yaptık

        #region <TIO - 20090606> Haciz Ihbarname 89/2 leri aldık 89/3 yaptık

        /*
         * tebligatlarda 89/2 kaıtları aldık
         * Muhattap collectionları üzerinde Tebligatın kesinleşme tarihi bugün ve bugünden küçük olanları seçtik
         * daha önce 89/3 kayıt yapılıp yapılmadığını Muhatap Cari  ve Alt Cari den kontrol ettik
         * bu kayıtlardan 89/3 haciz ihbarnameli yeni birer tebligat kaydı oluşturuldu
         */

        /// <summary>
        /// 89/1 Ilk Haciz İhbarnamesini aldığım List
        /// </summary>
        private TList<AV001_TDI_BIL_TEBLIGAT> tebligatKonuIkinciIhbarname = new TList<AV001_TDI_BIL_TEBLIGAT>();

        #endregion <TIO - 20090606> Haciz Ihbarname 89/2 leri aldık 89/3 yaptık

        #region <TIO - 20090606 > Banka Cari Alt kayıt ve  Haciz İhbarneme 89/1 Kayıt

        /*
         * Seçilen Banka Şubelerini Bankalarıyla aldık
         * Bankalardan Cari kaydı yaptık şubelerinden CARİ Alt kaydı yaptık
         * Bunlarla ( Muhatapları ve Yapanları ) yeni tebligatlar oluşturduk
         * oluşturduğumuz tebligatlar 89/1 Haciz ihbarnamesi .
         */

        private List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> kontrolCari = new List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI>();

        #endregion <TIO - 20090606 > Banka Cari Alt kayıt ve  Haciz İhbarneme 89/1 Kayıt

        #region <TIO - 20091606 CARİ dolu ALT CARİ boş ise CARİ den ALT CARİ oluşturma >

        private AV001_TDI_BIL_CARI carim = new AV001_TDI_BIL_CARI();

        #endregion <TIO - 20091606 CARİ dolu ALT CARİ boş ise CARİ den ALT CARİ oluşturma >
    }
}