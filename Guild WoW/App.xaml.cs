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
        public static string token;
        public static string viewMember;
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