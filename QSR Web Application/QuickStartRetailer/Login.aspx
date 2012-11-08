<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="QuickStartRetailer._Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="userLoginDiv">
    <h2 class="textCenter">Already Registered? Sign In.</h2>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Username" Width="100px"></asp:Label>
    <asp:TextBox ID="TextBoxUsername" runat="server" Width="140px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password" Width="100px"></asp:Label>
    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="140px"></asp:TextBox>
    <br />
    <br />
    <div class="userLoginButtonDiv">
        <asp:Button ID="ButtonLogin" runat="server" Text="Login" CssClass="fancy_button" Width="90px" onclick="ButtonLogin_Click" />
    </div>
    <div class="userLoginMessageDiv">
        <asp:Label ID="LabelOutput" Width="200px" runat="server" Text=""></asp:Label>
    </div>
</div>
<div class="userRegisterDiv">
    <h2 class="textCenter">Don't Have an Account? Click to Register.</h2>
    <div class="userContToRegisterButtonDiv">
        <asp:Button ID="ButtonGoToRegister" runat="server" Text="Continue to Registration..." CssClass="fancy_button" onclick="ButtonGoToRegister_Click" />
    </div>
</div>
</asp:Content>
