<%@ Page Title="" Language="C#" MasterPageFile="~/Webs/inc/Site.Master" AutoEventWireup="true" CodeBehind="LustrumYearPlanMgr.aspx.cs" Inherits="XiaoWeiOnlineEducation.Webs.admin.LustrumYearPlanMgr" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Scripts/uploadify3.2.1/uploadify.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Nav" runat="server">
    <li class="am-active">5年一贯制专业计划表管理</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TabPage" runat="server">
    <div class="row">
        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title  am-cf">专业列表</div>
                </div>
                <div class="widget-body  am-fr">
                    <div class="am-u-sm-12 am-u-md-6 am-u-lg-6">
                        <div class="am-form-group">
                            <div class="am-btn-toolbar">
                                <div class="am-btn-group am-btn-group-xs">

                                    <button type="button" class="am-btn am-btn-default am-btn-success" data-am-modal="{target: '#doc-modal-1',dimmer:false,width: 600}"><span class="am-icon-plus"></span>Excel导入</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="am-u-sm-12 am-u-md-12 am-u-lg-3">
                        <div class="am-input-group am-input-group-sm tpl-form-border-form cl-p">
                            <asp:TextBox ID="txtKeyword" CssClass="am-form-field" runat="server"></asp:TextBox>

                            <span class="am-input-group-btn">
                                <asp:Button ID="btnSearch" CssClass="am-btn  am-btn-default am-btn-success tpl-table-list-field am-icon-search" runat="server" Text="搜 索" OnClick="btnSearch_Click" />
                            </span>
                        </div>
                    </div>

                    <div class="am-u-sm-12">
                        <table width="100%" class="am-table am-table-compact am-table-striped tpl-table-black ">
                            <thead>
                                <tr>
                                    <th>年度</th>
                                    <th>名称</th>
                                    <th>查询分数</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                                    <ItemTemplate>
                                        <tr class="even gradeC">
                                            <td><%#Eval("YearId") %></td>
                                            <td><%#Eval("PlanName") %></td>
                                            <td><%#Convert.ToInt32(Eval("StateFlag"))==1?"<span style=\"color:green\">可查询</span>":"<span style=\"color:red\">不可查询</span>" %></td>
                                            <td>
                                                <%#string.Format("<a href=\"YearPlanMgrDetail.aspx?PlanId={0}\" target=\"_blank\">查看详细</a>",Eval("PlanId")) %>
                                                |
                                                <asp:LinkButton ID="lbtnOpen" CommandArgument='<%#string.Format("{0},{1}",Eval("StateFlag"),Eval("PlanId")) %>' CommandName="lbtnOpen" runat="server"><%#Convert.ToInt32(Eval("StateFlag"))==1?"关闭":"开启" %>分数查询</asp:LinkButton>
                                                |
                                                <asp:LinkButton ID="lbtnDel" CommandArgument='<%#Eval("PlanId") %>' OnClientClick="return onlbtnConfrim(this,'您确定要删除本年度的所有记录吗？',false)" CommandName="lbtnDel" runat="server">删除</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pager_default" CurrentPageButtonClass="current"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging"
                        PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="跳转" NumericButtonCount="5" PagingButtonSpacing="3px" ShowBoxThreshold="10">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>

    <!--Excel导入-->
    <div class="am-modal am-modal-no-btn" tabindex="-1" id="doc-modal-1">
        <div class="am-modal-dialog">
            <div class="am-modal-hd">
                Excel导入
               
               

                <a href="javascript: void(0)" class="am-close am-close-spin" data-am-modal-close>&times;</a>
            </div>
            <div class="am-modal-bd">
                <div class="am-form am-form-horizontal">
                    <div class="am-form-group">
                        <label for="user-name" class="am-u-sm-3 am-form-label"><span class="tpl-form-line-small-title">当前年度：</span></label>
                        <div class="am-u-sm-9">
                            <asp:TextBox ID="txtYear" ClientIDMode="Static" onFocus="WdatePicker({dateFmt:'yyyy'})" CssClass="am-form-field data-am-datepicker" placeholder="请输入您要导入的年度" runat="server"></asp:TextBox>
                        </div>

                    </div>

                    <div class="am-form-group">
                        <label for="user-name" class="am-u-sm-3 am-form-label"><span class="tpl-form-line-small-title">操作：</span></label>
                        <div class="am-u-sm-9">
                            <input type="file" name="uploadify" id="uploadify" value="选择要上传的文件" />
                        </div>
                    </div>
                    <div class="am-form-group">
                        <label for="user-name" class="am-u-sm-3 am-form-label"><span class="tpl-form-line-small-title">导入类型：</span></label>
                        <div class="am-u-sm-9">
                            <asp:DropDownList ID="ddlType" Style="color: #000000" runat="server">
                                <asp:ListItem Value="0" Text="计划"></asp:ListItem>
                                <asp:ListItem Value="1" Text="分数"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="am-form-group">
                        <label for="txtCurrentPwd" class="am-u-sm-3 am-form-label"><span class="tpl-form-line-small-title"></span></label>
                        <div class="am-u-sm-9" id="attchment-list">
                            <ul class="am-list confirm-list" id="attch-list">
                            </ul>
                        </div>
                    </div>

                    <div class="am-form-group">
                        <asp:Button ID="btnSave" runat="server" CssClass="btnSave am-btn am-btn-primary tpl-btn-bg-color-success" Text="导 入" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--上传列队-->
    <div class="am-modal am-modal-no-btn" tabindex="-1" id="uploadify-dialog">
        <div class="am-modal-dialog">
            <div class="am-modal-hd am-lg-text-left">
                上传列队<a href="javascript: void(0)" class="am-close am-close-spin" data-am-modal-close> &times;</a>
            </div>
            <div class="am-modal-bd">
                <div id="upload-fileQueue">
                </div>
                <div class="am-margin am-lg-text-right ">
                    <button type="button" class="am-btn  am-btn-default am-btn-sm" onclick="onCancelUpload()" data-toggle="button">
                        关 闭</button>
                    <button type="button" class="am-btn am-btn-success am-btn-sm" onclick="onUpload()" data-toggle="button">
                        上 传</button>
                </div>
            </div>
        </div>
    </div>
    <!--附件信息-->
    <asp:HiddenField ID="hfldAttachData" ClientIDMode="Static" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
    <script src="../../Scripts/uploadify3.2.1/jquery.uploadify.min.js"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            initData();//初始化数据
            initEvent();//初始化事件
        });

        //初始化数据
        function initData() {
            inituploadify();//初始化上传
        }

        //初始化事件
        function initEvent() {
            /**
            * 导入时询问
            */
            $(".btnSave").click(function () {
                if ($("#txtYear").val() == "") {
                    $.dialog.alert("请选择您要导入的年度！");
                    return false;
                }

                if ($("#attch-list input").length <= 0) {
                    $.dialog.alert("请至少添加一条记录！");
                    return false;
                }


                return doConfrim(this, "您确定要导入吗？", function () {
                    saveAttachData();//保存附件
                });
            });
        }
    </script>
    <script type="text/javascript">
        //初始化上传
        function inituploadify() {
            //上传事件
            $("#uploadify").uploadify({
                'buttonClass': '',
                'swf': '../../Scripts/uploadify3.2.1/uploadify.swf',
                'uploader': '../../Handler/Upload.ashx?action=onUpload&random=' + Math.random(),
                'cancelImg': '../../Script/uploadify3.2.1/uploadify-cancel.png',
                'folder': 'uploadfiles',
                'queueID': 'upload-fileQueue',
                'fileTypeExts': '*.xls;',
                'auto': false,
                'multi': true,
                'buttonText': '选择要上传的文件',
                'buttonCursor': 'pointer',
                'onDialogClose': function (queueData) {//当选择文件窗体关闭时
                    if (queueData.filesQueued >= 1) {
                        showuploadify(); //打开模态框
                    }
                },
                'onUploadSuccess': function (file, data, response) {
                    var json = JSON.parse(data);
                    if (json.code == 1) {
                        json.id = "";
                        addFile(json);
                    }
                    else {
                        briAlert(json.msg, error);
                    }
                },
                'onQueueComplete': function () {//当队列中所有文件上传结束
                    closeuploadify();
                }
            });

        }


        //上传事件
        function onUpload() {
            $('#uploadify').uploadify('upload', '*');
        }

        //取消上传
        function onCancelupload() {
            $('#uploadify').uploadify('cancel', '*');
            queueDialog.hidden();
        }

        //显示上传列队
        function showuploadify() {
            $('#uploadify-dialog').modal({
                relatedTarget: this,
                dimmer: false,
                width: 400
            });
        }

        //关闭模态框
        function closeuploadify() {
            $("#uploadify-dialog").modal('close');
        }

        //添加文件
        function addFile(json) {
            var $ul = $("#attch-list");

            var li = "<li>";
            li += "<input  type=\"hidden\" data-field=\"name\" value=\"" + json.name + "\" />";
            li += "<input  type=\"hidden\" data-field=\"path\"  value=\"" + json.path + "\" />";
            li += "<a href=\"javaScript:void(0);\" class=\"am-text-truncate am-icon-file-text\"> ";
            li += json.name;
            li += "<i class=\"am-icon-close am-topbar-toggle\" onclick=\"delAttach(this)\"></i></a></li>";
            $ul.append(li);

        }

        //删除附件
        function delAttach(obj) {
            var node = $(obj).parent().parent(); //要删除的LI节点
            $.dialog.confirm("您确定要删除吗？", function (result) {
                if (result) {
                    node.remove();
                }
            }, "");
        }

        //保存附件信息
        function saveAttachData() {
            var data = [];
            var item = {};
            //文件信息
            $("#attch-list li").each(function () {
                if ($.trim($(this).html()) != "") {
                    item.AttchName = $(this).children().eq(0).val();
                    item.AttachPath = $(this).children().eq(1).val();
                    data.push(item);
                    item = {};
                }
            });
            $("#hfldAttachData").val(data[0].AttachPath);
            data = [];
            item = {};
        }
    </script>
</asp:Content>
