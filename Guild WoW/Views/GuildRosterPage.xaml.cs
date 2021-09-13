using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Notes.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuildRosterPage : ContentPage
    {
        private BackgroundWorker main_info_worker;
        public static List<Member> users;


        public GuildRosterPage()
        {
            InitializeComponent();
            autorizations_battle_net();
        }

        public void UpdateInfo(object sender, DoWorkEventArgs e)
        {
            users = new List<Member>();

            try
            {


                int i = 0;

                foreach (GuildRosterMain character in App.guildRoster)
                {
                    users.Add(new Member { Name = character.Name, Rank = character.Rank, Class = character.Class, Level = character.Level.ToString(), ClassString = character.Class });
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
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void OnUpdateInfo(object sender, EventArgs e)
        {

            autorizations_battle_net();
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
        public static DateTime FromUnixTimeStampToDateTime(string unixTimeStamp) // конверстация времени
        {

            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(unixTimeStamp) / 1000).LocalDateTime;
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

        public void autorizations_battle_net()
        {
            Updater.IsRunning = true;
            UpdaterGrid.IsVisible = true;
            MembersView.IsVisible = false;
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


        public TimeSpan getRelativeDateTime(DateTime date)
        {
            TimeSpan ts = DateTime.Now - date;
            return ts;

        }



    }
}