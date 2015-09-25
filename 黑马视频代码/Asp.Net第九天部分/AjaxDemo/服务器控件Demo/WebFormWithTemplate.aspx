<%@ Page Title="" Language="C#" MasterPageFile="~/服务器控件Demo/SiteDemo.Master" AutoEventWireup="true" CodeBehind="WebFormWithTemplate.aspx.cs" Inherits="Demo.服务器控件Demo.WebFormWithTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
</asp:Content>
