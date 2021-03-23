using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class EmployeeViewNewConnectionDetails : System.Web.UI.Page
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

            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
                bindgrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from rtable where status='Send'", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cc")
            {
                int rid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                cmd = new SqlCommand("update rtable set status='Connected' where rid=@rid", con);
                cmd.Parameters.AddWithValue("rid", rid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}