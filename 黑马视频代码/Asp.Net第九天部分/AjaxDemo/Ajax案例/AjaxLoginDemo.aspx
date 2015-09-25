<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxLoginDemo.aspx.cs"
    Inherits="Demo.AjaxLoginDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        window.onload = function () {
            var btnLogin = document.getElementById("btnLogin");
            btnLogin.onclick = function () {

                var username = document.getElementById("username");
                var psw = document.getElementById("psw");
                MyAjax("Post", "AJaxResponseTestDemo.ashx",
                 function (data) {
                     alert(data);
                 }, "username=" + username.value + "&psw=" + psw.value);

            };
        }



        function MyAjax(method, url, callback, parameter) {
            /// <summary>Ajax封装,实现对服务服务,并用回调函数处理ResponseText</summary>
            /// <param name="method" type="String">请求方法</param>
            /// <param name="url" type="String">请求地址</param>
            /// <param name="callback" type="function">回调函数</param>
            /// <param name="parameter" type="??">当请求方法为Post的时候用到</param>
            var xhr;
            if (XMLHttpRequest) {
                xhr = new XMLHttpRequest();
            } else {
                xhr = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xhr.open(method, url, true);

            if (method.toString().toUpperCase() == "POST") {
                xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
                xhr.send(parameter)
            } else {
                xhr.send();
            }

            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    callback(xhr.responseText); //用回调函数处理返回字符串
                }
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        用户名:<input type="text" id="username" /><br />
        密码:<input type="text" id="psw" /><br />
        <input type="submit" id="btnLogin" value="登入" />
    </div>
    </form>
</body>
</html>
