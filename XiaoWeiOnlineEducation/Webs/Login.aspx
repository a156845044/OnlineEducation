<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XiaoWeiOnlineEducation.Webs.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>凤凰晓薇·专转本中心后台管理系统-登录</title>
    <meta name="description" content="凤凰晓薇·专转本中心">
    <meta name="keywords" content="index">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="icon" type="image/png" href="../assets/i/favicon.png">
    <link rel="apple-touch-icon-precomposed" href="../assets/i/app-icon72x72@2x.png">
    <meta name="apple-mobile-web-app-title" content="凤凰晓薇·专转本中心" />
    <link rel="stylesheet" href="../assets/css/amazeui.min.css" />
    <link rel="stylesheet" href="../assets/css/amazeui.datatables.min.css" />
    <link rel="stylesheet" href="../assets/css/app.css">
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../Scripts/lhgdialog4.2.0/lhgdialog.min.js?skin=idialog" type="text/javascript"></script>
    <script src="../Scripts/js/brilliantui.core.js?page=login" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //登陆验证
            $("#btnLogin").click(function () {
                if ($("#txtAccount").val() == "") {
                    $.dialog.alert("请输入您的账号！");
                    return false;
                }
                if ($("#txtPwd").val() == "") {
                    $.dialog.alert("请输入您的密码！");
                    return false;
                }
                __doPostBack($(this).attr("name"), '');
                return false;
            });
        });

    </script>
</head>
<body data-type="login">
    <script src="../assets/js/theme.js"></script>
    <form id="form1" class="am-form tpl-form-line-form" runat="server">
        <div class="am-g tpl-g">
            <!-- 风格切换 -->
            <div class="tpl-skiner">
                <div class="tpl-skiner-toggle am-icon-cog">
                </div>
                <div class="tpl-skiner-content">
                    <div class="tpl-skiner-content-title">
                        选择主题
                    </div>
                    <div class="tpl-skiner-content-bar">
                        <span class="skiner-color skiner-white" data-color="theme-white"></span>
                        <span class="skiner-color skiner-black" data-color="theme-black"></span>
                    </div>
                </div>
            </div>
            <div class="tpl-login">
                <div class="tpl-login-content">
                    <div class="tpl-login-logo">
                    </div>
                    <div class="am-form-group">
                        <asp:TextBox ID="txtAccount" ClientIDMode="Static" placeholder="请输入账号" CssClass="tpl-form-input" runat="server"></asp:TextBox>
                    </div>

                    <div class="am-form-group">
                        <asp:TextBox ID="txtPwd" TextMode="Password" CssClass="tpl-form-input" placeholder="请输入密码" runat="server"></asp:TextBox>

                    </div>
                    <div class="am-form-group">
                        <asp:Button ID="btnLogin" ClientIDMode="Static" CssClass="am-btn am-btn-primary  am-btn-block tpl-btn-bg-color-success  tpl-login-btn" runat="server" Text="登录" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../assets/js/amazeui.min.js"></script>
    <script src="../assets/js/app.js"></script>
</body>
</html>
