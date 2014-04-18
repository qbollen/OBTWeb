<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ORBITA.UI.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script src="Scripts/loopedslider.js" type="text/javascript" charset="utf-8"></script>

<div class="wrapper col3">
  <div id="intro">
    <div class="fl_left"><a href="#"><img src="images/company.jpg" alt="" /></a></div>
    <div class="fl_right">
      <h2>About ORBITA</h2>
	  <p>orbita is one of the reputable card operated lock and hotel locking systems manufactuers for the hospitality industry in china,established to offer the best quality products with professional and effective service to our customers.</p>
      <p>orbita series of product is a product of years of experience integrated with the advanced technology from siemens, dallas, atmel, philip etc. the cooperation with fidelio and other popular pms system has just enabled our locking system to a wide range of compatibility...</p>
      <p class="more"><a href="About.aspx">Read More &raquo;</a></p>
	  <!--<ul>
        <li><a href="#">Link Text</a></li>
        <li><a href="#">Link Text</a></li>
        <li class="last"><a href="#">Link Text</a></li>
      </ul>-->
    </div>
    <br class="clear" />
  </div>
</div>
<!-- ####################################################################################################### -->
<div class="wrapper col4">
  <div id="homecontent">
    <div id="column1">
      <h2>News</h2>
      <ul>
        <li>
          <p><a href="#"><img src="images/demo/80x80.gif" alt="" /></a> Feugiatrutrum rhoncus semper enim massa eu intesque ipsum velit orci dolorem. Atnatis dolor tincidunt nulla elit auctortis laculisi elit fauctortor natis loreet.</p>
          <p class="more"><a href="#">Continue Reading &raquo;</a></p>
        </li>
        <li>
          <p><a href="#"><img src="images/demo/80x80.gif" alt="" /></a> Feugiatrutrum rhoncus semper enim massa eu intesque ipsum velit orci dolorem. Atnatis dolor tincidunt nulla elit auctortis laculisi elit fauctortor natis loreet.</p>
          <p class="more"><a href="#">Continue Reading &raquo;</a></p>
        </li>
        <li>
          <p><a href="#"><img src="images/demo/80x80.gif" alt="" /></a> Feugiatrutrum rhoncus semper enim massa eu intesque ipsum velit orci dolorem. Atnatis dolor tincidunt nulla elit auctortis laculisi elit fauctortor natis loreet.</p>
          <p class="more"><a href="#">Continue Reading &raquo;</a></p>
        </li>
        <li class="last">
          <p><a href="#"><img src="images/demo/80x80.gif" alt="" /></a> Feugiatrutrum rhoncus semper enim massa eu intesque ipsum velit orci dolorem. Atnatis dolor tincidunt nulla elit auctortis laculisi elit fauctortor natis loreet.</p>
          <p class="more"><a href="#">Continue Reading &raquo;</a></p>
        </li>
      </ul>
    </div>
    <div id="colwrap">
      <div class="column2">
        <h2>Adipisciniapellentum Consequam</h2>
        <ul>
          <li>
            <h2 class="title"><img src="images/demo/64x64.gif" alt="" />Nullamlacus dui ipsum conseque</h2>
            <p>Nullamlacus dui ipsum conseque loborttis non euisque morbi penas dapibulum orna. Urnaultrices quis curabitur phasellentesque congue magnis vestibulum quismodo nulla et feugiat. Adipisciniapellentum leo ut consequam ris felit elit id nibh sociis malesuada.</p>
            <p class="readmore"><a href="#">Read More &raquo;</a></p>
          </li>
          <li class="last">
            <h2 class="title"><img src="images/demo/64x64.gif" alt="" />Nullamlacus dui ipsum conseque</h2>
            <p>Nullamlacus dui ipsum conseque loborttis non euisque morbi penas dapibulum orna. Urnaultrices quis curabitur phasellentesque congue magnis vestibulum quismodo nulla et feugiat. Adipisciniapellentum leo ut consequam ris felit elit id nibh sociis malesuada.</p>
            <p class="readmore"><a href="#">Read More &raquo;</a></p>
          </li>
        </ul>
        <div class="clear"></div>
      </div>
      <div class="column2">
        <h2>Laoremhabitur et phasellent wisis</h2>
        <p>Tincidunta sit eros dictum ac sollis ut convallis justo condiment justo. Phasellentumtellent ipsum congue sed et proin ut id lacus orci tor. Netuersemper velit platea diam tincidunt massa pede intesque nibh augue vel.</p>
        <p>Sitet monterdum senean faucibulus temper diam in iacus commodo amet ut. Pretralor loborttis id ristie pellenterdum masse quis justo interdum mollis egest. Urnaid at a malestibulum metus ac nunc vel eget et sagittis.</p>
      </div>
    </div>
    <div class="clear"></div>
  </div>
</div>


<!-- ####################################################################################################### -->
<div class="wrapper col7"  >
  <div id="productSlider" >
    <div class="prodbox box">

        <!-- Slider -->
        <div id="loopedSlider" class="box">
            <div class="container">
                <div class="slides">
                
                    <!-- first 5 items -->
                    <div>
                        <ul class="list box">
                            <li><a href="#"><img src="images/slider-1.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-2.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-3.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-4.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-5.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-5.jpg" alt="" /></a></li>
                        </ul>
                    </div>
                    
                    <!-- next 5 items -->
                    <div>
                        <ul class="list box">
                            <li><a href="#"><img src="images/slider-6.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-7.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-8.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-9.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-10.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-5.jpg" alt="" /></a></li>
                        </ul>
                    </div>
                    
                    <!-- and next 5 items -->
                    <div>
                        <ul class="list box">
                            <li><a href="#"><img src="images/slider-11.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-12.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-13.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-14.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-15.jpg" alt="" /></a></li>
                            <li><a href="#"><img src="images/slider-5.jpg" alt="" /></a></li>
                        </ul>
                    </div>
                    
                </div> <!-- /slides -->
            </div> <!-- /container -->

            <!-- Arrows (left, right) -->
            <a href="#" class="previous"><img src="images/arrow-left.gif" alt="&laquo;" /></a>
            <a href="#" class="next"><img src="images/arrow-right.gif" alt="&laquo;" /></a>

            <!-- Pagination -->
            <ul class="pagination">
                <li><a href="#"><span>1</span></a></li>
                <li><a href="#"><span>2</span></a></li>
                <li><a href="#"><span>3</span></a></li>
            </ul>
        </div> <!-- /looperslider -->
        
        <script type="text/javascript">
            $(function () {
                $('#loopedSlider').loopedSlider();
            });
        </script>

    </div> <!-- /box-03 -->
  </div>
</div>
</asp:Content>
