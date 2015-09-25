<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFm.aspx.cs" Inherits="Demo.新闻列表与详情复习.EditFm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Js/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        function submitForm() {
            /// <summary>给父容器调用的异步保存数据</summary>
            var jsonData = $("#form1").serializeArray();
            $.post("EditFm.aspx", jsonData, function (data) {
                if (data=="ok") {
                    //保存成功后关闭父容器的对话框并刷新表格
                    //使用父容器的方法
                    window.parent.window.afterEditSuccess();
                } else {
                    alert("保存失败");
                }
            });
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>详情</h1>
            <input type="hidden" name="id" value="<%=modelMain.ID %>" />
            <table>
                <tr>
                    <td>标题</td>
                    <td>
                        <input type="text" name="title" value="<%=modelMain.title %>" /></td>
                </tr>
                <tr>
                    <td>类型</td>
                    <td>
                        <input type="text" name="type" value="<%=modelMain.type %>" />

                    </td>
                </tr>
                <tr>
                    <td>创建人</td>
                    <td>
                        <input type="text" name="people" value="<%=modelMain.people %>" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">内容
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <textarea cols="20" name="content"><%=modelMain.content %></textarea>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
