<%@ Page Title="Product Management" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Products.aspx.cs" Inherits="QuickStartRetailer.Admin._Products" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script type="text/javascript">
        $(document).ready(function () {
            $(".fancybox_400x225").fancybox({ //activate/deactivate boxes
            'autoSize': false,
            'width': 400,
            'height': 225,
            'padding': 0,
            'type': 'iframe',
            'beforeClose': function() {
                <%=Page.ClientScript.GetPostBackEventReference(UpdatePanel1, "")%>
                }
            });
            $(".fancybox_600x425").fancybox({ //add/edit boxes
            'autoSize': false,
            'width': 600,
            'height': 425,
            'padding': 0,
            'type': 'iframe',
            'beforeClose': function() {
                <%=Page.ClientScript.GetPostBackEventReference(UpdatePanel1, "")%>
                }
            });
        });

    </script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:ScriptManager ID="ScriptManager1" runat="server" /> 
<br />
<a runat="server" id="add" class="fancybox_600x425" href="~/Admin/Forms/AddProductForm.aspx">
    <asp:Button ID="ButtonAddProduct" runat="server" CssClass="fancy_button" Text="Add New Product" />
</a>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" onload="UpdatePanel1_Load" UpdateMode="Conditional"> 
    <ContentTemplate>  
        <asp:GridView ID="GridViewProducts" runat="server" AutoGenerateColumns="false" 
            PageSize="5" GridLines="None"
            AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" 
            AlternatingRowStyle-CssClass="alt" 
            onpageindexchanging="GridViewProducts_PageIndexChanging" 
            AllowSorting="True" onsorting="GridViewProducts_Sorting" 
            onrowdatabound="GridViewProducts_RowDataBound"
            HeaderStyle-Wrap="true">
            <Columns>
                <asp:BoundField HeaderText="Prod Code" DataField="ProductCode" SortExpression="ProductCode">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Name" DataField="Name" SortExpression="Name">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Brand" DataField="Brand" SortExpression="Brand">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Desc" DataField="Description" SortExpression="Description">
                    <HeaderStyle Width="50"/>
                    <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Category" DataField="CategoryName" SortExpression="CategoryName">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="MSRP" DataField="MSRP" SortExpression="MSRP" DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Free Ship" DataField="IsFreeShipping" SortExpression="IsFreeShipping">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Tax Free" DataField="IsTaxFree" SortExpression="IsTaxFree">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Qty In Stock" DataField="QuantityInStock" SortExpression="QuantityInStock" DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Qty Unlimited" DataField="IsQuantityUnlimited" SortExpression="IsQuantityUnlimited">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Created" DataField="Created" SortExpression="Created">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Modified" DataField="ModifiedDisplay" SortExpression="ModifiedDisplay" NullDisplayText="">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <a runat="server" id="edit" class="fancybox_600x425"><img alt="edit" src="Images/clipboard_edit.png" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Active">
                    <ItemTemplate>
                        <a runat="server" id="activation" class="fancybox_400x225"><img alt="activation" /></a>
                    </ItemTemplate>
                 </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
