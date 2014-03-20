<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ProductClassMgmt.aspx.cs" Inherits="ORBITA.UI.Admin.ProductClassMgmt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="box">
            <h3>产品分类管理</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                    <asp:Label ID="lblErrDelete" runat="server" Text="·不能删除拥有子类的产品分类。" ForeColor="Red" 
                    Visible="False"></asp:Label>

                <asp:Repeater ID="RepeaterTree" runat="server" 
                    DataSourceID="TreeObjectDataSource" 
                    onitemdatabound="RepeaterTree_ItemDataBound" 
                    onitemcommand="RepeaterTree_ItemCommand" >
                    <HeaderTemplate>
                     <table><thead><th>产品分类</th><th>操作</th></thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <tr onmouseover="this.style.backgroundColor='#f3f9ff'" onmouseout="this.style.backgroundColor='#fff'">
                        <td><asp:Label ID="lblBlank" runat="server" Text=""></asp:Label>
                            <asp:Image ID="imgBlue" runat="server" ImageUrl="~/Images/bullet_arrow_right.png" />
                            <%#Eval("pc_name") %>  </td><td width="30%"> 
                        <asp:LinkButton ID="lbtEdit" runat="server" Text="编辑" CommandName="Edit" CommandArgument='<%#Eval("pc_id") %> ' ></asp:LinkButton>
                        <asp:LinkButton ID="lbtDelete" runat="server"  Text="删除" CommandName="Delete" CommandArgument='<%#Eval("pc_id") %> '></asp:LinkButton>
                          </td>
                    </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>   
                    </FooterTemplate>
                </asp:Repeater>
 <br />
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                <h3>编辑分类名称</h3>

                <table>
                <tr>
                    <td colspan="2" class="noborder">     
                        
                    <asp:Label ID="lblError" runat="server" Text="·产品分类名称不能为空。" ForeColor="Red" 
                            Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="noborder" width="15%"> 分类名称：</td>
                    <td class="noborder" > <asp:TextBox ID="tbxacname" runat="server" TabIndex="3" 
                            Width="180px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="noborder"> </td>
                    <td class="noborder"><asp:Button ID="btnConfirm" runat="server" Text=" 确 认 "  
                            TabIndex="4" onclick="btnConfirm_Click" /> </td>
                </tr>
                
                </asp:Panel>

                <asp:ObjectDataSource ID="TreeObjectDataSource" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetTree" 
                    TypeName="ORBITA.BLL.ProductClassManage">
                </asp:ObjectDataSource>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
