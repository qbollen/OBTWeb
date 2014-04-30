<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ORBITA.UI.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Scripts/loopedslider.js" type="text/javascript" charset="utf-8"></script>

    <div class="wrapper col3">
        <div id="intro">
        </div>
    </div>
    <!-- ####################################################################################################### -->
    <div class="wrapper col4">
        <div id="homecontent">

            <div id="colwrap">

                <h2>About ORBITA</h2>

                <div class="about">


                    <div class="companypic">
                        <a href="About.aspx">
                            <img src="images/company.jpg" alt="" /></a>
                    </div>
                    <p>orbita is one of the reputable card operated &nbsp; lock and hotel &nbsp; locking systems &nbsp; manufactuers &nbsp; for &nbsp; the hospitality &nbsp; industry &nbsp; in &nbsp; china, established to offer the best quality products &nbsp; with &nbsp; professional and effective service to our customers.</p>
                    <p>orbita series of product is a product of years of experience integrated with the advanced technology from siemens, dallas, atmel, philip etc. the cooperation with fidelio and other popular pms ...</p>
                    <p class="more"><a href="About.aspx">Continue Reading &raquo;</a></p>

                    <div class="clear"></div>
                </div>
                <div class="cert">
                    <h2>Certificates</h2>
                    <ul>
                        <li>
                            <a href="images/orbita_iso_1.gif" target="_blank">
                                <img class="ce" src="images/orbita_iso.gif" alt="" /></a>
                        </li>

                        <li><a href="images/orbita_ce_1.gif" target="_blank">
                            <img class="ce" src="images/orbita_ce.gif" alt="" /></a>
                        </li>

                        <li>
                            <a href="images/orbita_fidelio.gif" target="_blank">
                                <img class="ce" src="images/orbita_fidelio_0.gif" alt="" /></a>
                        </li>
                    </ul>
                </div>
            </div>

            <div id="news">
                <h2>News</h2>
                <asp:ListView ID="ListViewArticleTop" runat="server"
                     DataSourceID="ObjectDataSourceArticleTop" OnItemDataBound="ListViewArticleTop_ItemDataBound">
                    <LayoutTemplate>
                        <ul>
                            <li id="itemPlaceHolder" runat="server"></li>
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li runat="server">
                            <div class="imgcontainer">
                                <asp:Image ID="image" CssClass="image" runat="server" />
                            </div>
                            <div class="centcontainer">
                                <h1>
                                    <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                                </h1>
                                <asp:Label ID="lblDesc" runat="server"></asp:Label>
                            </div>
                            <div class="clear"></div>
                            <div class="continue">
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
                <h2>Recommend Products</h2>
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
