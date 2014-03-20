<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="ORBITA.UI.ProductList" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="leftinfo">
            <asp:ObjectDataSource ID="ObjectDataSourceProductClass" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetTree" 
                TypeName="ORBITA.BLL.ProductClassManage">
            </asp:ObjectDataSource>
            <asp:Repeater ID="RepeaterProductClass" runat="server" 
                DataSourceID="ObjectDataSourceProductClass" 
                onitemdatabound="RepeaterProductClass_ItemDataBound">
                <HeaderTemplate>
                    <table><thead><th colspan="2" class="categoryTitle">Product Category</th></thead>
                 </HeaderTemplate>
                 <ItemTemplate>
                 <tr onmouseover="this.style.backgroundColor='#f3f9ff'" onmouseout="this.style.backgroundColor='#fff'">
                    <td class="category">
                      <span class="spantitle"> <asp:Label ID="lblBlank" runat="server" Text="" /></span>
                      <span class="spantitle"><asp:Image ID="imgBar" runat="server" ImageUrl="~/Images/borrow.jpg" AlternateText="" /></span>

                     <span class="spantitle mypadding"><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "ProductList.aspx?id=" + Eval("pc_id") %>' 
                     Text='<%# Eval("pc_name") %>' CssClass="NodeName"></asp:HyperLink></span>
                    </td>
                 </tr>
                 </ItemTemplate>   
                <FooterTemplate>
                   </table>
                </FooterTemplate>
                
            </asp:Repeater>
        </div>
        <div class="navtitle">
          <span class="titleContent">
                <asp:Image ID="imgnav" Width="25px" Height="25px" runat="server" ImageUrl="~/Images/ico3.jpg" AlternateText="" />&nbsp;<a href="ProductList.aspx">Product List</a> <%=pcnav%>
        </span>
        </div>
       <div class="info">
        
       
           <asp:DataList ID="DataList1" runat="server" DataKeyField="prod_id" 
               DataSourceID="ObjectDataSourceProduct" RepeatColumns="3">
               <ItemTemplate>
                <table style="width:95%;">
                <tr>
                  <td class="MiniImage">
                   <a href='<%# "ProductShow.aspx?id=" + Eval("prod_id") %>'>
                   <asp:Image ID="imgProd"  runat="server" ImageUrl='<%# Eval("prod_image") %>'  AlternateText='<%# Eval("prod_name") %>' CssClass="imgProduct" /></a>
                  </td>
                </tr>
                <tr>
                <td class="noborder" style="font-family:宋体; font-size:13px;">
                   Name:
                   <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "ProductShow.aspx?id=" + Eval("prod_id") %>' Text='<%# Eval("prod_name")%>' CssClass="LabelStyle"></asp:HyperLink>
                   <br />
                   Model:
                   <asp:Label ID="prod_numberLabel" runat="server" 
                       Text='<%# Eval("prod_number") %>'  CssClass="LabelStyle"/>
                   <br />
                   Date:
                   <asp:Label ID="prod_dateLabel" runat="server" Text=' <%# string.Format("{0:d}", Eval("prod_date")) %>'  CssClass="LabelStyle"/>
                   <br />
                   </td></tr>
                </table>   
               </ItemTemplate>
               <ItemStyle Width="33%" BorderStyle="Dashed" Font-Size="Larger" 
                   BorderColor="#DFDFDF" BorderWidth="1px" />
           </asp:DataList>
           <asp:ObjectDataSource ID="ObjectDataSourceProduct" runat="server" 
               OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
               TypeName="ORBITA.Bll.ProductManage" 
               onselecting="ObjectDataSourceProduct_Selecting">
               <SelectParameters>
                   <asp:Parameter DefaultValue="0"  Name="pc_id" Type="Int32" />
                   <asp:ControlParameter ControlID="AspNetPager1" PropertyName="StartRecordIndex" 
                       Name="startRowIndex" Type="Int32"  />
                   <asp:ControlParameter ControlID="AspNetPager1"  PropertyName="PageSize"   
                       Name="maximumRows" Type="Int32" />
               </SelectParameters>
           </asp:ObjectDataSource>
         <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="First"  
                            LastPageText="Last" NextPageText="Next" 
               PrevPageText="Prev" ShowPageIndexBox="Never" PageSize="12" CssClass="anpager" 
            CurrentPageButtonClass="cpb" CustomInfoHTML="Total（%RecordCount%）" 
               Font-Size="Medium" ForeColor="#3366FF" ShowMoreButtons="False"  >
          </webdiyer:AspNetPager>
        
       </div>
</asp:Content>
