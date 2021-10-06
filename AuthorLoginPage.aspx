<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuthorLoginPage.aspx.cs" Inherits="A_New_Chapter.AuthorLoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10 mx-auto">
                <div class="row" style="margin-top:75px;">
                    <div class="col-md-7" style="background-image: url('images/signup.jpg')">
                    </div>
            <div class="col-md-5 ">
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
                                    <p>Author Name</p>
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
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>
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
                                    <asp:Button class="btn btn-outline-primary btn-lg btn-block" ID="Button2" runat="server" Text="Register Instead" OnClick="Button2_Click" />
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
