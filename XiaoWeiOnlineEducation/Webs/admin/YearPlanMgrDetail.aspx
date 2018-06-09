<%@ Page Title="" Language="C#" MasterPageFile="~/Webs/inc/Site.Master" AutoEventWireup="true" CodeBehind="YearPlanMgrDetail.aspx.cs" Inherits="XiaoWeiOnlineEducation.Webs.admin.YearPlanMgrDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Nav" runat="server">
    <li class="am-active">
        <asp:Literal ID="litNav" runat="server"></asp:Literal>计划详细</li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TabPage" runat="server">
    <div class="row">
        <div class="am-u-sm-12 am-u-md-12 am-u-lg-12">
            <div class="widget am-cf">
                <div class="widget-head am-cf">
                    <div class="widget-title  am-cf">专业列表</div>
                </div>
                <div class="widget-body  am-fr">
                    <div class="am-u-sm-12 am-u-md-9 am-u-lg-9">
                        <div class="am-form-group">
                            <div class="am-btn-toolbar">
                                <div class="am-btn-group am-btn-group-xs">
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
                                    <th width="50px">序号</th>
                                    <th width="80px">报考类别</th>
                                    <th width="150px">院校名称</th>
                                    <th width="110px">专业名称</th>
                                    <th width="80px">计划数</th>
                                    <th width="80px">投档分数</th>
                                    <th>对报考者专科阶段所学专业等要求</th>
                                    <th width="120px">专业课程要求</th>
                                    <th width="80px">备注</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#GetItemIndex(Container.ItemIndex,AspNetPager1) %></td>
                                            <td><%#Eval("AppTypeName") %></td>
                                            <td><%#Eval("SchoolName") %></td>
                                            <td><%#Eval("SchoolMajorName") %></td>
                                            <td><%#Eval("PlanNumber") %></td>
                                            <td><%#Eval("CastScore") %></td>
                                            <td><%#Eval("CandidateRequire") %></td>
                                            <td><%#Eval("MajorRequire") %></td>
                                            <td><%#Eval("Remarks") %></td>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
