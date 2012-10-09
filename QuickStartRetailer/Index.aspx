<%@ Page Title="Index" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="QuickStartRetailer._Index" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="slider">
	    <div class="simpleSlide-window" rel="0">
	        <div class="simpleSlide-tray" rel="0">
	            <div class="simpleSlide-slide" rel="0">
	               <img src="Images/image1.jpg" alt="" />
	            </div>
	            <div class="simpleSlide-slide" rel="0">
	               <img src="Images/image1.jpg" alt="" />
	            </div>
	            <div class="simpleSlide-slide" rel="0">
	               <img src="Images/image1.jpg" alt="" />
	            </div>
	            <div class="simpleSlide-slide" rel="0">
	               <img src="Images/image1.jpg" alt="" />
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
</asp:Content>
