<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleClassLeft.ascx.cs" Inherits="ORBITA.UI.Controls.ArticleClassLeft" %>
<div class="side_box">
    <h2>Article Categories</h2>
    <div class="side_con">
        <asp:ListView ID="ListViewArticleClass" runat="server"
            DataSourceID="ObjectDataSourceArticleClass">
            <LayoutTemplate>
                <ul runat="server">
                    <li id="itemPlaceHolder" runat="server"></li>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li runat="server">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "ArticleList.aspx?id=" + Eval("ac_id")%>'
                        Text='<%# Eval("ac_name") %>'></asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
<asp:ObjectDataSource ID="ObjectDataSourceArticleClass" runat="server"
     OldValuesParameterFormatString="original_{0}" 
     SelectMethod="GetListByParentID"
     TypeName="ORBITA.Bll.ArticleClassManage">
    <SelectParameters>
        <asp:Parameter DefaultValue="2" Name="parent_id" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>