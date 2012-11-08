<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeactivateProductForm.aspx.cs" MasterPageFile="~/Admin/Forms/Form.Master" Inherits="QuickStartRetailer.Admin.Forms.DeactivateProductForm" %>
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
        <h2 runat="server" id="formTitleHeader">Deactivate Product</h2>
    </div>
    <div class="form_bottom_div">
        <div class="maxWidth textCenter bold">
            <p>Are you sure you want to deactivate this product?</p>
        </div>
        <br />
        <div class="form_buttons_div" style="width:130px">
            <asp:Button ID="ButtonSubmit" CssClass="fancy_button" runat="server" 
                Text="Confirm" onclick="ButtonSubmit_Click" />
            <asp:Button ID="ButtonCancel" ClientIDMode="Static" CssClass="fancy_button" runat="server" Text="Cancel" />
        </div>
        <div class="form_output_div">
            <asp:Label ID="LabelOutput" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
