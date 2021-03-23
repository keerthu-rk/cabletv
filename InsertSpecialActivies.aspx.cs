using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class InsertSpecialActivies : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;

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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try 
        {
            cmd = new SqlCommand("select * from satable where channelname=@channelname", con);
            cmd.Parameters.AddWithValue("channelname", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Channel Name Already Found....";
                return;
            }

            cmd = new SqlCommand("insert into satable values(@channelname,@channeldesc)", con);
            cmd.Parameters .AddWithValue ("channelname",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("channeldesc",TextBox2 .Text );
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1 .Text ="Special Activity Details Inserted....";



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";

    }
}