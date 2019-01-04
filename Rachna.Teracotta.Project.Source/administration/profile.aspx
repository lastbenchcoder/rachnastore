<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Update Information</h1>
            </div>
            <div class="pull-right">
                <a href="/administration/alladmin.aspx?redirect-url=uyiretieyt7985798435ihtiuertireyte&id=alladmin.html">All Admin</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Update Information</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">
                        <asp:label id="lblBcTitle" runat="server"></asp:label>
                    </a>
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
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Update Information</h3>
                        <asp:hiddenfield id="hdnAdminId" runat="server" />
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Store</label>
                                <div class="col-sm-10">
                                    <asp:label id="lblStore" runat="server"></asp:label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">FullName</label>
                                <div class="col-sm-10">
                                    <asp:textbox id="txtFullname" runat="server" class="form-control" style="width: 30%"></asp:textbox>
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator4" forecolor="Red" runat="server" errormessage="Enter Fullname" controltovalidate="txtFullname" validationgroup="admin"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">EmailId</label>
                                <div class="col-sm-10">
                                    <asp:textbox id="txtEmailId" textmode="Email" runat="server" class="form-control" readonly="true" style="width: 30%"></asp:textbox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Phone</label>
                                <div class="col-sm-10">
                                    <asp:textbox id="txtPhone" textmode="Phone" runat="server" class="form-control" style="width: 30%"></asp:textbox>
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" forecolor="Red" runat="server" errormessage="Enter Phone Number" controltovalidate="txtPhone" validationgroup="admin"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Description</label>
                                <div class="col-sm-10">
                                    <asp:textbox id="txtDescription" textmode="MultiLine" runat="server" class="form-control" height="100px"></asp:textbox>
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator6" forecolor="Red" runat="server" errormessage="Enter Description" controltovalidate="txtDescription" validationgroup="admin"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Profile Photo</label>
                                <div class="col-sm-10">
                                    <asp:image id="imgProduct" runat="server" clientidmode="Static" width="100px" height="100px" class="form-control" />
                                    <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" errormessage="Invalid Image !.." controltovalidate="imgInp" forecolor="Red" validationexpression="^.+(.jpg|.JPG|.gif|.GIF|.PNG|.png)$"></asp:regularexpressionvalidator>
                                    <asp:fileupload id="imgInp" runat="server" clientidmode="Static" class="form-control" />
                                    <script type="text/javascript">
                                        function readURL(input) {
                                            if (input.files && input.files[0]) {
                                                var reader = new FileReader();

                                                reader.onload = function (e) {
                                                    $('#imgProduct').attr('src', e.target.result);
                                                }

                                                reader.readAsDataURL(input.files[0]);
                                            }
                                        }

                                        $("#imgInp").change(function () {
                                            readURL(this);
                                        });
                                    </script>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Select Role</label>
                                <div class="col-sm-10">
                                    <asp:dropdownlist id="ddlRole" runat="server" class="form-control input-sm" style="width: 30%">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:dropdownlist>
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" forecolor="Red" runat="server"
                                        errormessage="Select Role" initialvalue="Select.." controltovalidate="ddlRole" validationgroup="admin"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Select Status</label>
                                <div class="col-sm-10">
                                    <asp:dropdownlist id="ddlStatus" runat="server" class="form-control" style="width: 30%">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:dropdownlist>
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" forecolor="Red" runat="server"
                                        width="30%" errormessage="Select Status" initialvalue="Select.." controltovalidate="ddlStatus"
                                        validationgroup="admin"></asp:requiredfieldvalidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Login Attempt</label>
                                <div class="col-sm-10">
                                    <asp:label runat="server" Id="lblLoginAttempt"></asp:label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Get Activity Mail</label>
                                <div class="col-sm-10">
                                    <asp:checkbox runat="server" Id="chkGetActivityMail"></asp:checkbox>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:button id="btnSubmit" runat="server" text="Submit" class="btn btn-success btn-sm"
                                    validationgroup="admin" onclick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
