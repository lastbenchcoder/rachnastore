<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="sliderdetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.home.sliderdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Edit Slider Information</h1>
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
                    <a href="#">Home Page Slider</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Edit Slider Information</a>
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
                            <i class="fa fa-th-list"></i>Update Slider Information</h3>
                        <asp:HiddenField ID="hdnSliderId" runat="server" />
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Slider Banner</label>
                                <div class="col-sm-10">
                                    <asp:Image ID="imgBanner" runat="server" Width="50" Height="50" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Alternate Text</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAltText" runat="server" class="form-control input-sm" Width="50%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Confirm Password</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtImageUrl" runat="server" class="form-control input-sm" Width="50%"></asp:TextBox>
                                    <p style="color: red">URL may be any specific Product or List of products by category page. It is must and should. If No Url please mention #(No redirection will be done). </p>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Redirect Url" ControlToValidate="txtImageUrl" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnDelete" runat="server" Style="float: right" Text="Delete" class="btn btn-primary" OnClick="btnDelete_Click" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSubmit" runat="server" Style="float: right" Text="Submit" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                                &nbsp;&nbsp;&nbsp;
                                <a href="/administration/home/slider.aspx?redirecturl=admin-slider-rachna-teracotta" class="btn btn-info">Go Back to list</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
