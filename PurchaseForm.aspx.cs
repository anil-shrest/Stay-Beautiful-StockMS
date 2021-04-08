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
    public partial class PurchaseForm : System.Web.UI.Page
    {
        static List<Dictionary<string, int>> purchase_items = new List<Dictionary<string, int>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
         
        }

        
        protected void btnItemAdd_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> detail = new Dictionary<string, int>();
            int item = Convert.ToInt32(itemDDL.Text);
            int quantity = Convert.ToInt32(txQuantity.Text);

            //check availability of quantity of requested item
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT available_quantity  FROM Items WHERE item_id = " + item;
            cmd.CommandType = CommandType.Text;
            var sdr = cmd.ExecuteReader();
            System.Diagnostics.Debug.WriteLine(sdr);
            sdr.Read();
            int qty = sdr.GetInt32(0);
            if(qty >= quantity)
            {
                detail.Add("item", item);
                detail.Add("quantity", quantity);
                purchase_items.Add(detail);
                foreach (Dictionary<String, int> it in purchase_items)
                {
                    System.Diagnostics.Debug.WriteLine(it["item"]);
                    System.Diagnostics.Debug.WriteLine(it["quantity"]);

                }
                this.BindGrid();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Item quantity specified not available.");
            }
            
            
            //System.Diagnostics.Debug.WriteLine(purchase_items);

        }

        protected void BindGrid()
        {
            DataTable dt = new DataTable("items");
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            foreach (Dictionary<string, int> entry in purchase_items)
            {
                int id = entry["item"];
                int qty = entry["quantity"];
                    cmd.CommandText = @"SELECT Item_id, Item_name, item_description, item_price, '"+qty+"' as Quantity  FROM Items WHERE item_id = " + id;
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader sdr = cmd.ExecuteReader())
                    {
                        dt.Load(sdr);
                    }
            }

            con.Close();

            purchaseItemGridView.DataSource = dt;
            purchaseItemGridView.DataBind();
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            string customer = customerDDL.Text.ToString();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string date = "11-04-2021";


            using (OleDbConnection con = new OleDbConnection(constr))
            {
                //!!REMAINING - > Send user_id of logged in user as user_id and current date as purchased_date
                OleDbCommand cmd1 = new OleDbCommand("Insert into Purchase(customer_id, purchased_date, user_id) Values('" + customer + "', CAST('"+date+"' as date), 6)");
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                
                //OleDbCommand cmd2 = new OleDbCommand("Select IDENT_CURRENT('Purchase')");
                OleDbCommand cmd2 = new OleDbCommand("select IDENT_CURRENT('Purchase') as ID;");
                cmd2.Connection = con;
                var id = cmd2.ExecuteReader();
                id.Read();
                string pur_id = id["ID"].ToString();
                System.Diagnostics.Debug.WriteLine(pur_id);
                foreach (Dictionary<string, int> entry in purchase_items)
                {
                    int item_id = entry["item"];
                    int quantity = entry["quantity"];
                    OleDbCommand cmd = new OleDbCommand("Insert into Purchase_Detail(purchase_id, item_id, purchased_quantity) Values(" + pur_id + "," + item_id + ", " + quantity + ")");
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                }


                con.Close();
            }
        }


    }
}