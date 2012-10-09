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
        <h7><a href="/MyProfile.aspx">Heading 1</a></h7>
        <ul>
            <li class="index-list-item">item 1</li>
            <li class="index-list-item">item 2</li>
            <li class="index-list-item">item 3</li>
        </ul>
        <h7><a href="/MyAccount.aspx">Heading 3</a></h7>
        <ul>
            <li class="index-list-item">item 1</li>
            <li class="index-list-item">item 2</li>
            <li class="index-list-item">item 3</li>
        </ul>
    </div>
    <div class="right-content-section">
        <h7><a href="/ProductInfo.aspx">Heading 2</a></h7>
        <ul>
            <li class="index-list-item">item 1</li>
            <li class="index-list-item">item 2</li>
            <li class="index-list-item">item 3</li>
        </ul>
        <h7><a href="/OrderHistory.aspx">Heading 4</a></h7>
        <ul>
            <li class="index-list-item">item 1</li>
            <li class="index-list-item">item 2</li>
            <li class="index-list-item">item 3</li>
        </ul>
    </div>
</asp:Content>
