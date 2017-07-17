<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Posts.ascx.cs" Inherits="Huddle.Controls.Posts" %>

<div class="forum-wrapper">
    <div class="row">
        <div class="col-md-12">
            <asp:ListView ID="PostsView" runat="server" SelectMethod="PostsView_GetData" ItemType="Huddle.Objects.Post">
                <ItemTemplate>
                    <div class="post">
                        <div class="post-header">
                            <h2>Timestamp</h2>
                            <div class="rightfloater">
                                <p>#1</p>
                            </div>
                        </div>
                        <div class="post-body">
                            <aside class="left-profile">

                            </aside>
                            <h3>Post Title</h3>
                            <article>
                                Post Message here folks
                            </article>
                            <footer>
                                Signature goes here
                            </footer>
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
