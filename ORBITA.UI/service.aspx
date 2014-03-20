<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Main.Master" AutoEventWireup="true" CodeBehind="service.aspx.cs" Inherits="ORBITA.UI.service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mycontent">
        <table width="100%">
            <tbody>
                <tr>
                    <td>
                        <span class="spantitle">
                            <img class="navimg" src="images/ico3.jpg" alt="" /></span> <span class="spantitle largetitle">
                                &nbsp; Support & Service</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="mytable" width="100%">
                            <tr>
                                <td>
                                    Msn</td>
                                <td>
                                    <a href="msnim:chat?contact=orbitaservice@msn.cn" target="_blank">
                                        <img src="images/msn.gif" alt="" />
                                        orbitaservice@msn.cn</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Skype</td>
                                <td>
                                    <a href="skype:orbitacustomerservice?call">
                                        <img src="images/skype.gif" alt="" />
                                        orbitacustomerservice</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Yahoo</td>
                                <td>
                                    <a href="http://edit.yahoo.com/config/send_webmesg?.target=orbitaservice@yahoo.com.cn&.src=pg">
                                        <img src="images/yahoo.gif" alt="" />
                                        orbitaservice</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email</td>
                                <td>
                                    <a href="mailto:service@orbitatech.com" target="_blank">
                                        <img src="images/email.gif" alt="" />
                                        service@orbitatech.com</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tel</td>
                                <td>
                                    +86-18928480199&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; +86-755-83369158-625
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="spantitle">
                            <img class="navimg" src="images/ico2.jpg" alt="" /></span> <span class="spantitle smalltitle">
                                &nbsp; Self Detection :</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="mytable" width="100%">
                            <tr>
                                <td>
                                    led color
                                </td>
                                <td>
                                    times
                                </td>
                                <td>
                                    indication
                                </td>
                                <td>
                                    solution
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    yellow
                                </td>
                                <td>
                                    1
                                </td>
                                <td>
                                    card not issued (blank or wrong card).
                                </td>
                                <td>
                                    reissue the card.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    yellow
                                </td>
                                <td>
                                    2
                                </td>
                                <td>
                                    wrong room no or area no..
                                </td>
                                <td>
                                    check the room card.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    yellow
                                </td>
                                <td>
                                    3
                                </td>
                                <td>
                                    card expired.
                                </td>
                                <td>
                                    renew the card.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    yellow
                                </td>
                                <td>
                                    4
                                </td>
                                <td>
                                    the lock is not authorized.
                                </td>
                                <td>
                                    authorize the lock with athor card.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    yellow
                                </td>
                                <td>
                                    5
                                </td>
                                <td>
                                    this card has been suspended.
                                </td>
                                <td>
                                    issue a new card.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    yellow
                                </td>
                                <td>
                                    6
                                </td>
                                <td>
                                    the deadbolt is activated.
                                </td>
                                <td>
                                    guest inside, use master card.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    yellow
                                </td>
                                <td>
                                    7
                                </td>
                                <td>
                                    the lock is blocked.
                                </td>
                                <td>
                                    unblock the lock.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    yellow
                                </td>
                                <td>
                                    8
                                </td>
                                <td>
                                    the card is not issued from this system.
                                </td>
                                <td>
                                    change a card.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    red
                                </td>
                                <td>
                                    3
                                </td>
                                <td>
                                    battery power low.
                                </td>
                                <td>
                                    change battery.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    red
                                </td>
                                <td>
                                    1/5s
                                </td>
                                <td>
                                    deadbolt activated.
                                </td>
                                <td>
                                    normal state.
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="spantitle">
                            <img class="navimg" src="images/ico2.jpg" alt="" /></span> <span class="spantitle smalltitle">
                                &nbsp; Download :</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="mytable" width="100%">
                            <tr>
                                <td>
                                    1. ic card locking system
                                </td>
                                <td>
                                    version:200801 (com port) <a href="down/ic%20locking(com%20port).rar">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                                <td>
                                    version:vt3.1 (usb port) <a href="down/ic%20card%20lock%203.1.rar">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2. rf card locking system
                                </td>
                                <td>
                                    version:200801 (com port) <a href="down/rf%20locking(com%20port).rar">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                                <td>
                                    version:vt3.4 (usb port) <a href="down/orbita_rf_locking_3.4.rar">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    3. mifare card locking system
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    version:vt3.1 (usb port) <a href="down/mifare.card.lock.3.1.rar">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    4. mifare card locking system(russian edition)
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    version:vt3.1 (usb port) <a href="down/mifare.card.lock.3.1.russian.rar">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    5. magnetic card locking system
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    version:vt3.1 (com port) <a href="down/orbita%20magnetic%20card%20locking.rar">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    6. product file
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <a href="down/profile.pps">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    7. one card system
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <a href="down/onecard.pps">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    8. locking system video manual
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <a href="down/locking%20system%20video%20manual%20.rar">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    9. doorlock user's handbook
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <a href="down/doorlock%20user%20handbook.pdf" target="_blank">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    10. ic locking assembly
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <a href="product/images/ic%20assembly.jpg" target="_blank">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    11. how to program a lock
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <a href="down/how%20to%20program%20a%20lock.rar" target="_blank">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    12. orbita products range
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <a href="down/orbita%20products%20range.rar" target="_blank">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    13. office lock system
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <a href="down/orbita%20office%20lock.rar" target="_blank">
                                        <img src="images/download_0.gif" alt="" />
                                    </a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

</asp:Content>
