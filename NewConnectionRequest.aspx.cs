using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; 
using System.Data ;
using System.Configuration ;

public partial class NewConnectionRequest : System.Web.UI.Page
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
                if (Session["CustomerID"] != null && Session["CustomerName"] != null)
                {
                    TextBox1.Text = Session["CustomerID"].ToString();
                    TextBox2.Text = Session["CustomerName"].ToString();
                    autonumber();
                    TextBox4.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(rid),100)+1 from rtable ", con);

        TextBox3.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try 
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Branch Name....";
                return;
            }
            cmd = new SqlCommand("select rid from rtable where rid=@rid", con);
            cmd.Parameters.AddWithValue("rid", TextBox3.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Request ID Already Found....";
                return;
            }

            cmd = new SqlCommand("insert into rtable values(@cid,@cname,@bname,@rid,@rdate,@status)", con);
            cmd.Parameters .AddWithValue ("cid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("cname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("bname",DropDownList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("rid",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("rdate",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("status","Request");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "New Connection Request Details Inserted.....";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        autonumber();
    }
}