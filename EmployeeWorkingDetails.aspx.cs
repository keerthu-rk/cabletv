using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class EmployeeWorkingDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

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
            {

                if (Session["EmployeeID"] != null && Session["EmployeeName"] != null && Session["BName"] != null)
                {
                    TextBox1.Text = Session["BName"].ToString();
                    TextBox2.Text = Session["EmployeeID"].ToString();
                    TextBox3.Text = Session["EmployeeName"].ToString();
                    TextBox4.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
            }
         
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

            cmd = new SqlCommand("insert into ewtable values(@bname,@eid,@ename,@wdate,@wdesc)", con);
            cmd.Parameters .AddWithValue ("bname",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("eid",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("ename",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("wdate",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("wdesc",TextBox5 .Text );
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Working Details Inserted.....";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox5.Text = "";
        TextBox5.Focus();
    }
}