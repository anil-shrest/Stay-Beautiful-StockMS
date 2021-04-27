using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StayBeautifulSMS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            stats();
            
        }

        protected void stats()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd1 = new OleDbCommand();
            OleDbCommand cmd2 = new OleDbCommand();
            OleDbCommand cmd3 = new OleDbCommand();
            OleDbCommand cmd4 = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd1.Connection = con;
            cmd2.Connection = con;
            cmd3.Connection = con;
            cmd4.Connection = con;
            cmd1.CommandText = @"SELECT COUNT(brand_id) from Brand";
            cmd2.CommandText = @"SELECT COUNT(item_id) from Items";
            cmd3.CommandText = @"SELECT COUNT(customer_id) from Customer";
            cmd4.CommandText = @"SELECT COUNT(purchase_id) from Purchase where purchased_date >= CURRENT_TIMESTAMP -31";
            
            var brand = cmd1.ExecuteReader();
            brand.Read();
            brands.InnerText = brand.GetInt32(0).ToString();
            var item = cmd2.ExecuteReader();
            item.Read();
            items.InnerText = item.GetInt32(0).ToString();
            var customer = cmd3.ExecuteReader();
            customer.Read();
            customers.InnerText = customer.GetInt32(0).ToString();
            var purchase = cmd4.ExecuteReader();
            purchase.Read();
            purchases.InnerText = purchase.GetInt32(0).ToString();
            con.Close();
        }
    }
}