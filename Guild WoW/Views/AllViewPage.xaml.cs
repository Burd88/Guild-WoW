using System;
using System.Threading.Tasks;
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
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync($"{nameof(ConduitPage)}?{nameof(ConduitPage.LoadName)}={_member}");
        }

        async void OpenEquip(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            ErrorFrame.IsVisible = false;
            Fullbutton.IsVisible = false;
            UpdaterGrid.IsVisible = true;
            Updater.IsRunning = true;
            await Task.Delay(2000);
            // if (App.UpdateInfoEquip(_member))
            // {

            await Shell.Current.GoToAsync($"{nameof(EquipViewPage)}?{nameof(EquipViewPage.Loadname)}={_member}");
            ErrorFrame.IsVisible = false;
            Fullbutton.IsVisible = true;
            UpdaterGrid.IsVisible = false;
            Updater.IsRunning = false;
            //  }
            //  else
            // {
            //    ErrorFrame.IsVisible = true;
            //     Fullbutton.IsVisible = false;
            //     UpdaterGrid.IsVisible = false;
            //     Updater.IsRunning = false;
            //     ErrorName.Text = "Ошибка";
            //        ErrorText.Text = App.textError;
            //
            //  }

        }

        async void Open_Link_Battlenet(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://worldofwarcraft.com/"+App.localslug.ToLower() + "/character/"+App.region.ToLower() + "/"+ App.realslug +"/" + _member.ToLower());
        }
        async void Open_Link_WowProgress(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://www.wowprogress.com/character/" + App.region.ToLower() + "/" + App.realslug + "/" + _member.ToLower());
        }
        async void Open_Link_RaiderIO(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://raider.io/characters/" + App.region.ToLower() + "/" + App.realslug + "/" + _member);
        }
    }
}