using Newtonsoft.Json;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemberPage : ContentPage
    {

        // private Member _selectedMember;
        public MemberPage()
        {

            InitializeComponent();
            GetActiveMembers();




        }

        private BackgroundWorker main_info_worker;

        List<Member> member = new List<Member>();



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
        


        public void OnUpdateInfo(object sender, EventArgs e)
        {

            GetActiveMembers();
        }
        public void GetActiveMembers()
        {
            BackgroundImageSource = "Label_back";
            Progress.Text = "0%";
            Updater.IsRunning = true;
            UpdaterGrid.IsVisible = true;
            MemberView.IsVisible = false;
            ErrorFrame.IsVisible = false;
            UpdateButton.IsEnabled = false;


            try
            {



                main_info_worker = new BackgroundWorker();
                main_info_worker.WorkerReportsProgress = true;
                main_info_worker.DoWork += new DoWorkEventHandler(UpdateInfo);
                main_info_worker.ProgressChanged += new ProgressChangedEventHandler(ProgressUpdater);
                main_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Members_info_workerCompleted);
                main_info_worker.RunWorkerAsync();






            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Updater.IsRunning = false;
                    UpdaterGrid.IsVisible = false;
                    MemberView.IsVisible = false;
                    ErrorFrame.IsVisible = true;
                    ErrorName.Text = "Ошибка";
                    ErrorText.Text = "Нет сети/Сервер не доступен.\nПопробуйте позже.";
                }
            }
            catch (Exception e)
            {
                Updater.IsRunning = false;
                UpdaterGrid.IsVisible = false;
                MemberView.IsVisible = false;
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

            MemberView.ItemsSource = users;
            Title = "Персонажей: " + users.Count;
            BackgroundImageSource = "background.png";
            Updater.IsRunning = false;
            UpdaterGrid.IsVisible = false;
            MemberView.IsVisible = true;
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
                App.viewMember = note.Name;
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
                WebRequest requestchar = WebRequest.Create("https://" + App.region + ".api.blizzard.com/profile/wow/character/" + App.realslug + "/" + name.ToLower() + "?namespace=profile-" + App.region + "&locale=" + App.localslug + "&access_token=" + App.token);

                WebResponse responcechar = requestchar.GetResponse();

                using (Stream stream1 = responcechar.GetResponseStream())

                {
                    using (StreamReader reader1 = new StreamReader(stream1))
                    {
                        string line = "";
                        while ((line = reader1.ReadLine()) != null)
                        {
                            Root_charackter_full_info character = JsonConvert.DeserializeObject<Root_charackter_full_info>(line);
                            if (Convert.ToInt32(Functions.getRelativeDateTime(Functions.FromUnixTimeStampToDateTime(character.last_login_timestamp.ToString())).TotalDays) <= 7)
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