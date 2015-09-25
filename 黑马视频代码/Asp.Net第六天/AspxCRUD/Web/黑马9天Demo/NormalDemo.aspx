<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NormalDemo.aspx.cs" Inherits="News.Web.黑马9天Demo.NormalDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--一个控件,作用数能原封不动把字符串输出到页面-->
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        
        <!--容器控件-->
        <asp:Panel ID="Panel1" runat="server">
            <!--元素嵌套-->
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </asp:Panel>

        <h2>
        输出当前页面类的程序集位置
        <%=System.Reflection.Assembly.GetExecutingAssembly().Location %>
        </h2>

        <!--10个P标签-->
        <%for(int i=0;i<10;i++ )
        {%>
          <p><%=i%></p>
        <%} %>
    </div>
    </form>
</body>
</html>
