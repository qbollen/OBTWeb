<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top.ascx.cs" Inherits="ORBITA.UI.Controls.top" %>
<div class="wrapper col11"></div>
<div class="wrapper col10"></div>
<div class="wrapper col1">
  <div id="header">
    <div id="logo">
	  <a href="index.aspx"><img src="../images/orbita.png" alt="ORBITA" /> </a>    
    </div>
	  
    <div id="title">
        Professional.Powerful
    </div>

<%--    <div id="search">
      <form action="#" method="post">
        <fieldset>
          <legend>Site Search</legend>
          <input type="submit" name="go" id="go" value="GO" />
          <input type="text" value="Search the product;"  onfocus="this.value=(this.value=='Search the product;')? '' : this.value ;" />
        </fieldset>
      </form>
    </div>--%>

    <div id="menu">
        <ul>
            <li><a href="index.aspx">HOME</a></li>
            <li><a href="ArticleList.aspx">NEWS</a></li>
            <li><a href="ProductList.aspx?id=49">PRODUCTS</a></li>
            <li><a href="case.aspx">REFERENCES</a></li>
            <li class="last"><a href="service.aspx">SERVICE</a></li>
        </ul> 
    </div>
	
    <div class="clear" ></div>
  </div>
</div>
<!-- ####################################################################################################### -->
<%--<div class="wrapper col2">
  <div id="topbar">
  
    	
        <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
        <script type="text/javascript">
            $(function () {

                var $menu = $('#ldd_menu');   

                $menu.children('li').each(function () {
                var $this = $(this);
                var $span = $this.children('span');
                $span.data('width', $span.width());
                    $this.bind('mouseenter', function () {
                        $menu.find('.ldd_submenu').stop(true, true).hide();
                        $this.find('.ldd_submenu').slideDown(200);        
                    }).bind('mouseleave', function () {
                        $this.find('.ldd_submenu').stop(true, true).hide();
                        $this.find('.ldd_submenu').hide();
                });
            });
                
            });
        </script>
    
    <div id="topnav">
			<ul id="ldd_menu" class="ldd_menu">
				<li class="title">
					<span class="nosubmenu"><a href="index.aspx">HOME</a></span><!-- Increases to 510px in width-->
				</li>
				<li class="title">
					<span class="nosubmenu"><a href="ArticleList.aspx">NEWS</a></span>
					<div class="ldd_submenu">


                        <asp:ListView ID="ListViewArticleClass" runat="server"
                           DataSourceID="ObjectDataSourceArticleClass">
                            <LayoutTemplate>
                                <ul runat="server">
                                    <li class="ldd_heading" runat="server">News List</li>
                                    <li id="itemPlaceHolder" runat="server"></li>
                                </ul>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <li runat="server">

                                    <asp:HyperLink ID="HyperLink1" runat="server"
                                     NavigateUrl='<%# "~/ArticleList.aspx?id=" + Eval("ac_id") %>'
                                     Text='<%# Eval("ac_name") %>'></asp:HyperLink>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>

						<a class="ldd_subfoot" href="#"> + News List</a>

                        <asp:ObjectDataSource ID="ObjectDataSourceArticleClass" runat="server"
                         OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetListByParentID" TypeName="ORBITA.Bll.ArticleClassManage">
                           <SelectParameters>
                               <asp:Parameter  Name="parent_id" Type="Int32" DefaultValue="0" />
                           </SelectParameters>
                        </asp:ObjectDataSource>
					</div>
				</li>
				<li class="title">
					<span class="nosubmenu"><a href="ProductList.aspx?id=49">PRODUCTS</a></span>
					<div class="ldd_submenu">
                        <asp:ListView ID="ListViewProductClass" runat="server"
                             DataSourceID="ObjectDataSourceProductClass"
                              >
                        <LayoutTemplate>
                            <ul runat="server">
                                <li class="ldd_heading" runat="server">Product List</li>
                                <li id="itemPlaceHolder" runat="server"></li>
                            </ul>
                        </LayoutTemplate>
                             
                        <ItemTemplate>
                            <li runat="server">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ProductList.aspx?id="  + Eval("pc_id")%>' 
                                     Text='<%#Eval("pc_name") %>' CssClass="NodeName"></asp:HyperLink>
                            </li>
                        </ItemTemplate>
                        </asp:ListView>
                             

						<a class="ldd_subfoot" href="#"> + Product List</a>

                                   <asp:ObjectDataSource ID="ObjectDataSourceProductClass" runat="server" 
               OldValuesParameterFormatString="original_{0}" SelectMethod="GetListByParentID" 
               TypeName="ORBITA.Bll.ProductClassManage">
               <SelectParameters>
                   <asp:Parameter DefaultValue="0" Name="parent_id" Type="Int32" />
               </SelectParameters>
           </asp:ObjectDataSource>

					</div>
				</li>
				<li class="title">
					<span class="nosubmenu"><a href="case.aspx">REFERENCE</a></span>
				</li>
				<li class="title">
					<span>SERVICE</span>
					<div class="ldd_submenu">
						<ul>
							<li class="ldd_heading">Service</li>
							<li><a href="service.aspx">Support</a></li>
							<li><a href="download.aspx">Download</a></li>

						</ul>
						<ul>
							<li class="ldd_heading">Support</li>
							<li><a href="#">MSN:&nbsp;orbitaservice@msn.cn</a></li>
							<li><a href="#">Skype:&nbsp;orbitacustomerservice</a></li>
							<li><a href="#">Yahoo:&nbsp;orbitaservice</a></li>
							<li><a href="#">Email:&nbsp;service@orbitatech.com</a></li>							
                            <li><a href="#">Tel:&nbsp;+86-755-83369158-625</a></li>
						</ul>
                        <a class="ldd_subfoot" href="#"> + Service</a>
					</div>
				</li>
				<li class="title">
					<span class="nosubmenu"><a href="contact.aspx">CONTACT US</a></span>
				</li>
			</ul>
    </div>

    <br class="clear" />
  </div>
</div>--%>
<div class="clear"></div>