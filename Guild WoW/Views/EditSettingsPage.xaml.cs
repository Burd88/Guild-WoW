using MySqlConnector;
using Newtonsoft.Json;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;
namespace Notes.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class EditSettingsPage : ContentPage
    {


        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }
        List<Locale> LocaleValue;
        List<Realm> Realms;


        public EditSettingsPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Guild();
        }
        string region;
        void OnRegionSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                region = picker.Items[selectedIndex];
                LocaleValue = new List<Locale>();
                if (region == "US")
                {
                    LocaleValue.Add(new Locale { Localization = "English (United States)", LocaleValue = "en_US" });
                    LocaleValue.Add(new Locale { Localization = "Spanish (Mexico)", LocaleValue = "es_MX" });
                    LocaleValue.Add(new Locale { Localization = "Portuguese", LocaleValue = "pt_BR" });
                }
                else if (region == "EU")
                {
                    LocaleValue.Add(new Locale { Localization = "German", LocaleValue = "de_DE" });
                    LocaleValue.Add(new Locale { Localization = "English (Great Britain)", LocaleValue = "en_GB" });
                    LocaleValue.Add(new Locale { Localization = "Spanish (Spain)", LocaleValue = "es_ES" });
                    LocaleValue.Add(new Locale { Localization = "French", LocaleValue = "fr_FR" });
                    LocaleValue.Add(new Locale { Localization = "Italian", LocaleValue = "it_IT" });
                    LocaleValue.Add(new Locale { Localization = "Russian", LocaleValue = "ru_RU" });
                }
                else if (region == "KR")
                {
                    LocaleValue.Add(new Locale { Localization = "Korean", LocaleValue = "ko_KR" });
                }
                else if (region == "TW")
                {
                    LocaleValue.Add(new Locale { Localization = "Chinese (Traditional)", LocaleValue = "zh_TW" });
                }
                else if (region == "CN")
                {
                    LocaleValue.Add(new Locale { Localization = "Chinese (Simplified)", LocaleValue = "zh_CN" });
                }






                LocaleSelect.ItemsSource = LocaleValue;

                LocaleSelect.IsEnabled = true;
            }
        }

        string locale_value;
        string localization;

        void OnLocaleSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            Locale locale = new Locale();
            if (selectedIndex != -1)
            {
                locale = (Locale)picker.ItemsSource[selectedIndex];
                localization = locale.Localization;
                locale_value = locale.LocaleValue;
                RealmSelect.IsEnabled = false;
                autorizations_battle_net();


            }
        }
        string realmName;
        string realmSlug;
        void OnRealmSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            Realm realm = new Realm();
            if (selectedIndex != -1)
            {
                realm = (Realm)picker.ItemsSource[selectedIndex];
                realmName = realm.Name;
                realmSlug = realm.Slug;
                SaveButton.IsEnabled = true;
            }
        }
        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Guild guild = await App.Database.GetNoteAsync(id);

                BindingContext = guild;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }



        private void MainInfoSaveSQL(string region)
        {
            UpdateInfoOther(region);
            DataRow[] rows = guildCheck.Select();
            bool needWrt = true;

            if (rows.Length != 0)
            {
                for (int i = 0; i < rows.Length; i++)
                {

                    if (rows[i]["GuildName"].ToString() == GuildName.Text.Trim().Replace(" ", "-").ToLower() && rows[i]["Realm"].ToString() == realmSlug)
                    {
                        //guild_Name.Text = rows[i]["guild_name"].ToString();
                        needWrt = false;
                        Console.WriteLine("Write not Guild on SB");

                    }
                }
            }
            else
            {
                needWrt = true;
            }

            if (needWrt)
            {

                string connectionString = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=guilds;CharSet=utf8";
                string insert = "INSERT INTO " + region + "(`GuildName`, `Region`, `Realm`, `Locale`) " +
                "VALUES ('" + GuildName.Text.Trim().Replace(" ", "-").ToLower() + "', '" + region.Trim().ToLower() + "', '" + realmSlug + "', '" + locale_value + "')";



                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(insert, databaseConnection);

                commandDatabase.CommandTimeout = 10;

                try
                {
                    databaseConnection.Open();

                    MySqlDataReader myReader = commandDatabase.ExecuteReader();

                    //MessageBox.Show("User succesfully registered");

                    databaseConnection.Close();
                    Console.WriteLine("Write Guild on SB");
                }
                catch (Exception ex)
                {


                    Error.Text = ex.Message;
                }


            }

        }

        DataTable guildCheck;
        private void UpdateInfoOther(string region)
        {
            guildCheck = new DataTable();

            try
            {

                string Connection = "datasource=185.130.83.244;port=3306;username=warcraft;password=Dwqi7mbEziT6jphl;database=guilds;CharSet=utf8";
                //Display query  
                string GuildCheck = "select * from " + region + ";";


                MySqlConnection Conn = new MySqlConnection(Connection);

                MySqlCommand ConduitCommand = new MySqlCommand(GuildCheck, Conn);

                Conn.Open();


                MySqlDataAdapter GuildCheckAdapter = new MySqlDataAdapter
                {
                    SelectCommand = ConduitCommand
                };

                guildCheck.Clear();
                GuildCheckAdapter.Fill(guildCheck);


                //Error.Text = "ok table check";




                Conn.Close();
            }
            catch (Exception ex)
            {
                Error.Text = ex.Message;
                //  isError = true;
                //  textError = ex.Message;
            }

        }
        CultureInfo culture = CultureInfo.CurrentCulture;
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var guild = (Guild)BindingContext;
            guild.Local = localization;
            guild.Realm = realmName;
            guild.Region = region;
            guild.GuildSlug = GuildName.Text.Trim().Replace(" ", "-").ToLower();
            guild.RealmSlug = realmSlug;
            guild.LocalSlug = locale_value;

            if (!string.IsNullOrWhiteSpace(guild.GuildName) || !string.IsNullOrWhiteSpace(guild.Region) || !string.IsNullOrWhiteSpace(guild.Realm))
            {
                await App.Database.SaveNoteAsync(guild);

                //  MainInfoSaveSQL(region.Trim().ToLower());
            }

            // Navigate backwards
            // await Shell.Current.GoToAsync("..");
        }

        public async void autorizations_battle_net()
        {


            try
            {

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.ConnectionClose = true;
                    using (HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), "https://eu.battle.net/oauth/token"))
                    {
                        string base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("4e4c64f795ba43e89c232ecf5f01d4aa:T0AlNaK526jhXT7cEJsNmKCkqwEEqS2A"));
                        request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                        request.Content = new StringContent("grant_type=client_credentials");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                        HttpResponseMessage response = await httpClient.SendAsync(request);
                        Token_for_api my_token = JsonConvert.DeserializeObject<Token_for_api>(response.Content.ReadAsStringAsync().Result);
                        LoadRealmAll(my_token.access_token);






                    }

                }

            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    Error.Text = e.Message.ToString();
                }
            }
            catch (Exception e)
            {
                Error.Text = e.Message.ToString();
            }


        }
        private void LoadRealmAll(string token)
        {

            try
            {
                Realms = new List<Realm>();

                WebRequest requestchar = WebRequest.Create("https://" + region.ToLower().Trim() + ".api.blizzard.com/data/wow/search/realm?namespace=dynamic-" + region.ToLower().Trim() + "&_page=1&_pageSize=1000&locale=" + locale_value + "&access_token=" + token);

                WebResponse responcechar = requestchar.GetResponse();

                using (Stream stream1 = responcechar.GetResponseStream())

                {
                    using (StreamReader reader1 = new StreamReader(stream1))
                    {

                        string line = "";

                        while ((line = reader1.ReadLine()) != null)
                        {

                            line = line.Replace("'", " ");


                            Allrealm_ realms = JsonConvert.DeserializeObject<Allrealm_>(line);

                            foreach (Allrealm_Result realm in realms.results)
                            {
                                if (realm.data.locale == locale_value.Replace("_", ""))
                                {
                                    Dictionary<string, string> name = new Dictionary<string, string>();
                                    name.Add("it_IT", realm.data.name.it_IT);
                                    name.Add("ru_RU", realm.data.name.ru_RU);
                                    name.Add("en_GB", realm.data.name.en_GB);
                                    name.Add("zh_TW", realm.data.name.zh_TW);
                                    name.Add("ko_KR", realm.data.name.ko_KR);
                                    name.Add("en_US", realm.data.name.en_US);
                                    name.Add("es_MX", realm.data.name.es_MX);
                                    name.Add("pt_BR", realm.data.name.pt_BR);
                                    name.Add("es_ES", realm.data.name.es_ES);
                                    name.Add("zh_CN", realm.data.name.zh_CN);
                                    name.Add("fr_FR", realm.data.name.fr_FR);
                                    name.Add("de_DE", realm.data.name.fr_FR);

                                    Realms.Add(new Realm { Name = name[locale_value], Slug = realm.data.slug });

                                }
                                //


                            }

                        }
                    }
                }
                Realms.Sort((a, b) => a.Name.CompareTo(b.Name));
                RealmSelect.ItemsSource = Realms;
                RealmSelect.IsEnabled = true;
            }
            catch (Exception e)
            {
                Error.Text = Error.Text + " add : " + e.Message.ToString();
            }
        }
        private void LoadRealm(string token)
        {

            try
            {
                Realms = new List<Realm>();

                WebRequest requestchar = WebRequest.Create("https://" + region.ToLower().Trim() + ".api.blizzard.com/data/wow/realm/index?namespace=dynamic-" + region.ToLower().Trim() + "&locale=" + locale_value + "&access_token=" + token);

                WebResponse responcechar = requestchar.GetResponse();

                using (Stream stream1 = responcechar.GetResponseStream())

                {
                    using (StreamReader reader1 = new StreamReader(stream1))
                    {

                        string line = "";

                        while ((line = reader1.ReadLine()) != null)
                        {

                            line = line.Replace("'", " ");


                            Root_Realm realms = JsonConvert.DeserializeObject<Root_Realm>(line);

                            foreach (Root_RealmRealm realm in realms.realms)
                            {

                                //Realms.Add(new Realm { Name = realm.name.ToString(), Slug = realm.slug.ToString() });
                                LoadRealmLocal(realm.slug.ToString(), token);

                            }

                        }
                    }
                }
                Realms.Sort((a, b) => a.Name.CompareTo(b.Name));
                RealmSelect.ItemsSource = Realms;
                RealmSelect.IsEnabled = true;
            }
            catch (Exception e)
            {
                Error.Text = Error.Text + " add : " + e.Message.ToString();
            }
        }
        private void LoadRealmLocal(string slug, string token)
        {

            try
            {


                WebRequest requestchar = WebRequest.Create("https://" + region.ToLower().Trim() + ".api.blizzard.com/data/wow/realm/" + slug + "?namespace=dynamic-" + region.ToLower().Trim() + "&locale=" + locale_value + "&access_token=" + token);

                WebResponse responcechar = requestchar.GetResponse();

                using (Stream stream1 = responcechar.GetResponseStream())

                {
                    using (StreamReader reader1 = new StreamReader(stream1))
                    {

                        string line = "";

                        while ((line = reader1.ReadLine()) != null)
                        {

                            line = line.Replace("'", " ");


                            RootRealmlocal realms = JsonConvert.DeserializeObject<RootRealmlocal>(line);

                            if (realms.locale == locale_value.Replace("_", ""))
                            {
                                Realms.Add(new Realm { Name = realms.name, Slug = realms.slug });
                            }


                        }
                    }
                }


            }
            catch (Exception e)
            {
                Error.Text = Error.Text + " add : " + e.Message.ToString();
            }
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Guild)BindingContext;
            await App.Database.DeleteNoteAsync(note);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}