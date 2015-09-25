<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFrom.aspx.cs" Inherits="News.Web.MyCRUD.EditFrom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        编号<br /><lable name="id"><%=newsDeatail.ID %></lable><br />
        标题<br /><input type="text" name="title" value="<%=newsDeatail.title%>" /><br />
         创建人<br /><input type="text" name="people" value="<%=newsDeatail.people %>" /> <br />
        内容<br /><textarea name="content" rows=20><%=newsDeatail.content %></textarea><br />
       <input type="submit">
    </div>
    </form>
</body>
</html>
