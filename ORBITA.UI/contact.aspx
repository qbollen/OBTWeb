<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="ORBITA.UI.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="css/web.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="mynav" type="hidden" value="Service" />
    <div class="side_box">
        <%--<h2>Banner</h2>--%>
        <div class="side_con">
            <ul>
                <li><a href="contact.aspx">Contact US</a></li>
                <li><a href="service.aspx">Support</a></li>
                <li><a href="download.aspx">Download</a></li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="mycontact">
        <ul>
            <li>
                <h1><span>ORBITA (China)</span></h1>
                <ul>
                    <li>Address: &nbsp;5th floor,bldg b8,xiufeng industrial zone,buji, longgang dist,shenzhen,china</li>
                    <li>Sales manager: &nbsp;joshua liu</li>
                    <li>Tel: &nbsp;0086-755-83369158-606</li>
                    <li>Fax: &nbsp;0086-755-83617778</li>
                    <li>Mobile:	&nbsp;0086-13725547421</li>
                    <li>Email: &nbsp;joshua@orbitatech.com</li>
                    <li>Msn: &nbsp;joshua3385@orbitatech.com</li>
                    <li>Skype: &nbsp;joshua3385</li>
                    <li>Gmail: &nbsp;orbitalock.joshua@gmail.com</li>
                    <li>Alibaba: &nbsp;cgs_joshua</li>
                </ul>
            </li>
            <li>
                <h1><span>Hotel Supply (Thailand) ltd.</span></h1>
                <ul>
                    <li>Address: &nbsp;1000/25 pb tower 8th floor, sukhumvit 71,north klongtan, wattana, bangkok 10110</li>
                    <li>Contact: &nbsp;mr.watson thanakul</li>
                    <li>Tel: &nbsp;027133878</li>
                    <li>Fax: &nbsp;027133879</li>
                    <li>Mobile: &nbsp;0819008228</li>
                    <li>Email: &nbsp;sales@orbitathai.com</li>
                    <li>Msn: &nbsp;watson168@live.com</li>
                    <li>Skype: &nbsp;watson.ken</li>
                </ul>
            </li>
        </ul>
    </div>
</asp:Content>


