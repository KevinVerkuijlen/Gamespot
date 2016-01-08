using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamespot.C_Codes_And_Classes
{
    /// <summary>
    /// the summary of listes
    /// from here most of the listes will be filled and refreshd for the application
    /// </summary>
    public class Listes
    {
        AccountDatabase accountdatabase = new AccountDatabase();
        ConsoleDatabase consoledatabase = new ConsoleDatabase();
        GameDatabase gamedatabase = new GameDatabase();
        GenreDatabase genredatabase = new GenreDatabase();
        NewsDatabase newsdatabase = new NewsDatabase();
        ReviewDatabase reviewdatabase = new ReviewDatabase();
        ThemeDatabase themedatabase = new ThemeDatabase();
        VideoDatabase videodatabase = new VideoDatabase();
        
        public List<Account> accounts = new List<Account>();
        public List<Game> games = new List<Game>();
        public List<Post> postes = new List<Post>();
        public List<Console> consoles = new List<Console>();
        public List<Genre> genres = new List<Genre>();
        public List<Theme> themes = new List<Theme>();
        public List<Review> reviews = new List<Review>();
        public List<News> news = new List<News>();
        public List<Video> videos = new List<Video>();

        /// <summary>
        /// this method refreshes all listes with the data from the database
        /// </summary>
        public void refreshAll()
        {
            accounts = accountdatabase.allAccounts();
            games = gamedatabase.AllGames();
            consoles = consoledatabase.AllConsoles();
            genres = genredatabase.AllGenres();
            themes = themedatabase.AllThemes();
            reviews = reviewdatabase.AllReviews();
            news = newsdatabase.AllNews();
            videos = videodatabase.AllVideos();

            foreach (Review r in reviews)
            {
                postes.Add(r);
            }

            foreach (News n in news)
            {
                postes.Add(n);
            }
            foreach (Video v in videos)
            {
                postes.Add(v);
            }
        }
    }
}