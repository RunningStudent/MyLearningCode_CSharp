<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStateDemo.aspx.cs" Inherits="News.Web.黑马7Demo.ViewStateDemo" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%=Num%>
        <br />
        <input type="submit" name="name" value="上传" />
        <br />
        <input type="text" name="TxtValue" value="<%=txtValue %>  " /><asp:ListView 
            ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" 
            InsertItemPosition="LastItem" style="margin-top: 123px">
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
                    </td>
                    <td>
                        <asp:Label ID="typeLabel" runat="server" Text='<%# Eval("type") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="peopleLabel" runat="server" Text='<%# Eval("people") %>' />
                    </td>
                    <td>
                        <asp:Label ID="picUrlLabel" runat="server" Text='<%# Eval("picUrl") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td>
                        <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="contentTextBox" runat="server" Text='<%# Bind("content") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="typeTextBox" runat="server" Text='<%# Bind("type") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="peopleTextBox" runat="server" Text='<%# Bind("people") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="picUrlTextBox" runat="server" Text='<%# Bind("picUrl") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>
                            未返回数据。</td>
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
                        <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="contentTextBox" runat="server" Text='<%# Bind("content") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="typeTextBox" runat="server" Text='<%# Bind("type") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="peopleTextBox" runat="server" Text='<%# Bind("people") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="picUrlTextBox" runat="server" Text='<%# Bind("picUrl") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
                    </td>
                    <td>
                        <asp:Label ID="typeLabel" runat="server" Text='<%# Eval("type") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="peopleLabel" runat="server" Text='<%# Eval("people") %>' />
                    </td>
                    <td>
                        <asp:Label ID="picUrlLabel" runat="server" Text='<%# Eval("picUrl") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server">
                                    </th>
                                    <th runat="server">
                                        ID</th>
                                    <th runat="server">
                                        title</th>
                                    <th runat="server">
                                        content</th>
                                    <th runat="server">
                                        type</th>
                                    <th runat="server">
                                        Date</th>
                                    <th runat="server">
                                        people</th>
                                    <th runat="server">
                                        picUrl</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                        ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                    <td>
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
                    </td>
                    <td>
                        <asp:Label ID="typeLabel" runat="server" Text='<%# Eval("type") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                    </td>
                    <td>
                        <asp:Label ID="peopleLabel" runat="server" Text='<%# Eval("people") %>' />
                    </td>
                    <td>
                        <asp:Label ID="picUrlLabel" runat="server" Text='<%# Eval("picUrl") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
&nbsp;<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            DataObjectTypeName="News.Model.HKSJ_Main" DeleteMethod="Delete" 
            InsertMethod="Add" SelectMethod="GetModelList" TypeName="News.BLL.HKSJ_Main" 
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue=" " Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </div>
    </form>
</body>
</html>
