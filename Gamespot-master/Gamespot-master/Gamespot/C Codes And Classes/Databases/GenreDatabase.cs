using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Gamespot.C_Codes_And_Classes
{
    public class GenreDatabase
    {
        Database db = new Database();

        /// <summary>
        /// this methode get all the genres from the database
        /// </summary>
        /// <returns>it retuns a list with genre object from all the genres</returns>
        public List<Genre> AllGenres()
        {
            List<Genre> AllGenres = new List<Genre>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GENRE";

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                   string genrename = Convert.ToString(reader["GENRENAME"]);
                   string genredescription  = Convert.ToString(reader["GENREDESCRIPTION"]);
                   AllGenres.Add(new Genre(genrename,genredescription));
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
            return AllGenres;
        }

        /// <summary>
        /// this methode is used to search for a genre in the database
        /// </summary>
        /// <param name="name">this is the name of the genre to search for</param>
        /// <returns>it returns a genre object with the information of the found genre</returns>
        public Genre GetName(string name)
        {
            Genre match = null;
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM GENRE WHERE GENRENAME = :name";
                db.Command.Parameters.Add(new OracleParameter(":name", name));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string genrename = Convert.ToString(reader["GENRENAME"]);
                    string genredescription = Convert.ToString(reader["GENREDESCRIPTION"]);
                    match = new Genre(genrename, genredescription);
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
        /// this is a methode used to insert a new genre in the database
        /// </summary>
        /// <param name="newgenre">this genre object contains the information for the new genre</param>
        public void InsertGenre(Genre newgenre)
        {
            try
            {
                db.OpenConnection();

                db.Query = "INSERT INTO GENRE (GENRENAME, GENREDESCRIPTION) VALUES (:name, :description)";
                db.Command.Parameters.Add(new OracleParameter(":name", newgenre.GenreName));
                db.Command.Parameters.Add(new OracleParameter(":description", newgenre.Description));
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
        /// this methode is used to delete a genre from the database
        /// </summary>
        /// <param name="deltegenre">this gerne object contains the information of the genre to delete</param>
        public void DelteGenre(string deltegenre)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE GENRE WHERE GENRENAME = :name";
                db.Command.Parameters.Add(new OracleParameter(":name", deltegenre));
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