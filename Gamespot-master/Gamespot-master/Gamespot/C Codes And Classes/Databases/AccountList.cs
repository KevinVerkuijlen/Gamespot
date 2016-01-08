using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Gamespot.C_Codes_And_Classes
{
    public class AccountList
    {
        Database db = new Database();

        /// <summary>
        /// this method generates a list with account objects which the account has in his want list
        /// </summary>
        /// <param name="user">user is the account object from the logged in user</param>
        /// <returns>it returns a game object list with alll the games from the account want list</returns>
        public List<Game> Want(Account user)
        {
            List<Game> Want = new List<Game>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME G, WANTLIST W WHERE G.GAMEID=W.GAMEID AND W.ACCOUNTID= :userID ";
                db.Command.Parameters.Add(new OracleParameter(":userID", user.ID));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["GAMEID"]);
                    string gamename = Convert.ToString(reader["GAMENAME"]);
                    string genrename = Convert.ToString(reader["GENRENAME"]);
                    string themename = Convert.ToString(reader["THEMENAME"]);
                    string platform = Convert.ToString(reader["PLATFORMEN"]);
                    DateTime firstrelease = Convert.ToDateTime(reader["FIRSTRELEASE"]);
                    int rating = Convert.ToInt32(reader["RATING"]);
                    string description = Convert.ToString(reader["DESCRIPTION"]);
                    string designer = Convert.ToString(reader["ONTWERPER"]);
                    string publisher = Convert.ToString(reader["UITGEVER"]);
                    Want.Add(new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer));
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
            return Want;
        }

        /// <summary>
        /// this methode insert a game in the wantlist of the user
        /// </summary>
        /// <param name="userid">userid is the account id from the logged in user</param>
        /// <param name="newGameID">the newgameid is the id from the game to be added to the users wantlist</param>
        public void AddToWant(int userid, int newGameID)
        {
            try
            {
                db.OpenConnection();

                db.Query = "INSERT INTO WANTLIST (ACCOUNTID, GAMEID) VALUES(:userID, :gameID)";
                db.Command.Parameters.Add(new OracleParameter(":userID", userid));
                db.Command.Parameters.Add(new OracleParameter(":gameID", newGameID));

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
        /// this methode deletes the game from the users want list
        /// </summary>
        /// <param name="userid">userid is the account id from the logged in user</param>
        /// <param name="deleteGameID">the deleteGameID is the id from the game to be deletet from the users wantlist</param>
        public void DeleteFromWant(int userid, int deleteGameID)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE FROM WANTLIST WHERE ACCOUNTID = :userID AND GAMEID = :gameID";
                db.Command.Parameters.Add(new OracleParameter(":userID", userid));
                db.Command.Parameters.Add(new OracleParameter(":gameID", deleteGameID));

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
        /// this methode searches for the game in the users wantlist
        /// </summary>
        /// <param name="accountid">userid is the account id from the logged in user</param>
        /// <param name="gameid">the gameid is the id from the game to be found in the want list</param>
        /// <returns>it returns a game object</returns>
        public Game GetWant(int accountid, int gameid)
        {
            Game match = null;

            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME G, WANTLIST W WHERE G.GAMEID=W.GAMEID AND W.ACCOUNTID = :userID AND W.GAMEID = :gameID";
                db.Command.Parameters.Add(new OracleParameter(":userID", accountid));
                db.Command.Parameters.Add(new OracleParameter(":gameID", gameid));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["GAMEID"]);
                    string gamename = Convert.ToString(reader["GAMENAME"]);
                    string genrename = Convert.ToString(reader["GENRENAME"]);
                    string themename = Convert.ToString(reader["THEMENAME"]);
                    string platform = Convert.ToString(reader["PLATFORMEN"]);
                    DateTime firstrelease = Convert.ToDateTime(reader["FIRSTRELEASE"]);
                    int rating = Convert.ToInt32(reader["RATING"]);
                    string description = Convert.ToString(reader["DESCRIPTION"]);
                    string designer = Convert.ToString(reader["ONTWERPER"]);
                    string publisher = Convert.ToString(reader["UITGEVER"]);
                    match = new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer);
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
        /// this method generates a list with account objects which the account has in his have list
        /// </summary>
        /// <param name="user">user is the account object from the logged in user</param>
        /// <returns>it returns a game object list with alll the games from the account have list</returns>
        public List<Game> Have(Account user)
        {
            List<Game> Have = new List<Game>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME G, HAVELIST H WHERE G.GAMEID=H.GAMEID AND H.ACCOUNTID= :userID ";
                db.Command.Parameters.Add(new OracleParameter(":userID", user.ID));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["GAMEID"]);
                    string gamename = Convert.ToString(reader["GAMENAME"]);
                    string genrename = Convert.ToString(reader["GENRENAME"]);
                    string themename = Convert.ToString(reader["THEMENAME"]);
                    string platform = Convert.ToString(reader["PLATFORMEN"]);
                    DateTime firstrelease = Convert.ToDateTime(reader["FIRSTRELEASE"]);
                    int rating = Convert.ToInt32(reader["RATING"]);
                    string description = Convert.ToString(reader["DESCRIPTION"]);
                    string designer = Convert.ToString(reader["ONTWERPER"]);
                    string publisher = Convert.ToString(reader["UITGEVER"]);
                    Have.Add(new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer));
                }
            }
            catch(OracleException)
            {
                throw;
            }
            finally
            {
                db.CloseConnection();
            }
            return Have;
        }

        /// <summary>
        /// this methode insert a game in the havelist of the user
        /// </summary>
        /// <param name="userid">userid is the account id from the logged in user</param>
        /// <param name="newGameID">the newgameid is the id from the game to be added to the users havelist</param>
        public void AddToHave(int userid, int newGameID)
        {
            try
            {
                db.OpenConnection();

                db.Query = "INSERT INTO HAVELIST (ACCOUNTID, GAMEID) VALUES(:userID, :gameID)";
                db.Command.Parameters.Add(new OracleParameter(":userID", userid));
                db.Command.Parameters.Add(new OracleParameter(":gameID", newGameID));

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
        /// this methode deletes the game from the users have list
        /// </summary>
        /// <param name="userid">userid is the account id from the logged in user</param>
        /// <param name="deleteGameID">the deleteGameID is the id from the game to be deletet from the users havelist</param>
        public void DeleteFromHave(int userid, int newGameID)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE FROM HAVELIST WHERE ACCOUNTID = :userID AND GAMEID = :gameID";
                db.Command.Parameters.Add(new OracleParameter(":userID", userid));
                db.Command.Parameters.Add(new OracleParameter(":gameID", newGameID));

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

        /// <summary>
        /// this methode searches for the game in the users havelist
        /// </summary>
        /// <param name="accountid">userid is the account id from the logged in user</param>
        /// <param name="gameid">the gameid is the id from the game to be found in the have list</param>
        /// <returns>it returns a game object</returns>
        public Game GetHave(int accountid, int gameid)
        {
            Game match = null;
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME G, HAVELIST H WHERE G.GAMEID=H.GAMEID AND H.ACCOUNTID= :userID AND H.GAMEID = :gameID";
                db.Command.Parameters.Add(new OracleParameter(":userID", accountid));
                db.Command.Parameters.Add(new OracleParameter(":gameID", gameid));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["GAMEID"]);
                    string gamename = Convert.ToString(reader["GAMENAME"]);
                    string genrename = Convert.ToString(reader["GENRENAME"]);
                    string themename = Convert.ToString(reader["THEMENAME"]);
                    string platform = Convert.ToString(reader["PLATFORMEN"]);
                    DateTime firstrelease = Convert.ToDateTime(reader["FIRSTRELEASE"]);
                    int rating = Convert.ToInt32(reader["RATING"]);
                    string description = Convert.ToString(reader["DESCRIPTION"]);
                    string designer = Convert.ToString(reader["ONTWERPER"]);
                    string publisher = Convert.ToString(reader["UITGEVER"]);
                    match = new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer);
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
    }
}