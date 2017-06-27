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
        <asp:ListView ID="StickyListView" runat="server"></asp:ListView>
    </div>
    <div id="nonsticky-wrapper">
        <asp:ListView ID="ThreadListView" runat="server"></asp:ListView>
    </div>
</div>

