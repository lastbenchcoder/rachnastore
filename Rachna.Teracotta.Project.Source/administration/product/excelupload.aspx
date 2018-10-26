<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="excelupload.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.product.excelupload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Bulk Upload Product</h1>
            </div>
            <div class="pull-right">
                <a href="/administration/product/exceldoc/Product.csv" class="btn btn-primary" style="margin-top: 15px"><i class="fa fa-book fa-lg"></i>&nbsp;&nbsp;Download Sample Document</a>
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
                    <a href="#">Manage Products</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Products Bulk Upload</a>
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
        <div class="row margin-top">
            <div class="col-sm-12">
                <div class="alert alert-info">
                    <h3>Please follow below steps, before you upload the excel.</h3>
                    <ol>
                        <li>Please do not change the document format.
                        </li>
                        <li>Unknow format may cause loss or damage to the existing products.
                        </li>
                        <li>We request you to keep product id as 0 if you are going to insert new product, 
                           else mention product id to update the existing product.
                        </li>
                        <li>Valid product id/sub category id is required to insert/update the records, 
                           Error will be thrown or product submission will fail if no product id/sub category id exists.
                        </li>
                        <li>We request you to use the sample document to insert/update the records.
                        </li>
                    </ol>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Bulk Upload Product</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Select File :</label>
                                <div class="col-sm-10">
                                    <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please select the file" ValidationGroup="admin" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid File Format(Should be Comma Seperated Value File i.e. .csv) !.." ControlToValidate="FileUpload1" ForeColor="Red" ValidationExpression="^.+(.csv)$" ValidationGroup="admin"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" ValidationGroup="admin" class="btn" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
