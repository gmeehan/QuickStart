<%@ Page Title="Table Management" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="EditTables.aspx.cs" Inherits="QuickStartRetailer.Admin._EditTables" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:DropDownList ID="DropDownListDBTables" runat="server" AutoPostBack="true" 
        onselectedindexchanged="DropDownListDBTables_SelectedIndexChanged"></asp:DropDownList>

    <asp:GridView ID="GridViewDBTable" AutoGenerateColumns="true" 
        ShowHeaderWhenEmpty="true" runat="server"
        PageSize="20" GridLines="None" AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr"
         AlternatingRowStyle-CssClass="alt" AllowSorting="True" 
        HeaderStyle-Wrap="true" onpageindexchanging="GridViewDBTable_PageIndexChanging" 
        onsorting="GridViewDBTable_Sorting">
    </asp:GridView>

</asp:Content>

<%--<asp:GridView ID="GridViewProducts" runat="server" AutoGenerateColumns="false" 
            PageSize="5" GridLines="None"
            AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" 
            AlternatingRowStyle-CssClass="alt" 
            onpageindexchanging="GridViewProducts_PageIndexChanging" 
            AllowSorting="True" onsorting="GridViewProducts_Sorting" 
            onrowdatabound="GridViewProducts_RowDataBound"
            HeaderStyle-Wrap="true">--%>
