<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top.ascx.cs" Inherits="ORBITA.UI.Controls.top" %>
<div class="wrapper col1">
  <div id="header">
    <div id="logo">
      <!--<h1><a href="#">ORBITA</a></h1>-->
	  <img src="../images/log.png" alt="ORBITA" />
      <!--<p></p>-->
    </div>
	
    <div id="search">
      <form action="#" method="post">
        <fieldset>
          <legend>Product Search</legend>
          <input class="inp_srh" type="text" value="" />
          <input type="submit" name="go" id="go" value="Search" />
        </fieldset>
      </form>
    </div>
	
    <br class="clear" />
  </div>
</div>
<!-- ####################################################################################################### -->
<div class="wrapper col2">
  <div id="topbar">
  
    	<!-- The JavaScript -->
        <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
        <script type="text/javascript">
            $(function () {
                /**
				 * the menu
				 */
                var $menu = $('#ldd_menu');

                /**
				 * for each list element,
				 * we show the submenu when hovering and
				 * expand the span element (title) to 510px
				 */
                $menu.children('li').each(function () {
                    var $this = $(this);
                    var $span = $this.children('span');
                    $span.data('width', $span.width());

                    $this.bind('mouseenter', function () {
                        $menu.find('.ldd_submenu').stop(true, true).hide();
                        $span.stop().animate({ 'color': '#fff' }, 300, function () {
                            $this.find('.ldd_submenu').slideDown(300);
                        });
                    }).bind('mouseleave', function () {
                        $this.find('.ldd_submenu').stop(true, true).hide();
                        $span.stop().animate({ 'color': '#000' }, 300);
                    });
                });
            });
        </script>
    
    <div id="topnav">
			<ul id="ldd_menu" class="ldd_menu">
				<li>
					<span class="nosubmenu"><a href="index.aspx">HOME</a></span><!-- Increases to 510px in width-->
				</li>
				<li>
					<span>NEWS</span>
					<div class="ldd_submenu">
						<ul>
							<li class="ldd_heading">By Location</li>
							<li><a href="#">South America</a></li>
							<li><a href="#">Antartica</a></li>
							<li><a href="#">Africa</a></li>
							<li><a href="#">Asia and Australia</a></li>
							<li><a href="#">Europe</a></li>
						</ul>
						<a class="ldd_subfoot" href="#"> + New Deals</a>
					</div>
				</li>
				<li>
					<span class="nosubmenu"><a href="ProductList.aspx">PRODUCTS</a></span>
					<div class="ldd_submenu">
                        <asp:ListView ID="ListViewProductClass" runat="server"
                             DataSourceID="ObjectDataSourceProductClass"
                              OnItemDataBound="ListViewProductClass_ItemDataBound">
                        <LayoutTemplate>
                            <ul runat="server">
                                <li class="ldd_heading" runat="server">By Product</li>
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
                              
           <asp:ObjectDataSource ID="ObjectDataSourceProductClass" runat="server" 
               OldValuesParameterFormatString="original_{0}" SelectMethod="GetListByParentID" 
               TypeName="ORBITA.Bll.ProductClassManage">
               <SelectParameters>
                   <asp:Parameter DefaultValue="0" Name="parent_id" Type="Int32" />
               </SelectParameters>
           </asp:ObjectDataSource>

                        	<ul>
							<li class="ldd_heading">E3010</li>
							<li class="recommend"><img src="../images/E3010.png"></li>
						</ul>

						<a class="ldd_subfoot" href="#"> + Product Categories</a>
					</div>
				</li>
				<li>
					<span class="nosubmenu"><a href="case.aspx">REFERENCE</a></span>
				</li>
				<li>
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
							<li><a href="#">Tel:&nbsp;+86-18928480199</a></li>
                            <li><a href="#">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;+86-755-83369158-625</a></li>
						</ul>
                        <a class="ldd_subfoot" href="#"> + Service</a>
					</div>
				</li>
				<li>
					<span class="nosubmenu"><a href="contact.aspx">CONTACT US</a></span>
				</li>
			</ul>
    </div>

    <br class="clear" />
  </div>
</div>
<div class="clear"></div>