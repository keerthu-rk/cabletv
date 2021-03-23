<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeLogin.aspx.cs" Inherits="EmployeeLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
    <tr>
        <th colspan="2">
            <h1 style ="line-height :30px; font-size :x-large ; ">
                Employee Login
            </h1>
        </th>
    </tr>
    <tr>
        <td style="text-align: right; height: 28px;">
            Employee ID</td>
        <td style="height: 28px">
            <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Employee Name</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False" TextMode="Password" 
                Width="146px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align : center;">
            &nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Login</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align : center;">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

