using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace StayBeautifulSMS
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void signupBtn_ServerClick(object sender, EventArgs e)
        {
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
                    using (OleDbCommand cmd = new OleDbCommand("Insert into [StockManagement].[dbo].[User] (user_name, user_address, user_contact, user_username, user_email, user_password, user_type) Values('" + name + "', '" + address + "','" + contact + "', '" + username + "','" + email + "','" + password1 + "', 'Staff')"))
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

        protected void btnSignIn_ServerClick(object sender, EventArgs e)
        {
            string email = Request.Form["txtEmail"];
            string pw = Request.Form["txtPassword"];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string password;
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT user_password FROM [StockManagement].[dbo].[User] WHERE user_email = '" + email + "'"))
                {
                    cmd.Connection = con;
                    con.Open();
                    var pwd = cmd.ExecuteReader();
                    pwd.Read();
                    password = pwd["user_password"].ToString();
                    con.Close();
                }
            }

            
            if (password == pw)
            {
                lowStock(email); //trigger function to check for any items running out of stock and show popup message
                //remove FormsAuthentication from here
            }
        }

        protected void lowStock(string email)
        {
            List<string> lowStock = new List<string>();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"Select item_id, item_name from Items where available_quantity < 10";
            var low = cmd.ExecuteReader();
            while (low.Read())
            {
                var id = low.GetInt32(0);
                var name = low.GetString(1);
                lowStock.Add(name);
                System.Diagnostics.Debug.WriteLine("ID:" + id.ToString() + "Item:" + name);
            }

            if (lowStock.Count() > 0)
            {
                System.Diagnostics.Debug.WriteLine("Not Empty");
                string script = "alert(\"Items running out of stock.\");window.location ='stockform.aspx';"; //replace stockform.aspx with low stock form

                ScriptManager.RegisterStartupScript(this.Page, GetType(), "OpenModalDialog", script, true);
                FormsAuthentication.SetAuthCookie(email, true);
            }
            else
            {
                FormsAuthentication.RedirectFromLoginPage(email, true);
            }

        }
    }
}