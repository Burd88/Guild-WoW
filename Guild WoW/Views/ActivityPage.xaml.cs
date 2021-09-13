using Newtonsoft.Json;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        public ActivityPage()
        {

            InitializeComponent();
            autorizations_battle_net();


        }

        public void UpdateInfo(object sender, DoWorkEventArgs e)
        {
            activityList = new List<Activity>();
            try
            {

                WebRequest requesta = WebRequest.Create("https://" + App.region + ".api.blizzard.com/data/wow/guild/" + App.realslug + "/" + App.guildslug + "/activity?namespace=profile-" + App.region + "&locale=" + App.localslug + "&access_token=" + token);
                WebResponse responcea = requesta.GetResponse();

                using (Stream stream2 = responcea.GetResponseStream())

                {
                    using (StreamReader reader2 = new StreamReader(stream2))
                    {
                        string line = "";
                        while ((line = reader2.ReadLine()) != null)
                        {



                            ActivityAll activity = JsonConvert.DeserializeObject<ActivityAll>(line);


                            if (activity.activities != null)
                            {
                                for (int i = 0; i < activity.activities.Count; i++)
                                {
                                    if (activity.activities[i].activity.type == "CHARACTER_ACHIEVEMENT")
                                    {
                                        activityList.Add(new Activity() { Name = "Персонаж: " + activity.activities[i].character_achievement.character.name.ToString() + "\nПолучил достижение: " + activity.activities[i].character_achievement.achievement.name.ToString() + "\n" + relative_time(FromUnixTimeStampToDateTime(activity.activities[i].timestamp)) });


                                    }
                                    else if (activity.activities[i].activity.type == "ENCOUNTER")
                                    {

                                        activityList.Add(new Activity() { Name = "Гильдия победила: " + activity.activities[i].encounter_completed.encounter.name.ToString() + "\nРежим: " + activity.activities[i].encounter_completed.mode.name.ToString() + "\n" + relative_time(FromUnixTimeStampToDateTime(activity.activities[i].timestamp)) });

                                    }
                                    try
                                    {
                                        main_info_worker.ReportProgress(i * 100 / activity.activities.Count);
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
                responcea.Close();
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

        private BackgroundWorker main_info_worker;
        public void OnUpdateInfo(object sender, EventArgs e)
        {
            autorizations_battle_net();

        }


        public bool ServerConnect(string url)
        {

            Uri uri = new Uri(url);
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                httpWebRequest.Abort();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public void UpdateInfo()
        {
            if (App.guild_name != null)
            {
                BackgroundImageSource = "label_back";
                Updater.IsRunning = true;
                UpdaterGrid.IsVisible = true;
                ActivityView.IsVisible = false;
                ErrorFrame.IsVisible = false;

                if (ServerConnect("http://185.130.83.244/1.txt"))
                {

                    main_info_worker = new BackgroundWorker();
                    main_info_worker.WorkerReportsProgress = true;
                    main_info_worker.DoWork += new DoWorkEventHandler(UpdateInfo);
                    main_info_worker.ProgressChanged += new ProgressChangedEventHandler(ProgressUpdater);
                    main_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ActivityView_workerCompleted);
                    main_info_worker.RunWorkerAsync();


                }
                else
                {
                    BackgroundImageSource = "label_back";
                    Updater.IsRunning = false;
                    UpdaterGrid.IsVisible = false;
                    ActivityView.IsVisible = false;
                    ErrorFrame.IsVisible = true;
                    ErrorName.Text = "Ошибка";
                    ErrorText.Text = "Нет сети/Сервер не доступен.\nПопробуйте позже.";
                }
            }
            else
            {
                BackgroundImageSource = "label_back";
                Updater.IsRunning = false;
                UpdaterGrid.IsVisible = false;
                ActivityView.IsVisible = false;
                ErrorFrame.IsVisible = true;
                ErrorName.Text = "Ошибка";
                ErrorText.Text = "Dont Guild Data.";
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
        List<Activity> activityList;
        public void ActivityView_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {



            ActivityView.ItemsSource = activityList;
            Updater.IsRunning = false;
            UpdaterGrid.IsVisible = false;
            ActivityView.IsVisible = true;
            ErrorFrame.IsVisible = false;
            BackgroundImageSource = "background";

        }


        private string relative_time(DateTime date)
        {
            TimeSpan ts = DateTime.Now - date;
            if (ts.TotalMinutes < 1)//seconds ago
                return "just now";
            if (ts.TotalHours < 1)//min ago
                return (int)ts.TotalMinutes == 1 ? "1 Minute ago" : (int)ts.TotalMinutes + " Minutes ago";
            if (ts.TotalDays < 1)//hours ago
                return (int)ts.TotalHours == 1 ? "1 Hour ago" : (int)ts.TotalHours + " Hours ago";
            if (ts.TotalDays < 30.4368)//7)//days ago
                return (int)ts.TotalDays == 1 ? "1 Day ago" : (int)ts.TotalDays + " Days ago";
            // if (ts.TotalDays < 30.4368)//weeks ago
            //   return (int)(ts.TotalDays / 7) == 1 ? "1 Week ago" : (int)(ts.TotalDays / 7) + " Weeks ago";
            // if (ts.TotalDays < 365.242)//months ago
            //     return (int)(ts.TotalDays / 30.4368) == 1 ? "1 Month ago" : (int)(ts.TotalDays / 30.4368) + " Months ago";
            //years ago
            return (int)(ts.TotalDays / 365.242) == 1 ? "1 Year ago" : (int)(ts.TotalDays / 365.242) + " Years ago";
        }



        public static DateTime FromUnixTimeStampToDateTime(string unixTimeStamp) // конверстация времени
        {

            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(unixTimeStamp) / 1000).LocalDateTime;
        }
        string token;
        public async void autorizations_battle_net()
        {
            if (App.guild_name != null)
            {
                Updater.IsRunning = true;
                UpdaterGrid.IsVisible = true;
                ActivityView.IsVisible = false;
                ErrorFrame.IsVisible = false;
                BackgroundImageSource = "label_back";


                try
                {

                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.ConnectionClose = true;
                        using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), "https://eu.battle.net/oauth/token"))
                        {
                            string base64authorization = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("919738d00f474ed99c11d78afb43d72b:1jEPRSDu76lZdBq1f01VG20Abifv4Uxu"));
                            request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                            request.Content = new StringContent("grant_type=client_credentials");
                            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                            HttpResponseMessage response = await httpClient.SendAsync(request);
                            Token_for_api my_token = JsonConvert.DeserializeObject<Token_for_api>(response.Content.ReadAsStringAsync().Result);

                            token = my_token.access_token;

                            main_info_worker = new BackgroundWorker();
                            main_info_worker.DoWork += new DoWorkEventHandler(UpdateInfo);
                            main_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ActivityView_workerCompleted);
                            main_info_worker.RunWorkerAsync();




                        }

                    }

                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        BackgroundImageSource = "label_back";
                        Updater.IsRunning = false;
                        UpdaterGrid.IsVisible = false;
                        ActivityView.IsVisible = false;
                        ErrorFrame.IsVisible = true;
                        ErrorName.Text = "Ошибка";
                        ErrorText.Text = "Нет сети/Сервер не доступен.\nПопробуйте позже.";
                    }
                }
                catch (Exception e)
                {
                    BackgroundImageSource = "label_back";
                    Updater.IsRunning = false;
                    UpdaterGrid.IsVisible = false;
                    ActivityView.IsVisible = false;
                    ErrorFrame.IsVisible = true;
                    ErrorName.Text = "Ошибка";
                    ErrorText.Text = "Нет сети/Сервер не доступен.\nПопробуйте позже.";
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                BackgroundImageSource = "label_back";
                Updater.IsRunning = false;
                UpdaterGrid.IsVisible = false;
                ActivityView.IsVisible = false;
                ErrorFrame.IsVisible = true;
                ErrorName.Text = "Ошибка";
                ErrorText.Text = "Guild not found, check your settings!";
            }


        }
        private void Update_guild_activity()
        {
            activityList = new List<Activity>();
            try
            {

                WebRequest requesta = WebRequest.Create("https://" + App.region + ".api.blizzard.com/data/wow/guild/" + App.realslug + "/" + App.guildslug + "/activity?namespace=profile-" + App.region + "&locale=" + App.localslug + "&access_token=" + token);
                WebResponse responcea = requesta.GetResponse();

                using (Stream stream2 = responcea.GetResponseStream())

                {
                    using (StreamReader reader2 = new StreamReader(stream2))
                    {
                        string line = "";
                        while ((line = reader2.ReadLine()) != null)
                        {



                            ActivityAll activity = JsonConvert.DeserializeObject<ActivityAll>(line);


                            if (activity.activities != null)
                            {
                                for (int i = 0; i < activity.activities.Count; i++)
                                {
                                    if (activity.activities[i].character_achievement != null)
                                    {
                                        activityList.Add(new Activity() { Name = "Персонаж: " + activity.activities[i].character_achievement.character.name.ToString() + "\nДостижение: " + activity.activities[i].character_achievement.achievement.name.ToString() + "\n" + relative_time(FromUnixTimeStampToDateTime(activity.activities[i].timestamp)) });


                                    }
                                    else if (activity.activities[i].encounter_completed != null)
                                    {

                                        activityList.Add(new Activity() { Name = "Гильдия: " + activity.activities[i].encounter_completed.encounter.name.ToString() + "\nРежим: " + activity.activities[i].encounter_completed.mode.name.ToString() + "\n" + relative_time(FromUnixTimeStampToDateTime(activity.activities[i].timestamp)) });

                                    }
                                }

                            }


                        }
                    }
                }
                responcea.Close();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}