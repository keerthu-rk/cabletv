<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewEmployeeWorkingDetails.aspx.cs" Inherits="AdminViewEmployeeWorkingDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
        <tr>
            <th colspan ="2">
                <h1 style ="line-height :30px; font-size :x-large ; ">
                    Working Details</h1>
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
            Branch Name</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
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
            <td style="text-align :center ;" colspan="2">
                <center><asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="5" 
                    AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black" EmptyDataText="Record Not Found!!!">
                    <Columns >
                        <asp:BoundField DataField ="eid" HeaderText ="ID" />
                        <asp:BoundField DataField ="ename" HeaderText ="Name" />
                        <asp:BoundField DataField ="wdate" HeaderText ="Working Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField ="wdesc" HeaderText ="Working Details" />
                        
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
            <td style="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

