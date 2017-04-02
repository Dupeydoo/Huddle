<%@ Page Title="View Category" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="ViewCategory.aspx.cs" Inherits="Huddle.ViewCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <asp:Panel ID="ErrorPanel" runat="server" CssClass="forum-error">
        <div class="error-heading">

        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpClientScript" runat="server">
    <script>
        $(document).ready(function () {
            $('#home').addClass('active');
        })
    </script>
</asp:Content>
