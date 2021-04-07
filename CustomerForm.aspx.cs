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
            cmd.CommandText = @"SELECT Customer_Id, Customer_Name ""Customer Name"", Customer_Address ""Address"", Customer_Contact ""Phone"", Customer_email ""Email"", Customer_type ""Customer Type"" FROM Customer";
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtCustomertName.Text.ToString();
            string address = txtCustomerAddress.Text.ToString();
            string phone = txtCustomerPhone.Text.ToString();
            string email = txtCustomerEmail.Text.ToString();
            string type = txtCustomerType.Text.ToString();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("INSERT INTO Customer(Customer_Name, Customer_Address, Customer_Contact, Customer_Email, Customer_Type)" +
                    "Values('" + name + "','" + address + "','" + phone + "','" + email + "','" + type + "')"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtCustomertName.Text = "";
                    txtCustomerAddress.Text = "";
                    txtCustomerPhone.Text = "";
                    txtCustomerEmail.Text = "";
                    txtCustomerType.Text = "";

                }

            }

            this.BindGrid();
        }

        protected void customerGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != customerGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void customerGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            customerGridView.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void customerGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            customerGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void customerGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = customerGridView.Rows[e.RowIndex];
            int ID = Convert.ToInt32(customerGridView.DataKeys[e.RowIndex].Values[0]);
            string Name = (row.Cells[2].Controls[0] as TextBox).Text;
            string Address = (row.Cells[3].Controls[0] as TextBox).Text;
            string Phone = (row.Cells[4].Controls[0] as TextBox).Text;
            string Email = (row.Cells[5].Controls[0] as TextBox).Text;
            string Type = (row.Cells[5].Controls[0] as TextBox).Text;
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("UPDATE Customer set Customer_Name = '" + Name + "',Customer_Address = '" + Address + "',Customer_Contact = '" + Phone + "', Customer_Email = '" + Email + "', Customer_Type = '" + Type + "' where Customer_Id = " + ID))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            customerGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void customerGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int ID = Convert.ToInt32(customerGridView.DataKeys[e.RowIndex].Values[0]);
            //string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //using (OleDbConnection con = new OleDbConnection(constr))
            //{
            //    using (OleDbCommand cmd = new OleDbCommand("UPDATE Orders SET Customer_ID = null WHERE Order_Number IN (SELECT order_number FROM Orders WHERE customer_id =" + ID + ")"))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //    using (OleDbCommand cmd = new OleDbCommand("DELETE FROM Customer WHERE Customer_Id =" + ID))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}
            //this.BindGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtCustomertName.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerPhone.Text = "";
            txtCustomerEmail.Text = "";
            txtCustomerType.Text = "";
        }

        //protected void btninsert_Click(object sender, EventArgs e)
        //{
        //    string name = txtCustomertName.Text.ToString();
        //    string address = txtCustomerAddress.Text.ToString();
        //    string phone = txtCustomerPhone.Text.ToString();
        //    string email = txtCustomerEmail.Text.ToString();
        //    string type = txtCustomerType.Text.ToString();

        //    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //    using (OleDbConnection con = new OleDbConnection(constr))
        //    {
        //        using (OleDbCommand cmd = new OleDbCommand("INSERT INTO Customer(Customer_Name, Customer_Address, Customer_Contact, Customer_Email, Customer_Type)" +
        //            "Values('" + name + "','" + address + "','" + phone + "','" + email + "','" + type + "')"))
        //        {

        //            cmd.Connection = con;
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //            txtCustomertName.Text = "";
        //            txtCustomerAddress.Text = "";
        //            txtCustomerPhone.Text = "";
        //            txtCustomerEmail.Text = "";
        //            txtCustomerType.Text = "";

        //        }

        //    }

        //    this.BindGrid();
        //}

        //protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        //{


        //}

        //protected void OnRowCancelingEdit(object sender, EventArgs e)
        //{
        //    //customerGridView.EditIndex = -1;
        //    this.BindGrid();
        //}

        //protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    //int ID = Convert.ToInt32(customerGridView.DataKeys[e.RowIndex].Values[0]);
        //    //string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //    //using (OleDbConnection con = new OleDbConnection(constr))
        //    //{
        //    //    using (OleDbCommand cmd = new OleDbCommand("UPDATE Orders SET Customer_ID = null WHERE Order_Number IN (SELECT order_number FROM Orders WHERE customer_id =" + ID + ")"))
        //    //    {
        //    //        cmd.Connection = con;
        //    //        con.Open();
        //    //        cmd.ExecuteNonQuery();
        //    //        con.Close();
        //    //    }
        //    //    using (OleDbCommand cmd = new OleDbCommand("DELETE FROM Customer WHERE Customer_Id =" + ID))
        //    //    {
        //    //        cmd.Connection = con;
        //    //        con.Open();
        //    //        cmd.ExecuteNonQuery();
        //    //        con.Close();
        //    //    }
        //    //}
        //    this.BindGrid();
        //}

        //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != customerGridView.EditIndex)
        //    //{
        //    //    (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        //    //}

        //}

        //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    //customerGridView.EditIndex = e.NewEditIndex;
        //    this.BindGrid();
        //}

        //protected void customerGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = customerGridView.Rows[e.RowIndex];
        //    int ID = Convert.ToInt32(customerGridView.DataKeys[e.RowIndex].Values[0]);
        //    string Name = (row.Cells[2].Controls[0] as TextBox).Text;
        //    string Address = (row.Cells[3].Controls[0] as TextBox).Text;
        //    string Phone = (row.Cells[4].Controls[0] as TextBox).Text;
        //    string Email = (row.Cells[5].Controls[0] as TextBox).Text;
        //    string Type = (row.Cells[5].Controls[0] as TextBox).Text;
        //    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //    using (OleDbConnection con = new OleDbConnection(constr))
        //    {
        //        using (OleDbCommand cmd = new OleDbCommand("UPDATE Customer set Customer_Name = '" + Name + "',Customer_Address = '" + Address + "',Customer_Contact = '" + Phone + "', Customer_Email = '" + Email + "', Customer_Type = '" + Type + "' where Customer_Id = " + ID))
        //        {
        //            cmd.Connection = con;
        //            con.Open();

        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }

        //    customerGridView.EditIndex = -1;
        //    this.BindGrid();
        //}
    }
}