<%@ Page Title="" Language="C#" MasterPageFile="~/support/home/Home.Master" AutoEventWireup="true" ValidateRequest="false"  CodeBehind="default.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.support.home._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HyperLink ID="btnRejectModel" runat="server" data-toggle="modal" data-target="#modalFunctionality" class="btn btn-danger">Functionality</asp:HyperLink>


    <%
        Rachna.Teracotta.Project.Source.Models.Administrators _Administrator = null;
        List<Rachna.Teracotta.Project.Source.Models.Functionality> Functionality = null;
        List<Rachna.Teracotta.Project.Source.Models.FunctionalDefect> FunctionalDefect = null;
        Functionality = Rachna.Teracotta.Project.Source.Core.bal.bFunctionality.List();
        FunctionalDefect = Rachna.Teracotta.Project.Source.Core.bal.bFunctionalDefect.List();
        _Administrator = Rachna.Teracotta.Project.Source.Core.bal.bAdministrator.List().Where(m => m.Administrators_Id == Convert.ToInt32(Session[ConfigurationSettings.AppSettings["SupportSession"].ToString()].ToString())).FirstOrDefault();

    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Welcome <%=_Administrator.FullName%>!!!</h1>
            </div>
            <div class="pull-right">
                <ul class="stats">
                    <li class='satgreen'>
                        <a href="/support/home/functionality.aspx?redirecturl=admin-functionality-rachna-teracotta">
                            <i class="fa fa-briefcase"></i>
                            <div class="details">
                                <span class="big"><%=Functionality.Count %></span>
                                <span>Functionalities</span>
                            </div>
                        </a>
                    </li>
                    <li class='lightred'>
                        <a href="/support/home/functionaldefect.aspx?redirecturl=admin-defect-manager-rachna-teracotta">
                            <i class="fa fa-comment"></i>
                            <div class="details">
                                <span class="big"><%=FunctionalDefect.Count %></span>
                                <span>Defects</span>
                            </div>
                        </a>
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
                    <a href="/support/default.aspx?redirecturl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979">Dashboard</a>
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
                <div class="box box-bordered box-color">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-envelope"></i>
                            Functionalities Defect
                        </h3>
                    </div>
                    <div class="box-content nopadding">

                        <div class="tab-content">
                            <div class="tab-pane active" id="inbox">
                               <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Code</th>
                                    <th>Title</th>
                                    <th>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in FunctionalDefect)
                                    { %>
                                <tr>
                                    <td><%=item.FunctionalityDefectCode %></td>
                                    <td><%=item.Title %></td>
                                    <%if (item.Status == Rachna.Teracotta.Project.Source.Entity.eFunctionalityStatus.Completed.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success"><%=item.Status %>
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        {%>
                                    <td class='hidden-350'>
                                        <span class="label label-danger"><%=item.Status %>
                                        </span>
                                    </td>
                                    <%} %>
                                    <td class='hidden-1024'><%=item.CreatedDate.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.UpdatedDate.ToString("D") %></td>
                                    <td>
                                        <a href="/support/functionalitydefectdetail.aspx?defectid=<%=item.Defect_Id %>&pageId=1234"><i class="fa fa-edit fa-lg"></i></a>
                                    </td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
