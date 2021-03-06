﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamespot.C_Codes_And_Classes
{
    /// <summary>
    /// the summary of a Review which inherits from Post
    /// </summary>
    public class Review : Post
    {
        /// <summary>
        /// the content of a review
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// the pluspoints of an review
        /// </summary>
        public string PlusPoint { get; set; }
        /// <summary>
        /// the minpoints of an review
        /// </summary>
        public string MinPoint { get; set; }
        /// <summary>
        /// the rating of an review
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// the constructor of an review which inherits from a Post to insert in the database
        /// </summary>
        /// <param name="titel">the titel of the review which is inherited from a Post</param>
        /// <param name="accountid">the accountid of the review which is inherited from a Post</param>
        /// <param name="gameid">the gameid of the review which is inherited from a Post</param>
        /// <param name="uploaddate">the upploaddate of the review which is inherited from a Post</param>
        /// <param name="content">the content of the review</param>
        /// <param name="pluspoints">the pluspoints of the review</param>
        /// <param name="minpoints">the minpoints of the review</param>
        /// <param name="rating">the rating of the review</param>
        public Review(string titel, int accountid, int gameid, DateTime uploaddate, string content, string pluspoints, string minpoints, int rating) 
            : base (titel, accountid, gameid, uploaddate)
        {
            if (titel == null) { throw new ArgumentNullException("titel", "review titel description is null"); }
            if (accountid <= 0) { throw new ArgumentOutOfRangeException("accountid", "review accountid is invalid"); }
            if (gameid <= 0) { throw new ArgumentOutOfRangeException("gameid", "review gameid is invalid"); }
            if (uploaddate == null) { throw new ArgumentNullException("uploaddate", "review uploaddate is null"); }
            if (content == null) { throw new ArgumentNullException("content", "review content is null"); }
            if (pluspoints == null) { throw new ArgumentNullException("pluspoints", "pluspoints is null"); }
            if (minpoints == null) { throw new ArgumentNullException("minpoints", "minpoints is null"); }
            if (rating <= 0) { throw new ArgumentOutOfRangeException("rating", "reivew rating is invalid"); }

            this.Content = content;
            this.PlusPoint = pluspoints;
            this.MinPoint = minpoints;
            this.Rating = rating;
        }

        /// <summary>
        /// the constructor of an review which inherits from a Post which is being loaded fromt the database
        /// </summary>
        /// <param name="ID">The id of the reviews</param>
        /// <param name="titel">the titel of the review which is inherited from a Post</param>
        /// <param name="accountid">the accountid of the review which is inherited from a Post</param>
        /// <param name="gameid">the gameid of the review which is inherited from a Post</param>
        /// <param name="uploaddate">the upploaddate of the review which is inherited from a Post</param>
        /// <param name="content">the content of the review</param>
        /// <param name="pluspoints">the pluspoints of the review</param>
        /// <param name="minpoints">the minpoints of the review</param>
        /// <param name="rating">the rating of the review</param>
        public Review(int ID, string titel, int accountid, int gameid, DateTime uploaddate, string content, string pluspoints, string minpoints, int rating)
            : base(ID,titel, accountid, gameid, uploaddate)
        {
            if (ID <= 0) { throw new ArgumentOutOfRangeException("id", "review id is invalid"); }
            if (titel == null) { throw new ArgumentNullException("titel", "review titel description is null"); }
            if (accountid <= 0) { throw new ArgumentOutOfRangeException("accountid", "review accountid is invalid"); }
            if (gameid <= 0) { throw new ArgumentOutOfRangeException("gameid", "review gameid is invalid"); }
            if (uploaddate == null) { throw new ArgumentNullException("uploaddate", "review uploaddate is null"); }
            if (content == null) { throw new ArgumentNullException("content", "review content is null"); }
            if (pluspoints == null) { throw new ArgumentNullException("pluspoints", "pluspoints is null"); }
            if (minpoints == null) { throw new ArgumentNullException("minpoints", "minpoints is null"); }
            if (rating <= 0) { throw new ArgumentOutOfRangeException("rating", "reivew rating is invalid"); }

            this.Content = content;
            this.PlusPoint = pluspoints;
            this.MinPoint = minpoints;
            this.Rating = rating;
        }
    }
}