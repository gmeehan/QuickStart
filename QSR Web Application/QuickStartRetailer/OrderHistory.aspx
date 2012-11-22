<%@ Page Title="Order History" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="OrderHistory.aspx.cs" Inherits="QuickStartRetailer._OrderHistory" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="HistoryGrid" runat="server" AutoGenerateColumns="false" 
                GridLines="None" CssClass="mGrid" PagerStyle-CssClass="pgr" 
                AlternatingRowStyle-CssClass="alt" ShowHeaderWhenEmpty="true" AllowSorting="True"
                HeaderStyle-Wrap="true" onsorting="HistoryGrid_Sorting">
        <Columns>
            <asp:TemplateField HeaderText="Order ID">
                <ItemTemplate>
                    <a class="orderItemLink" runat="server" href='<%# "~/OrderInvoice.aspx?orderid=" + Eval("OrderID") %>'>'<%# Eval("OrderID") %>'</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Date Created" DataField="Created" SortExpression="Created" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Sub Total" DataField="SubTotal" SortExpression="SubTotal" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Tax" DataField="Taxes" SortExpression="Taxes" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Delivery Cost" DataField="DeliveryCost" SortExpression="DeliveryCost" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="GrandTotal" DataField="GrandTotal" SortExpression="GrandTotal" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
        </Columns>
        
    </asp:GridView>
</asp:Content>
