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
    public partial class InactiveCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        protected void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT cs.customer_id ""Customer_ID"", cs.customer_name ""Name"", cs.customer_address ""Address"", cs.customer_contact ""Customer Contact"", cs.customer_email ""Email"", cs.customer_type ""Customer Type"" FROM Customer cs
                                WHERE cs.customer_id not in ( 
                                    SELECT ps.customer_id FROM Purchase ps
                                    WHERE ps.purchased_date >= CURRENT_TIMESTAMP - 31
                                )
                                ";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("Customers");
            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();
            inactiveCustomerGrid.DataSource = dt;
            inactiveCustomerGrid.DataBind();
        }


    }
}