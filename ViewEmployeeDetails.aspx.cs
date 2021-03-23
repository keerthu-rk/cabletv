using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ViewEmployeeDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
         
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    void bindgrid()
    {
        GridView1.Visible = true;
        adp = new SqlDataAdapter("select * from etable where bname=@bname", con);
        adp.SelectCommand.Parameters.AddWithValue("bname", DropDownList1.SelectedItem.Text);
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Branch Name.....";
                return;
            }
            bindgrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}