<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ORBITA.UI.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/featured_slide.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.jcarousel.pack.js"></script>
    <script type="text/javascript" src="Scripts/jquery.jcarousel.setup.js"></script>
  <script src="Scripts/loopedslider.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <!-- ####################################################################################################### -->
<%--    <div class="wrapper col3">
        <div id="intro">
        </div>
    </div>--%>

  <div class="wrapper col3">
  <div id="featured_slide">
    <div id="featured_content">
      <ul>
        <li><img src="images/e3041.jpg" alt="E3041" />
          <div class="floater">
            <h2>Model: E3041</h2>
            <p>Waterproof idea for outdoor use, 
               Replace your old mechanical lock with our electronic lock, 
               Keep your mortise and carpentry, save your door & money&hellip;</p>
            <p class="readmore"><a href="ProductShow.aspx?id=298">Continue Reading &raquo;</a></p>
          </div>
        </li>
        <li><img src="images/obt2045mb.jpg" alt="OBT-2045MB" />
          <div class="floater">
            <h2>Model: OBT-2045MB</h2>
            <p>Enhanced LED Display, Audio/Visual Operating Signals, Event audit trail(Optaional), Easy Access Battery Panel, Emergency Battery Jumper Box, Secure Pedestal Mounting, Mechanical Fail-Safe Override key, Tamper-Proof Installation Hardware, Inner carpet, Spring loaded door, Fixing holes at bottom and back with screws, Auto secure mode(3 times wrong input of code gets frozen for 15mins)&hellip;</p>
            <p class="readmore"><a href="ProductShow.aspx?id=187">Continue Reading &raquo;</a></p>
          </div>
        </li>
        <li><img src="images/MB-40GA.jpg" alt="MB-40GA" />
          <div class="floater">
            <h2>Model: MB-40GA</h2>
            <p>High performance with superior absorption new technology, cooling by ammonia, no moving part, no vibration, noiseless, maintenance-free operation.&hellip;</p>
            <p class="readmore"><a href="ProductShow.aspx?id=312">Continue Reading &raquo;</a></p>
          </div>
        </li>
      </ul>
    </div>
    <a href="javascript:void(0);" id="featured-item-prev"><img src="images/prev.png" alt="" /></a> <a href="javascript:void(0);" id="featured-item-next"><img src="images/next.png" alt="" /></a> </div>
</div>

    <!-- ####################################################################################################### -->
    <div class="wrapper col4">
        <div id="homecontent">
            <div id="news">          
                <asp:ListView ID="ListViewArticleTop" runat="server"
                     DataSourceID="ObjectDataSourceArticleTop" OnItemDataBound="ListViewArticleTop_ItemDataBound">
                    <LayoutTemplate>
                        <ul>
                            <li id="itemPlaceHolder" runat="server"></li>
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li runat="server">
                             <h2>
                                <div class="imgcontainer">
                                    <asp:Image ID="image" CssClass="image" runat="server" />
                                 </div> 
                                 <div class="title">
                                     <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                                 </div>   
                                 <div class="clear"></div>                                                                                                                  
                             </h2>

                             <div class="content">
                                <asp:Label ID="lblDesc" runat="server"></asp:Label>
                             </div> 
                                                         
                             <div class="more">
                                <asp:HyperLink ID="HyperLinkMore" runat="server">
                                    Continue Reading &raquo;
                                </asp:HyperLink>
                             </div>
                            
                            
                        </li>
                    </ItemTemplate>
                </asp:ListView>

                <asp:ObjectDataSource ID="ObjectDataSourceArticleTop" runat="server"
                      TypeName="ORBITA.Bll.ArticleManage"
                      SelectMethod="GetTop">
                </asp:ObjectDataSource>
            </div>

            <div class="clear"></div>
        </div>
    </div>


    <!-- ####################################################################################################### -->
    <div class="wrapper col7">
        <div id="productSlider">
            <div class="prodbox box">
                <h2><span>Recommend Products</span></h2>
                <!-- Slider -->
                <div id="loopedSlider" class="box">
                    <asp:ListView ID="ListViewProductCommend" runat="server"
                        DataSourceID="ObjectDataSourceProductCommend" GroupItemCount="6" OnItemDataBound="ListViewProductCommend_ItemDataBound">
                        <LayoutTemplate>
                            <div class="container">
                                <div class="slides">

                                    <div id="groupPlaceHolder" runat="server"></div>

                                </div>
                                <!-- /slides -->
                            </div>
                            <!-- /container -->

                        </LayoutTemplate>

                        <GroupTemplate>
                            <div runat="server">
                                <ul runat="server" class="list box">
                                    <li id="itemPlaceHolder" runat="server"></li>
                                </ul>
                            </div>
                        </GroupTemplate>

                        <ItemTemplate>

                            <li runat="server">
                                <%--<a href="#"><img id="commendpics" runat="server" src="" alt="" /></a> --%>
                                <asp:HyperLink ID="lnkcommend" runat="server">
                                    <asp:Image ID="imgcommend" CssClass="imgcommend" runat="server" />
                                </asp:HyperLink>
                            </li>

                        </ItemTemplate>
                    </asp:ListView>

                    <asp:ObjectDataSource ID="ObjectDataSourceProductCommend" runat="server"
                        SelectMethod="GetCommend" TypeName="ORBITA.Bll.ProductManage"></asp:ObjectDataSource>

                    <!-- Arrows (left, right) -->
                    <a href="#" class="previous">
                        <img src="images/arrow-left.gif" alt="&laquo;" /></a>
                    <a href="#" class="next">
                        <img src="images/arrow-right.gif" alt="&laquo;" /></a>

                    <!-- Pagination -->
                    <ul class="pagination">
                        <li><a href="#"><span>1</span></a></li>
                        <li><a href="#"><span>2</span></a></li>
                        <li><a href="#"><span>3</span></a></li>
                    </ul>
                </div>
                <!-- /looperslider -->

                <script type="text/javascript">
                    $(function () {
                        $('#loopedSlider').loopedSlider();
                    });
                </script>

            </div>
        </div>
    </div>
</asp:Content>
