using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamespot.C_Codes_And_Classes
{
    /// <summary>
    /// the summary of an game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// the ID of an game
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// the name of an game
        /// </summary>
        public string GameName { get; set; }
        /// <summary>
        /// the genre of an game
        /// </summary>
        public string GenreName { get; set; }
        /// <summary>
        /// the theme of an game
        /// </summary>
        public string ThemeName { get; set; }
        /// <summary>
        /// the platform of an game
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        /// the first release of an game
        /// </summary>
        public DateTime FirstRelease { get; set; }
        /// <summary>
        /// the rating of an game
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// the description of an game
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// the name of the publisher of an game
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// the name of the desigener of an game
        /// </summary>
        public string Designer { get; set; }

        /// <summary>
        /// the constructor of an new game to insert in the database
        /// </summary>
        /// <param name="gamename">the name of the game</param>
        /// <param name="genrename">the genre of the game</param>
        /// <param name="themename">the theme of the game</param>
        /// <param name="platform">the platform of the game</param>
        /// <param name="firstrelease">the first release of the game</param>
        /// <param name="rating">the rating of the game</param>
        /// <param name="description">the description of the game</param>
        /// <param name="publisher">the name of the publisher of the game</param>
        /// <param name="designer">the name of the desigener of the game</param>
        public Game(string gamename, string genrename, string themename, string platform, DateTime firstrelease, int rating, string description, string publisher, string designer)
        {
            this.GameName = gamename;
            this.GenreName = genrename;
            this.ThemeName = themename;
            this.Platform = platform;
            this.FirstRelease = firstrelease;
            this.Rating = rating;
            this.Description = description;
            this.Publisher = publisher;
            this.Designer = designer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">the ID of the game</param>
        /// <param name="gamename">the name of the game</param>
        /// <param name="genrename">the genre of the game</param>
        /// <param name="themename">the theme of the game</param>
        /// <param name="platform">the platform of the game</param>
        /// <param name="firstrelease">the first release of the game</param>
        /// <param name="rating">the rating of the game</param>
        /// <param name="description">the description of the game</param>
        /// <param name="publisher">the name of the publisher of the game</param>
        /// <param name="designer">the name of the desigener of the game</param>
        public Game(int id, string gamename, string genrename, string themename, string platform, DateTime firstrelease, int rating, string description, string publisher, string designer)
        {
            this.ID = id;
            this.GameName = gamename;
            this.GenreName = genrename;
            this.ThemeName = themename;
            this.Platform = platform;
            this.FirstRelease = firstrelease;
            this.Rating = rating;
            this.Description = description;
            this.Publisher = publisher;
            this.Designer = designer;
        }
    }
}