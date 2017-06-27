<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Threads.ascx.cs" Inherits="Huddle.Controls.Threads" %>

<div class="row forum-wrapper">
    <div class="col-md-2"></div>

    <div class="col-md-8 forum-inner-wrapper">
        <div class="row forum-row-heading">
            <div class="col-md-12 section-heading">
                <asp:Literal ID="SectionHeading" runat="server"></asp:Literal>
            </div>
        </div>
        <!-- Gross! -->
        <asp:ListView ID="StickyListView" runat="server" SelectMethod="StickyListView_GetData" ItemType="Huddle.Objects.Thread">
            <ItemTemplate>
                <div class="row forum-row">
                    <div class="col-md-12">
                        <asp:HyperLink id="ThreadTitle" runat="server" Text='<%# Item.Title %>' NavigateUrl='<%# "~/ViewThread.aspx?id=" + Item.Id %>'></asp:HyperLink>
                    </div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="row forum-row-alternate">
                    <div class="col-md-12"></div>
                </div>
            </AlternatingItemTemplate>
            <LayoutTemplate>
                <ul class="ItemContainer">
                    <li runat="server" id="itemPlaceholder"></li>
                </ul>
            </LayoutTemplate>
        </asp:ListView>
        <asp:ListView ID="ThreadListView" runat="server" SelectMethod="ThreadListView_GetData" ItemType="Huddle.Objects.Thread">
            <ItemTemplate>
                <div class="row forum-row">
                    <div class="col-md-12"></div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="row forum-row-alternate">
                    <div class="col-md-12"></div>
                </div>
            </AlternatingItemTemplate>
            <LayoutTemplate>
                <ul class="ItemContainer">
                    <li runat="server" id="itemPlaceholder"></li>
                </ul>
            </LayoutTemplate>
        </asp:ListView>
    </div>
    <div class="col-md-2"></div>
</div>

