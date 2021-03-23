using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class InsertEmployeeDetails : System.Web.UI.Page
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
        cmd = new SqlCommand("select isnull(max(eid),0)+ 1 from etable", con);
        TextBox1.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Branch Name.....";
                return;
            }
            cmd = new SqlCommand("select * from etable where eid=@eid", con);
            cmd.Parameters.AddWithValue("eid", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "EmployeeID Already Found.....";
                return;
            }

            cmd = new SqlCommand("insert into etable values(@bname,@eid,@ename,@gender,@doj,@desg,@salary,@mno,@email,@address,@city,@ephoto)", con);
            cmd.Parameters.AddWithValue("bname", DropDownList1.SelectedItem.Text);
          cmd.Parameters .AddWithValue ("eid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("ename",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("gender",RadioButtonList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("doj",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("desg",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("salary",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("mno",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("email",TextBox7 .Text );
            cmd.Parameters .AddWithValue ("address",TextBox8 .Text );
            cmd.Parameters .AddWithValue ("city",TextBox9 .Text );
            cmd.Parameters.AddWithValue("ephoto", HiddenField1.Value);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Employee Details Inserted....";

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        RadioButtonList1.SelectedIndex = -1;
        Image1.ImageUrl = "";
        HiddenField1.Value = "";
    
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