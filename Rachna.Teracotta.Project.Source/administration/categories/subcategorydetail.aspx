<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="subcategorydetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.categories.subcategorydetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Sub Category Detail</h1>
                <asp:HiddenField ID="hdnCatId" runat="server" />
                <asp:HiddenField ID="hdnCurrentSubCatCatId" runat="server" />
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
                    <a href="/administration/categories/subcategory.aspx?redirectUrl=sub-category-administrator-home&pageId=1234HJHJKJ*7987979">Manage Sub Categories</a>
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
                            <i class="fa fa-th-list"></i>Update Sub Category</h3>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <div class="form-group">
                                <label>Select Categoory</label>
                                <asp:DropDownList ID="ddlCategory" runat="server" class="form-control input-sm" Width="50%">
                                    <asp:ListItem>Select..</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Select Category" InitialValue="Select.." ControlToValidate="ddlCategory" ValidationGroup="admin"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Title</label>
                                <asp:TextBox ID="txtCategory" runat="server" class="form-control" Width="50%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Category title" ControlToValidate="txtCategory" ValidationGroup="admin"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Administrator</label>
                                <span style="color: green; font-weight: bold">
                                    <asp:Label ID="lblAdministrator" runat="server"></asp:Label>
                                </span>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                 <asp:Button ID="btnSubmit" runat="server" Style="float: right" Text="Submit" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
