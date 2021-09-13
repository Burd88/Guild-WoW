using Newtonsoft.Json;
using Notes.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Color = Xamarin.Forms.Color;

namespace Notes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainGuildPage : ContentPage
    {
        private string dl_emb = null;
        private byte[] emblemByte;
        private int emblemColorGreen = 0;
        private int emblemColorRed = 0;
        private int emblemColorBlue = 0;
        private string guildAchiv;
        private string memberCount;
        private string guildFaction;
        private string realmstatus;
        private string realmId;
        int guildcountMembers = 0;
        string guildLeader = "";
        long guildTimeCreate = 0;
        string guildName = "";
        string token = "";
        public MainGuildPage()
        {
            InitializeComponent();
            LoadNote("1");
        }
        static public Guild guild;


        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                guild = await App.Database.GetNoteAsync(id);


                if (guild != null)
                {
                    App.guildslug = guild.GuildSlug;
                    App.realslug = guild.RealmSlug;
                    App.region = guild.Region.ToLower();
                    App.localslug = guild.LocalSlug;

                    string name = guild.GuildName.ToLower();
                    name = name.Trim();
                    name = name.Replace(" ", "_");

                    App.guild_name = name;
                    InfoGrid.IsVisible = true;
                    AutorizationsBattleNet();



                }
                else
                {

                    InfoGrid.IsVisible = false;
                    ErrorFrame.IsVisible = true;

                    ErrorText.Text = "Need set guild settings";

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }



      

        [Obsolete]
        public void UpdateInfo(object sender, DoWorkEventArgs e)
        {
            GuildUpdateFuncton();
            RealmUpdateFunction();
        }
     

        [Obsolete]
        private void Main_info_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            guild_Name.Text = guildName;
            if (guildFaction == "HORDE")
            {
                guild_Name.TextColor = Color.DarkRed;
            }
            else
            {
                guild_Name.TextColor = Color.Blue;
            }
            guild_leader_name.Text = AppResources.LiderText + guildLeader;

            guild_members_count.Text = AppResources.GuildMemberText + memberCount;
            guild_achiv.Text = AppResources.GuldAchivText + guildAchiv;
            guild_created.Text = AppResources.GuildCreateText + Functions.FromUnixTimeStampToDateTime(guildTimeCreate.ToString()).ToString();
            BackEmblem.Fill = new SolidColorBrush(Color.FromRgb(emblemColorRed, emblemColorGreen, emblemColorBlue));




            Emblem.Source = ImageSource.FromStream(() => new MemoryStream(emblemByte));


            Updater.IsRunning = false;
            UpdaterGrid.IsVisible = false;
            InfoGrid.IsVisible = true;
            ErrorFrame.IsVisible = false;
            UpdateButton.IsEnabled = true;
            RealmNameLabelStart.Text = AppResources.RealStatuslabelText;
            RealmNameLabel.Text = guild.Realm;
            if (realmstatus == "UP")
            {
                RealmImageStatus.Source = "RealmOk";
                RealmStatusLabel.Text = AppResources.RealmStatusUp;
                RealmStatusLabel.TextColor = Color.Green;
            }
            else
            {
                RealmImageStatus.Source = "RealmFalse";
                RealmStatusLabel.TextColor = Color.Red;
            }


        }

        [Obsolete]


        private BackgroundWorker main_info_worker;
        public void OnUpdateInfo(object sender, EventArgs e)
        {

            LoadNote("1");
        }

        async void OnSettings(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync(nameof(SettingsPage));


        }


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


        

        [Obsolete]
        public async void AutorizationsBattleNet()
        {
            Updater.IsRunning = true;
            UpdaterGrid.IsVisible = true;
            InfoGrid.IsVisible = false;
            ErrorFrame.IsVisible = false;
            Progress.Text = "0%";


            try
            {

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.ConnectionClose = true;
                    using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), "https://" + App.region + ".battle.net/oauth/token"))
                    {
                        string base64authorization = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("5adf246bde3d4a41a3792c229a6e425c:sBbit3bF6v0hSUzpPDPJIzy36dZhVwFq"));
                        request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                        request.Content = new StringContent("grant_type=client_credentials");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                        HttpResponseMessage response = await httpClient.SendAsync(request);
                        Token_for_api my_token = JsonConvert.DeserializeObject<Token_for_api>(response.Content.ReadAsStringAsync().Result);

                        token = my_token.access_token;

                        main_info_worker = new BackgroundWorker();

                        main_info_worker.WorkerReportsProgress = true;
                        main_info_worker.DoWork += new DoWorkEventHandler(UpdateInfo);
                        main_info_worker.ProgressChanged += new ProgressChangedEventHandler(ProgressUpdater);
                        main_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Main_info_workerCompleted);
                        main_info_worker.RunWorkerAsync();




                    }

                }

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
        void GuildUpdateFuncton()
        {
            guildcountMembers = 0;
            try
            {
                WebRequest request = WebRequest.Create("https://" + guild.Region.ToLower() + ".api.blizzard.com/data/wow/guild/" + guild.RealmSlug + "/" + guild.GuildSlug + "/roster?namespace=profile-" + guild.Region.ToLower() + "&locale=" + guild.LocalSlug + "&access_token=" + token);
                WebResponse responce = request.GetResponse();
                App.guildRoster = new System.Collections.Generic.List<GuildRosterMain>();
                using (System.IO.Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {



                            MainGuild guild = JsonConvert.DeserializeObject<MainGuild>(line);
                            foreach (Member_guild character in guild.members)
                            {
                                if (character.rank == 0)
                                {
                                    guildLeader = character.character.name;
                                }
                                try
                                {
                                    App.guildRoster.Add(new GuildRosterMain
                                    {
                                        Class = character.character.playable_class.id.ToString(),
                                        Level = character.character.level,
                                        Name = character.character.name,
                                        Race = character.character.playable_race.id.ToString(),
                                        Rank = character.rank.ToString()
                                    });
                                }
                                catch (Exception ecx)
                                {
                                    Console.WriteLine("Чтото не так " + ecx.Message);
                                }


                                guildcountMembers++;


                                try
                                {
                                    main_info_worker.ReportProgress(guildcountMembers * 100 / guild.members.Count);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("EXSA" + ex.Message);
                                }
                            }
                            Guild_emblem_image_load(token);



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

       
        private void Guild_emblem_image_load(string token)
        {

            try
            {
                WebRequest requestchar = WebRequest.Create("https://" + guild.Region.ToLower() + ".api.blizzard.com/data/wow/guild/" + guild.RealmSlug + "/" + guild.GuildSlug + "?namespace=profile-" + guild.Region.ToLower() + "&locale=" + guild.Region.ToLower() + "&access_token=" + token);

                WebResponse responcechar = requestchar.GetResponse();

                using (System.IO.Stream stream1 = responcechar.GetResponseStream())

                {

                    using (StreamReader reader1 = new StreamReader(stream1))
                    {
                        string line = "";

                        while ((line = reader1.ReadLine()) != null)
                        {



                            GuildMain guildmain = JsonConvert.DeserializeObject<GuildMain>(line);

                            guildTimeCreate = guildmain.created_timestamp;
                            WebClient dl = new WebClient();

                            guildName = guildmain.name;
                            if (guildmain.crest.emblem.id.ToString().Length == 1)
                            {
                                dl_emb = "https://render-eu.worldofwarcraft.com/guild/tabards/emblem_0" + guildmain.crest.emblem.id.ToString() + ".png";
                            }
                            else
                            {
                                dl_emb = "https://render-eu.worldofwarcraft.com/guild/tabards/emblem_" + guildmain.crest.emblem.id.ToString() + ".png";
                            }

                            realmId = guildmain.realm.id.ToString();
                            guildAchiv = guildmain.achievement_points.ToString();
                            memberCount = guildmain.member_count.ToString();
                            guildFaction = guildmain.faction.type;

                            emblemColorGreen = guildmain.crest.background.color.rgba.g;
                            emblemColorRed = guildmain.crest.background.color.rgba.r;
                            emblemColorBlue = guildmain.crest.background.color.rgba.b;
                           

                         
                            emblemByte = dl.DownloadData(dl_emb);


                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void RealmUpdateFunction()
        {
            try
            {

                WebRequest request = WebRequest.Create("https://" + guild.Region.ToLower() + ".api.blizzard.com/data/wow/connected-realm/" + realmId + "?namespace=dynamic-" + guild.Region.ToLower() + "&locale=" + guild.LocalSlug + "&access_token=" + token);
                WebResponse responce = request.GetResponse();

                using (System.IO.Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {


                            RealmInfo realm = JsonConvert.DeserializeObject<RealmInfo>(line);

                            realmstatus = realm.status.type;


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