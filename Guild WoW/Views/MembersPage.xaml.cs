using Newtonsoft.Json;
using Notes.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Notes.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembersPage : ContentPage
    {
        private BackgroundWorker main_info_worker;
        public static List<Member> users;
        public static List<Member> usersActive;
        string itemLVL = null;
        string spec = null;
        string coven = null;
        string coven_lvl = null;
        string coven_soul = null;
        string last_login = null;
        string raid_progress;
        string mythic_score = "0.0";
        string playing = "false";
        string token;

        public MembersPage()
        {
            InitializeComponent();
            autorizations_battle_net();
        }
        public void OnUpdateInfo(object sender, EventArgs e)
        {

            autorizations_battle_net();
        }
        public async void autorizations_battle_net()
        {
            Updater.IsRunning = true;
            UpdaterGrid.IsVisible = true;
            MembersView.IsVisible = false;
            ErrorFrame.IsVisible = false;
            UpdateButton.IsEnabled = false;


            try
            {

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.ConnectionClose = true;
                    using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), "https://" + App.region + ".battle.net/oauth/token"))
                    {
                        string base64authorization = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("7212d3c0546e45c09fe787e81fb3830c:jLLrZT1MaHzhF8RKZO6vPopxzBjw5rCI"));
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
                        main_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Members_info_workerCompleted);
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
                    MembersView.IsVisible = false;
                    ErrorFrame.IsVisible = true;
                    ErrorName.Text = "Ошибка";
                    ErrorText.Text = "Нет сети/Сервер не доступен.\nПопробуйте позже.";
                }
            }
            catch (Exception e)
            {
                Updater.IsRunning = false;
                UpdaterGrid.IsVisible = false;
                MembersView.IsVisible = false;
                ErrorFrame.IsVisible = true;
                ErrorName.Text = "Ошибка";
                ErrorText.Text = "Нет сети/Сервер не доступен.\nПопробуйте позже.";
                Console.WriteLine(e.Message);
            }


        }
        public void UpdateInfo(object sender, DoWorkEventArgs e)
        {
            users = new List<Member>();

            try
            {


                int i = 0;

                foreach (GuildRosterMain character in App.guildRoster)
                {

                    Character_info(character.Name);


                    if (playing == "true")
                    {
                        users.Add(new Member { Name = character.Name, Rank = character.Rank.ToString(), ClassString = character.Class, Class = "class_" + character.Class, Level = character.Level.ToString(), Spec = "spec_" + spec, Coven = coven, Raid = raid_progress, Myphicscore = mythic_score, Ilevel = itemLVL, InGame = last_login, NameSoul = coven_soul, Coven_lvl = coven_lvl, Active = playing });


                    }
                    i++;

                    try
                    {
                        main_info_worker.ReportProgress(i * 100 / App.guildRoster.Count);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("EXSA" + ex.Message);
                    }

                }

            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Members_info_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            users.Sort((a, b) => a.Rank.CompareTo(b.Rank));

            All_member.ItemsSource = users;
            Title = "Персонажей: " + users.Count;
            Updater.IsRunning = false;
            UpdaterGrid.IsVisible = false;
            MembersView.IsVisible = true;
            ErrorFrame.IsVisible = false;
            BackgroundImageSource = "label_back";
            UpdateButton.IsEnabled = true;

        }
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the filename as a query parameter.
                Member note = (Member)e.CurrentSelection.FirstOrDefault();

                await Shell.Current.GoToAsync($"{nameof(AllViewPage)}?{nameof(AllViewPage.LoadName)}={note.Name}");

            }
        }
        void ProgressUpdater(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                Progress.Text = e.ProgressPercentage.ToString() + "%";
                //ProgressBar.Progress = e.ProgressPercentage;
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXSA" + ex.Message);
            }
            // The progress percentage is a property of e

        }
        private void Character_info(string name)
        {

            try
            {
                WebRequest requestchar = WebRequest.Create("https://" + App.region + ".api.blizzard.com/profile/wow/character/" + App.realslug + "/" + name.ToLower() + "?namespace=profile-" + App.region + "&locale=" + App.localslug + "&access_token=" + token);

                WebResponse responcechar = requestchar.GetResponse();

                using (Stream stream1 = responcechar.GetResponseStream())

                {
                    using (StreamReader reader1 = new StreamReader(stream1))
                    {
                        string line = "";
                        while ((line = reader1.ReadLine()) != null)
                        {
                            Root_charackter_full_info character = JsonConvert.DeserializeObject<Root_charackter_full_info>(line);
                            if (Convert.ToInt32(Functions.getRelativeDateTime(Functions.FromUnixTimeStampToDateTime(character.last_login_timestamp.ToString())).TotalDays) <= 14)
                            {
                                playing = "true";

                                if (character.equipped_item_level.ToString() == "error")
                                {
                                    itemLVL = "0";
                                }
                                else
                                {
                                    itemLVL = character.equipped_item_level.ToString();
                                }


                                spec = character.active_spec.id.ToString();
                                last_login = Functions.relative_time(Functions.FromUnixTimeStampToDateTime(character.last_login_timestamp.ToString()));
                                if (line.Contains("\"covenant_progress\":"))
                                {
                                    coven = "coven_" + character.covenant_progress.chosen_covenant.id.ToString();
                                    coven_lvl = character.covenant_progress.renown_level.ToString();
                                }

                                else
                                {
                                    coven = "0";
                                    coven_lvl = "0";
                                    coven_soul = "нет";

                                }
                                Character_raid_progress(character.name);
                            }
                            else
                            {
                                playing = "false";
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
                    itemLVL = "0";
                    spec = "0";
                    coven = "0";
                    coven_lvl = "0";
                    coven_soul = "нет";
                    last_login = "0";
                }
            }
            catch (Exception e)
            {
                itemLVL = "error";
                spec = "0";
                coven = "0";
                coven_lvl = "0";
                coven_soul = "нет";
                last_login = "0";
                Console.WriteLine(e.Message);
            }
        }
        private void Character_raid_progress(string name)
        {

            try
            {
                WebRequest requestchar = WebRequest.Create("https://raider.io/api/v1/characters/profile?region=" + App.region + "&realm=" + App.realslug + "&name=" + name + "&fields=mythic_plus_scores%2Craid_progression");

                WebResponse responcechar = requestchar.GetResponse();

                using (Stream stream1 = responcechar.GetResponseStream())

                {
                    using (StreamReader reader1 = new StreamReader(stream1))
                    {
                        string line = "";
                        while ((line = reader1.ReadLine()) != null)
                        {
                            RaiderIO_info character = JsonConvert.DeserializeObject<RaiderIO_info>(line);
                            raid_progress = character.raid_progression.CastleNathria.summary;
                            mythic_score = character.mythic_plus_scores.all;
                        }
                    }
                }
                responcechar.Close();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    raid_progress = "0/0";
                    mythic_score = "0.0";
                }
            }
            catch (Exception e)
            {
                raid_progress = "0/0";
                mythic_score = "0.0";
                Console.WriteLine(e.Message);
            }
        }

    }
}