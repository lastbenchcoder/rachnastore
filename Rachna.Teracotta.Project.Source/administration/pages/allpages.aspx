<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="allpages.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.pages.allpages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Pages> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.Pages.Include("Admin").ToList();
    %>

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="/administration/default.aspx?ids=687324jhkjhkjh8798797987987&redirecturl=admin-home-<%=DateTime.Now %>">Home</a></li>
            <li class="active">All Pages</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="panel panel-default">
            <div class="col-md-8">
                <h4>Pages offered</h4>
                <p style="margin-top: 20px">
                    With multiple Pages, you are able to categorize your choice of Pages according to target group. 
                        Each Pages will be accessible through its own area and can be configured individually.
            </div>
            <div class="col-md-4">
                <div style="float: right; margin-top: 10px">
                    <a href="/administration/Pages/newpage.aspx?redirect=add-new-Pages.htm?pageid=yyghjghjg234234234234" class="btn btn-info">+ Add New</a>
                </div>
            </div>
            <table class="table table-striped" id="dataTable">
                <thead>
                    <tr>
                        <th>Pages Id</th>
                        <th>Title</th>
                        <th>DateCreated</th>
                        <th>DateUpdated</th>
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
                        <td><%=item.Page_Id %></td>
                        <td><%=item.Title %></td>
                        <td><%=item.DateCreated.ToString("D") %></td>
                        <td><%=item.DateUpdated.ToString("D") %></td>
                        <td><%=item.Admin.FullName %></td>
                        <td>
                            <a href="/administration/pages/pagedetail.aspx?pageid=<%=item.Page_Id %>&page-Id=1234"><i class="fa fa-edit fa-lg"></i></a>
                        </td>
                        <%} %>
                </tbody>
            </table>
        </div>
        <!-- /.padding-md -->
    </div>
</asp:Content>
