<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="Demo.使用服务器控件对新闻的增删改查.AddNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="ubbeditor/ubbEditor.js"></script>
    <title></title>
    <script>
        //UBBEditor对象必须为全局变量
        var nEditor;
        window.onload = function () {
            nEditor = new ubbEditor('<%=this.txtBoxContent.ClientID%>');
            nEditor.tLang = 'zh-cn';
            nEditor.tInit('nEditor', 'ubbeditor/');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--添加新闻页面用UBB编辑器--%>
            <%--测试发现,在编辑器中写<p>还会报错--%>
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
        <p>
            <asp:Button ID="btnAddNews" runat="server" OnClick="btnAddNews_Click" Text="添加" />
        </p>
    </form>
</body>

</html>
