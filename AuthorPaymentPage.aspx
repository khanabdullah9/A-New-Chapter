<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuthorPaymentPage.aspx.cs" Inherits="A_New_Chapter.AuthorPaymentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="margin-top: 30px;">
            <div class="col-sm-8 mx-auto">
                <center>Visit www.paypal.com to make the payment</center>
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <h4>Unpaid Authors</h4>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <hr />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:GridView class="table table-condensed Grid" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"  OnRowCommand="GridView1_RowCommand">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col">
                                                                    <div class="row">
                                                                        <div class="col-sm-3">
                                                                            Book ID:
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_id") %>'></asp:Label>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            Book Name:
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("book_name") %>'></asp:Label>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            Book Price($):
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("book_price") %>'></asp:Label>
                                                                        </div>
                                                                        <div class="col-sm-3">
                                                                            Database ID:
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    Email:
                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("email") %>' Font-Bold="true"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <hr />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                <div class="col">
                                                                    <asp:Button class="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Set Paid" CommandName="Paid" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('Are you sure you want to said this as paid?');"/>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
