<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Categories.ascx.cs" Inherits="Huddle.Controls.Categories" %>

<div class="row">
    <div class="col-md-2"></div>
    <div class="col-md-8">
        <asp:ListView ID="CategoriesListView" runat="server">
        </asp:ListView>
        <asp:DataPager ID="CategoriesPager" runat="server" PagedControlID="CategoriesListView"></asp:DataPager>
    </div>
    <div class="col-md-2"></div>
</div>
