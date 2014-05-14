<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="foot.ascx.cs" Inherits="ORBITA.UI.Controls.foot" %>
<div class="wrapper col5">
    <div id="footer">
        <div class="box1">
            <h2>Product Categories !</h2>
            <asp:ListView ID="ListViewProductClass" runat="server"
                DataSourceID="ObjectDataSourceProductClass">
                <LayoutTemplate>
                    <ul runat="server">
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

        </div>

        <div class="box4">
            <h2>Service !</h2>
            <ul>
                <li><a href="Contact.aspx">Contact</a></li>
                <li><a href="download.aspx">Download</a></li>
            </ul>

        </div>

        <div class="box2">
            <%--<h2>ORBITA QR !</h2>--%>
            <div class="wrap">
                <img src="~/../images/orbita_qr.png" />
            </div>
        </div>
        <div class="box contactdetails">
            <h2>Our Contact Details !</h2>
            <ul>
                <li>ORBITA TECHNOLOGY CO.,LTD</li>
                <li>Address:</li>
                <li>5th Floor,Bldg B8,Xiufeng Industrial zone,</li>
                <li>Buji,Longgang Dist,ShenZhen,China.</li>
                <li>Tel: 0086-755-83369158-606</li>
                <li>Fax: 0086-755-83617778</li>
                <li>Email: joshua@orbitatech.com</li>
            </ul>
        </div>
        <br class="clear" />
    </div>
</div>
<!-- ####################################################################################################### -->
<div class="wrapper col6">
    <div id="copyright">
        <p class="fl_left">Copyright &copy; 2014 - All Rights Reserved </p>
        <br class="clear" />
    </div>
</div>
