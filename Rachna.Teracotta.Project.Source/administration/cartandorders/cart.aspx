<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.cartandorders.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="/administration/default.aspx?redirecturl=admin-home-RachnaTeracotta">Home</a></li>
            <li class="active">All Users</li>
        </ul>
    </div>
    <!-- /breadcrumb-->
    <div class="panel panel-default">
        <div class="panel-body">
            <div style="margin-left: 10px; margin-top: 10px; margin-bottom: 10px">
                <h3>All Approved Users
                </h3>
                <p>
                    All the customer detail will be displayed here.
                </p>
            </div>
            <%
                var customerId = Request.QueryString["customer_id"].ToString();
                List<Rachna.Teracotta.Project.Source.Models.Carts> _RequestList = null;
                using (var ctx = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext())
                {
                    _RequestList = ctx.Cart.ToList().Where(m => m.Customer_Id == Convert.ToInt32(customerId)).ToList();
                }
            %>
            <div class="padding-md">
                <div class="panel panel-default table-responsive">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                <th></th>
                                <th>Cart Id</th>
                                <th>Customer Name</th>
                                <th>Product Name</th>
                                <th>Product Code</th>
                                <th>Unit Price</th>
                                <th>Size</th>
                                <th>Quantity</th>
                                <th>SubTotal</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% 
                                foreach (var item in _RequestList)
                                {
                            %>
                            <tr>
                                <td>
                                    <img src="../../<%=item.Product_Banner %>" style="height: 50px; width: 50px" />
                                </td>
                                <td><%=item.Cart_Id %></td>
                                <td><%=item.Customer_Name %></td>
                                <td><%=item.Product_Title %></td>
                                <td><%=item.Product_Id %></td>
                                <td><%=item.Product_Price %></td>
                                <td><%=item.Cart_Size %></td>
                                <td><%=item.Cart_Qty %></td>
                                <td><%=item.Cart_Price %></td>
                                <td><%=item.Cart_Status %></td>
                                <%} %>
                            </tr>
                        </tbody>
                    </table>
                    <!-- /.padding-md -->
                </div>
                <!-- /panel -->
            </div>
        </div>
    </div>
</asp:Content>
