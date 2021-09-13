using MySqlConnector;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Notes.ViewModels
{

    class ActivityPageView : INotifyPropertyChanged
    {
        private List<Activity> _activity;
        private Activity _selectedActivity;
        private bool _isRefreshing;
        readonly string guild_name = "сердце-греха";
        public List<Activity> Activity_List
        {
            get
            {
                return _activity;
            }
            set
            {
                _activity = value;
                OnPropertyChanged(nameof(Activity_List));
            }
        }
        public Activity SelectedActivity
        {
            get
            {
                return _selectedActivity;
            }
            set
            {
                _selectedActivity = value;

                OnPropertyChanged(nameof(SelectedActivity));
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));




            }
        }


        public ICommand RefreshCommand { get; set; }
        private void Activity_info_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataRow[] rows = activity_table.Select();


            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i]["type"].ToString() == "player")
                {
                    activity.Add(new Activity() { Name = "Персонаж: " + rows[i]["name"].ToString(), Mode = "Достижение: " + rows[i]["mode"].ToString(), Time = relative_time(FromUnixTimeStampToDateTime(rows[i]["time"].ToString())) });


                }
                else if (rows[i]["type"].ToString() == "guild")
                {
                    activity.Add(new Activity() { Name = "Гильдия победила: " + rows[i]["name"].ToString(), Mode = "Режим: " + rows[i]["mode"].ToString(), Time = relative_time(FromUnixTimeStampToDateTime(rows[i]["time"].ToString())) });
                }

            }


            Activity_List = activity;
            //guild_name_label.Content = rows[i]["guild_name"].ToString();
            //guild_master_label.Content = rows[i]["guild_lead"].ToString();
            // Guild_progress_label.Content = rows[i]["guild_raid_progress"].ToString();
            //  last_update_time.Content = "Последнее обновление на сервере в " + rows[i]["last_update"] + "(+4 мск)";
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


        private BackgroundWorker activity_info_worker;
        public ActivityPageView()
        {
            // logs_info_worker = new BackgroundWorker();
            //  logs_info_worker.DoWork += new DoWorkEventHandler(UpdateLogsInfo);
            //  logs_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Logs_info_workerCompleted);
            //  logs_info_worker.RunWorkerAsync();

            activity_table.Clear();
            activity.Clear();
            activity_info_worker = new BackgroundWorker();
            activity_info_worker.DoWork += new DoWorkEventHandler(UpdateActivityInfo);
            activity_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Activity_info_workerCompleted);
            activity_info_worker.RunWorkerAsync();

            RefreshCommand = new Command(CmdRefresh);
        }
        public List<Activity> Activi_List()
        {
            return Activity_List;
        }

        private async void CmdRefresh()
        {
            IsRefreshing = true;
            await Task.Delay(3000);
            IsRefreshing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        DataTable activity_table = new DataTable();
        List<Activity> activity = new List<Activity>();
        public void UpdateActivityInfo(object sender, DoWorkEventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=" + guild_name.Replace("-", "_") + ";CharSet=utf8";
                //Display query  
                string Query = "select * from guild_activity;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                activity_table.Clear();
                MyAdapter.Fill(activity_table);




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show("Сервер обновляет информацию, попробуйте позже");
                // MessageBox.Show(ex.Message);
            }

        }
        public static DateTime FromUnixTimeStampToDateTime(string unixTimeStamp) // конверстация времени
        {

            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(unixTimeStamp) / 1000).LocalDateTime;
        }
    }
}


