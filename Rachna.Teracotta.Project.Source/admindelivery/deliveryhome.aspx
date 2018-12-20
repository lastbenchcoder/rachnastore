<%@ Page Title="" Language="C#" MasterPageFile="~/admindelivery/Home.Master" AutoEventWireup="true" CodeBehind="deliveryhome.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.admindelivery.deliveryhome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.OrderDelivery> _RequestList = null;
        if (Session["DelieveryKey"] != null)
        {
            int teamId = Convert.ToInt32(Session["DelieveryKey"]);
            using (var ctx = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext())
            {
                _RequestList = ctx.OrderDelivery.Include("DeleveryTeam").Include("Order").Include("Stores").Where(m => m.TeamId == teamId).ToList();
            }
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
                                    <td><%=item.Stores.Store_Name %></td>
                                    <td><%=item.Order.Customer_Name %></td>
                                    <td><%=item.Order.Product_Title %></td>
                                    <td><%=item.Order.Order_Qty %></td>
                                    <th><%=item.Status %></th>
                                    <%if (item.Status != Rachna.Teracotta.Project.Source.Entity.eOrderDeliveryStatus.DeliveryFailed.ToString() &&
                                                item.Status != Rachna.Teracotta.Project.Source.Entity.eOrderDeliveryStatus.DeliveryRejected.ToString() &&
                                                item.Status != Rachna.Teracotta.Project.Source.Entity.eOrderDeliveryStatus.DelveryCompleted.ToString())
                                        {%>
                                    <td><a href="/admindelivery/delieveryupdate.aspx?delId=<%=item.Order_Delivery_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                                    <%}
                                        else
                                        { %>
                                    <td><a href="#"><i class="fa fa-edit fa-lg"></i></a></td>
                                    <% }
                                        } %>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
