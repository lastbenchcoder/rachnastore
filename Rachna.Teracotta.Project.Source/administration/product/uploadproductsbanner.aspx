<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="uploadproductsbanner.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.product.uploadproductsbanner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Banner</h1>
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
                <li>Banners
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
            <asp:Panel ID="pnlCreateBanner" runat="server" Visible="false">
                <div class="col-sm-12">
                    <div class="box box-color box-bordered">
                        <div class="box-title">
                            <h3>
                                <i class="fa fa-table"></i>
                                Upload Banners
                            </h3>
                        </div>
                        <div class="box-content nopadding">
                            <div class="form-group">
                                <label class="control-label col-sm-2">Banner</label>
                                <div class="col-sm-10">
                                    <asp:Image ID="imgProduct" runat="server" ClientIDMode="Static" Width="100px" Height="100px" class="form-control" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Image !.." ControlToValidate="imgInp" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.PNG|.png)$" ValidationGroup="admin"></asp:RegularExpressionValidator>
                                    <asp:FileUpload ID="imgInp" runat="server" ClientIDMode="Static" class="form-control" />
                                    <label></label>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="imgInp" ErrorMessage="Please select banner" ValidationGroup="admin" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2">Is Default Banner?</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control">
                                        <asp:ListItem Value="0">Select..</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Banners
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <asp:GridView ID="grdPrdSlider" runat="server" ClientIDMode="Static" class="table table-hover table-nomargin table-bordered dataTable" OnRowDeleting="OnRowDeleting" AutoGenerateColumns="false">
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
                                <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" />
                            </Columns>
                            <EmptyDataTemplate>
                                There are no product banners founnd.
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <div style="text-align: right; margin-bottom: 15px; margin-right: 15px; margin-top: 15px">
                            <asp:Button ID="btnGoBack" runat="server" Text="Save" class="btn btn-success hidden-print" OnClick="btnSearchPrdHome_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
