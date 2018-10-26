<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="store_audit.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.audit.store_audit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Stores_Audit> _RequestList = null;
        _RequestList = Rachna.Teracotta.Project.Source.Core.bal.bStores.AuditList();
    %>
    <div class="padding-md">
        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Store History</h4>
                </div>
                <div class="panel-body">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                <th>Store_Id</th>
                                <th>StoreCode</th>
                                <th>Store_Name</th>
                                <th>Store_Url</th>
                                <th>Store_Logo</th>
                                <th>Store_CreatedDate</th>
                                <th>Store_UpdatedDate</th>
                                <th>Store_Status</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% 
                                foreach (var item in _RequestList)
                                {
                            %>
                            <tr>
                                <td><%=item.Store_Id %></td>
                                <td><%=item.StoreCode %></td>
                                <td><%=item.Store_Name %></td>
                                <td><%=item.Store_Url %></td>
                                <td><%=item.Store_Logo %></td>
                                <td><%=item.Store_CreatedDate %></td>
                                <td><%=item.Store_UpdatedDate %></td>
                                <td><%=item.Store_Status %></td>
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
