<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="UserMgmt.aspx.cs" Inherits="ORBITA.UI.Admin.UserMgmt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="box">
            <h3>用户管理
            </h3>
       <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager> 
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                          <asp:GridView ID="UserGridView" runat="server" AutoGenerateColumns="False" 
                        AllowPaging="True" DataKeyNames="uid" 
                        DataSourceID="UserObjectDataSource" PagerSettings-FirstPageText="首页">
                              <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
                                  PreviousPageText="上一页" />
                        <Columns>
                            <asp:BoundField DataField="uid" HeaderText="ID" InsertVisible="False" 
                                ReadOnly="True" SortExpression="uid" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="username" HeaderText="用户名" 
                                SortExpression="username" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="joindate" HeaderText="加入日期" 
                                SortExpression="joindate" DataFormatString="{0:G}" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="login_ip" HeaderText="最后登录IP" 
                                SortExpression="login_ip" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="login_date" HeaderText="最后登录日期" 
                                SortExpression="login_date" DataFormatString="{0:G}" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                 <asp:LinkButton ID="lbtDelete" Text="删除" runat="server" OnClientClick="return confirm('确认要删除这个管理员吗?');" CommandName="Delete"></asp:LinkButton>
                   <asp:LinkButton ID="lbtModify" Text="修改密码" runat="server" PostBackUrl='<%# "UserChng.aspx?id=" + Eval("uid")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
<%--                        <PagerTemplate>
                            
                        </PagerTemplate>
--%>                    </asp:GridView>  
                             
                    
                     </ContentTemplate>
           </asp:UpdatePanel>

                       

            <asp:ObjectDataSource ID="UserObjectDataSource" runat="server" 
                SelectMethod="GetList" TypeName="ORBITA.Bll.UserManage" 
                DeleteMethod="Delete" >
                <DeleteParameters>
                    <asp:Parameter Name="uid" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
            
    </div>
</asp:Content>
