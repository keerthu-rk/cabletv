<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertEmployeeDetails.aspx.cs" Inherits="InsertEmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
    <tr>
        <th colspan="2">
          <h1 style ="line-height :30px; font-size :x-large ; ">
                Employee Details</h1>
        </th>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Branch Name</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>Anna Nagar</asp:ListItem>
                <asp:ListItem>KK Nagar</asp:ListItem>
                <asp:ListItem>JJ Nagar</asp:ListItem>
                <asp:ListItem>Rajaji Nagar</asp:ListItem>
                <asp:ListItem>Jeeva Nagar</asp:ListItem>
                <asp:ListItem>Villapuram</asp:ListItem>
                <asp:ListItem>Kalavasal</asp:ListItem>
                <asp:ListItem>Periyar</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Employee ID</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Employee Name</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Gender</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Date of Joining</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Designation</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Salary</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Mobile Number</td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Email ID</td>
        <td>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Address</td>
        <td>
            <asp:TextBox ID="TextBox8" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            City</td>
        <td>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Employee Photo</td>
        <td>
            
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">View</asp:LinkButton>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <br />
            <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align :center ;">
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Insert</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Clear</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

