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
    public partial class Brand : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT Brand_Id, Brand_Name ""Brand Name"" FROM Brand";
            //cmd.CommandText = "SELECT * FROM [customer]";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();
            brandGridView.DataSource = dt;
            brandGridView.DataBind();
        }

        protected void brandGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != brandGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }


        protected void brandGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(brandGridView.DataKeys[e.RowIndex].Values[0]);
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
            
            string brand_name = txtBrandName.Text.ToString();
            
            
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("Insert into Brand(brand_name)VALUES('"+brand_name+"')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtBrandName.Text = "";
                }
            }
            this.BindGrid();
        }

        protected void brandGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void brandGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void brandGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
  
}