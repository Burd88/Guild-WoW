using Notes.Models;
using Xamarin.Forms;
namespace Notes.Views
{
    public class ClassSelector : DataTemplateSelector
    {
        public DataTemplate Paladin { get; set; }
        public DataTemplate Warrior { get; set; }
        public DataTemplate Hunter { get; set; }
        public DataTemplate Rogue { get; set; }
        public DataTemplate Prist { get; set; }
        public DataTemplate DeathKnight { get; set; }
        public DataTemplate Shaman { get; set; }
        public DataTemplate Mage { get; set; }
        public DataTemplate Warlock { get; set; }
        public DataTemplate Monc { get; set; }
        public DataTemplate Druid { get; set; }
        public DataTemplate DemonHunter { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (((Member)item).ClassString == "1")
            {
                return Warrior;
            }
            else if (((Member)item).ClassString == "1")
            {
                return Warrior;
            }
            else if (((Member)item).ClassString == "2")
            {
                return Paladin;
            }
            else if (((Member)item).ClassString == "3")
            {
                return Hunter;
            }
            else if (((Member)item).ClassString == "4")
            {
                return Rogue;
            }
            else if (((Member)item).ClassString == "5")
            {
                return Prist;
            }
            else if (((Member)item).ClassString == "6")
            {
                return DeathKnight;
            }
            else if (((Member)item).ClassString == "7")
            {
                return Shaman;
            }
            else if (((Member)item).ClassString == "8")
            {
                return Mage;
            }
            else if (((Member)item).ClassString == "9")
            {
                return Warlock;
            }
            else if (((Member)item).ClassString == "10")
            {
                return Monc;
            }
            else if (((Member)item).ClassString == "11")
            {
                return Druid;
            }
            else if (((Member)item).ClassString == "12")
            {
                return DemonHunter;
            }

            return Warrior;
        }
    }
}
