<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookInventory.aspx.cs" Inherits="A_New_Chapter.BookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
                        <!--JQuery to add a search bar to the grid view.-->
<script type="text/javascript">
    $(document).ready(function () {
        $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
    });
</script>
    <style>
        .author-content-text{
    font-family:Gabriola;
    font-size:1.3em;
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
        <div class="row" style="margin-top:25px;">
            <div class="col-md-6 mr-auto">
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                        <div class="row">
                                    <div class="col">
                                        <center>
                                            <h4 class="author-title-text">Book Inventory</h4>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:Image ID="Image1" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <hr />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <p>Book ID</p>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                                <asp:Button class="btn btn-primary btn-sm" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Book Name</p>
                                            <asp:Label class="author-content-text" ID="Label5" runat="server" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Book Genre</p>
                                            <asp:Label class="author-content-text" ID="Label6" runat="server" Font-Bold="true"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Book Price</p>
                                            <asp:Label class="author-content-text" ID="Label7" runat="server" Font-Bold="true"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 mr-auto">
                                        <asp:Button class="btn btn-warning btn-block " ID="Button3" runat="server" Text="Download Book File" OnClick="Button3_Click" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button class="btn btn-warning btn-block " ID="Button4" runat="server" Text="Download Book Image" OnClick="Button4_Click" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <p>Book Description</p>
                                            <asp:Label class="author-content-text" ID="Label8" runat="server" Font-Bold="true"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button5" runat="server" Text="Send Book For Review" OnClick="Button5_Click" Style="margin-bottom:1em;" />                                        
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button2" runat="server" Text="Delete Book Permanently" OnClick="Button2_Click" OnClientClick="return confirm('Are you sure you want delete this book?')"/>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <hr />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
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
                                <h4 class="author-title-text" >Approved Books Available In The Database</h4>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:A New ChapterConnectionString %>" SelectCommand="SELECT * FROM [master_book_table] WHERE ([approved] = @approved)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="approved" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:GridView class="table table-condensed Grid" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" OnRowDataBound="OnRowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" ReadOnly="True" SortExpression="book_id" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    <asp:Label class="author-content-text" ID="Label1" runat="server" Text='<%# Eval("book_name") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <hr />
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-lg-4">
                                                                    Genre:
                                                                    <asp:Label class="author-content-text" ID="Label2" runat="server" Text='<%# Eval("book_genre") %>'></asp:Label>
                                                                </div>
                                                                <div class="col-lg-4">
                                                                    Price($):
                                                                    <asp:Label class="author-content-text" ID="Label3" runat="server" Text='<%# Eval("book_price") %>'></asp:Label>
                                                                </div>
                                                                <div class="col-lg-4">
                                                                    By:
                                                                    <asp:Label class="author-content-text" ID="Label9" runat="server" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <asp:Label class="author-content-text" ID="Label4" runat="server" Text='<%# Eval("book_description") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image class="img-fluid" ID="Image2" runat="server" />
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
