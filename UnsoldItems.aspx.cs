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
    public partial class UnsoldItems : System.Web.UI.Page
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
            cmd.CommandText = @"SELECT it.item_id ""Item_ID"", item_name ""Name"",br.Brand_Name ""Brand"", ct.category_name ""Category"", it.item_price ""Price"", it.stocked_date ""Stocked Date"", it.available_quantity ""Stock Quantity"" FROM Items it
INNER JOIN Brand br on it.brand_id = br.brand_id
INNER JOIN Category ct on ct.category_id = it.category_id
WHERE it.item_id not in (
SELECT pd.item_id from Purchase_Detail pd
INNER JOIN
(
	SELECT p.purchase_id from Purchase p
	WHERE p.purchased_date >= CURRENT_TIMESTAMP -1
) ps
ON pd.purchase_id = ps.purchase_id
) AND it.available_quantity > 0;";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("Items");
            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();
            unsoldItemsGrid.DataSource = dt;
            unsoldItemsGrid.DataBind();
        }
    }
}