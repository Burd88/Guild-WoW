using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    [QueryProperty(nameof(LoadName), nameof(LoadName))]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllViewPage : ContentPage
    {
        string _member = "";
        public string LoadName
        {
            set
            {

                _member = value;
                Title = _member;
                // LoadMember(value);
            }
        }
        public AllViewPage()
        {
            InitializeComponent();
            ErrorFrame.IsVisible = false;
            Fullbutton.IsVisible = true;
            UpdaterGrid.IsVisible = false;
            Updater.IsRunning = false;
        }

        async void OpenConduit(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync($"{nameof(ConduitPage)}?{nameof(ConduitPage.LoadName)}={App.viewMember}");
        }

        async void OpenEquip(object sender, EventArgs e)
        {


            await Shell.Current.GoToAsync($"{nameof(EquipViewPage)}?{nameof(EquipViewPage.Loadname)}={App.viewMember}");


        }

        async void Open_Link_Battlenet(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://worldofwarcraft.com/" + App.localslug.ToLower() + "/character/" + App.region.ToLower() + "/" + App.realslug + "/" + App.viewMember.ToLower());
        }
        async void Open_Link_WowProgress(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://www.wowprogress.com/character/" + App.region.ToLower() + "/" + App.realslug + "/" + App.viewMember.ToLower());
        }
        async void Open_Link_RaiderIO(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://raider.io/characters/" + App.region.ToLower() + "/" + App.realslug + "/" + App.viewMember);
        }
    }
}