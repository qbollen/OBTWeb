<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ArticleClassAdd.aspx.cs" Inherits="ORBITA.UI.Admin.ArticleClassAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="box">
        <h3>新闻分类添加</h3>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td colspan="3" class="noborder">
                            <asp:Label ID="lblError" runat="server" Text="添加失败." ForeColor="Red"
                                 Visible="false"></asp:Label>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                 CssClass="LabelStyle" />
                        </td>
                    </tr>
                    <tr>
                        <td width="15%" class="noborder">新闻分类：</td>
                        <td width="30%" class="noborder">
                            <asp:DropDownList ID="DropDownListTree" runat="server" Width="200px"
                                 TabIndex="1"></asp:DropDownList>
                        </td>
                        <td class="noborder">注:请选择所属分类, 一级分类请选择"无".</td>
                    </tr>
                    <tr>
                        <td class="noborder">
                            新闻分类名称：
                        </td>
                        <td class="noborder" colspan="2">
                            <asp:TextBox ID="tbxAcname" runat="server" TabIndex="2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                 ErrorMessage="新闻分类名称不能为空." ControlToValidate="tbxAcname"
                                 Display="None"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="noborder"></td>
                        <td class="noborder" colspan="2">
                            <asp:Button ID="btnAdd" runat="server" Text=" 添 加 " OnClick="btnAdd_Click"
                                 TabIndex="3" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
