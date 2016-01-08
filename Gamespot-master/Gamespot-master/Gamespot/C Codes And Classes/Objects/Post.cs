using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamespot.C_Codes_And_Classes
{
    /// <summary>
    /// a summary of the abstract post
    /// </summary>
    abstract public class Post
    {
        private int PostID;
        private string PostTitel;
        private int P_AccountID;
        private int P_GameID;
        private DateTime P_UploadDate;
        
        /// <summary>
        /// the id of an post
        /// </summary>
        public int ID
        {
            get
            {
                return PostID;
            }
        }

        /// <summary>
        /// the titel of an post
        /// </summary>
        public string Titel
        {
            get
            {
                return PostTitel;
            }
        }

        /// <summary>
        /// the AccountID of an post
        /// </summary>
        public int AccountID
        {
            get
            {
                return P_AccountID;
            }
        }

        /// <summary>
        /// the GameID of an Post
        /// </summary>
        public int GameID
        {
            get
            {
                return P_GameID;
            }
        }

        /// <summary>
        /// The UploadDate of an Post
        /// </summary>
        public DateTime UploadDate
        {
            get
            {
                return P_UploadDate;
            }
        } 
        
        /// <summary>
        /// the constructor of an new post
        /// </summary>
        /// <param name="titel">the titel of the post</param>
        /// <param name="accountid">the AccountID of the post</param>
        /// <param name="gameid">the GameID of the Post</param>
        /// <param name="uploaddate">The UploadDate of the Post</param>
        public Post(string titel, int accountid, int gameid, DateTime uploaddate)
        {
            this.PostTitel = titel;
            this.P_AccountID = accountid;
            this.P_GameID = gameid;
            this.P_UploadDate = uploaddate;
        }
        
        /// <summary>
        /// the constructor of an Post being loaded from the database
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <param name="titel">the titel of the post</param>
        /// <param name="accountid">the AccountID of the post</param>
        /// <param name="gameid">the GameID of the Post</param>
        /// <param name="uploaddate">The UploadDate of the Post</param>
        public Post(int id, string titel, int accountid, int gameid, DateTime uploaddate)
        {
            this.PostID = id;
            this.PostTitel = titel;
            this.P_AccountID = accountid;
            this.P_GameID = gameid;
            this.P_UploadDate = uploaddate;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}