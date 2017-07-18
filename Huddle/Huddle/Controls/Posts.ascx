<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Posts.ascx.cs" Inherits="Huddle.Controls.Posts" %>

<div class="forum-wrapper">
    <div class="row">
        <div class="col-md-12">
            <asp:ListView ID="PostsView" runat="server" SelectMethod="PostsView_GetData" ItemType="Huddle.Objects.Post">
                <ItemTemplate>
                    <div class="post">
                        <div class="post-header">
                            <h2>
                                <asp:Literal runat="server" ID="PostCreated" Text='<%# Item.DateCreated %>'></asp:Literal>
                            </h2>
                            <div class="rightfloater">
                                <p>
                                    <asp:Literal runat="server" ID="PostNumber" Text="1"></asp:Literal>
                                </p>
                            </div>
                        </div>
                        <div class="post-body">
                            <aside class="left-profile">
                            </aside>
                            <h3>
                                <asp:Literal runat="server" ID="ThreadTitle" Text='<%# Item.ThreadId %>'></asp:Literal>
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
                                <asp:Literal runat="server" ID="PostModified" Text='<%# Item.DateModified %>'></asp:Literal>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul class="ItemContainer">
                        <li runat="server" id="itemPlaceholder"></li>
                    </ul>
                </LayoutTemplate>
            </asp:ListView>
            <asp:DataPager runat="server" ID="PostsPager" PagedControlID="PostsView"></asp:DataPager>
        </div>
    </div>
</div>
