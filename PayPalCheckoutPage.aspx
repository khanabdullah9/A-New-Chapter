<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PayPalCheckoutPage.aspx.cs" Inherits="A_New_Chapter.PayPalCheckoutPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" >
        <div class="row" style="margin-top: 10px">
            <div class="col-md-12 mx-auto">               
                        <div class="row">
                            <div class="col">                                                                                                     
                                        <div class="row">
                                            <div class="col-md-6 mr-auto">
                                                <div class="card">
                                                    <div class="card-body my-image">
                                                        <%--Image will be placed here--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
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
                                                        <%--Hidden field section--%>
                                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                                        <asp:HiddenField ID="HFOrderID" runat="server" />
                                                        <asp:HiddenField ID="HFStatus" runat="server" />
                                                        <asp:HiddenField ID="HFTransID" runat="server" />
                                                        <asp:HiddenField ID="HFUserName" runat="server" />
                                                        <asp:HiddenField ID="HFBookName" runat="server" />
                                                        <%--Hidden field section--%>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:A New ChapterConnectionString %>" SelectCommand="SELECT * FROM [checkout] WHERE ([user_name] = @user_name)">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="user_name" SessionField="user_name" Type="String" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                        <asp:GridView class="table table-condensed Grid" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1"  ShowFooter="False" OnRowCommand="GridView1_RowCommand">
                                                            <Columns>
                                                                <asp:BoundField DataField="book_id" HeaderText="ID" SortExpression="book_id" />
                                                                <asp:BoundField DataField="book_name" HeaderText="Name" SortExpression="book_name" />
                                                                <%--<asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                                <asp:BoundField DataField="book_price" HeaderText="Price" SortExpression="book_price" />
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <div class="container-fluid">
                                                                            <div class="row">
                                                                                <div class="col">
                                                                                    <asp:Button class="btn btn-outline-danger" ID="Button4" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%#Eval("book_id") %>'/>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>                                                          
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-10">
                                                        <asp:Label class="float-right" ID="LabelPrice" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4 mx-auto">
                                                        <center>
                                    </center>
                                                    </div>
                                                </div>
                                                <!--PayPal button integration-->
                                                <div class="row" style="margin-top: 10px;">
                                                    <div class="col-md-5 mx-auto">
                                                        <div class="form-group">
                                                            <center>                                                                          
                                     <div  id="paypal-button-container">
                                            <!--paypal button-->
                                        </div>
                               <i>Powered by </i> <img src="images/paypal.png" width="60" />                                       
                                        <!--Paypal script-->
                                            <script src="https://www.paypal.com/sdk/js?client-id=AZxnFW8ZfWxrS2qyKY8f5YEF3qwI2uf3285tbmn3ove9GqZmWIZF7hp7M8URLW60wTU_kCudACQcskBM&currency=USD&disable-funding=credit,card"></script>
                                             <script>                                                 
                                                 var hf_price = $("#" + '<%= HiddenField1.ClientID %>').val();
                                                 var csrftoken = getCookie('csrftoken');
                                                 var payment_method = 'PayPal';
                                                 //Method from django official website that creates csrf token
                                                 function getCookie(name) {
                                                     let cookieValue = null;
                                                     if (document.cookie && document.cookie !== '') {
                                                         const cookies = document.cookie.split(';');
                                                         for (let i = 0; i < cookies.length; i++) {
                                                             const cookie = cookies[i].trim();
                                                             // Does this cookie string begin with the name we want?
                                                             if (cookie.substring(0, name.length + 1) === (name + '=')) {
                                                                 cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                                                                 break;
                                                             }
                                                         }
                                                     }
                                                     return cookieValue;
                                                 }
                                        </script>
                                                                <%--Paypal script--%>
                                        <script>
                                            // Render the PayPal button into #paypal-button-container

                                            paypal.Buttons({
                                                
                                                // Set up the transaction
                                                createOrder: function (data, actions) {
                                                    return actions.order.create({
                                                        purchase_units: [{
                                                            amount: {
                                                                value: hf_price//value coming from code behind file
                                                            }
                                                        }]
                                                    });
                                                },

                                                // Finalize the transaction
                                                onApprove: function (data, actions) {
                                                    return actions.order.capture().then(function (orderData) {
                                                        // Successful capture! For demo purposes:
                                                        console.log('Capture result', orderData, JSON.stringify(orderData, null, 2));
                                                        var transaction = orderData.purchase_units[0].payments.captures[0];                                        
                                                        console.log(transaction);
                                                        console.log(transaction.id);
                                                        console.log(transaction.status)                                                        

                                                        var hf_TransId = $("#" + '<%= HFTransID.ClientID%>').val();
                                                        var hf_Status = $("#" + '<%= HFStatus.ClientID%>').val();
                                                        var hf_OrderID = $("#" + '<%= HFOrderID.ClientID%>').val();
                                                        var hf_UserName = $("#" + '<%=HFUserName.ClientID%>').val();
                                                        var hf_bookName = $("#" + '<%= HFBookName.ClientID %>').val();
                                                        //My code starts here                                                        
                                                        if (transaction.id != null) {//this means that transaction has occured
                                                            alert("Order id= " + hf_OrderID + "\nTransaction Id= " + transaction.id + "\nPrice= " + hf_price + "\n User Name= " + hf_UserName + "\nPAYMENT SUCCESSFULLY!");
                                                            jsSendTrans();
                                                        }
                                                        function jsSendTrans() {
                                                            PageMethods.Send_TransactionDetails(hf_OrderID, transaction.id, hf_price, hf_UserName, hf_bookName, success, failure);                                                           
                                                        }
                                                        function success(result) {
                                                            console.log(result)
                                                        }
                                                        function failure(err) {
                                                            alert(err);
                                                        }
                                                        var tID = transaction.id;
                                                        var sta = statusp;
                                                    });
                                                }
                                            }).render('#paypal-button-container');                                            
                                        </script>
                                        </center>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                    </div>
                                                    <div class="col">
                                            <asp:ScriptManager id="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager><!--Do not delete-->
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
    </div>
</asp:Content>
