using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gamespot.C_Codes_And_Classes;

namespace Gamespot
{
    public partial class Consoles : System.Web.UI.Page
    {
        /// <summary>
        /// all databases the console pages uses
        /// </summary>
        public Listes adminstration = new Listes();
        public AccountDatabase accountdatabase = new AccountDatabase();
        public AccountList AccountList = new AccountList();
        public GameDatabase gameDatabase = new GameDatabase();
        public NewsDatabase newsDatabase = new NewsDatabase();
        public ReviewDatabase reviewDatabase = new ReviewDatabase();
        public VideoDatabase videoDatabase = new VideoDatabase();

        /// <summary>
        /// public variabeles which are used in multiple events
        /// </summary>
        static Account user = null;
        static string consoleName = "";
        static string RadioGenre = "";
        static string RadioTheme = "";

        //this event is trigged when the page is being loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //get the loggid in user and put it in the local variabele
                user = (Account)Session["globalAccount"];
                //refresh the listes
                refresh();
                //trigger the event to load the games for the console
                Console_DropDownList_SelectedIndexChanged(sender, e);
                //trigger the event to show the first post
                AllPost_ListBox.SelectedIndex = 0;
                AllPost_ListBox_SelectedIndexChanged(sender, e);
                //trigger the event to show the first game
                TopRated_ListBox.SelectedIndex = 0;
                TopRated_ListBox_SelectedIndexChanged(sender, e);
            }
        }

        //this event will load all games which have the same platform as the selected console
        protected void Console_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the console name
            consoleName = Console_DropDownList.Text;
            //refresh the game listes
            refresh();
            //show the earlier selected console
            Console_DropDownList.Text = consoleName;
        }

        //this would let the user follow the account which placed the selected post
        protected void Follow_Button_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('This option is not available yet');</script>");
        }

        //this event will change the page to show all information for the type of post
        protected void AllPost_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(AllPost_ListBox.SelectedItem != null)
            {
                //get the titel of the post
                string postTitel = AllPost_ListBox.SelectedItem.Text;
                //check if the post is of the type news
                    if (AllPost_ListBox.SelectedValue == "News")
                    {
                        //refresh all the controls which will show the news infromation
                        PostRefresh();
                        //show all the controls which are unique for news
                        ShowNews();
                        //get the news
                        News PostNews = newsDatabase.GetNews(postTitel);
                        //show the news information
                        InputTitel_Label.Text = PostNews.Titel;
                        Game NewsGame = gameDatabase.GetGame(PostNews.GameID);
                        Account NewsAccount = accountdatabase.GetBy(PostNews.AccountID);
                        InputName_Label.Text = NewsAccount.UserName;
                        InputDate_Label.Text = PostNews.UploadDate.ToShortDateString();
                        InputGame_Label.Text = NewsGame.GameName + ", " + NewsGame.Platform;
                        Content_TextBox.Text = PostNews.Content;
                        NewsInputRating_Label.Text = Convert.ToString(PostNews.Rating);
                    }
                    //check if the post is of the type review
                    if (AllPost_ListBox.SelectedValue == "Review")
                    {
                        //refresh all the controls which will show the review infromation
                        PostRefresh();
                        //show all the controls which are unique for review
                        ShowReview();
                        //get the review
                        Review PostReview = reviewDatabase.GetReview(postTitel);
                        //show all the review information
                        InputTitel_Label.Text = PostReview.Titel;
                        Game NewsGame = gameDatabase.GetGame(PostReview.GameID);
                        Account NewsAccount = accountdatabase.GetBy(PostReview.AccountID);
                        InputName_Label.Text = NewsAccount.UserName;
                        InputDate_Label.Text = PostReview.UploadDate.ToShortDateString();
                        InputGame_Label.Text = NewsGame.GameName + ", " + NewsGame.Platform;
                        Content_TextBox.Text = PostReview.Content;
                        GoodPoints_TextBox.Text = PostReview.PlusPoint;
                        BadPoints_TextBox.Text = PostReview.MinPoint;
                        ReviewInputRating_Label.Text = Convert.ToString(PostReview.Rating);
                    }
                    //check if the post is of the type video
                    if (AllPost_ListBox.SelectedValue == "Video")
                    {
                        //refresh all the controls which will show the video infromation
                        PostRefresh();
                        //show all the controls which are unique for video
                        ShowVideo();
                        //get the video
                        Video PostVideo = videoDatabase.GetVideo(postTitel);
                        //show the video information
                        InputTitel_Label.Text = PostVideo.Titel;
                        Game NewsGame = gameDatabase.GetGame(PostVideo.GameID);
                        Account NewsAccount = accountdatabase.GetBy(PostVideo.AccountID);
                        InputName_Label.Text = NewsAccount.UserName;
                        InputDate_Label.Text = PostVideo.UploadDate.ToShortDateString();
                        InputGame_Label.Text = NewsGame.GameName + ", " + NewsGame.Platform;
                    }
            }
        }

        //this event will show the information from the game which is selected in the top rated lisbox
        protected void TopRated_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TopRated_ListBox.SelectedItem != null)
            {
                //get the game inforamtion
               int gameID = Convert.ToInt32(TopRated_ListBox.SelectedValue);
                //show the game information
               ShowGameInfo(gameID);
            }
        }

        //this event will show the information from the game which is selected in the coming soon lisbox
        protected void ComingSoon_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComingSoon_ListBox.SelectedItem != null)
            {
                //get the game inforamtion
                int gameID = Convert.ToInt32(ComingSoon_ListBox.SelectedValue);
                //show the game information
                ShowGameInfo(gameID);
            }
        }

        //this event will show the information from the game which is selected in the new release lisbox
        protected void NewReleases_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NewReleases_ListBox.SelectedItem != null)
            {
                //get the game inforamtion
                int gameID = Convert.ToInt32(NewReleases_ListBox.SelectedValue);
                //show the game information
                ShowGameInfo(gameID);
            }
        }

        //this event will show the information from the game which is selected in the all games lisbox
        protected void AllGames_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AllGames_ListBox.SelectedItem != null)
            {
                //get the game inforamtion
                int gameID = Convert.ToInt32(AllGames_ListBox.SelectedValue);
                //show the game information
                ShowGameInfo(gameID);
            }
        }

        //this event will add the selected game to the wantlist
        protected void TopWant_Button_Click(object sender, EventArgs e)
        {
            if (TopRated_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(TopRated_ListBox.SelectedValue);
                Game games = gameDatabase.GetGame(gameID);
                //check if it exist in the have list
                if (AccountList.GetHave(user.ID, games.ID) == null)
                {
                    //check if it exist in the want list
                    if (AccountList.GetWant(user.ID, games.ID) == null)
                    {
                        //if not add it to the want list
                        AccountList.AddToWant(user.ID, games.ID);
                    }
                    else
                    {
                        //if it exist in the want list show error
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your want list');</script>");
                    }
                }
                else
                {
                    //if it exist in the have list show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your have list, you cant have the game in both listes');</script>");
                }
            }
        }

        protected void TopHave_Button_Click(object sender, EventArgs e)
        {
            if (TopRated_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(TopRated_ListBox.SelectedValue);
                Game games = gameDatabase.GetGame(gameID);
                //check if it exist in the want list
                if (AccountList.GetWant(user.ID, games.ID) == null)
                {
                    //check if it exist in the have list
                    if (AccountList.GetHave(user.ID, games.ID) == null)
                    {
                        //if not add it to the have list
                        AccountList.AddToHave(user.ID, games.ID);
                    }
                    else
                    {
                        //if it exist in the have list show error
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your have list');</script>");
                    }
                }
                else
                {
                    //if it exist in the want list show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your want list, you cant have the game in both listes');</script>");
                }
            }
        }

        //this event will add the selected game to the wantlist
        protected void ComingWant_Button_Click(object sender, EventArgs e)
        {
            if (ComingSoon_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(ComingSoon_ListBox.SelectedValue);
                Game games = gameDatabase.GetGame(gameID);
                //check if it exist in the have list
                if (AccountList.GetHave(user.ID, games.ID) == null)
                {
                    //check if it exist in the want list
                    if (AccountList.GetWant(user.ID, games.ID) == null)
                    {
                        //if not add it to the want list
                        AccountList.AddToWant(user.ID, games.ID);
                    }
                    else
                    {
                        //if it exist in the want list show error
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your want list');</script>");
                    }
                }
                else
                {
                    //if it exist in the have list show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your have list, you cant have the game in both listes');</script>");
                }
            }
        }

        protected void ComingHave_Button_Click(object sender, EventArgs e)
        {
            if (ComingSoon_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(ComingSoon_ListBox.SelectedValue);
                Game games = gameDatabase.GetGame(gameID);
                //check if it exist in the want list
                if (AccountList.GetWant(user.ID, games.ID) == null)
                {
                    //check if it exist in the have list
                    if (AccountList.GetHave(user.ID, games.ID) == null)
                    {
                        //if not add it to the have list
                        AccountList.AddToHave(user.ID, games.ID);
                    }
                    else
                    {
                        //if it exist in the have list show error
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your have list');</script>");
                    }
                }
                else
                {
                    //if it exist in the want list show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your want list, you cant have the game in both listes');</script>");
                }
            }
        }

        //this event will add the selected game to the wantlist
        protected void ReleaseWant_Button_Click(object sender, EventArgs e)
        {
            if (NewReleases_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(NewReleases_ListBox.SelectedValue);
                Game games = gameDatabase.GetGame(gameID);
                //check if it exist in the have list
                if (AccountList.GetHave(user.ID, games.ID) == null)
                {
                    //check if it exist in the want list
                    if (AccountList.GetWant(user.ID, games.ID) == null)
                    {
                        //if not add it to the want list
                        AccountList.AddToWant(user.ID, games.ID);
                    }
                    else
                    {
                        //if it exist in the want list show error
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your want list');</script>");
                    }
                }
                else
                {
                    //if it exist in the have list show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your have list, you cant have the game in both listes');</script>");
                }
            }
        }

        protected void ReleaseHave_Button_Click(object sender, EventArgs e)
        {
            if (NewReleases_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(NewReleases_ListBox.SelectedValue);
                Game games = gameDatabase.GetGame(gameID);
                //check if it exist in the want list
                if (AccountList.GetWant(user.ID, games.ID) == null)
                {
                    //check if it exist in the have list
                    if (AccountList.GetHave(user.ID, games.ID) == null)
                    {
                        //if not add it to the have list
                        AccountList.AddToHave(user.ID, games.ID);
                    }
                    else
                    {
                        //if it exist in the have list show error
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your have list');</script>");
                    }
                }
                else
                {
                    //if it exist in the want list show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your want list, you cant have the game in both listes');</script>");
                }
            }
        }

        //this event will add the selected game to the wantlist
        protected void AllWant_Button_Click(object sender, EventArgs e)
        {
            if (AllGames_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(AllGames_ListBox.SelectedValue);
                Game games = gameDatabase.GetGame(gameID);
                //check if it exist in the have list
                if (AccountList.GetHave(user.ID, games.ID) == null)
                {
                    //check if it exist in the want list
                    if (AccountList.GetWant(user.ID, games.ID) == null)
                    {
                        //if not add it to the want list
                        AccountList.AddToWant(user.ID, games.ID);
                    }
                    else
                    {
                        //if it exist in the want list show error
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your want list');</script>");
                    }
                }
                else
                {
                    //if it exist in the have list show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your have list, you cant have the game in both listes');</script>");
                }
            }
        }

        protected void AllHave_Button_Click(object sender, EventArgs e)
        {
            if (AllGames_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(AllGames_ListBox.SelectedValue);
                Game games = gameDatabase.GetGame(gameID);
                //check if it exist in the want list
                if (AccountList.GetWant(user.ID, games.ID) == null)
                {
                    //check if it exist in the have list
                    if (AccountList.GetHave(user.ID, games.ID) == null)
                    {
                        //if not add it to the have list
                        AccountList.AddToHave(user.ID, games.ID);
                    }
                    else
                    {
                        //if it exist in the have list show error
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your have list');</script>");
                    }
                }
                else
                {
                    //if it exist in the want list show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You already have the game in your want list, you cant have the game in both listes');</script>");
                }
            }
        }

        //this event will load all the games for the console with the selected genre
        protected void Genre_RadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear the all games listbox
            AllGames_ListBox.Items.Clear();
            //get the selected genre
            RadioGenre = Genre_RadioButtonList.SelectedValue;
            //get a list with the games
            List<Game> SearchGames = null;
            //check if a theme is also selected
            if(RadioTheme =="")
            {
                //if not only search for the games with the console and genre
                SearchGames = gameDatabase.GenreGames(RadioGenre, consoleName);
            }
            else
            {
                //else search for the games with the console, genre and theme
                SearchGames = gameDatabase.GenreAndThemeGames(RadioGenre, RadioTheme, consoleName);
            }
            //fill the all games list with the found games
            foreach (Game g in SearchGames)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                //add the game with its name and platform and as value its ID
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                AllGames_ListBox.Items.Add(dataItem);
            }
        }

        //this event will load all the games for the console with the selected theme
        protected void Theme_RadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear the all games listbox
            AllGames_ListBox.Items.Clear();
            //get the selected theme
            RadioTheme = Theme_RadioButtonList.SelectedValue;
            //get a list with the games
            List<Game> SearchGames = null;
            //check if a genre is also selected
            if(RadioGenre =="")
            {
                //if not only search for the games with the console and theme
                SearchGames = gameDatabase.ThemeGames(RadioTheme, consoleName);
            }
            else
            {
                //else search for the games with the console, genre and theme
                SearchGames = gameDatabase.GenreAndThemeGames(RadioGenre, RadioTheme, consoleName);
            }
            //fill the all games list with the found games
            foreach (Game g in SearchGames)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                //add the game with its name and platform and as value its ID
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                AllGames_ListBox.Items.Add(dataItem);
            }
        }

        //this method will show all the information of a game
        private void ShowGameInfo(int gameID)
        {
            Game selected = gameDatabase.GetGame(gameID);
            if (selected != null)
            {
                Game_Name_Label.Text = selected.GameName;
                Platform_Label.Text = selected.Platform;
                Genre_Label.Text = selected.GenreName;
                Thema_Label.Text = selected.ThemeName;
                FirstRelease_Label.Text = selected.FirstRelease.ToShortDateString();
                Rating_Label.Text = Convert.ToString(selected.Rating);
                Description_TextBox.Text = selected.Description;
                Publisher_Label.Text = selected.Publisher;
                Designer_Label.Text = selected.Designer;
            }
        }

        //this will refresh all post controls and hide the special controls for each type of post
        public void PostRefresh()
        {
            Content_TextBox.Visible = false;
            NewsRating_Label.Visible = false;
            NewsInputRating_Label.Visible = false;
            GoodPoints_TextBox.Visible = false;
            BadPoints_TextBox.Visible = false;
            ReviewRating_Label.Visible = false;
            ReviewInputRating_Label.Visible = false;

            InputTitel_Label.Text = "";
            InputName_Label.Text = "";
            InputDate_Label.Text = "";
            InputGame_Label.Text = "";
            Content_TextBox.Text = "";
            GoodPoints_TextBox.Text = "";
            BadPoints_TextBox.Text = "";
        }

        //this method will show the controls unique to a news post
        public void ShowNews()
        {
            Content_TextBox.Visible = true;
            NewsRating_Label.Visible = true;
            NewsInputRating_Label.Visible = true;
        }

        //this method will show the controls unique to a review post
        public void ShowReview()
        {
            Content_TextBox.Visible = true;
            GoodPoints_TextBox.Visible = true;
            BadPoints_TextBox.Visible = true;
            ReviewRating_Label.Visible = true;
            ReviewInputRating_Label.Visible = true;
        }

        //this method will show the controls unique to a video post
        public void ShowVideo()
        {

        }

        //this method will refresh all the listes
        private void refresh()
        {
            //clear all the listboxen
            Console_DropDownList.Items.Clear();
            AllPost_ListBox.Items.Clear();
            TopRated_ListBox.Items.Clear();
            ComingSoon_ListBox.Items.Clear();
            NewReleases_ListBox.Items.Clear();
            AllGames_ListBox.Items.Clear();
            Genre_RadioButtonList.Items.Clear();
            Theme_RadioButtonList.Items.Clear();

            //refresh the listes in the listes class
            adminstration.refreshAll();

            //add all 
            foreach (Post p in adminstration.postes)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                //check if the post is an News type
                if (p.GetType() == typeof(News))
                {
                    dataItem.Text = p.Titel;
                    dataItem.Value = "News";
                    //add the news with it titel an news as value
                    AllPost_ListBox.Items.Add(dataItem);
                }
                //check if the post is an Review type
                if (p.GetType() == typeof(Review))
                {
                    dataItem.Text = p.Titel;
                    dataItem.Value = "Review";
                    //add the review with it titel an review as value
                    AllPost_ListBox.Items.Add(dataItem);
                }
                //check if the post is an Video type
                if (p.GetType() == typeof(Video))
                {
                    dataItem.Text = p.Titel;
                    dataItem.Value = "Video";
                    //add the video with it titel an video as value
                    AllPost_ListBox.Items.Add(dataItem);
                }
            }

            //add all consoles to the listes
            foreach (C_Codes_And_Classes.Console c in adminstration.consoles)
            {
                Console_DropDownList.Items.Add(c.ConsoleNameID);
            }

            //add all genres to the genre listes
            foreach (Genre g in adminstration.genres)
            {
                Genre_RadioButtonList.Items.Add(g.GenreName);
            }

            //add all the themes to the theme listes
            foreach (Theme t in adminstration.themes)
            {
                Theme_RadioButtonList.Items.Add(t.ThemeName);
            }

            //get all the special game listes
            List<Game> ConsoleGames = gameDatabase.ConsoleGames(consoleName);
            List<Game> TopGames = gameDatabase.TopGames(consoleName);
            List<Game> NewGames = gameDatabase.NewReleasesGames(consoleName);
            List<Game> ComingGames = gameDatabase.ComingGames(consoleName);

            //add al games to the allgames listbox
            foreach (Game g in ConsoleGames)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                //add the game with its name and platform and as value its ID
                AllGames_ListBox.Items.Add(dataItem);
            }

            //add al games to the top rated listbox
            foreach (Game g in TopGames)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                //add the game with its name and platform and as value its ID
                TopRated_ListBox.Items.Add(dataItem);
            }

            //add al games to the new release listbox
            foreach (Game g in NewGames)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                //add the game with its name and platform and as value its ID
                NewReleases_ListBox.Items.Add(dataItem);
            }

            //add al games to the coming soon listbox
            foreach (Game g in ComingGames)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                //add the game with its name and platform and as value its ID
                ComingSoon_ListBox.Items.Add(dataItem);
            }
        }

    }
}
