using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class EmployeeLogin : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        try
        {

            cmd = new SqlCommand("select * from etable where eid=@eid and ename=@ename", con);
            cmd.Parameters.AddWithValue("eid", TextBox1.Text);
            cmd.Parameters.AddWithValue("ename", TextBox2.Text);
            rs = cmd.ExecuteReader();
          
            if (rs.Read ())
            {
                Session.Add("EmployeeID", TextBox1.Text);
                Session.Add("EmployeeName", TextBox2.Text);
                Session.Add("BName", rs["bname"].ToString());
                rs.Close();
                cmd.Dispose();
            
            
                Response.Redirect("EmployeeViewDetails.aspx");
            }
            else
            {
                rs.Close();
                cmd.Dispose();
            
                Label1.Text = "Invalid EmployeeID and Name ....";


            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}