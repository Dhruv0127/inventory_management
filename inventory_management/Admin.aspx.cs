using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace inventory_management
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String table_name = "Inventory";
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\App Dev\Net\inventory_management\inventory_management\App_Data\inventiryDB.mdf"";Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            conn.Open();
        }
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            string imagePath = txtImagePath.Text;
            string itemName = txtItemName.Text;
            int quantity = int.Parse(txtQuantity.Text);
            int price = int.Parse(txtPrice.Text);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"insert into {table_name} values('" + imagePath + "','" + itemName + "','" + quantity + "','" + price + "')";
            cmd.ExecuteNonQuery();
            txtItemName.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            Display_data(table_name, GridView1);
        }
        public void Display_data(String tb, GridView gd)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from {tb}";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable);
            gd.DataSource = dataTable;
            gd.DataBind();
        }
        protected string CalculateTotalPrice(object quantityObj, object priceObj)
        {
            int quantity = Convert.ToInt32(quantityObj);
            int price = Convert.ToInt32(priceObj);
            int totalPrice = quantity * price;
            return totalPrice.ToString();
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Decrease")
            {
                int itemID = Convert.ToInt32(e.CommandArgument);
                UpdateQuantity(itemID, -1); 
            }
            else if (e.CommandName == "Increase")
            {
                int itemID = Convert.ToInt32(e.CommandArgument);
                UpdateQuantity(itemID, 1); 
            }
        }

        private void UpdateQuantity(int itemID, int quantityChange)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"UPDATE {table_name} SET Quantity = Quantity + @QuantityChange WHERE ItemID = @ItemID";
            cmd.Parameters.AddWithValue("@QuantityChange", quantityChange);
            cmd.Parameters.AddWithValue("@ItemID", itemID);
            cmd.ExecuteNonQuery();

            Display_data(table_name, GridView1);
        }

        protected void btnShowDB_Click(object sender, EventArgs e)
        {
            Display_data(table_name, GridView1);
        }
    }
}


