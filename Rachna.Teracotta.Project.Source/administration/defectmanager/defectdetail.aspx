<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="defectdetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.defectmanager.defectdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Rachna.Teracotta.Project.Source.Models.FunctionalDefect _RequestList = null;
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
            _RequestList = context.DefectsManager.Include("Administrators").Include("FunctionalDefectStory").Where(m => m.Defect_Id == id).FirstOrDefault();
            if (_RequestList != null)
            {
                _RequestList.Resolver = context.Administrator.Where(m => m.Administrators_Id == _RequestList.Administrators_Id).FirstOrDefault();
                if (_RequestList.FunctionalDefectStory != null)
                {
                    foreach (var item in _RequestList.FunctionalDefectStory)
                    {
                        item.Administrators = context.Administrator.Where(m => m.Administrators_Id == item.Administrators_Id).FirstOrDefault();
                        item.Resolver = context.Administrator.Where(m => m.Administrators_Id == item.Resolver_Id).FirstOrDefault();
                    }
                }
            }
        }
    %>
    <%if (_RequestList != null)
        { %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1><%=_RequestList.Function_Id %><span>&nbsp;.&nbsp;</span><%=_RequestList.Title %></h1>
            </div>
            <div class="pull-right">
                        <a href="/administration/defectmanager/defectedit.aspx?id=<%=_RequestList.Defect_Id %>&redirect-url=jhgj657657HGH.htm" class="btn btn-danger">Edit the Defect
								</a>
                        <a href="/administration/defectmanager/defect.aspx?redirect-url=jhgj657657HGH.htm" class="btn btn-success">Go Back to List</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="more-login.html">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/defectmanager/defect.aspx?redirectUrl=jhgj657657HGH.htm">Defect</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#"><%=_RequestList.Function_Id %><span>&nbsp;.&nbsp;</span><%=_RequestList.Title %></a>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="box">
                    <div class="box-title">
                        <h3>
                            <%=_RequestList.Function_Id %><span>&nbsp;.&nbsp;</span><%=_RequestList.Title %>
								</h3>
                    </div>
                    <div class="box-content">
                        <h4>
                            <%=_RequestList.Description %>
                        </h4>
                        <%if (_RequestList.Banner != null && _RequestList.Banner != "")
                            { %>
                        <img src="../../<%=_RequestList.Banner %>" width="100" height="100" />
                        <%} %>
                        <h5><strong>Defect Id : #<%=_RequestList.Function_Id %></strong></h5>
                        <span class="text-muted">Created By : <%=_RequestList.Administrators.FullName %></span><br />
                        <h5 class="text-muted" style="color: blue;">Resolver : <%=_RequestList.Resolver.FullName %></h5>
                        <strong>Due Date : <%=_RequestList.FixDate.ToString("D") %></strong>
                        <%if (_RequestList.Status == Rachna.Teracotta.Project.Source.Entity.eFunctionalityStatus.Completed.ToString())
                            {%>
                        <h5 style="color: green;"><%=_RequestList.Status.ToUpper() %></h5>

                        <%}
                            else
                            { %>
                        <h5>Status: <span style="color: red;"><%=_RequestList.Status.ToUpper() %></span></h5>
                        <%} %>
                        <h5>Defect Priority : <%=_RequestList.Priority %></h5>
                        <h5>Date Created : <%=_RequestList.CreatedDate.ToString("D") %></h5>
                        <h5>Last Updated : <%=_RequestList.UpdatedDate.ToString("D") %></h5>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="box">
                    <div class="box-title">
                        <h3>
                            All History
								</h3>
                    </div>
                    <div class="box-content">
                        <%if (_RequestList.FunctionalDefectStory != null)
                            {
                                foreach (var item in _RequestList.FunctionalDefectStory)
                                {
                        %>
                        <blockquote>
                            <p><%=item.Title %></p>
                            <p><%=item.Description %></p>
                            <%if (item.Status == Rachna.Teracotta.Project.Source.Entity.eFunctionalityStatus.Completed.ToString())
                                {%>
                            <h5 style="color: green;">Status set to : <%=item.Status.ToUpper() %></h5>

                            <%}
                                else
                                { %>
                            <h5 style="color: red;">Status set to : <%=item.Status.ToUpper() %></h5>
                            <%} %>
                            <img src="../../<%=item.Banner %>" width="100" height="100" />
                            <br />
                            <small>Resolver : <%=item.Resolver.FullName %></small>
                        </blockquote>
                        <%}
                            }%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%} %>
</asp:Content>
