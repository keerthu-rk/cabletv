<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserViewComplaintStatus.aspx.cs" Inherits="UserViewComplaintStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
        <tr>
            <th colspan ="2">
                <h1 style ="line-height :30px; font-size :x-large ; ">
                    Complaint Status</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Complaint ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">View</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="text-align :center ;" colspan="2">
                <center><asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="243px" 
                    AutoGenerateRows="False" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black" EmptyDataText="Record Not Found!!!">
                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <Fields >
                <asp:BoundField DataField ="cdate" HeaderText ="Complaint Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                <asp:BoundField DataField ="comdesc" HeaderText ="Complaint Details" />
                <asp:BoundField DataField ="status" HeaderText ="Status" />
                </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                </asp:DetailsView></center>
            </td>
        </tr>
        <tr>
            <td style="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

