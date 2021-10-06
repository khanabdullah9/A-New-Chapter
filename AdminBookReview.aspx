<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookReview.aspx.cs" Inherits="A_New_Chapter.AdminBookReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Grid th
        {
            color:black;
            background-color:white;
        }
        .Grid, .Grid th, .Grid td
        {
            border:1px solid #ffffff;
        }
        
        .author-content-text{
    font-family:Gabriola;
    font-size:1.1em;
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
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-7 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="author-title-text">Admin Book Review</h4>
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
                                        <asp:Parameter DefaultValue="0" Name="approved" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:GridView class="table table-condensed  Grid" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" OnRowDataBound="OnRowDataBound" OnRowCommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" ReadOnly="True" SortExpression="book_id" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <div class="row">
                                                                <div class="col-lg-2">
                                                                    <asp:Image class="img-fluid " ID="Image1" runat="server" />
                                                                </div>
                                                                <div class="col-lg-10">
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <asp:Label class="author-content-text" ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <hr />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-lg-6">
                                                                            Genre:
                                                                            <asp:Label class="author-content-text" ID="Label2" runat="server" Text='<%# Eval("book_genre") %>'></asp:Label>
                                                                        </div>
                                                                        <div class="col-lg-6">
                                                                            Price($):
                                                                            <asp:Label class="author-content-text" ID="Label3" runat="server" Text='<%# Eval("book_price") %>'></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-12">
                                                                            Description:
                                                                            <asp:Label class="author-content-text" ID="Label4" runat="server" Text='<%# Eval("book_description") %>'></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="row">
                                                    <div class="col">
                                                        <div class="form-group">
                                                            <asp:LinkButton class="btn btn-outline-primary btn-lg" ID="LinkButton1" runat="server" ToolTip="Download" Style="margin-bottom: 1em;" CommandName="Download" CommandArgument='<%# Eval("book_id") %>'><i class="bi bi-download"></i></asp:LinkButton><br />
                                                            <asp:LinkButton class="btn btn-outline-primary btn-lg" ID="LinkButton2" runat="server" ToolTip="Approve" Style="margin-bottom: 1em;" CommandName="Approve" CommandArgument='<%# Eval("book_id") %>'><i class="bi bi-hand-thumbs-up"></i></asp:LinkButton><br />
                                                            <asp:LinkButton class="btn btn-outline-primary btn-lg" ID="LinkButton3" runat="server" ToolTip="Remove" CommandName="Remove" CommandArgument='<%# Eval("author_name")+";"+Eval("book_id") %>' OnClientClick="return confirm('Are you sure you want to remove this book?')"><i class="bi bi-file-x"></i></asp:LinkButton>
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
