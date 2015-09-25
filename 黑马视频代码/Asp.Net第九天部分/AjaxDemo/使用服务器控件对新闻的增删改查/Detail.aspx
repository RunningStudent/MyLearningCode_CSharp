<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Demo.使用服务器控件对新闻的增删改查.Detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>编号</td>
                    <td>
                        <asp:Label ID="lbID" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>发布人</td>
                    <td>
                        <asp:Literal ID="ltPeople" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">内容</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Literal ID="ltContent" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
