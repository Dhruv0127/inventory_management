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
    public partial class WebForm5 : System.Web.UI.Page
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\App Dev\Net\inventory_management\inventory_management\App_Data\inventiryDB.mdf"";Integrated Security=True");
        String table_name = "Users";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = this.email.Text;
            string password = this.password.Text;

            bool isAdmin = ValidateAdmin(email, password);

            if (isAdmin)
            {
                Session["UserEmail"] = email;

                Session["IsAdmin"] = true;
                Response.Redirect("Admin.aspx");
            }
            else
            {
                bool isValidUser = ValidateUser(email, password);

                if (isValidUser)
                {
                    Session["UserEmail"] = email;

                    Session["IsLoggedIn"] = true;
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    errorMessage.Text = "Invalid email or password. Please try again.";
                }
            }
        }

        private bool ValidateAdmin(string email, string password)
        {
            return (email == "admin@admin" && password == "Admin");
        }


        private bool ValidateUser(string email, string password)
        {
            bool isValidUser = false;

            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE user_email = @user_email AND user_password = @user_password", conn))
            {
                cmd.Parameters.AddWithValue("@user_email", email);
                cmd.Parameters.AddWithValue("@user_password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    isValidUser = true;
                }
            }

            return isValidUser;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Display_data(table_name, GridView1);
        }
    }
}