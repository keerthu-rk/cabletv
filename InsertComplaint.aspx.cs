using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class InsertComplaint : System.Web.UI.Page
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

                    cmd = new SqlCommand("select bname from rtable where cid=@cid", con);
                    cmd.Parameters.AddWithValue("cid", TextBox1.Text);
                    rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        TextBox3.Text = rs["bname"].ToString();
                        rs.Close();
                        cmd.Dispose();
                    }
                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                        Label1.Text = "Record Not Found.Check RTable....";
                        return;
                    }
                    autonumber();
                    TextBox5.Text = DateTime.Now.ToString("dd-MMM-yyyy");

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

        try 
        {

            cmd = new SqlCommand("select isnull(max(comid),1000)+1 from comtable", con);
         
            TextBox4.Text = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
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

            cmd = new SqlCommand("select comid from comtable where comid=@comid", con);
            cmd.Parameters.AddWithValue("comid", TextBox4.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "ComplaintID Already Found....";
                return;
            }

            cmd = new SqlCommand("insert into comtable values(@cid,@cname,@bname,@comid,@cdate,@comdesc,@status)", con);
            cmd.Parameters .AddWithValue ("cid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("cname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("bname",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("comid",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("cdate",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("comdesc",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("status","Register");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Complaint Details Register......";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try 
        {
            autonumber();
            TextBox6.Text = "";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}