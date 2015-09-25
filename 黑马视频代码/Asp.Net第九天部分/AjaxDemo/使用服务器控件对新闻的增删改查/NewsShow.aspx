<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsShow.aspx.cs" Inherits="Demo.使用服务器控件对新闻的增删改查.NewsShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <%--头模板--%>
            <HeaderTemplate>
                <table>
                    <tbody>
                        <tr>
                            <th>编号</th>
                            <th>标题</th>
                            <th>创建人</th>
                            <th>操作</th>
                        </tr>
                    </tbody>
            </HeaderTemplate>

            <%--各项间分隔符的模板--%>
            <SeparatorTemplate>
            </SeparatorTemplate>


            <%--项目模板,这里的数据会循环的显示,这里相当于写了一个循环--%>
            <ItemTemplate>
                <tr>
                    <%--Eval仅仅是输出--%>
                    <%--Bind是双向绑定--%>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("people") %></td>
                    <td><%# Eval("title") %></td>
                    <td>
                        <%--点击事件不能再设计器中直接给按钮设置--%>
                        <%--必须发生在Repeater的ItemCommand事件中--%>
                        <%--于是给按钮添加CommandName,区别按钮与其他按钮或空间的事件--%>
                        <%--用CommandArgument来保存事件触发时用得到的数据--%>
                        <asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' />
                        <asp:Button ID="btnEdit" runat="server" Text="编辑"  CommandName="Edit" CommandArgument='<%#Eval("ID")%>' />
                        &nbsp;
                        <a href="Detail.aspx?id=<%#Eval("ID") %>">详情</a>
                    </td>
                </tr>
            </ItemTemplate>


            <%--配合ItemTemplate,隔行地显示,可以做表格隔行不同色的效果--%>
            <%--它的存在会多取ItemTemplate一半的数据,所以如果这里不输出,将有一半数据不显示--%>
            <AlternatingItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("people") %></td>
                    <td><%# Eval("title") %></td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' />
                        <asp:Button ID="btnEdit" runat="server" Text="编辑"  CommandName="Edit" CommandArgument='<%#Eval("ID")%>' />
                        &nbsp;
                        <a href="Detail.aspx?id=<%#Eval("ID") %>">详情</a>
                    </td>
                </tr>
            </AlternatingItemTemplate>


            <%--脚模板--%>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Button ID="btnAddNews" runat="server" Text="添加" OnClick="btnAddNews_Click" />

        <%--这里默认使用Main业务对象的GetList方法,且查询条件是空--%>
        <%--现在要做分页效果,下面的数据源则不适合,即使修改参数值也很麻烦,所以不用这个数据源--%>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetList" TypeName="News.BLL.HKSJ_Main">
            <SelectParameters>
                <asp:Parameter DefaultValue=" " Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <div>
            <asp:Literal ID="NavString" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
