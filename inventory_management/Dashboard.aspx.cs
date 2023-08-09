using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace inventory_management
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        String table_name = "Inventory";
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\App Dev\Net\inventory_management\inventory_management\App_Data\inventiryDB.mdf"";Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            conn.Open();
            if (!IsPostBack)
            {
                DataTable rstData = MyRst($"select * from {table_name}");
                ViewState["InventoryData"] = rstData;

                Repeater1.DataSource = rstData;
                Repeater1.DataBind();
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
        protected void btnDecrease_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int itemIndex = Convert.ToInt32(btn.CommandArgument);

            DataTable rstData = (DataTable)ViewState["InventoryData"];
            int quantity = Convert.ToInt32(rstData.Rows[itemIndex]["Quantity"]);

            if (quantity > 0)
            {
                rstData.Rows[itemIndex]["Quantity"] = quantity - 1;
                UpdateDatabase(rstData);

                Repeater1.DataSource = rstData;
                Repeater1.DataBind();
            }
        }

        protected void btnIncrease_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int itemIndex = Convert.ToInt32(btn.CommandArgument);

            DataTable rstData = (DataTable)ViewState["InventoryData"];
            int quantity = Convert.ToInt32(rstData.Rows[itemIndex]["Quantity"]);

            rstData.Rows[itemIndex]["Quantity"] = quantity + 1;
            UpdateDatabase(rstData);

            Repeater1.DataSource = rstData;
            Repeater1.DataBind();
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int itemIndex = Convert.ToInt32(btn.CommandArgument);

            DataTable rstData = (DataTable)ViewState["InventoryData"];
            int itemId = Convert.ToInt32(rstData.Rows[itemIndex]["Id"]);

            // Delete the item from the database
            {
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM Inventory WHERE Id = @ItemId", conn))
                {
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    cmd.ExecuteNonQuery();
                }
            }

            // Refresh the data and Repeater
            rstData = MyRst($"SELECT * FROM {table_name}");
            ViewState["InventoryData"] = rstData;

            Repeater1.DataSource = rstData;
            Repeater1.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int itemIndex = Convert.ToInt32(btn.CommandArgument);

            // Implement your update logic here
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //navigation to admin page 
            Response.Redirect("Admin.aspx");
        }
    }
}