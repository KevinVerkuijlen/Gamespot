using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamespot.C_Codes_And_Classes
{
    /// <summary>
    /// description of an account object
    /// </summary>
    public class Account
    {
        /// <summary>
        /// ID of an acccount
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The username of an account
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// the password of an account
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// the email adress of an account
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// the accounttype of an account which is user or admin
        /// </summary>
        public string AccountType { get; set; }
        /// <summary>
        /// the gendre of an account which is Male, Female or not important
        /// </summary>
        public Gendre GendreType { get; set; }
        /// <summary>
        /// the country of an account
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// the birthdate of an account
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// the contstructer for a new account to register
        /// </summary>
        /// <param name="username">The username of the account</param>
        /// <param name="password">the password of the account</param>
        /// <param name="email">the email adress of the account</param>
        /// <param name="gendretype">the gendre of the account which is Male, Female or not important</param>
        /// <param name="country">the country of the account</param>
        /// <param name="birthdate">the birthdate of the account</param>
        public Account(string username, string password, string email, Gendre gendretype, string country, DateTime birthdate)
        {
            this.UserName = username;
            this.Password = password;
            this.Email = email;
            this.GendreType = gendretype;
            this.Country = country;
            this.Birthdate = birthdate;
        }

        /// <summary>
        /// the constructor for an account from the database
        /// </summary>
        /// <param name="id">ID of the acccount</param>
        /// <param name="username">The username of the account</param>
        /// <param name="password">the password of the account</param>
        /// <param name="email">the email adress of the account</param>
        /// <param name="accounttype">the accounttype of the account which is user or admin</param>
        /// <param name="gendretype">the gendre of the account which is Male, Female or not important</param>
        /// <param name="country">the country of the account</param>
        /// <param name="birthdate">the birthdate of the account</param>
        public Account(int id, string username, string password, string email, string accounttype, Gendre gendretype, string country, DateTime birthdate)
        {
            this.ID = id;
            this.UserName = username;
            this.Password = password;
            this.Email = email;
            this.AccountType = accounttype;
            this.GendreType = gendretype;
            this.Country = country;
            this.Birthdate = birthdate;
        }
    }
}