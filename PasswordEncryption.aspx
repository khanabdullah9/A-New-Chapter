<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PasswordEncryption.aspx.cs" Inherits="A_New_Chapter.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="form-control">
                 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <asp:Button class="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Encrypt" OnClick="Button1_Click" />
        </div>
        <div class="col-md-3">
            <asp:Button class="btn btn-warning btn-lg" ID="Button2" runat="server" Text="Decrypt" OnClick="Button2_Click" />
        </div>
    </div> 
    <div class="row">
         <div class="col-md-10 mx-auto">
             <asp:Label ID="Label1" runat="server" ></asp:Label>
         </div>
     </div> 
    <div class="row">
        <div class="col">
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-md-10 mx-auto">
             <asp:Label ID="Label2" runat="server" ></asp:Label>
        </div>
    </div>
</asp:Content>
