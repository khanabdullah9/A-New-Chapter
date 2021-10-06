<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminAuthorManagementPage.aspx.cs" Inherits="A_New_Chapter.AdminAuthorManagementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
                    <!--JQuery to add a search bar to the grid view.-->
<script type="text/javascript">
    $(document).ready(function () {

        //$(document).ready(function () {
        //$('.table').DataTable();
        // });

        $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        //$('.table1').DataTable();
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
        <div class="row">
            <div class="col-md-5 mr-auto">
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                        <h3 class="author-title-text">Author Management</h3>
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
                                        <div class="form-group">
                                            <p>User Name</p>
                                            <div class="input-group">
                                                <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                                <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Status</p>
                                            <div class="input-group">
                                                <asp:TextBox class="form-control" ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox>
                                                <asp:Button class="btn btn-success" ID="Button2" runat="server" Text="Active" OnClick="Button2_Click" />
                                                <asp:Button class="btn btn-warning" ID="Button3" runat="server" Text="Pending" OnClick="Button3_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Full Name</p>
                                            <asp:Label class="author-content-text" ID="Label1" runat="server" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Phone</p>
                                            <asp:Label class="author-content-text" ID="Label2" runat="server" Font-Bold="true"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>City</p>
                                            <asp:Label class="author-content-text" ID="Label3" runat="server" Font-Bold="true"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Reputation Points</p>
                                            <asp:Label class="author-content-text" ID="Label4" runat="server" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <p>Bio</p>
                                            <asp:Label class="author-content-text" ID="Label5" runat="server" Font-Bold="true"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <p>Email</p>
                                            <asp:Label class="author-content-text" ID="Label6" runat="server" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="form-group">
                                         <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button5" runat="server" Text="Block Author" OnClick="Button5_Click" />                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="row">
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <h3 class="author-title-text">List of Authors</h3>
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
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:A New ChapterConnectionString %>" SelectCommand="SELECT * FROM [master_author_table]"></asp:SqlDataSource>
                                        <asp:GridView class="table table-condensed Grid" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_name" DataSourceID="SqlDataSource1">
                                            <Columns>
                                                <asp:BoundField DataField="full_name" HeaderText="Full Name" SortExpression="full_name" />
                                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                                <asp:BoundField DataField="phone" HeaderText="Phone" SortExpression="phone" />
                                                <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                                <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                                <asp:BoundField DataField="author_name" HeaderText="author_name" ReadOnly="True" SortExpression="author_name" />
                                                <asp:BoundField DataField="reputation_points" HeaderText="Points" SortExpression="reputation_points" />
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
