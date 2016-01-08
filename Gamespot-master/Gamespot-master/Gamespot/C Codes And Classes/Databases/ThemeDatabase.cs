using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Gamespot.C_Codes_And_Classes
{
    public class ThemeDatabase
    {
        Database db = new Database();

        /// <summary>
        /// this methode get all the themes from the database
        /// </summary>
        /// <returns>it retuns a list with theme object from all the themes</returns>
        public List<Theme> AllThemes()
        {
            List<Theme> AllThemes = new List<Theme>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM THEME";

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string themename = Convert.ToString(reader["THEMENAME"]);
                    string themedescription = Convert.ToString(reader["THEMEDESCRIPTION"]);
                    AllThemes.Add(new Theme(themename, themedescription));
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
            return AllThemes;
        }

        /// <summary>
        /// this methode is used to search for a theme in the database
        /// </summary>
        /// <param name="name">this is the name of the theme to search for</param>
        /// <returns>it returns a theme object with the information of the found theme</returns>
        public Theme GetName(string name)
        {
            Theme match = null;
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM THEME WHERE THEMENAME = :name";
                db.Command.Parameters.Add(new OracleParameter(":name", name));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string themename = Convert.ToString(reader["THEMENAME"]);
                    string themedescription = Convert.ToString(reader["THEMEDESCRIPTION"]);
                    match = new Theme(themename, themedescription);
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
        /// this is a methode used to insert a new theme in the database
        /// </summary>
        /// <param name="newtheme">this theme object contains the information for the new theme</param>
        public void InsertTheme(Theme newtheme)
        {
            try
            {
                db.OpenConnection();

                db.Query = "INSERT INTO THEME (THEMENAME, THEMEDESCRIPTION) VALUES (:name, :description)";
                db.Command.Parameters.Add(new OracleParameter(":name", newtheme.ThemeName));
                db.Command.Parameters.Add(new OracleParameter(":description", newtheme.Description));
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
        /// this methode is used to delete a theme from the database
        /// </summary>
        /// <param name="deltetheme">this theme object contains the information of the theme to delete</param>
        public void DelteTheme(string deltetheme)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE THEME WHERE THEMENAME = :name";
                db.Command.Parameters.Add(new OracleParameter(":name", deltetheme));

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