using Notes.Models;
using System;
using System.IO;
using Xamarin.Forms;
namespace Notes.Views
{

    [QueryProperty(nameof(Loadname), nameof(Loadname))]
    public partial class EquipViewPage : ContentPage
    {
        string _member = "";
        public void OnUpdateInfo(object sender, EventArgs e)
        {
            LoadMember(_member);
        }
        public void OnUpdateInfo()
        {
            LoadMember(_member);
        }
        public string Loadname
        {
            set
            {
                _member = value;
                OnUpdateInfo();


            }
        }


        public void LoadMember(string member)
        {
            /*   try
              {
                  DataRow[] rows = App.equipinfo.Select();
                  Title = member;
                  for (int i = 0; i < rows.Length; i++)
                  {

                      if (rows[i]["name"].ToString() == member)
                      {
                          Equip equip = new Equip
                          {
                              head = Imagereturn(rows[i]["head_id"]),

                              neck = Imagereturn(rows[i]["neck_id"]),
                              shoulders = Imagereturn(rows[i]["shoulder_id"]),
                              shirt = Imagereturn(rows[i]["shirt_id"]),
                              chest = Imagereturn(rows[i]["chest_id"]),
                              waist = Imagereturn(rows[i]["waist_id"]),
                              legs = Imagereturn(rows[i]["legs_id"]),
                              feet = Imagereturn(rows[i]["feet_id"]),
                              wrist = Imagereturn(rows[i]["wrist_id"]),
                              hands = Imagereturn(rows[i]["hands_id"]),
                              finger1 = Imagereturn(rows[i]["finger1_id"]),
                              finger2 = Imagereturn(rows[i]["finger2_id"]),
                              trinket1 = Imagereturn(rows[i]["trinket1_id"]),
                              trinket2 = Imagereturn(rows[i]["trinket2_id"]),
                              back = Imagereturn(rows[i]["back_id"]),
                              main_hand = Imagereturn(rows[i]["main_hand_id"]),
                              off_hands = Imagereturn(rows[i]["off_hand_id"]),
                              tabard = Imagereturn(rows[i]["tabard_id"]),

                          };
                          BindingContext = equip;


                          Main_image.Source = Imagereturn(rows[i]["main_image"]);
                          //  EquipBackground = Imagereturn(rows[i]["neck_id"]));
                      }

                  }
              }
              catch (Exception)
              {
                  Console.WriteLine("Failed to load note.");
              } */
        }

        async void HeadButton(object sender, EventArgs e)
        {
            try
            {
                string str = "head" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void HandsButton(object sender, EventArgs e)
        {
            try
            {
                string str = "hands" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void NeckButton(object sender, EventArgs e)
        {
            try
            {
                string str = "neck" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void WaistButton(object sender, EventArgs e)
        {
            try
            {
                string str = "waist" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void ShoulderButton(object sender, EventArgs e)
        {
            try
            {
                string str = "shoulder" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void LegsButton(object sender, EventArgs e)
        {
            try
            {
                string str = "legs" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void BackButton(object sender, EventArgs e)
        {
            try
            {
                string str = "back" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void FeetButton(object sender, EventArgs e)
        {
            try
            {
                string str = "feet" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void ChestButton(object sender, EventArgs e)
        {
            try
            {
                string str = "chest" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void Finger1Button(object sender, EventArgs e)
        {
            try
            {
                string str = "finger2" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void ShirtButton(object sender, EventArgs e)
        {
            try
            {
                string str = "shirt" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void Finger2Button(object sender, EventArgs e)
        {
            try
            {
                string str = "finger2" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void TabardButton(object sender, EventArgs e)
        {
            try
            {
                string str = "tabard" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void Trinket1Button(object sender, EventArgs e)
        {
            try
            {
                string str = "trinket1" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void WristButton(object sender, EventArgs e)
        {
            try
            {
                string str = "wrist" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void Trinket2Button(object sender, EventArgs e)
        {
            try
            {
                string str = "trinket2" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void MainHandButton(object sender, EventArgs e)
        {
            try
            {
                string str = "main_hand" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
        }
        async void OffHandkButton(object sender, EventArgs e)
        {
            try
            {
                string str = "off_hand" + "," + _member;

                await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!" + ex.Message);
            }
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
        public EquipViewPage()
        {
            InitializeComponent();
            BindingContext = new Equip();

        }
    }
}