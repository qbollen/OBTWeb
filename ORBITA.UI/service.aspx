<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="service.aspx.cs" Inherits="ORBITA.UI.service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="css/web.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Banner</h1>
    <ul>
        <li>Service</li>
    </ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="myservice">
        <ul>
            <li>
                <img src="images/service.gif" alt="ORBITA Service"/>
            </li>
            <li>
                <h1>Service</h1>
                <ul>
                    <li>MSN: &nbsp;orbitaservice@msn.cn</li>
                    <li>Skype: &nbsp;orbitacustomerservice</li>
                    <li>Yahoo: &nbsp;orbitaservice</li>
                    <li>Email: &nbsp;service@orbitatech.com</li>
                    <li>Tel: &nbsp;+86-18928480199 &nbsp;+86-755-83369158-625</li>
                </ul>
            </li>
        </ul>
    </div>
</asp:Content>


