using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data .SqlClient ;
using System.Configuration ;

public partial class EmployeeViewDetails : System.Web.UI.Page
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

                if (Session["EmployeeID"] != null)
                {
                    Label2.Text = Session["EmployeeID"].ToString();
                    cmd = new SqlCommand("select * from etable where eid=@eid", con);
                    cmd.Parameters.AddWithValue("eid", Label2.Text);
                    rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        TextBox1.Text = rs["ename"].ToString();
                        RadioButtonList1.Text = rs["gender"].ToString();
                        TextBox2.Text = DateTime.Parse(rs["doj"].ToString()).ToString("dd-MMM-yyyy");
                        TextBox3.Text = rs["desg"].ToString();
                        TextBox4.Text = rs["salary"].ToString();
                        TextBox5.Text = rs["mno"].ToString();
                        TextBox6.Text = rs["email"].ToString();
                        TextBox7.Text = rs["address"].ToString();
                        TextBox8.Text = rs["city"].ToString();
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
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
        

    }
