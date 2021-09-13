using System;
using Xamarin.Forms;

namespace Notes.Views
{
    [QueryProperty(nameof(LoadName), nameof(LoadName))]
    public partial class ConduitPage : ContentPage
    {
        string _member = "";
        public string LoadName
        {
            set
            {

                _member = value;
                LoadMember(value);
                // LoadMember(value);
            }
        }
        string[] teh_talents = null;
        string[] conduits = null;
        string[] conduits_rank = null;
        public void LoadMember(string member)
        {
            /*
            try
            {
                DataRow[] rows = App.members_table.Select();
                Title = member;
                for (int i = 0; i < rows.Length; i++)
                {

                    if (rows[i]["Имя"].ToString() == member)
                    {



                        #region Tesh Talents
                        teh_talents = rows[i]["Талант"].ToString().Split(new char[] { ',' });


                        if (teh_talents.Length >= 1)
                        {
                            TechTalant4.IsVisible = true;
                            TechTalant1.Source = "tesh_talent_" + teh_talents[0];
                            //teh_talent_1.ToolTip = insert_tech_talent_discription(teh_talents[0]);
                        }
                        else
                        {
                            TechTalant1.IsVisible = false;
                            TechTalant1.Source = null;
                            // teh_talent_1.ToolTip = "Нет описания";
                        }
                        if (teh_talents.Length >= 2)
                        {
                            TechTalant4.IsVisible = true;
                            TechTalant2.Source = "tesh_talent_" + teh_talents[1];
                            //teh_talent_2.ToolTip = insert_tech_talent_discription(teh_talents[1]);
                        }
                        else
                        {
                            TechTalant2.IsVisible = false;
                            TechTalant2.Source = null;
                            //teh_talent_2.ToolTip = "Нет описания";
                        }
                        if (teh_talents.Length >= 3)
                        {
                            TechTalant4.IsVisible = true;
                            TechTalant3.Source = "tesh_talent_" + teh_talents[2];
                            //teh_talent_2.ToolTip = insert_tech_talent_discription(teh_talents[1]);
                        }
                        else
                        {
                            TechTalant3.IsVisible = false;
                            TechTalant3.Source = null;
                            //teh_talent_2.ToolTip = "Нет описания";
                        }
                        if (teh_talents.Length >= 4)
                        {
                            TechTalant4.IsVisible = true;
                            TechTalant4.Source = "tesh_talent_" + teh_talents[3];
                            //teh_talent_2.ToolTip = insert_tech_talent_discription(teh_talents[1]);
                        }
                        else
                        {
                            TechTalant4.IsVisible = false;
                            TechTalant4.Source = null;
                            //teh_talent_2.ToolTip = "Нет описания";
                        }
                        #endregion
                        #region conduits
                        conduits = rows[i]["Проводник"].ToString().Split(new char[] { ',' });
                        conduits_rank = rows[i]["Проводник_ранг"].ToString().Split(new char[] { ',' });

                        if (conduits.Length >= 1)
                        {
                            Conduit1.IsVisible = true;
                            Conduit1.Source = "counduit_" + conduits[0];
                            Conduitlvl1.Text = conduit_rank_ti_ilvl(conduits_rank[0]);
                            // Conduit_1.ToolTip = insert_conduit_discription(conduits[0], conduits_rank[0]);
                        }
                        else
                        {
                            Conduit1.IsVisible = false;
                            Conduit1.Source = null;
                            Conduitlvl1.Text = "";
                            // Conduit_1.ToolTip = "Нет описания";
                        }
                        if (conduits.Length >= 2)
                        {
                            Conduit2.IsVisible = true;
                            Conduit2.Source = "counduit_" + conduits[1];
                            Conduitlvl2.Text = conduit_rank_ti_ilvl(conduits_rank[1]);
                            // Conduit_1.ToolTip = insert_conduit_discription(conduits[0], conduits_rank[0]);
                        }
                        else
                        {
                            Conduit2.IsVisible = false;
                            Conduit2.Source = null;
                            Conduitlvl2.Text = "";
                            // Conduit_1.ToolTip = "Нет описания";
                        }
                        if (conduits.Length >= 3)
                        {
                            Conduit3.IsVisible = true;
                            Conduit3.Source = "counduit_" + conduits[2];
                            Conduitlvl3.Text = conduit_rank_ti_ilvl(conduits_rank[2]);
                            // Conduit_1.ToolTip = insert_conduit_discription(conduits[0], conduits_rank[0]);
                        }
                        else
                        {
                            Conduit3.IsVisible = false;
                            Conduit3.Source = null;
                            Conduitlvl3.Text = "";
                            // Conduit_1.ToolTip = "Нет описания";
                        }
                        if (conduits.Length >= 4)
                        {
                            Conduit4.IsVisible = true;
                            Conduit4.Source = "counduit_" + conduits[3];
                            Conduitlvl4.Text = conduit_rank_ti_ilvl(conduits_rank[3]);
                            // Conduit_1.ToolTip = insert_conduit_discription(conduits[0], conduits_rank[0]);
                        }
                        else
                        {
                            Conduit4.IsVisible = false;
                            Conduit4.Source = null;
                            Conduitlvl4.Text = "";
                            // Conduit_1.ToolTip = "Нет описания";
                        }
                        #endregion
                        Name.Text = rows[i]["Имя_Проводника"].ToString();
                        //Char_info_grid.Visibility = System.Windows.Visibility.Visible;

                    }
                    else
                    {

                    }
                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } */
        }

        async void Conduit1Relesed(object sender, EventArgs e)
        {

            string str = conduits[0] + "," + conduits_rank[0];


            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");


        }
        async void Conduit2Relesed(object sender, EventArgs e)
        {

            string str = conduits[1] + "," + conduits_rank[1];

            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
        }
        async void Conduit3Relesed(object sender, EventArgs e)
        {

            string str = conduits[2] + "," + conduits_rank[2];

            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
        }
        async void Conduit4Relesed(object sender, EventArgs e)
        {
            string str = conduits[3] + "," + conduits_rank[3];

            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
        }
        async void Conduit5Relesed(object sender, EventArgs e)
        {
            string str = conduits[3] + "," + conduits_rank[3];

            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
        }
        async void Conduit6Relesed(object sender, EventArgs e)
        {
            string str = conduits[3] + "," + conduits_rank[3];

            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={str}");
        }
        async void TechTalant1Relesed(object sender, EventArgs e)
        {


            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={teh_talents[0]}");


        }
        async void TechTalant2Relesed(object sender, EventArgs e)
        {



            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={teh_talents[1]}");


        }
        async void TechTalant3Relesed(object sender, EventArgs e)
        {



            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={teh_talents[2]}");


        }
        async void TechTalant4Relesed(object sender, EventArgs e)
        {



            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={teh_talents[3]}");


        }
        async void TechTalant5Relesed(object sender, EventArgs e)
        {



            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={teh_talents[3]}");


        }
        async void TechTalant6Relesed(object sender, EventArgs e)
        {



            await Shell.Current.GoToAsync($"{nameof(ConduitViewPage)}?{nameof(ConduitViewPage.LoadID)}={teh_talents[3]}");


        }
        public ConduitPage()
        {
            InitializeComponent();
        }

        private string conduit_rank_ti_ilvl(string rank)
        {
            string ilvl = null;
            if (rank == "1")
            {
                ilvl = "145";
            }
            else if (rank == "2")
            {
                ilvl = "158";
            }
            else if (rank == "3")
            {
                ilvl = "171";
            }
            else if (rank == "4")
            {
                ilvl = "184";
            }
            else if (rank == "5")
            {
                ilvl = "200";
            }
            else if (rank == "6")
            {
                ilvl = "213";
            }
            else if (rank == "7")
            {
                ilvl = "226";
            }
            else if (rank == "8")
            {
                ilvl = "239";
            }
            else if (rank == "9")
            {
                ilvl = "252";
            }

            return ilvl;
        }



    }
}