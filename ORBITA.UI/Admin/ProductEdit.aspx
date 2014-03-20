<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="ORBITA.UI.Admin.ProductEdit" %>
<%@ Register src="~/Controls/ProductClassDDL.ascx" tagname="ProductClassDDL" tagprefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">

    function CKeditorValidate(source, arguments) {

    }
 
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="box">
            <h3>编辑产品</h3>
            
                 <table >
                     <tr>
                         <td colspan="3" class="noborder">
                             <asp:Label ID="lblError" runat="server" Text="·添加失败。" ForeColor="Red" 
                                 Visible="False"></asp:Label>
                             <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                 CssClass="LabelStyle" />
                         </td>
                     </tr>
                     <tr>
                         <td width="15%" >
                             产品分类：</td>
                         <td width="30%" >
                         
                             <uc1:ProductClassDDL ID="ProductClassDDL1" runat="server" />
                         
                         </td>
                         <td >
                             注：请选择所属分类，一级分类请选择“无”。</td>
                     </tr>
                     <tr>
                         <td >
                             产品名称：</td>
                         <td colspan="2">
                             <asp:TextBox ID="tbxName" runat="server" TabIndex="2"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                 ErrorMessage="·产品名称不能为空。"  ControlToValidate="tbxName" Display="None"></asp:RequiredFieldValidator>
                         </td>
                     </tr>
                     <tr>
                     <td >产品型号：</td>
                         <td colspan="2">
                             <asp:TextBox ID="tbxNumber" runat="server" TabIndex="3"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                     <td >产品价格：</td>
                         <td >
                             <asp:TextBox ID="tbxPrice" runat="server" TabIndex="4" Columns="10"></asp:TextBox>
                         </td>
                         <td >
                             <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="·请输入正确的产品价格。" 
                                 Operator="GreaterThanEqual" ValueToCompare="0" 
                                 ControlToValidate="tbxPrice" Display="None" Type="Currency"></asp:CompareValidator>
                             注：输入格式 99.99。
                         </td>
                     </tr>
                     <tr>
                     <td >产品图片：</td>
                         <td >
                             <asp:TextBox ID="tbxImage" runat="server" TabIndex="5"></asp:TextBox>
                         </td>
                         <td >
                             注：请输入图片URL，留空系统会使用您上传的第一张图片作为产品图片。
                         </td>
                     </tr>
                     <tr>
                     <td >产品推荐：</td>
                         <td colspan="2">
                             <asp:CheckBox ID="cbxTop" runat="server"  Text="置顶" TabIndex="6"/>&nbsp;&nbsp;
                             <asp:CheckBox ID="cbxCommend" runat="server" Text="推荐" TabIndex="7" />
                             <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                 ErrorMessage= "·产品内容不能为空。"   
                                 ClientValidationFunction ="CKeditorValidate"  ValidateEmptyText ="true" 
                                 Display="None"></asp:CustomValidator>
                         </td>
                     </tr>
                     <tr>
                     <td >产品内容：</td>
                         <td colspan="2">
                             <CKEditor:CKEditorControl ID="CKEditor1" runat="server" basePath="~/ckeditor/">
		</CKEditor:CKEditorControl>
                         </td>
                     </tr>

                     <tr>
                         <td class="noborder">
                             &nbsp;</td>
                         <td class="noborder" colspan="2">
                             <asp:Button ID="btnConfirm" runat="server" Text=" 确  认 " onclick="btnConfirm_Click" 
                                 TabIndex="8" />
                         </td>
                     </tr>

                 </table>
            
</div>           
</asp:Content>
