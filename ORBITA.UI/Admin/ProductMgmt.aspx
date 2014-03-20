<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ProductMgmt.aspx.cs" Inherits="ORBITA.UI.Admin.ProductMgmt" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="box">
            <h3>产品管理</h3>
            
            
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
 
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>

             <table >
                <tr>
                    <td width="20%">产品分类：</td>
                    <td>
                        <asp:DropDownList ID="DropDownListTree" runat="server" Width="200px" 
                            AppendDataBoundItems="True" AutoPostBack="True" 
                            onselectedindexchanged="DropDownListTree_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
  
                 <asp:GridView ID="GridViewProduct" runat="server" 
                     DataSourceID="ObjectDataSourceProduct" AutoGenerateColumns="False" 
                     DataKeyNames="prod_id" onrowdeleted="GridViewProduct_RowDeleted" 
                     onrowdatabound="GridViewProduct_RowDataBound" EnableModelValidation="True">
                     <Columns>
                         <asp:BoundField DataField="prod_id" HeaderText="ID" InsertVisible="False" 
                             ReadOnly="True" SortExpression="prod_id" >
                          <ItemStyle HorizontalAlign="Center" />   
                         </asp:BoundField>
                         <asp:TemplateField HeaderText="分类">
                         <ItemTemplate>
                                <asp:Label ID="lblPcName" runat="server" Text=""></asp:Label>
                         </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>
                         <asp:HyperLinkField DataNavigateUrlFields="prod_id" 
                             DataNavigateUrlFormatString="~/ProductShow.aspx?id={0}" 
                             DataTextField="prod_name"   HeaderText="产品名" 
                             SortExpression="prod_name" Target="_blank" >
                             <ItemStyle Width="35%" />
                         </asp:HyperLinkField>
                         
                         <asp:BoundField HeaderText="产品型号" DataField="Prod_Number" 
                             SortExpression="Prod_Number" >
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="prod_date" HeaderText="日期" 
                             SortExpression="prod_date" DataFormatString="{0:d}" >
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>
                             
                         <asp:BoundField DataField="prod_click" HeaderText="点击数" 
                             SortExpression="prod_click" >
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>
                         <asp:TemplateField HeaderText="置顶">
                         <ItemTemplate>
                         <asp:Image ID="imgTop" runat="server" ImageUrl="~/Images/tick.png" Visible="False" />
                         </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="推荐" >
                         <ItemTemplate>
                              <asp:Image ID="imgCommend" runat="server" ImageUrl="~/Images/tick.png" Visible="False" />  
                         </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="操作 ">
                            <ItemTemplate>
             <asp:LinkButton ID="lbtEdit" runat="server" Text="编辑" PostBackUrl='<%# "ProductEdit.aspx?id=" + Eval("prod_id")%>' ></asp:LinkButton>
             <asp:LinkButton ID="lbtDelete" runat="server"  Text="删除" OnClientClick="return confirm('确认要删除这个产品吗?');" CommandName="Delete"></asp:LinkButton>
                            </ItemTemplate>
                             <ItemStyle Width="10%" />
                         </asp:TemplateField>
                     </Columns>
                 </asp:GridView>
                

                
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页"  
                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowFirstLast="False" 
                                ShowMoreButtons="False" ShowPageIndexBox="Never" CssClass="anpager" 
                CurrentPageButtonClass="cpb" CustomInfoHTML="产品共（%RecordCount%）篇" 
                ShowCustomInfoSection="Left" CustomInfoStyle="" >
              </webdiyer:AspNetPager>
                

                
                 <asp:ObjectDataSource ID="ObjectDataSourceProduct" runat="server" 
                     SelectMethod="GetList" 
                     TypeName="ORBITA.BLL.ProductManage" 
                     onselecting="ObjectDataSourceProduct_Selecting" 
                     DeleteMethod="Delete">
                     <DeleteParameters>
                         <asp:Parameter Name="prod_id" Type="Int32" />
                     </DeleteParameters>
                     <SelectParameters>
                         <asp:ControlParameter ControlID="DropDownListTree" DefaultValue="1" 
                             Name="pc_id" PropertyName="SelectedValue" Type="Int32" />
                         <asp:ControlParameter ControlID="AspNetPager1" DefaultValue="1" 
                             Name="startRowIndex" PropertyName="StartRecordIndex" Type="Int32" />
                         <asp:ControlParameter ControlID="AspNetPager1" DefaultValue="5" 
                             Name="maximumRows" PropertyName="PageSize" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
                

                
             </ContentTemplate>
            </asp:UpdatePanel>
            

       
       </div>
</asp:Content>
