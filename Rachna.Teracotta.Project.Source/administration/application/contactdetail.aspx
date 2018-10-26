<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="contactdetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.application.contactdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Contact Information</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Application</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/application/Contact.aspx?redirectUrl=ContactOwner-administrator-home&pageId=1234HJHJKJ*7987979">Contact Information</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a>
                        <asp:Label ID="lblBcTitle" runat="server"></asp:Label>
                    </a>
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
                            <i class="fa fa-th-list"></i>Contact Information</h3>
                        <asp:HiddenField ID="hdnContactOwnerId" runat="server" />
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtTitle" class="control-label col-sm-2">Title</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Title for ContactOwner" ControlToValidate="txtTitle" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">Description</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Description" ControlToValidate="txtDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">Address</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Address" ControlToValidate="txtAddress" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">City</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtCity" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter City" ControlToValidate="txtCity" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">State</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtState" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter State" ControlToValidate="txtState" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">ZipCode</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtZip" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter ZipCode" ControlToValidate="txtZip" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">EmailId</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEmailId" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter EmailId" ControlToValidate="txtEmailId" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">Phone</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtPhone" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Phone" ControlToValidate="txtPhone" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">Fax</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtFax" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Fax" ControlToValidate="txtFax" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">WebSite</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtWebSite" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter WebSite" ControlToValidate="txtWebSite" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription" class="control-label col-sm-2">Google Map URL</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtGMapUrl" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Google Map URL" ControlToValidate="txtGMapUrl" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">&nbsp;</label>
                                <div class="col-sm-10">
                                    <asp:CheckBox ID="chkIsDefault" runat="server" />
                                    Is Default Contact Detail
                                </div>
                            </div>
                             <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">&nbsp;</label>
                                <div class="col-sm-10">
                                    <asp:CheckBox ID="chkSubmitRequest" runat="server" />
                                   Customer Can Submit Request
                                </div>
                            </div>
                        </div>
                        <div class="form-actions col-sm-offset-2 col-sm-10">
                            <asp:Button ID="btnSubmit" runat="server" Style="float: right" Text="Save Changes" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
