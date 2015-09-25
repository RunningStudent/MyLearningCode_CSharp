<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsShow.aspx.cs" Inherits="Demo.新闻列表与详情复习.NewsShow" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Js/jquery-easyui-1.4/themes/default/easyui.css" rel="stylesheet" />
    <link href="../Js/jquery-easyui-1.4/themes/icon.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Js/jquery-1.7.1.js"></script>
    <script src="../Js/jquery-easyui-1.4/jquery.easyui.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#detailDialog").css("display", "none");
            $("#editDialog").css("display", "none");
            LoadNews();
        });
        function LoadNews(postData) {
            /// <summary>页面加载时异步载入数据到表格中</summary>
            $.ajax({
                url: "GetNewsByJSON.ashx",
                type: "post",
                dataType: "json",
                data: postData,//发送pageIndex与pagaSize,后端有默认值,不怕这里为空
                success: function (data) {
                    $("#NewTable").html("");
                    //数据获取成功,载入到页面
                    for (var i in data.dataList) {
                        var str = "<tr>";
                        str += "<td>" + data.dataList[i].ID + "</td>";
                        str += "<td>" + data.dataList[i].title + "</td>";
                        str += "<td>" + data.dataList[i].people + "</td>";
                        str += "<td><a href='JavaScript:void(0)' newsId=" + data.dataList[i].ID + " >详细|修改</a>&nbsp;<a href='JavaScript:void(0)' newsId=" + data.dataList[i].ID + " >详情|修改2</a>&nbsp;<a href='JavaScript:void(0)' newsId=" + data.dataList[i].ID + ">删除</a></td>";
                        str += "</tr>";
                        $("#NewTable").append(str);
                    }
                    //分页导航栏HTML载入
                    $("#NavLink").html(data.navHtml);
                    BindingShowDetail();
                    BindingShowDetail2();
                    BindingDeleteClick();
                    BindingNavClick();
                }
            });
        }
        function ShowDialog() {
            /// <summary>弹出对话框</summary>
            $("#detailDialog").css("display", "block");
            $('#detailDialog').dialog({
                title: '对话框',
                width: 500,
                height: 500,
                modal: true,
                collapsible: true,
                minimizable: true,
                maximizable: true,
                resizable: true,
                toolbar: [{
                    text: 'Add',
                    iconCls: 'icon-add',
                    handler: function () {
                        alert('add');
                    }
                }, '-', {
                    text: '保存修改',
                    iconCls: 'icon-save',
                    handler: SaveData
                }],
                buttons: [{
                    text: 'Ok',
                    iconCls: 'icon-ok',
                    handler: function () {
                        alert('ok');
                    }
                }, {
                    text: 'Cancel',
                    handler: function () {
                        $('#detailDialog').dialog('close');
                    }
                }]
            });
        }
        function ShowDialog2() {
            /// <summary>展示第二个对话框</summary>
            $("#editDialog").css("display", "block");
            $('#editDialog').dialog({
                title: '对话框',
                width: 500,
                height: 500,
                modal: true,
                collapsible: true,
                minimizable: true,
                maximizable: true,
                resizable: true,
                toolbar: [{
                    text: 'Add',
                    iconCls: 'icon-add',
                    handler: function () {
                        alert('add');
                    }
                }, '-', {
                    text: '保存修改',
                    iconCls: 'icon-save',
                    handler: dialog2SaveClick
                }],
                buttons: [{
                    text: 'Ok',
                    iconCls: 'icon-ok',
                    handler: function () {
                        alert('ok');
                    }
                }, {
                    text: 'Cancel',
                    handler: function () {
                        $('#editDialog').dialog('close');
                    }
                }]
            });

        }
        function SaveData() {
            /// <summary>保存更新</summary>
            var newsData = $("#newsForm").serializeArray();
            $.post("SaveChange.ashx", newsData, function (data) {
                if (data == "ok") {
                    //登入成功关闭对话框,更新列表
                    $('#detailDialog').dialog('close');
                    LoadNews();
                } else {
                    alert("保存失败");
                }
            });
        }
        function LoadDataToDialog(id) {
            /// <summary>数据载入到对话框中</summary>
            $.ajax({
                url: "GetDataById.ashx",
                data: { "id": id },
                type: "post",
                dataType: "json",
                success: function (data) {
                    $("input[name='id']").val(id);
                    $("input[name='title']").val(data.title);
                    $("input[name='type']").val(data.type);
                    $("input[name='people']").val(data.people);
                    $("textarea").val(data.content);
                }
            });
        }
        function BindingShowDetail() {
            /// <summary>给每个链接添加点击事件,点击后显示对话框,并把数据载入到对话框</summary>
            $("#NewTable a:contains('详细|修改')").click(function () {
                ShowDialog();
                //数据载入
                var id = $(this).attr("newsId");
                LoadDataToDialog(id);
            });
        }
        function BindingShowDetail2() {
            /// <summary>给点击详情链接绑定,点击后修改iframe的scr属性</summary>
            $("#NewTable a:contains('详情|修改2')").click(function () {
                ShowDialog2();
                //获取id,用于修改iframe标签src属性
                var id = $(this).attr("newsId");
                $("#eidtFrame").attr("src", "EditFm.aspx?id=" + id);
            });
        }
        function BindingDeleteClick() {
            /// <summary>绑定点击删除数据</summary>
            $("#NewTable a:contains('删除')").click(function () {
                //把a标签Jq对象保存起来,似乎在confirm方法中this代表的不是a标签
                var a = $(this);
                //弹出确认提示框
                $.messager.confirm("提示", "确定删除?", function (r) {
                    //如果提示框选择确定
                    if (r) {
                        var id = a.attr("newsId");
                        //数据库中的删除
                        $.post("DeletNews.ashx", { "id": id }, function (data) {
                            if (data == "ok") {

                            } else {
                                alert("删除失败");
                            }
                        });
                        //页面上的删除
                        a.parent().parent().fadeOut(1000);
                    }
                });
            });
        }
        function BindingNavClick() {
            /// <summary>导航栏链接点击</summary>
            $(".pageLink").click(function () {
                var postData = $(this).attr("href").substr(1);
                //重新载入表格
                LoadNews(postData);
                return false;
            });
            //存在一个问题,当前页的那个链接它的class不是.pageLink,所以当前页的链接未能绑定连击事件
        }
        function dialog2SaveClick() {
            /// <summary>第二个对话框的保存</summary>

            //虽然数据展示是用iframe,但是保存点击还是应该是父容器干的
            var iframe = document.getElementById("eidtFrame");
            iframe.contentWindow.submitForm();
        }
        function afterEditSuccess() {
            /// <summary>给子容器调用的,关闭对话框并刷新表格</summary>
            $('#editDialog').dialog('close');
            LoadNews()
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <%--表格头,那么添加数据就应该在表格体--%>
                <thead>
                    <tr>
                        <td>编号</td>
                        <td>标题</td>
                        <td>创建人</td>
                        <td>操作</td>
                    </tr>
                </thead>
                <tbody id="NewTable">
                </tbody>
            </table>
        </div>
    </form>

    <%--弹出对话框--%>
    <div id="detailDialog">
        <h1>详情</h1>
        <form method="post" id="newsForm">
            <input type="hidden" name="id" value=" " />
            <table>
                <tr>
                    <td>标题</td>
                    <td>
                        <input type="text" name="title" value="" /></td>
                </tr>
                <tr>
                    <td>类型</td>
                    <td>
                        <input type="text" name="type" value="" />

                    </td>
                </tr>
                <tr>
                    <td>创建人</td>
                    <td>
                        <input type="text" name="people" value="" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">内容
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <textarea cols="20" name="content"></textarea>
                    </td>
                </tr>
            </table>
        </form>
    </div>

    <%--弹出对话框,div内用iframe标签--%>
    <div id="editDialog">
        <iframe id="eidtFrame" src="JavaScript:void(0)" height="100%" width="100%"></iframe>
    </div>


    <%--分页导航栏--%>
    <div id="NavLink">
    </div>
</body>
</html>
