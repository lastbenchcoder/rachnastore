﻿<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="newproducts.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.product.newproducts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>New Product</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Catalog</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/categories/category.aspx?redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979">Manage Products</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/categories/category.aspx?redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979">Add New Product</a>
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
                            <i class="fa fa-th-list"></i>Basic Detail</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Select Category :</label>
                                <div class="col-sm-4">
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server"
                                        ErrorMessage="Select Category/Sub Category" InitialValue="Select.." ControlToValidate="ddlCategory"
                                        ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Title</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>
                                    <label></label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Title" ControlToValidate="txtTitle" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Description</label>
                                <div class="col-sm-10">
                                    <cc1:Editor ID="txtDescription" runat="server" Width="100%" Height="300px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Description" ControlToValidate="txtDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Specification</label>
                                <div class="col-sm-10">
                                    <cc1:Editor ID="txtSpecification" runat="server" Width="100%" Height="300px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Specifiction" ControlToValidate="txtSpecification" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Price Detail</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Market Price</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtMarketPrice" runat="server" class="form-control txtMarketPrice"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Market Price(If no mention 0)" ControlToValidate="txtMarketPrice" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Quantity</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtQuantity" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Quantity" ControlToValidate="txtQuantity" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Qty Low Alert</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtAlert" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Quantity Alert" ControlToValidate="txtAlert" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Discount(%)</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtDiscount" runat="server" class="form-control" TextMode="Number"
                                        OnTextChanged="txtDiscount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Discount If no discount enter 0" ControlToValidate="txtDiscount" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Our Price</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtOurPrice" runat="server" class="form-control txtOurPrice" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" runat="server" placeholder="Our Price (Depends on Discount, If no discount please enter 0)"
                                        ErrorMessage="Enter Our Price" ControlToValidate="txtOurPrice" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Shipping Charge :</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtShippingCharge" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="Red" runat="server" ErrorMessage="Enter Shipping Charge" ControlToValidate="txtShippingCharge" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Size And Delivery</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Delivered In</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtProductDelieveredIn" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Delievery time" ControlToValidate="txtProductDelieveredIn" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Max Purchase</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtMaxPurchase" runat="server" class="form-control" TextMode="Number" placeholder="Max Item Customer can purchase."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Max Purchase Product" ControlToValidate="txtMaxPurchase" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group">
                                        <label for="txtFirstName" class="control-label col-sm-2">Product Has Size</label>
                                        <div class="col-sm-4">
                                            <asp:RadioButtonList ID="rdbHasSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbHasSize_SelectedIndexChanged">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <asp:Panel ID="pnlSize" runat="server" Visible="false">
                                        <div class="form-group">
                                            <label for="txtFirstName" class="control-label col-sm-2">Size : </label>
                                            <div class="col-sm-4">
                                                <asp:TextBox ID="txtSize" runat="server" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Enter Size, Size Detail Should Be comma seperated." ControlToValidate="txtSize" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Zip Codes</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtZipcode" runat="server" class="form-control" placeholder="Zip Code (Product Will Not Be available to these Zipcodes)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Rating from Store</label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtRating" runat="server" class="form-control" Text="0"
                                        placeholder="Enter Number 1 to 5"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnProceedToSubmit" runat="server" Text="Submit" class="btn btn-success hidden-print"
                                    ValidationGroup="admin" OnClick="btnProceedToSubmit_Click" />
                                &nbsp;&nbsp;
                                <a href="/administration/product/products.aspx?redirecturl=admin-Product-rachna-teracotta" class="btn btn-primary">Cancel</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
