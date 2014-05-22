<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="ORBITA.UI.ArticleList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/Controls/ArticleClassLeft.ascx" TagPrefix="uc1" TagName="ArticleClassLeft" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="Css/web.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ArticleClassLeft runat="server" ID="ArticleClassLeft" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="articlelist">
        <h1><span>News List<%=acnav %></span></h1>
        <div class="list">
            <asp:ListView ID="ListViewArticle" runat="server"
               DataSourceID="ObjectDataSourceArticle" OnItemDataBound="ListViewArticle_ItemDataBound">
                <LayoutTemplate>
                    <ul runat="server">
                        <li id="itemPlaceHolder" runat="server"></li>
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li runat="server">
                        <div class="artimg">
                            <asp:HyperLink ID="HyperLinkImage" runat="server" >
                                <asp:Image id="artimg" runat="server" CssClass="leftimg"/>
                            </asp:HyperLink>
                        </div>
                        <div class="artdigest">
                            <asp:HyperLink ID="HyperLinkTitle" runat="server" CssClass="title">
                                <h1><asp:Literal ID="litTitle" runat="server"></asp:Literal></h1>
                            </asp:HyperLink>
                            <asp:Label ID="lbldscription" runat="server" CssClass="dsc" >
                            </asp:Label>
                        </div>
                        <div class="clear"></div>
                    </li>
                </ItemTemplate>
            </asp:ListView>

            <asp:ObjectDataSource ID="ObjectDataSourceArticle" runat="server"
                OldValuesParameterFormatString="original_{0}"
                OnSelecting="ObjectDataSourceArticle_Selecting"
                SelectMethod="GetList" TypeName="ORBITA.Bll.ArticleManage">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="ac_id" Type="Int32" />
                    <asp:ControlParameter ControlID="AspNetPager1" Name="startRowIndex" PropertyName="StartRecordIndex" Type="Int32" />
                    <asp:ControlParameter ControlID="AspNetPager1" Name="maximumRows" PropertyName="PageSize" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <div class="clear"></div>

        <div class="paging">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="First"
                LastPageText="Last" NextPageText="Next" PrevPageText="Prev" ShowFirstLast="False"
                ShowMoreButtons="False" ShowPageIndexBox="Never" PageSize="12" CssClass="anpager"
                CurrentPageButtonClass="cpb" CustomInfoHTML=""
                ShowCustomInfoSection="Left" CustomInfoClass="">
            </webdiyer:AspNetPager>
        </div>
    </div>

</asp:Content>
