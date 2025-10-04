using AdimAdimDavaKaydi.Editor.General;
using AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Editor.Forms
{
    public partial class frmDosyaAc : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmDosyaAc()
        {
            InitializeComponent();
        }

        public void Open(AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge.IRecordable parent)
        {
            ucDosyaAc1.Open(parent);

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.Show();
        }

        private void frmDosyaAc_Load(object sender, EventArgs e)
        {
            ucDosyaAc1.Filter = EditorUtil.filters.ToArray();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.ucDosyaAc1.SelectedrecordInfo = new RecordInfos();

            string[] uzantiIcinParcalar = openFileDialog1.FileName.Split('.');
            string uzanti = uzantiIcinParcalar[uzantiIcinParcalar.Length - 1];
            this.ucDosyaAc1.MyParent.SelectedStreamType =
                DosyaIslemleri.GetStreamType((FileTypes)Enum.Parse(typeof(FileTypes), uzanti.ToLower()));

            this.ucDosyaAc1.SelectedrecordInfo.SelectedFrom = LoadFromType.FromFolder;
            this.ucDosyaAc1.SelectedrecordInfo.Name = openFileDialog1.FileName;

            this.ucDosyaAc1.MyParent.OpenRecord(this.ucDosyaAc1.SelectedrecordInfo);
            this.Close();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            EditorUtil.filters.Clear();
            EditorUtil.filters.AddRange(this.ucDosyaAc1.Filter);
            this.Close();
            ucDosyaAc1.OpenSelected();
        }
    }
}