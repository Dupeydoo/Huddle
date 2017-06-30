<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Threads.ascx.cs" Inherits="Huddle.Controls.Threads" %>

<div class="row forum-wrapper">
    <div class="col-md-2"></div>

    <div class="col-md-8 forum-inner-wrapper">
        <div class="row forum-row-heading">
            <div class="col-md-12 section-heading">
                <asp:Literal ID="SectionHeading" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 sub-section-heading">
                <h1>Sticky Threads</h1>
            </div>
        </div>
        <!-- Gross! -->
        <asp:ListView ID="StickyListView" runat="server" SelectMethod="StickyListView_GetData" ItemType="Huddle.Objects.Thread">
            <ItemTemplate>
                <div class="row forum-row">
                    <div class="col-md-12">
                        <div class="thread-main">
                            <asp:HyperLink ID="ThreadTitle" runat="server" Text='<%# Item.Title %>' NavigateUrl='<%# "~/ViewThread.aspx?id=" + Item.Id %>'></asp:HyperLink>
                            <div class="thread-description">
                                <asp:Literal ID="ThreadDescription" runat="server" Text='<%# "Started By: " + Item.CreatedBy + " " + Item.DateCreated.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>'></asp:Literal>
                            </div>
                        </div>
                        <div class="thread-modified">
                            <p>
                                <asp:Literal runat="server" ID="LastPost" Text='<%# "Last Post By: " + Item.ModifiedBy %>'></asp:Literal>
                                <br />
                                <asp:Literal runat="server" ID="LastPostDate" Text='<%# Item.DateModified.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>'></asp:Literal>
                            </p>
                        </div>
                        <div class="thread-popularity">
                            <p>
                                <asp:Literal runat="server" ID="ThreadReplies" Text='<%# "Replies: " + Item.Replies %>'></asp:Literal>
                                <br />
                                <asp:Literal runat="server" ID="ThreadViews" Text='<%# "Views: " + Item.Views %>'></asp:Literal>
                            </p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="row forum-row-alternate">
                    <div class="col-md-12">
                        <div class="thread-main">
                            <asp:HyperLink ID="ThreadTitle" runat="server" Text='<%# Item.Title %>' NavigateUrl='<%# "~/ViewThread.aspx?id=" + Item.Id %>'></asp:HyperLink>
                            <div class="thread-description">
                                <asp:Literal ID="ThreadDescription" runat="server" Text='<%# "Started By: " + Item.CreatedBy + " " + Item.DateCreated.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>'></asp:Literal>
                            </div>
                        </div>
                        <div class="thread-modified">
                            <p>
                                <asp:Literal runat="server" ID="LastPost" Text='<%# "Last Post By: " + Item.ModifiedBy %>'></asp:Literal>
                                <br />
                                <asp:Literal runat="server" ID="LastPostDate" Text='<%# Item.DateModified.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>'></asp:Literal>
                            </p>
                        </div>
                        <div class="thread-popularity">
                            <p>
                                <asp:Literal runat="server" ID="ThreadReplies" Text='<%# "Replies: " + Item.Replies %>'></asp:Literal>
                                <br />
                                <asp:Literal runat="server" ID="ThreadViews" Text='<%# "Views: " + Item.Views %>'></asp:Literal>
                            </p>
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
        <div class="row">
            <div class="col-md-12 sub-section-heading">
                <h1>Normal Threads</h1>
            </div>
        </div>
        <asp:ListView ID="ThreadListView" runat="server" SelectMethod="ThreadListView_GetData" ItemType="Huddle.Objects.Thread">
            <ItemTemplate>
                <div class="row forum-row">
                    <div class="col-md-12">
                        <div class="thread-main">
                            <asp:HyperLink ID="ThreadTitle" runat="server" Text='<%# Item.Title %>' NavigateUrl='<%# "~/ViewThread.aspx?id=" + Item.Id %>'></asp:HyperLink>
                            <div class="thread-description">
                                <asp:Literal ID="ThreadDescription" runat="server" Text='<%# "Started By: " + Item.CreatedBy + " " + Item.DateCreated.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>'></asp:Literal>
                            </div>
                        </div>
                        <div class="thread-modified">
                            <p>
                                <asp:Literal runat="server" ID="LastPost" Text='<%# "Last Post By: " + Item.ModifiedBy %>'></asp:Literal>
                                <br />
                                <asp:Literal runat="server" ID="LastPostDate" Text='<%# Item.DateModified.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>'></asp:Literal>
                            </p>
                        </div>
                        <div class="thread-popularity">
                            <p>
                                <asp:Literal runat="server" ID="ThreadReplies" Text='<%# "Replies: " + Item.Replies %>'></asp:Literal>
                                <br />
                                <asp:Literal runat="server" ID="ThreadViews" Text='<%# "Views: " + Item.Views %>'></asp:Literal>
                            </p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="row forum-row-alternate">
                    <div class="col-md-12">
                        <div class="thread-main">
                            <asp:HyperLink ID="ThreadTitle" runat="server" Text='<%# Item.Title %>' NavigateUrl='<%# "~/ViewThread.aspx?id=" + Item.Id %>'></asp:HyperLink>
                            <div class="thread-description">
                                <asp:Literal ID="ThreadDescription" runat="server" Text='<%# "Started By: " + Item.CreatedBy + " " + Item.DateCreated.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>'></asp:Literal>
                            </div>
                        </div>
                        <div class="thread-modified">
                            <p>
                                <asp:Literal runat="server" ID="LastPost" Text='<%# "Last Post By: " + Item.ModifiedBy %>'></asp:Literal>
                                <br />
                                <asp:Literal runat="server" ID="LastPostDate" Text='<%# Item.DateModified.ToLocalTime().ToString("ddd d MMMM yyyy, HH:mm") %>'></asp:Literal>
                            </p>
                        </div>
                        <div class="thread-popularity">
                            <p>
                                <asp:Literal runat="server" ID="ThreadReplies" Text='<%# "Replies: " + Item.Replies %>'></asp:Literal>
                                <br />
                                <asp:Literal runat="server" ID="ThreadViews" Text='<%# "Views: " + Item.Views %>'></asp:Literal>
                            </p>
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
        <asp:DataPager runat="server" ID="ThreadsPager" PagedControlID="ThreadListView"></asp:DataPager>
    </div>
    <div class="col-md-2"></div>
</div>

