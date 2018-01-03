<%@ Page Title="" Language="C#" MasterPageFile="~/Webs/inc/home.Master" AutoEventWireup="true" CodeBehind="score.aspx.cs" Inherits="XiaoWeiOnlineEducation.Webs.site.score" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Scripts/jquery-ui-1.12.1.custom/jquery-ui.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TabPage" runat="server">
    <h2 class="about-title about-color"><%=DateTime.Now.Year %>年专转本各校各专业投档分数线查询</h2>
    <div class="am-u-lg-12 am-u-md-12 am-u-sm-12">
        <div class="am-form">
            <div class="am-form-group">
                <label for="user-name" class="am-u-sm-12 am-form-label am-text-left">报考类别 <span class="tpl-form-line-small-title">category</span></label>
                <asp:DropDownList ID="ddlCategory" CssClass="am-form-field" ClientIDMode="Static" runat="server"></asp:DropDownList>
            </div>
            <div class="am-form-group">
                <label for="user-name" class="am-u-sm-12 am-form-label am-text-left">专业代码 <span class="tpl-form-line-small-title">code</span></label>
                <asp:TextBox ID="txtCodeId" ClientIDMode="Static" CssClass="tpl-form-input am-margin-top-xs" placeholder="请输入您要查询的专业名称" runat="server"></asp:TextBox>
                <asp:HiddenField ID="hfldCodeId" ClientIDMode="Static" runat="server" />
                <small>请填写任意名称，自动匹配。<span id="codeName"></span></small>
            </div>
            <asp:Button ID="btnSearch" ClientIDMode="Static" CssClass="am-btn am-btn-secondary am-btn-block" runat="server" Text="查询" OnClick="btnSearch_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <script src="../../Scripts/jquery-ui-1.12.1.custom/jquery-ui.min.js"></script>
    <script type="text/javascript">
        var item = null;
        $(function () {
            $("#txtCodeId").autocomplete({
                source: $.getUrl("Query/GetMajorCodeQueryList"),
                select: function (event, ui) {
                    item = ui.item;
                    $("#codeName").text("当前专业代码：" + ui.item.label);
                }
            });

            $("#btnSearch").click(function () {
                if ($("#txtCodeId").val() == "") {
                    $.dialog.alert("请输入您要查询的专业代码编号！");
                    return false;
                }
                doPostBack(this);
            });
        });
    </script>
</asp:Content>
