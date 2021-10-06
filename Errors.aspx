<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Errors.aspx.cs" Inherits="A_New_Chapter.Errors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="margin-top:50px;">
            <div class="col-md-2 mx-auto">
                <p>
                    <%--<img src="images/error.png" width="200"/>--%>
                    <img src="images/error2.jfif" width="200" />
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8 mx-auto">
                <h3>
                     An unkown error has occured. We are aware of it and the IT team is currently 
                                     <center>working on this issue. Sorry for the inconvinience caused.</center>
                                       <center>Try to reconnect after some time.</center>
                </h3>
            </div>
        </div>
    </div>
</asp:Content>
