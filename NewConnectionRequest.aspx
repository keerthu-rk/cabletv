<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewConnectionRequest.aspx.cs" Inherits="NewConnectionRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
        <tr>
            <th colspan="2">
                <h1 style ="line-height :30px; font-size :x-large ; ">
                    New Connection Request</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align :right ;">
            Customer ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align :right ;">
            Customer Name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
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
                Request ID</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align :right ;">
                Request Date</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
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

