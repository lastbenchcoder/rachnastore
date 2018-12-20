<%@ Page Title="" Language="C#" MasterPageFile="~/adminvendor/Home.Master" AutoEventWireup="true" CodeBehind="productcomments.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.adminvendor.product.productcomments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
         Rachna.Teracotta.Project.Source.Models.Administrators _Administrator = null;
        List<Rachna.Teracotta.Project.Source.Models.ProdComments> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _Administrator = Rachna.Teracotta.Project.Source.Core.bal.bAdministrator.List().Where(m => m.Administrators_Id == Convert.ToInt32(Session[ConfigurationSettings.AppSettings["VendorSession"].ToString()].ToString())).FirstOrDefault();
        _RequestList = context.ProdComments.Include("Products").Include("Stores").Include("Customer").Where(m=>m.Store_Id==_Administrator.Store_Id).ToList();

    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Products Comments</h1>
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
                    <a href="#">Manage Products</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Product Comments</a>
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
                            Product Comments
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Product Code</th>
                                    <th>Store</th>
                                    <th>Product</th>
                                    <th>Customer</th>
                                    <th>Comment</th>
                                    <th>Status</th>
                                    <th>Approve/Reject</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td><a href="/adminvendor/product/uploadproductsbanner.aspx?Productid=<%=item.Product_Id %>">
                                        <%=item.Products.ProductCode %>
                                    </a>
                                    </td>
                                    <td>
                                        <%=item.Stores.Store_Name %>
                                    </td>
                                    <td><%=item.Products.Product_Title %></td>
                                    <td><%=item.Customer.Customers_FullName %></td>
                                    <td><%=item.Description %></td>
                                    <%if (item.Comment_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
                                        {%>
                                    <td><span class="label label-success">
                                        <%=item.Comment_Status %>
                                    </span></td>
                                    <%}
                                        else
                                        { %>
                                    <td><span class="label label-danger">
                                        <%=item.Comment_Status %>
                                    </span></td>
                                    <%} %>
                                    <td><a href="/adminvendor/product/productcommentsupdate.aspx?commentId=<%=item.Comment_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                                    <%
                                        }
                                    %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
