using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gamespot.C_Codes_And_Classes;

namespace Gamespot
{
    public partial class NewsPostes : System.Web.UI.Page
    {
        /// <summary>
        /// all databases the NewsPostes pages uses
        /// </summary>
        public Listes adminstration = new Listes();
        public NewsDatabase newsDatabase = new NewsDatabase();
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
                AllNews_ListBox.SelectedIndex = 0;
                AllNews_ListBox_SelectedIndexChanged(sender, e);
            }
        }

        //this event will show the selected news information from the news listbox
        protected void AllNews_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AllNews_ListBox.SelectedItem != null)
            {
                //refreh the controls for news
                newsrefresh();
                string news = AllNews_ListBox.SelectedItem.Text;
                //get the news
                News ShowNews = newsDatabase.GetNews(news);
                //show the news information
                InputTitel_Label.Text = ShowNews.Titel;
                Game NewsGame = gameDatabase.GetGame(ShowNews.GameID);
                Account NewsAccount = accountdatabase.GetBy(ShowNews.ID);
                InputName_Label.Text = NewsAccount.UserName;
                InputDate_Label.Text = ShowNews.UploadDate.ToShortDateString();
                InputGame_Label.Text = NewsGame.GameName + ", " + NewsGame.Platform;
                Content_TextBox.Text = ShowNews.Content;
                InputRating_Label.Text = Convert.ToString(ShowNews.Rating);
            }
        }

        //this event will show the selected news information from the mynews listbox
        protected void MyNews_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MyNews_ListBox.SelectedItem != null)
            {
                //refreh the controls for news
                newsrefresh();
                string news = MyNews_ListBox.SelectedItem.Text;
                //get the news
                News ShowNews = newsDatabase.GetNews(news);
                //show the news information
                InputTitel_Label.Text = ShowNews.Titel;
                Game NewsGame = gameDatabase.GetGame(ShowNews.GameID);
                Account NewsAccount = accountdatabase.GetBy(ShowNews.AccountID);
                InputName_Label.Text = NewsAccount.UserName;
                InputDate_Label.Text = ShowNews.UploadDate.ToShortDateString();
                InputGame_Label.Text = NewsGame.GameName + ", " + NewsGame.Platform;
                Content_TextBox.Text = ShowNews.Content;
                InputRating_Label.Text = Convert.ToString(ShowNews.Rating);
            }
        }

        //this event will redirect the user to the publish post page
        protected void Create_Button_Click(object sender, EventArgs e)
        {
            Session["NewPost"] = 0;
            Response.Redirect("Publish post.aspx");
        }

        //this event will remove the new which belongs to the user
        protected void Remove_Button_Click(object sender, EventArgs e)
        {
            if (MyNews_ListBox.SelectedItem != null)
            {
                //get the news
                string selectednews = MyNews_ListBox.Text;
                News selected = newsDatabase.GetNews(selectednews);
                //remove the news
                newsDatabase.DeleteNews(user, selected);
            }
        }

        //this would let the user follow the account which placed the selected post
        protected void Follow_Button_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('This option is not available yet');</script>");
        }

        //this method will refresh the news controls
        private void newsrefresh()
        {
            InputTitel_Label.Text = "";
            InputName_Label.Text = "";
            InputDate_Label.Text = "";
            InputGame_Label.Text = "";
            Content_TextBox.Text = "";
            InputRating_Label.Text = "";
        }

        //this method will refresh the news listes
        private void refresh()
        {
            // clear the listboxes
            MyNews_ListBox.Items.Clear();
            AllNews_ListBox.Items.Clear();

            //refresh all the news
            adminstration.refreshAll();
            //add the new to the listbox
            foreach (News n in adminstration.news)
            {
                AllNews_ListBox.Items.Add(n.Titel);
            }

            //get all the news which is published by the user
            List<News> mynews = newsDatabase.MyNews(user);
            //add all the news to the mynews listbox
            foreach (News m in mynews)
            {
                MyNews_ListBox.Items.Add(m.Titel);
            }
        }
    }
}
