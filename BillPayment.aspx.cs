using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class BillPayment : System.Web.UI.Page
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

            cmd = new SqlCommand("select isnull(max(billno),1000)+1 from bptable", con);
          
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

            cmd = new SqlCommand("select billno from bptable where billno=@billno", con);
            cmd.Parameters.AddWithValue("billno", TextBox4.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Bill Number Already Found....";
                return;
            }

            cmd = new SqlCommand("select * from bptable where cid=@cid and bpmonth=@bpmonth and bpyear=@bpyear", con);
            cmd.Parameters.AddWithValue("cid", TextBox1.Text);
            cmd.Parameters.AddWithValue("bpmonth", DateTime.Now.ToString("MMM"));
            cmd.Parameters.AddWithValue("bpyear", DateTime.Now.Year);
            rs = cmd.ExecuteReader();
             b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = DateTime.Now.ToString("MMM") + " Month Bill Already Paid.....";
                return;
            }


            cmd = new SqlCommand("insert into bptable values(@cid,@cname,@bname,@billno,@bpmonth,@bpyear,@bpdate,@amount,@ctype,@cnumber)", con);
            cmd.Parameters .AddWithValue ("cid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("cname",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("bname",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("billno",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("bpmonth",DateTime .Now .ToString ("MMM"));
            cmd.Parameters .AddWithValue ("bpyear",DateTime .Now.Year );
            cmd.Parameters .AddWithValue ("bpdate",TextBox5 .Text );
            cmd.Parameters.AddWithValue("amount",Label2.Text );
            cmd.Parameters.AddWithValue("ctype", DropDownList1 .SelectedItem .Text );
            cmd.Parameters.AddWithValue("cnumber", TextBox6 .Text );
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1.Text = "Bill Payment Details Inserted....";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}