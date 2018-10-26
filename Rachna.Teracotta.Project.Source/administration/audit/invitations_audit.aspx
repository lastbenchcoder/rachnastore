<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="invitations_audit.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.audit.invitations_audit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Invitations_Audit> Invitations = null;
        Invitations = Rachna.Teracotta.Project.Source.Core.bal.bInvitations.AuditList();
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Invitation</h1>
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
                    <a href="#">More</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Audit</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Invitation Audit</a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Invitation
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Role</th>
                                    <th>Store Id</th>
                                    <th>EmailId</th>
                                    <th>Status</th>
                                    <th>Registration Link</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-1024'>DateUpdated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in Invitations)
                                    { %>
                                <tr>
                                    <td><%=item.Role %></td>
                                    <td><%=item.Store_Id %></td>
                                    <td><%=item.Invitation_EmailId %></td>
                                    <%if (item.Invitation_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.InActive.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success">Completed
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        {%>
                                    <td class='hidden-350'>
                                        <span class="label label-danger">Pending
                                        </span>
                                    </td>
                                    <%} %>
                                    <td>
                                        <p><%=System.Configuration.ConfigurationSettings.AppSettings["DomainUrl"].ToString() %>/account/invitation.aspx?code=<%= item.Invitation_Code %>&emailid=<%= item.Invitation_EmailId %></p>
                                    </td>
                                    <td class='hidden-1024'><%=item.Invitation_CreatedDate.ToString("D") %></td>
                                    <td class='hidden-1024'><%=item.Invitation_UpdatedDate.ToString("D") %></td>
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
