<%@ Page Title="" Language="C#" MasterPageFile="~/adminvendor/Home.Master" AutoEventWireup="true" CodeBehind="deleverydetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.adminvendor.salesmanagement.deleverydetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="/administration/default.aspx?redirecturl=admin-home-RachnaTeracotta">Home</a></li>
            <li class="active">Category</li>
        </ul>
    </div>
    <!-- /breadcrumb-->

    <%
        List<Rachna.Teracotta.Project.Source.Models.OrderDelivery> _RequestList = null;
        Rachna.Teracotta.Project.Source.Models.Administrators _Administrator = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _Administrator = Rachna.Teracotta.Project.Source.Core.bal.bAdministrator.List().Where(m => m.Administrators_Id == Convert.ToInt32(Session[ConfigurationSettings.AppSettings["VendorSession"].ToString()].ToString())).FirstOrDefault();
        _RequestList = context.OrderDelivery.Include("DeleveryTeam").Include("Order").Include("Administrators").Where(m=>m.Store_Id==_Administrator.Store_Id).ToList();
        foreach(var item in _RequestList)
        {
            item.DeleveryTeam.DeliveryMethod = context.DeliveryMethod.Where(m => m.DeliveryMethod_Id == item.DeleveryTeam.DeliveryMethod_Id).FirstOrDefault();
        }
    %>

    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <h4>Manage Delevery</h4>
                    <p>
                        Delevery detail can be updated here.
                    </p>
                </div>
            </div>
            <table class="table table-striped" id="dataTable">
                <thead>
                    <tr>
                        <th>Delevery Method</th>
                        <th>Team Name</th>
                        <th>EmailId</th>
                        <th>Phone</th>
                        <th>Date Of Delevery</th>
                        <th>Status</th>                        
                        <th>Edit Detail</th>
                    </tr>
                </thead>
                <tbody>
                    <% 
                        foreach (var item in _RequestList)
                        {
                    %>
                    <tr>
                        <td>
                            <%=item.DeleveryTeam.DeliveryMethod.Title %></td>
                        <td>
                            <%=item.DeleveryTeam.Name %>
                        </td>
                        <td><%=item.DeleveryTeam.EmailId %></td>
                        <td><%=item.DeleveryTeam.Phone %></td>
                        <td><%=item.Order.Order_Delievery_Date.ToString("D") %></td>
                        <%if (item.Status == Rachna.Teracotta.Project.Source.Entity.eOrderDeliveryStatus.DelveryCompleted.ToString())
                            {%>
                        <td><span style="font-weight: bold; color: green">
                            <%=item.Status %>
                        </span></td>
                        <%}
                            else
                            { %>
                        <td><span style="font-weight: bold; color: red">
                            <%=item.Status %>
                        </span></td>
                        <%} %>
                        <td><a href="/adminvendor/categories/deleverydetailedit.aspx?catid=<%=item.Order_Delivery_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                        <%
                            }
                        %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
