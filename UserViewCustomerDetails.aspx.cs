using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class UserViewCustomerDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m4 = (Menu)Master.FindControl("Menu4");
            m4.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["CustomerID"] != null)
                {
                    Label2.Text = Session["CustomerID"].ToString();
                    cmd = new SqlCommand("select * from ctable where cid=@cid", con);
                    cmd.Parameters.AddWithValue("cid", Label2 .Text );
                    rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        TextBox2.Text = rs["cname"].ToString();
                        TextBox3.Text = rs["mno"].ToString();
                        TextBox4.Text = rs["email"].ToString();
                        TextBox5.Text = rs["address"].ToString();
                        TextBox6.Text = rs["city"].ToString();
                        Image1.ImageUrl = "~/PostedImage/" + rs["cphoto"].ToString();
                        rs.Close();
                        cmd.Dispose();
                    }
                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                    }
                }
              
            }
               
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
   
}