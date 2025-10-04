using AvukatProLib.AVPLicence;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace AvukatProLib.PaketYonetimi
{
    public class DbOperations
    {
        public DbOperations()
        {
            //paketList = dataContext.CS_KOD_PAKETs.ToList();
            //formList = dataContext.CS_KOD_FORM_LISTESIs.ToList();
            //nnformList = dataContext.CS_KOD_PAKET_NN_FORMs.ToList();
        }

        private static DataClassesDataContext dataContext = new DataClassesDataContext();//GetDataContext();
        private static List<CS_KOD_PAKET> paketList = null;

        public static void ConnectDb(string connectionString)
        {
            if (dataContext.Connection.State == System.Data.ConnectionState.Open) dataContext.Connection.Close();
            dataContext = new DataClassesDataContext(connectionString);

            //dataContext.Connection.ConnectionString = connectionString;
            //dataContext = new DataClassesDataContext(connectionString);
        }

        public static bool CopyPacket(string sourcePackName, string destinationPackName, string connectionString)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext();
            if (dataContext.Connection.State == System.Data.ConnectionState.Open) dataContext.Connection.Close();
            dataContext.Connection.ConnectionString = connectionString;
            try
            {
                List<CS_KOD_PAKET> sourcePack = dataContext.CS_KOD_PAKETs.Where(item => item.PAKET_ADI == sourcePackName).ToList();
                if (sourcePack == null || sourcePack.Count == 0)
                {
                    MessageBox.Show(String.Format("{0} paketi bulunamadı.", sourcePackName));
                    return false;
                }
                List<CS_KOD_PAKET> destPack = dataContext.CS_KOD_PAKETs.Where(item => item.PAKET_ADI == destinationPackName).ToList();
                if (destPack != null && destPack.Count > 0) //Paket mevcut
                {
                    if (MessageBox.Show(String.Format("Devam ederseniz {0} paketine ait bilgiler silinecek.\r\nYine de devam etmek istiyor musunuz?", destPack[0].PAKET_ADI), "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dataContext.CS_KOD_PAKETs.DeleteOnSubmit(destPack[0]);
                    }
                }
                CS_KOD_PAKET pack = new CS_KOD_PAKET();
                pack.KAYIT_TARIHI = DateTime.Now;
                pack.MODUL_NO = 1;
                pack.PAKET_ADI = destinationPackName;
                pack.stamp = 1;
                foreach (var item in sourcePack[0].CS_KOD_PAKET_NN_FORMs)
                {
                    CS_KOD_PAKET_NN_FORM nnForm = new CS_KOD_PAKET_NN_FORM();
                    nnForm.CS_KOD_PAKET = pack;
                    nnForm.CS_KOD_FORM_LISTESI = item.CS_KOD_FORM_LISTESI;
                    pack.CS_KOD_PAKET_NN_FORMs.Add(nnForm);
                }
                foreach (var item in sourcePack[0].CS_KOD_KONTROL_OZELLIKLERIs)
                {
                    CS_KOD_KONTROL_OZELLIKLERI ctrlProps = new CS_KOD_KONTROL_OZELLIKLERI();
                    ctrlProps.AKTIF_MI = item.AKTIF_MI;
                    ctrlProps.CS_KOD_PAKET = pack;
                    ctrlProps.CS_KOD_KONTROL_LISTESI = item.CS_KOD_KONTROL_LISTESI;
                    ctrlProps.GORUNUR_MU = item.GORUNUR_MU;
                    ctrlProps.SEPETTE_GOSTERILSIN_MI = item.SEPETTE_GOSTERILSIN_MI;
                    ctrlProps.YETKILENDIRMEDE_KULLANILSIN_MI = item.YETKILENDIRMEDE_KULLANILSIN_MI;
                    pack.CS_KOD_KONTROL_OZELLIKLERIs.Add(ctrlProps);
                }
                dataContext.CS_KOD_PAKETs.InsertOnSubmit(pack);
                dataContext.SubmitChanges();

                MessageBox.Show("Paket başarıyla kopyalandı.");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(String.Format("Paket kopyalanamadı.\nHata: {0}", ex.Message));
                return false;
            }
        }

        public static void CreateDatabase(string connectionString)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext();
            List<CS_KOD_PAKET> paketList = dataContext.CS_KOD_PAKETs.ToList();
            if (dataContext.Connection.State == System.Data.ConnectionState.Open) dataContext.Connection.Close();
            dataContext.Connection.ConnectionString = connectionString;
            if (!dataContext.DatabaseExists())
            {
                try
                {
                    dataContext.CreateDatabase();
                    foreach (CS_KOD_PAKET paket in paketList)
                    {
                        CS_KOD_PAKET pack = new CS_KOD_PAKET();
                        pack.KAYIT_TARIHI = DateTime.Now;
                        pack.MODUL_NO = 1;
                        pack.PAKET_ADI = paket.PAKET_ADI;
                        pack.stamp = 1;
                        dataContext.CS_KOD_PAKETs.InsertOnSubmit(pack);
                    }
                    dataContext.SubmitChanges();

                    //SaveConStr(connectionString);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(String.Format("Veritabanı oluşturulamadı.\nHata: {0}", ex.Message));
                }
            }
        }

        public static List<PaketBilgisi> GetPackListInfo(List<CS_KOD_PAKET> paketListesi)
        {
            List<PaketBilgisi> paketBilgileri = new List<PaketBilgisi>();
            List<PaketForm> formList = new List<PaketForm>();
            List<PaketControl> controlList = new List<PaketControl>();
            var dkl = paketListesi.Select(q => new PaketBilgisi()
            {
                PaketAdi = q.PAKET_ADI,
                FormListesi = q.CS_KOD_PAKET_NN_FORMs.Select(w => new PaketForm()
                {
                    FormAdi = w.CS_KOD_FORM_LISTESI.FULL_ADI,
                    Text = w.CS_KOD_FORM_LISTESI.FORM_TEXT,
                    Aciklama = w.CS_KOD_FORM_LISTESI.FORM_ACIKLAMA,
                    KontrolListesi = w.CS_KOD_FORM_LISTESI.CS_KOD_KONTROL_LISTESIs.Where(e => q.CS_KOD_KONTROL_OZELLIKLERIs.ToList().Any(r => r.KONTROL_ID == e.ID && r.PARENT_GORUNUR_MU.HasValue && r.PARENT_GORUNUR_MU.Value && !r.GORUNUR_MU.Value))
                        .Select(e => new PaketControl()
                    {
                        KontrolAdi = e.KONTROL_ADI,
                        Text = e.KONTROL_TEXT,
                        Aciklama = e.KONTROL_ACIKLAMA,
                        TipAdi = e.TIP_ADI,
                        RelativePath = e.RELATIVE_PATH,
                        UniqueId = e.UNIQUE_ID ?? -1,
                        Aktif = q.CS_KOD_KONTROL_OZELLIKLERIs.ToList().Where(r => r.KONTROL_ID == e.ID && r.PARENT_GORUNUR_MU.HasValue && r.PARENT_GORUNUR_MU.Value && !r.GORUNUR_MU.Value).First().AKTIF_MI ?? true,
                        Gorunur = q.CS_KOD_KONTROL_OZELLIKLERIs.ToList().Where(r => r.KONTROL_ID == e.ID && r.PARENT_GORUNUR_MU.HasValue && r.PARENT_GORUNUR_MU.Value && !r.GORUNUR_MU.Value).First().GORUNUR_MU ?? true,
                        Sepette_Goster = q.CS_KOD_KONTROL_OZELLIKLERIs.ToList().Where(r => r.KONTROL_ID == e.ID && r.PARENT_GORUNUR_MU.HasValue && r.PARENT_GORUNUR_MU.Value && !r.GORUNUR_MU.Value).First().SEPETTE_GOSTERILSIN_MI ?? true,
                        Yetkilendirmede_Kullan = q.CS_KOD_KONTROL_OZELLIKLERIs.ToList().Where(r => r.KONTROL_ID == e.ID && r.PARENT_GORUNUR_MU.HasValue && r.PARENT_GORUNUR_MU.Value && !r.GORUNUR_MU.Value).First().YETKILENDIRMEDE_KULLANILSIN_MI ?? true
                    }).ToArray()
                }).ToArray()
            }).ToList();

            //foreach (var paket in paketListesi)
            //{
            //    formList.Clear();
            //    controlList.Clear();
            //    PaketBilgisi packInfo = new PaketBilgisi();
            //    packInfo.PaketAdi = paket.PAKET_ADI;
            //    //packInfo.Aciklama = paket.ACIKLAMA;
            //    foreach (var item in paket.CS_KOD_PAKET_NN_FORMs)
            //    {
            //        PaketForm pktForm = new PaketForm();
            //        pktForm.FormAdi = item.CS_KOD_FORM_LISTESI.FULL_ADI;
            //        pktForm.Text = item.CS_KOD_FORM_LISTESI.FORM_TEXT;
            //        pktForm.Aciklama = item.CS_KOD_FORM_LISTESI.FORM_ACIKLAMA;
            //        foreach (var ctrl in item.CS_KOD_FORM_LISTESI.CS_KOD_KONTROL_LISTESIs)
            //        {
            //            List<CS_KOD_KONTROL_OZELLIKLERI> controlProps = ctrl.CS_KOD_KONTROL_OZELLIKLERIs.Where(controlItem => controlItem.PAKET_ID == paket.ID && controlItem.PARENT_GORUNUR_MU.HasValue && controlItem.PARENT_GORUNUR_MU.Value && !controlItem.GORUNUR_MU.Value).ToList();
            //            if (controlProps != null && controlProps.Count > 0)
            //            {
            //                PaketControl control = new PaketControl();
            //                control.KontrolAdi = ctrl.KONTROL_ADI;
            //                control.Text = ctrl.KONTROL_TEXT;
            //                control.Aciklama = ctrl.KONTROL_ACIKLAMA;
            //                control.TipAdi = ctrl.TIP_ADI;
            //                control.RelativePath = ctrl.RELATIVE_PATH;
            //                control.UniqueId = ctrl.UNIQUE_ID.HasValue ? ctrl.UNIQUE_ID.Value : -1;
            //                control.Aktif = Convert.ToBoolean(controlProps[0].AKTIF_MI);
            //                control.Gorunur = Convert.ToBoolean(controlProps[0].GORUNUR_MU);
            //                control.Sepette_Goster = Convert.ToBoolean(controlProps[0].SEPETTE_GOSTERILSIN_MI);
            //                control.Yetkilendirmede_Kullan = Convert.ToBoolean(controlProps[0].YETKILENDIRMEDE_KULLANILSIN_MI);
            //                controlList.Add(control);
            //                if (ctrl.CS_KOD_KONTROL_LISTESI1 != null)
            //                {
            //                    var result = controlList.Where(ctrlItem => ctrlItem.KontrolAdi == ctrl.CS_KOD_KONTROL_LISTESI1.KONTROL_ADI);
            //                    if (result != null && result.Count() > 0) control.Parent = result.Last();
            //                }
            //            }
            //        }
            //        pktForm.KontrolListesi = controlList.ToArray();
            //        formList.Add(pktForm);
            //    }
            //    packInfo.FormListesi = formList.ToArray();
            //    paketBilgileri.Add(packInfo);
            //}
            return dkl;
        }

        public static List<CS_KOD_PAKET> GetPaketBilgileri()
        {
            return dataContext.CS_KOD_PAKETs.ToList();
        }

        public void DeleteAll(string conStr)
        {
            try
            {
                DataClassesDataContext dataContext = null;
                if (!string.IsNullOrEmpty(conStr))
                    dataContext = new DataClassesDataContext(conStr);
                else dataContext = new DataClassesDataContext();
                dataContext.CS_KOD_KONTROL_OZELLIKLERIs.DeleteAllOnSubmit(dataContext.CS_KOD_KONTROL_OZELLIKLERIs);
                dataContext.CS_KOD_KONTROL_LISTESIs.DeleteAllOnSubmit(dataContext.CS_KOD_KONTROL_LISTESIs);
                dataContext.CS_KOD_FORM_LISTESIs.DeleteAllOnSubmit(dataContext.CS_KOD_FORM_LISTESIs);
                dataContext.CS_KOD_PAKET_NN_FORMs.DeleteAllOnSubmit(dataContext.CS_KOD_PAKET_NN_FORMs);

                dataContext.SubmitChanges();
            }
            catch 
            {
            }
        }

        public LisansBilgisi GetLisansBilgisi(CS_KOD_PAKET csPaket)
        {
            List<PaketBilgisi> paketBilgileri = new List<PaketBilgisi>();
            List<PaketForm> formList = new List<PaketForm>();
            List<PaketControl> controlList = new List<PaketControl>();

            LisansBilgisi lisans = new LisansBilgisi();

            lisans.AdSoyad = "Avukatpro";

            List<CS_KOD_PAKET> paketListesi = new List<CS_KOD_PAKET>();
            paketListesi.AddRange(GetPaketList(csPaket));
            if (csPaket != null)
            {
                lisans.PaketAdi = csPaket.PAKET_ADI;
                lisans.ModulNo = csPaket.MODUL_NO;
            }
            else lisans.PaketAdi = paketListesi[0].PAKET_ADI;

            lisans.PaketBilgileri = GetPackListInfo(paketListesi).ToArray();

            return lisans;
        }

        public LisansBilgisi GetLisansBilgisi(List<CS_KOD_PAKET> paketListesi)
        {
            List<PaketBilgisi> paketBilgileri = new List<PaketBilgisi>();
            List<PaketForm> formList = new List<PaketForm>();
            List<PaketControl> controlList = new List<PaketControl>();

            LisansBilgisi lisans = new LisansBilgisi();
            lisans.AdSoyad = "Avukatpro";
            lisans.PaketAdi = paketListesi[0].PAKET_ADI;
            lisans.PaketBilgileri = GetPackListInfo(paketListesi).ToArray();
            lisans.ModulNo = paketListesi[0].MODUL_NO;
            return lisans;
        }

        public void LoadData(Form form, Dictionary<int, List<ControlItem>> packItems)
        {
            CS_KOD_PAKET_NN_FORM csNNForm = null;
            CS_KOD_FORM_LISTESI csForm = null;
            List<CS_KOD_PAKET_NN_FORM> csNNFormItem = null;
            paketList = dataContext.CS_KOD_PAKETs.ToList();
            foreach (int paketId in packItems.Keys)
            {
                List<ControlItem> controlList = packItems[paketId];

                csNNFormItem = dataContext.CS_KOD_PAKET_NN_FORMs.Where(nnFormItem => nnFormItem.PAKET_ID == paketId && nnFormItem.CS_KOD_FORM_LISTESI.FULL_ADI == form.GetType().FullName).ToList();

                /*
                 * NNForm ilişkisi veritabanında bulunamadıysa yeni bir CS_KOD_PAKET_NN_FORM nesnesi oluşturuluyor
                 * İlişki bulunursa ilişkiye ait form nesnesi var mı kontrol ediliyor ve yoksa yeni bir CS_KOD_FORM_LISTESI nesnesi oluşturuluyor
                 */

                if (csNNFormItem == null || csNNFormItem.Count == 0)
                {
                    csNNForm = new CS_KOD_PAKET_NN_FORM();
                    if (csNNForm.CS_KOD_PAKET == null) csNNForm.CS_KOD_PAKET = paketList.Where(paket => paket.ID == paketId).Single();

                    dataContext.CS_KOD_PAKET_NN_FORMs.InsertOnSubmit(csNNForm);
                }
                else
                {
                    csNNForm = csNNFormItem[0];
                }

                if (csNNForm.CS_KOD_FORM_LISTESI != null)
                {
                    csForm = csNNForm.CS_KOD_FORM_LISTESI;
                }
                if (csForm == null)
                {
                    csForm = new CS_KOD_FORM_LISTESI();
                    csForm.KONTROL_NE_ZAMAN = DateTime.Now;
                    if (csNNForm.CS_KOD_PAKET == null) csNNForm.CS_KOD_PAKET = paketList.Where(paket => paket.ID == paketId).Single();
                    dataContext.CS_KOD_FORM_LISTESIs.InsertOnSubmit(csForm);
                }
                if (csNNForm.CS_KOD_FORM_LISTESI == null) csNNForm.CS_KOD_FORM_LISTESI = csForm;

                /*
                 * Form'a ait kontrol listesiyle veritabanındaki kontrol listesi karşılaştırılıyor.
                 * Veritabanında form kontrol listesinde olmayan kayıtlar mevcutsa bu kayıtlar siliniyor.
                 * Kontrol listesindeki kayıtlardan veritabanında olmayanlar varsa bu kayıtlar insert ediliyor.
                 */

                //var identicalQuery = from ctrlItem in controlList
                //                     join csControl in csNNForm.CS_KOD_FORM_LISTESI.CS_KOD_KONTROL_LISTESIs
                //                     on ctrlItem.Name/*.FullPath.GetHashCode()*/ equals csControl.KONTROL_ADI/*.UNIQUE_ID*/
                //                     select new { Item1 = ctrlItem, Item2 = csControl };

                //Dictionary<ControlItem, CS_KOD_KONTROL_LISTESI> kontrolPairList = new Dictionary<ControlItem, CS_KOD_KONTROL_LISTESI>();
                //foreach (ControlItem ctrlItem in controlList)
                //{
                //    List<CS_KOD_KONTROL_LISTESI> tmpCtrlList = null;
                //    if(ctrlItem.Parent != null)
                //        tmpCtrlList = csNNForm.CS_KOD_FORM_LISTESI.CS_KOD_KONTROL_LISTESIs.Where(csControl => csControl.KONTROL_ADI == ctrlItem.Name && (csControl.CS_KOD_KONTROL_LISTESI1 != null ? csControl.CS_KOD_KONTROL_LISTESI1.KONTROL_ADI == ctrlItem.Parent.Name : true)).ToList();
                //    else tmpCtrlList = csNNForm.CS_KOD_FORM_LISTESI.CS_KOD_KONTROL_LISTESIs.Where(csControl => csControl.KONTROL_ADI == ctrlItem.Name).ToList();

                //    if(tmpCtrlList != null && tmpCtrlList.Count > 0)
                //        kontrolPairList.Add(ctrlItem, tmpCtrlList[0]);
                //}

                var identicalQuery = from ctrlItem in controlList
                                     join csControl in csNNForm.CS_KOD_FORM_LISTESI.CS_KOD_KONTROL_LISTESIs on
                                         new { name = ctrlItem.Name, parName = (ctrlItem.Parent != null && !(ctrlItem.Parent.Control is Form)) ? ctrlItem.Parent.Name : "" }
                                         equals
                                         new { name = csControl.KONTROL_ADI, parName = csControl.CS_KOD_KONTROL_LISTESI1 != null ? csControl.CS_KOD_KONTROL_LISTESI1.KONTROL_ADI : "" }
                                     select new { Item1 = ctrlItem, Item2 = csControl };

                List<CS_KOD_KONTROL_LISTESI> tmpControlList = new List<CS_KOD_KONTROL_LISTESI>();
                foreach (var result in identicalQuery)
                {
                    Dictionary<string, string> tmpList = new Dictionary<string, string>();

                    if (result.Item1 == null || result.Item2 == null) continue;
                    tmpList.Add(result.Item1.Name, result.Item2.KONTROL_ADI);
                    tmpControlList.Add(result.Item2);
                    result.Item1.csForm = csNNForm.CS_KOD_FORM_LISTESI;
                    result.Item1.csControl = result.Item2;
                    result.Item2.RELATIVE_PATH = result.Item1.RelativePath;
                    var resultItem = (from item in result.Item2.CS_KOD_KONTROL_OZELLIKLERIs where item.PAKET_ID == paketId select item);
                    result.Item1.csControlProperties = resultItem.Count() > 0 ? resultItem.Single() : new CS_KOD_KONTROL_OZELLIKLERI();
                    //if (result.Item1.csControlProperties.GORUNUR_MU != null) result.Item1.Visible = Convert.ToBoolean(result.Item1.csControlProperties.GORUNUR_MU);
                    //if (result.Item1.csControlProperties.AKTIF_MI != null) result.Item1.Enabled = Convert.ToBoolean(result.Item1.csControlProperties.AKTIF_MI);
                    //if (result.Item1.csControlProperties.SEPETTE_GOSTERILSIN_MI != null) result.Item1.ShowInCustomizationForm = Convert.ToBoolean(result.Item1.csControlProperties.SEPETTE_GOSTERILSIN_MI);
                    //if (result.Item1.csControlProperties.YETKILENDIRMEDE_KULLANILSIN_MI != null) result.Item1.ShowInAccessList = Convert.ToBoolean(result.Item1.csControlProperties.YETKILENDIRMEDE_KULLANILSIN_MI);
                }
                /* Silme işlemi için kullanılacak. Geçici olarak kaldırıldı
                if (!string.IsNullOrEmpty(csNNForm.CS_KOD_FORM_LISTESI.FULL_ADI)) // Form veritabanında mevcut
                {
                    List<CS_KOD_KONTROL_LISTESI> deleteList = new List<CS_KOD_KONTROL_LISTESI>();
                    foreach (CS_KOD_KONTROL_LISTESI cs_Control in csNNForm.CS_KOD_FORM_LISTESI.CS_KOD_KONTROL_LISTESIs)
                    {
                        if (!tmpControlList.Exists(tmpItem => tmpItem.UNIQUE_ID == cs_Control.UNIQUE_ID))
                            deleteList.Add(cs_Control);
                    }

                    //var deleteList = csNNForm.CS_KOD_FORM_LISTESI.CS_KOD_KONTROL_LISTESIs.Except(tmpControlList);
                    dataContext.CS_KOD_KONTROL_LISTESIs.DeleteAllOnSubmit(deleteList);
                }
                 * */
                for (int i = 0; i < controlList.Count; i++)
                {
                    ControlItem item = controlList[i];
                    if (item.Control is Form) continue;
                    if (item.csControl == null)
                    {
                        item.csControl = new CS_KOD_KONTROL_LISTESI();

                        //item.csControl.CS_KOD_FORM_LISTESI = csForm;
                        item.csControl.KONTROL_NE_ZAMAN = DateTime.Now;
                        item.csControl.KONTROL_ADI = item.Name;
                        item.csControl.KONTROL_TEXT = item.Text;
                        item.csControl.KONTROL_ACIKLAMA = item.Explanation;
                        item.csControl.ADMIN_KAYIT_MI = true;
                        item.csControl.UNIQUE_ID = item.FullPath.GetHashCode();
                        item.csControl.TIP_ADI = item.Control.GetType().FullName;
                        item.csControl.RELATIVE_PATH = item.RelativePath;
                        csForm.CS_KOD_KONTROL_LISTESIs.Add(item.csControl);
                        dataContext.CS_KOD_KONTROL_LISTESIs.InsertOnSubmit(item.csControl);
                    }
                    var property = (from prop in item.csControl.CS_KOD_KONTROL_OZELLIKLERIs where prop.PAKET_ID == paketId select prop).ToList();
                    if (property.Count > 0)
                    {
                        item.csControlProperties = property[0];
                        item.csControlProperties.PARENT_GORUNUR_MU = item.ParentVisible;
                    }
                    else
                    {
                        item.csControlProperties = new CS_KOD_KONTROL_OZELLIKLERI();
                        item.csControlProperties.AKTIF_MI = item.csControlProperties.GORUNUR_MU = item.csControlProperties.SEPETTE_GOSTERILSIN_MI = item.csControlProperties.YETKILENDIRMEDE_KULLANILSIN_MI = true;
                        item.csControlProperties.PAKET_ID = paketId;
                        item.csControlProperties.PARENT_GORUNUR_MU = item.ParentVisible;
                        item.csControl.CS_KOD_KONTROL_OZELLIKLERIs.Add(item.csControlProperties);
                    }

                    int index = -1;
                    foreach (int id in packItems.Keys)
                    {
                        index++;
                        if (index == 0) continue;
                        packItems[id][i].csControl = item.csControl;
                    }
                }
            }
            foreach (ControlItem controlItem in packItems.Values.First())
            {
                if (controlItem.Control is Form) continue;
                if (controlItem.csControl.CS_KOD_KONTROL_LISTESI1 == null && controlItem.Parent != null) controlItem.csControl.CS_KOD_KONTROL_LISTESI1 = controlItem.Parent.csControl;
            }

            csForm.ADMIN_KAYIT_MI = true;
            csForm.BUTTON_GORUNUM_LIST = "";
            csForm.DB_TABLO_ADI = "";
            csForm.FORM_ACIKLAMA = csForm.FORM_TEXT = form.Text;
            csForm.FULL_ADI = form.GetType().FullName;
            csForm.KONTROL_KIM_ID = 1;
            csForm.KONTROL_NE_ZAMAN = DateTime.Now;
            csForm.KONTROL_VERSIYON = 1;
            csForm.MENU_NESNE_ADI = "";
            csForm.STAMP = 1;
            csForm.SUZME_KRITER = "";
        }

        public void Save(CS_KOD_PAKET paket, TreeList treeList)
        {
            //try
            //{
            if (dataContext.Connection.State != System.Data.ConnectionState.Open) dataContext.Connection.Open();
            dataContext.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(String.Format("Kayıt işlemi esnasında hata oluştu.\r\nHata: {0}", ex.Message));
            //}
        }

        private List<CS_KOD_PAKET> GetPaketList(CS_KOD_PAKET paket)
        {
            List<CS_KOD_PAKET> returnList = dataContext.CS_KOD_PAKETs.ToList();

            //returnList.Add(paket);
            //List<CS_KOD_PAKET> paketList = (from item in dataContext.CS_KOD_PAKETs where returnList.Contains((q => q.ID != item.ID) select item).ToList();
            //foreach (var pack in paketList)
            //{
            //    returnList.AddRange(GetPaketList(pack));
            //}
            return returnList;
        }
    }
}