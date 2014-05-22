<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true"
    CodeBehind="ProductShow.aspx.cs" Inherits="ORBITA.UI.ProductShow" %>

<%@ Register Src="~/Controls/ProductClassLeft.ascx" TagPrefix="uc1" TagName="ProductClassLeft" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/web.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ProductClassLeft runat="server" ID="ProductClassLeft" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="ProductInfo">
        <h1><span>Product<%=pcnav%></span></h1>
        <div class="title">
            <div class="prod_image">
                <asp:Image ID="imgProd" runat="server" CssClass="p_image" />
            </div>
            <div class="prod_info">
                <ul>
                    <li class="tl"><asp:Label ID="lblTitle" runat="server"></asp:Label></li>
                    <li>Model: &nbsp;<asp:Label ID="lblNumber" runat="server"></asp:Label></li>                 
                    <li>Browse: &nbsp;<asp:Label ID="lblClick" runat="server"></asp:Label></li>
                </ul>
            </div>
            <br class="clear" />          
        </div>
        <div class="clear"></div>
        <h1><span><strong>Features</strong></span></h1>
        <div class="content">          
            <asp:Label ID="lblContent" runat="server" CssClass="artContent"></asp:Label>
        </div>
    </div>
</asp:Content>
