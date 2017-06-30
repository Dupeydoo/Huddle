<%@ Page Title="View Thread" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewThread.aspx.cs" Inherits="Huddle.ViewThread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <asp:Panel ID="ErrorPanel" runat="server" CssClass="forum-error" Visible="false">
        <div class="error-heading">
            Huddle - Are you sure that's where you need to go?
        </div>
        <div class="error-body">
            Invalid thread, contact an administrator if you think this is
            a valid link. Go <a href="/">home...</a>
        </div>
    </asp:Panel>
    <asp:Panel ID="PostsPanel" runat="server" Visible="true">
        
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpClientScript" runat="server">
    <script>
        $(document).ready(function () {
            $('#home').addClass('active');
        })
    </script>
</asp:Content>
