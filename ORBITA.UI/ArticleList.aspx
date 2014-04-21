<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="ORBITA.UI.ArticleList" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register Src="~/Controls/ArticleClassLeft.ascx" TagPrefix="uc1" TagName="ArticleClassLeft" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ArticleClassLeft runat="server" id="ArticleClassLeft" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="GridViewArticle" runat="server" AutoGenerateColumns="False" CssClass="noborder" DataKeyNames="art_id" DataSourceID="ObjectDataSourceArticle" EnableModelValidation="True" GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "ArticleShow.aspx?id=" + Eval("art_id") %>'
                     Text='<%# Eval("art_title") %>' CssClass="LabelStyle boldLink"></asp:HyperLink>
                    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("art_description") %>'></asp:Label>...
                </ItemTemplate>
                <HeaderStyle CssClass="noborder" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" CssClass="noborder" />
            </asp:TemplateField>
            <asp:BoundField DataField="art_from" HeaderText="来源" SortExpression="art_from">
            <HeaderStyle CssClass="noborder" HorizontalAlign="Center" />
            <ItemStyle CssClass="noborder" HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="art_date" DataFormatString="{0:d}" HeaderText="日期" SortExpression="art_date">
            <HeaderStyle CssClass="noborder" HorizontalAlign="Center" />
            <ItemStyle CssClass="noborder" HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSourceArticle" runat="server" OldValuesParameterFormatString="original_{0}" OnSelecting="ObjectDataSourceArticle_Selecting" SelectMethod="GetList" TypeName="ORBITA.Bll.ArticleManage">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="ac_id" Type="Int32" />
            <asp:ControlParameter ControlID="AspNetPager1" DefaultValue="1" Name="startRowIndex" PropertyName="StartRecordIndex" Type="Int32" />
            <asp:ControlParameter ControlID="AspNetPager1" DefaultValue="10" Name="maximumRows" PropertyName="PageSize" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

             <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页"  
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowFirstLast="False" 
                            ShowMoreButtons="False" ShowPageIndexBox="Never" PageSize="6" CssClass="anpager" 
            CurrentPageButtonClass="cpb" CustomInfoHTML="文章共（%RecordCount%）篇" 
            ShowCustomInfoSection="Left"  >
          </webdiyer:AspNetPager>
         
</asp:Content>
