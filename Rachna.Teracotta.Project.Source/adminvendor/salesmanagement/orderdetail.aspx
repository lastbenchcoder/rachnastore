<%@ Page Title="" Language="C#" MasterPageFile="~/adminvendor/Home.Master" AutoEventWireup="true" CodeBehind="orderdetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.adminvendor.salesmanagement.orderdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%

    %>
    <div class="padding-md">
        <div class="panel panel-default">
            <div class="row">
                <div class="col-md-8">
                    <h3>Customer Orders</h3>
                    <p>
                        Process order to further steps from here.
                    </p>
                </div>
                <div class="col-md-4">
                    <div style="float: right; margin-top: 10px; margin-right: 20px">
                        <a href="#" data-toggle="modal" data-target="#modalOrderHistory" style="color: darkblue; font-weight: bolder">View Order History</a>
                    </div>
                </div>
            </div>
            <div style="margin-left: 20px">
                <table class="nav-justified">
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2"><b>Title</b></td>
                        <td class="auto-style3">&nbsp;&nbsp;
                                    <asp:Label ID="lblProduct_Title" runat="server" Font-Bold="True" ForeColor="#336600"></asp:Label>
                            <asp:HiddenField ID="hdnOrderId" runat="server" />
                            <asp:HiddenField ID="hdnProductId" runat="server" />
                            <asp:HiddenField ID="hdnAvailableSize" runat="server" />
                            <asp:HiddenField ID="hdnCustId" runat="server" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;&nbsp;
                                    <asp:Image ID="imgProductBanner" runat="server" Width="100px" Height="100px"></asp:Image>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><b>Size:</b> </td>
                        <td class="auto-style3">&nbsp;&nbsp;
                    <asp:Label ID="lblOrder_Size" runat="server"></asp:Label>
                            &nbsp;
                                    <a href="#" data-toggle="modal" data-target="#modalSize"><i class="fa fa-edit fa-lg"></i></a>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Enter Size" InitialValue="0" ControlToValidate="txtSize" ValidationGroup="admin"></asp:RequiredFieldValidator>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><b>Price:</b></td>
                        <td class="auto-style3">&nbsp;&nbsp;
                 Rs:&nbsp;<asp:Label ID="lblProduct_Price" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><b>Quantity :</b></td>
                        <td class="auto-style3">&nbsp;
                 <asp:Label ID="lblOrder_Qty" runat="server"></asp:Label>
                            items&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Total Price :</td>
                        <td class="auto-style3">&nbsp;
                 <asp:Label ID="lblOrder_Price" runat="server"></asp:Label>
                            &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Payment Mode :</td>
                        <td class="auto-style3">&nbsp;
                 <asp:Label ID="lblPaymentMode" runat="server"></asp:Label>
                            &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Status :</td>
                        <td class="auto-style3">&nbsp;
                 <asp:Label ID="lblOrder_Status" runat="server"></asp:Label>
                            &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">&nbsp;
                 <asp:Label ID="lblOrder_Delivery" runat="server"></asp:Label>
                            &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><b>Customer Detail:</b></td>
                        <td class="auto-style3">--------------------------------------------------------------------------------------------</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">
                            <asp:Label ID="lblCustomerName" runat="server"></asp:Label><br />
                            <asp:Label ID="lblAddress1" runat="server"></asp:Label><br />
                            <asp:Label ID="lblAddress2" runat="server"></asp:Label><br />
                            <asp:Label ID="lblCity" runat="server"></asp:Label><br />
                            <asp:Label ID="lblState" runat="server"></asp:Label><br />
                            <asp:Label ID="lblCountry" runat="server"></asp:Label><br />
                            <asp:Label ID="lblZipCode" runat="server"></asp:Label><br />
                            <span>--------------------------------------------------------------------------------------------</span><br />
                            <b>Phone Number: </b>
                            <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label><br />
                            <b>Email Id: </b>
                            <asp:Label ID="lblEmailId" runat="server"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Order Status:</td>
                        <td class="auto-style3">
                            <asp:DropDownList ID="ddlSorderStatus" runat="server" class="form-control" Width="40%" AutoPostBack="true" OnSelectedIndexChanged="ddlSorderStatus_SelectedIndexChanged">
                                <asp:ListItem>Select..</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Select Order Status" InitialValue="Select.." ControlToValidate="ddlSorderStatus" ValidationGroup="admin"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <asp:Panel ID="pnlDeleveryTeam" runat="server" Visible="false">
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style3">
                                <asp:DropDownList ID="ddlDeleveryMethod" runat="server" class="form-control" Width="40%" AutoPostBack="true" OnSelectedIndexChanged="ddlDeleveryMethod_SelectedIndexChanged">
                                    <asp:ListItem>Select..</asp:ListItem>
                                </asp:DropDownList>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="Select Delevery Method" InitialValue="Select.." ControlToValidate="ddlDeleveryMethod" ValidationGroup="admin"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style3">
                                <asp:DropDownList ID="ddlDelieveryTeam" runat="server">
                                    <asp:ListItem>Select..</asp:ListItem>
                                </asp:DropDownList>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="Select Delevery Team" InitialValue="Select.." ControlToValidate="ddlDelieveryTeam" ValidationGroup="admin"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                   
                    <tr>
                        <td class="auto-style1">Order Process Detail :</td>
                        <td class="auto-style1">&nbsp;                 
                                    <asp:TextBox ID="txtOrderDescription" runat="server" TextMode="MultiLine" class="form-control" Width="40%"></asp:TextBox>
                            &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Enter Process Description" ControlToValidate="txtOrderDescription" ValidationGroup="admin"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" ValidationGroup="admin" class="btn btn-primary" />
                            &nbsp;&nbsp;
                                    |
                                    &nbsp;&nbsp;
                                    <asp:Button ID="Button2" runat="server" Text="Go Back" class="btn" OnClick="Button2_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style3">&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <!--Modal-->
    <div class="modal fade" id="modalSize">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Select Size</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label data-toggle="tooltip" title="Enter Category Title">Available Size&nbsp;&nbsp;<i class="fa fa-question-circle"></i></label>
                        <asp:Label ID="lblAvailableSize" runat="server"></asp:Label>
                        <label>&nbsp;</label>
                    </div>
                    <div class="form-group">
                        <label data-toggle="tooltip" title="Enter Size">Size&nbsp;&nbsp;<i class="fa fa-question-circle"></i></label>
                        <asp:TextBox ID="txtSize" runat="server" class="form-control input-sm" Width="30%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Size" ControlToValidate="txtSize" ValidationGroup="adminSize"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-sm btn-success" data-dismiss="modal" aria-hidden="true">Close</button>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="adminSize" OnClick="btnSubmit_Click" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <!--Modal-->
    <div class="modal fade" id="modalOrderHistory">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Product History</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:GridView ID="grdOrderHistory" runat="server" AutoGenerateColumns="false" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="OrderHistory_Description" HeaderText="Reason" />
                                <asp:BoundField DataField="OrderHistory_Status" HeaderText="Status" />
                                <asp:BoundField DataField="OrderHistory_CreatedDate" HeaderText="Date" />
                            </Columns>
                            <EmptyDataTemplate>
                                There are no sliders founnd.
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-sm btn-success" data-dismiss="modal" aria-hidden="true">Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
</asp:Content>
