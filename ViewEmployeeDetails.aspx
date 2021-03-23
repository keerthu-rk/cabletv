<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewEmployeeDetails.aspx.cs" Inherits="ViewEmployeeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
        <tr>
            <th colspan ="2">
                 <h1 style ="line-height :30px; font-size :x-large ; ">
                    Employee Details</h1>
            </th>
        </tr>
        <tr><td style ="text-align :right ;">
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
                    EmptyDataText="Record Not Found!!!" ForeColor="Black">
                    <Columns >
                    <asp:BoundField DataField ="eid" HeaderText ="ID" />
                    <asp:BoundField DataField ="ename" HeaderText ="Name" />
                    <asp:BoundField DataField ="gender" HeaderText ="Gender" />
                    <asp:BoundField DataField ="doj" HeaderText ="Date of Joining" />
                    <asp:BoundField DataField ="desg" HeaderText ="Designation" />
                    <asp:BoundField DataField ="salary" HeaderText ="Salary" />
                    <asp:BoundField DataField ="mno" HeaderText ="Mobile No" />
                    <asp:BoundField DataField ="email" HeaderText ="EMailID" />
                    <asp:BoundField DataField ="address" HeaderText ="Address" />
                    <asp:BoundField DataField ="city" HeaderText ="City" />
                    <asp:ImageField DataImageUrlField ="ephoto" DataImageUrlFormatString ="PostedImage/{0}" HeaderText ="Photo">
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
            <td style="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

