<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="searchedkeywords.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.customer.searchedkeywords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-default">
        <div class="panel-body">
            <div style="margin-left: 10px; margin-top: 10px; margin-bottom: 10px">
                <h3>All Customers Search Items 
                </h3>
                <p>
                    All the customer searched key detail will be displayed here. 
                </p>
            </div>
            <%
                List<Rachna.Teracotta.Project.Source.Models.CustomerSearchKey> _RequestList = null;
                using (var ctx = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext())
                {
                    _RequestList = ctx.CustomerSearchKey.ToList();
                }
            %>
            <div class="padding-md">
                <div class="panel panel-default table-responsive">
                    <table class="table table-striped" id="dataTable">
                        <thead>
                            <tr>
                                <th>IpAdress</th>
                                <th>Search Key</th>
                                <th>Date Of Search</th
                            </tr>
                        </thead>
                        <tbody>
                            <% 
                                foreach (var item in _RequestList)
                                {
                            %>
                            <tr>
                                <td><%=item.IpAddress %></td>
                                <td><%=item.SearchKey %></td>
                                <td><%=item.DateCreated.ToString("D")%></td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                    <!-- /.padding-md -->
                </div>
                <!-- /panel -->
            </div>
        </div>
    </div>
</asp:Content>
