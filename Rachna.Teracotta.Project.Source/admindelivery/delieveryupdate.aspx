<%@ Page Title="" Language="C#" MasterPageFile="~/admindelivery/Home.Master" AutoEventWireup="true" CodeBehind="delieveryupdate.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.admindelivery.delieveryupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Update Delievery</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/admindelivery/deliveryhome.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <asp:label id="lblBCTitle" runat="server" text=""></asp:label>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <asp:panel id="pnlErrorMessage" class="page-header" runat="server" visible="false" style="margin-top: 10px">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </asp:panel>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Product Detail
                            <asp:hiddenfield Id="hdnDelId" runat="server"></asp:hiddenfield>
                            <asp:hiddenfield Id="hdnOrderId" runat="server"></asp:hiddenfield>
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class="box-content nopadding">
                            <div class='form-horizontal form-striped'>
                                <div class="form-group">
                                    <label for="txtFirstName" class="control-label col-sm-2">&nbsp;</label>
                                    <div class="col-sm-10">
                                        <asp:image id="Image1" runat="server" height="100px" width="100px" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtFirstName" class="control-label col-sm-2">Store</label>
                                    <div class="col-sm-10">
                                        <asp:literal id="lblStore" runat="server"></asp:literal>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtFirstName" class="control-label col-sm-2">Product</label>
                                    <div class="col-sm-10">
                                        <asp:literal id="lblProductTitle" runat="server"></asp:literal>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtFirstName" class="control-label col-sm-2">Customer</label>
                                    <div class="col-sm-10">
                                        <asp:literal id="lblCustomer" runat="server"></asp:literal>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtFirstName" class="control-label col-sm-2">Complete Address</label>
                                    <div class="col-sm-10">
                                        <asp:label id="lblCustomerName" runat="server"></asp:label>
                                        <br />
                                        <asp:label id="lblAddress1" runat="server"></asp:label>
                                        <br />
                                        <asp:label id="lblAddress2" runat="server"></asp:label>
                                        <br />
                                        <asp:label id="lblCity" runat="server"></asp:label>
                                        <br />
                                        <asp:label id="lblState" runat="server"></asp:label>
                                        <br />
                                        <asp:label id="lblCountry" runat="server"></asp:label>
                                        <br />
                                        <asp:label id="lblZipCode" runat="server"></asp:label>
                                        <br />
                                        <span>--------------------------------------------------------------------------------------------</span><br />
                                        <b>Phone Number: </b>
                                        <asp:label id="lblPhoneNumber" runat="server"></asp:label>
                                        <br />
                                        <b>Email Id: </b>
                                        <asp:label id="lblEmailId" runat="server"></asp:label>
                                        <br />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtFirstName" class="control-label col-sm-2">Status</label>
                                    <div class="col-sm-10">
                                        <asp:dropdownlist id="ddlSorderStatus" runat="server" class="form-control" width="40%">
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:dropdownlist>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="Select Status" InitialValue="Select.." ControlToValidate="ddlSorderStatus" ValidationGroup="orderdelivery"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtFirstName" class="control-label col-sm-2">Comment</label>
                                    <div class="col-sm-10">
                                         <asp:TextBox ID="txtOrderDescription" runat="server" TextMode="MultiLine" class="form-control" Width="40%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Enter Process Description" ControlToValidate="txtOrderDescription" ValidationGroup="orderdelivery"></asp:RequiredFieldValidator></td>
                                    </div>
                                </div>
                                <div class="form-actions col-sm-offset-2 col-sm-10 pull-right">
                                    <asp:button id="btnAddToFeature" runat="server" class="btn btn-primary" text="Add This" validationgroup="orderdelivery" OnClick="btnAddToFeature_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
