using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gamespot.C_Codes_And_Classes;

namespace Gamespot
{
    public partial class VideosPostes : System.Web.UI.Page
    {
        /// <summary>
        /// all databases the VideoPostes pages uses
        /// </summary>
        public Listes adminstration = new Listes();
        public VideoDatabase videoDatabase = new VideoDatabase();
        public GameDatabase gameDatabase = new GameDatabase();
        public AccountDatabase accountdatabase = new AccountDatabase();

        /// <summary>
        /// public variabeles which are used in multiple events
        /// </summary>
        static Account user = null;

        //this event is trigged when the page is being loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user = (Account)Session["globalAccount"];
                refresh();
                AllVideos_ListBox.SelectedIndex = 0; 
                AllVideos_ListBox_SelectedIndexChanged(sender, e);
            }
        }

        //this event will show the selected video information from the videos listbox
        protected void AllVideos_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refreh the controls for video
            refreshvideo();
            string selectedvideo = AllVideos_ListBox.Text;
            //get the video
            Video ShowVideo = videoDatabase.GetVideo(selectedvideo);
            //show the video information
            InputTitel_Label.Text = ShowVideo.Titel;
            Game NewsGame = gameDatabase.GetGame(ShowVideo.GameID);
            Account NewsAccount = accountdatabase.GetBy(ShowVideo.AccountID);
            InputName_Label.Text = NewsAccount.UserName;
            InputDate_Label.Text = ShowVideo.UploadDate.ToShortDateString();
            InputGame_Label.Text = NewsGame.GameName + ", " + NewsGame.Platform;
        }

        protected void MyVideos_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refreh the controls for video
            refreshvideo();
            string selectedvideo = MyVideos_ListBox.Text;
            //get the video
            Video ShowVideo = videoDatabase.GetVideo(selectedvideo);
            //show the review information
            InputTitel_Label.Text = ShowVideo.Titel;
            Game NewsGame = gameDatabase.GetGame(ShowVideo.GameID);
            Account NewsAccount = accountdatabase.GetBy(ShowVideo.ID);
            InputName_Label.Text = NewsAccount.UserName;
            InputDate_Label.Text = ShowVideo.UploadDate.ToShortDateString();
            InputGame_Label.Text = NewsGame.GameName + ", " + NewsGame.Platform;
            //video
        }

        //this event will redirect the user to the publish post page
        protected void Create_Button_Click(object sender, EventArgs e)
        {
            Session["NewPost"] = 2;
            Response.Redirect("Publish post.aspx");
        }

        //this event will remove the video which belongs to the user
        protected void Remove_Button_Click(object sender, EventArgs e)
        {
            if (MyVideos_ListBox.SelectedItem != null)
            {
                //get the review
                string selectedvideo = MyVideos_ListBox.Text;
                Video selected = videoDatabase.GetVideo(selectedvideo);
                //remove the review
                videoDatabase.DeleteVideo(user, selected);
            }
        }

        //this would let the user follow the account which placed the selected post
        protected void Follow_Button_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('This option is not available yet');</script>");
        }

        //this method will refresh the video controls
        private void refreshvideo()
        {
            InputTitel_Label.Text = "";
            InputName_Label.Text = "";
            InputDate_Label.Text = "";
            InputGame_Label.Text = "";
        }

        //this method will refresh the video listes
        private void refresh()
        {
            // clear the listboxes
            AllVideos_ListBox.Items.Clear();
            MyVideos_ListBox.Items.Clear();

            //refresh all the videos
            adminstration.refreshAll();
            //add the videos to the listbox
            foreach (Video v in adminstration.videos)
            {
                AllVideos_ListBox.Items.Add(v.Titel);

            }

            //get all the videos which is published by the user
            List<Video> myvideos = videoDatabase.MyVideos(user);
            //add all the videos to the mynews listbox
            foreach (Video m in myvideos)
            {
                MyVideos_ListBox.Items.Add(m.Titel);
            }
        }
    }
}
