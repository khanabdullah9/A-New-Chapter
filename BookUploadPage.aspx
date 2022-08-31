<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookUploadPage.aspx.cs" Inherits="A_New_Chapter.BookUploadPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OpenNewWind() {
            window.open("SetPrice.html","_blank","toolbar=yes,scrollbars=no,resizable=no,width=500,height=500");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 mx-auto">
            </div>
        </div>
        <div class="row">
            <div class="col-md-8 mx-auto">
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
                            <div class="col-md-4">
                                <div class="form-group">
                                    Book File<p style="color:red;display:inline">*</p>
                                <asp:FileUpload ID="FileUpload2" runat="server" tooltip="Valid file extention: .txt | Valid file size: (max 2MB)"/>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="A book without content?" ControlToValidate="FileUpload2"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                Book Image<p style="color:red;display:inline">*</p>
                                <asp:FileUpload ID="FileUpload1" runat="server" tooltip="Valid file extention: .jpg,.png,.bmp | Valid file size: (max 2MB)"/>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ErrorMessage="A book must have an attractive image" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    author_name
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    Book Name<p style="color:red;display:inline">*</p>
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Nameless book?" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    Book Genre<p style="color:red;display:inline">*</p>
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Genres help your book reach readers quickly" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    Book Price<p style="color:red;display:inline">*</p>
                                    <div class="input-group">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:Button class="btn btn-secondary btn-sm" ID="Button2" runat="server" Text="?" OnClientCLick="OpenNewWind()" CausesValidation="false"/>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Don't be so generous" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Set price according to you repuatation points" ControlTovalidate="TextBox3"  Type="Integer" ForeColor="Red" ></asp:RangeValidator>
                                </div>
                                    </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    Book Description<p style="color:red;display:inline">*</p>
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Describe your book" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 mx-auto">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                <asp:Label ID="Label1" runat="server" Text="Your book has been uploaded successfully, a team of professionals is reviewing your content.<br/>Your book will be added within 48 hours.<br/>If your book is not available on the bookstore page contact us at anewchapter96@gmail.com" ForeColor="Blue"></asp:Label>
                            </center>
                                    </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
