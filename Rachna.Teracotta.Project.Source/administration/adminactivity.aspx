<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="adminactivity.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.adminactivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.AdminActivity> AdminActivity = null;
        AdminActivity = Rachna.Teracotta.Project.Source.Core.bal.bAdministrator
         .ListActivityByAdmin(Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()));
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Administrators Activity</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Administration</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Admin Activity</a>
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
                            Administrator Activity
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>FullName</th>
                                    <th>EmailId</th>
                                    <th>Category</th>
                                    <th>Description</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in AdminActivity)
                                    { %>
                                <tr>
                                    <td>
                                        <img src="../../<%=item.Administrators.Photo%>" width="50" height="50" /></td>
                                    <td><%=item.Administrators.FullName %></td>
                                    <td><%=item.Administrators.EmailId %></td>
                                    <td><%=item.Category %></td>
                                    <td><%=item.Description %></td>
                                    <td class='hidden-1024'><%=item.Activity_CreatedDate.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.Activity_UpdatedDate.ToString("D") %></td>
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

