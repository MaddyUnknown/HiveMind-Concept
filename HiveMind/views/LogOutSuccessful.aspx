<%@ Page Title="" Language="C#" MasterPageFile="~/masterTemplate/Site.Master" AutoEventWireup="true" CodeBehind="LogOutSuccessful.aspx.cs" Inherits="HiveMind.View.LogOutSuccessful" %>
<%@MasterType VirtualPath="~/masterTemplate/Site.Master" %>
<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex flex-column align-items-center">
        <p class="h3 text-center py-3">Logged Out Successfully</p>
        <span><asp:Button ID="LogIn" runat="server" Text="Go To Log In Page" OnClick="LogIn_Click" class="btn cust-btn-primary"/></span>
    </div>
</asp:Content>
