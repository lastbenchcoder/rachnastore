﻿<%@ Page Title="" Language="C#" MasterPageFile="~/adminvendor/Home.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.adminvendor.account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Account Password</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/adminvendor/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Account Password</a>
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
                            <i class="fa fa-th-list"></i>Update Account Password</h3>
                        <asp:HiddenField ID="hdnAdminId" runat="server" />
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">New Password</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtPassword" runat="server" placeholder="New Password" TextMode="Password" class="form-control" Width="30%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter New Password" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="txtPassword" ValidationGroup="admin" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{5,8}$" runat="server" ErrorMessage="Minimum 5 and Maximum 8 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Confirm Password</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Confirm Password" TextMode="Password" class="form-control" Width="30%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Confirm Password" ControlToValidate="txtConfirmPassword" ForeColor="Red" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ControlToValidate="txtConfirmPassword" ValidationGroup="admin" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{5,8}$" runat="server" ErrorMessage="Minimum 5 and Maximum 8 characters required." ForeColor="Red"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success btn-sm" ValidationGroup="admin" OnClick="btnSubmit_Click" Style="float: right" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
