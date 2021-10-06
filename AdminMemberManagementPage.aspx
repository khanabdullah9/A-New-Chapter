<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminMemberManagementPage.aspx.cs" Inherits="A_New_Chapter.AdminMemberManagementPage" %>

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
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3 class="author-title-text">Memeber Management</h3>
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
                                    <p style="margin-bottom: -20px">User Name</p>
                                    </br>
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <p style="margin-bottom: -20px">Status</p>
                                    </br>
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox>
                                        <asp:Button class="btn btn-success" ID="Button2" runat="server" Text="Active" OnClick="Button2_Click" />
                                        <asp:Button class="btn btn-warning" ID="Button3" runat="server" Text="Pause" OnClick="Button3_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <p>Full Name</p>
                                    <asp:Label class="author-content-text" ID="Label4" runat="server" Font-Bold="true"></asp:Label>
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
                                <p>Email</p>
                                    <asp:Label class="author-content-text" ID="Label1" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button5" runat="server" Text="Block Member" OnClick="Button5_Click" />
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
                                            <h3 class="author-title-text">List Of Users</h3>
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
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:A New ChapterConnectionString %>" SelectCommand="SELECT * FROM [master_user_table]"></asp:SqlDataSource>
                                        <asp:GridView class="table table-condensed Grid" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="user_name" DataSourceID="SqlDataSource1">
                                            <Columns>
                                                <asp:BoundField DataField="full_name" HeaderText="Full Name" SortExpression="full_name" />
                                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                                <asp:BoundField DataField="phone" HeaderText="Phone" SortExpression="phone" />
                                                <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                                <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                                <asp:BoundField DataField="user_name" HeaderText="user_name" ReadOnly="True" SortExpression="user_name" />
                                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
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
