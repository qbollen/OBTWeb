<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="ORBITA.UI.Admin.UserAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="box">
            <h3>用户添加</h3>
            
            
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
 
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                
                 <table >
                     <tr>
                         <td colspan="2" class="noborder">
                             <asp:Label ID="lblError" runat="server" Text="·添加失败。" ForeColor="Red" 
                                 Visible="False"></asp:Label> &nbsp;&nbsp;&nbsp;
                             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                 CssClass="LabelStyle" />
                         </td>
                     </tr>
                     <tr>
                          <td width="12%" class="noborder">
                             用户名：</td>
                         <td class="noborder">
                             <asp:TextBox ID="tbxUsername" runat="server" TabIndex="1" Width="180px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                 ErrorMessage="·用户名不能为空。" ControlToValidate="tbxUsername" Display="None"></asp:RequiredFieldValidator>
                             <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                 ControlToCompare="tbxPassword" ControlToValidate="tbxCfmPasss" 
                                 ErrorMessage="·两次输入的密码不相同，请重新输入。" Display="None"></asp:CompareValidator>
                         </td>
                     </tr>
                     <tr>
                         <td class="noborder">
                             密码：</td>
                         <td class="noborder">
                             <asp:TextBox ID="tbxPassword" runat="server" TabIndex="2" TextMode="Password" 
                                 Width="180px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                 ErrorMessage="·密码不能为空。" ControlToValidate="tbxPassword" Display="None"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                 ErrorMessage="·密码不能包含空白字符或长度不得低得6个字符。" ControlToValidate="tbxPassword" 
                                 Display="None" ValidationExpression="^\S{6,50}$"></asp:RegularExpressionValidator>
                         </td>
                     </tr>
                     <tr>
                         <td class="noborder">
                             确认密码：</td>
                         <td class="noborder">
                             <asp:TextBox ID="tbxCfmPasss" runat="server" TabIndex="3" TextMode="Password" 
                                 Width="180px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                 ErrorMessage="·确认密码不能为空。" ControlToValidate="tbxCfmPasss" Display="None"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                 ErrorMessage="·确认密码不能包含空白字符或长度不得低得6个字符。" ControlToValidate="tbxCfmPasss" 
                                 Display="None" ValidationExpression="^\S{6,50}$"></asp:RegularExpressionValidator>
                         </td>
                     </tr>
                     <tr>
                         <td class="noborder">
                             &nbsp;</td>
                         <td class="noborder">
                             <asp:Button ID="btnAdd" runat="server" Text=" 添 加 " 
                                 TabIndex="4" onclick="btnAdd_Click" />
                         </td>
                     </tr>

                 </table>
                
             </ContentTemplate>
            </asp:UpdatePanel>
            

       
       </div>
</asp:Content>
