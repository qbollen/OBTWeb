<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top.ascx.cs" Inherits="ORBITA.UI.Controls.top" %>
<div class="wrapper col1">
  <div id="header">
    <div id="logo">
      <!--<h1><a href="#">ORBITA</a></h1>-->
	  <img src="images/log.png" alt="ORBITA" />
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
					<span>HOME</span><!-- Increases to 510px in width-->
					<div class="ldd_submenu">
						<ul>
							<li class="ldd_heading">subject 1</li>
							<li><a href="#">test1</a></li>
							<li><a href="#">test2</a></li>
							<li><a href="#">test3</a></li>
							<li><a href="#">test4</a></li>
							<li><a href="#">test5</a></li>
						</ul>
						<ul>
							<li class="ldd_heading">By Category</li>
							<li><a href="#">Sun &amp; Beach</a></li>
							<li><a href="#">Adventure</a></li>
							<li><a href="#">Science &amp; Education</a></li>
							<li><a href="#">Extreme Sports</a></li>
							<li><a href="#">Relaxing</a></li>
							<li><a href="#">Spa and Wellness</a></li>
						</ul>
						<ul>
							<li class="ldd_heading">By Theme</li>
							<li><a href="#">Paradise Islands</a></li>
							<li><a href="#">Cruises &amp; Boat Trips</a></li>
							<li><a href="#">Wild Animals &amp; Safaris</a></li>
							<li><a href="#">Nature Pure</a></li>
							<li><a href="#">Helping others &amp; For Hope</a></li>
							<li><a href="#">Diving</a></li>
						</ul>
						<a class="ldd_subfoot" href="#"> + New Deals</a>
					</div>
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
						<ul>
							<li class="ldd_heading">By Category</li>
							<li><a href="#">Sun &amp; Beach</a></li>
							<li><a href="#">Adventure</a></li>
							<li><a href="#">Science &amp; Education</a></li>
							<li><a href="#">Extreme Sports</a></li>
							<li><a href="#">Relaxing</a></li>
							<li><a href="#">Spa and Wellness</a></li>
						</ul>
						<ul>
							<li class="ldd_heading">By Theme</li>
							<li><a href="#">Paradise Islands</a></li>
							<li><a href="#">Cruises &amp; Boat Trips</a></li>
							<li><a href="#">Wild Animals &amp; Safaris</a></li>
							<li><a href="#">Nature Pure</a></li>
							<li><a href="#">Helping others &amp; For Hope</a></li>
							<li><a href="#">Diving</a></li>
						</ul>
						<a class="ldd_subfoot" href="#"> + New Deals</a>
					</div>
				</li>
				<li>
					<span>PRODUCTS</span>
					<div class="ldd_submenu">
						<ul>
							<li class="ldd_heading">By Location</li>
							<li><a href="#">South America</a></li>
							<li><a href="#">Antartica</a></li>
							<li><a href="#">Africa</a></li>
							<li><a href="#">Asia and Australia</a></li>
							<li><a href="#">Europe</a></li>
						</ul>
						<ul>
							<li class="ldd_heading">By Category</li>
							<li><a href="#">Sun &amp; Beach</a></li>
							<li><a href="#">Adventure</a></li>
							<li><a href="#">Science &amp; Education</a></li>
							<li><a href="#">Extreme Sports</a></li>
							<li><a href="#">Relaxing</a></li>
							<li><a href="#">Spa and Wellness</a></li>
						</ul>
						<ul>
							<li class="ldd_heading">By Theme</li>
							<li><a href="#">Paradise Islands</a></li>
							<li><a href="#">Cruises &amp; Boat Trips</a></li>
							<li><a href="#">Wild Animals &amp; Safaris</a></li>
							<li><a href="#">Nature Pure</a></li>
							<li><a href="#">Helping others &amp; For Hope</a></li>
							<li><a href="#">Diving</a></li>
						</ul>
						<a class="ldd_subfoot" href="#"> + New Deals</a>
					</div>
				</li>
				<li>
					<span>REFERENCE</span>
					<div class="ldd_submenu">
					<ul>
						<li class="ldd_heading">555</li>
					</ul>
					</div>
				</li>
				<li>
					<span>SERVICE</span>
					<div class="ldd_submenu">
					<ul>
						<li class="ldd_heading">555</li>
					</ul>
					</div>
				</li>
				<li>
					<span>ABOUT US</span>
					<div class="ldd_submenu">
					<ul>
						<li class="ldd_heading">555</li>
					</ul>
					</div>
				</li>
			</ul>
    </div>

    <br class="clear" />
  </div>
</div>
<div style="clear:both;"></div>