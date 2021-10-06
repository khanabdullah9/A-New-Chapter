<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuthorRegisterPage.aspx.cs" Inherits="A_New_Chapter.AuthorRegisterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="margin-top:25px;">
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
                            <div class="col-md-6">
                                Profile Picture<br />
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    Full Name<p style="color:red;display:inline">*</p>
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter your name" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    Email<p style="color:red;display:inline">*</p>
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter your email" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email" ControlToValidate="TextBox4" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    Phone<p style="color:red;display:inline">*</p>
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter your number" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid number" ControlToValidate="TextBox5" ValidationExpression="[0-9]{11}"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">                           
                            <div class="col-md-6">
                                <div class="form-group">
                                    City
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    Pincode
                                    <asp:TextBox class="form-control" ID="TextBox7" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid pin" ControlToValidate="TextBox7" ValidationExpression="^\d{5}(?:[-\s]\d{4})?$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    Country<p style="color:red;display:inline">*</p>
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="United Kingdom (coming soon)" Value="Select" />
                                        <asp:ListItem Text="United States of America" Value="United States of America" />
                                    </asp:DropDownList>
                                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Enter your country" ControlToValidate="DropDownList2" InitialValue="Select"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    State<p style="color:red;display:inline">*</p>
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="Alabama" Value="Alabama" />
                                        <asp:ListItem Text="Alaska" Value="Alaska" />
                                        <asp:ListItem Text="Arizona" Value="Arizona" />
                                        <asp:ListItem Text="Arkansas" Value="Arkansas" />
                                        <asp:ListItem Text="California" Value="California" />
                                        <asp:ListItem Text="Colorado" Value="Colorado" />
                                        <asp:ListItem Text="Connecticut" Value="Connecticut" />
                                        <asp:ListItem Text="Delaware" Value="Delaware" />
                                        <asp:ListItem Text="Florida" Value="Florida" />
                                        <asp:ListItem Text="Georgia" Value="Georgia" />
                                        <asp:ListItem Text="Hawaii" Value="Hawaii" />
                                        <asp:ListItem Text="Idaho" Value="Idaho" />
                                        <asp:ListItem Text="Illinois" Value="Illinois" />
                                        <asp:ListItem Text="Indiana" Value="Indiana" />
                                        <asp:ListItem Text="Iowa" Value="Iowa" />
                                        <asp:ListItem Text="Kansas" Value="Kansas" />
                                        <asp:ListItem Text="Kentucky" Value="Kentucky" />
                                        <asp:ListItem Text="Louisiana" Value="Louisiana" />
                                        <asp:ListItem Text="Maine" Value="Maine" />
                                        <asp:ListItem Text="Maryland" Value="Maryland" />
                                        <asp:ListItem Text="Massachusetts" Value="Massachusetts" />
                                        <asp:ListItem Text="Michigan" Value="Michigan" />
                                        <asp:ListItem Text="Minnesota" Value="Minnesota" />
                                        <asp:ListItem Text="Mississipi" Value="Mississipi" />
                                        <asp:ListItem Text="Missouri" Value="Missouri" />
                                        <asp:ListItem Text="Montana" Value="Montana" />
                                        <asp:ListItem Text="Nebraska" Value="Nebraska" />
                                        <asp:ListItem Text="Nevada" Value="Nevada" />
                                        <asp:ListItem Text="New Hampshire" Value="New New" />
                                        <asp:ListItem Text="New Jersey" Value="New New" />
                                        <asp:ListItem Text="New Mexico" Value="New Mexico"  />
                                        <asp:ListItem Text="New York" Value="New York" />
                                        <asp:ListItem Text="North Carolina" Value="North Carolina" />
                                        <asp:ListItem Text="North Dakota" Value="North Dakota" />
                                        <asp:ListItem Text="Ohio" Value="Ohio" />
                                        <asp:ListItem Text="Oklahoma" Value="Oklahoma" />
                                        <asp:ListItem Text="Oregon" Value="Oregon" />
                                        <asp:ListItem Text="Pennsylvania" Value="Pennsylvania" />
                                        <asp:ListItem Text="Rhode Island" Value="Rhode Island" />
                                        <asp:ListItem Text="South Carolina" Value="South Carolina" />
                                        <asp:ListItem Text="South Dakota" Value="South Dakota" />
                                        <asp:ListItem Text="Tennesse" Value="Tennesse" />
                                        <asp:ListItem Text="Texas" Value="Texas" />
                                        <asp:ListItem Text="Utah" Value="Utah" />
                                        <asp:ListItem Text="Vermont" Value="Vermont" />
                                        <asp:ListItem Text="Virginia" Value="Virginia" />
                                        <asp:ListItem Text="Washington" Value="Washington" />
                                        <asp:ListItem Text="West Virginia" Value="West Virginia" />
                                        <asp:ListItem Text="Wisconsin" Value="Wisconsin" />
                                        <asp:ListItem Text="Wyoming" Value="Wyoming" />
                                        <asp:ListItem Text="Union Territory" Value="Union Territory" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter your state" ControlToValidate="DropDownList1" InitialValue="Select"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    Full Address
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    Bio<p style="color:red;display:inline">*</p>
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Say something about yourself" ControlToValidate="TextBox9"></asp:RequiredFieldValidator>
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
                                    Author Name(user_name)<p style="color:red;display:inline">*</p>
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Author must have a author name" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    Password<p style="color:red;display:inline">*</p>
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter password" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    Confirm Password<p style="color:red;display:inline">*</p>
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter password" ControlToValidate="TextBox10"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ForeColor="Red" ID="CompareValidator1" runat="server" ErrorMessage="Passwords must match" ControlToValidate="TextBox10" ControlToCompare="TextBox2"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Register" OnClick="Button1_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8 mx-auto">
                <center>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="false">Already an Author?</asp:LinkButton>
                    </center>
            </div>
        </div>
    </div>
</asp:Content>
