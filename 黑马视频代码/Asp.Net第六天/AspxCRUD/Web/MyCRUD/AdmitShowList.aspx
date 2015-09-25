<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdmitShowList.aspx.cs"
    Inherits="News.Web.MyCRUD.AdmitShowList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../MyContent/style/tableStyle.css" rel="stylesheet" type="text/css" />
    <link href="../MyContent/style/NavPager.css" rel="stylesheet" type="text/css" />
    <script src="../Script/jquery-1.7.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">
        $(function () {
            $(".confirmDelete").click(function () {
                return confirm("确认删除?");
            })

        })
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <th>
                    编号
                </th>
                <th>
                    标题
                </th>
                <th>
                    日期
                </th>
                <th>
                    创建人
                </th>
                <th>
                    操作
                </th>
            </tr>
            <% foreach (var item in NewsList)
               {%>
            <tr>
                <td>
                    <%= item.ID %>
                </td>
                <td>
                    <%=item.title %>
                </td>
                <td>
                    <%=item.Date %>
                </td>
                <td>
                    <%=item.people %>
                </td>
                <td>
                    <a href="EditFrom.aspx?id=<%=item.ID %>">编辑</a>
                    <a class="confirmDelete" href="DeletFrom.aspx?id=<%=item.ID %>">删除</a>
                </td>
            </tr>
            <%}%>
        </table>
        <!-- 分页 -->
            <!-- 粗糙版 -->
            <%for (int i=1;i<=pageCount;i++)
            {%>
                <a href="AdmitShowList.aspx?pageIndex=<%=i %>"><%=i %></a>
            <%}%>

            <br />
        <!-- 精细版 -->
        <div class="paginator"     >
        <%=PageNav %>
        </div>
            
    </div>
    </form>
</body>
</html>
