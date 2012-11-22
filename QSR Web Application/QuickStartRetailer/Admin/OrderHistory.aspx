<%@ Page Title="Order History" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="OrderHistory.aspx.cs" Inherits="QuickStartRetailer.Admin._OrderHistory" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script type="text/javascript">
        $(document).ready(function () {
            $(".fancybox_700x425").fancybox({ //add/edit boxes
            'autoSize': false,
            'width': 700,
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
<asp:UpdatePanel ID="UpdatePanel1" runat="server" onload="UpdatePanel1_Load" UpdateMode="Conditional"> 
    <ContentTemplate>  
        <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="false" 
            PageSize="5" GridLines="None"
            AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" 
            AlternatingRowStyle-CssClass="alt" 
            onpageindexchanging="GridViewOrders_PageIndexChanging" 
            AllowSorting="True" onsorting="GridViewOrders_Sorting" 
            onrowdatabound="GridViewOrders_RowDataBound" 
            ShowHeaderWhenEmpty="true"
            HeaderStyle-Wrap="true">
            <Columns>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <a runat="server" id="edit" class="fancybox_700x425"><img alt="edit" src="Images/clipboard_edit.png" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="OrderID" DataField="OrderID" SortExpression="OrderID">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="UserID" DataField="UserID" SortExpression="UserID">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" SortExpression="Subtotal" DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Taxes" DataField="Taxes" SortExpression="Taxes" DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Delivery Cost" DataField="DeliveryCost" SortExpression="DeliveryCost" DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Delivery Type ID" DataField="DeliveryTypeID" SortExpression="DeliveryTypeID">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Grand Total" DataField="GrandTotal" SortExpression="GrandTotal" DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Created" DataField="Created" SortExpression="Created">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Modified" DataField="ModifiedDisplay" SortExpression="ModifiedDisplay" NullDisplayText="">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

