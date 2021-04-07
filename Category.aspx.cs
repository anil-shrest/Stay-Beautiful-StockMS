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
    public partial class Category : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT Category_Id, Category_Name ""Category Name"" FROM Category";
            //cmd.CommandText = "SELECT * FROM [customer]";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("category");
            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();
            categoryGridView.DataSource = dt;
            categoryGridView.DataBind();
        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            //insert code
            //get data from from

            string categoryName = txtCategoryName.Text.ToString();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
           

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("Insert into Category(category_name) Values('" + categoryName + "')"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtCategoryName.Text = "";
                }
            }

            this.BindGrid();
        }

        protected void categoryGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != categoryGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";

            }
        }

        protected void categoryGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            categoryGridView.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void categoryGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            categoryGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void categoryGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = categoryGridView.Rows[e.RowIndex];
            int ID = Convert.ToInt32(categoryGridView.DataKeys[e.RowIndex].Values[0]);
            string categoryName = (row.Cells[2].Controls[0] as TextBox).Text;
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("Update Category SET Category_Name = '" + categoryName + "' where category_id = " + ID))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            categoryGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void categoryGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(categoryGridView.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                OleDbCommand cmd1 = new OleDbCommand("UPDATE Items SET category_id = NULL WHERE category_id = " + ID);
                OleDbCommand cmd2 = new OleDbCommand("DELETE FROM Category WHERE category_id = " + ID);
                cmd1.Connection = con;
                cmd2.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            this.BindGrid();
        }
    }
}