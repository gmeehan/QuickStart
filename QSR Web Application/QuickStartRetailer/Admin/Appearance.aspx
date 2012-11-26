<%@ Page Title="Appearance Management" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Appearance.aspx.cs" Inherits="QuickStartRetailer.Admin._Appearance" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="appearanceDiv">
    <h1 style="font-weight:bold">Edit Website Banner Logo</h1>
    <br />
    <asp:FileUpload ID="FileUploadBannerLogo" runat="server" />
    <br />
    <br />
    <asp:Button ID="ButtonUpdateBannerLogo" runat="server" Text="Update" 
        onclick="ButtonUpdateBannerLogo_Click" CssClass="fancy_button" />
    <br />
    <asp:Label ID="LabelOutput" runat="server"></asp:Label>
    </div>
</asp:Content>
