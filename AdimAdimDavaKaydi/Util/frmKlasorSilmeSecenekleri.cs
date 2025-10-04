using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib.Extras;

namespace AdimAdimDavaKaydi.Util
{
    public partial class frmKlasorSilmeSecenekleri : DevExpress.XtraEditors.XtraForm
    {
        public static frmKlasorSilmeSecenekleri main;
        public List<KlasorSecenekleri> secilenler;

        public frmKlasorSilmeSecenekleri()
        {
            InitializeComponent();
        }

        public static List<KlasorSecenekleri> SecenekleriGoster()
        {
            main = new frmKlasorSilmeSecenekleri();
            main.ShowDialog();
            return main.secilenler;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Klasörle beraber klasöre bağlı seçilen veriler silinecektir. Onaylıyor musunuz?", "Klasör Silme Onayı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                secilenler = new List<KlasorSecenekleri>();

                if (radioGroup1.SelectedIndex == 1)
                {
                    secilenler.AddRange(Enum.GetValues(typeof(KlasorSecenekleri)).Cast<KlasorSecenekleri>());
                }
                else if (radioGroup1.SelectedIndex == 0)
                {
                    if (chkAlacaklar.Checked)
                        secilenler.Add(KlasorSecenekleri.Alacak);
                    if (chkAlacakSenetleri.Checked)
                        secilenler.Add(KlasorSecenekleri.AlacakSenedi);
                    if (chkDavalar.Checked)
                        secilenler.Add(KlasorSecenekleri.Dava);
                    if (chkIcralar.Checked)
                        secilenler.Add(KlasorSecenekleri.Icra);
                    if (chkIhtarnameler.Checked)
                        secilenler.Add(KlasorSecenekleri.Ihtarname);
                    if (chkIhtiyatiHacizler.Checked)
                        secilenler.Add(KlasorSecenekleri.IhtiyatiHaciz);
                    if (chkIhtiyatiTedbirler.Checked)
                        secilenler.Add(KlasorSecenekleri.IhtiyatiTedbir);
                    if (chkIlamlar.Checked)
                        secilenler.Add(KlasorSecenekleri.Ilam);
                    if (chkMallarHaklar.Checked)
                        secilenler.Add(KlasorSecenekleri.Mal);
                    if (chkMasraflar.Checked)
                        secilenler.Add(KlasorSecenekleri.Masraf);
                    if (chkOdemeler.Checked)
                        secilenler.Add(KlasorSecenekleri.Odeme);
                    if (chkSorusturmalar.Checked)
                        secilenler.Add(KlasorSecenekleri.Sorusturma);
                    if (chkSozlesmeler.Checked)
                        secilenler.Add(KlasorSecenekleri.Sozlesme);
                    if (chkTakipler.Checked)
                        secilenler.Add(KlasorSecenekleri.Takipler);
                    if (chkTeminatlar.Checked)
                        secilenler.Add(KlasorSecenekleri.Teminat);
                    if (chkBelgeler.Checked)
                        secilenler.Add(KlasorSecenekleri.Belge);

                    if (chkIsler.Checked)
                        secilenler.Add(KlasorSecenekleri.Is);

                    if (chkTaahhutler.Checked)
                        secilenler.Add(KlasorSecenekleri.Taahhut);

                    if (chkTebligatlar.Checked)
                        secilenler.Add(KlasorSecenekleri.Tebligatlar);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void frmKlasorSilmeSecenekleri_Load(object sender, EventArgs e)
        {
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}