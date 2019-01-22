<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="orderdetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.salesmanagement.orderdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Order Information</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">DashBoard</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Sales & Payment</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/salesmanagement/orders.aspx?id=jhgj657657HGH.htm">Manage Orders</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">
                        <asp:Label ID="lblBcTitle" runat="server"></asp:Label></a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <asp:Panel ID="pnlErrorMessage" class="page-header" runat="server" Visible="false" Style="margin-top: 10px">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </asp:Panel>


        <div class="row">
            <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Order Detail</h3>
                        <asp:HiddenField ID="hdnAdminId" runat="server" />
                        <div class="pull-right">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" ValidationGroup="admin" class="btn btn-primary" />
                            &nbsp &nbsp                       
                        <a href="#" data-toggle="modal" data-target="#modalOrderHistory" class="btn btn-info">Order History</a>
                            &nbsp &nbsp
                       <asp:Button ID="Button2" runat="server" Text="Go Back" class="btn" OnClick="Button2_Click" />
                            &nbsp &nbsp
                        </div>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>&nbsp;</b></label>
                                <div class="col-sm-4">
                                    <asp:Image ID="imgProductBanner" runat="server" Width="100px" Height="100px"></asp:Image>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Product Title : </b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblProduct_Title" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnOrderId" runat="server" />
                                    <asp:HiddenField ID="hdnProductId" runat="server" />
                                    <asp:HiddenField ID="hdnAvailableSize" runat="server" />
                                    <asp:HiddenField ID="hdnCustId" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Size Selected:</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblOrder_Size" runat="server"></asp:Label>
                                    &nbsp;
                                    <a href="#" data-toggle="modal" data-target="#modalSize"><i class="fa fa-edit fa-lg"></i></a>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Enter Size"
                                        InitialValue="0" ControlToValidate="txtSize" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Order Id & Code :</b></label>
                                <div class="col-sm-4">
                                    Order Id :
                                    <asp:Label ID="lblOrderId" runat="server"></asp:Label>
                                    &nbsp;&nbsp;
                                   Order Code :
                                    <asp:Label ID="lblOrderCode" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Price :</b></label>
                                <div class="col-sm-4">
                                    Rs:&nbsp;<asp:Label ID="lblProduct_Price" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Quantity :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblOrder_Qty" runat="server"></asp:Label>
                                    items&nbsp;&nbsp;
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Total Price:</b></label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblOrder_Price" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Status:</b></label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblOrder_Status" runat="server"></asp:Label>
                                    <asp:Label ID="lblOrder_Delivery" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Payment Mode :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblPaymentMode" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Customer Detail</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>FullName :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Address :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                                    <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>City :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblCity" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>State :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblState" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Country:</b></label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Zip Code:</b></label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblZipCode" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Phone :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblPhoneNumber" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Email :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Edit Order</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Select Status :</b></label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlSorderStatus" runat="server" class="form-control" Width="40%"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlSorderStatus_SelectedIndexChanged">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server"
                                        ErrorMessage="Select Order Status" InitialValue="Select.."
                                        ControlToValidate="ddlSorderStatus" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <asp:Panel ID="pnlDeleveryTeam" runat="server" Visible="false">
                                <div class="form-group">
                                    <label for="txtFirstName" class="control-label col-sm-2"><b>Delivery Method :</b></label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlDeleveryMethod" runat="server" class="form-control" Width="40%"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlDeleveryMethod_SelectedIndexChanged">
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="Select Delevery Method" InitialValue="Select.."
                                            ControlToValidate="ddlDeleveryMethod" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtFirstName" class="control-label col-sm-2"><b>Delivery Team :</b></label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlDelieveryTeam" runat="server" class="form-control" Width="40%">
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="Select Delevery Team" InitialValue="Select.."
                                            ControlToValidate="ddlDelieveryTeam" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Comment :</b></label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtOrderDescription" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Enter Process Description"
                                        ControlToValidate="txtOrderDescription" ValidationGroup="admin"></asp:RequiredFieldValidator></td>                               
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
