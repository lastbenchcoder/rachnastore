<%@ Page Title="" Language="C#" MasterPageFile="~/adminvendor/Home.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.adminvendor._default" %>

<%@ Register Src="~/administration/uc/_reviewpendingitems.ascx" TagPrefix="uc1" TagName="reviewPendingUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Rachna.Teracotta.Project.Source.Helper.AdminDashboardHelper _admin = null;
        Rachna.Teracotta.Project.Source.Helper.AdministratorDetail _bdashboard = new Rachna.Teracotta.Project.Source.Helper.AdministratorDetail();
        _admin = _bdashboard.GetVendorDashBoardDetail(Convert.ToInt32(Session[ConfigurationSettings.AppSettings["VendorSession"].ToString()].ToString()));
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Welcome <%=_admin.Administrators.FullName%>!!!</h1>
            </div>
            <div class="pull-right">
                <ul class="stats">
                    <li class='satgreen'>
                        <i class="fa fa-briefcase"></i>
                        <div class="details">
                            <span class="big"><%=_admin.TotalInvitation %></span>
                            <span>Stores</span>
                        </div>
                    </li>
                    <li class='lightred'>
                        <i class="fa fa-user"></i>
                        <div class="details">
                            <span class="big"><%=_admin.TotalAdministrator %></span>
                            <span>Invitation</span>
                        </div>
                    </li>
                    <li class='satgreen'>
                        <i class="fa fa-comment"></i>
                        <div class="details">
                            <span class="big"><%=_admin.TotalPendingInvitation %></span>
                            <span>Pending Invitation</span>
                        </div>
                    </li>
                    <li class='satgreen'>
                        <i class="fa fa-anchor"></i>
                        <div class="details">
                            <span class="big"><%=_admin.TotalCustomer %></span>
                            <span>Customer</span>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="#">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Administrator</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/default.aspx?redirecturl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Dashboard</a>
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
                            Pending Invitations
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>EmailId</th>
                                    <th>Role</th>
                                    <th class='hidden-350'>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in _admin.Invitations.Where(m => m.Invitation_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString()))
                                    { %>
                                <tr>
                                    <td><%=item.Invitation_EmailId %></td>
                                    <td><%=item.Role %></td>
                                    <%if (item.Invitation_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.InActive.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success">
                                            <%=item.Invitation_Status %>
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
                                    <td class='hidden-1024'><%=item.Invitation_CreatedDate.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.Invitation_UpdatedDate.ToString("D") %></td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Products Pending Review
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Product Id</th>
                                    <th>Store</th>
                                    <th></th>
                                    <th>Code</th>
                                    <th>Product</th>
                                    <th>Category</th>
                                    <th>CreatedBy</th>
                                    <th>Status</th>
                                    <th>Edit Detail</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _admin.ProdPendForReview)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <%=item.Product_Id %>
                                    </td>
                                    <td>
                                        <%=item.Store.Store_Name %>
                                    </td>
                                    <td><a href="/administration/product/uploadproductsbanner.aspx?Productid=<%=item.Product_Id %>"><%if (item.ProductBanner.Count > 0)
                                            { %>
                                        <img src="../../<%=item.ProductBanner.Where(m => m.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo %>" style="height: 50px; width: 50px" />
                                        <%}
                                            else
                                            { %>
                                        <img src="../../content/noimage.png" style="height: 50px; width: 50px" />
                                        <%} %>
                                    </a>
                                    </td>
                                    <td><%=item.ProductCode %></td>
                                    <%if (item.Product_Title.Length > 30)
                                        {%>
                                    <td><%=item.Product_Title.Substring(0, 30).ToString() %><span>...</span></td>
                                    <%}
                                        else
                                        { %>
                                    <td><%=item.Product_Title %><span>...</span></td>
                                    <%} %>
                                    <td><%=item.SubCategory.SubCategory_Title %>(<%= item.SubCategory.Category.Category_Title %>)</td>
                                    <td><%=item.Admin.FullName %></td>
                                    <td><span class="label label-danger">Review Pending</span></td>
                                    <td><a href="/administration/product/productsdetailstatic.aspx?Productid=<%=item.Product_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                                    <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Products Pending For Approve
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Product Id</th>
                                    <th>Store</th>
                                    <th></th>
                                    <th>Code</th>
                                    <th>Product</th>
                                    <th>Category</th>
                                    <th>CreatedBy</th>
                                    <th>Status</th>
                                    <th>Edit Detail</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _admin.ProdPendForApprove)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <%=item.Product_Id %>
                                    </td>
                                    <td>
                                        <%=item.Store.Store_Name %>
                                    </td>
                                    <td><a href="/administration/product/uploadproductsbanner.aspx?Productid=<%=item.Product_Id %>"><%if (item.ProductBanner.Count > 0)
                                            { %>
                                        <img src="../../<%=item.ProductBanner.Where(m => m.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo %>" style="height: 50px; width: 50px" />
                                        <%}
                                            else
                                            { %>
                                        <img src="../../content/noimage.png" style="height: 50px; width: 50px" />
                                        <%} %>
                                    </a>
                                    </td>
                                    <td><%=item.ProductCode %></td>
                                    <%if (item.Product_Title.Length > 30)
                                        {%>
                                    <td><%=item.Product_Title.Substring(0, 30).ToString() %><span>...</span></td>
                                    <%}
                                        else
                                        { %>
                                    <td><%=item.Product_Title %><span>...</span></td>
                                    <%} %>
                                    <td><%=item.SubCategory.SubCategory_Title %>(<%= item.SubCategory.Category.Category_Title %>)</td>
                                    <td><%=item.Admin.FullName %></td>
                                    <td><span class="label label-danger">Approve Pending</span></td>
                                    <td><a href="/administration/product/productsdetailstatic.aspx?Productid=<%=item.Product_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                                    <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Products Pending For Publish
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Product Id</th>
                                    <th>Store</th>
                                    <th></th>
                                    <th>Code</th>
                                    <th>Product</th>
                                    <th>Category</th>
                                    <th>CreatedBy</th>
                                    <th>Status</th>
                                    <th>Edit Detail</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _admin.ProdPendForPublish)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <%=item.Product_Id %>
                                    </td>
                                    <td>
                                        <%=item.Store.Store_Name %>
                                    </td>
                                    <td><a href="/administration/product/uploadproductsbanner.aspx?Productid=<%=item.Product_Id %>"><%if (item.ProductBanner.Count > 0)
                                            { %>
                                        <img src="../../<%=item.ProductBanner.Where(m => m.Product_Banner_Default == 1).FirstOrDefault().Product_Banner_Photo %>" style="height: 50px; width: 50px" />
                                        <%}
                                            else
                                            { %>
                                        <img src="../../content/noimage.png" style="height: 50px; width: 50px" />
                                        <%} %>
                                    </a>
                                    </td>
                                    <td><%=item.ProductCode %></td>
                                    <%if (item.Product_Title.Length > 30)
                                        {%>
                                    <td><%=item.Product_Title.Substring(0, 30).ToString() %><span>...</span></td>
                                    <%}
                                        else
                                        { %>
                                    <td><%=item.Product_Title %><span>...</span></td>
                                    <%} %>
                                    <td><%=item.SubCategory.SubCategory_Title %>(<%= item.SubCategory.Category.Category_Title %>)</td>
                                    <td><%=item.Admin.FullName %></td>
                                    <td><span class="label label-danger">Publish Pending</span></td>
                                    <td><a href="/administration/product/productsdetailstatic.aspx?Productid=<%=item.Product_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                                    <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
