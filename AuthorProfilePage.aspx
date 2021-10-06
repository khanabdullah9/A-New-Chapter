<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuthorProfilePage.aspx.cs" Inherits="A_New_Chapter.AuthorProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--JQuery to add a search bar to the grid view.-->
    <script type="text/javascript">
        $(document).ready(function () {
            $(".SearchEnabled").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
    <style>
        .author-content-text{
    font-family:Gabriola;
    font-size:1.5em;
    font-weight:bold;
    color:cadetblue;
}
        .author-title-text {
            font-family:Gabriola;
            font-size:2em;
            font-weight:bold;
            color:lightcoral;
        }
    </style>
    <link href="StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="margin-top:20px;">
            <div class="col-md-6 mr-auto">
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                        <h3 class="author-title-text">Author's Profile Page</h3>
                                    </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <%--for authour profile picture--%>
                                        <center>
                                        <asp:Image ID="Image1" runat="server" width="150px" Height="150px"/>
                                            </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <hr />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <p>Author Name</p>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox class="form-control" ID="TextBox1" runat="server" ></asp:TextBox>
                                                <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Full Name</p>
                                            <asp:Label class="author-content-text" ID="Label5" runat="server" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Reputation Points</p>
                                            <asp:Label class="author-content-text" ID="Label6" runat="server" Font-Bold="true"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Email</p>
                                            <asp:Label class="author-content-text" ID="Label7" runat="server" Font-Bold="true"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                            <p>About Author</p>
                                            <asp:Label class="author-content-text" ID="Label8" runat="server" Font-Bold="true"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 mx-auto">
                                        <div class="form-group">
                                            <asp:LinkButton ID="LinkButton1" class="btn btn-primary btn-lg btn-block" runat="server" ToolTip="Like" OnClick="LinkButton1_Click"><i class="bi bi-hand-thumbs-up"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 mx-auto">
                                        <center>
                                        <asp:Label ID="Label10" runat="server"  ForeColor="Blue" ></asp:Label>
                                            </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4 class="author-title-text">List of books uploaded by author</h4>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:A New ChapterConnectionString %>" SelectCommand="SELECT * FROM [master_book_table] WHERE ([author_name] = @author_name)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="TextBox1" Name="author_name" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:GridView class="table table-condensed Grid SearchEnabled" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" OnRowDataBound="OnRowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    <asp:Label CssClass="author-content-text" ID="Label1" runat="server" Text='<%# Eval("book_name")%>' Font-Bold="true" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <hr />
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-lg-6">
                                                                    Book Genre:
                                                            <asp:Label CssClass="author-content-text" ID="Label2" runat="server" Text='<%# Eval("book_genre") %>'></asp:Label>
                                                                </div>
                                                                <div class="col-lg-6">
                                                                    Book Price:
                                                            <asp:Label CssClass="author-content-text" ID="Label3" runat="server" Text='<%# Eval("book_price") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    Book Description:
                                                            <asp:Label CssClass="author-content-text" ID="Label4" runat="server" Text='<%# Eval("book_description") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image class="img-fluid p-2" ID="Image2" runat="server" />
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
</asp:Content>
