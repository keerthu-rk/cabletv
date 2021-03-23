using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class UserViewComplaintStatus : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m4 = (Menu)Master.FindControl("Menu4");
            m4.Visible = true;


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
            adp = new SqlDataAdapter("select * from comtable where  comid=@comid ", con);
            adp.SelectCommand.Parameters.AddWithValue("comid", TextBox1.Text);
            dt = new DataTable();
            adp.Fill(dt);
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}