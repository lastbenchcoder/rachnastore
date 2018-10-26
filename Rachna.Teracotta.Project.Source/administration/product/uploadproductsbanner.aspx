<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="uploadproductsbanner.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.product.uploadproductsbanner" %>

<%@ Register Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" TagPrefix="CuteWebUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #ContentPlaceHolder1_Attachments1__Insert {
            margin-top: 11px;
            height: 50px;
            width: 238px;
        }
    </style>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Product Banners</h1>
                <asp:HiddenField ID="hdnProductId" runat="server" />
                <asp:HiddenField ID="hdnProdId" runat="server" />
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Catalot</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Manage Products</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/product/productsdetailstatic.aspx?productid=<%=hdnProductId.Value %>">
                        <asp:Label ID="lblBcTitle" runat="server"></asp:Label></a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>Product Banners
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
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Upload Product Banners
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class="form-group col-lg-3" style="margin-top: 10px">
                            <label>&nbsp;</label>
                            <CuteWebUI:UploadAttachments InsertText="Upload Multiple files Now" runat="server"
                                ID="Attachments1" MultipleFilesUpload="true">
                                <InsertButtonStyle />
                            </CuteWebUI:UploadAttachments>
                        </div>
                        <div class="form-group col-lg-3" style="margin-top: 32px">
                            <asp:Button ID="btnSubmit" runat="server" Text="Upload Files" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Product Banners
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <asp:GridView ID="grdPrdSlider" runat="server" ClientIDMode="Static" 
                            class="table table-hover table-nomargin table-bordered" OnRowDeleting="OnRowDeleting" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton
                                            ID="LinkProducts"
                                            runat="server"
                                            CommandArgument='<%#Eval("Product_Banner_Id")%>'
                                            OnCommand="Product_Command"
                                            Text='Set As Default'></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "../../"+ Eval("Product_Banner_Photo") %>' Width="100px" Height="100px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Product_Banner_Id" HeaderText="Banner Id" />
                                <asp:BoundField DataField="Product_Banner_Default" HeaderText="Is Default Image(1=Yes and 0=No)" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Content/delete.png" CancelImageUrl="~/Content/delete.png" ShowDeleteButton="True" />
                            </Columns>
                            <EmptyDataTemplate>
                                There are no product banners founnd.
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <div style="text-align: right; margin-bottom: 15px; margin-right: 15px; margin-top: 15px">
                            <asp:Button ID="btnGoBack" runat="server" Text="Save Changes" class="btn btn-success hidden-print" OnClick="btnSearchPrdHome_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
