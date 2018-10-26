<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="ordersdelivery.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.delivery.ordersdelivery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.OrderDelivery> _RequestList = null;
        using (var ctx = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext())
        {
            _RequestList = ctx.OrderDelivery.Include("DeleveryTeam").Include("Order").Include("Stores").ToList();
        }
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Order For Delivery</h1>
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
                    <a href="#">Sales & Payment</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Order For Delivery</a>
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
                            Order For Delivery
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Store</th>
                                    <th>Customer</th>
                                    <th>Product</th>
                                    <th>Total Quantity</th>
                                    <th>Status</th>
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
                                        <img src="../../<%=item.Order.Product_Banner %>" style="height: 50px; width: 50px" /></td>
                                    <td><a href="/administration/storedetail.aspx?id=<%=item.Stores.Store_Id %>" target="_blank"><%=item.Stores.Store_Name %></a></td>
                                    <td><a href="/administration/salesmanagement/detail.aspx?id=<%=item.Order.Customer_Id %>" target="_blank"><%=item.Order.Customer_Name %></a></td>
                                    <td><a href="/administration/product/productsdetailstatic.aspx?Productid=<%=item.Order.Product_Id %>" target="_blank"><%=item.Order.Product_Title %></a></td>
                                    <td><%=item.Order.Order_Qty %></td>
                                    <th><%=item.Status %></th>
                                    <td><a href="/administration/product/ordereditdelivery.aspx?deliveryid=<%=item.Order_Delivery_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
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
