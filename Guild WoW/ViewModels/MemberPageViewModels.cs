using MySqlConnector;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
namespace Notes.ViewModels
{
    class MemberPageViewModels : INotifyPropertyChanged
    {
        private List<User> _member;
        private User _selectedMember;
        private bool _isRefreshing;
        readonly string guild_name = "сердце-греха";
        public List<User> Member_List
        {
            get
            {
                return _member;
            }
            set
            {
                _member = value;
                OnPropertyChanged(nameof(Member_List));
            }
        }
        public User SelectedMember
        {
            get
            {
                return _selectedMember;
            }
            set
            {
                _selectedMember = value;
                // Open_Link_Logs(_selectedLogs.Link);
                OnPropertyChanged(nameof(SelectedMember));
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
        List<User> users = new List<User>();
        /*
        public void MembersUpdate()
        {
            DataRow[] rows = App.members_table.Select();

            users.Clear();
            Member_List.Clear();
            for (int i = 0; i < rows.Length; i++)
            {


                string str_class = rows[i]["Класс"].ToString();
                string str_spec = rows[i]["Спек"].ToString();
                string str_coven = rows[i]["Ковенант"].ToString();
                string last_login_game = null;

                //   if (getRelativeDateTime(FromUnixTimeStampToDateTime(rows[i]["В_игре"].ToString())).TotalDays <= 14)
                //{
                last_login_game = relative_time(FromUnixTimeStampToDateTime(rows[i]["В_игре"].ToString()));//.ToString();
                int item_level;
                if (rows[i]["Илвл"].ToString() == "error")
                {
                    item_level = 0;
                }
                else
                {
                    item_level = Convert.ToInt32(rows[i]["Илвл"].ToString());
                }




                users.Add(new User() { Name = rows[i]["Имя"].ToString(), Level = Convert.ToInt32(rows[i]["Уровень"].ToString()), Class = str_class, Spec = str_spec, Rank = Convert.ToInt32(rows[i]["Ранг"].ToString()), Ilvl = item_level, Raid_progress = rows[i]["Рейд"].ToString(), MythicScore = Convert.ToDouble(rows[i]["RIO"].ToString().Replace(".", ",")), Coven = str_coven, Coven_lvl = Convert.ToInt32(rows[i]["Известность"].ToString()), Coven_soul = last_login_game, link = "Просмотр" });



            }
            users.Sort((a, b) => a.Rank.CompareTo(b.Rank));
            Member_List = users;

        }
        */
        private void Members_workerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataRow[] rows = dTable_members.Select();
            users.Clear();


            for (int i = 0; i < rows.Length; i++)
            {


                string str_class = rows[i]["Класс"].ToString();
                string str_spec = rows[i]["Спек"].ToString();
                string str_coven = rows[i]["Ковенант"].ToString();
                string last_login_game = null;
                if (rows[i]["В_игре"].ToString() != "0")
                {
                    //   if (getRelativeDateTime(FromUnixTimeStampToDateTime(rows[i]["В_игре"].ToString())).TotalDays <= 14)
                    //{
                    last_login_game = relative_time(FromUnixTimeStampToDateTime(rows[i]["В_игре"].ToString()));//.ToString();
                    int item_level;
                    if (rows[i]["Илвл"].ToString() == "error")
                    {
                        item_level = 0;
                    }
                    else
                    {
                        item_level = Convert.ToInt32(rows[i]["Илвл"].ToString());
                    }

                    //BitmapImage bmp_class = ToBitmapImage(Warcraft.Properties.Resources.ResourceManager.GetObject("class_" + str_class) as Bitmap);

                    //BitmapImage bmp_spec = ToBitmapImage(Warcraft.Properties.Resources.ResourceManager.GetObject("spec_" + str_spec) as Bitmap);

                    //BitmapImage bmp_coven = ToBitmapImage(Warcraft.Properties.Resources.ResourceManager.GetObject("coven_" + str_coven) as Bitmap);

                    if (!last_login_game.Contains("Month ago"))
                    {
                        users.Add(new User() { Name = rows[i]["Имя"].ToString(), Level = Convert.ToInt32(rows[i]["Уровень"].ToString()), Class = str_class, Spec = str_spec, Rank = Convert.ToInt32(rows[i]["Ранг"].ToString()), Ilvl = item_level, Raid_progress = rows[i]["Рейд"].ToString(), MythicScore = Convert.ToDouble(rows[i]["RIO"].ToString().Replace(".", ",")), Coven = str_coven, Coven_lvl = Convert.ToInt32(rows[i]["Известность"].ToString()), Coven_soul = last_login_game, link = "Просмотр" });

                    }
                }

                //  }
                else
                {
                    last_login_game = "0";
                }


                //guild_name_label.Content = rows[i]["guild_name"].ToString();
                //guild_master_label.Content = rows[i]["guild_lead"].ToString();
                // Guild_progress_label.Content = rows[i]["guild_raid_progress"].ToString();
                //  last_update_time.Content = "Последнее обновление на сервере в " + rows[i]["last_update"] + "(+4 мск)";


            }
            users.Sort((a, b) => a.Rank.CompareTo(b.Rank));
            Member_List = users;

        }
        // private BackgroundWorker members_worker;
        public MemberPageViewModels()
        {

            // users.Clear();
            // members_worker = new BackgroundWorker();
            // members_worker.DoWork += new DoWorkEventHandler(UpdateMembersInfo);
            // members_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Members_workerCompleted);
            //  members_worker.RunWorkerAsync();
            // MembersUpdate();
            // RefreshCommand = new Command(CmdRefresh);
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
        DataTable dTable_members = new DataTable();

        public void UpdateMembersInfo(object sender, DoWorkEventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=" + guild_name.Replace("-", "_") + ";CharSet=utf8";
                //Display query  
                string Query = "select * from guild_members;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MyConn2.Open();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter
                {
                    SelectCommand = MyCommand2
                };
                dTable_members.Clear();
                MyAdapter.Fill(dTable_members);






                MyConn2.Close();
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

