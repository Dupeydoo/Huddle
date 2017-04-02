<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Categories.ascx.cs" Inherits="Huddle.Controls.Categories" %>

<div class="row forum-wrapper">
    <div class="col-md-2"></div>

    <div class="col-md-8 forum-inner-wrapper">
        <div class="row forum-row-heading">
            <div class="col-md-12 section-heading">
                <asp:Literal ID="SectionHeading" runat="server" Text="Forum"></asp:Literal>
            </div>
        </div>

        <asp:ListView ID="CategoriesListView" runat="server" SelectMethod="CategoriesListView_GetData" ItemType="Huddle.Data.Entities.Category">
            <ItemTemplate>
                <div class="row forum-row">
                    <div class="col-md-12">
                        <div class="category-main">
                            <asp:HyperLink ID="CategoryTitle" runat="server" Text='<%# Item.Title %>' NavigateUrl='<%# "~/ViewCategory?id=" + Item.Id %>'></asp:HyperLink><br />
                            <div class="category-description">
                                <asp:Literal ID="CategoryDescription" runat="server" Text='<%# Item.Description %>'></asp:Literal>
                            </div>
                        </div>
                        <div class="clearfix">
                            <div class="forum-categorymodify">
                                Last Post:
                                <asp:Literal ID="ModifiedBy" Text='<%# Item.ModifiedBy %>' runat="server" /><br />
                                At:
                                <asp:Literal ID="ModifiedDate" Text='<%# Item.DateModified.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>' runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="row forum-row-alternate">
                    <div class="col-md-12">
                        <div class="category-main">
                            <asp:HyperLink ID="CategoryTitle" runat="server" Text='<%# Item.Title %>' NavigateUrl='<%# "~/ViewCategory?id=" + Item.Id %>'></asp:HyperLink><br />
                            <div class="category-description">
                                <asp:Literal ID="CategoryDescription" runat="server" Text='<%# Item.Description %>'></asp:Literal>
                            </div>
                        </div>
                        <div class="clearfix">
                            <div class="forum-categorymodify">
                                Last Post:
                                <asp:Literal ID="ModifiedBy" Text='<%# Item.ModifiedBy %>' runat="server" /><br />
                                At:
                                <asp:Literal ID="ModifiedDate" Text='<%# Item.DateModified.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>' runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </AlternatingItemTemplate>
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
