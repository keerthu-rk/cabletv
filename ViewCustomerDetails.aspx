<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCustomerDetails.aspx.cs" Inherits="ViewCustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
    <tr>
        <th>
           <h1 style ="line-height :30px; font-size :x-large ; ">
                Customer Details</h1>
        </th>
    </tr>
    <tr>
        <td style="text-align :center ;">
            <center><asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                onpageindexchanging="GridView1_PageIndexChanging" PageSize="5" 
                AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                ForeColor="Black" EmptyDataText="Record Not Found!!!">
                <Columns >
                <asp:BoundField DataField ="cid" HeaderText ="Customer ID" />
                <asp:BoundField DataField ="cname" HeaderText ="Customer Name" />
                <asp:BoundField DataField ="mno" HeaderText ="Mobile Number" />
                <asp:BoundField DataField ="email" HeaderText ="EMail ID" />
                <asp:BoundField DataField ="address" HeaderText ="Address" />
                <asp:BoundField DataField ="city" HeaderText ="City" />
                       <asp:ImageField DataImageUrlField ="cphoto" DataImageUrlFormatString ="PostedImage/{0}" HeaderText ="Photo">
                    <ControlStyle Width ="100" Height ="100" />
                    </asp:ImageField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView></center>
        </td>
    </tr>
    <tr>
        <td style="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

