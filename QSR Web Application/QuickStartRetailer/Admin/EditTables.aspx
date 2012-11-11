<%@ Page Title="Table Management" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="EditTables.aspx.cs" Inherits="QuickStartRetailer.Admin._EditTables" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:DropDownList ID="DropDownListDBTables" runat="server" AutoPostBack="true" 
        onselectedindexchanged="DropDownListDBTables_SelectedIndexChanged"></asp:DropDownList>
    <asp:GridView ID="GridViewDBTable" AutoGenerateColumns="true" runat="server"></asp:GridView>
</asp:Content>
