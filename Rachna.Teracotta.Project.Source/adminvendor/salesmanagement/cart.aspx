<%@ Page Title="" Language="C#" MasterPageFile="~/adminvendor/Home.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.adminvendor.salesmanagement.cart" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Carts</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Sales & Payment</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Manage Carts</a>
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
                            <i class="fa fa-th-list"></i>Carts</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Start Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtStartDate" type="date" runat="server" class="form-control input-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">End Date</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtEndDate" type="date" runat="server" class="form-control input-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Status</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control input-sm" Width="30%">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-success btn-sm" Text="Search" ValidationGroup="admin" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnExport" runat="server" Text="Export To Excel" class="btn btn-primary" OnClick="ExportToExcel" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Carts
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <asp:GridView ID="grdStoreCart" runat="server" AutoGenerateColumns="False" class="table table-hover table-nomargin table-bordered dataTable dataTable-tools">
                            <Columns>
                                <asp:BoundField DataField="Cart_Id" HeaderText="CartId" />
                                <asp:ImageField DataImageUrlField="Product_Banner" DataImageUrlFormatString="../../{0}">
                                    <ControlStyle Height="100px" Width="100px" />
                                </asp:ImageField>
                                <asp:BoundField DataField="Customer_Id" HeaderText="CustomerId	" />
                                <asp:BoundField DataField="Customer_Name" HeaderText="CustomerName	" />
                                <asp:BoundField DataField="Cart_Qty" HeaderText="Qty	" />
                                <asp:BoundField DataField="Cart_Size" HeaderText="Size" />
                                <asp:HyperLinkField DataNavigateUrlFields="Product_Id" DataNavigateUrlFormatString="/administration/product/productsdetailstatic.aspx?Productid={0}" DataTextField="Product_Title" HeaderText="Product Title" />
                                <asp:BoundField DataField="DateCreated" HeaderText="Date" />
                                <asp:BoundField DataField="Cart_Status" HeaderText="Status" />
                            </Columns>
                            <EmptyDataTemplate>
                                &nbsp;No Carts found for your search
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
