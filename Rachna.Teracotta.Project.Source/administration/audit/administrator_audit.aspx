<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="administrator_audit.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.audit.administrator_audit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Administrator_Audit> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.Administrator_Audit.ToList();
    %>
    <div class="padding-md">
        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Administrator History</h4>
                </div>
                <div class="panel-body">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                <th>Admin Code</th>
                                <th>Store_Id</th>
                                <th>FullName</th>
                                <th>EmailId</th>
                                <th>Phone</th>
                                <th>Status</th>
                                <th>Role</th>
                                <th>DateCreated</th>
                                <th>DateUpdated</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% 
                                foreach (var item in _RequestList)
                                {
                            %>
                            <tr>
                                <td><%=item.AdminCode %></td>
                                <td><%=item.Store_Id %></td>
                                <td><%=item.FullName %></td>
                                <td><%=item.EmailId %></td>
                                <td><%=item.Phone %></td>
                                <td><%=item.Admin_Status %></td>
                                <td><%=item.Admin_Role %></td>
                                <td><%=item.Admin_CreatedDate %></td>
                                <td><%=item.Admin_UpdatedDate %></td>
                                <td><%=item.Action %></td>
                                <% 
                                    }
                                %>
                        </tbody>
                    </table>
                    <!-- /.padding-md -->
                </div>
            </div>
            <!-- /panel -->
        </div>
    </div>
</asp:Content>
