<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="case.aspx.cs" Inherits="ORBITA.UI._case" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.montage.min.js"></script>
    <style type="text/css">
  ul,ol,li{list-style:none;}    
.box01{ margin: 20px auto; padding:0px 20px; position:relative; height:600px;}
.box01 li{ float: left; width: 200px; text-align: center; padding-right: 10px; margin-right: 10px; height: 90px; margin-bottom: 15px; cursor: pointer; z-index:0; position:relative;}
.box01 li img{ height: 90px; margin: 0 auto;}
.box01 li .in{ position: absolute; left: 0; top: 0;width: 200px; }
.box01 li .in p{ display: none; text-align: left;}
.box01 li.on{ z-index:99;}
.box01 li.on .in{ padding: 5px; border: 1px solid #ccc; position:absolute;z-index:100; width:auto; text-align: center; top:-40px;  background: #fff;}
.box01 li.on .in p{ position:relative; display:block;}
.box01 li.on img{ height: auto; margin-bottom: 8px;}
.bsc{ background:url(../images/icon01.png) no-repeat; position:absolute; right:10px; width: 19px; height: 15px; font-size: 0; float:right;}

    </style>


        <script type="text/javascript">
            $(function () {
                $('.box01 li').hover(function () {
                    $(this).addClass('on');
                    var wl = $(this).find('img').attr('width');
                    if (wl < 190) {
                        $(this).find('.in').css('left', '0')
                    } else {
                        $(this).find('.in').css('left', -wl / 4)
                    }
                },
                function () {
                    $(this).animate({
                        height: "90px"
                    },
                    100).removeClass('on');
                    $(this).find('.in').css('left', '0')
                });
            })
</script>
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="side_box">
        <h2>Banner</h2>
        <div class="side_con">
            <ul>
                <li><a href="case.aspx">REFERENCE</a></li>
            </ul>
        </div>
    </div>
</asp:Content>   

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Title</h1>
<ul class="box01" >
	<li>
		<div class="in">
			<a href="#" target="_blank"><img src="References/01.jpg" /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">1</a></p>
		</div>
	</li>
	<li>
		<div class="in">
			<a href="#" target="_blank"><img src="References/02.jpg" /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">2</a></p>
		</div>
	</li>
	<li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/03.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">3</a></p>
	    </div>
	</li>
    <li>
		<div class="in">
			<a href="#" target="_blank"><img src="References/04.jpg" /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">4</a></p>
		</div>
	</li>
	<li>
		<div class="in">
			<a href="#" target="_blank"><img src="References/05.jpg" /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">5</a></p>
		</div>
	</li>
	<li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/06.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">6</a></p>
	    </div>
	</li>
    	<li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/07.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">7</a></p>
	    </div>
	</li>
    	<li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/08.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">8</a></p>
	    </div>
	</li>
    	<li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/09.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">9</a></p>
	    </div>
	</li>
    	<li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/10.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">10</a></p>
	    </div>
	</li>
    	<li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/11.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">11</a></p>
	    </div>
	</li>
    <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/12.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">12</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/13.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">13</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/14.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">14</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/15.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">15</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/16.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">16</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/17.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">17</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/18.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">18</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/34.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">34</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/20.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">20</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/21.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">21</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/22.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">22</a></p>
	    </div>
	</li>
        <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/25.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">25</a></p>
	    </div>
	</li>
    <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/41.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">41</a></p>
	    </div>
	</li>
     <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/26.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">26</a></p>
	    </div>
	</li>

         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/23.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">23</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/27.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">27</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/28.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">28</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/29.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">29</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/30.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">30</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/31.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">31</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/32.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">32</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/33.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">33</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/19.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">19</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/35.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">35</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/36.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">36</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/37.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">37</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/38.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">38</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/39.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">39</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/40.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">40</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/24.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">24</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/42.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">42</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/43.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">43</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/44.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">44</a></p>
	    </div>
	</li>
         <li>
	    <div class="in">
	        <a href="#" target="_blank"><img src="References/45.jpg"  /></a>
			<p><b class="bsc"></b><a href="#" target="_blank">45</a></p>
	    </div>
	</li>
</ul>

<!-- 代码结束 -->
<div class="clear"></div>
</asp:Content>
