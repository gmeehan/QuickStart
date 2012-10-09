<%@ Page Title="Category" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Category.aspx.cs" Inherits="QuickStartRetailer._Category" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="main-nav">
        <ul class="tree-menu">
            <li class="tree-item current-item"><a href="">Current Page</a></li>
            <hr />
            <li class="tree-item"><a href="">Subpage</a></li>
            <hr />
            <li class="tree-item"><a href="">Subpage 2</a></li>
            <hr />
            <li class="tree-item"><a href="">Subpage 3</a></li>
        </ul>
    </div>
</asp:Content>
