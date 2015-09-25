<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="Demo.异步无刷新新闻列表分页.NewsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="http://localhost:38324/Js/jquery-1.7.1.js"></script>
    <title></title>
    <script type="text/javascript">
        $(function () {
            LoadNewsList();
            
        });

        function LoadNewsList(data) {
            $.getJSON("GetNewsList.ashx", data, function (data) {
                $("#newstbody").html("");
                for (var i in data.newsList) {
                    var str = "<tr>";
                    str += "<td>"+data.newsList[i].ID+"</td>";
                    str += "<td>" + data.newsList[i].title + "</td>";
                    str += "<td>" + data.newsList[i].people + "</td>";
                    str += "</tr>";
                    $("#newstbody").append(str);
                }
                $("#NavLinks").html(data.NavString);
                
                $(".pageLink").click(function () {
                    var href = $(this).attr("href");
                    var postData = href.substr(href.lastIndexOf("?") + 1);
                    LoadNewsList(postData);
                    return false;
                });
            });
        }

        function BindNavLink() {
            /// <summary>给导航链接添加点击事件</summary>
            

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <thead>
                <tr>
                    <th>编号</th>
                    <th>标题</th>
                    <th>创建人</th>
                </tr>
            </thead>
            <tbody id="newstbody">
                
            </tbody>
        </table>
    </div>
        <div id="NavLinks"></div>
    </form>
</body>
</html>
