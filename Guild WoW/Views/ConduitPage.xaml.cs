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
    [QueryProperty(nameof(LoadName), nameof(LoadName))]
    public partial class ConduitPage : ContentPage
    {
        string _member = "";
        public string LoadName
        {
            set => _member = value;// LoadMember(value);
        }

        #region Button
        async void Conduit1Relesed(object sender, EventArgs e)
        {

            try
            {
                if (conduit1view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={conduit1view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }




        }
        async void Conduit2Relesed(object sender, EventArgs e)
        {

            try
            {
                if (conduit2view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={conduit2view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }

        }
        async void Conduit3Relesed(object sender, EventArgs e)
        {

            try
            {
                if (conduit3view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={conduit3view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }

        }
        async void Conduit4Relesed(object sender, EventArgs e)
        {
            try
            {
                if (conduit4view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={conduit4view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }

        }
        async void Conduit5Relesed(object sender, EventArgs e)
        {
            try
            {
                if (conduit5view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={conduit5view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }

        }
        async void Conduit6Relesed(object sender, EventArgs e)
        {
            try
            {
                if (conduit6view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={conduit6view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }

        }
        async void TechTalant1Relesed(object sender, EventArgs e)
        {
            try
            {
                if (tt1view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={tt1view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }


        }
        async void TechTalant2Relesed(object sender, EventArgs e)
        {
            try
            {
                if (tt2view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={tt2view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }

        }
        async void TechTalant3Relesed(object sender, EventArgs e)
        {

            try
            {
                if (tt3view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={tt3view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }

        }
        async void TechTalant4Relesed(object sender, EventArgs e)
        {
            try
            {
                if (tt4view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={tt4view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        async void TechTalant5Relesed(object sender, EventArgs e)
        {
            try
            {
                if (tt5view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={tt5view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        async void TechTalant6Relesed(object sender, EventArgs e)
        {

            try
            {
                if (tt6view != null)
                {
                    await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={tt6view}");
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        #endregion
        [Obsolete]
        public ConduitPage()
        {
            InitializeComponent();
            GetConduitAllInfo();
        }

        private string GetConduitLevel(string rank)
        {
            string ilvl = null;
            if (rank == "1")
            {
                ilvl = "145";
            }
            else if (rank == "2")
            {
                ilvl = "158";
            }
            else if (rank == "3")
            {
                ilvl = "171";
            }
            else if (rank == "4")
            {
                ilvl = "184";
            }
            else if (rank == "5")
            {
                ilvl = "200";
            }
            else if (rank == "6")
            {
                ilvl = "213";
            }
            else if (rank == "7")
            {
                ilvl = "226";
            }
            else if (rank == "8")
            {
                ilvl = "239";
            }
            else if (rank == "9")
            {
                ilvl = "252";
            }

            return ilvl;
        }




        private BackgroundWorker main_info_worker;

        [Obsolete]
        public void GetConduitAllInfo()
        {

            Updater.IsRunning = true;
            UpdaterGrid.IsVisible = true;
            InfoGrid.IsVisible = false;
            ErrorFrame.IsVisible = false;
            Progress.Text = "0%";


            try
            {


                main_info_worker = new BackgroundWorker();

                main_info_worker.WorkerReportsProgress = true;
                main_info_worker.DoWork += new DoWorkEventHandler(UpdateInfo);
                main_info_worker.ProgressChanged += new ProgressChangedEventHandler(ProgressUpdater);
                main_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Main_info_workerCompleted);
                main_info_worker.RunWorkerAsync();





            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
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
        public void UpdateInfo(object sender, DoWorkEventArgs e)
        {

            GetSoulbindsCharacter();

        }

        [Obsolete]
        private void Main_info_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Name.Text = nameSoul;
            CovenName.Text = covenName;
            CovenName.TextColor = covenColor;
            TechTalant1.Source = trait1;
            TechTalant2.Source = trait2;
            TechTalant3.Source = trait3;
            TechTalant4.Source = trait4;
            TechTalant5.Source = trait5;
            TechTalant6.Source = trait6;

            Conduit1.Source = conduit1;
            Conduitlvl1.Text = conduit1lvl;
            Conduit2.Source = conduit2;
            Conduitlvl2.Text = conduit2lvl;
            Conduit3.Source = conduit3;
            Conduitlvl3.Text = conduit3lvl;
            Conduit4.Source = conduit4;
            Conduitlvl4.Text = conduit4lvl;
            Conduit5.Source = conduit5;
            Conduitlvl5.Text = conduit5lvl;
            Conduit6.Source = conduit6;
            Conduitlvl6.Text = conduit6lvl;

            Updater.IsRunning = false;
            UpdaterGrid.IsVisible = false;
            InfoGrid.IsVisible = true;
            ErrorFrame.IsVisible = false;
            UpdateButton.IsEnabled = true;



        }

        [Obsolete]

        void ProgressUpdater(object sender, ProgressChangedEventArgs e)
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
        ImageSource trait1;
        ImageSource trait2;
        ImageSource trait3;
        ImageSource trait4;
        ImageSource trait5;
        ImageSource trait6;

        string tt1view;
        string tt2view;
        string tt3view;
        string tt4view;
        string tt5view;
        string tt6view;

        ImageSource conduit1;
        ImageSource conduit2;
        ImageSource conduit3;
        ImageSource conduit4;
        ImageSource conduit5;
        ImageSource conduit6;

        string conduit1lvl;
        string conduit2lvl;
        string conduit3lvl;
        string conduit4lvl;
        string conduit5lvl;
        string conduit6lvl;

        string conduit1view;
        string conduit2view;
        string conduit3view;
        string conduit4view;
        string conduit5view;
        string conduit6view;

        string nameSoul;
        string covenName;
        Color covenColor;
        void GetSoulbindsCharacter()
        {
            trait1 = null;
            trait2 = null;
            trait3 = null;
            trait4 = null;
            trait5 = null;
            trait6 = null;

            conduit1 = null;
            conduit2 = null;
            conduit3 = null;
            conduit4 = null;
            conduit5 = null;
            conduit6 = null;

            conduit1lvl = null;
            conduit2lvl = null;
            conduit3lvl = null;
            conduit4lvl = null;
            conduit5lvl = null;
            conduit6lvl = null;


            try
            {
                WebRequest request = WebRequest.Create("https://" + App.region.ToLower() + ".api.blizzard.com/profile/wow/character/" + App.realslug + "/" + App.viewMember.ToLower() + "/soulbinds?namespace=profile-" + App.region.ToLower() + "&locale=" + App.localslug + "&access_token=" + App.token);
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {



                            CharacterSoulbindsAll allSoulbinds = JsonConvert.DeserializeObject<CharacterSoulbindsAll>(line);
                            foreach (SoulbindSoulbinds soulbinds in allSoulbinds.soulbinds)
                            {
                                int i = 0;
                                if (soulbinds.is_active == true)
                                {
                                    nameSoul = soulbinds.soulbind.name;
                                    covenName = allSoulbinds.chosen_covenant.name;
                                    if (allSoulbinds.chosen_covenant.id == 1)
                                    {
                                        covenColor = Color.FromRgb(105, 204, 240);
                                    }
                                    else if (allSoulbinds.chosen_covenant.id == 2)
                                    {

                                        covenColor = Color.FromRgb(196, 31, 59);
                                    }
                                    else if (allSoulbinds.chosen_covenant.id == 3)
                                    {
                                        covenColor = Color.FromRgb(163, 48, 201);
                                    }
                                    else if (allSoulbinds.chosen_covenant.id == 4)
                                    {
                                        covenColor = Color.FromRgb(171, 212, 115);
                                    }

                                    foreach (TraitSoulbinds traits in soulbinds.traits)
                                    {
                                        if (traits.trait != null)
                                        {
                                            if (trait1 == null)
                                            {

                                                tt1view = "TechTalent" + traits.trait.id + "," + App.token;

                                            }
                                            else if (trait2 == null)
                                            {
                                                tt2view = "TechTalent" + traits.trait.id + "," + App.token;
                                            }
                                            else if (trait3 == null)
                                            {
                                                tt3view = "TechTalent" + traits.trait.id + "," + App.token;
                                            }
                                            else if (trait4 == null)
                                            {
                                                tt4view = "TechTalent" + traits.trait.id + "," + App.token;
                                            }
                                            else if (trait5 == null)
                                            {
                                                tt5view = "TechTalent" + traits.trait.id + "," + App.token;
                                            }
                                            else if (trait6 == null)
                                            {
                                                tt6view = "TechTalent" + traits.trait.id + "," + App.token;
                                            }
                                            GetTeshTalentInfo(traits.trait.key.href);


                                        }
                                        else if (traits.conduit_socket != null)
                                        {

                                            GetConduitInfo(traits.conduit_socket.socket.conduit.key.href);
                                            if (conduit1lvl == null)
                                            {


                                                conduit1lvl = GetConduitLevel(traits.conduit_socket.socket.rank.ToString());
                                                conduit1view = "Conduit" + traits.conduit_socket.socket.conduit.id.ToString() + "," + traits.conduit_socket.socket.rank.ToString() + "," + conduit1lvl + "," + App.token;
                                            }
                                            else if (conduit2lvl == null)
                                            {

                                                conduit2lvl = GetConduitLevel(traits.conduit_socket.socket.rank.ToString());
                                                conduit2view = "Conduit" + traits.conduit_socket.socket.conduit.id.ToString() + "," + traits.conduit_socket.socket.rank.ToString() + "," + conduit2lvl + "," + App.token;
                                            }
                                            else if (conduit3lvl == null)
                                            {

                                                conduit3lvl = GetConduitLevel(traits.conduit_socket.socket.rank.ToString());
                                                conduit3view = "Conduit" + traits.conduit_socket.socket.conduit.id.ToString() + "," + traits.conduit_socket.socket.rank.ToString() + "," + conduit3lvl + "," + App.token;
                                            }
                                            else if (conduit4lvl == null)
                                            {

                                                conduit4lvl = GetConduitLevel(traits.conduit_socket.socket.rank.ToString());
                                                conduit4view = "Conduit" + traits.conduit_socket.socket.conduit.id.ToString() + "," + traits.conduit_socket.socket.rank.ToString() + "," + conduit4lvl + "," + App.token;
                                            }
                                            else if (conduit5lvl == null)
                                            {

                                                conduit5lvl = GetConduitLevel(traits.conduit_socket.socket.rank.ToString());
                                                conduit5view = "Conduit" + traits.conduit_socket.socket.conduit.id.ToString() + "," + traits.conduit_socket.socket.rank.ToString() + "," + conduit5lvl + "," + App.token;
                                            }
                                            else if (conduit6lvl == null)
                                            {

                                                conduit6lvl = GetConduitLevel(traits.conduit_socket.socket.rank.ToString());
                                                conduit6view = "Conduit" + traits.conduit_socket.socket.conduit.id.ToString() + "," + traits.conduit_socket.socket.rank.ToString() + "," + conduit6lvl + "," + App.token;
                                            }
                                        }

                                        i++;

                                        try
                                        {
                                            main_info_worker.ReportProgress(i * 100 / soulbinds.traits.Count);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("EXSA" + ex.Message);
                                        }
                                    }
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


        void GetTeshTalentInfo(string link)
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



                            TechTalent techTalent = JsonConvert.DeserializeObject<TechTalent>(line);


                            GetTeshTalentMedia(techTalent.media.key.href);




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

        void GetTeshTalentMedia(string link)
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



                            TechTalentMedia techTalent = JsonConvert.DeserializeObject<TechTalentMedia>(line);

                            foreach (AssetTTMedia asst in techTalent.assets)
                            {
                                if (trait1 == null)
                                {

                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    trait1 = ImageSource.FromStream(() => new MemoryStream(dl_trait));

                                }
                                else if (trait2 == null)
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    trait2 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                }
                                else if (trait3 == null)
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    trait3 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                }
                                else if (trait4 == null)
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    trait4 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                }
                                else if (trait5 == null)
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    trait5 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                }
                                else if (trait6 == null)
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    trait6 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
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

        void GetConduitInfo(string link)
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


                            Conduit conduit = JsonConvert.DeserializeObject<Conduit>(line);


                            GetConduitItem(conduit.item.key.href);




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

        void GetConduitItem(string link)
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



                            GetItem item = JsonConvert.DeserializeObject<GetItem>(line);

                            GetConduitMedia(item.media.key.href);






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

        void GetConduitMedia(string link)
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



                            ItemMedia techTalent = JsonConvert.DeserializeObject<ItemMedia>(line);

                            foreach (AssetItemMedia asst in techTalent.assets)
                            {
                                if (conduit1 == null)
                                {

                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    conduit1 = ImageSource.FromStream(() => new MemoryStream(dl_trait));

                                }
                                else if (conduit2 == null)
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    conduit2 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                }
                                else if (conduit3 == null)
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    conduit3 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                }
                                else if (conduit4 == null)
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    conduit4 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                }
                                else if (conduit5 == null)
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    conduit5 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
                                }
                                else if (conduit6 == null)
                                {
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    conduit6 = ImageSource.FromStream(() => new MemoryStream(dl_trait));
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