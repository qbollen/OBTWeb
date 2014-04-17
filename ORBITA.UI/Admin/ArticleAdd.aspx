<%@ Page Title="添加文章" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ArticleAdd.aspx.cs" Inherits="ORBITA.UI.Admin.ArticleAdd" %>

<%@ Register Src="~/Controls/ArticleClassDDL.ascx" TagPrefix="uc1" TagName="ArticleClassDDL" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var oEditer;
        function FCKeditorValidate(source, argments)
        {
            var value = oEditer.GetXHTML(true);
            if (value == "")
            {
                arguments.IsValid = false;
            }
            else
            {
                argments.IsValid = true;
            }
        }
        function FCKeditor_OnComplete(editorInstance)
        {
            oEditer = editorInstance;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="box">
        <h3>添加文章</h3>

        <table>
            <tr>
                <td colspan="3" class="noborder">
                    <asp:Label ID="lblError" runat="server" Text="添加失败" ForeColor="Red" Visible="false"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="LabelStyle" />
                    <asp:Label ID="lblErrContent" runat="server" Text="文章内容不能为空" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="15%"> 文章分类:</td>
                <td width="30%">
                    <uc1:ArticleClassDDL runat="server" id="ArticleClassDDL1" />
                </td>
                <td>注：请选择所属分类， 一级分类请选择“无”</td>
            </tr>
            <tr>
                <td>文章标题:</td>
                <td colspan="2">
                    <asp:TextBox ID="tbxTitle" runat="server" TabIndex="2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="文章标题不能为空." ControlToValidate="tbxTitle"
                         Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td>文章作者:</td>
                <td colspan="2">
                    <asp:TextBox ID="tbxAuthor" runat="server" TabIndex="3"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td>文章来源:</td>
                <td colspan="2">
                    <asp:TextBox ID="tbxFrom" runat="server" TabIndex="4"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>文章图片:</td>
                <td>
                    <asp:TextBox ID="tbxImage" runat="server" TabIndex="5"></asp:TextBox>
                </td>
                <td>
                    注：请输入图片URL, 留空系统会使用您上传的第一张图片作为文章图片。
                </td>
            </tr>
            <tr>
                <td>文章推荐:</td>
                <td colspan="2">
                    <asp:CheckBox ID="cbxTop" runat="server" Text="置顶" TabIndex="6" />
                    <asp:CheckBox ID="cbxCommend" runat="server" Text="推荐" TabIndex="7" />
                    <asp:CustomValidator ID="CustomValidator1" 
                        runat="server" ErrorMessage="文章内容不能为空。"
                         ClientValidationFunction="FCKeditorValidate" ValidateEmptyText="true"
                        Display="None"></asp:CustomValidator>
                </td>
            </tr>

            <tr>
                <td>文章内容:</td>
                <td colspan="2">
                    <CKEditor:CKEditorControl ID="CKEditor1" runat="server" basePath="~/ckeditor/">
		            </CKEditor:CKEditorControl>
                </td>
            </tr>

                                 <tr>
                     <td >文章描述：</td>
                         <td colspan="2" >
                             <textarea ID="txtDescription" runat="server" name="S1" rows="6" cols="40" 
                                 tabindex="9"></textarea></td>
                     </tr>
                    

                     <tr>
                         <td class="noborder">
                             &nbsp;</td>
                         <td class="noborder" colspan="2">
                             <asp:Button ID="btnAdd" runat="server" Text=" 添 加 " onclick="btnAdd_Click" 
                                 TabIndex="10" />
                         </td>
                     </tr>
        </table>
    </div>
</asp:Content>
