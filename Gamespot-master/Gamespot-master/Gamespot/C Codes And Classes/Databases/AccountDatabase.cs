using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Gamespot.C_Codes_And_Classes
{
    public class AccountDatabase
    {
        Database db = new Database();

        /// <summary>
        /// This method checks if the email is already being used in the database
        /// </summary>
        /// <param name="mail">This is the parameter with the email to check</param>
        /// <returns>if a match is found return a account object which has the mail</returns>
        public Account CheckMail(string mail)
        {
            Account match = null;
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM ACCOUNT WHERE EMAIL_ADRESS = :mail";
                db.Command.Parameters.Add(new OracleParameter(":mail", mail));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    string userName = Convert.ToString(reader["USERNAME"]);
                    string password = Convert.ToString(reader["PASSWORD"]);
                    string Email = Convert.ToString(reader["EMAIL_ADRESS"]);
                    string type = Convert.ToString(reader["ACCOUNTTYPE"]);
                    string gendre = Convert.ToString(reader["GENDRE"]);
                    string Country = Convert.ToString(reader["COUNTRY"]);
                    DateTime Birthdate = Convert.ToDateTime(reader["BIRTHDATE"]);
                    C_Codes_And_Classes.Gendre gendreType = C_Codes_And_Classes.Gendre.Not_importent;
                    if (gendre == "Male")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Male;
                    }
                    if (gendre == "Female")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Female;
                    }
                    if (gendre == "Not importent")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Not_importent;
                    }
                    match = new Account(accountID, userName, password, Email, type, gendreType, Country, Birthdate);
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
        /// This method searches for an account by its ID in the database
        /// </summary>
        /// <param name="id">this is the id used for searching</param>
        /// <returns>if an account whit the ID is found return an account object</returns>
        public Account GetBy(int id)
        {
            Account match = null;
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM ACCOUNT WHERE ACCOUNTID = :id";
                db.Command.Parameters.Add(new OracleParameter(":id", id));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    string userName = Convert.ToString(reader["USERNAME"]);
                    string password = Convert.ToString(reader["PASSWORD"]);
                    string Email = Convert.ToString(reader["EMAIL_ADRESS"]);
                    string type = Convert.ToString(reader["ACCOUNTTYPE"]);
                    string gendre = Convert.ToString(reader["GENDRE"]);
                    string Country = Convert.ToString(reader["COUNTRY"]);
                    DateTime Birthdate = Convert.ToDateTime(reader["BIRTHDATE"]);
                    C_Codes_And_Classes.Gendre gendreType = C_Codes_And_Classes.Gendre.Not_importent;
                    if (gendre == "Male")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Male;
                    }
                    if (gendre == "Female")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Female;
                    }
                    if (gendre == "Not importent")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Not_importent;
                    }
                    match = new Account(accountID, userName, password, Email, type, gendreType, Country, Birthdate);
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
        /// this method is used for an account to login, it checks if an account whit this email and password 
        /// combination exist in the database
        /// </summary>
        /// <param name="mail">this is the mail the user uses to login</param>
        /// <param name="Pass">this is the password the user uses to login</param>
        /// <returns>if an account with the combination exist return an account object with the account information</returns>
        public Account Login(string mail, string Pass)
        {
            Account login = null;
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM ACCOUNT WHERE EMAIL_ADRESS = :mail AND PASSWORD = :pass";
                db.Command.Parameters.Add(new OracleParameter(":mail", mail));
                db.Command.Parameters.Add(new OracleParameter(":pass", Pass));

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    string userName = Convert.ToString(reader["USERNAME"]);
                    string password = Convert.ToString(reader["PASSWORD"]);
                    string Email = Convert.ToString(reader["EMAIL_ADRESS"]);
                    string type = Convert.ToString(reader["ACCOUNTTYPE"]);
                    string gendre = Convert.ToString(reader["GENDRE"]);
                    string Country = Convert.ToString(reader["COUNTRY"]);
                    DateTime Birthdate = Convert.ToDateTime(reader["BIRTHDATE"]);
                    C_Codes_And_Classes.Gendre gendreType = C_Codes_And_Classes.Gendre.Not_importent;
                    if (gendre == "Male")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Male;
                    }
                    if (gendre == "Female")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Female;
                    }
                    if (gendre == "Not importent")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Not_importent;
                    }
                    login = new Account(accountID, userName, password, Email, type, gendreType, Country, Birthdate);
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
            return login;
        }

        /// <summary>
        /// this is a method to get all accounts from the database
        /// </summary>
        /// <returns>it returns a list with account objects from all accounts</returns>
        public List<Account> allAccounts()
        {
            List<Account> allAccounts = new List<Account>();
            try
            {
                db.OpenConnection();
                db.Query = "SELECT * FROM ACCOUNT";

                OracleDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    int accountID = Convert.ToInt32(reader["ACCOUNTID"]);
                    string userName = Convert.ToString(reader["USERNAME"]);
                    string password = Convert.ToString(reader["PASSWORD"]);
                    string Email = Convert.ToString(reader["EMAIL_ADRESS"]);
                    string type = Convert.ToString(reader["ACCOUNTTYPE"]);
                    string gendre = Convert.ToString(reader["GENDRE"]);
                    C_Codes_And_Classes.Gendre gendreType = C_Codes_And_Classes.Gendre.Not_importent;
                    if (gendre == "Male")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Male;
                    }
                    if (gendre == "Female")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Female;
                    }
                    if (gendre == "Not importent")
                    {
                        gendreType = C_Codes_And_Classes.Gendre.Not_importent;
                    }
                    string Country = Convert.ToString(reader["COUNTRY"]);
                    DateTime Birthdate = Convert.ToDateTime(reader["BIRTHDATE"]);
                    allAccounts.Add(new Account(accountID, userName, password, Email, type, gendreType, Country, Birthdate));
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
            return allAccounts;
        }

        /// <summary>
        /// this method inserts a new account in the database
        /// </summary>
        /// <param name="newaccount">this parameter contains a new account object with all the needed information</param>
        public void InsertAccount(Account newaccount)
        {
            try
            {
                db.OpenConnection();
                db.Query = "ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS'";
                db.Command.ExecuteNonQuery();

                db.Query = "INSERT INTO ACCOUNT (AccountID, Password, UserName, Gendre, Birthdate, Email_Adress, Country) VALUES (seq_Account.nextval, :password, :username, :gendre, TO_DATE(:birthdate,'DD-MM-YYYY'), :email, :country)";
                db.Command.Parameters.Add(new OracleParameter(":password", newaccount.Password));
                db.Command.Parameters.Add(new OracleParameter(":username", newaccount.UserName));
                db.Command.Parameters.Add(new OracleParameter(":gendre", newaccount.GendreType.ToString()));
                db.Command.Parameters.Add(new OracleParameter(":birthdate", newaccount.Birthdate.ToShortDateString()));
                db.Command.Parameters.Add(new OracleParameter(":email", newaccount.Email));
                db.Command.Parameters.Add(new OracleParameter(":country", newaccount.Country));
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
        /// this method updates an account information in the database
        /// </summary>
        /// <param name="changedaccount">This parameter contains a new account object with the changed account information</param>
        public void UpdateAccount(Account changedaccount)
        {
            try
            {
                db.OpenConnection();
                db.OpenConnection();
                db.Query = "ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS'";
                db.Command.ExecuteNonQuery();

                db.Query = "UPDATE ACCOUNT SET PASSWORD=:password, USERNAME=:username, GENDRE=:gendre, EMAIL_ADRESS=:email, BIRTHDATE=TO_DATE(:birthdate,'DD-MM-YYYY'), COUNTRY=:country WHERE ACCOUNTID=:id";
                db.Command.Parameters.Add(new OracleParameter(":password", changedaccount.Password));
                db.Command.Parameters.Add(new OracleParameter(":username", changedaccount.UserName));
                db.Command.Parameters.Add(new OracleParameter(":gendre", changedaccount.GendreType.ToString()));
                db.Command.Parameters.Add(new OracleParameter(":email", changedaccount.Email));
                db.Command.Parameters.Add(new OracleParameter(":birthdate", changedaccount.Birthdate.ToShortDateString()));  
                db.Command.Parameters.Add(new OracleParameter(":country", changedaccount.Country));
                db.Command.Parameters.Add(new OracleParameter(":id", changedaccount.ID));
                db.Command.ExecuteNonQuery();
            }
            catch (OracleException e)
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
        /// this methode deletes an account from the database
        /// </summary>
        /// <param name="deleteaccount">this parameter contains the account object with the information to delete</param>
        public void DelteAccount(Account deleteaccount)
        {
            try
            {
                db.OpenConnection();

                db.Query = "DELETE FROM ACCOUNT WHERE ACCOUNTID = :id";
                db.Command.Parameters.Add(new OracleParameter(":id", deleteaccount.ID));
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