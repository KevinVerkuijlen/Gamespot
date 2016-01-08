using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gamespot.C_Codes_And_Classes;

namespace Gamespot.Pages
{
    public partial class LogIn : System.Web.UI.Page
    {
        /// <summary>
        /// all databases the login pages uses
        /// </summary>
        private AccountDatabase AccountDB = new AccountDatabase();
        private Gendre gendre = new Gendre();

        //this event is trigged when the page is being loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
              
            }
            
        }

        //this event will add a new account in the database
        protected void Register_Button_Click(object sender, EventArgs e)
        {
            //check if a gendre is selected
            if (Reg_Gendre_RadioButtonList.SelectedItem != null)
            {
                //check if a country is selected
                if (Reg_Country_DropDownList.SelectedItem != null)
                {
                    //check if the email is already used in the database
                    string email = Reg_Mail_TextBox.Text;
                    Account check = AccountDB.CheckMail(email);
                    if (check == null)
                    {
                        //check if the passwords are the same 
                        if (Reg_Password_TextBox.Text == Reg_CPassword_TextBox.Text)
                        {
                            //get all the information
                            string username = Reg_UserName_TextBox.Text;
                            string password = Reg_Password_TextBox.Text;
                            //check which gendre type is selected
                            if(Reg_Gendre_RadioButtonList.SelectedValue == "Male")
                            {
                                gendre = Gendre.Male;
                            }
                            if (Reg_Gendre_RadioButtonList.SelectedValue == "Female")
                            {
                                gendre = Gendre.Female;
                            }
                            if (Reg_Gendre_RadioButtonList.SelectedValue == "Not importent")
                            {
                                gendre = Gendre.Not_importent;
                            }
                            DateTime birthdate = Convert.ToDateTime(Reg_BirthDate_TextBox.Text);
                            string country = Reg_Country_DropDownList.Text;

                            //create a new account
                            Account newUser = new Account(username, password, email, gendre, country, birthdate);
                            //insert the new account
                            AccountDB.InsertAccount(newUser);
                            //get the account information by logging in
                            Account user = AccountDB.Login(email, password);
                            if (user != null)
                            {
                                //rederict the this his home page
                                Session["globalAccount"] = user;
                                Response.Redirect("MyHome.aspx");
                            }
                        }
                        else
                        {
                            //if the passwords are not the same show error
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You need to enter the same password');</script>");
                        }
                    }
                    else
                    {   
                        //if email is already being used show error
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Email is already in use');</script>");
                    }
                }
                else
                {
                    //if a country is not selected show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You need to select a country');</script>");
                }
            }
            else
            {
                //if a gendre is not selected show error
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('You need to select a gendre option');</script>");
            }
        }

        protected void LogIn_Button_Click(object sender, EventArgs e)
        {
            //get the input information
            string email = Log_Email_TextBox.Text;
            string password = Log_Password_TextBox.Text;

            //check if the account exist in the database
            Account check = AccountDB.CheckMail(email);
            if (check != null)
            {
                //log the user in
                Account user = AccountDB.Login(email, password);
                if (user != null)
                {
                    //if login is correct rederict to users home page
                    Session["globalAccount"] = user;
                    Response.Redirect("MyHome.aspx");
                }
                else
                {
                    //if can not log in show error
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Email and password combination is not correct');</script>");
                }
            }
            else
            {
                //if email does not exist show error
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Email does not exits');</script>");
            }
        }
    }    
}