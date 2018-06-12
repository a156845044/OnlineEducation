<%@ Page Title="" Language="C#" MasterPageFile="~/Webs/inc/home.Master" AutoEventWireup="true" CodeBehind="querylist.aspx.cs" Inherits="XiaoWeiOnlineEducation.Webs.site.querylist" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .display_none {
            display: none;
        }

        @media only screen and (max-width: 600px) {
            .am-custom-sm-title {
                width: 100%;
                font-size: 19px;
            }

            .am-comment-main {
                margin-left: 0px;
            }

            .am-comment-custom-img {
                height: 41.8px;
                line-height: 41.8px;
                margin: 0 auto;
            }

                .am-comment-custom-img img {
                   display:none;
                }

                .am-comment-custom-img > svg {
                    fill: currentColor;
                    background: #f8f8f8;
                }

            .am-comment-main:before, .am-comment-main:after {
                border-color: none;
                border-style: none;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TabPage" runat="server">
    <h2 class="about-title about-color am-custom-sm-title">
        <asp:Literal ID="LitTitle" Text="江苏专转本考试（3年制）可报考院校及专业和录取投档线查询" runat="server"></asp:Literal></h2>
    <div class="am-u-lg-12 am-u-md-12 am-u-sm-12">
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <article class="am-comment">
                    <a href="#link-to-user-home" class="am-comment-custom-img">
                        <img data-src="holder.js/45x45?theme=sky&fg=ffffff&text=#<%#GetItemIndex(Container.ItemIndex,AspNetPager1) %>" class="am-comment-avatar am-img-responsive">
                    </a>
                    <div class="am-comment-main">
                        <header class="am-comment-hd">
                            <div class="am-comment-meta" style="font-size: 1.1em">
                                <%#string.Format("{0}&nbsp;（{1}）", Eval("SchoolName"),Convert.ToInt32(Eval("SchoolType"))==0?"公办本科":"民办本科") %>
                            </div>
                        </header>
                        <asp:Repeater runat="server" ID="rpquestionlist" DataSource='<%#Eval("ChildList") %>'>
                            <HeaderTemplate>
                                <div class="am-comment-bd">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <p>
                                    <div style="text-align: left;">
                                        <span class="am-badge am-badge-warning am-radius"><%#Container.ItemIndex+1 %></span>
                                        <%#Eval("SchoolMajorName") %>&nbsp;&nbsp;
                                    </div>
                                    <div style="padding-left: 15px; text-align: left;">
                                        <span>计划数：&nbsp;<%#string.Format("{0}&nbsp;&nbsp;{1}",Eval("PlanNumber"),Convert.ToInt32(Eval("ExtFlag"))==0?"":"（退役士兵）") %></span>

                                    </div>

                                    <blockquote class="am-serif">
                                        近三年投档分数：
                                     <ul class="am-avg-sm-1 am-avg-md-3 ">
                                         <li style="<%#CurrentEnable==true?"": " display: none;" %>"><%#GetBeforeScore(Convert.ToInt32(Eval("YearId")),Container.GetProperty("CastScore")) %> </li>
                                         <li><%#GetBeforeScore(Convert.ToInt32(Eval("YearId"))-1,Container.GetProperty("LastYearScore")) %> </li>
                                         <li><%#GetBeforeScore(Convert.ToInt32(Eval("YearId"))-2,Container.GetProperty("TwoYearsAgoScore")) %> </li>
                                         <li style="<%#CurrentEnable==true?"display: none;": "" %>"><%#GetBeforeScore(Convert.ToInt32(Eval("YearId"))-3,Container.GetProperty("ThreeYearsAgoScore")) %> </li>
                                     </ul>
                                    </blockquote>
                                </p>
                                <hr />

                            </ItemTemplate>
                            <FooterTemplate>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </article>
                <br />
            </ItemTemplate>
            <FooterTemplate>
                <%#GetEmptyRow(rptList) %>
            </FooterTemplate>
        </asp:Repeater>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pager_default" CurrentPageButtonClass="current"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging"
            PrevPageText="上一页" ShowPageIndexBox="Auto" SubmitButtonText="跳转" NumericButtonCount="5" PagingButtonSpacing="3px" ShowBoxThreshold="10">
        </webdiyer:AspNetPager>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/holder/2.9.4/holder.js"></script>
    <script>
        Holder.addTheme("bright", {
            bg: "white", fg: "gray", size: 12
        });
    </script>


</asp:Content>
