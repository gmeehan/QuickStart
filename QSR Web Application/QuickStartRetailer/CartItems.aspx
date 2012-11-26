<%@ Page Title="Add To Cart" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="CartItems.aspx.cs" Inherits="QuickStartRetailer._CartItems" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:DataList ID="DataListProducts"  CssClass="productList"  OnItemCommand ="DataListProducts_ItemCommand"  
                RepeatDirection="Vertical" RepeatColumns="1" runat="server">
                <ItemStyle CssClass="productListOuterCell"  />
            <ItemTemplate>
                <div id="productListInnerCell" runat="server" >
                    <asp:HyperLink ID="ProductImageLink" NavigateUrl='<%# "~/ProductInfo.aspx?prodcd=" + Eval("Prodcd") %>' runat="server">
                        <asp:Image ID="Image1" CssClass="product-image-small-left" ImageUrl='<%# Eval("Img") %>' runat="server" />
                    </asp:HyperLink>
                    <asp:Label ID="LabelName" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                    $<asp:Label ID="LabelCost" runat="server" Text='<%# Eval("Price") %>' />
                    <br />
                    Quantity:&nbsp;<asp:TextBox ID="TxtQty" runat="server" Text='<%# Eval("Qty") %>' Columns="1" />
                    <br />
                    <asp:Button ID="ButtonUpdateQty" runat="server" Text="Update Qty" CommandName='<%# Eval("Prodcd")%>' EnableViewState="true"/>
                    <br />
                    Total:&nbsp;$<asp:Label ID="Label1" runat="server" Text='<%# Eval("Total") %>' />
                </div>
            </ItemTemplate>
            </asp:DataList>
</asp:Content>
