using Xamarin.Forms;

namespace Notes.Models
{
    public class Member
    {
        public string Name { set; get; }
        public string ClassString { set; get; }
        public string Level { get; set; }
        public ImageSource Class { get; set; }
        public ImageSource Spec { get; set; }
        public string Rank { get; set; }
        public string Ilevel { get; set; }
        public string Raid { get; set; }
        public string Myphicscore { get; set; }
        public ImageSource Coven { get; set; }
        public string Coven_lvl { get; set; }
        public string InGame { get; set; }
        public string NameSoul { get; set; }
        public string Conduit { get; set; }
        public string ConduitLVL { get; set; }
        public string TechTalent { get; set; }
        public string Active { get; set; }
    }
}
