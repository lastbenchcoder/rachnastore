<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="topeight.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.home.topeight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Top Eight Products</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/store.aspx?redirecturl=admin-store-rachna-teracotta">Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/store.aspx?redirecturl=admin-store-rachna-teracotta">Top Eight Products</a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <div class="row margin-top">
            <div class="col-sm-12">
                <div class="alert alert-info">
                    <h4>Quick Information:</h4>
                    <ol>
                        <li>In this section, you can add only 8 products for specific feature.</li>
                        <li>Please delete existing items to add new items to the section.</li>
                        <li>Entered Product Should be in Published Status.</li>
                        <li>Product will be assigned to specific feature, No single product should be allowed to multiple feature.</li>
                    </ol>
                </div>
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
                            <i class="fa fa-th-list"></i>Select Top Eight Products

                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class="form-group col-lg-3" style="margin-top: 10px">
                            <label>Enter Product ID</label>
                            <asp:TextBox ID="txtProductSearch" runat="server" class="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                ErrorMessage="Enter Product Id" ControlToValidate="txtProductSearch" ValidationGroup="prdSearch">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-lg-3" style="margin-top: 32px">
                            <label>&nbsp;</label>
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-primary" Text="Search" ValidationGroup="prdSearch" />
                            <label>&nbsp;</label>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="pnlProduct" runat="server" Visible="false">
                <div class="col-sm-12">
                    <div class="box box-color box-bordered">
                        <div class="box-title">
                            <h3>
                                <i class="fa fa-table"></i>
                                Product Detail
                            </h3>
                        </div>
                        <div class="box-content nopadding">
                            <div class="box-content nopadding">
                                <div class='form-horizontal form-striped'>
                                    <div class="form-group">
                                        <label for="txtFirstName" class="control-label col-sm-2">&nbsp;</label>
                                        <div class="col-sm-10">
                                            <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtFirstName" class="control-label col-sm-2">Product Id</label>
                                        <div class="col-sm-10">
                                            <asp:Literal ID="lblId" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtFirstName" class="control-label col-sm-2">Product Title</label>
                                        <div class="col-sm-10">
                                            <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="form-actions col-sm-offset-2 col-sm-10 pull-right">
                                        <asp:Button ID="btnAddToFeature" runat="server" OnClick="btnAddToEights_Click" class="btn btn-primary" Text="Add This" ValidationGroup="feature" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Top Eight Products
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <asp:GridView ID="grdPrdSlider" runat="server" ClientIDMode="Static" class="table table-bordered table-condensed table-hover table-striped" Width="95%" Style="margin-left: 10px" OnRowDeleting="OnRowDeleting" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" />
                                <asp:BoundField DataField="Title" HeaderText="Title" />
                                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" />
                                <asp:BoundField DataField="DateUpdated" HeaderText="DateUpdated" />
                                <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" />
                            </Columns>
                            <EmptyDataTemplate>
                                There are no Products found.
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
