<%@ Page Title="SubCategory" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="SubCategory.aspx.cs" Inherits="QuickStartRetailer._SubCategory" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

        <div class="left-nav">
        <div class="nav-head" id="subCatDiv" runat="server" />
        <div class="nav-box">
            <div>
                <p>Product 1</p>  
                <p>Product 2</p> 
                <p>Product 3</p> 
                <p>Product 4</p> 
                <p>Product 5</p> 
            </div>
        </div>
        <div class="nav-end" />
    </div>
</asp:Content>
