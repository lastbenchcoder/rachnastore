<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="customers.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.customer.customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
        List<Rachna.Teracotta.Project.Source.Models.Customers> _RequestList = null;
        using (var ctx = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext())
        {
            _RequestList = ctx.Customer.Where(m => m.Customers_FullName.ToLower() != "guest user").ToList();

            int count_request = 0;
            if (_RequestList.Count() > 0)
            {
                count_request = _RequestList.Count();
                foreach (var item in _RequestList)
                {
                    item.Cart = ctx.Cart.ToList().Where(m => m.Customer_Id == item.Customer_Id && m.Cart_Status != Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString()).ToList();
                    item.Orders = ctx.Orders.ToList().Where(m => m.Customer_Id == item.Customer_Id).ToList();
                }
            }
        }
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Customers</h1>
            </div>
            <div class="pull-right">
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Customers</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">All Customers</a>
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
                            All Customers
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>FullName</th>
                                    <th>EmailId</th>
                                    <th>Phone</th>
                                    <th>Status</th>
                                    <th>Email Varified</th>
                                    <th>Cart</th>
                                    <th>Orders</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <img src="../../<%=item.Customers_Photo %>" style="height: 50px; width: 50px" /></td>
                                    <td><a href="/administration/salesmanagement/detail.aspx?id=<%=item.Customer_Id %>"><%=item.Customers_FullName %></a></td>
                                    <td><%=item.Customers_EmailId %></td>
                                    <td><%=item.Customers_Phone %></td>
                                    <th><%=item.Customers_Status %></th>
                                     <%if (item.IsEmailVerified == 1)
                                        {%>
                                    <td>
                                        <span class="label label-success">Verified
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        { %>
                                    <td><span class="label label-danger">Not Verified
                                    </span></td>
                                    <%} %>
                                    <td><%=item.Cart.Count %></td>
                                    <td><%=item.Orders.Count %></td>
                                    <td>
                                        <a href="/administration/salesmanagement/cart.aspx?customer_id=<%=item.Customer_Id %>&requesttype=edit-customer-detail.html"><i class="fa fa-shopping-cart fa-lg" title="Cart"></i></a>
                                        &nbsp;&nbsp;&nbsp;
                                    <a href="/administration/salesmanagement/orders.aspx?customer_id=<%=item.Customer_Id %>&requesttype=edit-customer-detail.html"><i class="fa fa-book fa-lg" title="Orders"></i></a>
                                    </td>
                                    <%} %>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
