<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true"
    CodeBehind="ProductShow.aspx.cs" Inherits="ORBITA.UI.ProductShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/web.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="side_box">
        <h2>Product Category</h2>
        <asp:ObjectDataSource ID="ObjectDataSourceProductClass" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetTree"
            TypeName="ORBITA.BLL.ProductClassManage"></asp:ObjectDataSource>
        <div class="side_con">
            <asp:ListView runat="server" ID="ListViewProductClass"
                DataSourceID="ObjectDataSourceProductClass">
                <LayoutTemplate>
                    <ul runat="server">
                        <li id="itemPlaceHolder" runat="server"></li>
                    </ul>
                </LayoutTemplate>

                <ItemTemplate>
                    <li runat="server">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "ProductList.aspx?id=" + Eval("pc_id") %>'
                            Text='<%# Eval("pc_name") %>'></asp:HyperLink>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="ProductInfo">
        <h1><a href="ProductList.aspx">All Categories</a><%=pcnav%></h1>
        <div class="title">
            <div class="prod_image">
                <asp:Image ID="imgProd" runat="server" CssClass="p_image" />
            </div>
            <div class="prod_info">
                <ul>
                    <li class="tl"><asp:Label ID="lblTitle" runat="server"></asp:Label></li>
                    <li>Model: &nbsp;<asp:Label ID="lblNumber" runat="server"></asp:Label></li>
                    <li>Issue Date: &nbsp;<asp:Label ID="lblDate" runat="server"></asp:Label></li>
                    <li>Browse: &nbsp;<asp:Label ID="lblClick" runat="server"></asp:Label></li>
                </ul>
            </div>
            <br class="clear" />          
        </div>
        <div class="clear"></div>
        <h1><strong>Features</strong></h1>
        <div class="content">          
            <asp:Label ID="lblContent" runat="server" CssClass="artContent"></asp:Label>
        </div>
    </div>
</asp:Content>
