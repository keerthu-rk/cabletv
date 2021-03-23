<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserViewCustomerDetails.aspx.cs" Inherits="UserViewCustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        height: 25px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
    <tr>
        <th colspan="2">
       <h1 style ="line-height :30px; font-size :x-large ; ">
                View Account</h1>
        </th>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Customer ID</td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Customer Name</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Mobile Number</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Email ID</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            Address</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align :right ;">
            City</td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td style="text-align :right ;">
            Photo</td>
        <td>
            <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

