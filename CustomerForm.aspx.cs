using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StayBeautifulSMS
{
    public partial class CustomerForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////default data load
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }

        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT Customer_Id, Customer_Name ""Customer Name"", Customer_Address ""Address"", Customer_Contact ""Phone"", Customer_type ""Customer Type"" FROM Customer";
            //cmd.CommandText = "SELECT * FROM [customer]";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("customer");

            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            customerGridView.DataSource = dt;
            customerGridView.DataBind();

        }
    }
}