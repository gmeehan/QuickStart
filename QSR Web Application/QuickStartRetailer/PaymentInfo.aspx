<%@ Page Title="Payment Info" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="PaymentInfo.aspx.cs" Inherits="QuickStartRetailer._PaymentInfo" ValidateRequest="false" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2 style="font-weight:bold; text-align:center">Payment Information</h2>
<asp:GridView ID="GridViewPaymentInfoItems" AutoGenerateColumns="false" 
        ShowFooter="true" CssClass="cartItemsList" runat="server" Width="100%" 
        onrowdatabound="GridViewPaymentInfoItems_RowDataBound">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <div id="Div1" runat="server" >
                        <asp:HyperLink ID="ProductImageLink" Target="_blank" NavigateUrl='<%# "~/ProductInfo.aspx?prodcd=" + Eval("Prodcd") %>' runat="server">
                            <asp:Image ID="Image1" CssClass="paymentInfoListItemImage" ImageUrl='<%# "~/Images/Product_Images/" + Eval("Prodcd") + ".jpg" %>' runat="server" />
                        </asp:HyperLink>
                        <br />
                        <asp:Label ID="LabelName" Font-Bold="true" runat="server" Text='<%# Eval("Name") %>' />
                    </div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="MSRP" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:C}" DataField="Msrp" />
        <asp:BoundField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" DataField="Quantity" />
        <asp:BoundField HeaderText="DeliveryType" ItemStyle-HorizontalAlign="Center" DataField="DeliveryTypeName" />
        <asp:BoundField HeaderText="Delivery" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:C}" DataField="DeliveryCost" />
        <asp:BoundField HeaderText="Taxes" ItemStyle-HorizontalAlign="Right" HtmlEncode="False" DataFormatString="{0:C}" DataField="Taxes" />
        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="LabelTotal" runat="server" Text='<%# Eval("Total", "{0:c}") %>' />
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label ID="LabelTotalSum" Font-Bold="true" runat="server" />
            </FooterTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<h2 style="font-weight:bold; text-align:center">Payment Type</h2>

<div class="paymentOuterDiv">
    <asp:RadioButtonList TextAlign="Right" Font-Bold="true" RepeatColumns="1" Width="100%" ID="RadioButtonListPaymentTypes" 
        CellPadding="10" AutoPostBack="true" runat="server">
        <asp:ListItem>
            <img src="https://www.paypal.com/en_US/i/logo/PayPal_mark_37x23.gif">
        </asp:ListItem>
        <asp:ListItem>
            <a href="http://www.credit-card-logos.com"><img alt="" title="" src="http://www.credit-card-logos.com/images/visa_mastercard_amex_credit-card-logos/mc_vs_ax_accpt_h_023_gif.gif" border="0" /></a>
        </asp:ListItem>
        <asp:ListItem Text="Cash"/>
        <asp:ListItem Text="Cheque"/>
    </asp:RadioButtonList>

    <%--<form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" target="paypal">
        <input type="hidden" name="cmd" value="_cart">
        <input type="hidden" name="upload" value="1">
        <input type="hidden" name="business" value="g_meeh_1355857599_biz@fanshaweonline.ca">
        <input type="hidden" name="currency_code" value="CAD">
 
        <!--First Item-->
        <p>
        <input type="hidden" name="item_name_1" value="Cross Trainer Software CD">
        <input type="hidden" name="item_number_1" value="CROSSTRAINCD">
        <input type="hidden" name="amount_1" value="120.00">
        Lexia Cross Trainer Software CD
         <select name="quantity_1" value="">
            <option value="0">0</option>
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
            <option value="6">6</option>
            <option value="7">7</option>
            <option value="8">8</option>
            <option value="9">9</option>
            <option value="10">10</option>
          </select>
        </p>

        <!--Second Item--> 
        <p>
        <input type="hidden" name="item_name_2" value="Literacy and Maths Online Monthly Subscription">
        <input type="hidden" name="item_name_2" value="LITONLINE1">
        <input type="hidden" name="amount_2" value="120.00">
        Literacy and Maths Online Monthly Subscription
         <select name="quantity_2" value="">
            <option value="0">0</option>
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
            <option value="6">6</option>
            <option value="7">7</option>
            <option value="8">8</option>
            <option value="9">9</option>
            <option value="10">10</option>
          </select>
        </p>

        <!--Third Item-->
        <p>
        <input type="hidden" name="item_name_3" value="Family Discount Offer Monthly Subscription">
        <input type="hidden" name="item_number_3" value="FDISCOUNT">
        <input type="hidden" name="amount_3" value="120.00">
        Family Discount Offer - Monthly Subscription
         <select name="quantity_3" value="">
            <option value="0">0</option>
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
            <option value="6">6</option>
            <option value="7">7</option>
            <option value="8">8</option>
            <option value="9">9</option>
            <option value="10">10</option>
          </select>
        </p>

        <!--Fourth Item-->
        <p>
        <input type="hidden" name="item_name_4" value="Family Discount Offer Monthly Subscription - Additional Users">
        <input type="hidden" name="item_number_4" value="FDISCOUNTUSERS">
        <input type="hidden" name="amount_4" value="40.00">
        Family Discount Offer - Additional Users
         <select name="quantity_4" value="">
            <option value="0">0</option>
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
            <option value="6">6</option>
            <option value="7">7</option>
            <option value="8">8</option>
            <option value="9">9</option>
            <option value="10">10</option>
          </select>
        </p>
 
        <input type="hidden" name="return" value="http://www.literacyandmaths.com.au/thankyou.html">

        <input type="image" src="http://images.paypal.com/en_US/i/btn/x-click-but22.gif" border="0" name="submit" 
            width="87" height="23" alt="Make payments with PayPal - it's fast, free and secure!">
    </form>--%>

    <%--<form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post">
        <input type="hidden" name="cmd" value="_xclick">
        <input type="hidden" name="business" value="g_meeh_1355857599_biz@fanshaweonline.ca" />
        <input type="hidden" name="item_name" value="My painting" />
        <input type="hidden" name="amount" value="10.00" />
        <input type="submit" name="submit" value="Buy!" />
    </form>--%>

    <form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" target="paypal">
        <input type="hidden" name="cmd" value="_cart">

        <input type="hidden" name="display" value="1">
        <input type="hidden" name="business" value="g_meeh_1355857599_biz@fanshaweonline.ca" />

        <input type="hidden" name="shopping_url" value="http://www.yourwebsite.com/shoppingpage.html">
        <input type="image" src="https://www.paypal.com/en_US/i/btn/view_cart_02.gif" name="submit" alt="Make payments with PayPal - it's fast, free and secure!">
    </form>
</div>

<div style="float:left;">
    <asp:Button ID="ButtonReturnToCheckout" runat="server" CssClass="fancy_button" 
        Text="Return to Checkout" onclick="ButtonReturnToCheckout_Click" />
</div>
<div style="float:right;">
    <asp:Button ID="ButtonContinueToConfirmation" runat="server" 
        CssClass="fancy_button" Text="Continue to Confirmation" 
        onclick="ButtonContinueToConfirmation_Click" />
</div>
</asp:Content>
