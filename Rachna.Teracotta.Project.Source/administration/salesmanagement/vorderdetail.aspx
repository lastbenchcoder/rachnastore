<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="vorderdetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.salesmanagement.vorderdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-body">
            <div style="margin-left: 10px; margin-top: 10px; margin-bottom: 10px">
                <h3>Customer Orders</h3>
                <p>
                    Process order to further steps from here.
                </p>
                <div class="row">
                    <div class="col-md-8">
                        &nbsp;
                    </div>
                    <div class="col-md-4">
                        &nbsp;
                    </div>
                </div>
            </div>
            <div class="padding-md">
                <div class="panel panel-default">
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
                                <td class="auto-style2">&nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1">Payment Mode :</td>
                                <td class="auto-style3">&nbsp;
                                 <asp:Label ID="lblPaymentMode" runat="server"></asp:Label>
                                    &nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
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
                                    <asp:Label ID="lblOrderStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1">Order Detail:</td>
                                <td class="auto-style3">
                                    <asp:Label ID="lblOrderDetail" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style3">
                                    <asp:Button ID="btnGoBack" runat="server" Text="Go Back" class="btn btn-info" OnClick="btnGoBack_Click" />
                                    &nbsp;&nbsp;|&nbsp;&nbsp;
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit Order" class="btn btn-info" OnClick="btnEdit_Click" />
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
        </div>
    </div>
</asp:Content>
