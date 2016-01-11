using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gamespot
{
    public partial class GameSpot_Master : System.Web.UI.MasterPage
    {
        public C_Codes_And_Classes.Account user;

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminTag.Visible = false;
            user = (C_Codes_And_Classes.Account)Session["globalAccount"];
            if (user != null)
            {
                if (user.AccountType == "admin")
                {
                    AdminTag.Visible = true;
                }
            }
        }

        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server.
            Exception exc = Server.GetLastError();

            Server.Execute("Error.aspx?handler=Page_Error%20-%20GameSpot_Master.Master", true);
        }

        protected void HomeTag_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }
        protected void ReviewTag_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Response.Redirect("ReviewsPostes.aspx");
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }
        protected void NewsTag_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Response.Redirect("NewsPostes.aspx");
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }
        protected void VideoTag_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Response.Redirect("VideosPostes.aspx");
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }        
        protected void ConsoleTag_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Response.Redirect("Consoles.aspx");
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        } 
       
        protected void MyHomeTag_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                Response.Redirect("MyHome.aspx");
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void LogOutTag_Click(object sender, EventArgs e)
        {
            Session["globalAccount"] = null;
            Response.Redirect("LogIn.aspx");
        }

        protected void AdminTag_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                if (user.AccountType == "admin")
                {
                    Response.Redirect("Admin.aspx");
                }
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }
    }
}