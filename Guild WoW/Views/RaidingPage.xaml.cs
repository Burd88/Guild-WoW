using Newtonsoft.Json;
using Notes.Models;
using System;
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
            Guild_raid_progress();
        }

        public void OnUpdateInfo(object sender, EventArgs e)
        {
            // UpdateInfo();
            Guild_raid_progress();
        }


        private void Guild_raid_progress()
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
                            CNguild_raid_progress.Text = "Рейд прогресс: " + rio_guild.raid_progression.CastleNathria.summary;
                            if (rio_guild.raid_rankings.CastleNathria.mythic.world == 0)
                            {
                                if (rio_guild.raid_rankings.CastleNathria.heroic.world == 0)
                                {
                                    if (rio_guild.raid_rankings.CastleNathria.normal.world == 0)
                                    {
                                        CNguild_rank_name.Text = "Сложность: " + "Обычный";
                                        CNguild_rank_world.Text = "Мир: " + "0";
                                        CNguild_rank_region.Text = "Регион: " + "0";
                                        CNguild_rank_realm.Text = "Сервер: " + "0";

                                    }
                                    else
                                    {
                                        CNguild_rank_name.Text = "Сложность: " + "Обычный";
                                        CNguild_rank_world.Text = "Мир: " + rio_guild.raid_rankings.CastleNathria.normal.world.ToString();
                                        CNguild_rank_region.Text = "Регион: " + rio_guild.raid_rankings.CastleNathria.normal.region.ToString();
                                        CNguild_rank_realm.Text = "Сервер: " + rio_guild.raid_rankings.CastleNathria.normal.realm.ToString();
                                    }


                                }
                                else
                                {
                                    CNguild_rank_name.Text = "Сложность: " + "Героический";
                                    CNguild_rank_world.Text = "Мир: " + rio_guild.raid_rankings.CastleNathria.heroic.world.ToString();
                                    CNguild_rank_region.Text = "Регион: " + rio_guild.raid_rankings.CastleNathria.heroic.region.ToString();
                                    CNguild_rank_realm.Text = "Сервер: " + rio_guild.raid_rankings.CastleNathria.heroic.realm.ToString();
                                }

                            }
                            else
                            {
                                CNguild_rank_name.Text = "Сложность: " + "Мифический";
                                CNguild_rank_world.Text = "Мир: " + rio_guild.raid_rankings.CastleNathria.mythic.world.ToString();
                                CNguild_rank_region.Text = "Регион: " + rio_guild.raid_rankings.CastleNathria.mythic.region.ToString();
                                CNguild_rank_realm.Text = "Сервер: " + rio_guild.raid_rankings.CastleNathria.mythic.realm.ToString();
                            }
                            SODguild_raid_progress.Text = "Рейд прогресс: " + rio_guild.raid_progression.SanctumOfDomination.summary;
                            if (rio_guild.raid_rankings.SanctumOfDomination.mythic.world == 0)
                            {
                                if (rio_guild.raid_rankings.SanctumOfDomination.heroic.world == 0)
                                {
                                    if (rio_guild.raid_rankings.SanctumOfDomination.normal.world == 0)
                                    {
                                        SODguild_rank_name.Text = "Сложность: " + "Обычный";
                                        SODguild_rank_world.Text = "Мир: " + "0";
                                        SODguild_rank_region.Text = "Регион: " + "0";
                                        SODguild_rank_realm.Text = "Сервер: " + "0";

                                    }
                                    else
                                    {
                                        SODguild_rank_name.Text = "Сложность: " + "Обычный";
                                        SODguild_rank_world.Text = "Мир: " + rio_guild.raid_rankings.SanctumOfDomination.normal.world.ToString();
                                        SODguild_rank_region.Text = "Регион: " + rio_guild.raid_rankings.SanctumOfDomination.normal.region.ToString();
                                        SODguild_rank_realm.Text = "Сервер: " + rio_guild.raid_rankings.SanctumOfDomination.normal.realm.ToString();
                                    }


                                }
                                else
                                {
                                    SODguild_rank_name.Text = "Сложность: " + "Героический";
                                    SODguild_rank_world.Text = "Мир: " + rio_guild.raid_rankings.SanctumOfDomination.heroic.world.ToString();
                                    SODguild_rank_region.Text = "Регион: " + rio_guild.raid_rankings.SanctumOfDomination.heroic.region.ToString();
                                    SODguild_rank_realm.Text = "Сервер: " + rio_guild.raid_rankings.SanctumOfDomination.heroic.realm.ToString();
                                }

                            }
                            else
                            {
                                SODguild_rank_name.Text = "Сложность: " + "Мифический";
                                SODguild_rank_world.Text = "Мир: " + rio_guild.raid_rankings.SanctumOfDomination.mythic.world.ToString();
                                SODguild_rank_region.Text = "Регион: " + rio_guild.raid_rankings.SanctumOfDomination.mythic.region.ToString();
                                SODguild_rank_realm.Text = "Сервер: " + rio_guild.raid_rankings.SanctumOfDomination.mythic.realm.ToString();
                            }
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
        }


        /*
        static string guildRaidProgressMythic = "";
        static string guildWorldRankMythic = "";
        static string guildRegionRankMythic = "";
        static string guildRealmRankMythic = "";

        static string guildRaidProgressHeroic = "";
        static string guildWorldRankHeroic = "";
        static string guildRegionRankHeroic = "";
        static string guildRealmRankHeroic = "";

        static string guildRaidProgressNormal = "";
        static string guildWorldRankNormal = "";
        static string guildRegionRankNormal = "";
        static string guildRealmRankNormal = "";
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