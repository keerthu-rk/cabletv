using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;


public partial class AdminSendAlertMessage : System.Web.UI.Page
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
            TextBox1.Text = DateTime.Now.ToString("dd-MMM-yyyy");

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

            cmd = new SqlCommand("select email from ctable", con);
            rs = cmd.ExecuteReader();
            ArrayList email = new ArrayList();
            while (rs.Read())
                email.Add(rs["email"].ToString());
            rs.Close();
            cmd.Dispose();
            bool b = false;

            for (int i = 0; i < email.Count; i++)
            {
                cmd = new SqlCommand("insert into amtable values(@email,@mdate,@mdesc)", con);
                cmd.Parameters .AddWithValue ("email",email [i].ToString ());
                cmd.Parameters .AddWithValue ("mdate",TextBox1 .Text );
                cmd.Parameters .AddWithValue ("mdesc",TextBox2 .Text );
                cmd.ExecuteNonQuery ();
                cmd.Dispose ();
                b = true;
            }
            if (b)
            {
                Label1.Text = "Successfully Send Your Message.....";

            }
       }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}