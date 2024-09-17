<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProspectiveStudent.aspx.cs" Inherits="CIS325_Web_Master_Project.Demos.MATDepartment.ProspectiveStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .sideways {
            background: black;
            text-orientation: sideways;
            writing-mode: vertical-lr;
            color: white;
        }
        .customTextbox{
            background:#d5bb7f;
        }
    </style>
    
    
    <h1>MAT Prospective Students Form</h1>

    <br />
    <asp:Panel ID="Panel1" runat="server">
    <table style="border: 1px solid black" width="100%" cellpadding="10">
        <tr>
            <td width="30%">
                <strong>Student Name: </strong>
            </td>

            <td width="70%">
                <asp:TextBox runat="server" ID="Name" class="customTextbox"></asp:TextBox></td>

        </tr>
        
        <tr>
            <td width="30%">
                <strong>Gender: </strong>
            </td>

            <td width="70%">
                <asp:RadioButtonList runat="server" ID="Gender" RepeatDirection="Horizontal">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Age: </strong>
            </td>

            <td width="70%">
                <asp:TextBox runat="server" ID="Age" Width="40px"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Email: </strong>
            </td>

            <td width="70%"></td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Intended Major: </strong>
            </td>

            <td width="70%"></td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Technical Skills</strong>
            </td>

            <td width="70%">
                <table style="border: 1px dashed black" width="100%">
                    <tr>
                        <td width="50%"><i>Programming Languages</i></td>
                        <td width="50%"><i>Developer Tools</i></td>
                    </tr>
                    <tr>
                        <td width="50%">
                            <asp:CheckBoxList runat="server" ID="Languages">
                                <asp:ListItem>C#</asp:ListItem>
                                <asp:ListItem>Python</asp:ListItem>
                                <asp:ListItem>JavaScript</asp:ListItem>
                                <asp:ListItem>Swift</asp:ListItem>
                                <asp:ListItem>HMTL</asp:ListItem>
                                <asp:ListItem>CSS</asp:ListItem>
                                <asp:ListItem>Other</asp:ListItem>
                            </asp:CheckBoxList></td>
                        <td width="50%">
                            <asp:CheckBoxList runat="server" ID="DevTools">
                                <asp:ListItem>Visual Studio</asp:ListItem>
                                <asp:ListItem>XCode</asp:ListItem>
                                <asp:ListItem>Jupyter Notebook</asp:ListItem>
                                <asp:ListItem>:PyCharm</asp:ListItem>
                                <asp:ListItem>SQL Management Studio</asp:ListItem>
                            </asp:CheckBoxList></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Comments: </strong>
            </td>

            <td width="70%">
                <asp:TextBox runat="server" TextMode="MultiLine" Width="500" Height="200"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="30%">
                <asp:Button runat="server" Text="Submit" ID="Submit"></asp:Button>&nbsp;</td>

            <td width="70%"></td>
               
        </tr>



    </table>
    </asp:Panel>
   
     <asp:Label runat="server" ID="ResultMsg"></asp:Label>

</asp:Content>
