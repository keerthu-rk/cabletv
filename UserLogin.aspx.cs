using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class UserLogin : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1 .Text ="";
            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            
        }
        catch (Exception ex)
        {
            Label1 .Text =ex.Message;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        try
        {

            cmd = new SqlCommand("select * from ctable where cid=@cid and cname=@cname", con);
            cmd.Parameters.AddWithValue("cid", TextBox1.Text);
            cmd.Parameters.AddWithValue("cname", TextBox2.Text);
            rs = cmd.ExecuteReader();


            if (rs.Read())
            {
                Session.Add("CustomerID", TextBox1.Text);
                Session.Add("CustomerName", TextBox2.Text);
                Session.Add("EMail", rs["EMail"].ToString());
                rs.Close();
                cmd.Dispose();
                Response.Redirect("UserViewCustomerDetails.aspx");
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Invalid CustomentID and Name ....";


            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}