using Notes.Data;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
[assembly: ExportFont("MORPHEUS.TTF", Alias = "WoW_Font")]
namespace Notes
{

    public partial class App : Application
    {
        static NoteDatabase database;

        public static string db;
        // Create the database connection as a singleton.
        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {

                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Guild.db3"));

                }

                return database;
            }
        }

        public static string region;
        public static string guildslug;
        public static string realslug;
        public static string localslug;
        public static string realmId;
        public static string lungSlug;
        public static List<GuildRosterMain> guildRoster;
        public static string server_status;
        public static bool isError;
        public static string textError;
        public static string guild_name;
        /*
        public static DataTable main_info;
        public static DataTable logs_table;
        
        public static DataTable members_table;
        public static DataTable activity_table;
        public static DataTable conduit_table;
        public static DataTable techtalent_table;
   
        public static DataRow[] equip_rows;
  
        public static bool UpdateInfo()
        {
            main_info = new DataTable();
            logs_table = new DataTable();
           
            members_table = new DataTable();
            activity_table = new DataTable();
            string Connection = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=" + guild_name + ";CharSet=utf8";
            //Display query  
            string MainQuery = "select * from guild_main_info;";
            string LogsQuery = "select * from guild_wow_logs;";
            string MembersQuery = "select * from guild_members;";
            string ActivityQuery = "select * from guild_activity;";
            //string EquipQuery = "select * from guild_member_equip;";
            string UpdateQuery = "select update_info from main;";
            MySqlConnection Conn = new MySqlConnection(Connection);
            MySqlCommand MainCommand = new MySqlCommand(MainQuery, Conn);
            MySqlCommand MembersCommand = new MySqlCommand(MembersQuery, Conn);
            MySqlCommand ActivityCommand = new MySqlCommand(ActivityQuery, Conn);
            MySqlCommand LogsCommand = new MySqlCommand(LogsQuery, Conn);
            //MySqlCommand EquipCommand = new MySqlCommand(EquipQuery, Conn);
            MySqlCommand UpdateCommand = new MySqlCommand(UpdateQuery, Conn);
            
            // equip_table = new DataTable();
            try
            {
                Conn.Open();

                server_status = UpdateCommand.ExecuteScalar().ToString();
                if (server_status == "false")
                {

                    MySqlDataAdapter MembersAdapter = new MySqlDataAdapter
                    {
                        SelectCommand = MembersCommand
                    };
                    App.members_table.Clear();
                    MembersAdapter.Fill(App.members_table);

                    MySqlDataAdapter MainAdapter = new MySqlDataAdapter
                    {
                        SelectCommand = MainCommand
                    };
                    App.main_info.Clear();

                    MainAdapter.Fill(App.main_info);

                    MySqlDataAdapter ActivityAdapter = new MySqlDataAdapter
                    {
                        SelectCommand = ActivityCommand
                    };
                    App.activity_table.Clear();
                    ActivityAdapter.Fill(App.activity_table);

                    MySqlDataAdapter LogsAdapter = new MySqlDataAdapter
                    {
                        SelectCommand = LogsCommand
                    };
                    App.logs_table.Clear();
                    LogsAdapter.Fill(App.logs_table);

                    


                }



                Conn.Close();
                return true;
                
                
            }
            catch (Exception ex)
            {
              //  Console.WriteLine("Error BD " + ex.Message);
               // isError = true;
                textError = "The server has not updated the data yet or check the guild settings";
                Conn.Close();
                return false;
                
                
            }
            
        }

        public static bool UpdateInfoMain()
        {
            main_info = new DataTable();
           
            string Connection = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=" + guild_name + ";CharSet=utf8";
            //Display query  
            string MainQuery = "select * from guild_main_info;";
           
            string UpdateQuery = "select update_info from main;";
            MySqlConnection Conn = new MySqlConnection(Connection);
            MySqlCommand MainCommand = new MySqlCommand(MainQuery, Conn);
          
            MySqlCommand UpdateCommand = new MySqlCommand(UpdateQuery, Conn);

           
            try
            {
                Conn.Open();

                server_status = UpdateCommand.ExecuteScalar().ToString();
                if (server_status == "false")
                {

                  
                    MySqlDataAdapter MainAdapter = new MySqlDataAdapter
                    {
                        SelectCommand = MainCommand
                    };
                    App.main_info.Clear();

                    MainAdapter.Fill(App.main_info);

              



                }



                Conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                //  Console.WriteLine("Error BD " + ex.Message);
                // isError = true;
                textError = "The server has not updated the data yet for " + guild_name + " or check the guild settings";
                Conn.Close();
                return false;


            }

        }

        public static bool UpdateInfoMembers()
        {
            
            members_table = new DataTable();
          
            string Connection = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=" + guild_name + ";CharSet=utf8";
            //Display query  
            
            string MembersQuery = "select * from guild_members;";
        
            string UpdateQuery = "select update_info from main;";
            MySqlConnection Conn = new MySqlConnection(Connection);
          
            MySqlCommand MembersCommand = new MySqlCommand(MembersQuery, Conn);
           
            MySqlCommand UpdateCommand = new MySqlCommand(UpdateQuery, Conn);

            // equip_table = new DataTable();
            try
            {
                Conn.Open();

                server_status = UpdateCommand.ExecuteScalar().ToString();
                if (server_status == "false")
                {

                    MySqlDataAdapter MembersAdapter = new MySqlDataAdapter
                    {
                        SelectCommand = MembersCommand
                    };
                    App.members_table.Clear();
                    MembersAdapter.Fill(App.members_table);


                }



                Conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                //  Console.WriteLine("Error BD " + ex.Message);
                // isError = true;
                textError = "The server has not updated the data yet for " + guild_name + " or check the guild settings";
                Conn.Close();
                return false;


            }

        }

        public static bool UpdateInfoLogs()
        {
          
            logs_table = new DataTable();

            string Connection = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=" + guild_name + ";CharSet=utf8";
            //Display query  
         
            string LogsQuery = "select * from guild_wow_logs;";
         
            string UpdateQuery = "select update_info from main;";
            MySqlConnection Conn = new MySqlConnection(Connection);
            
            MySqlCommand LogsCommand = new MySqlCommand(LogsQuery, Conn);
          
            MySqlCommand UpdateCommand = new MySqlCommand(UpdateQuery, Conn);

            // equip_table = new DataTable();
            try
            {
                Conn.Open();

                server_status = UpdateCommand.ExecuteScalar().ToString();
                if (server_status == "false")
                {

                 

                    MySqlDataAdapter LogsAdapter = new MySqlDataAdapter
                    {
                        SelectCommand = LogsCommand
                    };
                    App.logs_table.Clear();
                    LogsAdapter.Fill(App.logs_table);




                }



                Conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                //  Console.WriteLine("Error BD " + ex.Message);
                // isError = true;
                textError = "The server has not updated the data yet for " + guild_name + " or check the guild settings";
                Conn.Close();
                return false;


            }

        }
        public static bool UpdateInfoActivity()
        {
            
            activity_table = new DataTable();
            string Connection = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=" + guild_name + ";CharSet=utf8";
            //Display query  
          
            string ActivityQuery = "select * from guild_activity;";
        
            string UpdateQuery = "select update_info from main;";
            MySqlConnection Conn = new MySqlConnection(Connection);
          
            MySqlCommand ActivityCommand = new MySqlCommand(ActivityQuery, Conn);
    
            //MySqlCommand EquipCommand = new MySqlCommand(EquipQuery, Conn);
            MySqlCommand UpdateCommand = new MySqlCommand(UpdateQuery, Conn);

            // equip_table = new DataTable();
            try
            {
                Conn.Open();

                server_status = UpdateCommand.ExecuteScalar().ToString();
                if (server_status == "false")
                {

        

                    MySqlDataAdapter ActivityAdapter = new MySqlDataAdapter
                    {
                        SelectCommand = ActivityCommand
                    };
                    App.activity_table.Clear();
                    ActivityAdapter.Fill(App.activity_table);

               

                }



                Conn.Close();
                return true;


            }
            catch (Exception ex)
            {
                //  Console.WriteLine("Error BD " + ex.Message);
                // isError = true;
                textError = "The server has not updated the data yet for "+ guild_name +" or check the guild settings";
                Conn.Close();
                return false;


            }

        }

        public static void UpdateInfoOther()
        {
            conduit_table = new DataTable();
            techtalent_table = new DataTable();
            try
            {

                string Connection = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=guild_info;CharSet=utf8";
                //Display query  
                string ConduitQuery = "select * from wow_conduit;";
                string TechTalentQuery = "select * from wow_tech_talant;";

                MySqlConnection Conn = new MySqlConnection(Connection);

                MySqlCommand ConduitCommand = new MySqlCommand(ConduitQuery, Conn);
                MySqlCommand TechTalentCommand = new MySqlCommand(TechTalentQuery, Conn);
                Conn.Open();


                MySqlDataAdapter ConduitAdapter = new MySqlDataAdapter
                {
                    SelectCommand = ConduitCommand
                };
                App.conduit_table.Clear();
                ConduitAdapter.Fill(App.conduit_table);

                MySqlDataAdapter TechTalentAdapter = new MySqlDataAdapter
                {
                    SelectCommand = TechTalentCommand
                };
                App.techtalent_table.Clear();
                TechTalentAdapter.Fill(App.techtalent_table);





                Conn.Close();
            }
            catch (Exception ex)
            {
             //   isError = true;
                textError = ex.Message;
            }

        }


        public static DataTable equipinfo;

        public static bool UpdateInfoEquip(string name)
        {

            equipinfo = new DataTable();
            // equip_table = new DataTable();
            try
            {

                string Connection = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=" + guild_name + ";CharSet=utf8";
                //Display query  

                string EquipQuery = "select * from " + name + ";";
                string UpdateQuery = "select update_info from main;";
                MySqlConnection Conn = new MySqlConnection(Connection);

                MySqlCommand EquipCommand = new MySqlCommand(EquipQuery, Conn);
                MySqlCommand UpdateCommand = new MySqlCommand(UpdateQuery, Conn);
                Conn.Open();
                server_status = UpdateCommand.ExecuteScalar().ToString();
                if (server_status == "false")
                {



                    MySqlDataAdapter EquipAdapter = new MySqlDataAdapter
                    {
                        SelectCommand = EquipCommand
                    };
                    equipinfo.Clear();
                    EquipAdapter.Fill(equipinfo);

                    return true;

                }





                Conn.Close();
              //  isError = true;
                textError = "Сервер обновляет данные Гильдии";
                return false;
            }
            catch (Exception ex)
            {

              //  isError = true;
                textError = ex.Message;
                return false;
            }

        }

        public static bool gData;

        */
        public App()
        {
            // Xamarin.Forms.DataGrid.DataGridComponent.Init();
            InitializeComponent();
            // UpdateInfoOther();
            MainPage = new AppShell();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}