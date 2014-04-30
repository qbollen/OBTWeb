<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductClassLeft.ascx.cs" Inherits="ORBITA.UI.Controls.ProductClassLeft" %>
<script src="../Scripts/jquery-1.4.1.min.js"></script>
<script src="../Scripts/mycookie.js"></script>
<script type="text/javascript">
    $(function () {
        var menu = $(".side_box [menu]");
        var val = menu.attr("menu");
        var submenu = $(".side_box [submenu=" + val + "]");
        var name = "menu" + val

        if (getCookie(name) == "expended") {
            submenu.css({ display: "block" });
        }
        else {
            submenu.css({ display: "none" });
            setCookie(name, "collapsed");
        }

        menu.bind("click", function () {
            if (getCookie(name) == "expended")
            {
                submenu.css({ display: "none" });
                setCookie(name, "collapsed")
            }
            else
            {
                submenu.css({ display: "block" });
                setCookie(name, "expended");
            }
        });
    });

</script>    
<div class="side_box">
        <h2>Product Categories</h2>
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