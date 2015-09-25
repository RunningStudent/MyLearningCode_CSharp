<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CookieDemo.aspx.cs" Inherits="News.Web.黑马7Demo.CookieDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html runat="server">
<head>
    <meta charset="UTF-8">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CookieDemoContent/2/css/login-reg.css">
    <script type="text/javascript" src="CookieDemoContent/2/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        //使用的是淘二货的页面

        $(function () {
            var user = $('#username');
            var psw = $('#password');
            var phone = $('#phone');
            var submit = $('#login-submit');

            var phone_reg = /^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/;

            function checkStr(str) {
                // [\u4E00-\uFA29]|[\uE7C7-\uE7F3]汉字编码范围
                var re1 = new RegExp("^([\u4E00-\uFA29]+|[\uE7C7-\uE7F3]+|[a-zA-Z0-9])+$");
                if (!re1.test(str)) {
                    return false;
                }
                return true;
            }
            user.blur(function (event) {
                var str = $.trim($(this).val());
                if (str.length == 0) {

                    $('.demoForm').submit(function () {
                        return false;
                    })
                }
            });
            psw.blur(function (event) {
                var str = $(this).val();
                if (str.length < 6) {
                    $('.demoForm').submit(function () {
                        return false;
                    })
                }
            });

            submit.hover(function (event) {
                $(this).css({
                    cursor: 'pointer',
                    background: '#1276AA'
                });
            }, function () {
                $(this).css('background', '#2db3f8');
            });

            $('#newBtn').hover(function () {
                $(this).css({ background: '#508a23', cursor: 'pointer' })
            }, function () {
                $(this).css('background', '#63a72d')
            })
            $('#newText').blur(function () {
                if ($(this).val() == '' || !isEmail($(this).val())) {
                    $('#newBtn').click(function () {
                        return false
                    })
                }
            })
            $('#newBtn').click(function () {
                $('.newForm form').submit();
                $('.newForm').css('display', 'block')
            })

        })
        function isEmail(str) {
            var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/;
            return reg.test(str);
        }
      
    </script>
    <script type="text/javascript">
        function changeImage(img) {
            img.src = img.src + "?" + new Date().getTime();
        }
    </script>
</head>
<body>
    <form id="form2" runat="server">
    <div class="content">
        <div class="header">
            <a href="CookieDemoContent/2/index.jsp">
                <img src="CookieDemoContent/2/images/login-reg-logo.png">
            </a>
        </div>
        <div class="form">
            <img src="CookieDemoContent/2/images/login-reg-bg.png" id="form-bg">
            <div id="login-form">
                <form action="CookieDemoContent/2/login/loginAction_login.do" method="post" class="demoform">
                <p style="color: red">
                </p>
                <div class="user-logo">
                </div>
                <input type="text" name="account" placeholder="请输入你的用户名" autofocus required id="username" value="<%=UserName %>" />
                <div class="password-logo">
                </div>
                <input type="password" name="pwd" placeholder="请输入你的密码" required id="password">
                <div class="yzm-logo">
                </div>
                <input type="text" name="captcha" id="yzm">
                <img src="TestCodeHandler.ashx" onclick="changeImage(this)" alt="换一张"
                    style="cursor: hand">
                <p>
                    忘记密码？<a href="http://online.cumt.edu.cn/discuz/forum.php">找回密码>></a>
                </p>
                <input type="submit" value="登录" id="login-submit">
                </form>
                
            </div>
        </div>
    </div>
    <div class="footer">
        <p>
            2014&nbsp<a href="http://online.cumt.edu.cn/">学生在线</a> &nbsp&nbsp<a href="http://online.cumt.edu.cn/FlyingStudio2014">翔工作室</a>&nbsp版权所有
        </p>
    </div>
    </form>
</body>
</html>

<%=ScriptString %>
