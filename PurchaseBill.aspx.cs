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
    public partial class PurchaseBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SetData();
                BindGrid();
            }
        }

        protected void SetData()
        {
            var id = Request.QueryString["id"];
            lblPID.Text = id;

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            //get customer member type for discount purpose
            OleDbCommand cmdCus = new OleDbCommand();
            cmdCus.Connection = con;
            cmdCus.CommandText = @"SELECT cs.customer_type from Purchase pr inner join Customer cs on pr.customer_id = cs.customer_id where pr.purchase_id = " + id;
            cmdCus.CommandType = CommandType.Text;
            var reader = cmdCus.ExecuteReader();
            System.Diagnostics.Debug.WriteLine(reader);
            reader.Read();
            String type = reader.GetString(0);
            System.Diagnostics.Debug.WriteLine(type);

            int dis;
            if (type == "Regular")
            {
                dis = 10;
            }
            else if (type == "Casual")
            {
                dis = 5;
            }
            else
            {
                dis = 0;
            }

            lblDis.Text = dis.ToString();


            //for total amount
            OleDbCommand cmdtotal = new OleDbCommand();
            cmdtotal.Connection = con;
            cmdtotal.CommandText = @"SELECT pr.Purchase_Id, SUM(pd.purchased_quantity*it.item_price) as ""Total Amount""  from Purchase pr inner join Purchase_Detail pd on pr.purchase_id = pd.purchase_id inner join Items it on pd.item_id = it.item_id where pr.purchase_id = "+id+"group by pr.Purchase_Id ";
            cmdtotal.CommandType = CommandType.Text;
            var sdr1 = cmdtotal.ExecuteReader();
            System.Diagnostics.Debug.WriteLine(sdr1);
            sdr1.Read();
            int total = sdr1.GetInt32(1);
            lblAmount.Text = total.ToString();
            float amount = total - (dis * total / 100);
            lblTotal.Text = amount.ToString();

            //for purchase information
            OleDbCommand cmdInfo = new OleDbCommand();
            cmdInfo.Connection = con;
            cmdInfo.CommandText = @"SELECT pr.Customer_ID, cs.Customer_Name, pr.Purchased_Date, us.user_username from Purchase pr inner join [StockManagement].[dbo].[User] us on us.user_id = pr.user_id inner join Customer cs on cs.Customer_id = pr.customer_id where pr.purchase_id = " + id;
            cmdInfo.CommandType = CommandType.Text;
            var sdr2 = cmdInfo.ExecuteReader();
            System.Diagnostics.Debug.WriteLine(sdr2);
            sdr2.Read();
            int customerId = sdr2.GetInt32(0);
            string customerName = sdr2.GetString(1);
            string pd = Convert.ToString(sdr2.GetDateTime(2));
            string uid = sdr2.GetString(3);

            lblCID.Text = customerId.ToString();
            lblCN.Text = customerName.ToString();
            lblPD.Text = pd;
            lblBill.Text = uid;

        }

        protected void BindGrid()
        {
            var id = Request.QueryString["id"];
            DataTable dt = new DataTable("bill");
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT pr.Purchase_Id, pr.Purchased_date, it.item_id, it.item_price, pd.purchased_quantity, pd.purchased_quantity*it.item_price as ""Line Total"" from Purchase pr inner join Purchase_Detail pd on pr.purchase_id = pd.purchase_id inner join Items it on pd.item_id = it.item_id where pr.purchase_id = "+id+" group by pr.Purchase_Id, pr.Purchased_date, it.item_id, it.item_price, pd.purchased_quantity";
            cmd.CommandType = CommandType.Text;
            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();

            billGridView.DataSource = dt;
            billGridView.DataBind();
        }
    }
}