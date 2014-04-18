<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="service.aspx.cs" Inherits="ORBITA.UI.service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="css/web.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="side_box">
        <h2>Banner</h2>
        <div class="side_con">
            <ul>
                <li><a href="service.aspx">Support</a></li>
                <li><a href="download.aspx">Download</a></li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="myservice">
        <div class="top">
            <img src="images/service.gif" alt="ORBITA Service" />
        </div>
        <div class="bottom">
            <div class="left">
                <h1>Service</h1>
                <ul>
                    <li>MSN: &nbsp;orbitaservice@msn.cn</li>
                    <li>Skype: &nbsp;orbitacustomerservice</li>
                    <li>Yahoo: &nbsp;orbitaservice</li>
                    <li>Email: &nbsp;service@orbitatech.com</li>
                    <li>Tel: &nbsp;+86-18928480199 &nbsp;+86-755-83369158-625</li>
                </ul>
            </div>

        </div>

    </div>
</asp:Content>


