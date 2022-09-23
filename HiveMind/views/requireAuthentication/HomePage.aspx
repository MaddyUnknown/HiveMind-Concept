<%@ Page Title="" Language="C#" MasterPageFile="~/masterTemplate/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="HiveMind.View.HomePage" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%=Request.ApplicationPath+"/asset/stylesheet/pages/WelcomePage.css"%>" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex flex-column flex-md-row justify-content-center">
        <span class="h1 text-center">Welcome, &nbsp;</span>
        <asp:Label ID="UserName" runat="server" Text="" class="h1 text-center"></asp:Label>
    </div>
    <h1 class="text-center">User Home Page</h1>
</asp:Content>
