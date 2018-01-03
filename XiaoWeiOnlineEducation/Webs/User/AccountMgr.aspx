<%@ Page Title="" Language="C#" MasterPageFile="~/Webs/inc/Site.Master" AutoEventWireup="true" CodeBehind="AccountMgr.aspx.cs" Inherits="XiaoWeiOnlineEducation.Webs.User.AccountMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Nav" runat="server">
    <li class="am-active">修改帐号</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TabPage" runat="server">
    <div class="row">

        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title am-fl"></div>
                    <div class="widget-function am-fr">
                    </div>
                </div>
                <div class="widget-body am-fr">
                    <div class="am-form tpl-form-line-form">
                        <div class="am-form-group">
                            <label for="user-name" class="am-u-sm-3 am-form-label">当前账号 <span class="tpl-form-line-small-title">CurrentAccount</span></label>
                            <div class="am-u-sm-9">
                                <asp:Literal ID="litAccount" runat="server"></asp:Literal>
                            </div>
                        </div>

                        <div class="am-form-group">
                            <label for="txtCurrentPwd" class="am-u-sm-3 am-form-label">当前密码 <span class="tpl-form-line-small-title">Password</span></label>
                            <div class="am-u-sm-9">
                                <asp:TextBox ID="txtCurrentPwd" ClientIDMode="Static" TextMode="Password" CssClass="am-form-field tpl-form-no-bg" placeholder="请输入您当前的帐号密码" runat="server"></asp:TextBox>
                                <small>当前密码为必填</small>
                            </div>
                        </div>
                        <div class="am-form-group">
                            <label for="txtAccount" class="am-u-sm-3 am-form-label">帐号 <span class="tpl-form-line-small-title">NewAccount</span></label>
                            <div class="am-u-sm-9">
                                <asp:TextBox ID="txtAccount" ClientIDMode="Static" TextMode="Password" CssClass="am-form-field tpl-form-no-bg" placeholder="请输入您要修改的帐号" runat="server"></asp:TextBox>
                                <small>当前修改的帐号为必填</small>
                            </div>
                        </div>
                        <div class="am-form-group">
                            <div class="am-u-sm-9 am-u-sm-push-3">
                                <asp:Button ID="btnSave" runat="server" CssClass="btnSave am-btn am-btn-primary tpl-btn-bg-color-success" Text="提交" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--当前登录人员编号-->
    <asp:HiddenField ID="hfldUserId" ClientIDMode="Static" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
    <script src="../../Scripts/js/custom/user.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            initData();//初始化数据
            initEvent();//初始化事件
        });

        /**
         *初始化数据
         */
        function initData() {

        }
    </script>
    <script type="text/javascript">

        //初始化事件
        function initEvent() {
            //修改密码验证
            $(".btnSave").click(function () {
                var userId = $("#hfldUserId").val();
                if ($("#txtCurrentPwd").val() == "") {
                    $("#txtCurrentPwd").focus();
                    $.dialog.alert("系统要求验证您当前登录密码，请输入！");
                    return false;
                }
                if (!checkPwd(userId, $("#txtCurrentPwd").val())) {
                    $("#txtCurrentPwd").focus();
                    $.dialog.alert("密码有误，请输重新验证！");
                    return false;
                }
                if ($("#txtAccount").val() == "") {
                    $("#txtAccount").focus();
                    $.dialog.alert("请输入您要修改的账号！");
                    return false;
                }
                return doConfrim(this, "您确定要修改账号吗？");
            });

        }
    </script>
</asp:Content>
