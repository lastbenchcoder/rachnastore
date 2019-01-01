<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="emailtracker.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.emailTracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.EmailTracker> _emailTracker = null;
        _emailTracker = Rachna.Teracotta.Project.Source.Core.bal.bAdministrator.ListEmailTracker();
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Invitation</h1>
            </div>
            <div class="pull-right">
                <a href="#modalInvitation" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Email Tracker</a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <asp:panel id="pnlErrorMessage" class="page-header" runat="server" visible="false" style="margin-top: 10px">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </asp:panel>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Email Tracker
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Mail From</th>
                                    <th>Mail Subject</th>
                                    <th>ToEmailId</th>
                                    <th>Status</th>
                                    <th>Result</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in _emailTracker)
                                    { %>
                                <tr>
                                    <td><%=item.MailFrom %></td>
                                    <td><%=item.MailSubject %></td>
                                    <td><%=item.ToEmailId %></td>
                                     <td><%=item.Result %></td>
                                    <%if (item.Status == Rachna.Teracotta.Project.Source.Entity.eEmailStatus.Success.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success">Success
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        {%>
                                    <td class='hidden-350'>
                                        <span class="label label-danger">Failed
                                        </span>
                                    </td>
                                    <%} %>
                                    <td class='hidden-1024'><%=item.DateCreated.ToString("D") %></td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
