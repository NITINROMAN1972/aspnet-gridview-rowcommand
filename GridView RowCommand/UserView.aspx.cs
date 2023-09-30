using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserView : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
    }

    private void BindGrid()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            int editID = Convert.ToInt32(Session["UserId"]);

            con.Open();
            string sql = "SELECT * FROM UserMaster WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", editID);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                TextBox1.Text = dt.Rows[0]["Name"].ToString();
                TextBox2.Text = dt.Rows[0]["Email"].ToString();
                TextBox3.Text = dt.Rows[0]["MobileNo"].ToString();
            }
            con.Close();
        }
    }
}