<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CityProvinceDemo.aspx.cs"
    Inherits="Demo.省市联动Demo.CityProvinceDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Js/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(function () {
            LoadProvince();

        })

        function LoadProvince() {
            /// <summary>加载省信息</summary>
            $.get("GetProvinceInJSON.ashx", "", function (data) {
                //拿到JSON字符串,把它转成JSON对象,其实用getJSON和设置Type为JSON都能实现
                //转换JSON方法一
                //var jsonData = eval("(" + data + ")"); //括号是为了强制执行
                //方法二
                var jsonData = $.parseJSON(data);
                var appendString = "";
                for (var i in jsonData) {
                    $("#selectProvince").append("<option value='" + jsonData[i].pId + "'>" + jsonData[i].pName + "</option>");
                }
                SelectChangeEvent();
                $("#selectProvince").change();
            });

            function SelectChangeEvent() {
                /// <summary>当选中省改变时事件</summary>
                $("#selectProvince").change(function () {
                    var selectValue = $(this).attr("value");
                    $.getJSON("GetCityInJSON.ashx", "Proid=" + selectValue, function (data) {
                        var city = $("#selectCity");
                        city.empty();//清空上次加载的市信息
                        for (var i in data) {
                            city.append("<option value='" + data[i].CityID + "'>" + data[i].CityName + "</option>");
                        }
                    })
                })

            };

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <select id="selectProvince">
        </select>
        <select id="selectCity">
        </select>
    </div>
    </form>
</body>
</html>
