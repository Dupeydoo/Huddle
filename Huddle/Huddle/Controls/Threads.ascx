<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Threads.ascx.cs" Inherits="Huddle.Controls.Threads" %>

<div class="row">
    <div class="col-md-12 threads-wrapper">
        <div id="sticky-wrapper">
            <!-- Gross! -->
            <asp:ListView ID="StickyListView" runat="server"></asp:ListView>
        </div>
        <div id="nonsticky-wrapper">
            <asp:ListView ID="ThreadListView" runat="server"></asp:ListView>
        </div>
    </div>
</div>
