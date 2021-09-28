using Newtonsoft.Json;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
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
            GetGuildActivity();


        }

        public void UpdateInfo(object sender, DoWorkEventArgs e)
        {
            activityList = new List<Activity>();
            try
            {

                WebRequest requesta = WebRequest.Create("https://" + App.region + ".api.blizzard.com/data/wow/guild/" + App.realslug + "/" + App.guildslug + "/activity?namespace=profile-" + App.region + "&locale=" + App.localslug + "&access_token=" + App.token);
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
                                        activityList.Add(new Activity() { Name = "Персонаж: " + activity.activities[i].character_achievement.character.name.ToString() + "\nПолучил достижение: " + activity.activities[i].character_achievement.achievement.name.ToString() + "\n" + Functions.relative_time(Functions.FromUnixTimeStampToDateTime(activity.activities[i].timestamp)) });


                                    }
                                    else if (activity.activities[i].activity.type == "ENCOUNTER")
                                    {

                                        activityList.Add(new Activity() { Name = "Гильдия победила: " + activity.activities[i].encounter_completed.encounter.name.ToString() + "\nРежим: " + activity.activities[i].encounter_completed.mode.name.ToString() + "\n" + Functions.relative_time(Functions.FromUnixTimeStampToDateTime(activity.activities[i].timestamp)) });

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
            GetGuildActivity();

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








        public void GetGuildActivity()
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


                    main_info_worker = new BackgroundWorker();
                    main_info_worker.DoWork += new DoWorkEventHandler(UpdateInfo);
                    main_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ActivityView_workerCompleted);
                    main_info_worker.RunWorkerAsync();





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

    }
}