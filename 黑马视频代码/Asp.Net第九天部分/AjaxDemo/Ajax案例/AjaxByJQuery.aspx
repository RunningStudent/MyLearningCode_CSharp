<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxByJQuery.aspx.cs" Inherits="Demo.AjaxByJQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Js/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnGetTime").click(function () {

           
                //用Get方法请求
                //参数
                //请求地址,[传输数据(可以是字符串,也可以是Json)],[回调函数],[回调数据类型,默认text类型]
                //$.post()同理
                $.get("ReturnTime.ashx", "username=stupid&psw=stupid2", function (data) {
                    alert(data);
                });
                
                
                //返回格式必须为JSON,后台数据要返回JSON否则data为Null,且方法体不执行
                //"{\"Date\":\""+DateTime.Now.ToString()+"\"}",这是个可行JSON ,{"Data":"2015..."},记得键也要双引号
                $.getJSON("ReturnTime.ashx", { JSON: '1' }, function (data) {
                    alert(data.Date);
                });
                

                $.ajax({
                    //===请求地址===
                    url: "ReturnTime.ashx",

                    //===请求设置===
                    data: {id:"12",JSON:"json"},//传输数据,可以是字符串,也可以是json
                    success:function(data){//请求成功时的回调函数,success(data, textStatus, jqXHR)
                        alert(data.Date);
                    },
                    type:"post",//请求方法
                    dataType:"json",//返回的数据类型
                    cache:flase,//是否使用缓存,(默认: true,dataType为script和jsonp时默认为false)  
                    contentType: "application/x-www-form-urlencoded"//发送信息至服务器时内容编码类型,这里是默认值
                })


            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="获得时间" id="btnGetTime" />
    </div>
    </form>
</body>
</html>
