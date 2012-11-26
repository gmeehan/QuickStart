<%@ Page Title="Product Info" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ProductInfo.aspx.cs" Inherits="QuickStartRetailer._ProductInfo" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <br />
    <asp:Label ID="title" runat="server" Text="Title" CssClass="prodInfo_prodName" />
    <br />
    Product Code:&nbsp;<asp:Label ID="productCode" runat="server" Text="Product Code" />
    <br />
    <hr />
    <asp:Label ID="brand" runat="server" Text="Brand" CssClass="prodInfo_brand"/>
    <div class="prodInfo_RightDiv">
        <asp:Label ID="price" runat="server" Text="Price" CssClass="prodInfo_price" />
        <br />
        <br />
        <div class="prodInfo_RightInnerDiv">
            <asp:Label ID="quantity" runat="server" Text="" CssClass="prodInfo_quantity" />
            <br />
            <br />
            <asp:Label ID="LabelDeliveryTypesTitle" runat="server" Text="Available Delivery Types" CssClass="prodInfo_delTypesTitle" />
            <asp:GridView ID="GridViewDeliveryTypes" GridLines="None" CssClass="prodInfo_dtypesGV" ShowHeader="false" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="Name" SortExpression="Name">
                        <ItemStyle CssClass="prodInfo_dtypesGVItem" HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Cost" SortExpression="Cost" DataFormatString="{0:c}">
                        <ItemStyle CssClass="prodInfo_dtypesGVItem" HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="submit" runat="server" Text="Add to Cart" CssClass="fancy_button" OnClick="addCartClick" />
        </div>
    </div>
    <asp:Image ID="itemPic" runat="server" CssClass="prodInfo_image" />
    <br />
    <div class="prodInfo_DescriptionDiv">
        <asp:ToolkitScriptManager runat="Server" />
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
            <asp:TabPanel ID="TabPanelDetails" HeaderText="Details" runat="server">
                <ContentTemplate>
                    <br />
                    <asp:Label ID="LabelDescription" runat="server" Text="" CssClass="prodInfo_description"/>
                </ContentTemplate>  
            </asp:TabPanel>  
            <asp:TabPanel ID="TabPanelSpecs" HeaderText="Specifications" runat="server">  
                <ContentTemplate>  
                    
                </ContentTemplate>              
            </asp:TabPanel>  
        </asp:TabContainer>  
    </div>
</asp:Content>
