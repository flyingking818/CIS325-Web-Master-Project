<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProspectiveStudent.aspx.cs" Inherits="CIS325_Web_Master_Project.Demos.MATDepartment.ProspectiveStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .sideways {
            text-orientation:sideways;
            background:black;
            color:#ede8da;
            writing-mode:vertical-lr;
        }

        .customTextbox{
           background:#cce1f6;
        }
    </style>
    
    
    
    <h1>MAT Prospective Students Form</h1>

    <br />
    <!-- This is my form layout-->
    <asp:Panel ID="FormPanel" runat="server">
    <table style="border: 1px solid black" width="100%" cellpadding="10px">
        <tr>
            <td width="30%" class="sideways">
                <strong>Student Name: </strong>

            </td>
            <td width="70%">
                <asp:TextBox ID="Name" runat="server" class="customTextbox"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="30%" class ="sideways">
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
                <table style="border: 1px dashed black" width="100%">
                    <tr>
                        <td><i>Programming Languages</i></td>
                        <td><em>Developer Tools</em></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList ID="ProgrammingLanguages" runat="server" Width="120px">
                                <asp:ListItem Value="CSharp">C#</asp:ListItem>
                                <asp:ListItem Value="Python">Python</asp:ListItem>
                                <asp:ListItem Value="Java">Java</asp:ListItem>
                                <asp:ListItem Value="Swift">Swift</asp:ListItem>
                                <asp:ListItem Value="HTML">HTML</asp:ListItem>
                                <asp:ListItem Value="CSS">CSS</asp:ListItem>
                                <asp:ListItem Value="Other">Other</asp:ListItem>
                            </asp:CheckBoxList>

                        </td>


                        <td>
                            <asp:CheckBoxList ID="DeveloperTools" runat="server" Width="200px">
                                <asp:ListItem Value="VS">Visual Studio</asp:ListItem>
                                <asp:ListItem Value="Xcode">Xcode</asp:ListItem>
                                <asp:ListItem Value="PyCharm">PyCharm</asp:ListItem>
                                <asp:ListItem Value="JN">Jupiter Notebook</asp:ListItem>
                                <asp:ListItem Value="Swift">SQL Management Studio</asp:ListItem>
                                <asp:ListItem Value="IntelliJ">IntelliJ</asp:ListItem>
                                <asp:ListItem Value="WS">WebSphere</asp:ListItem>
                                <asp:ListItem Value="Other">Other</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="30%">
                <strong>Comments: </strong>
            </td>
            <td width="70%">
                <asp:TextBox ID="Comments" runat="server" width="300px" height="100px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Submit" runat="server" Text="Submit Form" OnClick="Submit_Click" /></td>
            <td></td>
        </tr>

    </table>
    </asp:Panel>
    <asp:Label ID="ResultMsg" runat="server" Text=""></asp:Label>

</asp:Content>
