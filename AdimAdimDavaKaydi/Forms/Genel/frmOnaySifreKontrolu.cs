using AvukatProLib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class frmOnaySifreKontrolu : Form
    {
        public frmOnaySifreKontrolu(int SifreTuru)
        {
            InitializeComponent();
            this.SifreTuru = SifreTuru;
        }

        public bool Onaylandi;
        private bool isMove = false;
        private int SifreTuru;
        private int tempX = 0, tempY = 0;

        private void btnDevam_Click(object sender, EventArgs e)
        {
            List<CompInfo> cmpNfoList = CompInfo.CmpNfoList;
            CompInfo cmpNfo = cmpNfoList[0];
            if (SifreTuru == 1)
            {
                if (txtSifre.Text == cmpNfo.OnaySifresi1)
                    Onaylandi = true;
            }
            else if (SifreTuru == 2)
            {
                if (txtSifre.Text == cmpNfo.OnaySifresi2)
                    Onaylandi = true;
            }
            else if (SifreTuru == 3)
            {
                if (txtSifre.Text == cmpNfo.OnaySifresi3)
                    Onaylandi = true;
            }
            else if (SifreTuru == 4)
            {
                if (txtSifre.Text == cmpNfo.DegistirmeSilmeSifresi)
                    Onaylandi = true;
            }

            if (Onaylandi)
                this.Close();
            else
                MessageBox.Show("Şifre hatalı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Down(object sender, MouseEventArgs e)
        {
            tempX = e.X;
            tempY = e.Y;
            isMove = true;
        }

        private void frmOnaySifreKontrolu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnVazgec_Click(sender, null);
            else if (e.KeyCode == Keys.Enter)
                btnDevam_Click(sender, null);
        }

        //aykut şifre kontrol
        private void frmOnaySifreKontrolu_Load(object sender, EventArgs e)
        {
            if (SifreTuru == 4)
            {
                this.Text = "Değiştirme Şifresini Girin";
                groupControl1.Text = "Değiştirme Şifresini Girin";
                labelControl1.Text = "Değiştirme Şifresi :";
                Onaylandi = false;
            }
            else
            {
                this.Text = SifreTuru + ". Onay Şifresini Girin";
                groupControl1.Text = SifreTuru + ". Onay Şifresini Girin";
                labelControl1.Text = SifreTuru + ". Onay Şifresi :";
                Onaylandi = false;
            }
        }

        private void Move(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                this.Left += e.X - tempX;
                this.Top += e.Y - tempY;
            }
        }

        private void Up(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
    }
}