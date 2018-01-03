/*!
* 用户公共方法
*/

/**
* @param userId String 用户编号
* 验证密码 
*/
function checkPwd(userId, pwd) {
    var flag = false;
    $.action({
        url: "User/CheckPwd",
        dataType: "json",
        async: false,
        data: {
            "userId": userId,
            "pwd": pwd
        },
        success: function (data) {
            if (data.code == 1) {//密码验证成功
                flag = true;
            } else {
                flag = false;
            }
        },
        error: function () {
           $.dialog.alert("error");
        }

    });
    return flag;
}

/**
* @param func 执行函数
* @param userId String 用户编号
* 验证密码 弹出层
*/
function verifyPwd(func, userId) {
    $.dialog.briPrompt("密码验证", "此操作涉及基础数据，要求验证您的登录密码！", true, function (data) {
        var flag = checkPwd(userId, data);
        if (flag) {//验证成功
            // 执行函数
            if (typeof (func) == "function")
                func();
        }
        else {
            $.dialog.alert("密码输入有误，请重新验证！");
        }

    }, "");
}