<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="UserChng.aspx.cs" Inherits="ORBITA.UI.Admin.UserChng" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="box">
            <h3>密码修改</h3>
            
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                  <table>
                <tr>
                    <td colspan="2" class="noborder">     
                        
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            CssClass="LabelStyle" />
                            <asp:Label ID="lblError" runat="server" Text="·错误, 请返回重试。" ForeColor="Red" 
                            Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="noborder">
                        <span class="txtblue">用户名： <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
                        
                        </span>
                    
                        </td>
                </tr>
                <tr>
                    <td width="15%" class="noborder">
                        原始密码： </td>
                    <td class="noborder">
                        <asp:TextBox ID="tbxOldPass" runat="server" Enabled="False" TabIndex="1" 
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="tbxOldPass" ErrorMessage="·原始密码不能为空。" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ErrorMessage="·原始密码不能包含空白字符或长度不得低得6个字符。" ControlToValidate="tbxOldPass" 
                            Display="None" ValidationExpression="^\S{6,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="noborder">
                        新 密 码：</td>
                    <td class="noborder">
                        <asp:TextBox ID="tbxNewPass" runat="server" Enabled="False" TabIndex="2" 
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="·新密码不能为空。" ControlToValidate="tbxNewPass" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ErrorMessage="·新密码不能包含空白字符或长度不得低得6个字符。" ControlToValidate="tbxNewPass" 
                            Display="None" ValidationExpression="^\S{6,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                                 <tr>
                                     <td class="noborder"> 
                                         确认新密码：</td>
                                     <td class="noborder">
                                         <asp:TextBox ID="tbxCfmPass" runat="server" Enabled="False" TabIndex="3" 
                                             TextMode="Password"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                             ErrorMessage="·确认密码不能为空。" ControlToValidate="tbxCfmPass" Display="None"></asp:RequiredFieldValidator>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                             ErrorMessage="·确认密码不能包含空白字符或长度不得低得6个字符。" ControlToValidate="tbxCfmPass" 
                                             Display="None" ValidationExpression="^\S{6,50}$"></asp:RegularExpressionValidator>
                                         <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                             ErrorMessage="·两次输入的密码不相同，请重新输入。" ControlToCompare="tbxNewPass" 
                                             ControlToValidate="tbxCfmPass" Display="None"></asp:CompareValidator>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td class="noborder">
                                         &nbsp;</td>
                                     <td class="noborder">
                                         <asp:Button ID="btnConfirm" runat="server" Text=" 修 改 " Enabled="False" 
                                             TabIndex="4" onclick="btnConfirm_Click" />&nbsp;
                                         <asp:Button ID="btnBack" runat="server" Text=" 返 回 " 
                                             onclientclick="javascript:window.history.go(-1);" TabIndex="5" />
                                     </td>
                                 </tr>
            </table>    
            </ContentTemplate>
            </asp:UpdatePanel>
    </div>
</asp:Content>
