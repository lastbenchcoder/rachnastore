<%@ Page Title="" Language="C#" MasterPageFile="~/support/home/Home.Master" AutoEventWireup="true" CodeBehind="functionalitydetail.aspx.cs" ValidateRequest="false"
    Inherits="Rachna.Teracotta.Project.Source.support.home.functionalitydetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Functionality Information</h1>
                <asp:HiddenField ID="hdnFunctionalityId" runat="server" />
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/support/home/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Functionality</a>
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
                            <i class="fa fa-th-list"></i>Detail</h3>
                        <asp:HiddenField ID="hdnAdminId" runat="server" />
                        <div class="pull-right">
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn btn-info" OnClick="btnEdit_Click" />
                            &nbsp &nbsp
                            <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" class="btn btn-info" OnClick="btnCancelEdit_Click" Enabled="false" />
                            &nbsp &nbsp
                            <asp:Button ID="btnSave" runat="server" Text="Save Changes" class="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="functionality" Enabled="false" />
                            &nbsp &nbsp
                            <a href="/support/home/functionality.aspx?redirecturl=admin-allproduct-RachnaTeracotta" class="btn btn-brown">Back</a>
                            &nbsp &nbsp
                        </div>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Status:</b></label>
                                <div class="col-sm-4">
                                    <h4>
                                        <asp:Label ID="lblFunctionalityStatus" runat="server"></asp:Label>
                                    </h4>
                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control" Width="50%" Visible="false">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                        ErrorMessage="Select Status" InitialValue="Select.." ControlToValidate="ddlStatus"
                                        ValidationGroup="functionality"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDeveloperFirstName" class="control-label col-sm-2"><b>Developer Name:</b></label>
                                <div class="col-sm-4">
                                    <h5>
                                        <asp:Label ID="lblDeveloperName" runat="server"></asp:Label>
                                    </h5>
                                    <asp:DropDownList ID="ddlDeveloper" runat="server" class="form-control" Width="50%" Visible="false">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server"
                                        ErrorMessage="Select Developer" InitialValue="Select.." ControlToValidate="ddlDeveloper"
                                        ValidationGroup="functionality"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Functionality Id & Code :</b></label>
                                <div class="col-sm-4">
                                    Funct Id :
                                    <asp:Label ID="lblFunctionalityId" runat="server"></asp:Label>
                                    &nbsp;&nbsp;
                                    Funct Code :
                                    <asp:Label ID="lblFunctionalityCode" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Title :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblFunctionalityName" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control"
                                        placeholder="Title" Visible="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Functionality Title" ControlToValidate="txtTitle"
                                        ValidationGroup="functionality"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Description:</b></label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblFunctionalityDescription" runat="server"></asp:Label>
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control"
                                        placeholder="Description" Visible="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Functionality Description" ControlToValidate="txtDescription"
                                        ValidationGroup="functionality"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Created By :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtDescription.ClientID %>', { filebrowserImageUploadUrl: '../../Upload.ashx' });
        });
    </script>
</asp:Content>
