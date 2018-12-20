<%@ Page Title="" Language="C#" MasterPageFile="~/adminvendor/Home.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.adminvendor._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Rachna.Teracotta.Project.Source.Helper.AdminDashboardHelper _admin = null;
        Rachna.Teracotta.Project.Source.Helper.AdministratorDetail _bdashboard = new Rachna.Teracotta.Project.Source.Helper.AdministratorDetail();
        _admin = _bdashboard.GetDashBoardDetail(Convert.ToInt32(Session[ConfigurationSettings.AppSettings["VendorSession"].ToString()].ToString()));
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Welcome <%=_admin.Administrators.FullName%>!!!</h1>
            </div>
            <div class="pull-right">
                <ul class="stats">
                    <li class='satgreen'>
                        <a href="/adminvendor/store.aspx?redirecturl=admin-store-rachna-teracotta">
                            <i class="fa fa-briefcase"></i>
                            <div class="details">
                                <span class="big"><%=_admin.TotalStores %></span>
                                <span>Stores</span>
                            </div>
                        </a>
                    </li>
                    <li class='lightred'>
                        <a href="/adminvendor/invitation.aspx?redirecturl=admin-store-rachna-teracotta">
                            <i class="fa fa-comment"></i>
                            <div class="details">
                                <span class="big"><%=_admin.TotalInvitation %></span>
                                <span>Invitation</span>
                            </div>
                        </a>
                    </li>
                    <li class='satgreen'>
                        <a href="/adminvendor/alladmin.aspx?redirecturl=admin-slider-rachna-teracotta">
                            <i class="fa fa-user"></i>
                            <div class="details">
                                <span class="big"><%=_admin.TotalAdministrator %></span>
                                <span>Administrators</span>
                            </div>
                        </a>
                    </li>
                    <li class='satgreen'>
                        <a href="/adminvendor/salesmanagement/customers.aspx?id=jhgj657657HGH.htm">
                            <i class="fa fa-anchor"></i>
                            <div class="details">
                                <span class="big"><%=_admin.TotalCustomer %></span>
                                <span>Customer</span>
                            </div>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Administrator</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/adminvendor/default.aspx?redirecturl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Dashboard</a>
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
                <ul class="tiles">
                    <li class="magenta">
                        <a href="/adminvendor/categories/category.aspx?redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979">
                            <span>
                                <i class="fa fa-asterisk"></i>
                            </span>
                            <span class="name"><%=_admin.TotalCategory %> Categories</span>
                        </a>
                    </li>
                    <li class="pink long">
                        <a href="/adminvendor/categories/subcategory.aspx?redirectUrl=subcategory-administrator-home&pageId=1234HJHJKJ*7987979">
                            <span>
                                <i class="fa fa-barcode"></i>
                            </span>
                            <span class="name"><%=_admin.TotalSubCategory %> Sub Categories</span>
                        </a>
                    </li>
                    <li class="blue">
                        <a href="/adminvendor/product/products.aspx?redirecturl=admin-Product-rachna-teracotta">
                            <span>
                                <i class="fa fa-wrench"></i>
                            </span>
                            <span class="name"><%=_admin.TotalProducts %> Products</span>
                        </a>
                    </li>
                    <li class="lime">
                        <a href="/adminvendor/salesmanagement/orders.aspx?id=jhgj657657HGH.htm">
                            <span>
                                <i class="fa fa-shopping-cart"></i>
                            </span>
                            <span class="name"><%=_admin.TotalOrders %> Orders</span>
                        </a>
                    </li>
                    <li class="orange">
                        <a href="/adminvendor/salesmanagement/cart.aspx?id=jhgj657657HGH.htm">
                            <span>
                                <i class="fa fa-sign-out"></i>
                            </span>
                            <span class="name"><%=_admin.TotalItemsInCart %> Cart</span>
                        </a>
                    </li>
                    <li class="red long">
                        <a href="/adminvendor/delivery/ordersdelivery.aspx?id=jhgj657657HGH.htm">
                            <span>
                                <i class="fa fa-bell"></i>
                            </span>
                            <span class="name"><%=_admin.TotalOrders %> Order for Delievery</span>
                        </a>
                    </li>
                </ul>
            </div>
            <div class="col-sm-12">
                <div class="box box-bordered box-color">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-envelope"></i>
                            Query From Users
                        </h3>
                    </div>
                    <div class="box-content nopadding">

                        <div class="tab-content">
                            <div class="tab-pane active" id="inbox">
                                <table class="table table-hover table-nomargin table-bordered dataTable">
                                    <thead>
                                        <tr>
                                            <th>FullName</th>
                                            <th>EmailId</th>
                                            <th>IpAddress</th>
                                            <th>Subject</th>
                                            <th>Description</th>
                                            <th class="table-date hidden-480">Date</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%foreach (var item in _admin.CustomerRequest)
                                            { %>
                                        <tr>
                                            <td><%=item.FullName %>
                                            </td>
                                            <td><%=item.EmailId %>
                                            </td>
                                            <td><%=item.IpAddress %>
                                            </td>
                                            <td><%=item.Subject %>
                                            </td>
                                            <td><%=item.Description %>
                                            </td>
                                            <td class="table-date hidden-480"><%=item.DateCreated.ToString("D") %>
                                            </td>
                                        </tr>
                                        <%} %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>