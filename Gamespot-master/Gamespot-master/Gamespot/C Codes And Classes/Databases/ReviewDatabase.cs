using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Gamespot.C_Codes_And_Classes
{
    public class ReviewDatabase
    {
        Database db = new Database();

        /// <summary>
        /// this methode gets all the reviews from the database
        /// </summary>
        /// <returns>it returns a list of review object for each review in the database</returns>
        public List<Review> AllReviews()
        {
            List<Review> AllReviews = new List<Review>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM REVIEW";

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["REVIEW_ID"]);
                    string titel = Convert.ToString(reader["REVIEW_TITEL"]);
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    int gameID = Convert.ToInt32(reader["GAMEID"]);
                    DateTime uploaddate = Convert.ToDateTime(reader["UPLOADDATE"]);
                    string content = Convert.ToString(reader["CONTENT"]);
                    string plus = Convert.ToString(reader["PLUSPOINTS"]);
                    string min = Convert.ToString(reader["MINUSPOINTS"]);
                    int rating = Convert.ToInt32(reader["REVIEWERRATING"]);
                    AllReviews.Add(new Review(ID,titel,accountID,gameID,uploaddate,content,plus,min,rating));
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
            return AllReviews;
        }

        /// <summary>
        /// this methode gets all the reviews from the logged in user
        /// </summary>
        /// <param name="user">user is the account object from the logged in user</param>
        /// <returns>it returns a list of review objects which belong to the user</returns>
        public List<Review> MyReviews(Account user)
        {
            List<Review> MyReviews = new List<Review>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM REVIEW WHERE ACCOUNTID = :userID";
                db.Command.Parameters.Add(new OracleParameter(":userID", user.ID));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["REVIEW_ID"]);
                    string titel = Convert.ToString(reader["REVIEW_TITEL"]);
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    int gameID = Convert.ToInt32(reader["GAMEID"]);
                    DateTime uploaddate = Convert.ToDateTime(reader["UPLOADDATE"]);
                    string content = Convert.ToString(reader["CONTENT"]);
                    string plus = Convert.ToString(reader["PLUSPOINTS"]);
                    string min = Convert.ToString(reader["MINUSPOINTS"]);
                    int rating = Convert.ToInt32(reader["REVIEWERRATING"]);
                    MyReviews.Add(new Review(ID, titel, accountID, gameID, uploaddate, content, plus, min, rating));
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
            return MyReviews;
        }

        /// <summary>
        /// this methode is used to search for a review in the database
        /// </summary>
        /// <param name="Titel">this is the titel used for searching</param>
        /// <returns>it returns a review object</returns>
        public Review GetReview(string Titel)
        {
            Review match = null;

            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM REVIEW WHERE REVIEW_TITEL = :titel";
                db.Command.Parameters.Add(new OracleParameter(":titel", Titel));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["REVIEW_ID"]);
                    string titel = Convert.ToString(reader["REVIEW_TITEL"]);
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    int gameID = Convert.ToInt32(reader["GAMEID"]);
                    DateTime uploaddate = Convert.ToDateTime(reader["UPLOADDATE"]);
                    string content = Convert.ToString(reader["CONTENT"]);
                    string plus = Convert.ToString(reader["PLUSPOINTS"]);
                    string min = Convert.ToString(reader["MINUSPOINTS"]);
                    int rating = Convert.ToInt32(reader["REVIEWERRATING"]);
                    match = new Review(ID, titel, accountID, gameID, uploaddate, content, plus, min, rating);
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
        /// this method is used to insert a new review in the database
        /// </summary>
        /// <param name="newreview">this review object contains the information of the new review</param>
        public void InsertReview(Review newreview)
        {
            try
            {
                db.OpenConnection();
                db.Query = "ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS'";
                db.Command.ExecuteNonQuery();

                db.Query = "INSERT INTO REVIEW (REVIEW_ID, REVIEW_TITEL, ACCOUNTID, GAMEID, UPLOADDATE, CONTENT, PLUSPOINTS, MINUSPOINTS, REVIEWERRATING) VALUES(seq_Review.nextval, :titel, :accountid, :gameid, TO_DATE(:uploaddate,'DD-MM-YYYY'), :content, :plus, :min, :rating)";
                db.Command.Parameters.Add(new OracleParameter(":titel", newreview.Titel));
                db.Command.Parameters.Add(new OracleParameter(":accountid", newreview.AccountID));
                db.Command.Parameters.Add(new OracleParameter(":gameid", newreview.GameID));
                db.Command.Parameters.Add(new OracleParameter(":uploaddate", newreview.UploadDate.ToShortDateString()));
                db.Command.Parameters.Add(new OracleParameter(":content", newreview.Content));
                db.Command.Parameters.Add(new OracleParameter(":plus", newreview.PlusPoint));
                db.Command.Parameters.Add(new OracleParameter(":min", newreview.MinPoint));
                db.Command.Parameters.Add(new OracleParameter(":rating", newreview.Rating));

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
        /// this method is used to delete a review from the database
        /// </summary>
        /// <param name="deletereview">this review object contains the information of the review to delete</param>
        public void DeleteReview(Review deletereview)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE FROM REVIEW WHERE REVIEW_ID = :id";
                db.Command.Parameters.Add(new OracleParameter(":id", deletereview.ID));
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
        /// this method is used to delete a review from the database which belong to the logged in user
        /// </summary>
        /// <param name="user">user is the account object from the logged in user</param>
        /// <param name="deletereview">this review object contains the information of the review to delete</param>
        public void DeleteReview(Account user, Review deletereview)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE FROM REVIEW WHERE REVIEW_ID = :id AND ACCOUNTID = :account";
                db.Command.Parameters.Add(new OracleParameter(":account", user.ID));
                db.Command.Parameters.Add(new OracleParameter(":id", deletereview.ID));
                db.Command.ExecuteNonQuery();
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