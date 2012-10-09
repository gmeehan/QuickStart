<%@ Page Title="Category" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Category.aspx.cs" Inherits="QuickStartRetailer._Category" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="left-nav">
            <div class="nav-head">
                <h2>
                    <a href="Category.aspx">Categories</a>
                </h2>
                <div class="h-dot"><img width="1" height="1" alt="" src="/Images/spacer1px.gif"></div>
            </div>
            <div class="nav-box">
               <div>
                    <p>1</p>
                    <p>2</p>
                    <p>3</p>
                    <p>4</p>
                    <p>5</p>
                    <p>5</p>
                    <p>5</p>
               </div>     
            </div>
            <div class="nav-end">
                <p>
                    <img width="7" height="8" alt="" src="/Images/blue-arrow.png">
                    <a href="/Category.aspx">Get Started!</a>
                </p>
            </div>
        </div>
</asp:Content>
