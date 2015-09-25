<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxDemo.aspx.cs" Inherits="Demo.AjaxDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        onload = function () {
            var p = document.getElementById("ajaxP");
            var btn = document.getElementById("GetServiceTime");

            //按钮点击
            btn.onclick = function () {

                //创建Ajax对象
                var xhr;
                //浏览器适配
                if (XMLHttpRequest) {
                    xhr = new XMLHttpRequest();
                } else {
                    //IE5,6创建方法
                    xhr = new ActiveXObject("Microsoft.XMLHTTP");
                }

                //请求方法  请求地址 是否异步 用户名 密码
                //用UI线程去请求
                //Get请求的参数直接写在地址中
                xhr.open("Get", "ReturnTime.ashx", true);

                //========如果是Post还要设置数据传输类型,因为要传输的数据类型有很多种=========
                //xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
                //========================================================================

                //发送请求,如果是Post方法,括号中写参数
                xhr.send();

                //异步监听
                xhr.onreadystatechange = function () {
                    /*
                    0: 请求未初始化 
                    1: 服务器连接已建立 
                    2: 请求已接收 
                    3: 请求处理中 
                    4: 请求已完成，且响应已就绪 
                    */


                    //如果请求结束,而且状态码为200
                    if (xhr.readyState == 4 && xhr.status == 200) {
                        alert(xhr.responseText);
                    }
                }
            }

        };
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p id="ajaxP">....</p>
        <!--这里是button不是submit-->
        <input type="button"  value="回传时间" id="GetServiceTime"/>
    </div>
    </form>
</body>
</html>
