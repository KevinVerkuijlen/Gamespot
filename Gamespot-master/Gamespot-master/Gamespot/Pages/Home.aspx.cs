using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gamespot.C_Codes_And_Classes;

namespace Gamespot
{
    public partial class Home : System.Web.UI.Page
    {
        /// <summary>
        /// all databases the home pages uses
        /// </summary>
        public Listes adminstration = new Listes();
        public GameDatabase gameDatabase = new GameDatabase();
        public AccountDatabase accountdatabase = new AccountDatabase();
        public AccountList AccountList = new AccountList();
        public NewsDatabase newsDatabase = new NewsDatabase();
        public ReviewDatabase reviewDatabase = new ReviewDatabase();
        public VideoDatabase videoDatabase = new VideoDatabase();

        /// <summary>
        /// public variabeles which are used in multiple events
        /// </summary>
        static Account user;

        //this event is trigged when the page is being loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                refresh();
                Postes_ListBox.SelectedIndex = 0;
                Postes_ListBox_SelectedIndexChanged(sender, e);
                Games_ListBox.SelectedIndex = 0;
                Games_ListBox_SelectedIndexChanged(sender, e);
            }
        }

        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server.
            Exception exc = Server.GetLastError();

            Server.Execute("Error.aspx?handler=Page_Error%20-%20Home.aspx", true);
        }

        //this event will change the page to show all information for the type of post
        protected void Postes_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Postes_ListBox.SelectedItem != null)
            {
                //get the titel of the post
                string postTitel = Postes_ListBox.SelectedItem.Text;
                //check if the post is of the type news
                if (Postes_ListBox.SelectedValue == "News")
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
                if (Postes_ListBox.SelectedValue == "Review")
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
                if (Postes_ListBox.SelectedValue == "Video")
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


        //this event will show the selected game information
        protected void Games_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Games_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(Games_ListBox.SelectedValue);
                Game Games = gameDatabase.GetGame(gameID);
                if (Games != null)
                {
                    //show all the game information
                    Game_Name_Label.Text = Games.GameName;
                    Platform_Label.Text = Games.Platform;
                    Genre_Label.Text = Games.GenreName;
                    Thema_Label.Text = Games.ThemeName;
                    FirstRelease_Label.Text = Games.FirstRelease.ToShortDateString();
                    Rating_Label.Text = Convert.ToString(Games.Rating);
                    Description_TextBox.Text = Games.Description;
                    Publisher_Label.Text = Games.Publisher;
                    Designer_Label.Text = Games.Designer;
                }
            }
        }

        protected void Want_Button_Click(object sender, EventArgs e)
        {
            user = (Account)Session["globalAccount"];
            if (Games_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(Games_ListBox.SelectedValue);
                Game Games = gameDatabase.GetGame(gameID);
                Game checkHave = AccountList.GetHave(user.ID, gameID);
                //check if it exist in the have list
                if (checkHave == null)
                {
                    Game checkWant = AccountList.GetWant(user.ID, gameID);
                    //check if it exist in the want list
                    if (checkWant == null)
                    {
                        //if not add it to the want list
                        AccountList.AddToWant(user.ID, Games.ID);
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

        protected void Have_Button_Click(object sender, EventArgs e)
        {
            user = (Account)Session["globalAccount"];
            if (Games_ListBox.SelectedItem != null)
            {
                //get the game
                int gameID = Convert.ToInt32(Games_ListBox.SelectedValue);
                Game Games = gameDatabase.GetGame(gameID);
                Game checkWant = AccountList.GetWant(user.ID, gameID);
                //check if it exist in the want list
                if (checkWant == null)
                {
                    //check if it exist in the have list
                    Game checkHave = AccountList.GetHave(user.ID, Games.ID);
                    if (checkHave == null)
                    {
                        //if not add it to the have list
                        AccountList.AddToHave(user.ID, Games.ID);
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

        //this would let the user follow the account which placed the selected post
        protected void Follow_Button_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('This option is not available yet');</script>");
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
        public void refresh()
        {
            //clear all the listboxen
            Postes_ListBox.Items.Clear();
            Games_ListBox.Items.Clear();

            //refresh the listes in the listes class
            adminstration.refreshAll();

            //add al games to the games listbox
            foreach (Game g in adminstration.games)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                //add the game with its name and platform and as value its ID
                Games_ListBox.Items.Add(dataItem);
            }


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
                    Postes_ListBox.Items.Add(dataItem);
                }
                //check if the post is an Review type
                if (p.GetType() == typeof(Review))
                {
                    dataItem.Text = p.Titel;
                    dataItem.Value = "Review";
                    //add the review with it titel an review as value
                    Postes_ListBox.Items.Add(dataItem);
                }
                //check if the post is an Video type
                if (p.GetType() == typeof(Video))
                {
                    dataItem.Text = p.Titel;
                    dataItem.Value = "Video";
                    //add the video with it titel an video as value
                    Postes_ListBox.Items.Add(dataItem);
                }
            }
        }
    }
}
