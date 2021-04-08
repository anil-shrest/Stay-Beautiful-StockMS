using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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

        protected void stockGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != stockGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";

            }
        }

        protected void stockGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            stockGridView.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void stockGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            stockGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void stockGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = stockGridView.Rows[e.RowIndex];
            int ID = Convert.ToInt32(stockGridView.DataKeys[e.RowIndex].Values[0]);
            string item_id = (row.Cells[2].Controls[0] as TextBox).Text;
            string updated_quantity = (row.Cells[3].Controls[0] as TextBox).Text;
            string date = (row.Cells[4].Controls[0] as TextBox).Text;
            string mfd = (row.Cells[5].Controls[0] as TextBox).Text;
            string exp = (row.Cells[6].Controls[0] as TextBox).Text;
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                OleDbCommand quantity = new OleDbCommand("SELECT updated_quantity FROM Stock WHERE stock_id = " + ID, con);
                con.Open();
                var sdr = quantity.ExecuteReader();
                System.Diagnostics.Debug.WriteLine(sdr);
                sdr.Read();
                int qty = sdr.GetInt32(0);
                while (sdr.Read()){
                    System.Diagnostics.Debug.WriteLine(sdr.GetInt32(0));
                }


                OleDbCommand cmd1 = new OleDbCommand("Update items set available_quantity=available_quantity-" + qty + "+" + updated_quantity + ", stocked_date = CAST('" + date + "' as DATE) where item_id = " + item_id);
                OleDbCommand cmd2 = new OleDbCommand("Update stock set updated_quantity= " + updated_quantity + ", date_of_stock  = CAST ('"+date+ "' as Date) , mfd  = CAST ('" + mfd + "' as Date), exp  = CAST ('" + exp + "' as Date) where stock_id = " + ID);
                    quantity.Connection = con;
                cmd1.Connection = con;
                cmd2.Connection = con;




                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                    con.Close();
                
            }

            stockGridView.EditIndex = -1;
            this.BindGrid();
        }
    }
}