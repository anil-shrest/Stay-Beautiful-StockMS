using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StayBeautifulSMS
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void signupBtn_ServerClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Hi");
            string name = Request.Form["txtSignUpName"];
            string username = Request.Form["txtSignUpUsername"];
            string address = Request.Form["txtSignUpAddress"];
            string contact = Request.Form["txtSignUpContact"];
            string email = Request.Form["txtSignUpEmail"];
            string password1 = Request.Form["txtSignUpPassword1"];
            string password2 = Request.Form["txtSignUpPassword2"];

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            if (password1 == password2)
            {
                using (OleDbConnection con = new OleDbConnection(constr))
                {
                    using (OleDbCommand cmd = new OleDbCommand("Insert into [StockManagement].[dbo].[User] (user_name, user_address, user_contact, user_username, user_email, user_password, user_type) Values('" + name + "', '"+address+"','"+contact+"', '"+username+"','"+email+"','"+password1+"', 'Staff')"))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                    }
                }
            }
            else
            {
                string script = "alert(\"Password Fields Do Not Match!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                System.Diagnostics.Debug.WriteLine("Password Fields Do Not Match");
            }
            
        }
    }
}