<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="A_New_Chapter.test1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <asp:TextBox class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:Button class="btn btn-primary " ID="Button1" runat="server" Text="ComputeSHA256Hash" OnClick="Button1_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:Label ID="Label1" runat="server" ></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
