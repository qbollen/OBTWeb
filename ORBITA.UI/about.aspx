<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Web.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ORBITA.UI.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="css/web.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="side_box">
        <h2>Banner</h2>
        <div class="side_con">
            <ul>
                <li><a href="about.aspx">About ORBITA</a> </li>
            </ul>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="mycompany">

        <div class="introduce">
            <h1>ORBITA TECHNOLOGY CO.,LTD.</h1>

            <div class="content">
                <p>
                    &nbsp;&nbsp;orbita is one of the reputable card operated
                        lock and hotel locking systems manufactuers for the hospitality industry in china,established
                        to offer the best quality products with professional and effective service to our
                        customers.
                </p>
                <p>
                    &nbsp;&nbsp;orbita series of product is a product of years
                        of experience integrated with the advanced technology from siemens, dallas, atmel,
                        philip etc. the cooperation with fidelio and other popular pms system has just enabled
                        our locking system to a wide range of compatibility.
                </p>
                <p>
                    &nbsp;&nbsp;more than 3000 hotels, resorts and cruise ships
                        in 50 countries in the world are using our card locks, digital safes and other satisfactory
                        hotel intelligent accessories that have been becoming another attractive point for
                        the hotel.
                </p>
                <p>
                    &nbsp;&nbsp;orbita believes that every customer is a customer
                        for life. producing products of fine quality with our experience and knowledge is
                        our source of pride and customer's satisfaction is our only criterion in service.
                </p>
            </div>

        </div>
        
        <div class="cer">
            <a name="cer"></a>
            <h1>Certificates</h1>
            <ul class="cerlist">
                <li>
                    <ul>
                        <li><a href="images/orbita_iso_1.gif" target="_blank">
                            <img src="images/orbita_iso.gif" alt="" /></a></li>
                        <li>certificate: iso 9001:2008</li>
                    </ul>
                </li>

                <li>
                    <ul>
                        <li><a href="images/orbita_logo_1.gif" target="_blank">
                            <img src="images/orbita_logo.gif" alt="" /></a></li>
                        <li>certificate: orbita logo</li>
                    </ul>
                </li>

                <li>
                    <ul>
                        <li><a href="images/orbita_product_patent_1.gif" target="_blank">
                            <img src="images/orbita_product_patent.gif" alt="" /></a></li>
                        <li>certificate:product patent</li>
                    </ul>
                </li>

                <li>
                    <ul>
                        <li><a href="images/orbita_soft_certificate_1.gif" target="_blank">
                            <img src="images/orbita_soft_certificate.gif" alt="" /></a></li>
                        <li>certificate: lock system</li>
                    </ul>
                </li>

                <li>
                    <ul>
                        <li><a href="images/orbita_ce_1.gif" target="_blank">
                            <img src="images/orbita_ce.gif" alt="" /></a></li>
                        <li>certificate: ce</li>
                    </ul>
                </li>

                <li>
                    <ul>
                        <li><a href="images/orbita_fc_1.gif" target="_blank">
                            <img src="images/orbita_fc.gif" alt="" /></a></li>
                        <li>certificate: fc</li>
                    </ul>
                </li>

                <li>
                    <ul>
                        <li><a href="images/orbita_fidelio.gif" target="_blank">
                            <img src="images/orbita_fidelio_0.gif" alt="" /></a></li>
                        <li>certificate: fidelio interface</li>
                    </ul>
                </li>
            </ul>
        </div>

    </div>
</asp:Content>
