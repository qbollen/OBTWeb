<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ArticleMgmt.aspx.cs" Inherits="ORBITA.UI.Admin.ArticleMgmt" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="box">
        <h3>文章管理</h3>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td width="20%">文章分类:</td>
                        <td>
                            <asp:DropDownList ID="DropDownListTree" runat="server" Width="200px"
                             AppendDataBoundItems="true" AutoPostBack="true"
                             OnSelectedIndexChanged="DropDownListTree_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                </table>

                <asp:GridView ID="GridViewArticle" runat="server" AutoGenerateColumns="False" DataKeyNames="art_id" DataSourceID="ObjectDataSourceArticle" EnableModelValidation="True" OnRowDataBound="GridViewArticle_RowDataBound" OnRowDeleted="GridViewArticle_RowDeleted">
                    <Columns>
                        <asp:BoundField DataField="art_id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="art_id">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="分类">
                            <ItemTemplate>
                                <asp:Label ID="lblAcName" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="art_id" 
                            DataNavigateUrlFormatString="~/ArticleShow.aspx?ID={0}" 
                            DataTextField="art_title" HeaderText="标题" SortExpression="art_title" Target="_blank">
                        <ItemStyle Width="40%" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="art_date" DataFormatString="{0:d}" HeaderText="日期" SortExpression="art_date">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="art_click" HeaderText="点击数 " SortExpression="art_click">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="置顶">
                            <ItemTemplate>
                                <asp:Image ID="imgTop" runat="server" ImageUrl="../images/tick.png" Visible="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="推荐">
                            <ItemTemplate>
                                <asp:Image ID="imgCommend" runat="server" ImageUrl="../images/tick.png" Visible="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtEdit" runat="server" Text="编辑" PostBackUrl='<%# "ArticleEdit.aspx?id=" + Eval("art_id")%>'>

                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtDelete" runat="server" Text="删除" OnClientClick="return confirm('确认要删除这篇文章吗？')" CommandName="Delete"></asp:LinkButton>
                                
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页"  
                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowFirstLast="False" 
                                ShowMoreButtons="False" ShowPageIndexBox="Never" PageSize="3" CssClass="anpager" 
                CurrentPageButtonClass="cpb" CustomInfoHTML="文章共（%RecordCount%）篇" 
                ShowCustomInfoSection="Left" CustomInfoStyle="" >
              </webdiyer:AspNetPager>

                <asp:ObjectDataSource ID="ObjectDataSourceArticle" runat="server" 
                    DeleteMethod="Delete" SelectMethod="GetList" TypeName="ORBITA.Bll.ArticleManage" 
                    OnSelecting="ObjectDataSourceArticle_Selecting">
                    <DeleteParameters>
                        <asp:Parameter Name="art_id" Type="Int32" />
                    </DeleteParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownListTree" 
                            DefaultValue="2" Name="ac_id" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter Name="startRowIndex" ControlID="AspNetPager1" 
                            DefaultValue="1" PropertyName="StartRecordIndex" Type="Int32" />
                        <asp:ControlParameter ControlID="AspNetPager1" DefaultValue="5" 
                            Name="maximumRows" PropertyName="PageSize" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>

        </asp:UpdatePanel>
    </div>
</asp:Content>
