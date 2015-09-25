<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EFDemo.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="jquery-1.9.1.min.js"></script>
    <script src="template.js"></script>
    <script id="list" type="text/html">
        {{each datas as value i}}
            <tr>
                <td>{{value.id}}</td>
                <td>{{value.name}}</td>
            </tr>
        {{/each}}
    </script>
    <title></title>
</head>
<body>
    <div>
        <table id="Ttable">
        </table>
    </div>


    <script type="text/javascript">
        $(function () {
            $.ajax({
                //===请求地址===
                url: "List.ashx",
                //===请求设置===
                success: function (data) {//请求成功时的回调函数,success(data, textStatus, jqXHR)

                    var html = template('list', data);
                    document.getElementById('Ttable').innerHTML = html;
                },
                type: "post",//请求方法
                dataType: "json",//返回的数据类型
                cache: false,//是否使用缓存,(默认: true,dataType为script和jsonp时默认为false)  
                contentType: "application/x-www-form-urlencoded"//发送信息至服务器时内容编码类型,这里是默认值
            })
        });
    </script>
</body>
</html>
