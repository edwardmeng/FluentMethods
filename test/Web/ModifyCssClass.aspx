<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyCssClass.aspx.cs" Inherits="FluentMethods.WebApp.net45.ModifyCssClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="labelValue" ClientIDMode="Static" Text="Fizz" CssClass="text-info open in"></asp:Label>
    <input runat="server" id="textValue" ClientIDMode="Static" value="Buzz" class="text-info open in"/>
</asp:Content>
