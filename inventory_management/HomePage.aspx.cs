using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace inventory_management
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        String table_name = "Inventory";
        String table2_name = "cart_table";

        int userId = 2;
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\App Dev\Net\inventory_management\inventory_management\App_Data\inventiryDB.mdf"";Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserId"] != null)
            {
                userId = Convert.ToInt32(Session["UserId"]);
            }

            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            conn.Open();
            if (!IsPostBack)
            {
                DataTable rstData = MyRst($"select * from {table_name}");
                ViewState["InventoryData"] = rstData;

                RepeaterOfHomepage.DataSource = rstData;
                RepeaterOfHomepage.DataBind();
            }
        }
        public DataTable MyRst(string strSQL)
        {
            DataTable rstData = new DataTable();
            {
                using (SqlCommand cmdSQL = new SqlCommand(strSQL, conn))
                {
                    rstData.Load(cmdSQL.ExecuteReader());
                    rstData.TableName = strSQL;
                }
            }
            return rstData;
        }
        private void UpdateDatabase(DataTable rstData)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\App Dev\Net\inventory_management\inventory_management\App_Data\inventiryDB.mdf"";Integrated Security=True"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {table_name}", conn))
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.UpdateCommand = builder.GetUpdateCommand();
                    adapter.Update(rstData);
                }
            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] arguments = btn.CommandArgument.ToString().Split('|');
            int itemIndex = Convert.ToInt32(arguments[0]);
            int selectedQuantity = Convert.ToInt32(arguments[1]);
            int itemId = Convert.ToInt32(arguments[2]);

            DataTable rstData = (DataTable)ViewState["InventoryData"];
            int quantity = Convert.ToInt32(rstData.Rows[itemIndex]["Quantity"]);
            decimal price = Convert.ToDecimal(rstData.Rows[itemIndex]["Price"]);

            if (quantity >= selectedQuantity)
            {
                rstData.Rows[itemIndex]["Quantity"] = quantity - selectedQuantity;
                UpdateDatabase(rstData);

                decimal totalAmount = selectedQuantity * price;

                using (SqlCommand cmd = new SqlCommand("INSERT INTO cart_table (item_id, user_id, item_name, user_item_quantity, total_amount) VALUES (@item_id, @user_id, @item_name, @user_item_quantity, @total_amount)", conn))
                {
                    cmd.Parameters.AddWithValue("@item_id", itemId);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@item_name", rstData.Rows[itemIndex]["ItemName"]);
                    cmd.Parameters.AddWithValue("@user_item_quantity", selectedQuantity);
                    cmd.Parameters.AddWithValue("@total_amount", totalAmount);

                    cmd.ExecuteNonQuery();
                }

                RepeaterOfHomepage.DataSource = rstData;
                RepeaterOfHomepage.DataBind();
            }
        }

        protected void RepeaterOfHomepage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int itemIndex = e.Item.ItemIndex;
                int selectedQuantity = Convert.ToInt32(((DropDownList)e.Item.FindControl("QuantityDropDown")).SelectedValue);

                DataTable rstData = (DataTable)ViewState["InventoryData"];
                int quantity = Convert.ToInt32(rstData.Rows[itemIndex]["Quantity"]);
                decimal price = Convert.ToDecimal(rstData.Rows[itemIndex]["Price"]);
                int itemId = Convert.ToInt32(rstData.Rows[itemIndex]["Id"]); // Assuming the Id column is present in your Inventory table

                if (quantity >= selectedQuantity)
                {
                    rstData.Rows[itemIndex]["Quantity"] = quantity - selectedQuantity;
                    UpdateDatabase(rstData);

                    decimal totalAmount = selectedQuantity * price;

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO cart_table (item_id, user_id, item_name, user_item_quantity, total_amount) VALUES (@item_id, @user_id, @item_name, @user_item_quantity, @total_amount)", conn))
                    {
                        cmd.Parameters.AddWithValue("@item_id", itemId);
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@item_name", rstData.Rows[itemIndex]["ItemName"]);
                        cmd.Parameters.AddWithValue("@user_item_quantity", selectedQuantity);
                        cmd.Parameters.AddWithValue("@total_amount", totalAmount);

                        cmd.ExecuteNonQuery();
                    }

                    RepeaterOfHomepage.DataSource = rstData;
                    RepeaterOfHomepage.DataBind();
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"insert into {table2_name} values('" + 01 + "','" + "lemon" + "','" + 02 + "','" + 500 + "')";
            cmd.ExecuteNonQuery();

        }
    }
}