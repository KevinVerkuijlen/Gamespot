using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Gamespot.C_Codes_And_Classes
{
    public class NewsDatabase
    {
        Database db = new Database();

        /// <summary>
        /// this methode gets all the news from the database
        /// </summary>
        /// <returns>it returns a list of news object for each news in the database</returns>
        public List<News> AllNews()
        {
            List<News> AllNews = new List<News>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM NEWS";

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["NEWS_ID"]);
                    string titel = Convert.ToString(reader["NEWS_TITEL"]);
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    int gameID = Convert.ToInt32(reader["GAMEID"]);
                    DateTime uploaddate = Convert.ToDateTime(reader["UPLOADDATE"]);
                    string content = Convert.ToString(reader["CONTENT"]);
                    int rating = Convert.ToInt32(reader["RATING"]);
                    AllNews.Add(new News(ID, titel, accountID, gameID, uploaddate, content,rating));
                }
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                db.CloseConnection();
            }
            return AllNews;
        }

        /// <summary>
        /// this methode gets all the news from the logged in user
        /// </summary>
        /// <param name="user">user is the account object from the logged in user</param>
        /// <returns>it returns a list of news objects which belong to the user</returns>
        public List<News> MyNews(Account user)
        {
            List<News> MyNews = new List<News>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM NEWS WHERE ACCOUNTID = :userID";
                db.Command.Parameters.Add(new OracleParameter(":userID", user.ID));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["NEWS_ID"]);
                    string titel = Convert.ToString(reader["NEWS_TITEL"]);
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    int gameID = Convert.ToInt32(reader["GAMEID"]);
                    DateTime uploaddate = Convert.ToDateTime(reader["UPLOADDATE"]);
                    string content = Convert.ToString(reader["CONTENT"]);
                    int rating = Convert.ToInt32(reader["RATING"]);
                    MyNews.Add(new News(ID, titel, accountID, gameID, uploaddate, content, rating));
                }
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                db.CloseConnection();
            }
            return MyNews;
        }

        /// <summary>
        /// this methode is used to search for a news in the database
        /// </summary>
        /// <param name="Titel">this is the titel used for searching </param>
        /// <returns>it returns a news object</returns>
        public News GetNews(string Titel)
        {
            News match = null;

            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM NEWS WHERE NEWS_TITEL = :titel";
                db.Command.Parameters.Add(new OracleParameter(":titel", Titel));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["NEWS_ID"]);
                    string titel = Convert.ToString(reader["NEWS_TITEL"]);
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    int gameID = Convert.ToInt32(reader["GAMEID"]);
                    DateTime uploaddate = Convert.ToDateTime(reader["UPLOADDATE"]);
                    string content = Convert.ToString(reader["CONTENT"]);
                    int rating = Convert.ToInt32(reader["RATING"]);
                    match =new News(ID, titel, accountID, gameID, uploaddate, content, rating);
                }
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                db.CloseConnection();
            }
            return match;
        }

        /// <summary>
        /// this method is used to insert a  new news in the database
        /// </summary>
        /// <param name="newnews">this news object contains the information of the new news</param>
        public void InsertNews(News newnews)
        {
            try
            {
                db.OpenConnection();
                db.Query = "ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS'";
                db.Command.ExecuteNonQuery();

                db.Query = "INSERT INTO NEWS (NEWs_ID, NEWS_TITEL, ACCOUNTID, GAMEID, UPLOADDATE, CONTENT, RATING) VALUES(seq_News.nextval, :titel, :accountid, :gameid, TO_DATE(:uploaddate,'DD-MM-YYYY'), :content, :rating)";
                db.Command.Parameters.Add(new OracleParameter(":titel", newnews.Titel));
                db.Command.Parameters.Add(new OracleParameter(":accountid", newnews.AccountID));
                db.Command.Parameters.Add(new OracleParameter(":gameid", newnews.GameID));
                db.Command.Parameters.Add(new OracleParameter(":uploaddate", newnews.UploadDate.ToShortDateString()));
                db.Command.Parameters.Add(new OracleParameter(":content", newnews.Content));
                db.Command.Parameters.Add(new OracleParameter(":rating", newnews.Rating));

                db.Command.ExecuteNonQuery();
                db.Commit();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                db.Commit();
                db.CloseConnection();
            }
        }

        /// <summary>
        /// this method is used to delete a news from the database
        /// </summary>
        /// <param name="deletenews">this news object contains the information of the news to delete</param>
        public void DeleteNews(News deletenews)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE FROM NEWS WHERE NEWS_ID = :id";
                db.Command.Parameters.Add(new OracleParameter(":id", deletenews.ID));
                db.Command.ExecuteNonQuery();
                db.Commit();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                db.Commit();
                db.CloseConnection();
            }
        }

        /// <summary>
        /// this method is used to delete a news from the database which belong to the logged in user
        /// </summary>
        /// <param name="user">user is the account object from the logged in user</param>
        /// <param name="deletenews">this news object contains the information of the news to delete</param>
        public void DeleteNews(Account user, News deletenews)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE FROM NEWS WHERE NEWS_ID = :id AND ACCOUNTID = :account";
                db.Command.Parameters.Add(new OracleParameter(":account", user.ID));
                db.Command.Parameters.Add(new OracleParameter(":id", deletenews.ID));
                db.Command.ExecuteNonQuery();
                db.Commit();
            }
            catch (OracleException)
            {
                throw;
            }
            finally
            {
                db.Commit();
                db.CloseConnection();
            }
        }
    }
}