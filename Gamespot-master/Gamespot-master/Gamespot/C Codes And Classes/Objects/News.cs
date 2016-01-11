using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamespot.C_Codes_And_Classes
{
    /// <summary>
    /// the summary of a news which inherits from Post
    /// </summary>
    public class News : Post
    {
        /// <summary>
        /// the content of a news
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// the rating of an news
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// the constructor of an news which inherits from a Post to insert in the database
        /// </summary>
        /// <param name="titel">the titel of the news which is inherited from a Post</param>
        /// <param name="accountid">the accountid of the news which is inherited from a Post</param>
        /// <param name="gameid">the gameid of the news which is inherited from a Post</param>
        /// <param name="uploaddate">the upploaddate of the news which is inherited from a Post</param>
        /// <param name="content">the content of the news</param>
        /// <param name="rating">the rating of the news</param>
        public News(string titel, int accountid, int gameid, DateTime uploaddate, string content, int rating)
            : base(titel, accountid, gameid, uploaddate)
        {
            if (titel == null) { throw new ArgumentNullException("titel", "news titel description is null"); }
            if (accountid <= 0) { throw new ArgumentOutOfRangeException("accountid", "news accountid is invalid"); }
            if (gameid <= 0) { throw new ArgumentOutOfRangeException("gameid", "news gameid is invalid"); }
            if (uploaddate == null) { throw new ArgumentNullException("uploaddate", "news uploaddate is null"); }
            if (content == null) { throw new ArgumentNullException("content", "news content is null"); }
            if (rating <= 0) { throw new ArgumentOutOfRangeException("rating", "news rating is invalid"); }

            this.Content = content;
            this.Rating = rating;
        }

        /// <summary>
        /// the constructor of an news which inherits from a Post being loaded fromt the database
        /// </summary>
        /// <param name="ID">the ID of the news</param>
        /// <param name="titel">the titel of the news</param>
        /// <param name="accountid">the accountid of the news</param>
        /// <param name="gameid">the gameid of the news</param>
        /// <param name="uploaddate">the upploaddate of the news</param>
        /// <param name="content">the content of the news</param>
        /// <param name="rating">the rating of the news</param>
        public News(int ID, string titel, int accountid, int gameid, DateTime uploaddate, string content, int rating)
            : base(ID, titel, accountid, gameid, uploaddate)
        {
            if (ID <= 0) { throw new ArgumentOutOfRangeException("id", "news id is invalid"); }
            if (titel == null) { throw new ArgumentNullException("titel", "news titel description is null"); }
            if (accountid <= 0) { throw new ArgumentOutOfRangeException("accountid", "news accountid is invalid"); }
            if (gameid <= 0) { throw new ArgumentOutOfRangeException("gameid", "news gameid is invalid"); }
            if (uploaddate == null) { throw new ArgumentNullException("uploaddate", "news uploaddate is null"); }
            if (content == null) { throw new ArgumentNullException("content", "news content is null"); }
            if (rating <= 0) { throw new ArgumentOutOfRangeException("rating", "news rating is invalid"); }
            this.Content = content;
            this.Rating = rating;
        }
    }
}