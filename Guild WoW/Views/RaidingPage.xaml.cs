using Newtonsoft.Json;
using Notes.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Notes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RaidingPage : ContentPage
    {
        public RaidingPage()
        {
            InitializeComponent();
            GetGuildRaidInfo();
        }
        private BackgroundWorker main_info_worker;
        public void OnUpdateInfo(object sender, EventArgs e)
        {
            // UpdateInfo();
            GetGuildRaidInfo();
        }
        public void GetGuildRaidInfo()
        {
            BackgroundImageSource = "Label_back";
            Updater.IsRunning = true;
            UpdaterGrid.IsVisible = true;
            InfoGrid.IsVisible = false;
            ErrorFrame.IsVisible = false;
            Progress.Text = "0%";


            try
            {



                main_info_worker = new BackgroundWorker();

                main_info_worker.WorkerReportsProgress = true;
                main_info_worker.DoWork += new DoWorkEventHandler(Guild_raid_progress);
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
                    Console.WriteLine(e.Message);
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
        private void Guild_raid_progress(object sender, DoWorkEventArgs e)
        {

            try
            {
                WebRequest requestchar = WebRequest.Create("https://raider.io/api/v1/guilds/profile?region=" + MainGuildPage.guild.Region.ToLower() + "&realm=" + MainGuildPage.guild.RealmSlug + "&name=" + MainGuildPage.guild.GuildSlug.Replace("-", " ") + "&fields=raid_progression%2Craid_rankings");

                WebResponse responcechar = requestchar.GetResponse();

                using (System.IO.Stream stream1 = responcechar.GetResponseStream())

                {
                    using (StreamReader reader1 = new StreamReader(stream1))
                    {
                        string line = "";
                        while ((line = reader1.ReadLine()) != null)
                        {
                            GuildRaiderIO rio_guild = JsonConvert.DeserializeObject<GuildRaiderIO>(line);
                            CNguildraidprogress = "Рейд прогресс: " + rio_guild.raid_progression.CastleNathria.summary;
                            if (rio_guild.raid_rankings.CastleNathria.mythic.world == 0)
                            {
                                if (rio_guild.raid_rankings.CastleNathria.heroic.world == 0)
                                {
                                    if (rio_guild.raid_rankings.CastleNathria.normal.world == 0)
                                    {
                                        CNguildrankname = "Сложность: " + "Обычный";
                                        CNguildrankworld = "Мир: " + "0";
                                        CNguildrankregion = "Регион: " + "0";
                                        CNguildrankrealm = "Сервер: " + "0";

                                    }
                                    else
                                    {
                                        CNguildrankname = "Сложность: " + "Обычный";
                                        CNguildrankworld = "Мир: " + rio_guild.raid_rankings.CastleNathria.normal.world.ToString();
                                        CNguildrankregion = "Регион: " + rio_guild.raid_rankings.CastleNathria.normal.region.ToString();
                                        CNguildrankrealm = "Сервер: " + rio_guild.raid_rankings.CastleNathria.normal.realm.ToString();
                                    }


                                }
                                else
                                {
                                    CNguildrankname = "Сложность: " + "Героический";
                                    CNguildrankworld = "Мир: " + rio_guild.raid_rankings.CastleNathria.heroic.world.ToString();
                                    CNguildrankregion = "Регион: " + rio_guild.raid_rankings.CastleNathria.heroic.region.ToString();
                                    CNguildrankrealm = "Сервер: " + rio_guild.raid_rankings.CastleNathria.heroic.realm.ToString();
                                }

                            }
                            else
                            {
                                CNguildrankname = "Сложность: " + "Мифический";
                                CNguildrankworld = "Мир: " + rio_guild.raid_rankings.CastleNathria.mythic.world.ToString();
                                CNguildrankregion = "Регион: " + rio_guild.raid_rankings.CastleNathria.mythic.region.ToString();
                                CNguildrankrealm = "Сервер: " + rio_guild.raid_rankings.CastleNathria.mythic.realm.ToString();
                            }
                            try
                            {
                                main_info_worker.ReportProgress(50);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("EXSA" + ex.Message);
                            }
                            SODguildraidprogress = "Рейд прогресс: " + rio_guild.raid_progression.SanctumOfDomination.summary;
                            if (rio_guild.raid_rankings.SanctumOfDomination.mythic.world == 0)
                            {
                                if (rio_guild.raid_rankings.SanctumOfDomination.heroic.world == 0)
                                {
                                    if (rio_guild.raid_rankings.SanctumOfDomination.normal.world == 0)
                                    {
                                        SODguildrankname = "Сложность: " + "Обычный";
                                        SODguildrankworld = "Мир: " + "0";
                                        SODguildrankregion = "Регион: " + "0";
                                        SODguildrankrealm = "Сервер: " + "0";

                                    }
                                    else
                                    {
                                        SODguildrankname = "Сложность: " + "Обычный";
                                        SODguildrankworld = "Мир: " + rio_guild.raid_rankings.SanctumOfDomination.normal.world.ToString();
                                        SODguildrankregion = "Регион: " + rio_guild.raid_rankings.SanctumOfDomination.normal.region.ToString();
                                        SODguildrankrealm = "Сервер: " + rio_guild.raid_rankings.SanctumOfDomination.normal.realm.ToString();
                                    }


                                }
                                else
                                {
                                    SODguildrankname = "Сложность: " + "Героический";
                                    SODguildrankworld = "Мир: " + rio_guild.raid_rankings.SanctumOfDomination.heroic.world.ToString();
                                    SODguildrankregion = "Регион: " + rio_guild.raid_rankings.SanctumOfDomination.heroic.region.ToString();
                                    SODguildrankrealm = "Сервер: " + rio_guild.raid_rankings.SanctumOfDomination.heroic.realm.ToString();
                                }

                            }
                            else
                            {
                                SODguildrankname = "Сложность: " + "Мифический";
                                SODguildrankworld = "Мир: " + rio_guild.raid_rankings.SanctumOfDomination.mythic.world.ToString();
                                SODguildrankregion = "Регион: " + rio_guild.raid_rankings.SanctumOfDomination.mythic.region.ToString();
                                SODguildrankrealm = "Сервер: " + rio_guild.raid_rankings.SanctumOfDomination.mythic.realm.ToString();
                            }
                            try
                            {
                                main_info_worker.ReportProgress(100);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("EXSA" + ex.Message);
                            }
                        }
                    }
                }
                responcechar.Close();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {

                    Console.WriteLine("Status Code : {0}", ((HttpWebResponse)ex.Response).StatusCode);
                    Console.WriteLine("Status Description : {0}", ((HttpWebResponse)ex.Response).StatusDescription);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        private void Main_info_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundImageSource = "background";
            Updater.IsRunning = false;
            UpdaterGrid.IsVisible = false;
            InfoGrid.IsVisible = true;
            ErrorFrame.IsVisible = false;
            SODguild_raid_progress.Text = SODguildraidprogress;
            SODguild_rank_name.Text = SODguildrankname;
            SODguild_rank_world.Text = SODguildrankworld;
            SODguild_rank_region.Text = SODguildrankregion;
            SODguild_rank_realm.Text = SODguildrankrealm;

            CNguild_raid_progress.Text = CNguildraidprogress;
            CNguild_rank_name.Text = CNguildrankname;
            CNguild_rank_world.Text = CNguildrankworld;
            CNguild_rank_region.Text = CNguildrankregion;
            CNguild_rank_realm.Text = CNguildrankrealm;




            //UpdateButton.IsEnabled = true;


        }
        string CNguildraidprogress;
        string SODguildraidprogress;
        string CNguildrankname;
        string CNguildrankworld;
        string CNguildrankregion;
        string CNguildrankrealm;
        string SODguildrankname;
        string SODguildrankworld;
        string SODguildrankregion;
        string SODguildrankrealm;

        /*
        private void Guild_raid_progress()
        {

            try
            {
                WebRequest requestchar = WebRequest.Create("https://raider.io/api/v1/guilds/profile?region=" + guild.Region.ToLower() + "&realm=" + guild.RealmSlug + "&name=" + guild.GuildSlug.Replace("-", " ") + "&fields=raid_progression%2Craid_rankings");

                WebResponse responcechar = requestchar.GetResponse();

                using (System.IO.Stream stream1 = responcechar.GetResponseStream())

                {
                    using (StreamReader reader1 = new StreamReader(stream1))
                    {
                        string line = "";
                        while ((line = reader1.ReadLine()) != null)
                        {
                            RaiderIO_guild_info rio_guild = JsonConvert.DeserializeObject<RaiderIO_guild_info>(line);
                            // guildRaidProgress = rio_guild.raid_progression.CastleNathria.summary;
                            guildRaidProgressNormal = rio_guild.raid_progression.CastleNathria.normal_bosses_killed.ToString();
                            guildWorldRankNormal = rio_guild.raid_rankings.CastleNathria.normal.world.ToString();
                            guildRegionRankNormal = rio_guild.raid_rankings.CastleNathria.normal.region.ToString();
                            guildRealmRankNormal = rio_guild.raid_rankings.CastleNathria.normal.realm.ToString();

                            guildRaidProgressHeroic = rio_guild.raid_progression.CastleNathria.heroic_bosses_killed.ToString();
                            guildWorldRankHeroic = rio_guild.raid_rankings.CastleNathria.heroic.world.ToString();
                            guildRegionRankHeroic = rio_guild.raid_rankings.CastleNathria.heroic.region.ToString();
                            guildRealmRankHeroic = rio_guild.raid_rankings.CastleNathria.heroic.realm.ToString();

                            guildRaidProgressMythic = rio_guild.raid_progression.CastleNathria.mythic_bosses_killed.ToString();
                            guildWorldRankMythic = rio_guild.raid_rankings.CastleNathria.mythic.world.ToString();
                            guildRegionRankMythic = rio_guild.raid_rankings.CastleNathria.mythic.region.ToString();
                            guildRealmRankMythic = rio_guild.raid_rankings.CastleNathria.mythic.realm.ToString();

                            //guild_raid_progress.Text = "Рейд прогресс: " + guildRaidProgress;
                           // guild_rank_name.Text = "Сложность: " + guildRankName;
                          //  guild_rank_world.Text = "Мир: " + guildWorldRank;
                          //  guild_rank_region.Text = "Регион: " + guildRegionRank;
                          //  guild_rank_realm.Text = "Сервер: " + guildRealmRank;
                        }
                    }
                }
                responcechar.Close();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {

                    Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                    Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }*/
    }
}