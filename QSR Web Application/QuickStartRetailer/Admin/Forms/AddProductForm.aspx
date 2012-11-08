<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProductForm.aspx.cs" MasterPageFile="~/Admin/Forms/Form.Master" Inherits="QuickStartRetailer.Admin.Forms.AddProductForm" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ButtonCancel").click(function () {
                window.top.window.$.fancybox.close();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="form_title">
        <h2 runat="server" id="formTitleHeader">Add Product</h2>
    </div>
    <div class="form_ContentLeft">
        <div class="form_row">
            <asp:Label ID="Label2" CssClass="form_label" runat="server" Width="100px" Text="Product Code:"></asp:Label>
            <asp:TextBox ID="TextBoxProductCode" MaxLength="10" CssClass="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label1" CssClass="form_label" runat="server" Width="100px" Text="Name:"></asp:Label>
            <asp:TextBox ID="TextBoxName" MaxLength="50" CssClass="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label3" CssClass="form_label" runat="server" Width="100px" Text="Brand:"></asp:Label>
            <asp:TextBox ID="TextBoxBrand" MaxLength="50" CssClass="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label4" CssClass="form_label" runat="server" Width="100px" Text="Description:"></asp:Label>
            <asp:TextBox ID="TextBoxDescription" MaxLength="200" CssClass="form_textbox_medium"  runat="server"></asp:TextBox>
        </div>
        <div class="form_row"> 
            <asp:Label ID="Label5" CssClass="form_label" runat="server" Width="100px" Text="Category:"></asp:Label>
            <asp:DropDownList ID="DropDownListCategory" CssClass="form_dropdown_medium" runat="server"></asp:DropDownList>
        </div>
        <div class="form_row">
            <asp:Label ID="Label6" CssClass="form_label" runat="server" Width="100px" Text="MSRP:"></asp:Label>
            <asp:TextBox ID="TextBoxMSRP" CssClass ="form_textbox_numeric_short" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form_ContentRight">
        <div class="form_row">
            <asp:Label ID="Label7" CssClass="form_label" runat="server" Width="100px" Text="Free Shipping:"></asp:Label>
            <asp:CheckBox ID="CheckBoxFreeShipping" runat="server" />
        </div>
        <div class="form_row">
            <asp:Label ID="Label8" CssClass="form_label" runat="server" Width="100px" Text="Tax Free:"></asp:Label>
            <asp:CheckBox ID="CheckBoxTaxFree" runat="server" />
        </div>
        <div class="form_row">
            <asp:Label ID="Label9" CssClass="form_label" runat="server" Width="100px" Text="Qty In Stock:"></asp:Label>
            <asp:TextBox ID="TextBoxQtyInStock" CssClass="form_textbox_numeric_short" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label10" CssClass="form_label" runat="server" Width="100px" Text="Qty Unlimited:"></asp:Label>
            <asp:CheckBox ID="CheckBoxQtyUnlimited" runat="server" />
        </div>
        <div class="form_row">
            <asp:Label ID="Label11" CssClass="form_label" runat="server" Width="100px" Text="Created:"></asp:Label>
            <asp:Label ID="LabelCreated" CssClass="form_label" runat="server" Text=""></asp:Label>
        </div>
        <div class="form_row">
            <asp:Label ID="Label12" CssClass="form_label" runat="server" Width="100px" Text="Last Modified:"></asp:Label>
            <asp:Label ID="LabelModified" CssClass="form_label" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="form_bottom_div">
        <div class="form_buttons_div">
            <asp:Button ID="ButtonSubmit" CssClass="fancy_button" runat="server" 
                Text="Save Changes" onclick="ButtonSubmit_Click" />
            <asp:Button ID="ButtonCancel" ClientIDMode="Static" CssClass="fancy_button" runat="server" Text="Cancel" />
        </div>
        <div class="form_output_div">
            <asp:Label ID="LabelOutput" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
