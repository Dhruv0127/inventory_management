
using System.Data.SqlClient;
using System;

namespace inventory_management
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        String table_name = "Users";
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\App Dev\Net\inventory_management\inventory_management\App_Data\inventiryDB.mdf"";Integrated Security=True");

        // Declare userId at the class level
        private int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == System.Data.ConnectionState.Open) { conn.Close(); }
            conn.Open();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string email = this.email.Text;
            string password = this.password.Text;
            string dateOfBirth = this.dateOfBirth.Text;

            DateTime birthDate = DateTime.Parse(dateOfBirth);
            int age = CalculateAge(birthDate);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"insert into {table_name} values('" + username + "','" + email + "','" + password + "','" + dateOfBirth + "','" + age + "')";
            cmd.ExecuteNonQuery();

            userId = GetUserIdByEmail(email);
            Session["UserId"] = userId;
            Response.Redirect("HomePage.aspx");
        }

        private int CalculateAge(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;
            if (DateTime.Now.DayOfYear < dob.DayOfYear)
                age--;
            return age;
        }

        private int GetUserIdByEmail(string email)
        {
            int userId = 0;

            using (SqlCommand cmd = new SqlCommand($"SELECT Id FROM Users WHERE user_email = @user_email", conn))
            {
                cmd.Parameters.AddWithValue("@user_email", email);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }
            }

            return userId;
        }
    }
}