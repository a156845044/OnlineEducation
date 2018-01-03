<%@ Page Title="" Language="C#" MasterPageFile="~/Webs/inc/home.Master" AutoEventWireup="true" CodeBehind="scorelist.aspx.cs" Inherits="XiaoWeiOnlineEducation.Webs.site.scorelist" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TabPage" runat="server">
    <h2 class="about-title about-color"><%=DateTime.Now.Year %>年专转本各校各专业投档分数线查询</h2>
    <div class="am-u-lg-12 am-u-md-12 am-u-sm-12">
        <div class="am-panel-group">
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <div class="am-panel am-panel-default">
                        <div class="am-panel-hd">
                            <h3 class="am-panel-title"><span style="color: green;">#<%#GetItemIndex(Container.ItemIndex,AspNetPager1) %></span>&nbsp;<%#string.Format("{0}&nbsp;({1})", Eval("SchoolName"),Convert.ToInt32(Eval("SchoolType"))==0?"公办本科":"民办本科") %></h3>
                        </div>
                        <ul class="am-list am-list-static">
                            <li>专业名称：&nbsp;<%#Eval("SchoolMajorName") %></li>
                            <li>计划数：&nbsp;<%#Eval("PlanNumber") %></li>
                            <li>投档分数：&nbsp;<%#Eval("CastScore") %></li>
                        </ul>
                        <div class="am-panel-footer">
                            近三年投档分数：
                            <ul class="am-avg-sm-4 am-thumbnails">
                                <li><%#GetBeforeScore(Convert.ToInt32(Eval("YearId"))-1,Container.GetProperty("LastYearScore")) %> </li>
                                <li><%#GetBeforeScore(Convert.ToInt32(Eval("YearId"))-2,Container.GetProperty("TwoYearsAgoScore")) %> </li>
                                <li><%#GetBeforeScore(Convert.ToInt32(Eval("YearId"))-3,Container.GetProperty("ThreeYearsAgoScore")) %> </li>
                            </ul>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <%#GetEmptyRow(rptList) %>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pager_default" CurrentPageButtonClass="current"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging"
            PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="跳转" NumericButtonCount="5" PagingButtonSpacing="3px" ShowBoxThreshold="10">
        </webdiyer:AspNetPager>


    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
