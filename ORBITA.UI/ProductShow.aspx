<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true"
    CodeBehind="ProductShow.aspx.cs" Inherits="ORBITA.UI.ProductShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ProductInnerContent">
        <span class="artTitle2"><a href="ProductList.aspx">All Categories</a>
            <%=pcnav%>
        </span>
        <div class="ProductInfo">
            <table>
                <tr>
                    <td class="noborder artTitle">
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="noborder artTitle2" align="center">
                        Date:
                        <asp:Label ID="lblDate" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Browse:
                        <asp:Label ID="lblClick" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="noborder artTitle2">
                        Model:
                        <asp:Label ID="lblNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="noborder artTitle2">
                        Price:
                        <asp:Label ID="lblPrice" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="noborder">
                        <asp:Label ID="lblContent" runat="server" CssClass="artContent"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
