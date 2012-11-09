<%@ Page Title="Category" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Category.aspx.cs" Inherits="QuickStartRetailer._Category" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
<asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView CssClass="left-nav" ID="TreeViewLeftNav" 
        ShowExpandCollapse="false" runat="server" NodeWrap="true"
        onselectednodechanged="TreeViewLeftNav_SelectedNodeChanged">
            <RootNodeStyle Font-Size="14px" Font-Bold="true" ForeColor="DarkBlue" />
            <NodeStyle Font-Size="12px" ForeColor="DarkBlue" NodeSpacing="5px" />
            <SelectedNodeStyle Font-Size="14px" ForeColor="Black" />
        </asp:TreeView>
        <div class="products-content">
            <h2 id="subcategoryTitle" runat="server" class="subcategory-heading">Subcategory Title</h2>
            <asp:DataList ID="DataListProducts"  CssClass="productList"  
                RepeatDirection="Horizontal" RepeatColumns="3" runat="server" 
                onitemcreated="DataListProducts_ItemCreated">
                <ItemStyle CssClass="productListOuterCell" />
            <ItemTemplate>
                <div id="productListInnerCell" runat="server" class="productListInnerCell">
                    <asp:HyperLink ID="ProductImageLink" NavigateUrl='<%# "~/ProductInfo.aspx?prodcd=" + Eval("ProductCode") %>' runat="server">
                        <asp:Image ID="Image1" CssClass="product-image-small" ImageUrl="~/Images/image1.jpg" runat="server" />
                    </asp:HyperLink>
                    <br />
                    <asp:Label ID="LabelPrice" runat="server" CssClass="product-price-small" Text='<%# Eval("MSRP") %>' />
                    <br />
                    <br />
                    <asp:HyperLink ID="ProductNameLink" CssClass="product-name-small" NavigateUrl='<%# "~/ProductInfo.aspx?prodcd=" + Eval("ProductCode") %>' runat="server"><%# Eval("Name") %></asp:HyperLink>
                    <br />
                </div>
            </ItemTemplate>
            </asp:DataList>
        </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
