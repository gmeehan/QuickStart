<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Registration.aspx.cs" Inherits="QuickStartRetailer._Registration" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="registerBlock">
        <p style="color:Red">Required Fields (*)</p>
        <div class="regLabel"><p>*Username:</p><asp:TextBox ID="txtUName" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p>*Password:</p><asp:TextBox ID="txtPass" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p>*Confirm Password:</p><asp:TextBox ID="txtPass2" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p>*Salutation:</p><asp:TextBox ID="txtSal" runat="server" 
                Width="76px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p>*First Name:</p><asp:TextBox ID="txtFName" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p>*Last Name:</p><asp:TextBox ID="txtLName" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p>*Address:</p><asp:TextBox ID="txtAddress" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p>Address 2 (optional):</p><asp:TextBox ID="txtAddress2" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p>*Country:</p><asp:DropDownList ID="drop" runat="server" 
                onselectedindexchanged="drop_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>United States</asp:ListItem>
            <asp:ListItem>Canada</asp:ListItem>
        </asp:DropDownList></div>
        <div class="regLabel"><p>*City:</p><asp:TextBox ID="txtCity" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p>*State/Province:</p><asp:DropDownList ID="dropStateProv" 
                runat="server" onselectedindexchanged="dropStateProv_SelectedIndexChanged"/></div>
        <div class="regLabel"><p>*Zip/Postal Code:</p><asp:TextBox ID="txtZip" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p>*Email:</p><asp:TextBox ID="txtEmail" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="regLabel"><p class="ckBox"><asp:CheckBox ID="ckBox" Text="Sign me up to recieve monthly newsletters!" TextAlign="Right" AutoPostBack="true" runat="server" /></p></div>

        <div class="userRegButtonDiv">
            <asp:Button ID="ButtonReg" runat="server" Text="Register" CssClass="fancy_button" Width="100px" onclick="ButtonReg_Click" />
        </div>

        <div class="reportLabel">
            <asp:Label ID="LabelOutput" Width="200px" runat="server" Text="" />
        </div>
    </div>
</asp:Content>
