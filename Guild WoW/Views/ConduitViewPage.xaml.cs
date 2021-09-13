using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Notes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(LoadID), nameof(LoadID))]
    public partial class ConduitViewPage : ContentPage
    {

        public string LoadID
        {
            set
            {


                if (value.Contains(","))
                {
                    if (value.Contains("head") || value.Contains("hands") || value.Contains("neck") || value.Contains("waist") || value.Contains("shoulder") || value.Contains("legs") || value.Contains("back") ||
                        value.Contains("feet") || value.Contains("chest") || value.Contains("finger2") || value.Contains("shirt") || value.Contains("finger2") || value.Contains("tabard") || value.Contains("trinket1") ||
                        value.Contains("wrist") || value.Contains("trinket2") || value.Contains("main_hand") || value.Contains("off_hand"))
                    {
                        string[] str = value.Split(new char[] { ',' });
                        insert_discription_item(str[0], str[1]);
                    }
                    else
                    {
                        string[] str = value.Split(new char[] { ',' });
                        insert_discription(str[0], str[1]);
                    }

                }
                else
                {
                    insert_discription(value);
                }

                // LoadMember(value);
            }
        }
        public ConduitViewPage()
        {
            InitializeComponent();
        }

        public void insert_discription(string id)
        {
            //   DataRow[] rows = App.techtalent_table.Select();

            // for (int i = 0; i < rows.Length; i++)
            // {
            //     if (rows[i]["id"].ToString() == id)
            //     {
            //        Name.Text = rows[i]["название"].ToString();
            //         Text.Text = rows[i]["описание"].ToString() + "\n" + rows[i]["cast_time"].ToString();
            //          Title = rows[i]["название"].ToString();
            //         Image.Source = "tesh_talent_" + id;
            //     }
            //  }

        }
        public void insert_discription_item(string slot, string name)
        {
            //DataRow[] rows;//= App.equipinfo.Select();

            // for (int i = 0; i < rows.Length; i++)
            // {

            //      if (rows[i]["name"].ToString() == name)
            //       {

            //       Text.Text = rows[i][slot + "_tooltip"].ToString();
            //       Name.IsVisible = false;
            //       Image.Source = Imagereturn(rows[i][slot + "_id"]);
            //   }
            // }

        }

        public ImageSource Imagereturn(object obj)
        {
            try
            {
                return ImageSource.FromStream(() => new MemoryStream((byte[])obj));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public void insert_discription(string id, string rank)
        {
            // DataRow[] rows = App.conduit_table.Select();

            //  for (int i = 0; i < rows.Length; i++)
            //  {
            //      if (rows[i]["id"].ToString() == id)
            //     {
            //        Name.Text = rows[i]["name"].ToString();
            //        Text.Text = rows[i][rank].ToString() + "\n" + rows[i]["cast_time"].ToString();
            //         Title = rows[i]["name"].ToString();
            //        Image.Source = "counduit_" + id;
            //     }
            // }

        }
    }
}