using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Gamespot.C_Codes_And_Classes
{
    public class ConsoleDatabase
    {
        Database db = new Database();

        /// <summary>
        /// This methode gets all consoles from the databas
        /// </summary>
        /// <returns>it returns a list with console objects for all consoles</returns>
        public List<Console> AllConsoles()
        {
            List<Console> AllConsoles = new List<Console>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM CONSOLE";

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string consolenameid = Convert.ToString(reader["CONSOLENAMEID"]);
                    string consoletype = Convert.ToString(reader["CONSOLE_TYPE"]);
                    string description = Convert.ToString(reader["DESCRIPTION"]);
                    AllConsoles.Add(new Console(consolenameid, consoletype, description));
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
            return AllConsoles;
        }

        /// <summary>
        /// this method is used to search in the database for the console with the same name
        /// </summary>
        /// <param name="nameid">this parameter contains to name to search for</param>
        /// <returns>it returns an console object which hase the samen name as the parameter</returns>
        public Console GetConsole(string nameid)
        {
            Console match = null;
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM CONSOLE WHERE CONSOLENAMEID = :nameID";
                db.Command.Parameters.Add(new OracleParameter(":nameID", nameid));


                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    string consolenameid = Convert.ToString(reader["CONSOLENAMEID"]);
                    string consoletype = Convert.ToString(reader["CONSOLE_TYPE"]);
                    string description = Convert.ToString(reader["DESCRIPTION"]);
                    match = new Console(consolenameid, consoletype, description);
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
        /// This method is used to insert a new console in the database
        /// </summary>
        /// <param name="newconsole">this conosle object contains all the information for the new console</param>
        public void InsertConsole(Console newconsole)
        {
            try
            {
                db.OpenConnection();

                db.Query = "INSERT INTO CONSOLE (CONSOLENAMEID, CONSOLE_TYPE,DESCRIPTION) VALUES (:consolenameID, :consoletype, :description)";
                db.Command.Parameters.Add(new OracleParameter(":consolenameID", newconsole.ConsoleNameID));
                db.Command.Parameters.Add(new OracleParameter(":consoletype", newconsole.ConsoleType));
                db.Command.Parameters.Add(new OracleParameter(":description", newconsole.Description));
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
        /// this methode deletes a console from the database
        /// </summary>
        /// <param name="delteconsole"> this console object contains the information of the console to delete</param>
        public void DelteConsole(Console delteconsole)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE CONSOLE WHERE CONSOLENAMEID = :consolenameID";
                db.Command.Parameters.Add(new OracleParameter(":consolenameID", delteconsole.ConsoleNameID));
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