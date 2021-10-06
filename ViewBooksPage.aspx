<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewBooksPage.aspx.cs" Inherits="A_New_Chapter.ViewBooksPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <div class="row">
            <div class="col-md-10 mx-auto">
                <div class="row">
                    <div class="col">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Image class="img-fluid p-2" ID="Image1" runat="server" />
                                    </div>
                                    <div class="col-md-10">
                                        <div class="row">
                                            <div class="col-md-12">

                                                <asp:Label ID="Label1" class="bookstore-title-text"  runat="server" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4">
                                                Genre:
                                                <asp:Label ID="Label2" CssClass="bookstore-content-text"  runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4">
                                                Price($):
                                                <asp:Label ID="Label3" CssClass="bookstore-content-text" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4">
                                                By:
                                                <asp:Label ID="Label4" CssClass="bookstore-content-text" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                Description:
                                                <asp:Label ID="Label5" CssClass="bookstore-content-text" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top: 1em;">
            <div class="col-md-8 mx-auto">
                <div class="row">
                    <div class="col">
                        <h5 class="nav-link-font">Write Your Review Here:</h5>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <asp:TextBox class="form-control" ID="TextBox1" runat="server" TextMode="MultiLine" placeholder="Write something nice...."></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Button class="btn btn-primary btn-lg" ID="Button2" runat="server" Text="Post" OnClick="Button2_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top: ;">
            <div class="col-md-8 mx-auto">
                <div class="">
                    <div class="">
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:A New ChapterConnectionString %>" SelectCommand="SELECT * FROM [review_box] WHERE ([book_id] = @book_id) ORDER BY [comment_time] DESC">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="book_id" QueryStringField="bookID" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:GridView class="table table-condensed Grid" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="comment_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <div class="row">
                                                                <div class="col-lg-5 mr-auto">
                                                                    <asp:Label ID="Label6" class="nav-link-font" runat="server" Text='<%# Eval("comment_from") %>' Font-Bold="true" Font-Size="X-Large"></asp:Label> (<asp:Label ID="Label9"  runat="server" Text='<%# Eval("commenter_role") %>'></asp:Label>)
                                                                    says....                                                                    
                                                                </div>
                                                                <div class="col-lg-3">
                                                                    
                                                                </div>
                                                                <div class="col-lg-4 float-left">
                                                                    at:
                                                                    <asp:Label ID="Label7" class="nav-link-font" runat="server" Text='<%# Eval("comment_time") %>' Font-Size="Larger"></asp:Label>
                                                                </div>
                                                                
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <hr />
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <asp:Label ID="Label8" class="nav-link-font" runat="server" Text='<%# Eval("comment_text") %>'></asp:Label>
                                                                </div>
                                                            </div>
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
</asp:Content>
