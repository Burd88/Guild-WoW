using SQLite;
using System.Collections.Generic;
namespace Notes.Models
{
    public class Logs
    {
        [PrimaryKey, AutoIncrement]
        public string Dungeon { get; set; }

        public string Date_start { get; set; }


        public string Link { get; set; }
        public string Downloader { get; set; }
        public int ID { get; set; }
    }
    public class Warcraftlogs
    {
        public List<Logs_all> logs { get; set; }

    }
    public class Logs_all
    {

        public string id { get; set; }
        public string title { get; set; }
        public string owner { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public int zone { get; set; }
    }

    public class Logsw
    {


        public string Dungeon { get; set; }

        public string Date_start { get; set; }

        public string Date_end { get; set; }
        public string Link { get; set; }
        public string Downloader { get; set; }
        public int ID { get; set; }
    }
}