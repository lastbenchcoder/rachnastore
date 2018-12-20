<%@ Page Title="" Language="C#" MasterPageFile="~/adminvendor/Home.Master" AutoEventWireup="true" CodeBehind="productcommentsupdate.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.adminvendor.product.productcommentsupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Rachna.Teracotta.Project.Source.Models.ProdComments _RequestList = null;
        if (Request.QueryString["commentId"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["commentId"].ToString());
            Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
            _RequestList = context.ProdComments.Include("Products").Include("Stores").Include("Customer").Where(m => m.Comment_Id == id).FirstOrDefault();

            if (_RequestList.LikeUnlike == 0)
            {
                lblLike.ForeColor = System.Drawing.Color.Green;
                lblLike.Text = "Customered Liked this Product";
            }
            else
            {
                lblLike.ForeColor = System.Drawing.Color.Red;
                lblLike.Text = "Customered does not like this Product";
            }


            lblRating.ForeColor = System.Drawing.Color.Blue;
            lblRating.Text = "Customered has given " + _RequestList.Rating + " Rating to this product";
            hdnProductCommentId.Value = _RequestList.Comment_Id.ToString();
        }
        else
        {
            Response.Redirect("/adminvendor/product/productcomments.aspx?redirecturl=admin-productcomments-RachnaTeracotta");
        }
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Approve/Reject Comment</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/adminvendor/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Catalog</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Manage Product</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Product Comments</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">
                        <%= _RequestList.Products.Product_Title %>
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
                            <i class="fa fa-th-list"></i>Update Product Comment</h3>
                        <asp:HiddenField ID="hdnAdminId" runat="server" />
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Product</label>
                                <div class="col-sm-10">
                                    <span><%= _RequestList.Products.Product_Title %></span>
                                    <asp:HiddenField ID="hdnProductCommentId" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Store</label>
                                <div class="col-sm-10">
                                    <span><%= _RequestList.Stores.Store_Name %></span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Customer</label>
                                <div class="col-sm-10">
                                    <span><%= _RequestList.Customer.Customers_FullName %>(<%= _RequestList.Customer.CustomerCode %>)</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">EmailId</label>
                                <div class="col-sm-10">
                                    <span><%= _RequestList.Customer.Customers_EmailId %></span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Like/Unlike</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblLike" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">FirstName</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblRating" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Comment Description</label>
                                <div class="col-sm-10">
                                    <span><%= _RequestList.Description %></span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Status</label>
                                <div class="col-sm-10">
                                    <span class="label label-success"><%= _RequestList.Comment_Status.ToUpper() %></span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Comment Status</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlSorderStatus" runat="server" class="form-control" Width="40%">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" ValidationGroup="admin" class="btn btn-primary" Style="margin-right: 20px;" />
                                <a href="/adminvendor/product/productcomments.aspx?redirecturl=admin-productcomments-RachnaTeracotta">Go Back</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
