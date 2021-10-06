<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="A_New_Chapter.homepage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
            <div class="banner-text">
                <div class="text-area">
                    <p style="color:floralwhite">There is no greater agony than bearing an untold story inside you!</p>
                </div>
                <p>
                    <asp:Button class="banner-btn btn" ID="Button2" style="margin-top:-10px;margin-right:-700px;" runat="server" Text="Become An Author" OnClick="Button2_Click" /><br />
                    <asp:Button class="banner-btn btn" ID="book_shelf" style="margin-top:10px;margin-right:-700px;" runat="server" Text="Book Shelf"  OnClick="book_shelf_Click"/><br />
                    <asp:Button class="banner-btn btn" ID="upload_book" style="margin-top:10px;margin-right:-700px;" runat="server" Text="Share your story" OnClick="upload_book_Click"/><br />
                    <asp:Button class="banner-btn btn" ID="member_management" style="margin-top:10px;margin-right:-700px;" runat="server" Text="Member Management" OnClick="member_management_Click" /><br />
                    <asp:Button class="banner-btn btn" ID="author_management" style="margin-top:10px;margin-right:-700px;" runat="server" Text="Author Management"  OnClick="author_management_Click"/><br />
                    <asp:Button class="banner-btn btn" ID="book_inventory" style="margin-top:10px;margin-right:-700px;" runat="server" Text="Book Inventory"  OnClick="book_inventory_Click"/><br />
                    <asp:Button class="banner-btn btn" ID="unpaid_authors" style="margin-top:10px;margin-right:-700px;" runat="server" Text="Unpaid Authors"  OnClick="unpaid_authors_Click"/><br />                    
                    <asp:Button class="banner-btn btn" ID="book_review" style="margin-top:10px;margin-right:-700px;" runat="server" Text="Book Review"  OnClick="book_review_Click"/><br />                    
                    <asp:Button class="btn btn-default" ID="admin_login" style="margin-top:-330px;margin-left:-1300px;" runat="server" Text=""  OnClick="admin_login_Click"/>
                </p>
            </div>
        </div>
</asp:Content>
