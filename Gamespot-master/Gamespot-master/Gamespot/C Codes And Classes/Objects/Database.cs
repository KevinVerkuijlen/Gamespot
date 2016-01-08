using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Gamespot.C_Codes_And_Classes
{
    public class Database
    {
        private static readonly string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=GAMESPOT;Password=GAMESPOT";
        private static OracleCommand command;
        public OracleConnection connection;

        public string Query
        {
            set
            {
                command = new OracleCommand(value, connection);
            }
        }

        public OracleCommand Command
        {
            get
            {
                return command;
            }
        }

        public OracleConnection OpenConnection()
        {

            connection = new OracleConnection(connectionString);
            try
            {
                // Check if the connection is already open
                connection.Open();
            }
            catch (OracleException)
            {
                throw;
            }
            return connection;
        }

        /// <summary>
        /// close the connection
        /// </summary>
        public void CloseConnection()
        {
            // check if the connection is already close
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        public void Commit()
        {
            using (OracleConnection connection = OpenConnection())
            {
                string query = "commit";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (OracleException)
                    {
                        // Unexpected error: rethrow to let the caller handle it
                        throw;
                    }
                }
            }
        }
    }
}