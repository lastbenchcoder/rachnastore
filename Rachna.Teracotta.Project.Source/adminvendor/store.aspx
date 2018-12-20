<%@ Page Title="" Language="C#" MasterPageFile="~/adminvendor/Home.Master" AutoEventWireup="true" CodeBehind="store.aspx.cs" Inherits="Page3.Project.Source.adminvendor.store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Stores> _RequestList = null;        
        _RequestList = Rachna.Teracotta.Project.Source.Core.bal.bStores.List();
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Store Information</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/adminvendor/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Stores & Admin</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Add/View Stores</a>
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
                            Store Information
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Store Code</th>
                                    <th>Store Name</th>
                                    <th>Store Url</th>
                                    <th>Status</th>
                                    <th>DateCreated</th>
                                    <th>DateUpdated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <img src="../<%=item.Store_Logo %>" style="height: 50px; width: 50px" /></td>
                                    <td><%=item.StoreCode %></td>
                                    <td><%=item.Store_Name %></td>
                                    <td><%=ConfigurationSettings.AppSettings["DomainUrl"].ToString()+item.Store_Url %></td>
                                    <%if (item.Store_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success"><%=item.Store_Status %>
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        {%>
                                    <td class='hidden-350'>
                                        <span class="label label-danger"><%=item.Store_Status %>
                                        </span>
                                    </td>
                                    <%} %>
                                    <td><%=item.Store_CreatedDate.ToString("D") %></td>
                                    <td><%=item.Store_UpdatedDate.ToString("D") %></td>
                                    <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
