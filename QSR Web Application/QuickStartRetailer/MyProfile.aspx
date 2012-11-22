<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="MyProfile.aspx.cs" Inherits="QuickStartRetailer._MyProfile" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="accountBlock">
        <div class="accLabel"><p>Username:</p><asp:TextBox ID="txtUName" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p>Password:</p><asp:TextBox ID="txtPass" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p>Confirm Password:</p><asp:TextBox ID="txtPass2" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p>Salutation:</p><asp:TextBox ID="txtSal" runat="server" 
                Width="76px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p>First Name:</p><asp:TextBox ID="txtFName" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p>Last Name:</p><asp:TextBox ID="txtLName" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p>Address:</p><asp:TextBox ID="txtAddress" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p>Address 2 (optional):</p><asp:TextBox ID="txtAddress2" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p>Country:</p><asp:DropDownList ID="drop" runat="server" 
                onselectedindexchanged="drop_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>United States</asp:ListItem>
            <asp:ListItem>Canada</asp:ListItem>
        </asp:DropDownList></div>
        <div class="accLabel"><p>City:</p><asp:TextBox ID="txtCity" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p>State/Province:</p><asp:DropDownList ID="dropStateProv" 
                runat="server" onselectedindexchanged="dropStateProv_SelectedIndexChanged"/></div>
        <div class="accLabel"><p>Zip/Postal Code:</p><asp:TextBox ID="txtZip" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p>Email:</p><asp:TextBox ID="txtEmail" runat="server" Width="250px" AutoCompleteType="Search" /></div>
        <div class="accLabel"><p class="ckBox"><asp:CheckBox ID="ckBox" Text="Sign me up to recieve monthly newsletters!" TextAlign="Right" AutoPostBack="true" runat="server" /></p></div>

        <div class="userRegButtonDiv">
            <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="fancy_button" Width="100px" onclick="ButtonSave_Click" />
        </div>

        <div class="reportLabel">
            <asp:Label ID="LabelOutput" Width="200px" runat="server" Text="" />
        </div>
    </div>
</asp:Content>
