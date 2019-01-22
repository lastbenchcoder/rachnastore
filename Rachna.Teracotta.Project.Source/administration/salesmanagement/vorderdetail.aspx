<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="vorderdetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.salesmanagement.vorderdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <asp:Button ID="btnEdit" runat="server" Text="Edit Order" class="btn btn-info" OnClick="btnEdit_Click" />
                            &nbsp &nbsp
                            <asp:Button ID="btnGoBack" runat="server" Text="Go Back" class="btn btn-info" OnClick="btnGoBack_Click" />
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
                                     <asp:Label ID="lblOrderStatus" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Comment :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblOrderDetail" runat="server"></asp:Label>                            
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
