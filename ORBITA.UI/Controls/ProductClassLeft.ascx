﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductClassLeft.ascx.cs" Inherits="ORBITA.UI.Controls.ProductClassLeft" %>
<input id="mynav" type="hidden" value="Products" />
<script src="../Scripts/jquery-1.4.1.min.js"></script>
<script src="../Scripts/mycookie.js"></script>
<script type="text/javascript">
    $(function () {
        $(".side_box [menu]").each(function () {
            var val = $(this).attr("menu");
            var name = "orbita_product_class_menu_" + val;
            var flag = false;
            var submenus = $(".side_box [submenu=" + val + "]");

            if (getCookie(name) == "expended")
            {
                flag = true;
            }
            else
            {
                flag = false;
                setCookie(name, "collapsed");
            }

            submenus.each(function () {
                 
                if (flag) {
                    $(this).css({ display: "block" });
                }
                else {
                    $(this).css({ display: "none" });
                }
            });


            $(this).bind("click", function () {
                if (getCookie(name) == "expended") {
                    submenus.each(function(){
                        $(this).css({ display: "none" });
                    });
                    setCookie(name, "collapsed")
                }
                else {
                    submenus.each(function(){
                        $(this).css({ display: "block" });
                    });
                    setCookie(name, "expended");
                }
            });
        });
    });

</script>    
<div class="side_box">
        <%--<h2>Product Categories</h2>--%>
        <div class="side_con">
            <asp:ListView runat="server" ID="ListViewProductClass"
                DataSourceID="ObjectDataSourceProductClass" OnItemDataBound="ListViewProductClass_ItemDataBound">
                <LayoutTemplate>
                    <ul runat="server">
                        <li id="itemPlaceHolder" runat="server"></li>
                    </ul>
                </LayoutTemplate>

                <ItemTemplate>
                    <li id="liItem" runat="server">
                        <asp:Label ID="lblBlank" runat="server" Text=""></asp:Label>
                        <asp:HyperLink ID="classitem" runat="server"></asp:HyperLink>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceProductClass" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetTree"
    TypeName="ORBITA.BLL.ProductClassManage"></asp:ObjectDataSource>