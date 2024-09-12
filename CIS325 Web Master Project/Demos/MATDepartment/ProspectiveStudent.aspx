<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProspectiveStudent.aspx.cs" Inherits="CIS325_Web_Master_Project.Demos.MATDepartment.ProspectiveStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>MAT Prospective Students Form</h1>

    <br />
    <!-- This is my form layout-->
    <table style="border: 1px solid black" width="100%" cellpadding="10">
        <tr>
            <td width="30%">
                <strong>Student Name: </strong>
                
            </td>
            <td width="70%">
                <asp:TextBox ID="Name" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Gender: </strong>
            </td>
            <td width="70%">
                <asp:RadioButtonList ID="Gender" Width="300px" runat="server" RepeatDirection="Horizontal" CellSpacing="5">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Age: </strong>
            </td>
            <td width="70%">
                <asp:TextBox ID="Age" Width="50" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Email: </strong>
            </td>
            <td width="70%">
                <asp:TextBox ID="Email" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Intended Major: </strong>
            </td>
            <td width="70%">
                <asp:DropDownList ID="IntendedMajor" runat="server">
                     <asp:ListItem Value="0">---Please Select---</asp:ListItem>
                    <asp:ListItem Value="CIS">Computer Information Systems</asp:ListItem>
                    <asp:ListItem Value="DS">Data Science</asp:ListItem>
                    <asp:ListItem Value="MATH">Mathematics</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Technical Skills: </strong>
            </td>
            <td width="70%">
                <table style="border:1px dashed black" width ="100%">
                    <tr>
                        <td>Programming Languages</td>
                        <td>Developer Tools</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Comments: </strong>
            </td>
            <td width="70%"></td>
        </tr>


    </table>


</asp:Content>
