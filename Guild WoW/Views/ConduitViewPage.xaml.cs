using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using Notes.Models;

using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
namespace Notes.Views
{
    
    [QueryProperty(nameof(LoadID), nameof(LoadID))]
    public partial class ConduitViewPage : ContentPage
    {

        public string LoadID
        {
            set
            {


                if (value.Contains("Conduit"))
                {
                    
                   string settings = value.Replace("Conduit", "");
                    string[] str = settings.Split(new char[] { ',' });
                    
                    GetConduitInfo(str[0], str[1], str[2], str[3]);
                }
                else if (value.Contains("TechTalent"))
                {
                    string settings = value.Replace("TechTalent", "");
                    string[] str = settings.Split(new char[] { ',' });

                    GetTeshTalentInfo(str[0], str[1]);
                }

                // LoadMember(value);
            }
        }
        public ConduitViewPage()
        {
            InitializeComponent();
        }

        void GetTeshTalentInfo(string id, string token)
        {


            try
            {
                WebRequest request = WebRequest.Create("https://"+ App.region.ToLower() +".api.blizzard.com/data/wow/tech-talent/"+ id +"?namespace=static-eu" + "&locale=" + App.localslug + "&access_token=" + token);
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {



                            TechTalent techTalent = JsonConvert.DeserializeObject<TechTalent>(line);
                            Name.Text = techTalent.spell_tooltip.spell.name;
                            Description.Text = techTalent.spell_tooltip.description;
                            Level.Text = "";
                            CastTime.Text = techTalent.spell_tooltip.cast_time;

                            GetTeshTalentMedia(techTalent.media.key.href , token);




                        }
                    }
                }
                responce.Close();
            }
            catch (WebException er)
            {
                if (er.Status == WebExceptionStatus.ProtocolError)
                {

                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }


        }

        void GetTeshTalentMedia(string link, string token)
        {


            WebClient dl = new WebClient();
            try
            {
                WebRequest request = WebRequest.Create(link + "&locale=" + App.localslug + "&access_token=" + token);
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {



                            TechTalentMedia techTalent = JsonConvert.DeserializeObject<TechTalentMedia>(line);

                            foreach (AssetTTMedia asst in techTalent.assets)
                            {


                                byte[] dl_trait;
                                dl_trait = dl.DownloadData(asst.value);
                                Image.Source = ImageSource.FromStream(() => new MemoryStream(dl_trait));

                            }




                        }
                    }
                }
                responce.Close();
            }
            catch (WebException er)
            {
                if (er.Status == WebExceptionStatus.ProtocolError)
                {

                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }


        }

        void GetConduitInfo(string id, string rank, string lvl, string token)
        {


            try
            {
                WebRequest request = WebRequest.Create("https://"+ App.region.ToLower() + ".api.blizzard.com/data/wow/covenant/conduit/"+ id + "?namespace=static-" + App.region.ToLower() + "&locale=" + App.localslug + "&access_token=" + token);
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            

                            Conduit conduit = JsonConvert.DeserializeObject<Conduit>(line);
                            foreach(RankConduit ranks in conduit.ranks)
                            {
                                if (ranks.tier == Convert.ToInt32(rank) - 1)
                                {
                                    Name.Text = ranks.spell_tooltip.spell.name;
                                    Level.Text = lvl;
                                    Description.Text = ranks.spell_tooltip.description;
                                    CastTime.Text = ranks.spell_tooltip.cast_time;
                                    GetConduitItem(conduit.item.key.href , token);
                                }
                            }

                            




                        }
                    }
                }
                responce.Close();
            }
            catch (WebException er)
            {
                if (er.Status == WebExceptionStatus.ProtocolError)
                {

                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }


        }

        void GetConduitItem(string link, string token)
        {



            try
            {
                WebRequest request = WebRequest.Create(link + "&locale=" + App.localslug + "&access_token=" + token);
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {



                            GetItem item = JsonConvert.DeserializeObject<GetItem>(line);

                            GetConduitMedia(item.media.key.href , token);






                        }
                    }
                }
                responce.Close();
            }
            catch (WebException er)
            {
                if (er.Status == WebExceptionStatus.ProtocolError)
                {

                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }
        }

        void GetConduitMedia(string link , string token )
        {


            WebClient dl = new WebClient();
            try
            {
                WebRequest request = WebRequest.Create(link + "&locale=" + App.localslug + "&access_token=" + token);
                WebResponse responce = request.GetResponse();

                using (Stream stream = responce.GetResponseStream())

                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        {



                            ItemMedia techTalent = JsonConvert.DeserializeObject<ItemMedia>(line);

                            foreach (AssetItemMedia asst in techTalent.assets)
                            {
                                
                                    byte[] dl_trait;
                                    dl_trait = dl.DownloadData(asst.value);
                                    Image.Source = ImageSource.FromStream(() => new MemoryStream(dl_trait));

                            }





                        }
                    }
                }
                responce.Close();
            }
            catch (WebException er)
            {
                if (er.Status == WebExceptionStatus.ProtocolError)
                {

                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
            }


        }
    }
}