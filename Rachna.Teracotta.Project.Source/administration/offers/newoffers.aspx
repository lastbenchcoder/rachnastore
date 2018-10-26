<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="newoffers.aspx.cs" ValidateRequest="false" Inherits="Rachna.Teracotta.Project.Source.administration.offers.newoffers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>New Offer</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Offers</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/offers/offers.aspx?redirecturl=admin-offers-RachnaTeracotta">All Offers</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Add New Offer</a>
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
                            <i class="fa fa-th-list"></i>Offer Detail</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Select Store :</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlStore" runat="server" class="form-control">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server"
                                        ErrorMessage="Select Store" InitialValue="Select.." ControlToValidate="ddlStore" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Offer On :</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlOffersFor" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOffersFor_SelectedIndexChanged">
                                        <asp:ListItem>Select..</asp:ListItem>
                                        <asp:ListItem>Universal</asp:ListItem>
                                        <asp:ListItem>Category</asp:ListItem>
                                        <asp:ListItem>Product</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="Select Offer For"
                                        InitialValue="Select.." ControlToValidate="ddlOffersFor" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Offer Item :</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlOfferValue" runat="server" class="form-control">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Select Category/Product" InitialValue="Select.." ControlToValidate="ddlOfferValue" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Offer Header :</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtOfferTitle" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="Enter Offer Title" ControlToValidate="txtOfferTitle" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Offer Description :</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control" Height="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">No Of Times :</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txNoOfTimes" TextMode="Number" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter No Of Times user can avail this offer" ControlToValidate="txNoOfTimes" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Offer Banner :</label>
                                <div class="col-sm-10">
                                    <asp:Image ID="imgProduct" runat="server" ClientIDMode="Static" Width="100px" Height="100px" class="form-control" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Image !.." ControlToValidate="imgInp" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.PNG|.png)$"></asp:RegularExpressionValidator>
                                    <asp:FileUpload ID="imgInp" runat="server" ClientIDMode="Static" class="form-control" />
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
                                <label for="txtFirstName" class="control-label col-sm-2">Offer Starts From :</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtStartDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                        ErrorMessage="Select StartDate" ControlToValidate="txtStartDate" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Offer End On :</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtEndDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                        ErrorMessage="Select End Date" ControlToValidate="txtEndDate" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success hidden-print" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                                &nbsp;&nbsp;
                                <a href="/administration/offers/offers.aspx?redirecturl=admin-offers-RachnaTeracotta" class="btn btn-primary">Cancel</a>
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
