using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class UserViewMessage : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
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
            if (!IsPostBack)
            {
                if(Session ["EMail"]!=null)
                bindgrid();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from amtable where email=@email", con);
        adp.SelectCommand.Parameters.AddWithValue("email", Session["EMail"].ToString());
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try 
        {
            string mdate = GridView1.DataKeys[e.RowIndex].Value.ToString();
            cmd = new SqlCommand("delete from amtable where email=@email and mdate=@mdate", con);
            cmd.Parameters.AddWithValue("email", Session["EMail"].ToString());
            cmd.Parameters.AddWithValue("mdate", mdate);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            bindgrid();


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }


    }
}