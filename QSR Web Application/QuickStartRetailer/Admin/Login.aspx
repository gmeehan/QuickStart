<%@ Page Title="Administrator Login" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="QuickStartRetailer.Admin._Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="adminLoginDiv">
    <h2 class="textCenter">Administrator Login</h2>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Username" Width="100px"></asp:Label>
    <asp:TextBox ID="TextBoxUsername" runat="server" Text="admin" Width="140px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password" Width="100px"></asp:Label>
    <asp:TextBox ID="TextBoxPassword" runat="server" Text="admin" TextMode="Password" Width="140px"></asp:TextBox>
    <br />
    <br />
    <div class="adminLoginButtonDiv">
        <asp:Button ID="ButtonLogin" runat="server" Text="Login" CssClass="bold" 
            Width="90px" onclick="ButtonLogin_Click" />
    </div>
    <div class="adminLoginMessageDiv">
        <asp:Label ID="LabelOutput" Width="200px" runat="server" Text=""></asp:Label>
    </div>
</div>

</asp:Content>
