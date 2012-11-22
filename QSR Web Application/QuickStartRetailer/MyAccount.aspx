<%@ Page Title="My Account" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="MyAccount.aspx.cs" Inherits="QuickStartRetailer._MyAccount" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="AccountMenu">
        <a href="MyProfile.aspx">Update Profile</a>
        <a href="OrderHistory.aspx">Order History</a>
        <asp:LinkButton ID="LinkButtonLoginLogout" runat="server" 
                                    onclick="Logout_Click">Logout</asp:LinkButton>
    </div>
</asp:Content>
