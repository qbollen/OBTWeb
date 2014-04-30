<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="ArticleShow.aspx.cs" Inherits="ORBITA.UI.ArticleShow" %>

<%@ Register Src="~/Controls/ArticleClassLeft.ascx" TagPrefix="uc1" TagName="ArticleClassLeft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="Css/Web.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ArticleClassLeft runat="server" ID="ArticleClassLeft" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="articleinfo">

        <h1><a href="ArticleList.aspx">All Categories</a> <%=acnav%> </h1>

        <div class="info">

            <h6 class="largetitle">
                <asp:Literal ID="litTitle" runat="server"></asp:Literal>
            </h6>

            <div class="smalltitle">
                Source: <asp:Label ID="lblSource" runat="server"></asp:Label>
                &nbsp;&nbsp;
                Author:<asp:Label ID="lblAuthor" runat="server"></asp:Label>
                &nbsp;&nbsp;
                Date:<asp:Label ID="lblDate" runat="server"></asp:Label>
                &nbsp;&nbsp;
                Browse:<asp:Label ID="lblBrowse" runat="server"></asp:Label>
            </div>
            <div class="artcontent">
                <asp:Label ID="lblContent" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
