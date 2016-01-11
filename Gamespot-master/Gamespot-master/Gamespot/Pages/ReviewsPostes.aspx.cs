using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gamespot.C_Codes_And_Classes;

namespace Gamespot
{
    public partial class ReviewsPostes : System.Web.UI.Page
    {
        /// <summary>
        /// all databases the ReviewPostes pages uses
        /// </summary>
        public Listes adminstration = new Listes();
        public ReviewDatabase reviewDatabase = new ReviewDatabase();
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
                AllReviews_ListBox.SelectedIndex = 0;
                AllReviews_ListBox_SelectedIndexChanged(sender, e);
            }
        }

        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server.
            Exception exc = Server.GetLastError();

            Server.Execute("Error.aspx?handler=Page_Error%20-%ReviewPostes.aspx", true);
        }

        //this event will show the selected review information from the reviews listbox
        protected void AllReviews_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AllReviews_ListBox.SelectedItem != null)
            {
                //refreh the controls for review
                reviewrefresh();
                string review = AllReviews_ListBox.SelectedItem.Text;
                //get the review
                Review ShowReview = reviewDatabase.GetReview(review);
                //show the review information
                InputTitel_Label.Text = ShowReview.Titel;
                Game ReviewGame = gameDatabase.GetGame(ShowReview.GameID);
                Account ReviewAccount = accountdatabase.GetBy(ShowReview.AccountID);
                InputName_Label.Text = ReviewAccount.UserName;
                InputDate_Label.Text = ShowReview.UploadDate.ToShortDateString();
                InputGame_Label.Text = ReviewGame.GameName + ", " + ReviewGame.Platform;
                Content_TextBox.Text = ShowReview.Content;
                GoodPoints_TextBox.Text = ShowReview.PlusPoint;
                BadPoints_TextBox.Text = ShowReview.MinPoint;
                InputRating_Label.Text = Convert.ToString(ShowReview.Rating);
            }
        }

        //this event will show the selected news information from the myreviews listbox
        protected void MyReviews_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MyReviews_ListBox.SelectedItem != null)
            {
                //refreh the controls for review
                reviewrefresh();
                string review = AllReviews_ListBox.SelectedItem.Text;
                //get the review
                Review ShowReview = reviewDatabase.GetReview(review);
                //show the review information
                InputTitel_Label.Text = ShowReview.Titel;
                Game ReviewGame = gameDatabase.GetGame(ShowReview.GameID);
                Account ReviewAccount = accountdatabase.GetBy(ShowReview.ID);
                InputName_Label.Text = ReviewAccount.UserName;
                InputDate_Label.Text = ShowReview.UploadDate.ToShortDateString();
                InputGame_Label.Text = ReviewGame.GameName + ", " + ReviewGame.Platform;
                Content_TextBox.Text = ShowReview.Content;
                GoodPoints_TextBox.Text = ShowReview.PlusPoint;
                BadPoints_TextBox.Text = ShowReview.MinPoint;
                InputRating_Label.Text = Convert.ToString(ShowReview.Rating);
            }
        }

        //this event will redirect the user to the publish post page
        protected void Create_Button_Click(object sender, EventArgs e)
        {
            Session["NewPost"] = 1;
            Response.Redirect("Publish post.aspx");
        }

        //this event will remove the review which belongs to the user
        protected void Remove_Button_Click(object sender, EventArgs e)
        {
            if (MyReviews_ListBox.SelectedItem != null)
            {
                //get the review
                string selectedreview = MyReviews_ListBox.Text;
                Review selected = reviewDatabase.GetReview(selectedreview);
                //remove the review
                reviewDatabase.DeleteReview(user, selected); 
            }
        }

        //this would let the user follow the account which placed the selected post
        protected void Follow_Button_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('This option is not available yet');</script>");
        }

        //this method will refresh the review controls
        private void reviewrefresh()
        {
            InputTitel_Label.Text = "";
            InputName_Label.Text = "";
            InputDate_Label.Text = "";
            InputGame_Label.Text = "";
            Content_TextBox.Text = "";
            GoodPoints_TextBox.Text = "";
            BadPoints_TextBox.Text = "";
            InputRating_Label.Text = "";
        }

        //this method will refresh the news listes
        private void refresh()
        {
            // clear the listboxes
            MyReviews_ListBox.Items.Clear();
            AllReviews_ListBox.Items.Clear();

            //refresh all the reviews
            adminstration.refreshAll();
            //add the reviews to the listbox
            foreach (Review r in adminstration.reviews)
            {
                AllReviews_ListBox.Items.Add(r.Titel);
            }

            //get all the reviews which is published by the user
            List<Review> myrevies = reviewDatabase.MyReviews(user);
            //add all the reviews to the mynews listbox
            foreach (Review m in myrevies)
            {
                MyReviews_ListBox.Items.Add(m.Titel);
            }
        }
    }
}
