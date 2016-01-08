using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Gamespot.C_Codes_And_Classes
{
    public class GameDatabase
    {
        Database db = new Database();

        /// <summary>
        /// This methode get all the games from the database
        /// </summary>
        /// <returns>It returns a list with game objects</returns>
        public List<Game> AllGames()
        {
            List<Game> games = new List<Game>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME";

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
                    games.Add(new Game(ID,gamename,genrename,themename,platform,firstrelease,rating,description,publisher,designer));
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
            return games;
        }

        /// <summary>
        /// This methode get all the games from the database which belong to the selected console
        /// </summary>
        /// <param name="consolename">this parameter is the selected console</param> 
        /// <returns>It returns a list with game objects which all contain the console parameter</returns>
        public List<Game> ConsoleGames(string consolename)
        {
            List<Game> ConsoleGames = new List<Game>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME WHERE PLATFORMEN = :console";
                db.Command.Parameters.Add(new OracleParameter(":console", consolename));


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
                    ConsoleGames.Add(new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer));
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
            return ConsoleGames;
        }

        /// <summary>
        /// This methode get all the games from the database which belong to the selected console and is sorted by the rating
        /// </summary>
        /// <param name="consolename">this parameter is the selected console</param>
        /// <returns>It returns a list with game objects which all contain the console parameter sorted by rating</returns>
        public List<Game> TopGames(string consolename)
        {
            List<Game> TopGames = new List<Game>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME WHERE PLATFORMEN= :console ORDER BY RATING";
                db.Command.Parameters.Add(new OracleParameter(":console", consolename));

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
                    TopGames.Add(new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer));
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
            return TopGames;
        }

        /// <summary>
        /// This methode get all the games from the database which belong to the selected console and is sorted by the release date
        /// </summary>
        /// <param name="consolename">this parameter is the selected console</param>
        /// <returns>It returns a list with game objects which all contain the console parameter sorted by the release date</returns>
        public List<Game> NewReleasesGames(string consolename)
        {
            List<Game> NewReleasesGames = new List<Game>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME WHERE PLATFORMEN= :console AND FIRSTRELEASE <= SYSDATE ORDER BY FIRSTRELEASE DESC";
                db.Command.Parameters.Add(new OracleParameter(":console", consolename));

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
                    NewReleasesGames.Add(new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer));
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
            return NewReleasesGames;
        }

        /// <summary>
        /// This methode get all the games from the database which belong to the selected console and have not been released yet
        /// </summary>
        /// <param name="consolename">this parameter is the selected console</param>
        /// <returns>It returns a list with game objects which all contain the console parameter and have not been released yet</returns>
        public List<Game> ComingGames(string consolename)
        {
            List<Game> ComingGames = new List<Game>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME WHERE PLATFORMEN= :console AND FIRSTRELEASE >= SYSDATE ORDER BY FIRSTRELEASE DESC";
                db.Command.Parameters.Add(new OracleParameter(":console", consolename));

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
                    ComingGames.Add(new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer));
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
            return ComingGames;
        }


        /// <summary>
        /// This methode gets all the games from the database which contain the selected theme
        /// </summary>
        /// <param name="Theme">this parameter is the selected Theme</param>
        /// <param name="consolename">this parameter is the selected Console</param>
        /// <returns>It returns a list with game objects which all contain the selected theme and console</returns>
        public List<Game> ThemeGames(string Theme, string consolename)
        {
            List<Game> ThemeGames = new List<Game>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME WHERE THEMENAME= :theme AND PLATFORMEN= :console ORDER BY GAMENAME";
                db.Command.Parameters.Add(new OracleParameter(":theme", Theme));
                db.Command.Parameters.Add(new OracleParameter(":console", consolename));

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
                    ThemeGames.Add(new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer));
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
            return ThemeGames;
        }

        /// <summary>
        /// This methode gets all the games from the database which contain the selected genre
        /// </summary>
        /// <param name="Theme">this parameter is the selected genre</param>
        /// <param name="consolename">this parameter is the selected Console</param>
        /// <returns>It returns a list with game objects which all contain the selected genre and console</returns>
        public List<Game> GenreGames(string Genre, string consolename)
        {
            List<Game> GenreGames = new List<Game>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME WHERE GENRENAME= :theme AND PLATFORMEN= :console ORDER BY GAMENAME";
                db.Command.Parameters.Add(new OracleParameter(":genre", Genre));
                db.Command.Parameters.Add(new OracleParameter(":console", consolename));

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
                    GenreGames.Add(new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer));
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
            return GenreGames;
        }

        /// <summary>
        /// This methode gets all the games from the database which contain the selected genre
        /// </summary>
        /// <param name="Genre">this parameter is the selected genre</param>
        /// <param name="Theme">this parameter is the selected theme</param>
        /// <param name="consolename">this parameter is the selected Console</param>
        /// <returns>It returns a list with game objects which all contain the selected genre, theme and console</returns>
        public List<Game> GenreAndThemeGames(string Genre, string Theme, string consolename)
        {
            List<Game> GenreGames = new List<Game>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME WHERE GENRENAME= :Genre AND THEMENAME = :Theme AND PLATFORMEN= :console ORDER BY GAMENAME";
                db.Command.Parameters.Add(new OracleParameter(":genre", Genre));
                db.Command.Parameters.Add(new OracleParameter(":theme", Theme));
                db.Command.Parameters.Add(new OracleParameter(":console", consolename));

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
                    GenreGames.Add(new Game(ID, gamename, genrename, themename, platform, firstrelease, rating, description, publisher, designer));
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
            return GenreGames;
        }

        /// <summary>
        /// This method search for the game by its id and returns an object of it.
        /// </summary>
        /// <param name="id">This is the id which will be used for searching</param>
        /// <returns>It returns a game object</returns>
        public Game GetGame(int id)
        {
            Game match = null;

            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME WHERE GAMEID = :id";
                db.Command.Parameters.Add(new OracleParameter(":id", id));

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
        /// this method searchs for a game which matches the gamename and platform
        /// </summary>
        /// <param name="name">this is the name which will be used to search</param>
        /// <param name="plat">this is the platform which will be used to search</param>
        /// <returns>it returns a game which contains the same name and platform</returns>
        public Game GetGame(string name, string plat)
        {
            Game match = null;

            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GAME WHERE GAMENAME = :name AND PLATFORMEN = :plat";
                db.Command.Parameters.Add(new OracleParameter(":name", name));
                db.Command.Parameters.Add(new OracleParameter(":plat", plat));

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
        /// whit this method a new game will be inserted in the database
        /// </summary>
        /// <param name="newgame">this is an object which contains all the information for the new game</param>
        public void Insertgame(Game newgame)
        {
            try
            {
                db.OpenConnection();

                db.Query = "INSERT INTO GAME (GAMEID,GAMENAME, GENRENAME, THEMENAME, PLATFORMEN, FIRSTRELEASE, RATING, DESCRIPTION, ONTWERPER, UITGEVER) VALUES(seq_Game.nextval, :gamename, :genrename, :themename, :platform, :firstrelease, :rating, :description, :designer, :publisher)";
                db.Command.Parameters.Add(new OracleParameter(":gamename", newgame.GameName));
                db.Command.Parameters.Add(new OracleParameter(":genrename", newgame.GenreName));
                db.Command.Parameters.Add(new OracleParameter(":themename", newgame.ThemeName));
                db.Command.Parameters.Add(new OracleParameter(":platform", newgame.Platform));
                db.Command.Parameters.Add(new OracleParameter(":firstrelease", newgame.FirstRelease.ToShortDateString()));
                db.Command.Parameters.Add(new OracleParameter(":rating", newgame.Rating));
                db.Command.Parameters.Add(new OracleParameter(":description", newgame.Description));
                db.Command.Parameters.Add(new OracleParameter(":designer", newgame.Designer));
                db.Command.Parameters.Add(new OracleParameter(":publisher", newgame.Publisher));

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
        /// this is a method which will delete a game from the database
        /// </summary>
        /// <param name="deltegame">this is a object which contains the information of the game to delete</param>
        public void Deletegame(Game deltegame)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE FROM GAME WHERE GAMEID = :id";
                db.Command.Parameters.Add(new OracleParameter(":id", deltegame.ID));
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