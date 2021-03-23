using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class InsertCustomerDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
                autonumber();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(cid),0)+ 1 from ctable", con);
        TextBox1.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (HiddenField1.Value == "")
            {
                Label1.Text = "Select Customer Photo.....";
                return;
            }
            cmd = new SqlCommand("select * from ctable where cid=@cid", con);
            cmd.Parameters.AddWithValue("cid", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "CustomerID Already Found.....";
                return;
            }

            cmd = new SqlCommand("insert into ctable values(@cid,@cname,@mno,@email,@address,@city,@cphoto)", con);
            cmd.Parameters .AddWithValue ("cid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("cname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("mno",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("email",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("address",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("city",TextBox6 .Text );
            cmd.Parameters.AddWithValue("cphoto", HiddenField1.Value);
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1.Text = "Customer Details Inserted....";

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
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        HiddenField1 .Value ="";
            Image1 .ImageUrl ="";
        autonumber();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {

            Image1.ImageUrl = "";
            HiddenField1.Value = "";
            if (FileUpload1.HasFile)
            {
                string path = DateTime.Now.Ticks + "_" + FileUpload1.FileName;
                Image1.ImageUrl = FileUpload1.PostedFile.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("PostedImage/" + path));
                HiddenField1.Value = path;
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}