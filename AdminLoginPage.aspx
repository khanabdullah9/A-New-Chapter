<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminLoginPage.aspx.cs" Inherits="A_New_Chapter.AdminLoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-10 mx-auto">
                <div class="row">
                    <div class="col-md-7 ml-auto" >
                        <img src="images/brittney-weng-F2j0fba4Ujg-unsplash.jpg" width="400" style="margin-right:-1000px;"/>
                    </div>
           <div class="col-md-5 mr-auto" style="margin-left:-300px;">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h1 style="font-family:Brush Script MT, Brush Script Std, cursive;color:#0047ff">A New Chapter</h1>
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
                                <div class="form-group">
                                    <p>Admin User Name</p>
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <p>Password</p>
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
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
</asp:Content>
