using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class AdminViewNotBillPaymentCustomerDetails : System.Web.UI.Page
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
        adp = new SqlDataAdapter("select * from rtable where cid not in (select cid from bptable where bpmonth=@bpmonth and bpyear=@bpyear)", con);
        adp.SelectCommand.Parameters.AddWithValue("bpmonth", DropDownList1.SelectedItem.Text);
        adp.SelectCommand.Parameters.AddWithValue("bpyear", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            GridView1.Visible = false;
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Month .....";
                return;
            }

            bindgrid();


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bindgrid();

    }
}
