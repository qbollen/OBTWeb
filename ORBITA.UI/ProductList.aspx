<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="ORBITA.UI.ProductList" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/web.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="side_box">
        <h2>Product Category</h2>
        <asp:ObjectDataSource ID="ObjectDataSourceProductClass" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetTree"
            TypeName="ORBITA.BLL.ProductClassManage"></asp:ObjectDataSource>
        <div class="side_con">
            <asp:ListView runat="server" ID="ListViewProductClass"
                DataSourceID="ObjectDataSourceProductClass">
                <LayoutTemplate>
                    <ul runat="server">
                        <li id="itemPlaceHolder" runat="server"></li>
                    </ul>
                </LayoutTemplate>

                <ItemTemplate>
                    <li runat="server">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "ProductList.aspx?id=" + Eval("pc_id") %>'
                            Text='<%# Eval("pc_name") %>'></asp:HyperLink>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="productList">
        <h1><a href="ProductList.aspx">Product List</a> <%=pcnav%></h1>
        <div class="list">
            <asp:ListView ID="ListViewProduct" runat="server" DataKeyNames="prod_id" DataSourceID="ObjectDataSourceProduct" GroupItemCount="3">
                <LayoutTemplate>
                    <ul class="container">
                        <asp:PlaceHolder ID="groupPlaceHolder" runat="server"></asp:PlaceHolder>
                        <li class="clear"></li>
                    </ul>

                </LayoutTemplate>
                <GroupTemplate>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </GroupTemplate>
                <ItemTemplate>
                    <li class="items">
                        <ul>
                            <li>
                                <a href='<%# "ProductShow.aspx?id=" + Eval("prod_id") %>'>
                                    <asp:Image ID="imgProd" runat="server" ImageUrl='<%# Eval("prod_image") %>'
                                        AlternateText='<%# Eval("prod_name") %>' CssClass="imgProduct" /></a>
                            </li>
                            <li class="model">Model:
                                <asp:Label ID="prod_numberLabel" runat="server"
                                    Text='<%# Eval("prod_number") %>' CssClass="LabelStyle" />
                            </li>
                        </ul>
                    </li>
                </ItemTemplate>
            </asp:ListView>

            <asp:ObjectDataSource ID="ObjectDataSourceProduct" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
                TypeName="ORBITA.Bll.ProductManage" OnSelecting="ObjectDataSourceProduct_Selecting">
               <SelectParameters>
                   <asp:Parameter DefaultValue="0"  Name="pc_id" Type="Int32" />
                   <asp:ControlParameter ControlID="AspNetPager1" PropertyName="StartRecordIndex" 
                       Name="startRowIndex" Type="Int32"  />
                   <asp:ControlParameter ControlID="AspNetPager1"  PropertyName="PageSize"   
                       Name="maximumRows" Type="Int32" />
               </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <div class="clear"></div>
        <div class="paging">
         <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="First"  
                            LastPageText="Last" NextPageText="Next" PrevPageText="Prev" 
                            ShowMoreButtons="False" ShowPageIndexBox="Never" PageSize="12" CssClass="anpager" 
            CurrentPageButtonClass="cpb" CustomInfoHTML="" 
            ShowCustomInfoSection="Left" CustomInfoClass=""  >
          </webdiyer:AspNetPager>
            <div class="clear"></div>
        </div>
        
    </div>
</asp:Content>
