<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Demo.用datagrid进行增删改查.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Js/jquery-easyui-1.4/themes/bootstrap/easyui.css" rel="stylesheet" />
    <link href="../Js/jquery-easyui-1.4/themes/icon.css" rel="stylesheet" />

    <script src="../Js/jquery-1.7.1.js"></script>
    <script src="../Js/datapattern.js"></script>
    <script src="../Js/jquery-easyui-1.4/locale/easyui-lang-zh_CN.js"></script>
    <script src="../Js/jquery-easyui-1.4/jquery.easyui.min.js"></script>

    <script type="text/ecmascript">
        $(function () {
            initializeTable();
            $("#editNewsDialog").css("display", "none");
            $("#addNewsDialog").css("display", "none"); 
        })
        function initializeTable() {
            /// <summary>初始化DataGrid</summary>
            $('#tt').datagrid({
                iconCls: "",//标题旁边的图标
                url: 'GetNews.ashx',//请求新闻的页面,它会发送一个JSON对象{page: rows:}
                //返回数据必须包括{total: ,rows:[{},{},{}...]}
                selectOnCheck: true,//为true时候,勾选将控制行选取
                checkOnSelect: true,//为true时候,行选取能控制勾选
                title: '新闻展示',
                width: 700,
                height: 400,
                fitColumns: true,//填满列
                idField: 'ID',//主键ID,名字必须与发送过来的JSON数据一样,注意大小写
                loadMsg: '正在加载新闻...',//等待后端发送数据时显示的文字
                pagination: true,//是否显示分页工具栏,默认false
                singleSelect: false,//单行选择,默认false
                pageSize: 10,
                pageNumber: 1,
                pageList: [10, 20, 30],//一个下拉列表框,用户可设置的,用于修改页面显示数据数
                queryParams: {},//额外发送的数据
                columns: [[
                    //field字段名称,应与发送过来的JSON数据对应

                    //formatter(格式化器)函数,三个参数
                    //value 这个单元格的数据
                    //row 这一行的行对象
                    //index 这行的索引

                    //styler(样式)函数，返回如'background:red'这样的自定义单元格样式字符串。,三个参数
                    //value 这个单元格的数据
                    //row 这一行的行对象
                    //index 这行的索引

                        { field: 'ck', checkbox: true, align: 'left', width: 50 },
                        { field: 'ID', title: '主键', width: 80 },
                        { field: 'title', title: '标题', width: 120 },
                        { field: 'type', title: '类型', width: 80 },
                        {
                            field: 'Date', title: '提交时间', width: 80, align: 'right',
                            formatter: function (value, row, index) {
                                return (eval(value.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"))).pattern("yyyy-M-d h:m:s.S");
                            }
                        },
                ]],
                //工具栏
                toolbar: [{
                    id: 'btnAddNews',
                    text: '添加新闻',
                    iconCls: 'icon-add',//图标
                    handler: showAddNewsDialog
                }, {
                    id: 'btnEditNews',
                    text: '修改新闻',
                    iconCls: 'icon-edit',
                    handler: editNews
                }, {
                    id: 'btnDeleteNews',
                    text: '删除新闻',
                    iconCls: 'icon-delete',
                    handler:deleteNews
                }],
                onHeaderContextMenu: function (e, field) {
                    //在鼠标右击DataGrid表格头的时候触发。
                }
            });

        }
        function editNews() {
            //获得选中行
            var seletedRows = $("#tt").datagrid("getSelections");
            if (seletedRows.length != 1) {
                $.messager.alert("错误", "选择一行进行修改", "warning");
                return
            } else {
                $("#txtTitle").val($.trim(seletedRows[0].title));
                $("#txtType").val($.trim(seletedRows[0].type));
                $("#Id").val(seletedRows[0].ID);
                showEidtDialog();
            }
        }
        function showEidtDialog() {
            $("#editNewsDialog").css("display", "block");
            $('#editNewsDialog').dialog({
                title: '编辑新闻',
                collapsible: true,
                minimizable: true,
                maximizable: true,
                resizable: true,
                modal: true,
                toolbar: [{
                    text: 'Add',
                    iconCls: 'icon-add',
                    handler: function () {
                        alert('add');
                    }
                }, '-', {
                    text: 'Save',
                    iconCls: 'icon-save',
                    handler: function () {
                        saveChange();
                    }
                }],
                buttons: [{
                    text: 'Ok',
                    iconCls: 'icon-ok',
                    handler: function () {
                        alert('ok');
                    }
                }, {
                    text: 'Cancel',
                    handler: function () {
                        $('#editNewsDialog').dialog('close');
                    }
                }]
            });
        }
        function saveChange() {
            var postdata = $("#editNewsDialog input").serializeArray();
            $.post("SaveChange.ashx", postdata, function (data) {
                if (data == "ok") {
                    $('#editNewsDialog').dialog('close');
                    //刷新
                    $("#tt").datagrid("reload");
                } else {
                    $.messager.alert("失败", "数据保存失败", "warning");
                }
            });
        }
        function addNews() {
            //序列化新增对话框下所有 有name属性的标签
            var postdata = $("#addNewsDialog *[name]").serializeArray();
            $.post("AddNews.ashx", postdata, function (data) {
                if (data=="ok") {
                    $('#addNewsDialog').dialog('close');
                    $("#tt").datagrid("reload");
                } else {
                    $.messager.alert("错误", "添加新闻失败", "error");
                }
            });
        }
        function showAddNewsDialog() {
            $("#addNewsDialog").css("display", "block");
            $('#addNewsDialog').dialog({
                title: '编辑新闻',
                collapsible: true,
                minimizable: true,
                maximizable: true,
                resizable: true,
                modal: true,
                buttons: [{
                    text: 'Add',
                    iconCls: 'icon-add',
                    handler: function () {
                        addNews();
                    }
                }, {
                    text: 'Cancel',
                    handler: function () {
                        $('#addNewsDialog').dialog('close');
                    }
                }]
            });
        }
        function deleteNews() {
            var selectRows = $("#tt").datagrid("getSelections");
            //遍历JSON数组,把JSON对象的ID取出组成一个新的JSON数组
            var newJSON=$.map(selectRows, function (e,i) {
                return e.ID;
            });
            //现在newJSON是个数组[xx,xx],把它封装成一个JSON对象,方便传输
            $.post("DeleteNews.ashx", { "id": String(newJSON) }, function (data) {
                if (data=="ok") {
                    $("#tt").datagrid("reload");
                } else {
                    alert("删除失败");
                }
            });

        }

    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%--Easy-ui DataGrid显示数据--%>
        <div>
            <table id="tt" style="width: 700px;" title="标题，可以使用代码进行初始化，也可以使用这种属性的方式" iconcls="icon-edit">
            </table>
        </div>


        <%---------------------编辑对话框开始-----------------------------%>
        <div id="editNewsDialog">
            <input type="hidden" name="Id" id="Id" value=" " />
            <table border="0" cellpadding="0" cellspacing="0">
                <h1>编辑新闻</h1>
                <tr>
                    <td>标题
                    </td>
                    <td>
                        <input type="text" id="txtTitle" name="txtTitle" />
                    </td>
                </tr>
                <tr>
                    <td>类型
                    </td>
                    <td>
                        <input type="text" id="txtType" name="txtType" />
                    </td>
                </tr>
            </table>
        </div>
        <%---------------------编辑对话框结束-----------------------------%>

        <%---------------------新增对话框开始-----------------------------%>
        <div id="addNewsDialog">
            <table>
                <tr>
                    <td>标题</td>
                    <td>
                        <input type="text" name="title" value="" /></td>
                </tr>
                <tr>
                    <td>类型</td>
                    <td>
                        <input type="text" name="type" value="" />

                    </td>
                </tr>
                <tr>
                    <td>创建人</td>
                    <td>
                        <input type="text" name="people" value="" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">内容
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <textarea cols="20" name="content"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <%---------------------新增对话框结束-----------------------------%>
    </form>
</body>
</html>
