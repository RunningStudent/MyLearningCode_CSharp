<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListViewDemo.aspx.cs" Inherits="Demo.ListView案例.ListViewDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
    <div>

        <%--ListView是伪分页,查询所有数据,但只显示部分--%>
        <%--用DataPager进行真分页--%>
        <asp:DataPager ID="DataPager2" runat="server" PagedControlID="ListView1">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LoginNameLabel" runat="server" Text='<%# Eval("LoginName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PassWordLabel" runat="server" Text='<%# Eval("PassWord") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PlaneLabel" runat="server" Text='<%# Eval("Plane") %>' />
                    </td>
                    <td>
                        <asp:Label ID="phoneLabel" runat="server" Text='<%# Eval("phone") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MailLabel" runat="server" Text='<%# Eval("Mail") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cardNoLabel" runat="server" Text='<%# Eval("cardNo") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td>
                        <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LoginNameTextBox" runat="server" Text='<%# Bind("LoginName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PassWordTextBox" runat="server" Text='<%# Bind("PassWord") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PlaneTextBox" runat="server" Text='<%# Bind("Plane") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="phoneTextBox" runat="server" Text='<%# Bind("phone") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="MailTextBox" runat="server" Text='<%# Bind("Mail") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="cardNoTextBox" runat="server" Text='<%# Bind("cardNo") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>未返回数据。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                    <td>
                        <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="UserNameTextBox" runat="server" Text='<%# Bind("UserName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LoginNameTextBox" runat="server" Text='<%# Bind("LoginName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PassWordTextBox" runat="server" Text='<%# Bind("PassWord") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PlaneTextBox" runat="server" Text='<%# Bind("Plane") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="phoneTextBox" runat="server" Text='<%# Bind("phone") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="MailTextBox" runat="server" Text='<%# Bind("Mail") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="cardNoTextBox" runat="server" Text='<%# Bind("cardNo") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LoginNameLabel" runat="server" Text='<%# Eval("LoginName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PassWordLabel" runat="server" Text='<%# Eval("PassWord") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PlaneLabel" runat="server" Text='<%# Eval("Plane") %>' />
                    </td>
                    <td>
                        <asp:Label ID="phoneLabel" runat="server" Text='<%# Eval("phone") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MailLabel" runat="server" Text='<%# Eval("Mail") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cardNoLabel" runat="server" Text='<%# Eval("cardNo") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server"></th>
                                    <th runat="server">ID</th>
                                    <th runat="server">UserName</th>
                                    <th runat="server">LoginName</th>
                                    <th runat="server">PassWord</th>
                                    <th runat="server">Plane</th>
                                    <th runat="server">phone</th>
                                    <th runat="server">Mail</th>
                                    <th runat="server">cardNo</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LoginNameLabel" runat="server" Text='<%# Eval("LoginName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PassWordLabel" runat="server" Text='<%# Eval("PassWord") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PlaneLabel" runat="server" Text='<%# Eval("Plane") %>' />
                    </td>
                    <td>
                        <asp:Label ID="phoneLabel" runat="server" Text='<%# Eval("phone") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MailLabel" runat="server" Text='<%# Eval("Mail") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cardNoLabel" runat="server" Text='<%# Eval("cardNo") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>

        <%--BLL中并没有News.Model.HKSJ_USERS类型参数的Delete方法,所以删除功能失效--%>
    
    </div>
       
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="News.Model.HKSJ_USERS" DeleteMethod="Delete" InsertMethod="Add" SelectMethod="GetUserList" TypeName="News.BLL.HKSJ_USERS" UpdateMethod="Update" EnablePaging="True" SelectCountMethod="GetCount">
            <SelectParameters>
                <%--<asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />--%>
            </SelectParameters>
        </asp:ObjectDataSource>
       
    </form>
</body>
</html>
