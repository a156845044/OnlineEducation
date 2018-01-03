/*!
* 调用 brilliantui.core.js?page=index
* index 表示为主页 缺省则表示为内页
* brilliantui core v1.0.0
* Date: 2014-10-21 11:01:41 
* Copyright 2013-2016 Brilliant
*/
var tabObject = null;
var tab = null;
var accordion = null;
var tabItems = [];
var lastScrollY = 0; //返回顶部
var timer; //记时器
var height = 0;
var accordionheightdiff = 35.5;//菜单高度差

/*=======获取QueryString的值===========*/
var _args, _path = (function (script, i, me) {
    var l = script.length;

    for (; i < l; i++) {
        me = !!document.querySelector ?
		    script[i].src : script[i].getAttribute('src', 4);

        if (me.substr(me.lastIndexOf('/')).indexOf('brilliantui') !== -1)
            break;
    }

    me = me.split('?'); _args = me[1];

    return me[0].substr(0, me[0].lastIndexOf('/') + 1);
})(document.getElementsByTagName('script'), 0)

var _getArgs = function (name) {
    if (_args) {
        var p = _args.split('&'), i = 0, l = p.length, a;
        for (; i < l; i++) {
            a = p[i].split('=');
            if (name === a[0]) return a[1];
        }
    }
    return null;
}

//去除字符串尾部空格或指定字符  
String.prototype.trimEnd = function (c) {
    if (c == null || c == "") {
        var str = this;
        var rg = /\s+/;
        var i = str.length;
        while (rg.test(str.charAt(--i)));
        return str.slice(0, i + 1);
    }
    else {
        var str = this;
        var rg = new RegExp(c);
        var i = str.length;
        while (rg.test(str.charAt(--i)));
        return str.slice(0, i + 1);
    }
};

//主函数
$(function () {

    if ((_getArgs("page") || "content") == "index") {////后台index
      
    }
    else if ((_getArgs("page") || "content") == "user") {//前台index
     
    }
    else if ((_getArgs("page") || "content") == "inside") {//内页
    
    }
});

/**
* 初始化菜单
*/
function initLayout() {
    // 页面布局
    $("#global_layout").ligerLayout({
        leftWidth: 200,
        height: '100%',
        heightDiff: 0,
        allowTopResize: false,
        allowBottomResize: false,
        allowLeftCollapse: true,
        allowRightResize: true,
        topHeight: 60,
        space: 0,
        bottomHeight: 24,
        onHeightChanged: f_heightChanged,
        onEndResize: function (parm, e) {
            tab.onResize();
        }
    });
    $(".l-layout-header-toggle").click(function () {
        tab.onResize();
    });
}

/**
* 初始化导航面板
*/
function initTab() {
    height = $(".l-layout-center").height();
    // Tab
    $("#framecenter").ligerTab({
        height: height,
        showSwitchInTab: true,
        showSwitch: true,
        onAfterAddTabItem: function (tabdata) {
            tabItems.push(tabdata);
        },
        onAfterRemoveTabItem: function (tabid) {
            for (var i = 0; i < tabItems.length; i++) {
                var o = tabItems[i];
                if (o.tabid == tabid) {
                    tabItems.splice(i, 1);
                    break;
                }
            }
        },
        onReload: function (tabdata) {
            var tabid = tabdata.tabid;
        }
    });



}

/**
* 初始化左边菜单
*/
function initMenu() {
    // 左边导航面板
    $("#global_left_nav").ligerAccordion({
        height: height - accordionheightdiff,
        changeHeightOnResize: true,
        speed: 400
    });

    $(".l-link").hover(function () {
        $(this).addClass("l-link-over");
    }, function () {
        $(this).removeClass("l-link-over");
    });
    accordion = $("#global_left_nav").ligerGetAccordionManager();
}

/**
* 初始化变量
*/
function initVariable() {
    tab = $("#framecenter").ligerGetTabManager();
    $("#pageloading_bg").hide();
    $("#pageloading").hide();
    var $link = $("a[href='#']");
    if ($link.size() > 0) {
        $.each($link, function () {
            $(this).attr("href", "javascript:void(0)");
        });
    }
}

/**
* 菜单高度变化时调用的函数
*/
function f_heightChanged(options) {
    if (tab) {
        tab.addHeight(options.diff);
    }
    if (accordion && options.middleHeight - accordionheightdiff > 0) {
        accordion.setHeight(options.middleHeight - accordionheightdiff);
    }
}

/**
* 添加Tab，可传3个参数
* @param tabid [String] 标签编号
* @param text [String] 选项卡显示文本
* @param url [String] 跳转地址
* @param iconcss [String] 样式
*/
function f_addTab(tabid, text, url, iconcss) {
    if (arguments.length == 4) {
        tab.addTabItem({
            tabid: tabid,
            text: text,
            url: url,
            iconcss: iconcss
        });
    } else {
        tab.addTabItem({
            tabid: tabid,
            text: text,
            url: url
        });
    }
}

/**
 * 重新加载Tab标签
 * @param tabid [String] 标签编号
 * @author dfq 2015-11-17
 */
function f_reloadTab(tabid) {
    tab.reload(tabid);
}

/**
 * 移除Tab标签
 * @param tabid 标签编号
 * @author dfq 2015-11-17
 */
function f_removeTab(tabid) {
    tab.removeTabItem(tabid);
}

/**
 * 移除当前所有Tab标签
 * @author dfq 2015-11-17
 */
function f_removeCurTab() {
    tab.removeSelectedTabItem();
}

/**
* 内页列表隔行变色
*/
function heightLight() {
    $(".msgtable tr:nth-child(odd)").addClass("tr_odd_bg");
    $(".msgtable tr").hover(function () {
        $(this).addClass("tr_hover_col");
    }, function () {
        $(this).removeClass("tr_hover_col");
    });
}

/**
* Tab控制函数（内页选项卡）
*/
function tabs(tabId, tabNum) {
    // 设置点击后的切换样式
    $(tabId + " .tab_nav li").removeClass("selected");
    $(tabId + " .tab_nav li").eq(tabNum).addClass("selected");
    // 根据参数决定显示内容
    $(tabId + " .tab_con").hide();
    $(tabId + " .tab_con").eq(tabNum).show();
}

/**
* Tab控制函数
*/
function tabs2(tabObj) {
    var tabNum = $(tabObj).parent().index();
    // 设置点击后的切换样式
    $(tabObj).parent().parent().find("li a").removeClass("selected");
    $(tabObj).addClass("selected");
    // 根据参数决定显示内容
    $(".tab-content").hide();
    $(".tab-content").eq(tabNum).show();
}

/**
* Tab控制函数2
* @author dfq 2015-12-23
*/
function initContentTab2() {
    var parentObj = $(".content-tab");
    //    var tabObj = $('<div class="tab-title"><span>' + parentObj.find("ul li a.selected").text() + '</span><i></i></div>');
    //  parentObj.children().children("ul").before(tabObj);
    parentObj.find("ul li a").click(function () {
        var tabNum = $(this).parent("li").index();
        //设置点击后的切换样式
        $(this).parent().parent().find("li a").removeClass("selected");
        $(this).addClass("selected");
        // tabObj.children("span").text($(this).text());
        //根据参数决定显示内容
        $(".tab-content").hide();
        $(".tab-content").eq(tabNum).show();
        //$(".page-footer").ruleLayoutFooter();
    });
}


/**
* LinkButton 阻塞询问函数(需要勾选)
* @param obj this
* @param objmsg String 提示内容 
* @param check boolean 是否验证复选框选中状态 
*/
function onlbtnConfrim(obj, objmsg, check) {
    //如果Enable为false
    var $obj = $(obj);
    if ($obj.hasClass('aspNetDisabled')) {
        return false;
    }
    var flag = false;
    var msg = "删除记录后不可恢复，您确定吗？";
    if (arguments.length >= 2) {
        msg = objmsg;
    }
    if (arguments.length == 3) {
        flag = check;
    }
    if (flag) {
        if ($(".checkall input:checked").size() < 1) {
            $.dialog.alert("请选中您要操作的记录！");
            return false;
        }
    }
    $.dialog.confirm(msg, function (result) {
        if (result) {
            window.location.href = $obj.attr("href");
        }
    }, "");
    return false;
}

/**
* Button 阻塞询问函数
* @param obj this
* @param objmsg String 提示内容 
*/
function onbtnConfrim(obj, objmsg) {
    var $obj = $(obj);
    if ($obj.hasClass('aspNetDisabled')) {
        return false;
    }
    var msg = "不再考虑考虑？您确定要继续吗？";
    if (arguments.length == 2) {
        msg = objmsg;
    }
    $.dialog.confirm(msg, function (result) {
        if (result) {
            __doPostBack($obj.attr("name"), '');
        }
    }, "");
    return false;
}

/**
* 自定义 阻塞询问函数
* @param obj this
* @param msg String 提示内容 
* @param calback function 执行函数 
*/
function doConfrim(obj, msg, calback) {
    var flag = false;
    if (arguments.length == 3) {
        flag = true;
    }
    $.dialog.confirm(msg, function (result) {
        if (result) {
            if (flag) {
                if (typeof (calback) == "function") {
                    calback();
                }
            }
            __doPostBack($(obj).attr("name"), '');
        }
    }, "");
    return false;
}

/**
* 自定义 执行__doPostBack
* @param obj this
*/
function doPostBack(obj) {
    __doPostBack($(obj).attr("name"), '');
}

/**
* 自定义 执行lbtn后台事件
* @param obj this
*/
function lbtndoPostBack(obj) {
    window.location.href = $(obj).attr("href");
}

/**
* 全选取消按钮函数
*/
function checkAll(chkobj) {
    if ($(chkobj).find("span b").text() == "全选") {
        $(chkobj).find("span b").text("取消");
        $(".checkall input").attr("checked", true);
    } else {
        $(chkobj).find("span b").text("全选");
        $(".checkall input").attr("checked", false);
    }
}

/**
* 只允许输入数字
*/
function checkNumber(e) {
    var key = e.which || e.keyCode;
    //允许的键值
    var codelist = [8, 13, 33, 34, 35, 36, 37, 38, 39, 40, 45, 46, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105];
    //if (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) {  //FF 
    //    if (!((e.which >= 48 && e.which <= 57) || (e.which >= 96 && e.which <= 105) || (e.which == 8) || (e.which == 46)))
    //        return false;
    //} else {
    //    if (!((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 8) || (event.keyCode == 46)))
    //        event.returnValue = false;
    //}
    if (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) {  //FF 

        //禁用组合键
        if (e.shiftKey && codelist.indexOf(key) > -1) {
            return false;
        }
        if (codelist.indexOf(key) <= -1) {
            return false;
        }

    } else {

        //检测是否支持indexOf
        if (!Array.prototype.indexOf) {
            Array.prototype.indexOf = function (value, from) {
                for (var i = 0; i < this.length; i++) {
                    if (this[i] == value) {
                        return i;
                    }
                }
                return -1;
            }
        }

        //禁用组合键
        if (e.shiftKey && (codelist.indexOf(key) > -1)) {
            event.returnValue = false;
            return false;
        }

        if (codelist.indexOf(key) <= -1) {
            event.returnValue = false;
            return false;
        }

    }
}

var succ = "Success";
var error = "Error";

/**
* 1.5秒钟自动关闭的提示
* @param msgcontant [String] 消息主体
* @param url [String] 跳转的链接地址（back 或 url链接）
* @param msgcss [String] 消息样式 (Success、Error)
* @param callback [Function] 回调函数
*/
function showTipMsg(msgcontant, url, msgcss, callback) {
    var iconurl = "";
    var argnum = arguments.length;
    switch (msgcss) {
        case "Success":
            iconurl = "32X32/succ.png";
            break;
        case "Error":
            iconurl = "32X32/fail.png";
            break;
        default:
            iconurl = "32X32/hits.png";
            break;
    }
    var reIcon = iconurl ? function () {
        this.DOM.icon[0].innerHTML = '<img src="' + this.config.path + 'skins/icons/' + iconurl + '" class="ui_icon_bg"/>';
        this.DOM.icon[0].style.display = '';
        if (callback) this.config.close = callback;
    } : function () {
        this.DOM.icon[0].style.display = 'none';
        if (callback) this.config.close = callback;
    };

    return lhgdialog({
        id: 'Tips',
        zIndex: lhgdialog.setting.zIndex,
        title: false,
        cancel: false,
        fixed: true,
        lock: false,
        resize: false,
        max: false,
        min: false,
        close: function () {
            if (url == "back") {
                history.back(-1);
            }
            if (url != "") {
                location.href = url;
            }
            if (url == "ExitLogin") {
                top.location.href = '../../Login.aspx';
            }
            //执行回调函数
            if (typeof (callback) == "function") callback();
        }
    })
	.content(msgcontant)
	.time(1.5, reIcon);
}

/**
* Dialog窗口提示
* @param msgtitle [String] 标题
* @param msgcontent [String] 内容
* @param url [String] 跳转的链接地址（back 或 url链接）
* @param msgcss [String] 消息样式 (Success、Error)
* @param callback [Function] 回调函数
*/
function showDialogMsg(msgtitle, msgcontent, url, msgcss, callback) {
    var iconurl = "";
    var argnum = arguments.length;
    switch (msgcss) {
        case "Success":
            iconurl = "success.gif";
            break;
        case "Error":
            iconurl = "error.gif";
            break;
        default:
            iconurl = "alert.gif";
            break;
    }
    var dialog = $.dialog({
        title: msgtitle,
        content: msgcontent,
        fixed: true,
        min: false,
        max: false,
        lock: true,
        icon: iconurl,
        ok: true,
        close: function () {
            if (url == "back") {
                history.back(-1);
            }
            if (url != "") {
                location.href = url;
            }
            if (url == "ExitLogin") {
                top.location.href = '../../Login.aspx';

            }
            //执行回调函数
            if (typeof (callback) == "function") callback();
        }
    });
}

/**
* 提示
* @param contant [String] 内容
* @param msgcss [String] 消息样式 (Success、Error)
* @param callback [Function] 回调函数
*/
function briAlert(contant, msgcss, callback) {
    showTipMsg(contant, "", msgcss, callback);
}
/**
* 回调函数
*/
function callitback(callback) {
    //执行回调函数
    if (typeof (callback) == "function") callback();

}

//初始化返回顶部
function initGoTopButton() {
    $("body").prepend(" <div id=\"gotop\" class=\"gotop\"><ul><li style=\"border: none;\"><a  class=\"sidetop\"  href=\"javascript:void(0);\" onfocus=\"this.blur()\" onclick=\"window.scrollTo(0,0);\"><div class=\"sidebox\"> <img src=\"../../Images/side_icon05.png\"  />返回顶部</div></a> </li></ul></div>");
    window.setInterval("gotop()", 1);

    $(".gotop ul li").hover(function () {
        $(this).find(".sidebox").stop().animate({ "width": "124px" }, 200).css({ "opacity": "1", "filter": "Alpha(opacity=100)", "background": "#89AEC7" })
    }, function () {
        $(this).find(".sidebox").stop().animate({ "width": "54px" }, 200).css({ "opacity": "0.8", "filter": "Alpha(opacity=80)", "background": "#919191" })
    });
}

//返回顶部
function gotop() {
    var diffY;
    try {
        if (document.documentElement && document.documentElement.scrollTop)
            diffY = document.documentElement.scrollTop;

        else if ($(document)) {
            diffY = $(document).scrollTop();
        }
        else { /*Netscape stuff*/ }
        percent = .1 * (diffY - lastScrollY);
        if (percent > 0) percent = Math.ceil(percent);
        else percent = Math.floor(percent);
        lastScrollY = lastScrollY + percent;
        if (lastScrollY < 100) {
            document.getElementById("gotop").style.display = "none";
        } else {
            document.getElementById("gotop").style.display = "block";
        }

    } catch (e) {

    }

}

/**
* @param mgr [Object] Tree管理器
* @param obj this 
*/
function TreeToggle(mgr, obj) {
    if ($(obj).find("span b").text() == "展开全部") {
        $(obj).find("span b").text("收起全部");
        mgr.expandAll();
    } else {
        $(obj).find("span b").text("展开全部");
        mgr.collapseAll();
    }
}

/**
* 添加行
* @param manager [Object] gird的操作对象
*/
function addRow(manager) {
    manager.addEditRow();
}

/**
* 删除行
* @param manager [Object] gird的操作对象
* @param rowid [int] 当前行索引
*/
function deleteRow(manager, rowid) {
    $.dialog.confirm("您确定要删除当前行吗？", function (result) {
        if (result) {
            manager.deleteRow(rowid);
            briAlert("删除成功！", succ);
        }
    }, "");
}

/**
* 删除选择行
* @param manager [Object] gird的操作对象
*/
function deleteRows(manager) {
    var nodes = manager.getSelectedRows();
    if (nodes == "") {
        $.dialog.alert("请选中要操作的列！");
        return false;
    }
    $.dialog.confirm("您确定要全部删除吗？", function (result) {
        if (result) {
            manager.deleteSelectedRow();
        }
    }, "");

}

/**
* 开始编辑行
* @param manager [Object] gird的操作对象
* @param rowid [int] 当前行索引
*/
function beginEdit(manager, rowid) {
    manager.beginEdit(rowid);
}

/**
* 取消编辑行
* @param manager [Object] gird的操作对象
* @param rowid [int] 当前行索引
*/
function cancelEdit(manager, rowid) {
    manager.cancelEdit(rowid);
}

/**
* 提交编辑行
* @param manager [Object] gird的操作对象
* @param rowid [int] 当前行索引
*/
function endEdit(manager, rowid) {
    manager.endEdit(rowid);
}

/**
* 删除LI元素
* @param obj [Object] this
*/
function del_DOM(obj) {
    var node = $(obj).parent(); //要删除的LI节点
    $.dialog.confirm("确定要删除吗？", function (result) {
        if (result) {
            node.remove(); //删除DOM元素
        }
    }, "");
}

/**
* 下载文件
* @param filepath [String] 地址
* @param fileName [String] 文件名
*/
function download(filepath, fileName) {
    $.download("../../Handler/Upload.ashx?action=onDownload", { "FilePath": filepath, "FileName": fileName }, "post");

}

/**
* 下载扩展
* @param url [String] 地址
* @param data [Object] JSON对象
* @param method [String] 'POST GET'
*/
jQuery.download = function (url, data, method) {
    if (url && data) {
        var inputs = "";
        for (var key in data) {
            inputs += '<input type="hidden" name="' + key + '" value="' + data[key] + '"/>';
        }
        jQuery('<form  action="' + url + '" method="' + (method || 'post') + '" >' + inputs + '<form/>').appendTo('body').submit().remove();
    };
};

/**
* 播放声音
*/
function play() {
    $(".player").remove();
    $('<embed class="player" src="../../Flash/ring.swf" height="0" width="0"></embed>').appendTo("body");
}

/**
* 右下角弹窗
* @param cmtitle [String] 标题
* @param cmcontant [String] 内容
* @param index [int] 索引
*/
function alertCustom(cmtitle, cmcontant, index) {
    return $.dialog.notice({
        id: 'Notice' + index,
        title: cmtitle,
        width: 220,  /*必须指定一个像素宽度值或者百分比，否则浏览器窗口改变可能导致lhgDialog收缩 */
        content: cmcontant,
        close: function () {
            runColseBack();

        }
    });
}

/**
* 回调函数 （覆盖调用）
*/
function runColseBack() {
}

/**
* 写入Cookie
* @param objName key
* @param objValue 值
* @param objHours cookie的销毁时间
*/
function addCookie(objName, objValue, objHours) {
    var str = objName + "=" + escape(objValue);
    if (objHours > 0) {//为0时不设定过期时间，浏览器关闭时cookie自动消失
        var date = new Date();
        var ms = objHours * 3600 * 1000;
        date.setTime(date.getTime() + ms);
        str += "; expires=" + date.toGMTString();
    }
    document.cookie = str;
}

/**
* 读Cookie 
* @param objName key
*/
function getCookie(objName) {//获取指定名称的cookie的值
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0] == objName) return unescape(temp[1]);
    }
    return "";
}

/*
* 删除Cookie
* @param objName key
*/
function delCookie(objName) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(objName);
    if (cval != null) {
        document.cookie = objName + "=" + cval + "; expires=" + exp.toGMTString();
    }
}

/**
* 获取子节点信息 （递归） 
* @param item [object] 当前结点
* @param name [String] cookie前缀名称
*/
function getChildNode(item, name) {
    var argnum = arguments.length; //获取当前传入参数的个数
    if (item.children != undefined) {
        $.each(item.children, function (i, child) {
            var temp = "";
            if (argnum == 2) {
                temp = getCookie(name + child.text);
            }
            else {
                temp = getCookie(child.text);
            }

            if (temp.length > 0) {
                if (child.id == $.trim(temp)) {
                    child.isexpand = true;
                }
            }
            getChildNode(child, name);
        });
    }
}

/**
* 重新组织记住用户Tree展开状态
* @param data [object] tree的JSON序列
* @param name [String] cookie前缀名称
*/
function initTreeStatus(data, name) {
    //如果当前参数为1
    if (arguments.length < 2) {
        name = "";
    }
    $.each(data, function (i, item) {
        var temp = getCookie(name + item.text);
        if (temp.length > 0) {
            if (item.id == $.trim(temp)) {
                item.isexpand = true;
            }
        }
        getChildNode(item, name);
    });
}

/**
* 获取当前页面参数值
* @param name url 参数名称
* @author dfq 2015-11-17
*/
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    var value = null;
    //if (r != null) return unescape(r[2]); return null;
    //utf-8 编码
    if (r != null) {
        try {
            value = decodeURI(r[2]);
        } catch (e) {
            value = unescape(r[2]);
        }
    }
    return value;
}

/**
* 页面重新定向
* @param title Tab标签名称
* @param url   url地址
* @param funcid url地址参数funcid,为空，自动获取当前url地址参数funcid 
* @param id 列表中的主键Id
* @author dfq 2015-11-17
*/
function redirect(title, url, funcid, id) {
    // var tabid = new Date().valueOf();
    title = title.replace(/\s/g, "");//去除空格
    var tabid = getFuncId();
    if (arguments.length == 3) {

        parent.f_addTab(funcid, title, getUrlStr(url, funcid));
    }
    if (arguments.length == 2) {
        tabid = tabid + title;
        parent.f_addTab(tabid, title, getUrlStr(url));
    }

    if (arguments.length == 4) {
        tabid = id + title;
        parent.f_addTab(tabid, title, getUrlStr(url));
    }
}

/**
* 获取url地址字符串
* @param url   url地址
* @param funcid url地址参数funcid,为空，自动获取当前url地址参数funcid 
* @author dfq 2015-11-17
*/
function getUrlStr(url, funcid) {
    var id = getFuncId();
    var moduleName = getQueryString("moduleName");
    if (arguments.length == 2) {
        id = funcid;
    }
    var urlInfo = url.split('?');
    var str = "";
    for (var i = 0; i < urlInfo.length; i++) {
        if (i == 0) {
            str = urlInfo[i] + "?funcid=" + id + "&moduleName=" + moduleName + "&";
        }
        else {
            str += urlInfo[i];
        }
    }
    return str;
}

/**
* 获取当前页面funcid
* @author dfq 2015-11-20
*/
function getFuncId() {
    return getQueryString("funcid");
}

/**
* 弹窗主函数
*/
$.dialog.notice = function (options) {
    var opts = options || {},
api, aConfig, hide, wrap, top,
duration = opts.duration || 800;
    var config = {
        left: '99.8%',
        top: '99.8%',
        fixed: true,
        drag: false,
        resize: false,
        init: function (here) {
            api = this;
            aConfig = api.config;
            wrap = api.DOM.wrap;
            top = parseInt(wrap[0].style.top);
            hide = top + wrap[0].offsetHeight;

            wrap.css('top', hide + 'px')
    .animate({ top: top + 'px' }, duration, function () {
        opts.init && opts.init.call(api, here);
    });
        },
        close: function (here) {
            wrap.animate({ top: hide + 'px' }, duration, function () {
                opts.close && opts.close.call(this, here);
                aConfig.close = $.noop;
                api.close();
            });

            return false;
        }
    };

    for (var i in opts) {
        if (config[i] === undefined) config[i] = opts[i];
    }

    return $.dialog(config);
};

/**
 * 密码询问
 * @param title String 标题
 * @param content String 提示内容
 * @param ispwd boolean 是否是密码
 * @param yes function 确认后执行函数
 */
$.dialog.briPrompt = function (title, content, ispwd, yes, value, parent) {
    value = value || '';
    var input;
    var inputType = "text";
    if (ispwd) {
        inputType = "password";
    }
    return lhgdialog({
        title: title,
        id: 'Prompt',
        zIndex: lhgdialog.setting.zIndex,
        icon: 'prompt.gif',
        fixed: true,
        lock: true,
        parent: parent || null,
        content: ['<div style="margin-bottom:5px;font-size:12px">', content,
				'</div>', '<div>', '<input value="', value,
				'" type="' + inputType + '" style="width:18em;padding:6px 4px" />', '</div>'].join(''),
        init: function () {
            input = this.DOM.content[0].getElementsByTagName('input')[0];
            input.select();
            input.focus();
        },
        ok: function (here) {
            return yes && yes.call(this, input.value, here);
        },
        cancel: true
    });

};

/**
* tooptip提示用法需要自定义标签属性 msg
*/
(function () {
    $.fn.brilliantipmsg = function (options) {
        var $obj = $(this);
        var opts = $.extend({}, $.fn.brilliantipmsg.defaults, options);
        var o = $.meta ? $.extend({}, opts, $obj.data()) : opts;
        var $tip = $('<div id="tip_box" class="l-verify-tip"><div id="tip_cont" style="word-break:break-all;" class="l-verify-tip-content"></div></div>');
        var $tipCont = $tip.find("#tip_cont");
        $tip.css({ width: options.width + "px" });
        $tipCont.css({ width: options.width + "px" });
        $obj.hover(function (e) {
            var offset = $(this).offset();
            var left = offset.left + $(this).width();
            var top = offset.top + $(this).height();
            var max = $(window).width() - 30;
            if (left + $tip.width() > max) {
                left = offset.left - $tip.width();
            }
            if (options.target == undefined) {
                options.target = o.target;
            }
            $tipCont.html(options.auto ? $(this).attr("" + options.target + "") : options.content);
            $tip.css({ left: left + "px", top: top + "px" });
            $tip.appendTo("body");
        }, function () {
            $tip.remove();
        });
        return this;
    };
    //默认参数对象
    $.fn.brilliantipmsg.defaults = {
        content: null,
        callback: null,
        width: 150,
        height: null,
        x: 0,
        y: 0,
        appendIdTo: null,       //保存ID到那一个对象(jQuery)(待移除)
        target: null,
        auto: null,             //是否自动模式，如果是，那么：鼠标经过时显示，移开时关闭,并且当content为空时自动读取attr[msg]
        target: 'msg',
        removeTitle: true

    };
})(jQuery);

/**
* dialog 抖动
*/
$.dialog.fn.shake = function () {
    var style = this.DOM.wrap[0].style,
        p = [4, 8, 4, 0, -4, -8, -4, 0],
        fx = function () {
            style.marginLeft = p.shift() + 'px';
            if (p.length <= 0) {
                style.marginLeft = 0;
                clearInterval(timerId);
            }
        };
    p = p.concat(p.concat(p));
    timerId = setInterval(fx, 13);
    return this;
};

/**
* Ajax 
*/
$.extend({
    action: function (options) {
        var defaults = { url: "", data: {}, dataType: "text", async: true, success: null };
        var option = $.extend({}, defaults, options);
        var url = $.getUrl(option.url);
        $.ajax({
            type: "POST",
            url: url,
            data: option.data,
            dataType: option.dataType,
            async: option.async,
            success: function (data) {
                if (option.success) {
                    option.success(data);
                }
            }
        });
    },
    getUrl: function (url) {
        var strs = url.split('/');
        var url = "../../Handler/" + strs[0] + ".ashx?action=" + strs[1] + "&random=" + Math.random();
        return url;
    }
});

/**
* 表单序列化插件
*/
(function () {
    $.fn.serialize = function (options) {
        var $obj = $(this);
        var opts = $.extend({}, $.fn.serialize.defaults, options);
        var o = $.meta ? $.extend({}, opts, $obj.data()) : opts;

        var model = {};//定义空实体，用于接收数据
        //  var entity = "";
        //表单元素
        var $elms = $obj.find("input[type='text'],input[type='hidden'],textarea,select");
        if ($elms.size() > 0) {
            //dfq 2016.12.28，注释
            //  entity += _setField($elms);

            //dfq 2016.12.28， 字符串形式的容易出现问题，引号、换行等
            model = _getFieldItem($elms);
        }


        //单选按钮
        var $radio = $obj.find("input[type='radio']");
        if ($radio.size() > 0) {
            var nameTemp = "";
            $.each($radio, function () {
                var $item = $(this);
                var name = $item.attr("name");
                if (name != nameTemp) {
                    nameTemp = name;
                    var $checkedItem = $obj.find("input[name='" + name + "']:checked");
                    var field = $checkedItem.parent("span").attr("data-field");
                    var value = $checkedItem.next().text();
                    //dfq 2016.12.28，注释
                    // entity += '"' + field + '"' + ':"' + value + '",';
                    //dfq 2016.12.28， 字符串形式的容易出现问题，引号、换行等
                    model["" + field + ""] = value;
                }
            });
        }

        //复选按钮
        //未实现

        //dfq 2016.12.28，注释 start
        //  entity = entity.substring(0, entity.length - 1);
        //  entity = "{" + entity + "}";
        // var data = JSON.parse(entity);
        //dfq 2016.12.28，注释 end

        //添加事件
        if (o.onAdd != null) {
            // o.onAdd(data);
            // entity = JSON.stringify(data);
            o.onAdd(model);
        }

        if (o.clear) {
            _clear($obj);
        }

        if (o.debug) {
            //  console.log(entity);
            console.log(model);
        }
        switch (o.dataType) {
            case "text":
                // return entity;
                return JSON.stringify(model);
            case "json":
                //  return data;
                return model;
            default:
                // return entity;
                return JSON.stringify(model);//默认以text形式返回
        }
    };

    //默认参数
    $.fn.serialize.defaults = {
        dataType: "text",
        clear: false,
        debug: false,
        onAdd: null
    };

    //清空表单
    $.fn.clearForm = function () {
        var $obj = $(this);
        _clear($obj);
    };

    //反序列化
    $.fn.deserialize = function (options) {
        var $obj = $(this);
        var $elms = $obj.find("input[type='text'],input[type='hidden'],textarea,select,span");
        var opts = $.extend({}, $.fn.deserialize.defaults, options);
        var o = $.meta ? $.extend({}, opts, $obj.data()) : opts;
        if (o.data == null) throw "数据源不能为空";
        var data = _isJson(o.data) ? o.data : JSON.parse(o.data);
        var $item, value = null;
        var attr, key = "";
        var attrs, dataField = [];
        $.each($elms, function () {
            $item = $(this);
            attr = $item.attr("data-field");
            if (typeof (attr) == "undefined" || attr == "") return true;
            try {
                attrs = attr.split(",");
                dataField = attrs[0].split("|");
                key = dataField[0];
                value = _getValue(data, key);

                if ($item.is("span")) {
                    $item.text(value);
                }
                else {
                    $item.val(value);
                }
            }
            catch (e) {

            }
        });
    };

    //默认参数
    $.fn.deserialize.defaults = {
        data: null
    };

    //获取json对象中键对应的值
    function _getValue(data, key) {
        var val;
        $.each(data, function (field, value) {
            if (key == field) {
                val = value;
                return false;
            }
        });
        return val;
    }

    //判定对象是否为json对象或json对象数组
    function _isJson(obj) {
        if (typeof (obj) == "object") {
            var type = Object.prototype.toString.call(obj).toLowerCase();
            if (type == "[object object]" || type == "[object array]") {
                return true;
            }
        }
        return false;
    }

    //清空表单
    function _clear(objects) {
        var $input = objects.find("input[type='text'],textarea");
        $.each($input, function () {
            $(this).val("");
        });
        var $select = objects.find("select");
        $.each($select, function () {
            var $item = $(this);
            $item.val($item.find("option").eq(0).attr("value"));
        });
    }

    //设置字段
    function _setField(objects) {
        var $item;
        var field, fieldType, value, attr, str = "";
        var attrs, dataField = [];
        var currentItem = [];
        $.each(objects, function () {
            $item = $(this);
            value = $item.val();
            attr = $item.attr("data-field");

            //text,select-one,hidden,textarea
            // var domtype = document.getElementById($item.attr("id")).type;//获取dom类别

            if (typeof (attr) == "undefined" || attr == "") return true; //增加为空判定
            //异常处理：防止索引取不到而引发异常
            try {
                attrs = attr.split(",");
                for (var i = 0; i < attrs.length; i++) {
                    //如果存在两个属性(则为下拉框)
                    if (i == 1) { value = $item.find("option:selected").text(); } //取下拉框选中的文本

                    dataField = attrs[i].split("|"); //分割字段，获取到字段名称和字段类型

                    field = dataField[0]; //字段名称
                    fieldType = dataField.length > 1 ? dataField[1] : "string"; //如果有字段类型，则返回字段类型，否则返回默认类型
                    value = _getFieldValue(fieldType, value);
                    str += '"' + field + '":' + value + ',';
                    currentItem["" + field + ""] = value;
                }
            }
            catch (e) { }
        });
        console.log(currentItem);
        return str;
    };

    //获取最终Item json dfq 2016.12.28
    function _getFieldItem(objects) {
        var $item;
        var field, fieldType, value, attr;
        var attrs, dataField = [];
        var currentItem = {};
        $.each(objects, function () {
            $item = $(this);
            value = $item.val();
            attr = $item.attr("data-field");
            if (typeof (attr) == "undefined" || attr == "") return true; //增加为空判定
            //异常处理：防止索引取不到而引发异常
            try {
                attrs = attr.split(",");
                for (var i = 0; i < attrs.length; i++) {
                    //如果存在两个属性(则为下拉框)
                    if (i == 1) { value = $item.find("option:selected").text(); } //取下拉框选中的文本

                    dataField = attrs[i].split("|"); //分割字段，获取到字段名称和字段类型

                    field = dataField[0]; //字段名称
                    fieldType = dataField.length > 1 ? dataField[1] : "string"; //如果有字段类型，则返回字段类型，否则返回默认类型
                    value = _getFieldItemValue(fieldType, value);
                    currentItem["" + field + ""] = value;
                }
            }
            catch (e) { }
        });
        // console.log(currentItem);
        return currentItem;
    }

    //获取字段的值
    function _getFieldValue(type, value) {
        switch (type) {
            case "number":
                return value;
            case "string":
                return '"' + value + '"';
            default:
                return '"' + value + '"';
        }
    };

    //获取字段的值 dfq 2016.12.28
    function _getFieldItemValue(type, value) {
        switch (type) {
            case "number":
                return value - 0;
            case "string":
                return value;
            default:
                return value;
        }
    };
})(jQuery);

/**
* 内页调用的推送方法
*/
function briPush() {
    parent.index_push();
}

/**
* 转换金额
* @param num [float] 待转换金额
*/
function formatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3) ; i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' +
        num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + num + '.' + cents);
}

/**
* 从json列表中获取实体
* @author dfq 2016-06-07
*/
function getModel(data, key, value) {
    var json = {};
    $.each(data, function (i, item) {
        if (item[key] == value) {
            json = item;
        }
    });
    return json;
}

/**
* 登出
*/
function logout() {
    top.location.href = '../../Login.aspx';
}

/*
* 初始化悬浮工具条
*/
function initSideToolbar() {
    $(".side-toolbar ul li").hover(function () {
        $(this).find(".sidebox").stop().animate({ "width": "150px" }, 200).css({ "opacity": "1", "filter": "Alpha(opacity=100)", "background": "#89AEC7" })
    }, function () {
        $(this).find(".sidebox").stop().animate({ "width": "54px" }, 200).css({ "opacity": "0.8", "filter": "Alpha(opacity=80)", "background": "#7A6E6E" })
    });
}

/*
* 初始化悬浮工具条
* @param index [int] 索引
* @author dfq 2016-11-01
*/
function gethlgDialogMgr(index) {
    return lhgdialog.list['Notice' + index];
}

/**
* 关闭所有弹窗
*/
function closeAllDialog() {
    var list = $.dialog.list;
    for (var i in list) {
        list[i].close();
    }
}

/**
*两个浮点数求和
* @num1 数值1
* @num2 数值2
* @return 和
*@author dfq 2017.03.16
*/
function accAdd(num1, num2) {
    var r1, r2, m;
    try {
        r1 = num1.toString().split('.')[1].length;
    } catch (e) {
        r1 = 0;
    }
    try {
        r2 = num2.toString().split('.')[1].length;
    } catch (e) {
        r2 = 0;
    }
    m = Math.pow(10, Math.max(r1, r2));
    return Math.round(num1 * m + num2 * m) / m;
}


/**
* 两个浮点数相减
* @num1 被减数
* @num2 减数
* @digits  保留小数位（ 可为空 ）
* @return 差
**@author dfq 2017.03.16
*/
function accSub(num1, num2, digits) {
    var r1, r2, m;
    try {
        r1 = num1.toString().split('.')[1].length;
    } catch (e) {
        r1 = 0;
    }
    try {
        r2 = num2.toString().split('.')[1].length;
    } catch (e) {
        r2 = 0;
    }
    m = Math.pow(10, Math.max(r1, r2));
    n = (r1 >= r2) ? r1 : r2;
    if (n > 15) {
        n = 15;
    }

    if (arguments.length >= 3) {
        n = digits;
    }

    return (Math.round(num1 * m - num2 * m) / m).toFixed(n);
}

/**
 *两个浮点数两数相除
 * @num1 被除数
 * @num2 除数
 * @return 商
 **@author dfq 2017.03.16
 */
function accDiv(num1, num2) {
    var t1, t2, r1, r2;
    try {
        t1 = num1.toString().split('.')[1].length;
    } catch (e) {
        t1 = 0;
    }
    try {
        t2 = num2.toString().split('.')[1].length;
    } catch (e) {
        t2 = 0;
    }
    r1 = Number(num1.toString().replace(".", ""));
    r2 = Number(num2.toString().replace(".", ""));
    return (r1 / r2) * Math.pow(10, t2 - t1);
}

/**
*   两个浮点数两数乘
* @num1 被乘数
* @num2 乘数
* @return 乘积
*@author dfq 2017.03.16
*/
function accMul(num1, num2) {
    var m = 0, s1 = num1.toString(), s2 = num2.toString();
    try { m += s1.split('.')[1].length } catch (e) { };
    try { m += s2.split('.')[1].length } catch (e) { };
    return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m);
}

/**
* 获取实体拷贝
* @param model 待拷贝的实体
* @param exceptprop 除了哪儿些属性（可为空）
* @author dfq 2017.03.16
*/
function getCopyNewEntity(model, exceptprop) {

    var flag = false;
    var props;
    if (arguments.length > 1) {
        flag = true;
        props = exceptprop.split(',');
    }
    var entity = {};
    for (var prop in model) {
        if (flag) {
            if (props.indexOf(prop) > -1) {
                continue;
            }
        }
        entity[prop] = model[prop];

    }
    return entity;
}

/**
* 追加到页面
* @data  待添加的实体
* @divid 待追加div的Id
* @distinctprop  去重属性
* @displayprop   显示的属性
* @inputname    input的name属性 （可缺省，默认hiddenctrl）
* @return 
* @author dfq 2017.05.08
*/
function appendULTarget(data, divid, distinctprop, displayprop, inputname) {
    var distinct = false;
    var li = "";
    if (arguments.length >= 4) {
        li = "<li id=\"" + data[distinctprop] + "\">";
        distinct = true;
    }
    else {
        li = "<li>";
    }

    var tempName = "hiddenctrl";
    if (inputname != undefined && inputname != "") {
        tempName = inputname;
    }

    for (var prop in data) {
        li += "<input  type=\"hidden\" data-field=\"" + prop + "\" name=\"" + tempName + "\" value=\"" + data[prop] + "\" />";
    }
    li += "<b class=\"close\" title=\"删除\" onclick=\"del_DOM(this);\"></b>";
    li += "<span class=\"title\">";

    li += data[displayprop];

    li += "</span>";
    li += "</li>";
    if (distinct) {
        if ($("#" + data[distinctprop]).length <= 0) {
            $("#" + divid + " ul").append(li);
        }
    }
    else {
        $("#" + divid + " ul").append(li);
    }
}


/**
 * 获取追加内容数据列表
 * @param divid div的id 
 * @param property input的自定义属性名称 默认为 data-field 可缺省
 * @return data
 * @author dfq 2017.04.07
 */
function getLiValueList(divid, property) {
    var datafield = "data-field";//隐藏域自定义属性
    if (arguments.length > 1) {
        datafield = property;
    }
    var data = [];
    var item = {};
    $("#" + divid + " ul li").each(function () {
        var $this = $(this);
        if ($.trim($this.html()) != "") {
            var inputlist = $this.children("input[type=\"hidden\"]");//获取li下所有input的集合
            var prop = "";//自定义属性值
            //遍历所有input
            inputlist.each(function () {
                var $current_input = $(this); //获取当前隐藏控件
                prop = $current_input.attr(datafield);//获取属性
                if (prop != undefined) {
                    prop = $.trim(prop);
                    item[prop] = $current_input.val();
                }
            });
            data.push(item);
            item = {};
        }
    });
    return data;
}

/**
* 拷贝两个实体相同属性部分
* @param byEntity 被拷贝的实体
* @param toEntity 要拷贝的实体
* @author dfq 2017.04.17
*/
function getEntityCopy(byEntity, toEntity) {
    for (var prop in byEntity) {
        if (toEntity.hasOwnProperty(prop)) {
            toEntity[prop] = byEntity[prop];
        }
    }
    return toEntity;
}

/**
* 关闭弹窗
* @id 指定的Id名称
* @author dfq 2017.05.05
*/
function dialogclose(id) {
    $.ligerDialog.hide(id);
}

/**
*多个浮点数求和
* @param 可变长参数
*@author dfq 2017.05.05
*/
function accMultiAdd() {
    var total = 0.0;
    for (var i = 0; i < arguments.length; i++) {
        total = accAdd(total, arguments[i]);
    }
    return total;
}

