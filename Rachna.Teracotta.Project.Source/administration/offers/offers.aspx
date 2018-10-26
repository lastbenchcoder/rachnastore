<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="offers.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.offers.offers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Offers> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.Offers.Include("Store").Include("Admin").ToList();
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Offers</h1>
            </div>
            <div class="pull-right">
                <a href="/administration/offers/newoffers.aspx?redirect=add-new-offers.htm?pageid=yyghjghjg234234234234" class="btn btn-primary" style="margin-top: 15px">+ Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Offers</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">View All Offers</a>
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
                            All Offers
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Offers Code</th>
                                    <th></th>
                                    <th>StoreName</th>
                                    <th>Title</th>
                                    <th>StartDate</th>
                                    <th>EndDate</th>
                                    <th>CreatedBy</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td><%=item.Offer_Code %></td>
                                    <td>
                                        <img src="../../<%=item.Offer_Banner %>" width="100" height="100" />
                                    </td>
                                    <td><%=item.Store.Store_Name %></td>
                                    <td><%=item.Offer_Title %></td>
                                    <td><%=item.Offer_StartsDate.ToString("D") %></td>
                                    <td><%=item.Offer_EndDate.ToString("D") %></td>
                                    <td><%=item.Admin.FullName %></td>
                                    <td>
                                        <a href="/administration/offers/offerdetail.aspx?offerid=<%=item.Offer_Id %>&pageId=1234"><i class="fa fa-edit fa-lg"></i></a>
                                    </td>
                                    <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
