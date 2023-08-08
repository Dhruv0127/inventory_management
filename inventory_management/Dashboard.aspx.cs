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
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\App Dev\Net\inventory_management\inventory_management\App_Data\inventiryDB.mdf"";Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (con.State == System.Data.ConnectionState.Open) { con.Close(); }
            con.Open();
            if (!IsPostBack)
            {
                DataTable rstData;
                rstData = MyRst($"select * from {table_name}");

                Repeater1.DataSource = rstData;
                Repeater1.DataBind();
            }
        }
        public DataTable MyRst(string strSQL)
        {
            DataTable rstData = new DataTable();
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\App Dev\Net\inventory_management\inventory_management\App_Data\inventiryDB.mdf"";Integrated Security=True"))
            {
                using (SqlCommand cmdSQL = new SqlCommand(strSQL, conn))
                {
                    conn.Open();
                    rstData.Load(cmdSQL.ExecuteReader());
                    rstData.TableName = strSQL;
                }
            }
            return rstData;
            /*<div style="border-style:solid;color:black;width:320px;height:450px;float:left;margin-right:10px;margin-bottom:10px">
                                <div style="text-align:center;padding:2px 10px 2px 10px">
                                    <asp:Image ID="Image1" runat="server" 
                                        ImageUrl = '<%# Eval("ImagePath") %>' Width="170" />
                                    <h4>Engine</h4>
                                    <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("ItemName") %>' />
                                    <h4>Description</h4>
                                    <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                                </div>
                            </div>*/
        }
    }
}