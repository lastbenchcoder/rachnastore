<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="emailsubscription.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.subscription.emailsubscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Subscription> _RequestList = null;
        using (var ctx = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext())
        {
            _RequestList = ctx.Subscribe.ToList();
        }
        int count_request = 0;
        if (_RequestList.Count() > 0)
        {
            count_request = _RequestList.Count();
        }
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Email Subscription Users</h1>
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
                    <a href="#">Email Subscription Users</a>
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
                            Email Subscription Users
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>EmailId</th>
                                    <th>Status</th>
                                    <th>CreatedDate</th>
                                    <th>UpdatedDate</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td><%=item.Subscription_Id %></td>
                                    <td><%=item.Subscription_EmailId %></td>
                                    <td><%=item.Subscription_Status %></td>
                                    <td><%=item.Subscription_CreatedDate %></td>
                                    <td><%=item.Subscription_UpdatedDate %></td>
                                    <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
