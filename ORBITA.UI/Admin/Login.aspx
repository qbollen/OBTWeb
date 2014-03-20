<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ORBITA.UI.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Css/Admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/Admin.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div1">
        <div class="div2">
           <!-- <ul class="faceul">
                <li>Orbita Web Background Manage</li>
            </ul> -->
            <img src="../Images/AdminLog.gif" />
        </div>
        <div class="div3">
            <div class="div4">
                <img class="image1" src="../Images/login_1.gif" />
            </div>
            <div class="div5">
                <ul class="faceul2">
                    <li>User Name:</li>
                    <li class="label1">
                        <asp:TextBox ID="txtUserName" runat="server" Width="140px"></asp:TextBox>
                    </li>
                    <li>Password:</li>
                    <li>
                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="140px"></asp:TextBox>
                    </li>
                    <li>Validate Code:</li>
                    <li>
                        <asp:TextBox ID="txtCode" runat="server" Width="80px" CssClass="validatecode"></asp:TextBox>
                        <asp:Image ID="Image1" runat="server" ImageUrl="ValidateCode.aspx" />
                        &nbsp;
                    </li>
                </ul>
            </div>
            <div class="div6">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/Images/login_2.gif" CssClass="image2" 
                    OnClientClick="return ValidateLogin()"
                    onclick="ImageButton1_Click"  />
            </div>
        </div>
        <div class="div7">
            Copyright(C) 2012 ORBITA TECHNOLOGY CO.,LTD.
        </div>
        </div>
        </form>
     </body>
</html>
