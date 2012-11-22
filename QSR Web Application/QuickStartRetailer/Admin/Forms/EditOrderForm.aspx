<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditOrderForm.aspx.cs" MasterPageFile="~/Admin/Forms/Form.Master" Inherits="QuickStartRetailer.Admin.Forms.EditOrderForm" %>
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
        <h2 runat="server" id="formTitleHeader">Edit Order</h2>
    </div>
    <div class="form_ContentLeft">
        <div class="form_row">
            <asp:Label ID="Label2" CssClass="form_label" runat="server" Width="100px" Text="Order ID:"></asp:Label>
            <asp:Label ID="LabelOrderID" CssClass="form_label" runat="server" Text=""></asp:Label>
        </div>
        <div class="form_row">
            <asp:Label ID="Label6" CssClass="form_label" runat="server" Width="100px" Text="User:"></asp:Label>
            <asp:DropDownList ID="DropDownListUsers" CssClass="form_dropdown_medium" runat="server"></asp:DropDownList>
        </div>
        <div class="form_row">
            <asp:Label ID="Label1" CssClass="form_label" runat="server" Width="100px" Text="Subtotal:"></asp:Label>
            <asp:TextBox ID="TextBoxSubtotal" CssClass="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label3" CssClass="form_label" runat="server" Width="100px" Text="Taxes:"></asp:Label>
            <asp:TextBox ID="TextBoxTaxes" CssClass="form_textbox_medium" runat="server"></asp:TextBox>
        </div>

    </div>
    <div class="form_ContentRight">
        <div class="form_row">
            <asp:Label ID="Label4" CssClass="form_label" runat="server" Width="100px" Text="Delivery Cost:"></asp:Label>
            <asp:TextBox ID="TextBoxDeliveryCost" CssClass="form_textbox_medium"  runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label7" CssClass="form_label" runat="server" Width="100px" Text="Delivery Type:"></asp:Label>
            <asp:DropDownList ID="DropDownListDeliveryType" CssClass="form_dropdown_medium" runat="server"></asp:DropDownList>
        </div>
        <div class="form_row"> 
            <asp:Label ID="Label5" CssClass="form_label" runat="server" Width="100px" Text="Grand Total:"></asp:Label>
            <asp:TextBox ID="TextBoxGrandTotal" CssClass="form_textbox_medium"  runat="server"></asp:TextBox>
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
