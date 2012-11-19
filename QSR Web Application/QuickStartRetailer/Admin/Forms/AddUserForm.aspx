<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserForm.aspx.cs" MasterPageFile="~/Admin/Forms/Form.Master" Inherits="QuickStartRetailer.Admin.Forms.AddUserForm" %>
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
        <h2 runat="server" id="formTitleHeader">Add User</h2>
    </div>
    <div class="form_ContentLeft">
        <div class="form_row">
            <asp:Label ID="Label2" CssClass="form_label" runat="server" Width="100px" Text="User ID:"></asp:Label>
            <asp:Label ID="LabelUserID" CssClass="form_label" runat="server" Text=""></asp:Label>
        </div>
        <div class="form_row">
            <asp:Label ID="Label1" CssClass="form_label" runat="server" Width="100px" Text="Username:"></asp:Label>
            <asp:TextBox ID="TextBoxUsername" CssClass="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label3" CssClass="form_label" runat="server" Width="100px" Text="Password:"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" CssClass="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label4" CssClass="form_label" runat="server" Width="100px" Text="Salutation:"></asp:Label>
            <asp:TextBox ID="TextBoxSalutation" CssClass="form_textbox_medium"  runat="server"></asp:TextBox>
        </div>
        <div class="form_row"> 
            <asp:Label ID="Label5" CssClass="form_label" runat="server" Width="100px" Text="First Name:"></asp:Label>
            <asp:TextBox ID="TextBoxFirstName" CssClass="form_textbox_medium"  runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label6" CssClass="form_label" runat="server" Width="100px" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="TextBoxLastName" CssClass ="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label13" CssClass="form_label" runat="server" Width="100px" Text="Address 1:"></asp:Label>
            <asp:TextBox ID="TextBoxAddress1" CssClass ="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label14" CssClass="form_label" runat="server" Width="100px" Text="Address 2:"></asp:Label>
            <asp:TextBox ID="TextBoxAddress2" CssClass ="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form_ContentRight">
        <div class="form_row">
            <asp:Label ID="Label15" CssClass="form_label" runat="server" Width="100px" Text="City:"></asp:Label>
            <asp:TextBox ID="TextBoxCity" CssClass ="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label7" CssClass="form_label" runat="server" Width="100px" Text="State/Province:"></asp:Label>
            <asp:DropDownList ID="DropDownListStateProvince" CssClass="form_dropdown_medium" runat="server"></asp:DropDownList>
        </div>
        <div class="form_row">
            <asp:Label ID="Label8" CssClass="form_label" runat="server" Width="100px" Text="Zip/Postal Code"></asp:Label>
            <asp:TextBox ID="TextBoxZipPostalCode" CssClass ="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label9" CssClass="form_label" runat="server" Width="100px" Text="Email:"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" CssClass="form_textbox_medium" runat="server"></asp:TextBox>
        </div>
        <div class="form_row">
            <asp:Label ID="Label10" CssClass="form_label" runat="server" Width="100px" Text="Newsletters?:"></asp:Label>
            <asp:CheckBox ID="CheckBoxIsReceiveNewsletters" runat="server" />
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
