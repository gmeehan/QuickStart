<%@ Page Title="Product Management" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Products.aspx.cs" Inherits="QuickStartRetailer.Admin._Products" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
            <asp:BoundField HeaderText="Cat ID" DataField="CategoryID" SortExpression="CategoryID">
                <ItemStyle HorizontalAlign="Right" Width="50px"></ItemStyle>
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
                <ItemStyle HorizontalAlign="Right" Width="50px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Qty Unlimited" DataField="IsQuantityUnlimited" SortExpression="IsQuantityUnlimited">
                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Created" DataField="Created" SortExpression="Created">
                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Modified" DataField="Modified" SortExpression="Modified">
                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField>
                <ItemStyle Width="50px"></ItemStyle>
                <ItemTemplate>
                    <a runat="server" id="edit" class="fancybox_600x500"><img alt="edit" src="Images/clipboard_edit.png" /></a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
