<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="ArticleShow.aspx.cs" Inherits="ORBITA.UI.ArticleShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="innerContent">
        <span class="titleContent">
            <a href="ProductList.aspx">所有分类</a> <%=acnav%>        
        </span>
        <div class="info">

            <table>
                <tr>
                    <td colspan="4" class="noborder artTitle">
                        <asp:label id="lblTitle" runat="server"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="noborder" width="25%">日期:
                        <asp:label id="lblDate" runat="server"></asp:label>
                    </td>
                    <td class="noborder">作者:
                        <asp:label id="lblAuthor" runat="server"></asp:label>
                    </td>
                    <td class="noborder">来源:
                        <asp:label id="lblFrom" runat="server"></asp:label>
                    </td>
                    <td class="noborder">浏览:
                        <asp:label id="lblClick" runat="server"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="noborder">
                        <asp:label id="lblContent" runat="server" cssclass="artContent"></asp:label>

                    </td>
                </tr>

            </table>
        </div>
    </div>
</asp:Content>
