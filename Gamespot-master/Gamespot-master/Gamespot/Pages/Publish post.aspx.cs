using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gamespot.C_Codes_And_Classes;

namespace Gamespot.Pages
{
    public partial class Publish_post : System.Web.UI.Page
    {
        /// <summary>
        /// all databases the PublishPostes pages uses
        /// </summary>
        public Listes adminstration = new Listes();
        public GameDatabase gameDatabase = new GameDatabase();
        public ReviewDatabase reviewDatabase = new ReviewDatabase();
        public NewsDatabase newsDatabase = new NewsDatabase();
        public VideoDatabase videoDatabase = new VideoDatabase();

        /// <summary>
        /// public variabeles which are used in multiple events
        /// </summary>
        static Account user = null;

        //this event is trigged when the page is being loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PostChange();
                refresh();
                Date_Label.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //check from which page the user came en select the radio button
                PostType_RadioButtonList.SelectedIndex = Convert.ToInt32(Session["NewPost"]);
                PostType_RadioButtonList_SelectedIndexChanged(sender, e);
            }
        }

        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server.
            Exception exc = Server.GetLastError();

            Server.Execute("Error.aspx?handler=Page_Error%20-%20Publish post.aspx", true);
        }

        //when a radio button is selected the controls for the type of post will be visible and enabeld
        protected void PostType_RadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if news is selected
            if (PostType_RadioButtonList.SelectedValue == "News")
            {
                //reset all the types of unique post controls
                PostChange();
                //show the unique controls for news
                NewsContent_Label.Visible = true;
                NewsContent_TextBox.Visible = true;
                NewsRating_Label.Visible = true;
                NewsRating_DropDownList.Visible = true;
                //enabel the unique validator for news
                NewsContent_RequiredFieldValidator.Enabled = true;

            }
            //if review is selected
            if (PostType_RadioButtonList.SelectedValue == "Review")
            {
                //reset all the types of unique post controls
                PostChange();
                //show the unique controls for review
                ReviewContent_Label.Visible = true;
                ReviewContent_TextBox.Visible = true;
                ReviewGood_Label.Visible = true;
                ReviewGood_TextBox.Visible = true;
                ReviewBad_Label.Visible = true;
                ReviewBad_TextBox.Visible = true;
                ReviewRating_Label.Visible = true;
                ReviewRating_DropDownList.Visible = true;
                //enabel the unique validators for review
                ReviewContent_RequiredFieldValidator.Enabled = true;
                ReviewGood_RequiredFieldValidator.Enabled = true;
                ReviewBad_RequiredFieldValidator.Enabled = true;
            }
            //if video is selected
            if (PostType_RadioButtonList.SelectedValue == "Video")
            {
                //reset all the types of unique post controls
                PostChange();
                //show the unique controls for video
                VideoURL_Label.Visible = true;
                VideoURL_TextBox.Visible = true;
                //enabel the unique validator for video
                VideoURL_RequiredFieldValidator.Enabled = true;
            }
        }

        //this event will add a new post
        protected void Place_Button_Click(object sender, EventArgs e)
        {
            //get the normall input
            user = (Account)Session["globalAccount"];
            string Titel = Titel_TextBox.Text;
            int gameID = Convert.ToInt32(Game_ListBox.SelectedValue);
            Game postgame = gameDatabase.GetGame(gameID);
            DateTime uploadDate = Convert.ToDateTime(Date_Label.Text); 

            //check which type of post is is
            if (PostType_RadioButtonList.SelectedValue == "News")
            {
                //check if the titel is not being used already for the news
                News check = newsDatabase.GetNews(Titel);
                if (check == null)
                {
                    //if it is a news, get the extra news input
                    string content = NewsContent_TextBox.Text;
                    int rating = Convert.ToInt32(NewsRating_DropDownList.Text);
                    //create a new news object
                    News newNews = new News(Titel, user.ID, postgame.ID, uploadDate, content, rating);
                    //insert the new news in the database
                    newsDatabase.InsertNews(newNews);
                    //refresh the listes
                    refresh();
                    //redirict back to the page the user came from
                    Response.Redirect("NewsPostes.aspx");
                }
                else
                {
                    //else show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('This titel is already being used');</script>");
                }
            }
            if (PostType_RadioButtonList.SelectedValue == "Review")
            {
                //check if the titel is not being used already for the review
                News check = newsDatabase.GetNews(Titel);
                if (check == null)
                {
                    //if it is a review, get the extra review input
                    string content = ReviewContent_TextBox.Text;
                    string good = ReviewGood_TextBox.Text;
                    string bad = ReviewBad_TextBox.Text;
                    int rating = Convert.ToInt32(ReviewRating_DropDownList.Text);
                    //create a new review object
                    Review newReview = new Review(Titel, user.ID, postgame.ID, uploadDate, content, good, bad, rating);
                    //insert the new review in the database
                    reviewDatabase.InsertReview(newReview);
                    //refresh the listes
                    refresh();
                    //redirict back to the page the user came from
                    Response.Redirect("ReviewsPostes.aspx");
                }
                else
                {
                    //else show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('This titel is already being used');</script>");
                }
            }
            if (PostType_RadioButtonList.SelectedValue == "Video")
            {
                //check if the titel is not being used already for the video
                News check = newsDatabase.GetNews(Titel);
                if (check == null)
                {
                    //if it is a video, get the extra video input
                    string URL = VideoURL_TextBox.Text;
                    //create a new video object
                    Video newVideo = new Video(Titel, user.ID, postgame.ID, uploadDate, URL);
                    //insert the new video in the database
                    videoDatabase.InsertVideo(newVideo);
                    //refresh the listes
                    refresh();
                    //redirict back to the page the user came from
                    Response.Redirect("VideosPostes.aspx");
                }
                else
                {
                    //else show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('This titel is already being used');</script>");
                }
            }
        }

        //this method will refresh the listboxes
        private void refresh()
        {
            //clear the listbox for games
            Game_ListBox.Items.Clear();
            //refresh all the listes
            adminstration.refreshAll();

            //get all games the games
            foreach (Game g in adminstration.games)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                //add item to the listbox
                Game_ListBox.Items.Add(dataItem);
            }
        }

        //this method will disable all special post controls and validators
        private void PostChange()
        {
            NewsContent_Label.Visible = false;
            NewsContent_TextBox.Visible = false;
            NewsRating_Label.Visible = false;
            NewsRating_DropDownList.Visible = false;
            ReviewContent_Label.Visible = false;
            ReviewContent_TextBox.Visible = false;
            ReviewGood_Label.Visible = false;
            ReviewGood_TextBox.Visible = false;
            ReviewBad_Label.Visible = false;
            ReviewBad_TextBox.Visible = false;
            ReviewRating_Label.Visible = false;
            ReviewRating_DropDownList.Visible = false;
            VideoURL_Label.Visible = false;
            VideoURL_TextBox.Visible = false;

            NewsContent_RequiredFieldValidator.Enabled = false;
            ReviewContent_RequiredFieldValidator.Enabled = false;
            ReviewGood_RequiredFieldValidator.Enabled = false;
            ReviewBad_RequiredFieldValidator.Enabled = false;
            VideoURL_RequiredFieldValidator.Enabled = false;
        }
    }
}
