<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBandingDemo.aspx.cs" Inherits="Demo.省市联动服务器控件版.DataBandingDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ProvinceDDList" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="ProName" DataValueField="ProID"></asp:DropDownList>
        
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Demo.省市联动Demo.ProvinceDataSetTableAdapters.ProvinceTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ProID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProID" Type="Int32" />
                <asp:Parameter Name="ProName" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProName" Type="String" />
                <asp:Parameter Name="Original_ProID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        
        <asp:DropDownList ID="CityDDList" runat="server" DataSourceID="ObjectDataSource2" DataTextField="CityName" DataValueField="CityID"></asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCityByProID" TypeName="Demo.省市联动Demo.ProvinceDataSetTableAdapters.CityTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_CityName" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CityID" Type="Int32" />
                <asp:Parameter Name="CityName" Type="String" />
                <asp:Parameter Name="ProID" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ProvinceDDList" DefaultValue="0" Name="pid" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="CityID" Type="Int32" />
                <asp:Parameter Name="ProID" Type="Int32" />
                <asp:Parameter Name="Original_CityName" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
