<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MortgageApplicationXML.aspx.cs" Inherits="CIS325_Web_Master_Project.Demos.MortgageApplicationDB.MortgageApplicationXML" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="DataFormPanel" runat="server">
        <table style="width: 2507px; height: 146px; ">
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">&nbsp;</td>
                <td style="width: 1880px; font-size: large">
                    &nbsp;</td>
            </tr>
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">Approval Status:</td>
                <td style="width: 1880px; font-size: large">
                    <asp:RadioButtonList ID="ApprovalStatus" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Pending</asp:ListItem>
                        <asp:ListItem>Approved</asp:ListItem>
                        <asp:ListItem>Rejected</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">Customer Name:</td>
                <td style="width: 1880px; font-size: large">
                    <asp:TextBox ID="CustomerName" runat="server" Width="530px"></asp:TextBox>
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">Customer Email:</td>
                <td style="width: 814px; font-size: large">
                    <asp:TextBox ID="CustomerEmail" runat="server" TextMode="Email" Width="530px"></asp:TextBox>
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">Customer SSN:</td>
                <td style="width: 814px; font-size: large">
                    <asp:TextBox ID="CustomerSSN" runat="server" Width="530px"></asp:TextBox>
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">Customer Gener:</td>
                <td style="width: 814px; font-size: large">
                    <asp:RadioButtonList ID="CustomerGender" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem Value="NotSure">Not Sure</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">State:</td>
                <td style="width: 814px; font-size: large">
                    <asp:DropDownList ID="CustomerState" runat="server">
                        <asp:ListItem Value="0">---Please Select---</asp:ListItem>
                        <asp:ListItem Value="OH">Ohio</asp:ListItem>
                        <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                        <asp:ListItem Value="IN">Indiana</asp:ListItem>
                        <asp:ListItem Value="FL">Florida</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">Existing Accounts</td>
                <td style="width: 814px; font-size: large">
                    <asp:CheckBoxList ID="CustomerExistingAccounts" runat="server">
                        <asp:ListItem>Chekcing</asp:ListItem>
                        <asp:ListItem>Savings</asp:ListItem>
                        <asp:ListItem>MoneyMarket</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">Loan Amount:</td>
                <td style="width: 814px; font-size: large">
                    <asp:TextBox ID="CustomerLoanAmount" runat="server" Width="530px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">Comment: </td>
                <td style="width: 814px; font-size: large">
                    <asp:TextBox ID="CustomerComments" runat="server" Height="258px" TextMode="MultiLine" Width="768px" ></asp:TextBox>
                </td>
            </tr>
            <tr style="font-size: x-large">
                <td style="font-size: large; width: 297px;">&nbsp;</td>
                <td style="width: 814px; font-size: large">&nbsp;</td>
            </tr>
        </table>

    </asp:Panel>
    <asp:Label ID="ErrorMsg" runat="server" style="font-size: large; color: #FF3300"></asp:Label>
<br />
<asp:Label ID="ResultMsg" runat="server" style="font-size: large"></asp:Label>
<br />


    <asp:Button ID="Submit" runat="server" Text="Submit Application" OnClick="Submit_Click" />


</asp:Content>

 
