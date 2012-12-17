<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Checkout.aspx.cs" Inherits="QuickStartRetailer._Checkout" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2 style="font-weight:bold; text-align:center">Checkout</h2>
<br />
<asp:ScriptManager ID="ScriptManager1" runat="server" /> 
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:DataList ID="DataListCheckout" runat="server" CssClass="DataListCheckout" 
        Width="100%" onitemdatabound="DataListCheckout_ItemDataBound">
    <ItemStyle CssClass="DataListCheckoutItem" BackColor="#FCFCFB" Font-Bold="true" />
    <AlternatingItemStyle BackColor="AliceBlue" Font-Bold="true" />
    <ItemTemplate>
        <br />
        <table>
            <!--Row 1-->
            <tr>
            <td width="200px"><asp:Label ID="LabelProdcd" runat="server" CssClass="" Text='<%# Eval("Prodcd") %>' /></td>
            <td width="150x">Quantity: <asp:Label ID="LabelQuantity" runat="server" CssClass="" Text='<%# Eval("Quantity") %>' /></td>
            <td width="320px"></td>
            <td></td>
            </tr>
            <!--Row 2-->
            <tr>
            <td><asp:Label ID="LabelName" runat="server" CssClass="" Text='<%# Eval("Name") %>' /></td>
            <td><asp:Label ID="LabelMSRP" runat="server" CssClass="" Text='<%# "$" + Eval("Msrp") + " each"%>' /></td>
            <td>Delivery Type: <asp:DropDownList ID="DropDownListDeliveryType" DataSource='<%# Eval("DeliveryTypes") %>' DataTextField="Name" DataValueField="DeliveryTypeID" runat="server" /></td>
            <td><asp:CheckBox ID="CheckBoxUseUserAddress" runat="server" Text="Send to User's Address" OnCheckedChanged="Check_Changed" AutoPostBack="true" Checked="true" /></td>
            </tr>
        </table>
        <br />
        <div id="SpecifiedDeliveryInfoDiv" rowID='<%# Eval("Prodcd") %>' runat="server" style="padding-left:15px; margin-bottom:15px;" visible="false">
            <p style="color:Red">Required Fields (*)</p>
            <table>
            <tr>
                <td>*First Name:</td>
                <td style="padding-right:20px;"><asp:TextBox ID="txtFName" runat="server" Width="200px" AutoCompleteType="Search" /></td>
                <td>*Last Name:</td>
                <td><asp:TextBox ID="txtLName" runat="server" Width="200px" AutoCompleteType="Search" /></td>
            </tr>
            <tr>
                <td>*Address:</td>
                <td style="padding-right:20px;"><asp:TextBox ID="txtAddress" runat="server" Width="200px" AutoCompleteType="Search" /></td>
                <td>Address 2 (optional):</td>
                <td><asp:TextBox ID="txtAddress2" runat="server" Width="200px" AutoCompleteType="Search" /></td>
            </tr>
            <tr>
                <td>*City:</td>
                <td style="padding-right:20px;"><asp:TextBox ID="txtCity" runat="server" Width="200px" AutoCompleteType="Search" /></td>
                <td>*Country:</td>
                <td><asp:DropDownList ID="drop" runat="server" Width="204px">
                        <asp:ListItem>United States</asp:ListItem>
                        <asp:ListItem>Canada</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>*State/Province:</td>
                <td style="padding-right:20px;"><asp:DropDownList ID="dropStateProv" runat="server" Width="204px"/></td>
                <td>*Zip/Postal Code:</td>
                <td><asp:TextBox ID="txtZip" runat="server" Width="200px" AutoCompleteType="Search" /></td>
            </tr>
            <tr>
                <td>*Email:</td>
                <td style="padding-right:20px;"><asp:TextBox ID="txtEmail" runat="server" Width="200px" AutoCompleteType="Search" /></td>
                <td></td>
                <td></td>
            </tr>
            </table>
        </div>
     </ItemTemplate>
</asp:DataList>
</ContentTemplate>
</asp:UpdatePanel>
<div style="float:right; padding-top:10px;">
    <asp:Button ID="ButtonGoToPayInfo" runat="server" CssClass="fancy_button" 
        Text="Continue to Payment Information..." onclick="ButtonGoToPayInfo_Click" />
</div>
</asp:Content>
