<%@ Page Title="Forum Settings" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ForumSettings.aspx.cs" Inherits="Huddle.Admin.ForumSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpClientScript" runat="server">
    <script>
        $(document).ready(function () {
            $('#admin').addClass('active');
        })
    </script>
</asp:Content>
