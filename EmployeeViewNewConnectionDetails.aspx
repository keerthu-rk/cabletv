<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeViewNewConnectionDetails.aspx.cs" Inherits="EmployeeViewNewConnectionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
        <tr>
            <th>
                <h1 style ="line-height :30px; font-size :x-large ; ">
                    View New Connection Request</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align :center ;">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                onpageindexchanging="GridView1_PageIndexChanging" PageSize="5" 
                    AutoGenerateColumns="False" DataKeyNames="rid" 
                    onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                    CellSpacing="2" ForeColor="Black">
                    <Columns >
                        <asp:BoundField DataField ="cid" HeaderText ="Customer ID" />
                        <asp:BoundField DataField ="cname" HeaderText ="Customer Name" />
                        <asp:BoundField DataField ="bname" HeaderText ="Branch Name" />
                        <asp:BoundField DataField ="rid" HeaderText ="Request ID" />
                        <asp:BoundField DataField ="rdate" HeaderText ="Request Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                        <asp:ButtonField Text ="Connected" CommandName ="cc" HeaderText ="Connected" />
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
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align :center ;">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

