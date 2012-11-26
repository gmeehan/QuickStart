<%@ Page Title="Index" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="QuickStartRetailer._Index" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div id="slider">
	    <div class="simpleSlide-window" rel="0">
	        <div class="simpleSlide-tray" rel="0">
	            <div class="simpleSlide-slide" rel="0">
                   <div class="featured_slide">
	                    <img id="ImageFeatured1" runat="server" class="slide-product-image" src="Images/image1.jpg" alt="" />
                        <div class="slide-product-detailsDiv">
                            <asp:Label ID="LabelFeaturedBrand1" class="slide-product-brand" runat="server" Text="Label"></asp:Label>
                            <br />
                            <asp:Label ID="LabelFeaturedName1" class="slide-product-name" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <hr />
                            <br />
                            <asp:Label ID="LabelFeaturedPrice1" class="slide-product-price" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:LinkButton ID="LinkButtonFeatured1" CssClass="fancy_button" runat="server">More Information</asp:LinkButton>
                        </div>
                   </div>
	            </div>
	            <div class="simpleSlide-slide" rel="0">
                    <div class="featured_slide">
	                    <img id="ImageFeatured2" runat="server" class="slide-product-image" src="Images/image2.jpg" alt="" />
                        <div class="slide-product-detailsDiv">
                            <asp:Label ID="LabelFeaturedBrand2" class="slide-product-brand" runat="server" Text="Label"></asp:Label>
                            <br />
                            <asp:Label ID="LabelFeaturedName2" class="slide-product-name" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <hr />
                            <br />
                            <asp:Label ID="LabelFeaturedPrice2" class="slide-product-price" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:LinkButton ID="LinkButtonFeatured2" CssClass="fancy_button" runat="server">More Information</asp:LinkButton>
                        </div>
                    </div>
	            </div>
	            <div class="simpleSlide-slide" rel="0">
                    <div class="featured_slide">
	                    <img id="ImageFeatured3" runat="server" class="slide-product-image" src="Images/image3.jpg" alt="" />
                        <div class="slide-product-detailsDiv">
                            <asp:Label ID="LabelFeaturedBrand3" class="slide-product-brand" runat="server" Text="Label"></asp:Label>
                            <br />
                            <asp:Label ID="LabelFeaturedName3" class="slide-product-name" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <hr />
                            <br />
                            <asp:Label ID="LabelFeaturedPrice3" class="slide-product-price" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:LinkButton ID="LinkButtonFeatured3" CssClass="fancy_button" runat="server">More Information</asp:LinkButton>
                        </div>
                    </div>
	            </div>
	            <div class="simpleSlide-slide" rel="0">
                    <div class="featured_slide">
	                    <img id="ImageFeatured4" runat="server" class="slide-product-image" src="Images/image4.jpg" alt="" />
                        <div class="slide-product-detailsDiv">
                            <asp:Label ID="LabelFeaturedBrand4" class="slide-product-brand" runat="server" Text="Label"></asp:Label>
                            <br />
                            <asp:Label ID="LabelFeaturedName4" class="slide-product-name" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <hr />
                            <br />
                            <asp:Label ID="LabelFeaturedPrice4" class="slide-product-price" runat="server" Text="Label"></asp:Label>
                            <br />
                            <br />
                            <asp:LinkButton ID="LinkButtonFeatured4" CssClass="fancy_button" runat="server">More Information</asp:LinkButton>
                        </div>
                    </div>
	            </div>
	        </div>
	    </div>
	
	    <div id="simpleSlide-nav">
		    <div class="left-button pointer" rel="0"><img src="Images/left.png" alt="" /></div>
		    <div class="right-button pointer" rel="0"><img src="Images/right.png" alt="" /></div>
	    </div>
	
	    <div id="status-tray">
		    <div class="simpleSlideStatus-tray" rel="0">
		        <div class="simpleSlideStatus-window" rel="0"></div>
		    </div>
	    </div>
        <div class="auto-slider" rel="0"></div>
	
	    <!-- //////////////////////////////////////////////////
	    //////////////////  Use only one.  ////////////////////
	    ///////////////////////////////////////////////////////
	    <div id="simpleSlide-jump-to">
		    <div class="jump-to pointer" rel="0" alt="1"></div>
		    <div class="jump-to pointer" rel="0" alt="2"></div>
		    <div class="jump-to pointer" rel="0" alt="3"></div>
		    <div class="jump-to pointer" rel="0" alt="4"></div>
	    </div>
	    /////////////////////////////////////////////////// -->
    </div><!-- end #slider -->

    <!--
    <div class="left-content-section">
        <div class="index-info-box">
            <div class="info-head">
                <h2>
                    <a href="AddToCart.aspx">Add To Cart</a>
                </h2>
                <div class="h-dot"><img width="1" height="1" alt="" src="/Images/spacer1px.gif"></div>
            </div>
            <div class="info-box">
               <div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ut ipsum vel dui.</p>
                    <p>
                        <img width="7" height="8" alt="" src="/Images/blue-arrow.png">
                        <a href="/AddToCart.aspx">Get Started!</a>
                    </p>
               </div>     
            </div>
        </div>
    </div>

    <div class="right-content-section">
        <div class="index-info-box">
            <div class="info-head">
                <h2>
                    <a href="ProductInfo.aspx">Products</a>
                </h2>
                <div class="h-dot"><img width="1" height="1" alt="" src="/Images/spacer1px.gif"></div>
            </div>
            <div class="info-box">
               <div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ut ipsum vel dui.</p>
                    <p>
                        <img width="7" height="8" alt="" src="/Images/blue-arrow.png">
                        <a href="/ProductInfo.aspx">Get Started!</a>
                    </p>
               </div>     
            </div>
        </div>
    </div>
    -->
    <br />
    <div id="HomepageProducts" class="homepage_products">
        <h1 style="font-weight:bold; text-align:center">Featured Products</h1>
        <asp:DataList ID="DataListProducts" CssClass="productList" RepeatDirection="Horizontal" 
        RepeatColumns="3" runat="server" onitemcreated="DataListProducts_ItemCreated">
            <ItemStyle CssClass="productListOuterCell" />
                <ItemTemplate>
                    <div id="productListInnerCell" runat="server" class="productListInnerCell">
                        <asp:HyperLink ID="ProductImageLink" NavigateUrl='<%# "~/ProductInfo.aspx?prodcd=" + Eval("ProductCode") %>' runat="server">
                            <asp:Image ID="Image1" CssClass="product-image-small" ImageUrl='<%# "~/Images/Product_Images/" + Eval("ProductCode") + ".jpg" %>' 
                            runat="server" />
                        </asp:HyperLink>
                        <br />
                        <asp:Label ID="LabelPrice" runat="server" CssClass="product-price-small" Text='<%# Eval("MSRP") %>' />
                        <br />
                        <br />
                        <asp:HyperLink ID="ProductNameLink" CssClass="product-name-small" NavigateUrl='<%# "~/ProductInfo.aspx?prodcd=" + Eval("ProductCode") %>' 
                        runat="server"><%# Eval("Name") %></asp:HyperLink>
                        <br />
                    </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <br />

</asp:Content>
