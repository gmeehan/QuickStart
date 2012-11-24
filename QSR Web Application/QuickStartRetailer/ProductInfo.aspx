<%@ Page Title="Product Info" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ProductInfo.aspx.cs" Inherits="QuickStartRetailer._ProductInfo" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="title" runat="server" Text="Title" /><br />
    <asp:Label ID="productCode" runat="server" Text="Product Code" /><br />
    <asp:Label ID="brand" runat="server" Text="Brand" CssClass="productInfoMargins"/>
    <asp:Label ID="price" runat="server" Text="Price" /><br /><br />
    <asp:Image ID="itemPic" runat="server" ImageUrl="~/Images/arrow.png" /><br />
    Quantity Remaining:&nbsp;<asp:Label ID="quantity" runat="server" Text="OVER 9000" /><br />
    <asp:Button ID="submit" runat="server" Text="Add to Cart" OnClick="addCartClick" />
</asp:Content>
