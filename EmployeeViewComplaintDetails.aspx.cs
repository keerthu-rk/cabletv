using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class EmployeeViewComplaintDetails : System.Web.UI.Page
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
        adp = new SqlDataAdapter("select * from comtable where status='Register'", con);
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
                int cid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                cmd = new SqlCommand("update comtable set status='Completed' where cid=@cid", con);
                cmd.Parameters.AddWithValue("cid", cid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
           //     bindgrid();
                Response.Redirect("EmployeeWorkingDetails.aspx");
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}