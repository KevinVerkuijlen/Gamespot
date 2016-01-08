using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Gamespot.C_Codes_And_Classes
{
    public class VideoDatabase
    {
        Database db = new Database();

        /// <summary>
        /// this methode gets all the videos from the database
        /// </summary>
        /// <returns>it returns a list of video object for each videos in the database</returns>
        public List<Video> AllVideos()
        {
            List<Video> AllVideos = new List<Video>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM VIDEO";

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["VIDEO_ID"]);
                    string titel = Convert.ToString(reader["VIDEO_TITEL"]);
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    int gameID = Convert.ToInt32(reader["GAMEID"]);
                    DateTime uploaddate = Convert.ToDateTime(reader["UPLOADDATE"]);
                    string url = Convert.ToString(reader["VIDEOURL"]);
                    AllVideos.Add(new Video(ID,titel,accountID,gameID,uploaddate,url));
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
            return AllVideos;
        }

        /// <summary>
        /// this methode gets all the videos from the logged in user
        /// </summary>
        /// <param name="user">user is the account object from the logged in user</param>
        /// <returns>it returns a list of videos objects which belong to the user</returns>
        public List<Video> MyVideos(Account user)
        {
            List<Video> MyVideos = new List<Video>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM VIDEO WHERE ACCOUNTID = :userID";
                db.Command.Parameters.Add(new OracleParameter(":userID", user.ID));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["VIDEO_ID"]);
                    string titel = Convert.ToString(reader["VIDEO_TITEL"]);
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    int gameID = Convert.ToInt32(reader["GAMEID"]);
                    DateTime uploaddate = Convert.ToDateTime(reader["UPLOADDATE"]);
                    string url = Convert.ToString(reader["VIDEOURL"]);
                    MyVideos.Add(new Video(ID, titel, accountID, gameID, uploaddate, url));
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
            return MyVideos;
        }

        /// <summary>
        /// this methode is used to search for a video in the database
        /// </summary>
        /// <param name="Titel">this is the titel used for searching</param>
        /// <returns>it returns a video object</returns>
        public Video GetVideo(string Titel)
        {
            Video match = null;

            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM VIDEO WHERE VIDEO_TITEL = :titel";
                db.Command.Parameters.Add(new OracleParameter(":titel", Titel));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["VIDEO_ID"]);
                    string titel = Convert.ToString(reader["VIDEO_TITEL"]);
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    int gameID = Convert.ToInt32(reader["GAMEID"]);
                    DateTime uploaddate = Convert.ToDateTime(reader["UPLOADDATE"]);
                    string url = Convert.ToString(reader["VIDEOURL"]);
                    match = new Video(ID, titel, accountID, gameID, uploaddate, url);
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
        /// this method is used to insert a new video in the database
        /// </summary>
        /// <param name="newvideo">this video object contains the information of the new video</param>
        public void InsertVideo(Video newvideo)
        {
            try
            {
                db.OpenConnection();

                db.Query = "INSERT INTO VIDEO (VIDEO_ID, VIDEO_TITEL, ACCOUNTID, GAMEID, UPLOADDATE, VIDEOURL) VALUES(seq_Video.nextval, :titel, :accountid, :gameid, TO_DATE(:uploaddate,'DD-MM-YYYY'), :url)";
                db.Command.Parameters.Add(new OracleParameter(":titel", newvideo.Titel ));
                db.Command.Parameters.Add(new OracleParameter(":accountid", newvideo.AccountID));
                db.Command.Parameters.Add(new OracleParameter(":gameid", newvideo.GameID));
                db.Command.Parameters.Add(new OracleParameter(":uploaddate", newvideo.UploadDate.ToShortDateString()));
                db.Command.Parameters.Add(new OracleParameter(":url", newvideo.VideoURL));
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
        /// this method is used to delete a video from the database
        /// </summary>
        /// <param name="deletevideo">this video object contains the information of the video to delete</param>
        public void DeleteVideo(Video deletevideo)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE FROM VIDEO WHERE VIDEO_ID = :id";
                db.Command.Parameters.Add(new OracleParameter(":id", deletevideo.ID));
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
        /// this method is used to delete a video from the database which belong to the logged in user
        /// </summary>
        /// <param name="user">user is the account object from the logged in user</param>
        /// <param name="deletevideo">this video object contains the information of the video to delete</param>
        public void DeleteVideo(Account user, Video deletevideo)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE FROM VIDEO WHERE VIDEO_ID = :id AND ACCOUNTID = :account";
                db.Command.Parameters.Add(new OracleParameter(":account", user.ID));
                db.Command.Parameters.Add(new OracleParameter(":id", deletevideo.ID));
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