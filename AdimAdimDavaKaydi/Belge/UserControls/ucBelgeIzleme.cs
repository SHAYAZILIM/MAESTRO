using AvukatPro.Model.EntityClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Belge.UserControls
{
    public partial class ucBelgeIzleme : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucBelgeIzleme()
        {
            InitializeComponent();
        }

        private List<int> _BelgeIds;

        public List<int> BelgeIds
        {
            get
            {
                return _BelgeIds;
            }
            set
            {
                _BelgeIds = value;

                if (value != null)
                {
                    simpleButton1.Enabled = false;
                    simpleButton2.Enabled = _BelgeIds.Count > 0;
                    BelgeIndex = 0;
                    belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds.First()), 0);
                }
            }
        }

        private int BelgeIndex { get; set; }

        private void belgeyiOnlizle(Av001TdieBilBelgeEntity belge, int index)
        {
            if (belge != null && belge.Id != 0)
            {
                string file = belge.DosyaAdi;
                string[] exts = file.Split('.');

                if (exts.Length <= 0)
                {
                    return;
                }

                string ext = exts[exts.Length - 1].ToLower(new System.Globalization.CultureInfo("en-US"));
                byte[] data = belge.Icerik;

                if (file == string.Empty && data == null)
                {
                    return;
                }

                if (data == null)
                {
                    if (File.Exists(file))
                    {
                        FileStream fss = new FileStream(file, FileMode.Open);

                        byte[] veri = new byte[fss.Length];
                        fss.Read(veri, 0, veri.Length);
                        belge.Icerik = veri;
                        data = belge.Icerik;
                        fss.Close();
                    }
                }
                ucBelgeOnizleme1.ViewFile(data, belge.Id, belge.KontrolVersiyon, ext);

                BelgeIndex = index;
            }
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            Av001TdieBilBelgeEntity belge = AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex]);
            if (belge != null && belge.Icerik != null)
            {
                string bad = System.IO.Path.GetTempPath() + Guid.NewGuid() + "." + belge.DokumanUzanti;
                FileStream fs = new FileStream(bad, FileMode.Create);
                fs.Write(belge.Icerik.ToArray(), 0, belge.Icerik.Length);
                fs.Close();
                fs.Dispose();
                Tools.OpenProgram(bad);
            }
            else
            {
                MessageBox.Show("Belge İçeriği Bulunamadı", "Dikkat", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void dnBelge_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //if (e.Button.Tag == "first")
            //{
            //    belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds.First()), 0);
            //}

            //else if (e.Button.Tag == "last")
            //{
            //    belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds.Last()), BelgeIds.Count - 1);
            //}

            //else if (e.Button.Tag == "next")
            //{
            //    BelgeIndex++;
            //    belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex ]), BelgeIndex );
            //}

            //else if (e.Button.Tag == "prev")
            //{
            //    BelgeIndex--;
            //    belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex]), BelgeIndex);
            //}
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (BelgeIndex > 0)
            {
                simpleButton2.Enabled = true;
                BelgeIndex--;
                belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex]), BelgeIndex);
            }
            else
            {
                simpleButton1.Enabled = false;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (BelgeIndex < (BelgeIds.Count - 1))
            {
                simpleButton1.Enabled = true;
                BelgeIndex++;
                belgeyiOnlizle(AvukatPro.Services.Implementations.DosyaService.GetBelgeById(BelgeIds[BelgeIndex]), BelgeIndex);
            }
            else
            {
                simpleButton2.Enabled = false;
            }
        }
    }
}