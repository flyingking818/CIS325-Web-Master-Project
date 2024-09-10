<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="CIS325_Web_Master_Project.Demos.HelloWorld.HelloWorld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Hello world! Welcome to my site! :)
    <br />
    1) Embed C#
    <br />
    Today is: <%=DateTime.Now.ToString("MMMM dd, yyyy") %>
    <p>
    2) Code-behind C# (more common in ASP.NET web form)
        <br />

        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />

    </p>
    <p>&nbsp;</p>

</asp:Content>
