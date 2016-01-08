using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gamespot.C_Codes_And_Classes;

namespace Gamespot
{
    public partial class MyHome : System.Web.UI.Page
    {
        /// <summary>
        /// all databases the MyHome pages uses
        /// </summary>
        AccountDatabase AccountDB = new AccountDatabase();
        AccountList AccountList = new AccountList();
        GameDatabase GameDB = new GameDatabase();

        /// <summary>
        /// public variabeles which are used in multiple events
        /// </summary>
        static Account user = null;
        static Gendre gendre = Gendre.Not_importent;

        //this event is trigged when the page is being loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                 // get the account from the session and show its information
                user = (Account)Session["globalAccount"];
                if(user != null)
                {
                    Account_ID_Label.Text = user.ID.ToString();
                    UserName_TextBox.Text = user.UserName;
                    Email_TextBox.Text = user.Email;
                    if(user.GendreType.ToString() =="Male")
                    {
                        Gendre_RadioButtonList.SelectedIndex = 0;
                    }
                    if(user.GendreType.ToString() == "Female")
                    {
                        Gendre_RadioButtonList.SelectedIndex = 1;
                    }
                    if(user.GendreType.ToString() == "Not_importent")
                    {
                        Gendre_RadioButtonList.SelectedIndex = 2;
                    }
                    DateTime date = Convert.ToDateTime(user.Birthdate);
                    BirthDate_TextBox.Text = String.Format("{0:dd/MM/yyyy}", date);
                    Country_DropDownList.Text = user.Country;
                }
                // fill the want and have list of the user
                refresh();
                Want_ListBox.SelectedIndex = 0;
                Want_ListBox_SelectedIndexChanged(sender, e);
            }
        }

        //this event is triggerd when a game is selected from the want listbox
        protected void Want_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Want_ListBox.SelectedItem != null)
            {
                //get the game information
                int gameID = Convert.ToInt32(Want_ListBox.SelectedValue);
                Game wantGame = GameDB.GetGame(gameID);
                if (wantGame != null)
                {
                    //show the game information
                    Game_Name_Label.Text = wantGame.GameName;
                    Platform_Label.Text = wantGame.Platform;
                    Genre_Label.Text = wantGame.GenreName;
                    Thema_Label.Text = wantGame.ThemeName;
                    FirstRelease_Label.Text = wantGame.FirstRelease.ToShortDateString();
                    Rating_Label.Text = Convert.ToString(wantGame.Rating);
                    Description_TextBox.Text = wantGame.Description;
                    Publisher_Label.Text = wantGame.Publisher;
                    Designer_Label.Text = wantGame.Designer;
                }
            }
        }

        //this event is triggerd when a game is selected from the have listbox
        protected void Have_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Have_ListBox.SelectedItem != null)
            {
                //get the game information
                int gameID = Convert.ToInt32(Have_ListBox.SelectedValue);
                Game HaveGame = GameDB.GetGame(gameID);
                if (HaveGame != null)
                {
                    //show the game information
                    Game_Name_Label.Text = HaveGame.GameName;
                    Platform_Label.Text = HaveGame.Platform;
                    Genre_Label.Text = HaveGame.GenreName;
                    Thema_Label.Text = HaveGame.ThemeName;
                    FirstRelease_Label.Text = HaveGame.FirstRelease.ToShortDateString();
                    Rating_Label.Text = Convert.ToString(HaveGame.Rating);
                    Description_TextBox.Text = HaveGame.Description;
                    Publisher_Label.Text = HaveGame.Publisher;
                    Designer_Label.Text = HaveGame.Designer;
                }
            }
        }

        protected void Want_Remove_Button_Click(object sender, EventArgs e)
        {
            //get the selected game
            int gameID = Convert.ToInt32(Want_ListBox.SelectedValue);
            Game wantGame = GameDB.GetGame(gameID);

            //check if it exist in the database
            Game match = AccountList.GetWant(user.ID,wantGame.ID);
            if (match != null)
            {
                //delete the game from the want list
                AccountList.DeleteFromWant(user.ID, wantGame.ID);
                refresh();
            }
            else
            {
                //if it does not exist show error
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('The game does not exist in your want list');</script>");
            }
        }

        protected void Have_Remove_Button_Click(object sender, EventArgs e)
        {
            //get the selected game
            int gameID = Convert.ToInt32(Have_ListBox.SelectedValue);
            Game HaveGame = GameDB.GetGame(gameID);

            //check if it exist in the database
            Game match = AccountList.GetHave(user.ID, HaveGame.ID);
            if (match != null)
            {
                //delete the game from the want list
                AccountList.DeleteFromHave(user.ID, HaveGame.ID);
                refresh();
            }
            else
            {
                //if it does not exist show error
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('The game does not exist in you have list');</script>");
            }
        }

        protected void Save_Account_Button_Click(object sender, EventArgs e)
        {
            //check if a gendre is selected
            if(Gendre_RadioButtonList.SelectedItem != null)
            {
                //check if a country is selected
                if(Country_DropDownList.SelectedItem != null)
                {
                    //get all the information
                    string username = UserName_TextBox.Text;
                    string password = Password_TextBox.Text;
                    string email = Email_TextBox.Text;
                    //check which gendre type is selected
                    if (Gendre_RadioButtonList.SelectedValue == "Male")
                    {
                        gendre = Gendre.Male;
                    }
                    if (Gendre_RadioButtonList.SelectedValue == "Female")
                    {
                        gendre = Gendre.Female;
                    }
                    if (Gendre_RadioButtonList.SelectedValue == "Not importent")
                    {
                        gendre = Gendre.Not_importent;
                    }
                    string country = Country_DropDownList.Text;
                    DateTime birthdate = Convert.ToDateTime(BirthDate_TextBox.Text);
                    if (email == user.Email)
                    {
                        //when it is the same create an object and update the account
                        Account changed = new Account(user.ID, username, password, email, user.AccountType, gendre, country, birthdate);
                        AccountDB.UpdateAccount(changed);
                        Session["globalAccount"] = AccountDB.GetBy(changed.ID);
                    }
                    else
                    {
                        if (email != user.Email)
                        {
                            //if the email is changed, check if it is not already being used in the database
                            Account checkMail = AccountDB.CheckMail(email);
                            if (checkMail == null)
                            {
                                // create an object and update the account
                                Account changed = new Account(user.ID, username, password, email, user.AccountType, gendre, country, birthdate);
                                AccountDB.UpdateAccount(changed);
                                Session["globalAccount"] = AccountDB.GetBy(changed.ID);
                            }
                        }
                    }
                }
                else
                {
                    //if a country is not selected show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You need to select a country');</script>");
                }
            }
            else
            {
                //if a gendre is not selected show error
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You need to select a gendre option');</script>");
            }
        }

        public void refresh()
        {
            //refresh the wantlistbox with the games from the users wantlist
            Want_ListBox.Items.Clear();
            List<Game> want = AccountList.Want(user);
            foreach (Game g in want)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                //add the game with its name and platform and as value its ID
                Want_ListBox.Items.Add(dataItem);
            }

            //refresh the havelistbox with the games from the users havelist
            Have_ListBox.Items.Clear();
            List<Game> have = AccountList.Have(user);
            foreach (Game g in have)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                //add the game with its name and platform and as value its ID
                Have_ListBox.Items.Add(dataItem);
            }
        }
    }
}