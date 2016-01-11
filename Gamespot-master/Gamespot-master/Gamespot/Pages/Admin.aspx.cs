using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gamespot.C_Codes_And_Classes;

namespace Gamespot.Pages
{
    public partial class Admin : System.Web.UI.Page
    {
        /// <summary>
        /// all databases the admin pages uses
        /// </summary>
        public Listes adminstration = new Listes();
        public GameDatabase gameDatabase = new GameDatabase();
        public AccountDatabase accountdatabase = new AccountDatabase();
        public NewsDatabase newsDatabase = new NewsDatabase();
        public ReviewDatabase reviewDatabase = new ReviewDatabase();
        public VideoDatabase videoDatabase = new VideoDatabase();
        public ConsoleDatabase consoleDatabase = new ConsoleDatabase();
        public GenreDatabase genreDatabase = new GenreDatabase();
        public ThemeDatabase themeDatabase = new ThemeDatabase();

        /// <summary>
        /// public variabeles which are used in multiple events
        /// </summary>
        static Account selectedUser = null;
        static Gendre gendre = Gendre.Not_importent;
        static string consoleName = "";

        //this event is trigged when the page is being loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if the page is being loaded refresh all the listes
                refresh();
            }
        }

        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server.
            Exception exc = Server.GetLastError();

            Server.Execute("Error.aspx?handler=Page_Error%20-%20Admin.aspx", true);
        }

        //this event is trigged when a post type is selected from the dropdownlist
        protected void PostType_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show all the postes
            if(PostType_DropDownList.SelectedValue =="All")
            {
                refreshPostes();
            }
            //show only the news type postes
            if(PostType_DropDownList.SelectedValue =="News")
            {
                Post_ListBox.Items.Clear();
                foreach (Post p in adminstration.postes)
                {
                    ListItem dataItem = new ListItem();
                    if (p.GetType() == typeof(News))
                    {
                        dataItem.Text = p.Titel;
                        dataItem.Value = "News";
                        Post_ListBox.Items.Add(dataItem);
                    }
                }
            }
            //show only the review type postes
            if (PostType_DropDownList.SelectedValue == "Review")
            {
                Post_ListBox.Items.Clear();
                foreach(Review r in adminstration.reviews)
                {
                    Post_ListBox.Items.Add(r.Titel);
                }
            }
            //show only the video type postes
            if (PostType_DropDownList.SelectedValue == "Video")
            {
                Post_ListBox.Items.Clear();
                foreach(Video v in adminstration.videos)
                {
                    Post_ListBox.Items.Add(v.Titel);
                }
            }        
        }

        //this event removes a post from the database
        protected void RemovePost_Button_Click(object sender, EventArgs e)
        {
            //get the titel of the post to delete
            string titel = Post_ListBox.SelectedItem.Text;
            
            //if its is an news remove from news
            if (Post_ListBox.SelectedValue == "News")
            {
                News DeleteNews = newsDatabase.GetNews(titel);
                newsDatabase.DeleteNews(DeleteNews);
            }

            //if its is an Review remove from review
            if (Post_ListBox.SelectedValue == "Review")
            {
                Review DeleteReview = reviewDatabase.GetReview(titel);
                reviewDatabase.DeleteReview(DeleteReview);
            }

            //if its is an video remove from video
            if (Post_ListBox.SelectedValue == "Video")
            {
                Video DeleteVideo = videoDatabase.GetVideo(titel);
                videoDatabase.DeleteVideo(DeleteVideo);
            }
            //refresh the listes
            refresh();
        }

        //this event updates an account information
        protected void ChangeAccount_Button_Click(object sender, EventArgs e)
        {
            //get all the information an the account 
            string username = UserName_TextBox.Text;
            string password = Password_TextBox.Text;
            string email = Email_TextBox.Text;
            string country = Country_DropDownList.Text;
            DateTime birthdate = Convert.ToDateTime(BirthDate_TextBox.Text);
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
            
            //check if the email is the same or changed
            if (email == selectedUser.Email)
            {
                //when it is the same create an object and update the account
                Account changed = new Account(selectedUser.ID, username, password, email, selectedUser.AccountType, gendre, country, birthdate);
                accountdatabase.UpdateAccount(changed);
            }
            else
            {
                if(email != selectedUser.Email)
                {
                    //if the email is changed, check if it is not already being used in the database
                    Account checkMail = accountdatabase.CheckMail(email);
                    if(checkMail == null)
                    {
                        // create an object and update the account
                        Account changed = new Account(selectedUser.ID, username, password, email, selectedUser.AccountType, gendre, country, birthdate);
                        accountdatabase.UpdateAccount(changed);
                    }
                }
            }
            //refresh the listes
            refresh();
        }

        //this event removes an account from the database
        protected void AccountRemove_Button_Click(object sender, EventArgs e)
        {
            if (Account_ListBox.SelectedItem != null)
            {
                //get the account
                string mail = Account_ListBox.SelectedItem.Text;
                selectedUser = accountdatabase.CheckMail(mail);
                if (selectedUser != null)
                {
                    //remove the account from the database
                    accountdatabase.DelteAccount(selectedUser);
                }
            }
            //refresh the listes
            refresh();
        }

        //this event loads all the info of an account in the boxes 
        protected void Account_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Account_ListBox.SelectedItem != null)
            {
                string mail = Account_ListBox.SelectedItem.Text;
                selectedUser = accountdatabase.CheckMail(mail);
                if (selectedUser != null)
                {
                    Account_ID_Label.Text = selectedUser.ID.ToString();
                    UserName_TextBox.Text = selectedUser.UserName;
                    Email_TextBox.Text = selectedUser.Email;
                    //check which radiobutton needs to be checked
                    if (selectedUser.GendreType.ToString() == "Male")
                    {
                        Gendre_RadioButtonList.SelectedIndex = 0;
                    }
                    if (selectedUser.GendreType.ToString() == "Female")
                    {
                        Gendre_RadioButtonList.SelectedIndex = 1;
                    }
                    if (selectedUser.GendreType.ToString() == "Not_importent")
                    {
                        Gendre_RadioButtonList.SelectedIndex = 2;
                    }
                    BirthDate_TextBox.Text = selectedUser.Birthdate.ToShortDateString();
                    Country_DropDownList.Text = selectedUser.Country;
                }
            }
        }

        //this event will refresh the game listbox whith games which have the same console ass the selected console
        protected void ConsoleSort_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            consoleName = ConsoleSort_DropDownList.Text;
            refreshGame(consoleName);
            ConsoleSort_DropDownList.Text = consoleName;
        }

        //this event will add an new game to the database
        protected void GameAdd_Button_Click(object sender, EventArgs e)
        {
            //get all the game information
            string gamename = GameName_TextBox.Text;
            string genre = Genre_DropDownList.SelectedItem.Text;
            string theme = Theme_DropDownList.SelectedItem.Text;
            string platform = Platform_DropDownList.SelectedItem.Text;
            DateTime firstrelease = Convert.ToDateTime(FirstRelease_TextBox.Text);
            int rating = Convert.ToInt32(Rating_DropDownList.SelectedItem.Text);
            string Gamedescription = GameDescription_TextBox.Text;
            string publisher = GamePublischer_TextBox.Text;
            string designer = GameDesigner_TextBox.Text;
            //check if the game, platform combination already exist in the database
            Game checkGame = gameDatabase.GetGame(gamename, platform);
            if (checkGame == null)
            {
                //if it is a new game, create an object and insert the new game in the database
                Game newGame = new Game(gamename, genre, theme, platform, firstrelease, rating, Gamedescription, publisher, designer);
                gameDatabase.Insertgame(newGame);
            }
            refresh();
        }

        //this event will remove a game from the database
        protected void GameRemove_Button_Click(object sender, EventArgs e)
        {
            //check if the game exist in the database
            int gameID = Convert.ToInt32(Game_ListBox.SelectedValue);
            Game checkGame = gameDatabase.GetGame(gameID);
            if (checkGame != null)
            {
                //if the game exist delete the game
                gameDatabase.Deletegame(checkGame);
            }
            //refresh the listes
            refresh();
        }

        //this event will add a new console to the database
        protected void ConsoleAdd_Button_Click(object sender, EventArgs e)
        {
            //get all the console information
            string consolename = ConsoleName_TextBox.Text;
            string consoletype="";
            string Consoledescription = ConsoleDescription_TextBox.Text;
            if(ConsoleType_RadioButtonList.SelectedIndex == 0)
            {
                consoletype = "Handheld";
            }
            if(ConsoleType_RadioButtonList.SelectedIndex ==1)
            {
                consoletype = "Home console";
            }
            //check if the console doesn't already exist in the database
            C_Codes_And_Classes.Console checkConsole = consoleDatabase.GetConsole(consolename);
            if(checkConsole == null)
            {
                //if the console doesn't already exist in the database create a console object and insert the console
                C_Codes_And_Classes.Console newConsole = new C_Codes_And_Classes.Console(consolename, consoletype, Consoledescription);
                consoleDatabase.InsertConsole(newConsole);
            }
            //refresh the listes
            refresh();
        }

        //this event will remove an console from the database
        protected void ConsoleRemove_Button_Click(object sender, EventArgs e)
        {
            //check if the console exist in the database
            string consolename = Console_ListBox.SelectedItem.Text;
            C_Codes_And_Classes.Console checkConsole = consoleDatabase.GetConsole(consolename);
            if (checkConsole != null)
            {
                //if the console exist delete the console
                consoleDatabase.DelteConsole(checkConsole);
            }
            //refresh the listes
            refresh();
        }

        //this event will add a new genre to the database
        protected void GenreAdd_Button_Click(object sender, EventArgs e)
        {
            //get all the genre information
            string genrename = GenreName_TextBox.Text;
            string genredescription = GenreDescription_TextBox.Text;
            //check if the genre doesn't already exist in the database
            Genre checkGenre = genreDatabase.GetName(genrename);
            if (checkGenre == null)
            {
                //if the genre doesn't already exist in the database create a genre object and insert the genre
                Genre newGenre = new Genre(genrename, genredescription);
                genreDatabase.InsertGenre(newGenre);
            }
            //refresh the listes
            refresh();
        }

        //this event will remove a genre from the database
        protected void GenreRemove_Button_Click(object sender, EventArgs e)
        {
            //check if the genre exist in the database
            string genrename = Genre_ListBox.SelectedItem.Text;
            Genre checkGenre = genreDatabase.GetName(genrename);
            if (checkGenre != null)
            {
                //if the genre exist delete the console
                genreDatabase.DelteGenre(genrename);
            }
            //refresh the listes
            refresh();
        }

        //this event will add a new theme to the database
        protected void ThemeAdd_Button_Click(object sender, EventArgs e)
        {
            //get all the theme information
            string themename = ThemeName_TextBox.Text;
            string themedescription = ThemeDescription_TextBox.Text;
            //check if the theme doesn't already exist in the database
            Theme checkTheme = themeDatabase.GetName(themename);
            if (checkTheme == null)
            {
                //if the theme doesn't already exist in the database create a theme object and insert the theme
                Theme newTheme = new Theme(themename, themedescription);
                themeDatabase.InsertTheme(newTheme);
            }
            //refresh the listes
            refresh();
        }

        protected void ThemeRemove_Button_Click(object sender, EventArgs e)
        {
            //check if the theme exist in the database
            string themename = Theme_ListBox.SelectedItem.Text;
            Theme checkTheme = themeDatabase.GetName(themename);
            if(checkTheme != null)
            {
                //if the theme exist delete the console
                themeDatabase.DelteTheme(themename);
            }
            //refresh the listes
            refresh();
        }

        //this method will refresh only all the postes on the page and in the listes class
        private void refreshPostes()
        {
            //refesh all the listes in the listes class
            adminstration.refreshAll();

            //clear the Post listbox
            Post_ListBox.Items.Clear();
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
                    Post_ListBox.Items.Add(dataItem);
                }
                //check if the post is an Review type
                if (p.GetType() == typeof(Review))
                {
                    dataItem.Text = p.Titel;
                    dataItem.Value = "Review";
                    //add the review with it titel an review as value
                    Post_ListBox.Items.Add(dataItem);
                }
                //check if the post is an Video type
                if (p.GetType() == typeof(Video))
                {
                    dataItem.Text = p.Titel;
                    dataItem.Value = "Video";
                    //add the video with it titel an video as value
                    Post_ListBox.Items.Add(dataItem);
                }
            }
        }

        //this method will refresh the gamelistbox with all the games for the selected console
        public void refreshGame(string platform)
        {
            //clear the game listbox
            Game_ListBox.Items.Clear();
            //get a list with all the consoles for the console
            List<Game> consoleGames = gameDatabase.ConsoleGames(platform);
            foreach (Game g in consoleGames)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                //add the game with its name and platform and as value its ID
                Game_ListBox.Items.Add(dataItem);
            }
        }

        //this method will refresh all listes on the page
        private void refresh()
        {
            //this method will refresh all postes
            refreshPostes();

            //clear all the other listboxen
            Console_ListBox.Items.Clear();
            ConsoleSort_DropDownList.Items.Clear();
            Platform_DropDownList.Items.Clear();
            Account_ListBox.Items.Clear();
            Genre_ListBox.Items.Clear();
            Theme_ListBox.Items.Clear();
            Game_ListBox.Items.Clear();

            //refresh the listes in the listes class
            adminstration.refreshAll();
            
            //add all consoles to the listes
            foreach (C_Codes_And_Classes.Console c in adminstration.consoles)
            {
                Console_ListBox.Items.Add(c.ConsoleNameID);
                ConsoleSort_DropDownList.Items.Add(c.ConsoleNameID);
                Platform_DropDownList.Items.Add(c.ConsoleNameID);
            }

            //add all accounts to the account listbox
            foreach (Account a in adminstration.accounts)
            {
                Account_ListBox.Items.Add(a.Email);
            }

            //add all genres to the genre listes
            foreach (Genre e in adminstration.genres)
            {
                Genre_ListBox.Items.Add(e.GenreName);
                Genre_DropDownList.Items.Add(e.GenreName);
            }
            
            //add all the themes to the theme listes
            foreach (Theme t in adminstration.themes)
            {
                Theme_ListBox.Items.Add(t.ThemeName);
                Theme_DropDownList.Items.Add(t.ThemeName);
            }

            //add al games to the listbox
            foreach (Game g in adminstration.games)
            {
                //create new listItems
                ListItem dataItem = new ListItem();
                dataItem.Text = g.GameName + ", " + g.Platform;
                dataItem.Value = g.ID.ToString();
                //add the game with its name and platform and as value its ID
                Game_ListBox.Items.Add(dataItem);
            }
        }
    }
}
