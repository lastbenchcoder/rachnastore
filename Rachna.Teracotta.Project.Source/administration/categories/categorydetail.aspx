<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="categorydetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.categories.categorydetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Category Detail</h1>
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
                    <a href="/administration/categories/category.aspx?redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979">Manage Categories</a>
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
                            <i class="fa fa-th-list"></i>Update Category</h3>
                        <asp:HiddenField ID="hdnCatId" runat="server" />
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Title</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtCategory" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Category title" ControlToValidate="txtCategory" ValidationGroup="category"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">&nbsp;</label>
                                <div class="col-sm-10">
                                    <asp:Image ID="imgArticle" runat="server" ClientIDMode="Static" Width="50px" Height="50px" class="form-control" />
                                    <label></label>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
                                        ErrorMessage="Invalid Image File Format, Should be .jpg, .JPG, .gif, .GIF, .PNG, .png, .jpeg !.."
                                        ControlToValidate="imgInp" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.PNG|.png|.jpeg)$"
                                        ValidationGroup="category"></asp:RegularExpressionValidator>
                                    <asp:FileUpload ID="imgInp" runat="server" ClientIDMode="Static" class="form-control input-sm" />
                                    <label></label>
                                    <script type="text/javascript">
                                        function readURL(input) {
                                            if (input.files && input.files[0]) {
                                                var reader = new FileReader();

                                                reader.onload = function (e) {
                                                    $('#imgArticle').attr('src', e.target.result);
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
                                <label for="txtFirstName" class="control-label col-sm-2">Administrator</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtAdministrator" runat="server" class="form-control" ReadOnly="true" Width="50%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2">Is Active?</label>
                                <div class="col-sm-10">
                                    <asp:CheckBox ID="chkIsActive" runat="server" />
                                    Active
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" Style="float: right" Text="Submit" class="btn btn-primary"
                                    ValidationGroup="category" OnClientClick="if (!CategoryUpdateConfirmation()) return false;"  OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function CategoryUpdateConfirmation() {
            return confirm("Are you sure you want to deactivate this category? By deactivating this Category will deactivate the SubCategory and Product and also Product Features and Carts will be deleted.");
        }
    </script>
</asp:Content>
