using AdimAdimDavaKaydi.Util.BaseClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmCariMerge : AvpXtraForm
    {
        public frmCariMerge()
        {
            InitializeComponent();
            this.MdiParent = null;
            //SourceCari = AvukatPro.Services.Implementations.BaseService._db.Av001TdiBilCari.Where(q => q.Id == cari.ID).FirstOrDefault();
        }

        private AvukatPro.Model.EntityClasses.Av001TdiBilCariEntity SourceCari { get; set; }

        private AvukatPro.Model.EntityClasses.Av001TdiBilCariEntity TargetCari { get; set; }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            panelControl1.Enabled = true;

            var id1 = ((int?)lueTarafAdi1.EditValue).Value;
            SourceCari = AvukatPro.Services.Implementations.BaseService._db.Av001TdiBilCari.Where(q => q.Id == id1).FirstOrDefault();

            var id = ((int?)lueTarafAdi2.EditValue).Value;
            TargetCari = AvukatPro.Services.Implementations.BaseService._db.Av001TdiBilCari.Where(q => q.Id == id).FirstOrDefault();

            var properties = SourceCari.GetType().GetProperties().Where(q => q.PropertyType.GetInterfaces().Any(w => w == typeof(IEntityCollection)));

            //Transaction trans = new Transaction(IsolationLevel.ReadCommitted, "CariTrans");
            //AvukatPro.Services.Implementations.BaseService._db.TransactionToUse = trans;

            bool hasError = false;

            var total = properties.Count();
            var cur = 0;
            foreach (var item in properties)
            {
                cur++;
                try
                {
                    if (cur == 102)
                        Convert.ToInt32("55");

                    var source = (item.GetValue(SourceCari, null) as IEntityCollection);

                    lblProcessInfo.Text = string.Format("İşlem:{0}/{1}, Adı:{3}, Kaynak:{2}", cur, total, source.Count, item.Name);
                    if (source.Count > 0)
                    {
                        if (item.Name == "Av001TdiBilSozlesmeTarafs")
                        {
                            foreach (IEntity entity in source.Cast<IEntity>().ToList())
                            {
                                var ent = (entity as AvukatPro.Model.EntityClasses.Av001TdiBilSozlesmeTarafEntity);

                                try
                                {
                                    ent.Av001TdiBilCari = TargetCari;
                                    ent.CariAdi = TargetCari.Ad;
                                    ent.CariId = TargetCari.Id;
                                    ent.Save();
                                }
                                catch
                                {
                                    ent.Delete();
                                }
                            }
                        }
                        else if (item.Name == "AktDagitilmamisMasrafAvans")
                        {
                            foreach (IEntity entity in source.Cast<IEntity>().ToList())
                            {
                                var ent = (entity as AvukatPro.Model.EntityClasses.AktDagitilmamisMasrafAvanEntity);

                                try
                                {
                                    ent.Av001TdiBilCari = TargetCari;
                                    ent.KrediBorclusuCariId = TargetCari.Id;
                                    ent.Save();
                                }
                                catch
                                {
                                    ent.Delete();
                                }
                            }
                        }
                        else if (item.Name == "Av001TdieBilProjeKrediBorclusus")
                        {
                            foreach (IEntity entity in source.Cast<IEntity>().ToList())
                            {
                                var ent = (entity as AvukatPro.Model.EntityClasses.Av001TdieBilProjeKrediBorclusuEntity);

                                try
                                {
                                    ent.Av001TdiBilCari = TargetCari;
                                    ent.KrediBorclusuCariId = TargetCari.Id;
                                    ent.Save();
                                }
                                catch
                                {
                                    ent.Delete();
                                }
                            }
                        }
                        else if (item.Name == "Av001TdieBilProjeSorumlus")
                        {
                            foreach (IEntity entity in source.Cast<IEntity>().ToList())
                            {
                                var ent = (entity as AvukatPro.Model.EntityClasses.Av001TdieBilProjeSorumluEntity);
                                ent.Av001TdiBilCari = TargetCari;
                                ent.CariId = TargetCari.Id;
                                ent.Save();
                            }
                        }
                        else if (item.Name == "Av001TdieBilProjeTarafs")
                        {
                            foreach (IEntity entity in source.Cast<IEntity>().ToList())
                            {
                                var ent = (entity as AvukatPro.Model.EntityClasses.Av001TdieBilProjeTarafEntity);
                                try
                                {
                                    ent.Av001TdiBilCari = TargetCari;
                                    ent.CariId = TargetCari.Id;
                                    ent.Save();
                                }
                                catch
                                {
                                    ent.Delete();
                                }
                            }
                        }
                        else if (item.Name == "Av001TdiBilTebligatMuhataps")
                        {
                            foreach (IEntity entity in source.Cast<IEntity>().ToList())
                            {
                                var ent = (entity as AvukatPro.Model.EntityClasses.Av001TdiBilTebligatMuhatapEntity);
                                try
                                {
                                    if (ent.AlanCariId == SourceCari.Id)
                                    {
                                        ent.Av001TdiBilCari = TargetCari;
                                        ent.AlanCariId = TargetCari.Id;
                                        ent.Save();
                                    }
                                    else if (ent.MuhatapCariId == SourceCari.Id)
                                    {
                                        ent.Av001TdiBilCari_ = TargetCari;
                                        ent.MuhatapCariId = TargetCari.Id;
                                        ent.Save();
                                    }
                                }
                                catch
                                {
                                    ent.Delete();
                                }
                            }
                        }
                        else if (item.Name == "Av001TdiBilTebligatMuhataps_")
                        {
                            foreach (IEntity entity in source.Cast<IEntity>().ToList())
                            {
                                var ent = (entity as AvukatPro.Model.EntityClasses.Av001TdiBilTebligatMuhatapEntity);
                                try
                                {
                                    if (ent.AlanCariId == SourceCari.Id)
                                    {
                                        ent.Av001TdiBilCari = TargetCari;
                                        ent.AlanCariId = TargetCari.Id;
                                        ent.Save();
                                    }
                                    else if (ent.MuhatapCariId == SourceCari.Id)
                                    {
                                        ent.Av001TdiBilCari_ = TargetCari;
                                        ent.MuhatapCariId = TargetCari.Id;
                                        ent.Save();
                                    }
                                }
                                catch
                                {
                                    ent.Delete();
                                }
                            }
                        }
                        else
                        {
                            var target = (item.GetValue(TargetCari, null) as IEntityCollection);
                            foreach (IEntity entity in source.Cast<IEntity>().ToList())
                            {
                                target.Add(entity);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Logger.ErrorException("Cari Birleştirme", ex);
                    hasError = true;
                    MessageBox.Show(ex.Message);
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
                backgroundWorker1.ReportProgress((cur * 100) / total);
            }
            lblProcessInfo.Text = "Değişiklikler Kaydediliyor";
            try
            {
                TargetCari.Save(true);
                SourceCari.Save(true);
                //if (chkDelete.Checked)
                //{
                SourceCari.Delete();
                //}
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Logger.ErrorException("Cari Birleştirme", ex);
                hasError = true;
                MessageBox.Show(ex.Message);
            }
            //AvukatPro.Model.da Data.Context.DbContext = null;
            //if (hasError)
            //    trans.Rollback();
            //else
            //    trans.Commit();
            if (hasError)
                MessageBox.Show("Birleştirme sırasında hatalar oluşmuştur. Birleştirme işlemi gerçekleşmemiştir.");
            lblProcessInfo.Text = "";
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgProcess.Position = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Cari Aktarımı Başarıyla Bitmiştir.");
        }

        private void frmCariMerge_Load(object sender, EventArgs e)
        {
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTarafAdi1, null);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueTarafAdi2, null);
            //var collection = (lueTarafAdi2.Properties.DataSource as List<AvukatPro.Model.EntityClasses.PerCariKimlikIletisimBilgileriEntity>);
            //var src = collection.Where(q => q.Id == SourceCari.Id).FirstOrDefault();

            //if (src != null)
            //    collection.Remove(src);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lueTarafAdi1.EditValue != null && ((int?)lueTarafAdi1.EditValue).HasValue)
            {
            }
            else
            {
                MessageBox.Show("Lütfen Kaynak Cari Seçiniz.");
                return;
            }

            if (lueTarafAdi2.EditValue != null && ((int?)lueTarafAdi2.EditValue).HasValue)
            {
            }
            else
            {
                MessageBox.Show("Lütfen Hedef Cari Seçiniz.");
                return;
            }

            if (lueTarafAdi1.EditValue == lueTarafAdi2.EditValue)
            {
                MessageBox.Show("Lütfen Farklı Cariler Seçiniz.");
                return;
            }

            if (MessageBox.Show("Dikkat yapacağınız bu işlem...\nKaynak şahıs üzerindeki her türlü dosya, belge ve ilişkileri hedef şahız üzerine atayacaktır. Birleştirme işleminin geri dönüşü yoktur. İşleme devam etmek istiyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;

            backgroundWorker1.RunWorkerAsync();
        }
    }
}