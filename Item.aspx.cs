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
    public partial class Item : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT Item_Id, Item_Name ""Brand Name"", Item_Description ""Item Description"",Convert(varchar,stocked_date,23) ""Stocked Date"", available_quantity ""Available Quantity"", item_price ""Item Price"" FROM Items";
            //cmd.CommandText = "SELECT * FROM [customer]";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();
            itemGridView.DataSource = dt;
            itemGridView.DataBind();
        }

        protected void itemGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != itemGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void itemGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            itemGridView.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void itemGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = itemGridView.Rows[e.RowIndex];
            int ID = Convert.ToInt32(itemGridView.DataKeys[e.RowIndex].Values[0]);
            string itemName = (row.Cells[2].Controls[0] as TextBox).Text;
            string itemDescription = (row.Cells[3].Controls[0] as TextBox).Text;
            string stockedDate = (row.Cells[4].Controls[0] as TextBox).Text;
            int availableQuantity = Convert.ToInt32((row.Cells[5].Controls[0] as TextBox).Text);
            int itemPrice = Convert.ToInt32((row.Cells[6].Controls[0] as TextBox).Text);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("UPDATE Items SET item_name = '" + itemName + "', item_description = '" + itemDescription + "', stocked_date= CAST('" + stockedDate + "' as Date), available_quantity="+ availableQuantity+",item_price="+ itemPrice+"  WHERE item_id = " + ID))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            itemGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void itemGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            itemGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void itemGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(itemGridView.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("update Items set brand_id=null where item_id in (select item_id from Items where brand_id=" + ID + ")"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                using (OleDbCommand cmd = new OleDbCommand("DELETE FROM Brand WHERE Brand_Id =" + ID))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {

            string itemName = txtItemName.Text.ToString();
            string itemDescription = txtItemDescription.Text.ToString();
            string stockedDate = txtStockDate.Text.ToString();
            int availableQuantity = Convert.ToInt32(txtAvailableQuantity.Text);
            int itemPrice = Convert.ToInt32(txtItemRate.Text);


            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("Insert into Items(item_name,item_description,stocked_date,available_quantity,item_price)VALUES('" + itemName + "','"+itemDescription+"', CAST('"+ stockedDate+"' as DATE),"+availableQuantity+","+itemPrice+")"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtItemName.Text = "";
                    txtItemDescription.Text = "";
                    txtStockDate.Text= "";
                    txtAvailableQuantity.Text = "";
                    txtItemRate.Text = "";
                }
            }
            this.BindGrid();
        }
    }
}