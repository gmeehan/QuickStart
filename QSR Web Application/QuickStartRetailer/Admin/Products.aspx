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
            $(".fancybox_870x420").fancybox({ //add/edit boxes
            'autoSize': false,
            'width': 870,
            'height': 420,
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
<h2 style="font-weight:bold; text-align:center;">Product Management</h2>
<a runat="server" id="add" class="fancybox_870x420" href="~/Admin/Forms/AddProductForm.aspx">
    <asp:Button ID="ButtonAddProduct" runat="server" CssClass="fancy_button" Text="Add New Product" />
</a>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" onload="UpdatePanel1_Load" UpdateMode="Conditional"> 
    <ContentTemplate>  
        <div style="padding:10px; width:100%; overflow:auto; background-color:#F2F2F2; border:1px solid black">
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
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Name" DataField="Name" SortExpression="Name">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Brand" DataField="Brand" SortExpression="Brand">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Desc" DataField="Description" SortExpression="Description">
                        <HeaderStyle Width="200px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Category" DataField="CategoryName" SortExpression="CategoryName">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="MSRP" DataField="MSRP" SortExpression="MSRP" DataFormatString="{0:c}">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Free Ship" DataField="IsFreeShipping" SortExpression="IsFreeShipping">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Tax Free" DataField="IsTaxFree" SortExpression="IsTaxFree">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Qty In Stock" DataField="QuantityInStock" SortExpression="QuantityInStock" DataFormatString="{0:d}">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Qty Unlimited" DataField="IsQuantityUnlimited" SortExpression="IsQuantityUnlimited">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Created" DataField="Created" SortExpression="Created">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Modified" DataField="ModifiedDisplay" SortExpression="ModifiedDisplay" NullDisplayText="">
                        <HeaderStyle Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Edit">
                        <HeaderStyle Width="40px" />
                        <ItemTemplate>
                            <a runat="server" id="edit" class="fancybox_870x420"><img alt="edit" src="Images/clipboard_edit.png" /></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Active">
                        <HeaderStyle Width="40px" />
                        <ItemTemplate>
                            <a runat="server" id="activation" class="fancybox_400x225"><img alt="activation" /></a>
                        </ItemTemplate>
                     </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" onload="UpdatePanel2_Load" UpdateMode="Conditional"> 
    <ContentTemplate>
        <div style="border:1px solid silver; padding:5px; width:100%; text-align:center; margin-bottom:30px; background-color: #FAFAFA;">
            <h1 style="font-weight:bold; text-align:center">Change Featured Products</h1>
            <br />
            <table class="FeaturedProductsTable">
                <tr>
                    <td>Product 1</td>
                    <td>Product 2</td>
                    <td>Product 3</td>
                    <td>Product 4</td>
                </tr>
                <tr>
                    <td><asp:DropDownList ID="DropDownListFeaturedProduct1" runat="server" /></td>
                    <td><asp:DropDownList ID="DropDownListFeaturedProduct2" runat="server" /></td>
                    <td><asp:DropDownList ID="DropDownListFeaturedProduct3" runat="server" /></td>
                    <td><asp:DropDownList ID="DropDownListFeaturedProduct4" runat="server" /></td>
                </tr>
            </table>
            <br />
            <asp:Button runat="server" CssClass="fancy_button" Text="Save Changes" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

