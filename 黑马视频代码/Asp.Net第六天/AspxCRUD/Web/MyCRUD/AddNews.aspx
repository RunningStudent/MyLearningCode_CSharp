<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="News.Web.MyCRUD.AddNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
        <p >新闻标题</p>
        <input type="text" name="title" value=" " /><br />
        <p>正文</p>
        
        <textarea name="content" cols="20" ></textarea  ><br />
        <input type="submit">
    </div>
    </form>
</body>
</html>
