using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {


        CultureInfo culture = CultureInfo.CurrentCulture;
        public SettingsPage()
        {
            InitializeComponent();

            //  RegionPicker.SelectedIndexChanged += (sender, args) =>
            //   {
            //   region = RegionPicker.SelectedIndex.ToString();


            //  };
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = await App.Database.GetNoteAsync(1);

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            if (RegionLabel.Text != null)
            {
                AddButton.Text = "Edit";
            }
            else
            {
                AddButton.Text = "Add";
            }
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            if (RegionLabel.Text != null)
            {
                await Shell.Current.GoToAsync($"{nameof(EditSettingsPage)}?{nameof(EditSettingsPage.ItemId)}={"1"}");
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(EditSettingsPage));
            }
            // Navigate to the NoteEntryPage, without passing any data.

        }



        /* private void GuildNameEntryChange(object sender, TextChangedEventArgs e)
         {
             guildname = GuildNameEntry.Text;


         }
         string var;


         async void LoadNote(string itemId)
         {
             try
             {
                 await App.Database.GetNotesAsync();
                 Console.WriteLine("1");
                 int id = Convert.ToInt32(itemId);
                 Console.WriteLine("2");
                 // Retrieve the note and set it as the BindingContext of the page.
                 Guild note = await App.Database.GetNoteAsync(id);
                 Console.WriteLine("3");
                 Console.WriteLine(note.GuildName);
                 Console.WriteLine(note.Region);
                 Console.WriteLine(note.Local);
                 GuildNameEntry.Text = note.GuildName;
                 Console.WriteLine("4");
                 RegionPicker.SelectedIndex = Convert.ToInt32(note.Region);
                 Console.WriteLine("5");
                 Save.Text = note.GuildName;
                 Console.WriteLine("Загрузка данных");
             }
             catch (Exception)
             {

             }
         }

         async void OnSaveButtonClicked(object sender, EventArgs e)
         {

             Guild guild = new Guild();
             guild.Local = culture.Name;
             guild.GuildName = guildname;
             if (!string.IsNullOrWhiteSpace(guild.Region) && !string.IsNullOrWhiteSpace(guild.GuildName))
             {
                 await App.Database.SaveNoteAsync(guild);
             }

             // Navigate backwards
             await Shell.Current.GoToAsync("..");
         }

         async void OnDeleteButtonClicked(object sender, EventArgs e)
         {
             var guild = (Guild)BindingContext;
             await App.Database.DeleteNoteAsync(guild);

             // Navigate backwards
             await Shell.Current.GoToAsync("..");
         }
         public string Loadname
         {
             set
             {
                 LoadNote(value);


             }
         }*/
    }
}