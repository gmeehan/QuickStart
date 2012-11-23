<%@ Page Title="OrderInvoice" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="OrderInvoice.aspx.cs" Inherits="QuickStartRetailer._OrderInvoice" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:GridView ID="OrderItemsGrid" runat="server" AutoGenerateColumns="false" 
                GridLines="None" CssClass="mGrid" PagerStyle-CssClass="pgr" 
                AlternatingRowStyle-CssClass="alt" ShowHeaderWhenEmpty="true" AllowSorting="True"
                HeaderStyle-Wrap="true" onsorting="HistoryGrid_Sorting">
        <Columns>
            <asp:BoundField HeaderText="Product Code" DataField="ProdCode" SortExpression="ProdCode" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Product Name" DataField="ProdName" SortExpression="ProdName" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Product Description" DataField="ProdDesc" SortExpression="ProdDesc">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="MSRP" DataField="MSRP" SortExpression="MSRP" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Quantity" DataField="Quantity" SortExpression="Quantity" >
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Tax" DataField="Tax" SortExpression="Tax" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Total" DataField="Total" SortExpression="Total" DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
        </Columns>
        
    </asp:GridView>
</asp:Content>
