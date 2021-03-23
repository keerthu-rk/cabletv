using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ModifyEmployeeDetails : System.Web.UI.Page
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
            {
                cmd = new SqlCommand("select eid from etable", con);
                rs = cmd.ExecuteReader();
                DropDownList1.DataSource = rs;
                DropDownList1.DataTextField = "eid";
                DropDownList1.DataBind();
                rs.Close();
                cmd.Dispose();
                DropDownList1.Items.Insert(0, "Select");
            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox1.Text = "";
            RadioButtonList1.SelectedIndex = -1;
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            Image1.ImageUrl = "";
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Employee ID.....";
                return;
            }

            cmd = new SqlCommand("select * from etable where eid=@eid", con);
            cmd.Parameters.AddWithValue("eid", DropDownList1.SelectedItem.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                TextBox1.Text = rs["ename"].ToString();
                RadioButtonList1.Text = rs["gender"].ToString();
                TextBox2.Text = DateTime.Parse (rs["doj"].ToString()).ToString ("dd-MMM-yyyy");
                TextBox3.Text = rs["desg"].ToString();
                TextBox4.Text = rs["salary"].ToString();
                TextBox5.Text = rs["mno"].ToString();
                TextBox6.Text = rs["email"].ToString();
                TextBox7.Text = rs["address"].ToString();
                TextBox8.Text = rs["city"].ToString();
                TextBox9.Text = rs["bname"].ToString();
                Image1.ImageUrl = "~/PostedImage/" + rs["ephoto"].ToString();
                    
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
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
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Customer ID.....";
                return;
            }
            cmd = new SqlCommand("update etable set ename=@ename,gender=@gender,doj=@doj,desg=@desg,salary=@salary,mno=@mno,email=@email,address=@address,city=@city where eid=@eid", con);
            cmd.Parameters.AddWithValue("ename", TextBox1.Text);
            cmd.Parameters.AddWithValue("gender", RadioButtonList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("doj", TextBox2.Text);
            cmd.Parameters.AddWithValue("desg", TextBox3.Text);
            cmd.Parameters.AddWithValue("salary", TextBox4.Text);
            cmd.Parameters.AddWithValue("mno", TextBox5.Text);
            cmd.Parameters.AddWithValue("email", TextBox6.Text);
            cmd.Parameters.AddWithValue("address", TextBox7.Text);
            cmd.Parameters.AddWithValue("city", TextBox8.Text);
            cmd.Parameters.AddWithValue("eid", DropDownList1.SelectedItem.Text);

             cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Employee Details Updated.....";
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
            if (DropDownList1.SelectedIndex == 0)
            {
                Label1.Text = "Select Employee ID.....";
                return;
            }

            cmd = new SqlCommand("delete from etable where eid=@eid", con);
            cmd.Parameters.AddWithValue("eid", DropDownList1.SelectedItem.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Employee Details Deleted....";
            TextBox1.Text = "";
            RadioButtonList1.SelectedIndex = -1;
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            Image1.ImageUrl = "";

            DropDownList1.Items.Remove(DropDownList1.SelectedItem.Text);


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }


    }
}