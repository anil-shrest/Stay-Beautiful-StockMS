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
    public partial class StockForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            cmd.CommandText = @"SELECT stock_id ""Stock ID"", item_id ""Item ID"", updated_quantity ""Updated Quantity"", date_of_stock ""Date of Stock"", mfd ""Manufactured Date"", exp ""Expiry Date""  FROM Stock";
            //cmd.CommandText = "SELECT * FROM [customer]";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("stock");
            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();
            stockGridView.DataSource = dt;
            stockGridView.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(DropDownList1.SelectedValue);
            int quantity = Convert.ToInt32(txtUpdatedQuantity.Text);
            string date = txtDateOfStock.Text.ToString();
            string mfd = txtMfd.Text.ToString();
            string exp = txtExp.Text.ToString();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


            using (OleDbConnection con = new OleDbConnection(constr))
            {
                OleDbCommand cmd1 = new OleDbCommand("Insert into Stock(item_id, updated_quantity, date_of_stock, mfd, exp) Values(" + itemId + "," + quantity + ", CAST('" + date + "' as DATE), CAST('" + mfd + "'as DATE), CAST('" + exp + "' as DATE))");
                OleDbCommand cmd2 = new OleDbCommand("Update Items SET stocked_date = CAST('" + date + "' as DATE), available_quantity = available_quantity + '" + quantity + "' WHERE item_id = '" + itemId + "'");
                cmd1.Connection = con;
                cmd2.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();


                txtUpdatedQuantity.Text = "";
                txtDateOfStock.Text = "";
                txtMfd.Text = "";
                txtExp.Text = "";

            }

            this.BindGrid();
        }

    }
}