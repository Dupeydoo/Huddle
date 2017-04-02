<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Huddle.MyAccount.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpClientScript" runat="server">
    <script>
        $(document).ready(function () {
            $('#myaccount').addClass('active');
        })
    </script>
</asp:Content>
