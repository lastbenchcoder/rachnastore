<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="delieverymethod.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.salesmanagement.delieverymethod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.DeliveryMethod> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.DeliveryMethod.ToList();
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Delivery Methods</h1>
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
                    <a href="#">Catalog</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Sales Management</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Delivery Methods</a>
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
                            Delivery Methods
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Delivery Method</th>
                                    <th>Title</th>
                                    <th>Description</th>
                                    <th>Status</th>
                                    <th>DateCreated</th>
                                    <th>DateUpdated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <%=item.DeliveryMethod_Id %>
                                    </td>
                                    <td><%=item.Title %></td>
                                    <td><%=item.Description %></td>
                                    <%if (item.Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
                                        {%>
                                    <td><span style="font-weight: bold; color: green">
                                        <%=item.Status %>
                                    </span></td>
                                    <%}
                                        else
                                        { %>
                                    <td><span style="font-weight: bold; color: red">
                                        <%=item.Status %>
                                    </span></td>
                                    <%} %>
                                    <td>
                                        <%=item.DateCreated.ToString("D") %>
                                    </td>
                                    <td>
                                        <%=item.DateUpdated.ToString("D") %>
                                    </td>
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
