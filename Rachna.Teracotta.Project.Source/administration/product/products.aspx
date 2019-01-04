<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.product.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Product> _RequestList = null;
        _RequestList = Rachna.Teracotta.Project.Source.Core.bal.bProduct.List();
        if (_RequestList.Count > 0)
        {
            foreach (var item in _RequestList)
            {
                item.SubCategory.Category = Rachna.Teracotta.Project.Source.Core.bal.bCategory.List().Where(m => m.Category_Id == item.SubCategory.Category_Id).FirstOrDefault();
            }
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Products</h1>
            </div>
            <div class="pull-right">
                <a href="/administration/product/newproducts.aspx?redirecturl=admin-Product-RachnaTeracotta" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
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
                    <a href="#">View All Products</a>
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
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            All Products
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Product Id</th>
                                    <th>Store</th>
                                    <th></th>
                                    <th>Code</th>
                                    <th>Product</th>
                                    <th>Category</th>
                                    <th>CreatedBy</th>
                                    <th>Status</th>
                                    <th>Edit Detail</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <%=item.Product_Id %>
                                    </td>
                                    <td>
                                        <%=item.Store.Store_Name %>
                                    </td>
                                    <td><a href="/administration/product/uploadproductsbanner.aspx?Productid=<%=item.Product_Id %>"><%if (item.ProductBanner.Count > 0)
                                            { %>
                                        <img src="../../<%=item.ProductBanner.Where(m => m.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo %>" style="height: 50px; width: 50px" />
                                        <%}
                                            else
                                            { %>
                                        <img src="../../content/noimage.png" style="height: 50px; width: 50px" />
                                        <%} %>
                                    </a>
                                    </td>
                                    <td><%=item.ProductCode %></td>
                                    <%if (item.Product_Title.Length > 30)
                                        {%>
                                    <td><%=item.Product_Title.Substring(0, 30).ToString() %><span>...</span></td>
                                    <%}
                                        else
                                        { %>
                                    <td><%=item.Product_Title %><span>...</span></td>
                                    <%} %>
                                    <td><%=item.SubCategory.SubCategory_Title %>(<%= item.SubCategory.Category.Category_Title %>)</td>
                                    <td><%=item.Admin.FullName %></td>
                                    <%if (item.Product_Status == Rachna.Teracotta.Project.Source.Entity.eProductStatus.Published.ToString())
                                        {%>
                                    <td>
                                        <span class="label label-success"><%=item.Product_Status %>
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        { %>
                                    <td><span class="label label-danger"><%=item.Product_Status %>
                                    </span></td>
                                    <%} %>
                                    <td><a href="/administration/product/productsdetailstatic.aspx?Productid=<%=item.Product_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                                    <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
