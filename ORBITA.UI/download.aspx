<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="download.aspx.cs" Inherits="ORBITA.UI.download" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="css/web.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="mynav" type="hidden" value="Service" />
    <div class="side_box">
   <%-- <h2>Banner</h2>--%>
        <div class="side_con">
            <ul>
                <li><a href="contact.aspx">Contact us</a></li>
                <li><a href="service.aspx">Support</a></li>
                <li><a href="download.aspx">Download</a></li>
            </ul>
        </div>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="mydownload">
        <h1><span>Download</span></h1>
        <ul>
            <li>【Software】&nbsp; <a href="down/LockingSystem5.0.rar">Locking System 5.0 (c mifare usb port)</a></li>
            <li>【Software】&nbsp; <a href="down/ic%20card%20lock%203.1.rar">IC card locking system v3.1 (usb port)</a></li>
            <li>【Software】&nbsp; <a href="down/orbita_rf_locking_3.4.2.rar">RF card locking system v3.4.2 (usb port)</a></li>
            <li>【Software】&nbsp; <a href="down/mifare.card.lock.3.1.rar">Mifare card locking system v3.1 (usb port)</a></li>
            <li>【Software】&nbsp; <a href="down/mifare.card.lock.3.1.russian.rar">Mifare card locking system(russian edition) v3.1 (usb port)</a></li>
            <li>【Software】&nbsp; <a href="down/orbita%20magnetic%20card%20locking.rar">Magnetic card locking system v3.1 (com port)</a></li>
            <li>【Software】&nbsp; <a href="down/orbita%20office%20lock.rar">Office lock system</a></li>
            <li>【Manual】&nbsp; <a href="down/profile.pps">Product file</a></li>
            <li>【Other】&nbsp; <a href="down/onecard.pps">One card system</a></li>
            <li>【Video】&nbsp; <a href="down/locking%20system%20video%20manual%20.rar">Locking system video manual</a></li>
            <li>【Manual】&nbsp; <a href="down/doorlock%20user%20handbook.pdf">Doorlock user's handbook</a></li>
            <li>【Other】&nbsp; <a href="product/images/ic%20assembly.jpg">IC locking assembly</a></li>
            <li>【Video】&nbsp; <a href="down/how%20to%20program%20a%20lock.rar">How to program a lock</a></li>
            <li>【Other】&nbsp; <a href="down/orbita%20products%20range.rar">Orbita products range</a></li>
        </ul>
    </div>
</asp:Content>
