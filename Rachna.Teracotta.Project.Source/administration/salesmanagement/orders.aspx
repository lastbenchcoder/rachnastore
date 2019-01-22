<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.salesmanagement.orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Orders</h1>
                <asp:HiddenField ID="hdnProductId" runat="server" />
                <asp:HiddenField ID="hdnProdId" runat="server" />
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Dashboard</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Sales & Payment</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Manage Orders</a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Store &amp; Orders
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class="form-group">
                            <label class="control-label col-sm-2">Store</label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlStore" runat="server" class="form-control input-sm">
                                    <asp:ListItem>Select..</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Atlease select store"
                                    InitialValue="Select.." ControlToValidate="ddlStore" ValidationGroup="admin">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">First Date</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtStartDate" type="date" runat="server" class="form-control input-sm"></asp:TextBox>
                                <label></label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">End Date</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtEndDate" type="date" runat="server" class="form-control input-sm"></asp:TextBox>
                                <label></label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">Status</label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control input-sm" Width="30%">
                                    <asp:ListItem>Select..</asp:ListItem>
                                </asp:DropDownList>
                                <label></label>
                            </div>
                        </div>
                        <div class="form-actions col-sm-offset-2 col-sm-10">
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-success btn-sm" Text="Search" ValidationGroup="admin" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Orders
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <asp:GridView ID="grdStoreOrders" runat="server" AutoGenerateColumns="False" class="table table-hover table-nomargin table-bordered dataTable grdStoreOrders">
                            <Columns>
                                <asp:BoundField DataField="Order_Id" HeaderText="OrderId" />
                                <asp:ImageField DataImageUrlField="Product_Banner" DataImageUrlFormatString="../../{0}">
                                    <ControlStyle Height="100px" Width="100px" />
                                </asp:ImageField>
                                <asp:BoundField DataField="Customer_Id" HeaderText="CustomerId	" />
                                <asp:BoundField DataField="Customer_Name" HeaderText="CustomerName	" />
                                <asp:BoundField DataField="Order_Qty" HeaderText="OrderQty	" />
                                <asp:BoundField DataField="Order_Size" HeaderText="OrderSize" />
                                <asp:HyperLinkField DataNavigateUrlFields="Product_Id" DataNavigateUrlFormatString="/administration/product/productsdetailstatic.aspx?Productid={0}&derdirect-url=12gdggd787hhgfhgfhgfhgfhg.htm" DataTextField="Product_Title" HeaderText="Product Title" />
                                <asp:BoundField DataField="Order_Date" HeaderText="OrderDate" />
                                <asp:BoundField DataField="Order_Delievery_Date" HeaderText="Delievery Date" />
                                <asp:BoundField DataField="Order_Status" HeaderText="Status" />
                                <asp:HyperLinkField DataNavigateUrlFields="Order_Id" DataNavigateUrlFormatString="/administration/salesmanagement/vorderdetail.aspx?orderId={0}&derdirect-url=12gdggd787hhgfhgfhgfhgfhg.htm" Text="Detail" />
                            </Columns>
                            <EmptyDataTemplate>
                                &nbsp;No Orders found for your search
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <div style="text-align: right; margin-bottom: 15px; margin-right: 15px; margin-top: 15px">
                            <asp:Button ID="btnExport" runat="server" Text="Export To Excel" class="btn btn-primary" OnClick="ExportToExcel" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
