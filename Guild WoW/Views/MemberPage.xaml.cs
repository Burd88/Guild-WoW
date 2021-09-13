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
    public partial class MemberPage : ContentPage
    {

        // private Member _selectedMember;
        public MemberPage()
        {

            InitializeComponent();

            UpdateInfo();




        }

        //     protected override void OnAppearing()
        //    {
        //        base.OnAppearing();
        //       UpdateInfo();

        //   }
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the filename as a query parameter.
                Member note = (Member)e.CurrentSelection.FirstOrDefault();

                await Shell.Current.GoToAsync($"{nameof(AllViewPage)}?{nameof(AllViewPage.LoadName)}={note.Name}");

            }
        }






        public TimeSpan getRelativeDateTime(DateTime date)
        {
            TimeSpan ts = DateTime.Now - date;
            return ts;

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

        public void UpdateInfo(object sender, DoWorkEventArgs e)
        {
            if (MembersPage.users != null)
            {
                member = new List<Member>();
                foreach (Member memb in MembersPage.users)
                {

                    if (memb.Active == "true")
                    {
                        member.Add(memb);
                    }


                }
            }




        }

        private BackgroundWorker main_info_worker;
        public void OnUpdateInfo(object sender, EventArgs e)
        {
            UpdateInfo();

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
                MemberView.IsVisible = false;
                ErrorFrame.IsVisible = false;



                main_info_worker = new BackgroundWorker();
                main_info_worker.DoWork += new DoWorkEventHandler(UpdateInfo);
                main_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Member_info_workerCompleted);
                main_info_worker.RunWorkerAsync();



            }
            else
            {
                Updater.IsRunning = false;
                UpdaterGrid.IsVisible = false;
                MemberView.IsVisible = false;
                ErrorFrame.IsVisible = true;

                ErrorName.Text = "Ошибка";
                ErrorText.Text = "Dont guild data";
            }

        }
        List<Member> member = new List<Member>();
        private void Member_info_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //  if (!dontDB)
            //  {

            member.Sort((a, b) => a.Rank.CompareTo(b.Rank));
            Title = "Активных игроков: " + member.Count.ToString();
            MemberView.ItemsSource = member;
            Updater.IsRunning = false;
            UpdaterGrid.IsVisible = false;
            MemberView.IsVisible = true;
            ErrorFrame.IsVisible = false;
            BackgroundImageSource = "background";
            /*   }

               else
               {
                   Updater.IsRunning = false;
                   UpdaterGrid.IsVisible = false;
                   MemberView.IsVisible = false;
                   ErrorFrame.IsVisible = true;

                   ErrorName.Text = "Ошибка";
                   ErrorText.Text = App.textError;
               }*/
        }
        public void Update()
        {
            try
            {
                member = new List<Member>();
                foreach (Member memb in MembersPage.users)
                {

                    if (memb.Active == "true")
                    {
                        member.Add(memb);
                    }
                }

                member.Sort((a, b) => a.Rank.CompareTo(b.Rank));
                Title = "Активных игроков: " + member.Count.ToString();
                MemberView.ItemsSource = member;
                Updater.IsRunning = false;
                UpdaterGrid.IsVisible = false;
                MemberView.IsVisible = true;
                ErrorFrame.IsVisible = false;
                BackgroundImageSource = "background";


            }
            catch (Exception ex)
            {
                Console.WriteLine("EXEPT" + ex.Message);
            }


        }
    }
}