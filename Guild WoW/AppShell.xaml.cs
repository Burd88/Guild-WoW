using Notes.Views;
using Xamarin.Forms;

namespace Notes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ConduitPage), typeof(ConduitPage));
            Routing.RegisterRoute(nameof(ConduitViewPage), typeof(ConduitViewPage));
            Routing.RegisterRoute(nameof(AllViewPage), typeof(AllViewPage));
            Routing.RegisterRoute(nameof(EquipViewPage), typeof(EquipViewPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(EditSettingsPage), typeof(EditSettingsPage));

        }


    }
}