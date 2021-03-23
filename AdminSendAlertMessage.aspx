<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminSendAlertMessage.aspx.cs" Inherits="AdminSendAlertMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
        <tr>
            <th colspan="2">
                <h1 style ="line-height :30px; font-size :x-large ; ">
                    Alert Message</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                Messsage Date</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Message Description</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align : center;" class="style1">
            &nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Send</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server">Clear</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align : center;">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

