using Newtonsoft.Json;
using Notes.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Xamarin.Forms;
using Color = Xamarin.Forms.Color;
namespace Notes.Views
{

    [QueryProperty(nameof(Loadname), nameof(Loadname))]
    public partial class EquipViewPage : ContentPage
    {
        string _member = "";

        [Obsolete]
        public EquipViewPage()
        {
            InitializeComponent();

            //BindingContext = new Equip();
            GetCharEquipFullInfo();
        }

        [Obsolete]
        public void OnUpdateInfo(object sender, EventArgs e)
        {
            GetCharEquipFullInfo();
        }

        public string Loadname
        {
            set
            {
                _member = value;

                Title = _member;

            }
        }


        private static BackgroundWorker equipWorker;
        private static Equip equipChar;

        [Obsolete]
        public void GetCharEquipFullInfo()
        {

            Updater.IsRunning = true;
            UpdaterGrid.IsVisible = true;
            InfoGrid.IsVisible = false;
            ErrorFrame.IsVisible = false;
            Progress.Text = "0%";
            equipChar = new Equip();

            try
            {



                equipWorker = new BackgroundWorker
                {
                    WorkerReportsProgress = true
                };
                equipWorker.DoWork += new DoWorkEventHandler(UpdateInfo);
                equipWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressUpdater);
                equipWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Main_info_workerCompleted);
                equipWorker.RunWorkerAsync();





            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Console.WriteLine("1ОШИБКА : !" + e.Message);
                    Updater.IsRunning = false;
                    UpdaterGrid.IsVisible = false;
                    InfoGrid.IsVisible = false;
                    ErrorFrame.IsVisible = true;
                    ErrorName.Text = "Ошибка";
                    ErrorText.Text = "Нет сети/Сервер не доступен.\nПопробуйте позже.";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("2ОШИБКА : !" + e.Message);
                Updater.IsRunning = false;
                UpdaterGrid.IsVisible = false;
                InfoGrid.IsVisible = false;
                ErrorFrame.IsVisible = true;
                ErrorName.Text = "Ошибка";
                ErrorText.Text = "Нет сети/Сервер не доступен.\nПопробуйте позже.";
                Console.WriteLine(e.Message);
            }


        }
        [Obsolete]
        private void UpdateInfo(object sender, DoWorkEventArgs e)
        {

            GetEquipCharacter();

        }

        [Obsolete]
        private void Main_info_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Main_image.Source = equipChar.charMedia;
            if (equipChar.head != null)
            {
                Head.Source = equipChar.head;
                HeadLVL.Text = equipChar.headLVL;
                HeadLVL.TextColor = equipChar.headRGBLVL;
            }

            if (equipChar.hands != null)
            {
                Hands.Source = equipChar.hands;
                HandsLVL.Text = equipChar.handsLVL;
                HandsLVL.TextColor = equipChar.handsRGBLVL;
            }

            if (equipChar.neck != null)
            {
                Neck.Source = equipChar.neck;
                NeckLVL.Text = equipChar.neckLVL;
                NeckLVL.TextColor = equipChar.neckRGBLVL;
            }

            if (equipChar.waist != null)
            {
                Waist.Source = equipChar.waist;
                WaistLVL.Text = equipChar.waistLVL;
                WaistLVL.TextColor = equipChar.waistRGBLVL;
            }

            if (equipChar.shoulders != null)
            {
                Shoulder.Source = equipChar.shoulders;
                ShouldersLVL.Text = equipChar.shouldersLVL;
                ShouldersLVL.TextColor = equipChar.shouldersRGBLVL;
            }

            if (equipChar.legs != null)
            {
                Legs.Source = equipChar.legs;
                LegsLVL.Text = equipChar.legsLVL;
                LegsLVL.TextColor = equipChar.legsRGBLVL;
            }

            if (equipChar.back != null)
            {
                Back.Source = equipChar.back;
                BackLVL.Text = equipChar.backLVL;
                BackLVL.TextColor = equipChar.backRGBLVL;
            }

            if (equipChar.feet != null)
            {
                Feet.Source = equipChar.feet;
                FeetLVL.Text = equipChar.feetLVL;
                FeetLVL.TextColor = equipChar.feetRGBLVL;
            }

            if (equipChar.chest != null)
            {
                Chest.Source = equipChar.chest;
                ChestLVL.Text = equipChar.chestLVL;
                ChestLVL.TextColor = equipChar.chestRGBLVL;
            }

            if (equipChar.finger1 != null)
            {
                Finger1.Source = equipChar.finger1;
                Finger1LVL.Text = equipChar.finger1LVL;
                Finger1LVL.TextColor = equipChar.finger1RGBLVL;
            }

            if (equipChar.shirt != null)
            {
                Shirt.Source = equipChar.shirt;
                ShirtLVL.Text = equipChar.shirtLVL;
                ShirtLVL.TextColor = equipChar.shirtRGBLVL;
            }

            if (equipChar.finger2 != null)
            {
                Finger2.Source = equipChar.finger2;
                Finger2LVL.Text = equipChar.finger2LVL;
                Finger2LVL.TextColor = equipChar.finger2RGBLVL;
            }

            if (equipChar.tabard != null)
            {
                Tabard.Source = equipChar.tabard;
                TabardLVL.Text = equipChar.tabardLVL;
                TabardLVL.TextColor = equipChar.tabardRGBLVL;
            }

            if (equipChar.trinket1 != null)
            {
                Trinket1.Source = equipChar.trinket1;
                Trinket1LVL.Text = equipChar.trinket1LVL;
                Trinket1LVL.TextColor = equipChar.trinket1RGBLVL;
            }

            if (equipChar.wrist != null)
            {
                Wrist.Source = equipChar.wrist;
                WristLVL.Text = equipChar.wristLVL;
                WristLVL.TextColor = equipChar.wristRGBLVL;
            }

            if (equipChar.trinket2 != null)
            {
                Trinket2.Source = equipChar.trinket2;
                Trinket2LVL.Text = equipChar.trinket2LVL;
                Trinket2LVL.TextColor = equipChar.trinket2RGBLVL;
            }


            if (equipChar.main_hand != null)
            {
                MainHand.Source = equipChar.main_hand;
                Main_handLVL.Text = equipChar.main_handLVL;
                Main_handLVL.TextColor = equipChar.main_handRGBLVL;
            }

            if (equipChar.off_hands != null)
            {
                OffHandk.Source = equipChar.off_hands;
                Off_handsLVL.Text = equipChar.off_handsLVL;
                Off_handsLVL.TextColor = equipChar.off_handsRGBLVL;
            }
            Updater.IsRunning = false;
            UpdaterGrid.IsVisible = false;
            InfoGrid.IsVisible = true;
            ErrorFrame.IsVisible = false;
            UpdateButton.IsEnabled = true;





        }

        [Obsolete]

        private void ProgressUpdater(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                Progress.Text = e.ProgressPercentage.ToString() + "%";

            }
            catch (Exception ex)
            {
                Console.WriteLine("EXSA" + ex.Message);
            }


        }
      



        private void GetEquipCharacter()
        {


            try
            {
                WebRequest request = WebRequest.Create("https://" + App.region.ToLower() + ".api.blizzard.com/profile/wow/character/" + App.realslug + "/" + App.viewMember.ToLower() + "/equipment?namespace=profile-" + App.region.ToLower() + "&locale=" + App.localslug + "&access_token=" + App.token);
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {

                    using (StreamReader reader = new StreamReader(stream))
                    {

                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            int i = 0;
                            line = line.Replace("'", " ");



                            Equip_character_Root equip = JsonConvert.DeserializeObject<Equip_character_Root>(line);
                            if (equip != null)
                            {
                                foreach (Equip_character_EquippedItem items in equip.equipped_items)
                                {


                                    GetItemInfo(items.item.key.href, items.slot.type, items.level.value.ToString(), items.quality.type);


                                    i++;

                                    try
                                    {
                                        equipWorker.ReportProgress(i * 100 / equip.equipped_items.Count);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("EXSA" + ex.Message);
                                    }
                                }
                                GetCharMedia();
                            }
                        }
                    }
                }
                responce.Close();
            }
            catch (WebException er)
            {
                if (er.Status == WebExceptionStatus.ProtocolError)
                {

                    Console.WriteLine("3ОШИБКА : !" + er.Message);
                }
            }
            catch (Exception er)
            {

                Console.WriteLine("4ОШИБКА : !" + er.Message);
            }


        }


        private void GetItemInfo(string link, string type, string lvl, string qality)
        {


            try
            {
                WebRequest request = WebRequest.Create(link + "&locale=" + App.localslug + "&access_token=" + App.token);
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {


                            GetItemEquipChar itemEquip = JsonConvert.DeserializeObject<GetItemEquipChar>(line);


                            GetItemMedia(itemEquip.media.key.href, type, lvl, qality);




                        }
                    }
                }
                responce.Close();
            }
            catch (WebException er)
            {
                if (er.Status == WebExceptionStatus.ProtocolError)
                {
                    Console.WriteLine("5ОШИБКА : !" + er.Message);
                }
            }
            catch (Exception er)
            {
                Console.WriteLine("6ОШИБКА : !" + er.Message);
            }


        }
        private Color ColorItemQuality(string quality)
        {
            if (quality == "POOR")
            {
                return Color.FromHex("#9d9d9d");
            }
            else if (quality == "COMMON")
            {
                return Color.FromHex("#fff");
            }
            else if (quality == "UNCOMMON")
            {
                return Color.FromHex("#1eff00");
            }
            else if (quality == "RARE")
            {
                return Color.FromHex("#0070dd");
            }
            else if (quality == "EPIC")
            {
                return Color.FromHex("#9345ff");
            }
            else if (quality == "LEGENDARY")
            {
                return Color.FromHex("#ff8000");
            }
            else if (quality == "ARTIFACT")
            {
                return Color.FromHex("#e5cc80");
            }
            else if (quality == "HEIRLOOM")
            {
                return Color.FromHex("#0cf");
            }
            else if (quality == "WOWTOKEN")
            {
                return Color.FromHex("#0cf");
            }
            return Color.FromHex("#fff");
        }
        private void GetItemMedia(string link, string type, string lvl, string qality)
        {


            WebClient dl = new WebClient();
            try
            {
                WebRequest request = WebRequest.Create(link + "&locale=" + App.localslug + "&access_token=" + App.token);
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {



                            GetItemEquipMedia itemEquipMedia = JsonConvert.DeserializeObject<GetItemEquipMedia>(line);

                            foreach (AssetEquipMedia asst in itemEquipMedia.assets)
                            {
                                if (type == "HEAD")
                                {

                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.head = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.headLVL = lvl;
                                    equipChar.headRGBLVL = ColorItemQuality(qality);
                                }

                                else if (type == "NECK")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.neck = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.neckLVL = lvl;
                                    equipChar.neckRGBLVL = ColorItemQuality(qality);
                                }
                                else if (type == "SHOULDER")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.shoulders = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.shouldersLVL = lvl;
                                    equipChar.shouldersRGBLVL = ColorItemQuality(qality);
                                }
                                else if (type == "SHIRT")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.shirt = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.shirtLVL = lvl;
                                    equipChar.shirtRGBLVL = ColorItemQuality(qality);
                                }
                                else if (type == "CHEST")
                                {

                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.chest = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.chestLVL = lvl;
                                    equipChar.chestRGBLVL = ColorItemQuality(qality);
                                }

                                else if (type == "WAIST")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.waist = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.waistLVL = lvl;
                                    equipChar.waistRGBLVL = ColorItemQuality(qality);
                                }

                                else if (type == "LEGS")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.legs = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.legsLVL = lvl;
                                    equipChar.legsRGBLVL = ColorItemQuality(qality);
                                }

                                else if (type == "FEET")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.feet = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.feetLVL = lvl;
                                    equipChar.feetRGBLVL = ColorItemQuality(qality);
                                }

                                else if (type == "WRIST")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.wrist = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.wristLVL = lvl;
                                    equipChar.wristRGBLVL = ColorItemQuality(qality);
                                }

                                else if (type == "HANDS")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.hands = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.handsLVL = lvl;
                                    equipChar.handsRGBLVL = ColorItemQuality(qality);
                                }

                                else if (type == "FINGER_1")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.finger1 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.finger1LVL = lvl;
                                    equipChar.finger1RGBLVL = ColorItemQuality(qality);
                                }
                                else if (type == "FINGER_2")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.finger2 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.finger2LVL = lvl;
                                    equipChar.finger2RGBLVL = ColorItemQuality(qality);
                                }
                                else if (type == "TRINKET_1")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.trinket1 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.trinket1LVL = lvl;
                                    equipChar.trinket1RGBLVL = ColorItemQuality(qality);
                                }
                                else if (type == "TRINKET_2")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.trinket2 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.trinket2LVL = lvl;
                                    equipChar.trinket2RGBLVL = ColorItemQuality(qality);
                                }
                                else if (type == "BACK")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.back = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.backLVL = lvl;
                                    equipChar.backRGBLVL = ColorItemQuality(qality);
                                }
                                else if (type == "MAIN_HAND")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.main_hand = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.main_handLVL = lvl;
                                    equipChar.main_handRGBLVL = ColorItemQuality(qality);
                                }
                                else if (type == "OFF_HAND")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.off_hands = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.off_handsLVL = lvl;
                                    equipChar.off_handsRGBLVL = ColorItemQuality(qality);
                                }
                                else if (type == "TABARD")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    equipChar.tabard = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                    equipChar.tabardLVL = lvl;
                                    equipChar.tabardRGBLVL = ColorItemQuality(qality);
                                }



                            }





                        }
                    }
                }
                responce.Close();
            }
            catch (WebException er)
            {
                if (er.Status == WebExceptionStatus.ProtocolError)
                {
                    Console.WriteLine("7ОШИБКА : !" + er.Message);
                }
            }
            catch (Exception er)
            {
                Console.WriteLine("8ОШИБКА : !" + er.Message);
            }


        }






        #region Button
        async void HeadButton(object sender, EventArgs e)
        {
            try
            {
                string str = "head" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void HandsButton(object sender, EventArgs e)
        {
            try
            {
                string str = "hands" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void NeckButton(object sender, EventArgs e)
        {
            try
            {
                string str = "neck" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void WaistButton(object sender, EventArgs e)
        {
            try
            {
                string str = "waist" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void ShoulderButton(object sender, EventArgs e)
        {
            try
            {
                string str = "shoulder" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void LegsButton(object sender, EventArgs e)
        {
            try
            {
                string str = "legs" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void BackButton(object sender, EventArgs e)
        {
            try
            {
                string str = "back" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void FeetButton(object sender, EventArgs e)
        {
            try
            {
                string str = "feet" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void ChestButton(object sender, EventArgs e)
        {
            try
            {
                string str = "chest" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void Finger1Button(object sender, EventArgs e)
        {
            try
            {
                string str = "finger2" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void ShirtButton(object sender, EventArgs e)
        {
            try
            {
                string str = "shirt" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void Finger2Button(object sender, EventArgs e)
        {
            try
            {
                string str = "finger2" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void TabardButton(object sender, EventArgs e)
        {
            try
            {
                string str = "tabard" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void Trinket1Button(object sender, EventArgs e)
        {
            try
            {
                string str = "trinket1" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void WristButton(object sender, EventArgs e)
        {
            try
            {
                string str = "wrist" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void Trinket2Button(object sender, EventArgs e)
        {
            try
            {
                string str = "trinket2" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void MainHandButton(object sender, EventArgs e)
        {
            try
            {
                string str = "main_hand" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void OffHandkButton(object sender, EventArgs e)
        {
            try
            {
                string str = "off_hand" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        #endregion
        private ImageSource Imagereturn(object obj)
        {
            try
            {
                return ImageSource.FromStream(() => new MemoryStream((byte[])obj));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        private void GetCharMedia()
        {

            WebClient dl = new WebClient();
            try
            {
                WebRequest request = WebRequest.Create("https://" + App.region.ToLower() + ".api.blizzard.com/profile/wow/character/" + App.realslug + "/" + App.viewMember.ToLower() + "/character-media?namespace=profile-" + App.region.ToLower() + "&locale=" + App.localslug + "&access_token=" + App.token);
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {


                            CharMedia charMedia = JsonConvert.DeserializeObject<CharMedia>(line);


                            foreach (AssetCM media in charMedia.assets)
                            {
                                if (media.key == "main")
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(media.value);
                                    equipChar.charMedia = ImageSource.FromStream(() => new MemoryStream(dl_trait));

                                }
                            }




                        }
                    }
                }
                responce.Close();
            }
            catch (WebException er)
            {
                if (er.Status == WebExceptionStatus.ProtocolError)
                {

                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }


        }


    }
}