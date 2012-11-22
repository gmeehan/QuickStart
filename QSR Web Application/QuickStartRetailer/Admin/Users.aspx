<%@ Page Title="User Management" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Users.aspx.cs" Inherits="QuickStartRetailer.Admin._Users" %>


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
            $(".fancybox_700x525").fancybox({ //add/edit boxes
            'autoSize': false,
            'width': 700,
            'height': 525,
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
<a runat="server" id="add" class="fancybox_700x525" href="~/Admin/Forms/AddUserForm.aspx">
    <asp:Button ID="ButtonAddUser" runat="server" CssClass="fancy_button" Text="Add New User" />
</a>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" onload="UpdatePanel1_Load" UpdateMode="Conditional"> 
    <ContentTemplate>  
        <div style="padding:10px; width:100%; overflow:auto; background-color:#F2F2F2; border:1px solid black">
            <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="false" 
                PageSize="5" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" 
                AlternatingRowStyle-CssClass="alt" 
                onpageindexchanging="GridViewUsers_PageIndexChanging" 
                AllowSorting="True" onsorting="GridViewUsers_Sorting" 
                onrowdatabound="GridViewUsers_RowDataBound"
                HeaderStyle-Wrap="true">
                <Columns>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <a runat="server" id="edit" class="fancybox_700x525"><img alt="edit" src="Images/clipboard_edit.png" /></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="UserID" DataField="UserID" SortExpression="UserID">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Username" DataField="Username" SortExpression="Username">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Password" DataField="Password" SortExpression="Password">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Salutation" DataField="Salutation" SortExpression="Salutation">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="FirstName" DataField="FirstName" SortExpression="FirstName">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="LastName" DataField="LastName" SortExpression="LastName">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Address1" DataField="Address1" SortExpression="Address1">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Address2" DataField="Address2" SortExpression="Address2">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="City" DataField="City" SortExpression="City">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="StateProvinceID" DataField="StateProvinceID" SortExpression="StateProvinceID">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ZipCodePostal" DataField="ZipCodePostal" SortExpression="ZipCodePostal">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Email" DataField="Email" SortExpression="Email">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="IsReceiveNewsletters" DataField="IsReceiveNewsletters" SortExpression="IsReceiveNewsletters">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Created" DataField="Created" SortExpression="Created">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Modified" DataField="ModifiedDisplay" SortExpression="ModifiedDisplay" NullDisplayText="">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
