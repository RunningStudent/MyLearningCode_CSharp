<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditNews.aspx.cs" Inherits="Demo.使用服务器控件对新闻的增删改查.EditNews" ValidateRequest="false" %>

<%--ValidateRequest设置为false,使得数据发送到后台不检查--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="kindeditor-4.0.5/kindeditor-min.js"></script>
    <script src="kindeditor-4.0.5/lang/zh_CN.js"></script>
    <title></title>
    <script>
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('textarea[name="txtBoxContent"]', {
                allowFileManager: false,//true时显示文件上传按钮。
                resizeType: 1,
                uploadJson: 'kindeditor-4.0.5/asp.net/upload_json.ashx',//指定上传文件的服务器端程序。
            fileManagerJson: 'kindeditor-4.0.5/asp.net/file_manager_json.ashx',//指定浏览远程图片的服务器端程序。
                allowPreviewEmoticons: false,
                allowImageUpload: true,//true时显示图片上传按钮。
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--添加新闻页面用kindeditor编辑器--%>

            <table>
                <tr>
                    <td>标题</td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>创建人</td>
                    <td>
                        <asp:TextBox ID="txtPeople" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">内容</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="txtBoxContent" runat="server" Height="316px" TextMode="MultiLine" Width="415px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
