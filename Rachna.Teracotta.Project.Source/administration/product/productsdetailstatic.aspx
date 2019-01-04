<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="productsdetailstatic.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.product.productsdetailstatic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
            width: 208px;
        }

        .auto-style2 {
            width: 208px;
        }

        .auto-style3 {
            width: 621px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--Modal-->
    <div class="modal fade" id="modalRejectProduct">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Reject Product</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Reject Reason</label>
                        <asp:TextBox ID="txtReasonReject" TextMode="MultiLine" runat="server" class="form-control input-sm" Height="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                            ErrorMessage="Enter valid Reason for exception" ControlToValidate="txtReasonReject" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-sm btn-success" data-dismiss="modal" aria-hidden="true">Close</button>
                    <asp:Button ID="btnReject" runat="server" Text="Submit" class="btn btn-success btn-sm" ValidationGroup="admin" OnClick="btnReject_Click" Style="float: right" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <!--Modal-->
    <div class="modal fade" id="modalProdHistory">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Product History</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:GridView ID="grdProdHistory" runat="server" AutoGenerateColumns="false" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="Product_Flow_CreatedBy" HeaderText="Admin" />
                                <asp:BoundField DataField="Product_Status" HeaderText="Status" />
                                <asp:BoundField DataField="Product_Flow_Detail" HeaderText="Reason" />
                                <asp:BoundField DataField="Product_Flow_CreatedDate" HeaderText="Date" />
                            </Columns>
                            <EmptyDataTemplate>
                                There are no details founnd.
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-sm btn-success" data-dismiss="modal" aria-hidden="true">Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Product Information</h1>
            </div>
            <div class="pull-right" style="margin-top: 20px">
                <%
                    string url = "/product/productoffline?id=" + lblProductId.Text + "&title=" + lblBcTitle.Text + "&redirect-page-mode=offline-mode";
                %>
                <a href="<%=url %>" target="_blank" style="color: darkblue; font-weight: bolder; margin-right: 20px">View Offline</a>
                &nbsp;&nbsp;|&nbsp;&nbsp;
                <a href="#" data-toggle="modal" data-target="#modalProdHistory" style="color: darkblue; font-weight: bolder; margin-right: 20px">Product History</a>
                &nbsp;&nbsp;|&nbsp;&nbsp;
                <a href="/administration/product/products.aspx?redirect-url=uyiretieyt7985798435ihtiuertireyte&id=alladmin.html" style="color: darkblue; font-weight: bolder; margin-right: 20px">All Products</a>
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
                    <a href="/administration/product/products.aspx?redirecturl=admin-Product-rachna-teracotta">View All Products</a>
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
                            <i class="fa fa-th-list"></i>Basic Detail</h3>
                        <asp:HiddenField ID="hdnAdminId" runat="server" />
                        <div class="pull-right">
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn btn-info" OnClick="btnEdit_Click" />
                            &nbsp &nbsp
                        <asp:Button ID="btnImageUpload" runat="server" Text="Upload Banner" class="btn btn-info" OnClick="btnImageUpload_Click" />
                            &nbsp &nbsp
                        <asp:Button ID="btnApprove" runat="server" Text="Publish" class="btn btn-primary" OnClick="btnApprove_Click" />
                            &nbsp &nbsp
                        <asp:HyperLink ID="btnRejectModel" runat="server" data-toggle="modal" data-target="#modalRejectProduct" class="btn btn-danger">Reject</asp:HyperLink>
                            &nbsp &nbsp
                        <a href="/administration/product/products.aspx?redirecturl=admin-allproduct-RachnaTeracotta" class="btn btn-brown">Go Back</a>
                            &nbsp &nbsp
                        </div>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Status:</b></label>
                                <div class="col-sm-4">
                                    <h4>
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label></h4>
                                </div>
                            </div>
                             <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Store Name:</b></label>
                                <div class="col-sm-4">
                                    <h5>
                                        <asp:Label ID="lblStore" runat="server"></asp:Label></h5>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Product Id & Code :</b></label>
                                <div class="col-sm-4">
                                    Product Id :
                                    <asp:Label ID="lblProductId" runat="server"></asp:Label>
                                    &nbsp;&nbsp;
                                   Product Code :
                                    <asp:Label ID="lblProductCode" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Title :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Category :</b></label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblCategorySubCategory" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Description:</b></label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"><b>Specification:</b></label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblSpecification" runat="server"></asp:Label>
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
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Price Detail</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Market Price</label>
                                <div class="col-sm-4">
                                    <span>&#x20B9;&nbsp;</span><asp:Label ID="lblmktprc" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Quantity</label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblQty" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Qty Low Alert</label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Discount(%)</label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lbldiscount" runat="server" Text=""></asp:Label><span>%</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Our Price</label>
                                <div class="col-sm-4">
                                    <span>&#x20B9;&nbsp;</span><asp:Label ID="lblourprc" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Shipping Charge :</label>
                                <div class="col-sm-4">
                                    <span>&#x20B9;&nbsp;</span><asp:Label ID="lblShippingchrge" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Size And Delivery</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Delivered In:</label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblDelieveryTime" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Customer:</label>
                                <div class="col-sm-4">
                                    <span>can Purchase max&nbsp;&nbsp;</span><asp:Label ID="lblmaxpurchase" runat="server" Text=""></asp:Label><span>&nbsp;&nbsp;products</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Size : </label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblSizes" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Available Zip Codes:</label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblzipcode" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Rating from Store:</label>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblRatingStore" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="box box-bordered">
            <div class="box-title">
                <h3>
                    <i class="fa fa-th-list"></i>Product Banners</h3>
            </div>
            <div class="box-content nopadding">
                <div class='form-horizontal form-striped'>
                    <div class="form-group">
                        <label for="txtFirstName" class="control-label col-sm-2">&nbsp;</label>
                        <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" ShowFooter="False" ShowHeader="False" Width="696px">
                            <ItemTemplate>
                                <asp:Image ID="imgEmp" runat="server" Width="100px" Height="100px" ImageUrl='<%# Bind("Product_Banner_Photo", "../../{0}") %>' Style="padding-left: 40px" /><br />
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
        <div class="box box-bordered">
            <div class="box-title">
                <h3>
                    <i class="fa fa-th-list"></i>Product Comments</h3>
            </div>
            <div class="box-content nopadding">
                <div class='form-horizontal form-striped'>
                    <div class="form-group">
                        <label for="txtFirstName" class="control-label col-sm-2">&nbsp;</label>
                        <asp:GridView ID="grdComments" runat="server" AutoGenerateColumns="False" CellPadding="0" GridLines="None" Enabled="False" EnableModelValidation="False" EnableTheming="False">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="696px" ItemStyle-CssClass="margin-right:20px">
                                    <ItemTemplate>
                                        <table border="1">
                                            <tr>
                                                <th style="width: 25%">Rating</th>
                                                <th style="width: 25%">LikeUnlike</th>
                                                <th style="width: 25%">Description</th>
                                                <th style="width: 25%">Status</th>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%">
                                                    <asp:Label Text='<%# Eval("Rating").ToString() %>'
                                                        runat="server" /></td>
                                                <td style="width: 25%">
                                                    <asp:Label Text='<%# Eval("LikeUnlike").ToString() == "1" ? "Liked" : "DisLike" %>'
                                                        runat="server" /></td>
                                                <td style="width: 25%">
                                                    <asp:Label Text='<%# Eval("Description").ToString() %>'
                                                        runat="server" /></td>
                                                <td style="width: 25%">
                                                    <asp:Label Text='<%# Eval("Comment_Status").ToString().ToLower() == "active" ? "Approved" : "Pending For Approve" %>'
                                                        runat="server" /></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>

                                    <ItemStyle CssClass="margin-right:20px" Width="696px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
