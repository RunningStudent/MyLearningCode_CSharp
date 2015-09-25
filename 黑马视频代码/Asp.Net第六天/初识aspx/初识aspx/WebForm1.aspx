
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="初识aspx.WebForm1" %>
<!-- 该页面最终会编译成一个类 -->
<!-- 该类继承自初识aspx.WebForm1类 -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- 这里相当于页面模板 -->
<!-- 访问该页面时,会反射出一个页面类型 -->
<!-- 再执行方法 -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%= this.TestPrototype%>
    </div>
    </form>
</body>
</html>
