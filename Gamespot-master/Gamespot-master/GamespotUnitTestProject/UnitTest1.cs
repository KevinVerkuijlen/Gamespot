using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gamespot;
using Gamespot.C_Codes_And_Classes;

namespace GamespotUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
       

        [TestMethod]
        //test if an account is being correct insert and recoverd from the database
        public void InsertAccountTest()
        {
            string username = "GameSpot account";
            string password = "password";
            string email = "gamespot@hotmail.com";
            DateTime Bday = DateTime.Today;
            Gendre gendre = Gendre.Not_importent;
            string country = "United States";

            AccountDatabase ADB = new AccountDatabase();

            Account newAccount = new Account(username,password,email,gendre,country,Bday);
            ADB.InsertAccount(newAccount);
            Account control = ADB.Login(email, password);
            Assert.AreEqual(username, control.UserName, "wrong username");
            Assert.AreEqual(password, control.Password, "wrong password");
            Assert.AreEqual(email, control.Email, "wrong email");
            Assert.AreEqual(Bday.ToShortDateString(), control.Birthdate.ToShortDateString(), "wrong birthdate");
            Assert.AreEqual(gendre, control.GendreType, "wrong gendre");
            Assert.AreEqual(country, control.Country, "wrong country");
            ADB.DelteAccount(control);
        }

        [TestMethod]
        // a method to test if the consoledatabase works
        public void  ConsoleTest()
        {
            ConsoleDatabase CDB = new ConsoleDatabase();
            string consoleName = "Andriod";
            string consoletype = "Handheld";
            string description = "a mobile phone brand";
            Gamespot.C_Codes_And_Classes.Console testConsole = new Gamespot.C_Codes_And_Classes.Console(consoleName,consoletype,description);
            CDB.InsertConsole(testConsole);
            Gamespot.C_Codes_And_Classes.Console control = CDB.GetConsole(consoleName);
            Assert.AreEqual(consoleName, control.ConsoleNameID, "wrong name");
            Assert.AreEqual(consoletype, control.ConsoleType, "wrong type");
            Assert.AreEqual(description, control.Description, "wrong description");
            CDB.DelteConsole(control);
        }

        [TestMethod]
        // a method to test if the gernedatabase works
        public void GenreTest()
        {
            string genrename = "Murder";
            string description = "dead bodies";

            GenreDatabase GDB = new GenreDatabase();
            Genre genretest = new Genre(genrename, description);
            GDB.InsertGenre(genretest);

            Genre control = GDB.GetName(genrename);
            Assert.AreEqual(genrename, control.GenreName, "wrong name");
            Assert.AreEqual(description, control.Description, "wrong description");
            GDB.DelteGenre(genrename);
        }

        [TestMethod]
        // a method to test if the themedatabase works
        public void ThemeTest()
        {
            string themename = "Mystery";
            string description = "Spooky";

            ThemeDatabase TDB = new ThemeDatabase();
            Theme themetest = new Theme(themename,description);
            TDB.InsertTheme(themetest);

            Theme control = TDB.GetName(themename);
            Assert.AreEqual(themename, control.ThemeName, "wrong name");
            Assert.AreEqual(description, control.Description, "wrong description");
            TDB.DelteTheme(themename);
        }

        [TestMethod]
        // a method to test if the Gaedatabase works
        public void GameTest()
        {
            string gamename = "Asp.net survival";
             string genrename ="Action";
            string themename="Crime";
            string platform = "PC";
            DateTime firstrelease = DateTime.Today;
            int rating = 9;
            string description ="hello world";
            string publisher="Henk";
            string designer = "Jaap";

            GameDatabase GDB = new GameDatabase();

            Game testgame = new Game(gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer);
            GDB.Insertgame(testgame);

            Game control = GDB.GetGame(gamename, platform);
            Assert.AreEqual(gamename, control.GameName, "wrong name");
            Assert.AreEqual(genrename, control.GenreName, "wrong genre");
            Assert.AreEqual(themename, control.ThemeName, "wrong theme");
            Assert.AreEqual(platform, control.Platform, "wrong platform");
            Assert.AreEqual(firstrelease.ToShortDateString(), control.FirstRelease.ToShortDateString(), "wrong date");
            Assert.AreEqual(rating, control.Rating, "wrong rating");
            Assert.AreEqual(description, control.Description, "wrong description");
            Assert.AreEqual(publisher, control.Publisher, "wrong publisher");
            Assert.AreEqual(designer, control.Designer, "wrong designer");
            GDB.Deletegame(control);
        }

        [TestMethod]
        // a method to test if the Newsdatabase works
        public void NewsTest()
        {
            string Titel = "newstest";
            int accountid = 4;
            int gameid = 4;
            DateTime uploaddate = DateTime.Today;
            string content= "hello and gooed morning";
            int rating = 9;

            NewsDatabase NDB = new NewsDatabase();

            News testnews = new News(Titel, accountid, gameid, uploaddate, content, rating);
            NDB.InsertNews(testnews);

            News control = NDB.GetNews(Titel);
            Assert.AreEqual(Titel, control.Titel, "wrong titel");
            Assert.AreEqual(accountid, control.AccountID, "wrong accountID");
            Assert.AreEqual(gameid, control.GameID, "wrong gameID");
            Assert.AreEqual(uploaddate.ToShortDateString(), control.UploadDate.ToShortDateString(), "wrong uploaddate");
            Assert.AreEqual(content, control.Content, "wrong content");
            Assert.AreEqual(rating, control.Rating, "wrong rating");
            NDB.DeleteNews(control);
        }

        [TestMethod]
        // a method to test if the reviewdatabase works
        public void ReviewTest()
        {
            string Titel = "reviewtest";
            int accountid = 2;
            int gameid = 2;
            DateTime uploaddate = DateTime.Today;
            string content = "content";
            string good = "good";
            string bad = "bad";
            int rating = 8;

            ReviewDatabase RDB = new ReviewDatabase();
            Review testreview = new Review(Titel, accountid, gameid, uploaddate, content, good, bad, rating);
            RDB.InsertReview(testreview);
            Review control = RDB.GetReview(Titel);
            Assert.AreEqual(Titel, control.Titel, "wrong titel");
            Assert.AreEqual(accountid, control.AccountID, "wrong accountID");
            Assert.AreEqual(gameid, control.GameID, "wrong gameID");
            Assert.AreEqual(uploaddate.ToShortDateString(), control.UploadDate.ToShortDateString(), "wrong uploaddate");
            Assert.AreEqual(content, control.Content, "wrong content");
            Assert.AreEqual(good, control.PlusPoint, "wrong pluspoints");
            Assert.AreEqual(bad, control.MinPoint, "wrong minpoints");
            Assert.AreEqual(rating, control.Rating, "wrong rating");
            RDB.DeleteReview(control);
           
        }

        [TestMethod]
        // a method to test if the videodatabase works
        public void VideoTest()
        {
            string Titel = "videotest";
            int accountid = 1;
            int gameid = 1;
            DateTime uploaddate = DateTime.Today;
            string url = "fakeurl.nl";

            VideoDatabase VDB = new VideoDatabase();
            Video testvideo = new Video(Titel, accountid, gameid, uploaddate, url);
            VDB.InsertVideo(testvideo);
            Video control = VDB.GetVideo(Titel);
            Assert.AreEqual(Titel, control.Titel, "wrong titel");
            Assert.AreEqual(accountid, control.AccountID, "wrong accountID");
            Assert.AreEqual(gameid, control.GameID, "wrong gameID");
            Assert.AreEqual(uploaddate.ToShortDateString(), control.UploadDate.ToShortDateString(), "wrong uploaddate");
            Assert.AreEqual(url, control.VideoURL, "wrong url");
            VDB.DeleteVideo(testvideo);
        }
    }
}
