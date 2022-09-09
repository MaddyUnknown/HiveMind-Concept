<%@ Page Title="" Language="C#" MasterPageFile="~/masterTemplate/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="HiveMind.View.HomePage" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%=Request.ApplicationPath+"/asset/stylesheet/pages/WelcomePage.css"%>" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">User Home Page</h1>
</asp:Content>
