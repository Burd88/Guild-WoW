using Newtonsoft.Json;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Notes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]




    public partial class LogsPage : ContentPage, INotifyPropertyChanged
    {



        public LogsPage()
        {
            InitializeComponent();


            UpdateInfo();
         

        }

      


        public void UpdateInfo(object sender, DoWorkEventArgs e)
        {


            Update_warcraftlogs_data();



        }

        private BackgroundWorker main_info_worker;
        public void OnUpdateInfo(object sender, EventArgs e)
        {
            UpdateInfo();

        }


       
        public void UpdateInfo()
        {
            if (App.guild_name != null)
            {
                BackgroundImageSource = "label_back";
                Updater.IsRunning = true;
                UpdaterGrid.IsVisible = true;
                Logs_Data.IsVisible = false;
                ErrorFrame.IsVisible = false;



                main_info_worker = new BackgroundWorker();
                main_info_worker.DoWork += new DoWorkEventHandler(UpdateInfo);
                main_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Logs_Data_workerCompleted);
                main_info_worker.RunWorkerAsync();


            }
            else
            {
                BackgroundImageSource = "label_back";
                Updater.IsRunning = false;
                UpdaterGrid.IsVisible = false;
                Logs_Data.IsVisible = false;
                ErrorFrame.IsVisible = true;
                ErrorName.Text = "Ошибка";
                ErrorText.Text = "Guild not found, check your settings!";
            }

        }
        List<Logs> logsall;
        public void Logs_Data_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {






            Logs_Data.ItemsSource = logsall;
            Updater.IsRunning = false;
            UpdaterGrid.IsVisible = false;
            Logs_Data.IsVisible = true;
            ErrorFrame.IsVisible = false;
            BackgroundImageSource = "background";

        }

        

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
               
                Logs log = (Logs)e.CurrentSelection.FirstOrDefault();


                await Launcher.OpenAsync(log.Link);
            }
        }

        private void Update_warcraftlogs_data()
        {
            logsall = new List<Logs>();
            try
            {

                WebRequest request = WebRequest.Create("https://www.warcraftlogs.com/v1/reports/guild/" + App.guildslug.Replace("-", " ") + "/" + App.realslug + "/" + App.region.ToLower() + "?api_key=c2c9093c70e642ac6ec003d4b0904c33");
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = reader.ReadToEnd();


                        int index = 1;
                        line = "{ \"logs\": " + line + "}";

                        //  List<Logs> logs_list = new List<Logs>();
                        Warcraftlogs logs = JsonConvert.DeserializeObject<Warcraftlogs>(line);


                        foreach (Logs_all log in logs.logs)
                        {

                            logsall.Add(new Logs() { ID = index, Dungeon = log.title.ToString(), Date_start = Functions.FromUnixTimeStampToDateTime(log.start.ToString()).ToString(), Downloader = log.owner.ToString(), Link = "https://ru.warcraftlogs.com/reports/" + log.id.ToString() });

                           
                        }


                      



                    }
                }
                responce.Close();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    BackgroundImageSource = "label_back";
                    Updater.IsRunning = false;
                    UpdaterGrid.IsVisible = false;
                    Logs_Data.IsVisible = false;
                    ErrorFrame.IsVisible = true;
                    ErrorName.Text = "Ошибка";
                    ErrorText.Text = App.textError;
                }
            }
            catch (Exception e)
            {
                BackgroundImageSource = "label_back";
                Updater.IsRunning = false;
                UpdaterGrid.IsVisible = false;
                Logs_Data.IsVisible = false;
                ErrorFrame.IsVisible = true;
                ErrorName.Text = "Ошибка";
                ErrorText.Text = App.textError;
                Console.WriteLine(e.Message);
            }
        }

    }
}