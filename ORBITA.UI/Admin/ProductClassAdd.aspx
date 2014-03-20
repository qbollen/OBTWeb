<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ProductClassAdd.aspx.cs" Inherits="ORBITA.UI.Admin.ProductClassAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="box">
    <h3>产品分类添加</h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <td colspan="3" class="noborder">
                    <asp:Label ID="lblError" runat="server" Text=".添加失败。" ForeColor="Red"
                         Visible = "False"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                        CssClass="LabelStyle" />
                
                </td>
            </tr>

            <tr>
                <td style="width:15%;" class="noborder">
                    产品分类：
                </td>
                <td style="width:30%;" class="noborder">
                    <asp:DropDownList ID="DropDownListTree" runat="server" Width="200px" TabIndex="1"></asp:DropDownList>
                </td>

                <td class="noborder">
                    注:请选择所属分类，一级分类请选择“无”。 只支持二级分类。</td>
             </tr>
                <tr>
                    <td class="noborder">
                        产品分类名称：
                    </td>

                    <td class="noborder" colspan="2">
                        <asp:TextBox ID="txtAcname" runat="server" TabIndex="2" Width="199px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage=".产品分类名称不能为空。" ControlToValidate="txtAcname" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="noborder">&nbsp;</td>
                    <td class="noborder" colspan="2">
                        <asp:Button ID="btnAdd" runat="server" Text=" 添 加 " TabIndex="3" 
                            onclick="btnAdd_Click" />
                    </td>
                </tr>
           
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>

</div>
</asp:Content>
