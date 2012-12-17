<%@ Page Title="Add To Cart" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="CartItems.aspx.cs" Inherits="QuickStartRetailer._CartItems" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:DataList ID="DataListCartItems"  CssClass="cartItemsList"  OnItemCommand ="DataListProducts_ItemCommand" Width="100%" RepeatDirection="Vertical" RepeatColumns="1" runat="server">
                <ItemStyle CssClass="cartItemsListItem" />
                <ItemTemplate>
                    <div runat="server" >
                        <asp:HyperLink ID="ProductImageLink" NavigateUrl='<%# "~/ProductInfo.aspx?prodcd=" + Eval("Prodcd") %>' runat="server">
                            <asp:Image ID="Image1" CssClass="product-image-small-left" ImageUrl='<%# Eval("Img") %>' runat="server" />
                        </asp:HyperLink>
                        <br />
                        <asp:Label ID="LabelName" Font-Bold="true" runat="server" Text='<%# Eval("Name") %>' />&nbsp;-&nbsp;
                        $<asp:Label ID="LabelCost" runat="server" Text='<%# Eval("Price") %>' />
                        <br />
                        <br />
                        Quantity:&nbsp;<asp:TextBox ID="TxtQty" runat="server" Text='<%# Eval("Qty") %>' Columns="1" />
                        <asp:Button ID="ButtonUpdateQty" runat="server" CssClass="fancy_button" Text="Update Qty" CommandName='<%# Eval("Prodcd")%>' EnableViewState="true"/>
                        <br />
                        <br />
                        Total:&nbsp;$<asp:Label ID="Label1" runat="server" Text='<%# Eval("Total") %>' />
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <div style="float:left;">
                <asp:Button ID="ButtonContinueShopping" runat="server" CssClass="fancy_button" 
                    Text="Continue Shopping..." onclick="ButtonContinueShopping_Click" />
            </div>
            <div style="float:right;">
                <asp:Button ID="ButtonCheckout" runat="server" CssClass="fancy_button" 
                    Text="Checkout..." onclick="ButtonCheckout_Click" />
            </div>

</asp:Content>
