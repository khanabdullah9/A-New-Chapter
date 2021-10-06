<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookShelf.aspx.cs" Inherits="A_New_Chapter.BookShelf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="margin-bottom:-50px;">
            <div class="col">
                <div class="row">
                    <div class="col-md-6 bg-image mr-auto"></div>
                    <div class="col-md-6">
                        <div class="row" style="margin-top:30px;">
                            <div class="col">
                               <center><asp:Label ID="Label3" runat="server" Text="Your Book Shelf" Font-Size="X-Large"  style="font-family:Impact, fantasy;color:lightcoral;" ></asp:Label></center>
                                <div class="row" style="margin-left:100px;">
                                    <center>
                                    <asp:GridView class="table table-condensed Grid" ID="GridView1" ShowHeader="false" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                                        <Columns>                       
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div class="container-fluid">
                                                        <div class="row">                                                            
                                                            <div class="col">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("book_name") %>' Font-Size="X-Large" style="font-family:Impact, fantasy;color:cadetblue"></asp:Label>
                                                            </div>
                                                        </div>
                                                        
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image class="" ID="MyImage" runat="server" Width="50" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div class="container-fluid">
                                                        <div class="row">
                                                            <div class="col">
                                                                <asp:Button class="btn btn-outline-primary" ID="Button1" runat="server" Text="Read" CommandName="Read" CommandArgument='<%# Eval("book_id") %>' OnClientClick=""/>
                                                                <asp:Button class="btn btn-outline-primary" ID="Button2" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("book_id") %>' OnClientClick="return confirm('Are you sure you want to remove this book?\n You can always request us at anewchapter96@gmail.com to get the book back')"/>                                                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                        </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
