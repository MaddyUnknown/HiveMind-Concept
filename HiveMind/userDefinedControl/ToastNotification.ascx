<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToastNotification.ascx.cs" Inherits="HiveMind.Userdefined.Control.ToastNotification" %>


<div role="alert" aria-live="assertive" aria-atomic="true" class="toast show mr-3 mt-3" style="position: absolute; top: 0; right: 0; z-index: 100; min-width: 20vw">
    <div class="toast-header">
        <asp:Image ID="BannerImage" runat="server" ImageUrl="~/asset/image/icon/error.png" Height="20px" Width="20px"/>
        <asp:Label ID="Heading" runat="server" Text="There you go" class="mr-auto px-2"></asp:Label>
        <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>
    <div class="toast-body">
        <asp:Label ID="Body" runat="server" Text="This is the error"></asp:Label>
    </div>
    <script>$(function () { $('.toast').toast(); })</script>
</div>
