<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="dealofthedaydetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.home.dealofthedaydetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Edit Deal of the day Information</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Deal of the day</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Edit Deal of the day Information</a>
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
                            <i class="fa fa-th-list"></i>Update Deal of the day Information</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <asp:HiddenField ID="hdnDealId" runat="server" />
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
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Product Actual Price</label>
                                <div class="col-sm-10">
                                    <asp:Literal ID="ltlActualPrice" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Deal Price</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDealPrice" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Deal Price" ControlToValidate="txtDealPrice" ValidationGroup="dealoftheday"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Deal Starts On :</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtStartDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                        ErrorMessage="Select Deal Day" ControlToValidate="txtStartDate" ValidationGroup="dealoftheday"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10 pull-right">
                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Save Changes"
                                    OnClick="btnSubmit_Click" ValidationGroup="dealoftheday" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
