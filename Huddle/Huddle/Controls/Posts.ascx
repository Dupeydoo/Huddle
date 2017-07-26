<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Posts.ascx.cs" Inherits="Huddle.Controls.Posts" %>

<div class="forum-wrapper">
    <div class="row">
        <div class="col-md-12">
            <asp:ListView ID="PostsView" runat="server" SelectMethod="PostsView_GetData" ItemType="Huddle.Objects.Post" OnItemDataBound="PostsView_ItemDataBound" OnPagePropertiesChanging="PostsView_PagePropertiesChanging">
                <ItemTemplate>
                    <div class="post">
                        <div class="post-header clearfix">
                            <h2>
                                <asp:Literal runat="server" ID="PostCreated" Text='<%# "Date Posted: " + Item.DateCreated.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>'></asp:Literal>
                            </h2>
                            <div class="rightfloater">
                                <p>
                                    <asp:Literal runat="server" ID="PostNumber"></asp:Literal>
                                </p>
                            </div>
                        </div>
                        <div class="post-body clearfix">
                            <aside class="left-profile">
                                Hello World!
                            </aside>
                            <section class="post-content">
                                <h3 class="thread-title">
                                    <asp:Literal runat="server" ID="ThreadTitle" Text="<%# Page.Title %>"></asp:Literal>
                                </h3>
                                <article>
                                    <p>
                                        <asp:Literal runat="server" ID="PostMessage" Text='<%# Item.PostMessage %>'></asp:Literal>
                                    </p>
                                </article>
                                <div class="post-footer">
                                    <div class="signature">
                                        Signature goes here
                                    </div>
                                    <asp:Literal runat="server" ID="PostModified" Text='<%# "Date Edited: " + Item.DateModified.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>'></asp:Literal>
                                </div>
                            </section>
                        </div>
                    </div>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul class="ItemContainer">
                        <li runat="server" id="itemPlaceholder"></li>
                    </ul>
                </LayoutTemplate>
            </asp:ListView>
            <asp:DataPager runat="server" ID="PostsPager" PagedControlID="PostsView">
                <Fields>
                    <asp:NumericPagerField ButtonCount="10" />
                </Fields>
            </asp:DataPager>
            <asp:Literal runat="server" ID="Test"></asp:Literal>
        </div>
    </div>
</div>
