<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="mostvisitedproduct.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.customer.mostvisitedproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
        List<Rachna.Teracotta.Project.Source.Models.VisitedProducts> _RequestList = null;
        using (var ctx = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext())
        {
            _RequestList = ctx.VisitedProducts.ToList();
        }
    %>


    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Products Visited By Customers</h1>
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
                    <a href="#">All Products Visited By Customers</a>
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
                            All Products Visited By Customers
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Product Id</th>
                                    <th></th>
                                    <th>Product Name</th>
                                    <th>IpAddress</th>
                                    <th>Visited Count</th>
                                    <th>Date Visited</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td><%=item.Product_Id %></td>
                                    <td>
                                        <img src="../../<%=item.ProductBanner %>" style="height: 50px; width: 50px" />
                                    </td>
                                    <td><a href="/administration/product/productsdetailstatic.aspx?Productid=<%=item.Product_Id %>"><%=item.ProductTitle %></a></td>
                                    <td><%=item.IpAddress %></td>
                                    <td><%=item.VisitedCount %></td>
                                    <td><%=item.DateCreated.ToString("D") %></td>
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
