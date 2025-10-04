using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ImportExportWithSelection
{
    public partial class ucIletisimBilgileri : DevExpress.XtraEditors.XtraUserControl
    {
        public ucIletisimBilgileri()
        {
            InitializeComponent();
            this.Load += ucIletisimBilgileri_Load;
        }

        //TODO: <TIO - 20090610>
        private List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM> seciliIletisimKayitlari;

        [Browsable(false)]
        public List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM> MyDataSource
        {
            get
            {
                if (this.gridControlIletisim_Meslek.DataSource is List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM>)
                {
                    return (List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM>)this.gridControlIletisim_Meslek.DataSource;
                }
                return null;
            }
            set { this.gridControlIletisim_Meslek.DataSource = value; }
        }

        /// <summary>
        /// Form üzerinden UserControls te seçilen kayýtlarý almamýzý saðlýyor./ THSN
        /// </summary>
        /// <param name="tebligats">Formda " ucUSERCONTROLADI.MyDataSource "  property sini veriseniz olur yada List </param>
        /// <returns></returns>
        public List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM> GetSelectedIletisims(List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM> iletisims)
        {
            seciliIletisimKayitlari = new List<AvukatProLib.Arama.per_TDI_BIL_ILETISIM>();
            foreach (AvukatProLib.Arama.per_TDI_BIL_ILETISIM f in iletisims)
            {
                if (f.IsSelected)
                    seciliIletisimKayitlari.Add(f);
            }
            return seciliIletisimKayitlari;
        }

        private void ucIletisimBilgileri_Load(object sender, EventArgs e)
        {
            //LOAD
            if (this.DesignMode)
                return;
        }
    }
}