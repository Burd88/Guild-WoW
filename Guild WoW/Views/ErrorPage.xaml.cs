
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorPage : ContentPage
    {
        
        public ErrorPage()
        {
            InitializeComponent();
        }

        public ErrorPage(string error, string text)
        {
            InitializeComponent();
            NameError.Text = error;
            TextError.Text = text;
        }


    }
}