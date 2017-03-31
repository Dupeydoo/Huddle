<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Categories.ascx.cs" Inherits="Huddle.Controls.Categories" %>

<div class="row">
    <div class="col-md-2"></div>
    <div class="col-md-8">
        <asp:ListView ID="CategoriesListView" runat="server" SelectMethod="CategoriesListView_GetData" ItemType="Category">
            <ItemTemplate>
                <asp:TextBox ID="CategoryTitle" runat="server" Text='<%# Item.Title %>'></asp:TextBox>
            </ItemTemplate>
            <LayoutTemplate>
                <ul class="ItemContainer">
                    <li runat="server" id="itemPlaceholder"></li>
                </ul>
            </LayoutTemplate>
        </asp:ListView>
        <asp:DataPager ID="CategoriesPager" runat="server" PagedControlID="CategoriesListView"></asp:DataPager>
    </div>
    <div class="col-md-2"></div>
</div>
