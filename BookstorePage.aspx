<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookstorePage.aspx.cs" Inherits="A_New_Chapter.BookstorePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //$(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
    <style>
        .bookstore-content-text-2 {
    font-family:Gabriola;
    color: cadetblue;
   
}
    </style>
    <link href="StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="background-color:white">
        <div id="rem1" class="row">
            <div class="col-md-8 mx-auto">
                <center>
                <asp:Label ID="Label7" runat="server" Text="hello"></asp:Label>                
                <asp:Label ID="Label6" runat="server"></asp:Label>
                    </center>
            </div>
        </div>
        <div class="row" style="margin-top:10px;">
            <div class="col-sm-12 mx-auto">
                <div class="">
                    <div class="">
                        <div class="row">
                            <div class="col-sm-8 mx-auto">
                                <center>
                            <h5 class="bookstore-content-text">Books under $100</h5>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:A New ChapterConnectionString %>" SelectCommand="SELECT * FROM [master_book_table] WHERE (([book_price] &gt; @book_price) AND ([book_price] &lt;= @book_price2) AND ([approved] = @approved))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="50" Name="book_price" Type="Decimal" />
                                        <asp:Parameter DefaultValue="100" Name="book_price2" Type="Decimal" />
                                        <asp:Parameter DefaultValue="1" Name="approved" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:GridView class="table table-condensed Grid" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" OnRowDataBound="OnRowDataBound" OnRowCommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <div class="row">
                                                                <div class="col-sm-2">
                                                                    <asp:Image class="img-fluid" ID="Image1" runat="server" />
                                                                </div>
                                                                <div class="col-sm-10">
                                                                    <div class="row">
                                                                        <div class="col-sm-12">
                                                                            <asp:Label ID="Label1" class="bookstore-title-text" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <hr />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-sm-6">
                                                                            Genre:
                                                                <asp:Label ID="Label2" class="bookstore-content-text-2" runat="server" Text='<%# Eval("book_genre") %>' Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                        <div class="col-sm-6">
                                                                            Price($):
                                                                <asp:Label ID="Label3" class="bookstore-content-text-2" runat="server" Text='<%# Eval("book_price") %>' Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-sm-12">
                                                                            Description:
                                                                <asp:Label ID="Label4" class="bookstore-content-text-2" runat="server" Text='<%# Eval("book_description") %>' Font-Size="XX-Large"></asp:Label>
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
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button1" runat="server" Text="Buy" CommandName="Add" CommandArgument='<%#Eval("book_id") %>' style="width:inherit"/>
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button2" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("book_id") %>' style="margin-top:0.5em;width:inherit"/>
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button4" runat="server" Text="Profile" CommandName="Profile" CommandArgument='<%#Eval("author_name") %>' style="margin-top:0.5em;width:inherit"/>
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
        <div class="row">
            <div class="col-sm-12 mx-auto">
                <div class="">
                    <div class="">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h5 class="bookstore-content-text">Books under $50</h5>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:A New ChapterConnectionString %>" SelectCommand="SELECT * FROM [master_book_table] WHERE (([book_price] &gt; @book_price) AND ([book_price] &lt;= @book_price2) AND ([approved] = @approved))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="25" Name="book_price" Type="Decimal" />
                                        <asp:Parameter DefaultValue="50" Name="book_price2" Type="Decimal" />
                                        <asp:Parameter DefaultValue="1" Name="approved" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:GridView class="table table-condensed Grid" ID="GridView2" runat="server" OnRowDataBound="OnRowDataBound2" OnRowCommand="GridView2_RowCommand" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" DataKeyNames="book_id">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <div class="row">
                                                                <div class="col-sm-2">
                                                                    <asp:Image class="img-fluid" ID="Image2" runat="server" />
                                                                </div>
                                                                <div class="col-sm-10">
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <asp:Label ID="Label5" class="bookstore-title-text" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <hr />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-sm-6">
                                                                            Genre:
                                                                            <asp:Label ID="Label8" class="bookstore-content-text-2" runat="server" Text='<%# Eval("book_genre") %>' Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                        <div class="col-sm-6">
                                                                            Price($):
                                                                            <asp:Label ID="Label9" class="bookstore-content-text-2" runat="server" Text='<%# Eval("book_price") %>' Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            Description:
                                                                            <asp:Label ID="Label10" class="bookstore-content-text-2" runat="server" Text='<%# Eval("book_description") %>' Font-Size="XX-Large"></asp:Label>
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
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button3" runat="server" Text="Buy" CommandName="Add" CommandArgument='<%#Eval("book_id") %>' style="width:inherit"/><br />
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button12" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("book_id") %>' style="margin-top:0.5em;width:inherit"/><br />
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button6" runat="server" Text="Profile" CommandName="Profile" CommandArgument='<%#Eval("author_name") %>' style="margin-top:0.5em;width:inherit"/>
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
        <div class="row">
            <div class="col-sm-12">
                <div class="">
                    <div class="">
                        <div class="row">
                            <div class="col">
                                <center>
                                <h5 class="bookstore-content-text">Books under $25</h5>
                                    </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:A New ChapterConnectionString %>" SelectCommand="SELECT * FROM [master_book_table] WHERE (([book_price] &gt;= @book_price) AND ([book_price] &lt;= @book_price2) AND ([approved] = @approved))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="10" Name="book_price" Type="Decimal" />
                                        <asp:Parameter DefaultValue="25" Name="book_price2" Type="Decimal" />
                                        <asp:Parameter DefaultValue="1" Name="approved" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:GridView class="table table-condensed Grid" ID="GridView3" runat="server" OnRowDataBound="OnRowDataBound3" OnRowCommand="GridView3_RowCommand" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource3">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <div class="row">
                                                                <div class="col-sm-2">
                                                                    <asp:Image class="img-fluid" ID="Image3" runat="server" />
                                                                </div>
                                                                <div class="col-sm-10">
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <asp:Label ID="Label11" class="bookstore-title-text" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <hr />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-sm-6">
                                                                            Genre:
                                                           <asp:Label ID="Label12" runat="server" class="bookstore-content-text-2" Text='<%# Eval("book_genre") %>' Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                        <div class="col-sm-6">
                                                                            Price($):
                                                           <asp:Label ID="Label13" runat="server" class="bookstore-content-text-2" Text='<%# Eval("book_price") %>' Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            Description:
                                                           <asp:Label ID="Label14" runat="server" class="bookstore-content-text-2" Text='<%# Eval("book_description") %>' Font-Size="XX-Large"></asp:Label>
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
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button5" runat="server" Text="Buy" CommandName="Add" CommandArgument='<%#Eval("book_id") %>' style="width:inherit"  /><br />
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button8" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("book_id") %>' style="margin-top:0.5em;width:inherit"/><br />
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button9" runat="server" Text="Profile" CommandName="Profile" CommandArgument='<%#Eval("author_name") %>' style="margin-top:0.5em;width:inherit"/>
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
        <div class="row">
            <div class="col-sm-12">
                <div class="">
                    <div class="">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h5 class="bookstore-content-text">Free Books</h5>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:A New ChapterConnectionString %>" SelectCommand="SELECT * FROM [master_book_table] WHERE (([book_price] = @book_price) AND ([approved] = @approved))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="0" Name="book_price" Type="Decimal" />
                                        <asp:Parameter DefaultValue="1" Name="approved" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:GridView class="table table-condensed Grid" ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource4" OnRowDataBound="OnRowDataBound4" OnRowCommand="GridView4_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <div class="row">
                                                                <div class="col-sm-2">
                                                                    <asp:Image class="img-fluid" ID="Image4" runat="server" />
                                                                </div>
                                                                <div class="col-sm-10">
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <asp:Label ID="Label15" class="bookstore-title-text" runat="server" Text='<%# Eval("book_name")%>' Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <hr />
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-sm-6">
                                                                            Genre:
                                                                            <asp:Label ID="Label16" class="bookstore-content-text-2" runat="server" Text='<%# Eval("book_genre")%>' Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                        <div class="col-sm-6">
                                                                            Price($):
                                                                            <asp:Label ID="Label17" class="bookstore-content-text-2" runat="server" Text='FREE' Font-Size="XX-Large"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            Description:
                                                                            <asp:Label ID="Label18" class="bookstore-content-text-2" runat="server" Text='<%# Eval("book_description")%>' Font-Size="XX-Large"></asp:Label>
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
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col">
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button7" runat="server" Text="Add" CommandName="Add" CommandArgument='<%#Eval("book_id") %>' style="width:inherit"/><br />
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button10" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("book_id") %>' style="margin-top:0.5em;width:inherit"/><br />
                                                            <asp:Button class="btn btn-outline-primary btn-lg" ID="Button11" runat="server" Text="Profile" CommandName="Profile" CommandArgument='<%#Eval("author_name") %>' style="margin-top:0.5em;width:inherit"/>
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
