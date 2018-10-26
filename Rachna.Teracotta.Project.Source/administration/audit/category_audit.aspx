<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="category_audit.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.audit.category_audit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%
        List<Rachna.Teracotta.Project.Source.Models.Categories_Audit> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.Categories_Audit.ToList();
    %>
    <div class="padding-md">
        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Category History</h4>
                </div>
                <div class="panel-body">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                <th>Category_Id</th>
                                <th>CategoryCode</th>
                                <th>Category_Title</th>
                                <th>Category_Description</th>
                                <th>Administrators_Id</th>
                                <th>Category_CreatedDate</th>
                                <th>Category_UpdatedDate</th>
                                <th>Category_Status</th>
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
                                <td><%=item.Category_Id %></td>
                                <td><%=item.CategoryCode %></td>
                                <td><%=item.Category_Title %></td>
                                <td><%=item.Category_Description %></td>
                                <td><%=item.Administrators_Id %></td>
                                <td><%=item.Category_CreatedDate %></td>
                                <td><%=item.Category_UpdatedDate %></td>
                                <td><%=item.Category_Status %></td>
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
