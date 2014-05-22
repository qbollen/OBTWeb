<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="case.aspx.cs" Inherits="ORBITA.UI._case" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.montage.min.js"></script>
    <script type="text/javascript">
            $(function () {
                $('#myreferences .box li').hover(function () {
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
    <link rel="Stylesheet" href="css/web.css" type="text/css" /> 
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="mynav" type="hidden" value="References" />
    <div class="side_box">
       <%-- <h2>Banner</h2>--%>
        <div class="side_con">
            <ul>
                <li><a href="case.aspx">References</a></li>
            </ul>
        </div>
    </div>
</asp:Content>   

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="myreferences">
        <h1><span>References</span></h1>
        <ul class="box">
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/01.jpg" /></a>
                    <p><b class="bsc"></b><a href="#">Carlson</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/02.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >wyndham</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/03.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" ></a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/04.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Hilton Hotel & resorts</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/05.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Starwood Hotels & Resorts</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/06.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Inter Continental Hotels & Resorts</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/07.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Fairmont Hotels & Resorts</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/08.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Kempinski</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/09.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Best Western</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/10.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Crown Regency Hotels & Resorts</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/11.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" ></a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/12.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >LaQuinta Inns & suites</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/13.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Radisson Blu Hotel,Zambia</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/14.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Nilai Springs Resort,Malaysia</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/15.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Hilton hotel kampala,Uganda</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/16.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Leo Meridian Resorts,Indla</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/17.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Lpoh,Malaysia</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/18.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Ramada Hotel,Pakistan</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/34.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Asia Paradise Hotel,Vietnam</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/20.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Mercure Value Hotel,Saudi Arabia</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/21.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Atlantica caldera palace,Greece</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/22.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Golden Beach Hotel,Arzebejan</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/25.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Grand Hotel Reykjavik,lceland</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/41.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >GK International Airport Hotel,Benin</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/26.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Kenya Bay Beach Hotel</a></p>
                </div>
            </li>

            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/23.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Sphinx Resort,Egypt</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/27.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Hawler Plaza Hotel,lraq</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/28.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Crown Regency Hotels & Towers in Cebu,Ph</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/29.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Best Western Plus in MD,USA</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/30.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Aswan Hotel,Egypt</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/31.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Twin Plaza Hotel,Indonesia</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/32.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Imperial Hotel,Turkey</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/33.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Duc Long Hotel,Vietnam</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/19.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Best Western City Sheridan,Cairns in Australia</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/35.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Aeolos mareblue hotels resorts,Greece</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/36.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Corp Hotel,Dubai</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/37.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Erbil International Hotel,lraq</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/38.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >King Solomon Hotel,lsrael</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/39.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Intercontinental Hotel,Ethiopia</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/40.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Ginger Hotels,India</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/24.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Oscar group resort,North Cyprus</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/42.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Caldera Palace,Greece</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/43.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Reikartz Hotels & Resorts,Ukraine</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/44.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Days lnn Deccan Plaza,India</a></p>
                </div>
            </li>
            <li>
                <div class="in">
                    <a href="#" >
                        <img src="References/45.jpg" /></a>
                    <p><b class="bsc"></b><a href="#" >Crown regency prince resort in Boracay,Ph</a></p>
                </div>
            </li>
        </ul>
    </div>
    <div class="clear"></div>
</asp:Content>
