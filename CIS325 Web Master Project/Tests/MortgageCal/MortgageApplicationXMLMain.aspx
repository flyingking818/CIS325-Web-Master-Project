<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MortgageApplicationXMLMain.aspx.cs" Inherits="CIS325_Web_Master_Project.Demos.MortgageApplicationDB.MortgageApplicationXMLMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    &nbsp;<asp:TextBox ID="SearchBox" runat="server" ToolTip="Enter customer name" Width="441px"></asp:TextBox>
    <asp:Button ID="Search" runat="server" OnClick="Search_Click" Text="Search" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AppID" EmptyDataText="There are no data records to display." AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1247px" OnPageIndexChanging="GridView1_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="AppID" DataNavigateUrlFormatString="MortgageApplicationXML?Action=View&amp;AppID={0}" DataTextField="AppID" DataTextFormatString="View App" HeaderText="View" />
            <asp:HyperLinkField DataNavigateUrlFields="AppID" DataNavigateUrlFormatString="MortgageApplicationXML?Action=Edit&amp;AppID={0}" DataTextField="AppID" DataTextFormatString="Edit App" HeaderText="Edit" />
            <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName" />
            <asp:BoundField DataField="CustomerEmail" HeaderText="CustomerEmail" SortExpression="CustomerEmail" />
            <asp:BoundField DataField="CustomerSSN" HeaderText="CustomerSSN" SortExpression="CustomerSSN" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="20px" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="20" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

</asp:Content>
