﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamespot.C_Codes_And_Classes
{
    /// <summary>
    /// the summary of a Video which inherits from Post
    /// </summary>
    public class Video : Post
    {
        private string url;

        /// <summary>
        /// the url of an video
        /// </summary>
        public string VideoURL
        {
            get { return url; }
            set { url = value; }
        }

        /// <summary>
        /// the constructor of an video which inherits from a Post to insert in the database
        /// </summary>
        /// <param name="titel">the titel of the video which is inherited from a Post</param>
        /// <param name="accountid">the accountid of the video which is inherited from a Post</param>
        /// <param name="gameid">the gameid of the video which is inherited from a Post</param>
        /// <param name="uploaddate">the upploaddate of the video which is inherited from a Post</param>
        /// <param name="videourl">the url of the video</param>
        public Video(string titel, int accountid, int gameid, DateTime uploaddate, string videourl)
            : base (titel, accountid, gameid, uploaddate)
        {
            if (titel == null) { throw new ArgumentNullException("titel", "video titel description is null"); }
            if (accountid <= 0) { throw new ArgumentOutOfRangeException("accountid", "video accountid is invalid"); }
            if (gameid <= 0) { throw new ArgumentOutOfRangeException("gameid", "video gameid is invalid"); }
            if (uploaddate == null) { throw new ArgumentNullException("uploaddate", "video uploaddate is null"); }
            if (videourl == null) { throw new ArgumentNullException("videourl", "videourl is null"); }

            this.VideoURL = videourl;
        }

        /// <summary>
        /// the constructor of an video which inherits from a Post which is being loaded fromt the database
        /// </summary>
        /// <param name="ID">the id of the video</param>
        /// <param name="titel">the titel of the video which is inherited from a Post</param>
        /// <param name="accountid">the accountid of the video which is inherited from a Post</param>
        /// <param name="gameid">the gameid of the video which is inherited from a Post</param>
        /// <param name="uploaddate">the upploaddate of the video which is inherited from a Post</param>
        /// <param name="videourl">the url of the video</param>
        public Video(int ID, string titel, int accountid, int gameid, DateTime uploaddate, string videourl)
            : base(ID, titel, accountid, gameid, uploaddate)
        {
            if (ID <= 0) { throw new ArgumentOutOfRangeException("id", "video id is invalid"); }
            if (titel == null) { throw new ArgumentNullException("titel", "video titel description is null"); }
            if (accountid <= 0) { throw new ArgumentOutOfRangeException("accountid", "video accountid is invalid"); }
            if (gameid <= 0) { throw new ArgumentOutOfRangeException("gameid", "video gameid is invalid"); }
            if (uploaddate == null) { throw new ArgumentNullException("uploaddate", "video uploaddate is null"); }
            if (videourl == null) { throw new ArgumentNullException("videourl", "videourl is null"); }

            this.VideoURL = videourl;
        }

    }
}