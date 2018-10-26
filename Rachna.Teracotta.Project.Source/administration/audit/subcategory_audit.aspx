<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="subcategory_audit.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.audit.subcategory_audit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.SubCategories_Audit> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.SubCategories_Audit.ToList();
    %>
    <div class="padding-md">
        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Sub Category History</h4>
                </div>
                <div class="panel-body">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                 <th>SubCategory_Id</th>
                                <th>Category_Id</th>
                                <th>SubCategoryCode</th>
                                <th>SubCategory_Title</th>
                                <th>SubCategory_Description</th>
                                <th>SubAdministrators_Id</th>
                                <th>SubCategory_CreatedDate</th>
                                <th>SubCategory_UpdatedDate</th>
                                <th>SubCategory_Status</th>
                                <th>SubDateUpdated</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% 
                                foreach (var item in _RequestList)
                                {
                            %>
                            <tr>
                                 <td><%=item.SubCategory_Id %></td>
                                <td><%=item.Category_Id %></td>
                                <td><%=item.SubCategoryCode %></td>
                                <td><%=item.SubCategory_Title %></td>
                                <td><%=item.SubCategory_Description %></td>
                                <td><%=item.Administrators_Id %></td>
                                <td><%=item.SubCategory_CreatedDate %></td>
                                <td><%=item.SubCategory_UpdatedDate %></td>
                                <td><%=item.SubCategory_Status %></td>
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
