<%@ Page Title="Product Management" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Products.aspx.cs" Inherits="QuickStartRetailer.Admin._Products" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script type="text/javascript">
    $(document).ready(function () {
        $(".fancybox").fancybox({
            'width': '75%',
            'height': '75%',
            'autoScale': false,
            'transitionIn': 'none',
            'transitionOut': 'none',
            'type': 'iframe'
        });
    });
    </script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
Products
<a class="fancybox" rel="group" href="Forms/AddProductForm.aspx">hi dave</a>
    <asp:GridView ID="GridViewProducts" AutoGenerateColumns="true" runat="server"></asp:GridView>
</asp:Content>
