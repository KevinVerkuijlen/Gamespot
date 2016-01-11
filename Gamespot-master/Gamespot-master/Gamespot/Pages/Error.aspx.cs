using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gamespot.Pages
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage_Label.Text = "A problem has occurred on this web site. Please try again later. If this error continues, please contact support.";

            string errorHandler = Request.QueryString["handler"];
            if (errorHandler == null)
            {
                errorHandler = "Error Page";
            }

            Exception ex = Server.GetLastError();

            string errorMsg = Request.QueryString["msg"];
            if (errorMsg == "404")
            {
                ex = new HttpException(404, "An HTTP error occurred. Page Not found. Please try again.", ex);
                ErrorMessage_Label.Text = ex.Message;
            }

            if (ex == null)
            {
                ex = new Exception("The error was unhandled by application code.");
            }

            if (Request.IsLocal)
            {
                Detail_Label.Text = ex.Message;
                
                Source_Label.Text = errorHandler;

                FullErrorDetails_Label.Visible = true;

                if (ex.InnerException != null)
                {
                    FullErrorDetails_Label.Text = ex.GetType().ToString() + "<br/>" +
                        ex.InnerException.Message;
                    FullErrorDetails_Label.Text = ex.InnerException.StackTrace;
                }
                else
                {
                    FullErrorDetails_Label.Text = ex.GetType().ToString();
                    if (ex.StackTrace != null)
                    {
                        FullErrorDetails_Label.Text = ex.StackTrace.ToString().TrimStart();
                    }
                }
            }

            System.Diagnostics.Debug.WriteLine("Exception: " + ex);
            System.Diagnostics.Debug.WriteLine("errorHandler: " + errorHandler);

            Server.ClearError();
        }
    }
}