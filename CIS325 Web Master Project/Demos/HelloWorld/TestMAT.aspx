<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestMAT.aspx.cs" Inherits="CIS325_Web_Master_Project.Demos.HelloWorld.TestMAT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        tr, td {
            padding: 8px;
        }

        .modal-sm {
            font-weight: bold;
        }
    </style>



    <asp:Panel ID="FormPanel" runat="server" Style="font-size: large">

        <table class="nav-justified">
            <tr>
                <td class="text-center" colspan="2"><strong>Mortgage Calculator</strong></td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">&nbsp;</td>
                <td>
                    <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">Customer Name<span style="color: #FF0000"><strong>*</strong></span>:</td>
                <td>
                    <asp:TextBox ID="CustomerName" runat="server" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVCustomerName" runat="server" ControlToValidate="CustomerName" ErrorMessage="Please enter your name." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">Customer Age:</td>
                <td>
                    <asp:TextBox ID="CustomerAge" runat="server" Width="74px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">Email<span style="color: #FF0000"><strong>*</strong></span>:</td>
                <td>
                    <asp:TextBox ID="CustomerEmail" runat="server" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVCustomerEmail" runat="server" ControlToValidate="CustomerEmail" ErrorMessage="Please enter your email." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">Gender:</td>
                <td>
                    <asp:RadioButtonList ID="Gender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Not Sure</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">State:</td>
                <td>
                    <asp:DropDownList ID="State" runat="server">
                        <asp:ListItem Value="0">---Please Select---</asp:ListItem>
                        <asp:ListItem Value="FL">Florida</asp:ListItem>
                        <asp:ListItem Value="GA">Georgia</asp:ListItem>
                        <asp:ListItem Value="MI">Michigan</asp:ListItem>
                        <asp:ListItem Value="NY">New York</asp:ListItem>
                        <asp:ListItem Value="OH">Ohio</asp:ListItem>
                        <asp:ListItem Value="CA">California</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">Existing Accounts:</td>
                <td>
                    <asp:CheckBoxList ID="ExistingAccounts" runat="server">
                        <asp:ListItem Value="Checking">Checking Account</asp:ListItem>
                        <asp:ListItem>Savings</asp:ListItem>
                        <asp:ListItem Value="MM">Money Market</asp:ListItem>
                        <asp:ListItem>Bonds</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">Loan Amount<span style="color: #FF0000"><strong>*</strong></span>:</td>
                <td>
                    <asp:TextBox ID="LoanAmount" runat="server" Width="250px" MaxLength="7" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVLoanAmount" runat="server" ControlToValidate="LoanAmount" ErrorMessage="Please enter your loan amount." ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RVLoanAmount" runat="server" ControlToValidate="LoanAmount" ErrorMessage="Please enter a value betwen 100,000 to 500,000" ForeColor="Red" MaximumValue="500000" MinimumValue="100000" Type="Double"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">Loan Term:</td>
                <panel id="LoanSupervisor">
                    <td>
                        <asp:RadioButtonList ID="LoanTerm" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="7ARM">7 Year ARM</asp:ListItem>
                            <asp:ListItem Value="10Year">10 Year Fix Rate</asp:ListItem>
                            <asp:ListItem Value="30Year">30 Year Fix Rate</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        hide this by default, show this when 7 year ARM is selected.<br />
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </panel>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">Down Payment (%)<span style="color: #FF0000"><strong>*</strong></span>:</td>
                <td>
                    <asp:TextBox ID="DownPayment" runat="server" Width="42px" ToolTip="Please enter your down payment as a percentage of your total purchase price." TextMode="Number"></asp:TextBox>%
                    <asp:RequiredFieldValidator ID="RFVDownPayment" runat="server" ControlToValidate="DownPayment" ErrorMessage="Please enter your down payment %." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">&nbsp;</td>
                <td>
                    <asp:Button ID="Submit" runat="server" BackColor="#A61F38" ForeColor="White" OnClick="Submit_Click" Text="Submit Form" />
                </td>
            </tr>
            <tr>
                <td style="width: 386px" class="modal-sm">&nbsp;</td>
                <td></td>
            </tr>
        </table>

    </asp:Panel>

    <asp:Label ID="ResultMsg" runat="server" Style="font-size: large"></asp:Label>
</asp:Content>
