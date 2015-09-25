<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminForm.aspx.cs" Inherits="News.Web.MyCRUD.AdminForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Script/jquery-1.7.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //为每个导航栏中的a标签添加点击事件
            $("#left_bar a").click(function () {
                var href = $(this).attr("href");
                $("iframe").attr("src", href);
                return false;
            })
        })
    </script>
    <style type="text/css">
        *
        {
            margin:0px;
        }
        #header
        {
            height: 150px;
            border: 1px solid red;
        }
        
        #content
        {
            border: 1px solid blue;
            height: 500px;
            margin-left: 205px;
        }
        #left_bar
        {
            text-align:center;
            width: 200px;
            height: 500px;
            float: left;
            border: 1px solid yellow;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
    头
    </div>
    <div id="main">
        <div id="left_bar">
            <!-- p标签帮助换行 -->
            <p><a href="AddNews.aspx">添加新闻</a></p>
            <p><a href="ShowListForm.aspx">新闻页面</a></p>
            <p><a href="AdmitShowList.aspx">新闻编辑</a></p>
        </div>
        <div id="content">
            <iframe id="contentframe" src="" width="100%" height="100%" ></iframe>
        </div>
    </div>
    </form>
</body>
</html>
