using MySqlConnector;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace Notes.ViewModels
{
    public class LogsPageViewModels : INotifyPropertyChanged
    {
        private List<Logs> _logs;
        private Logs _selectedLogs;
        private bool _isRefreshing;
        readonly string guild_name = "сердце-греха";
        public List<Logs> Logs_List
        {
            get
            {
                return _logs;
            }
            set
            {
                _logs = value;
                OnPropertyChanged(nameof(Logs_List));
            }
        }
        public Logs SelectedLogs
        {
            get
            {
                return _selectedLogs;
            }
            set
            {
                _selectedLogs = value;
                Open_Link_Logs(_selectedLogs.Link);
                OnPropertyChanged(nameof(SelectedLogs));
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

        async void Open_Link_Logs(string link)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync(link);
        }
        public ICommand RefreshCommand { get; set; }
        private void Logs_info_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataRow[] rows = logs_table.Select();


            for (int i = 0; i < rows.Length; i++)
            {


                logs.Add(new Logs() { ID = Convert.ToInt32(rows[i]["id"]), Dungeon = rows[i]["Dungeon"].ToString(), Date_start = FromUnixTimeStampToDateTime(rows[i]["Date_start"].ToString()).ToString(), Downloader = rows[i]["Downloader"].ToString(), Link = rows[i]["Link"].ToString() });


            }


            Logs_List = logs;
            //guild_name_label.Content = rows[i]["guild_name"].ToString();
            //guild_master_label.Content = rows[i]["guild_lead"].ToString();
            // Guild_progress_label.Content = rows[i]["guild_raid_progress"].ToString();
            //  last_update_time.Content = "Последнее обновление на сервере в " + rows[i]["last_update"] + "(+4 мск)";


        }
        private BackgroundWorker logs_info_worker;
        public LogsPageViewModels()
        {
            // logs_info_worker = new BackgroundWorker();
            //  logs_info_worker.DoWork += new DoWorkEventHandler(UpdateLogsInfo);
            //  logs_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Logs_info_workerCompleted);
            //  logs_info_worker.RunWorkerAsync();

            logs_table.Clear();
            logs.Clear();
            logs_info_worker = new BackgroundWorker();
            logs_info_worker.DoWork += new DoWorkEventHandler(UpdateLogsInfo);
            logs_info_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Logs_info_workerCompleted);
            logs_info_worker.RunWorkerAsync();

            RefreshCommand = new Command(CmdRefresh);
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
        DataTable logs_table = new DataTable();
        List<Logs> logs = new List<Logs>();
        public void UpdateLogsInfo(object sender, DoWorkEventArgs e)
        {
            try
            {
                string MyConnection3 = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=" + guild_name.Replace("-", "_") + ";CharSet=utf8";

                string Query3 = "select * from guild_wow_logs;";
                MySqlConnection MyConn3 = new MySqlConnection(MyConnection3);
                MySqlCommand MyCommand3 = new MySqlCommand(Query3, MyConn3);
                MyConn3.Open();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter
                {
                    SelectCommand = MyCommand3
                };

                MyAdapter.Fill(logs_table);







                MyConn3.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!" + ex.Message);

            }
        }
        public static DateTime FromUnixTimeStampToDateTime(string unixTimeStamp) // конверстация времени
        {

            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(unixTimeStamp) / 1000).LocalDateTime;
        }
    }
}
