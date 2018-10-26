<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="metainformation.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.application.metainformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.MetaInformation> MetaInformation = null;
        MetaInformation = Rachna.Teracotta.Project.Source.Core.bal.bMetaInformation.List();
    %>

    <!--Modal-->
    <div class="modal fade" id="modalApplicationMetaInformation">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Add New Application MetaInformation</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Title</label>
                        <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" 
                            ErrorMessage="Enter Title for MetaInformation" ControlToValidate="txtTitle" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Description</label>
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" 
                            ErrorMessage="Enter Description for MetaInformation" ControlToValidate="txtDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                     <div class="form-group">
                        <label>Keywords</label>
                        <asp:TextBox ID="txtKeywords" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" 
                            ErrorMessage="Enter Keywords for MetaInformation" ControlToValidate="txtKeywords" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Is Default?</label>
                        <asp:CheckBox ID="chkIsDefault" runat="server" />
                        Is Default MetaInformation
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-sm btn-success" data-dismiss="modal" aria-hidden="true">Close</button>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success btn-sm" ValidationGroup="admin" OnClick="btnSubmit_Click" Style="float: right" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All MetaInformations</h1>
            </div>
            <div class="pull-right">
                <a href="#modalApplicationMetaInformation" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Application</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">All MetaInformations</a>
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
                            MetaInformation
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Title</th>
                                    <th>Description</th>
                                    <th>Keywords</th>
                                    <th>Created By</th>
                                    <th>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in MetaInformation)
                                    { %>
                                <tr>
                                    <td><%=item.Meta_Title %></td>
                                    <td><%=item.Meta_Description %></td>
                                    <td><%=item.Meta_KeyWords %></td>
                                    <td><%=item.Administrators.FullName %></td>
                                    <%if (item.Meta_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success">Active
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        {%>
                                    <td class='hidden-350'>
                                        <span class="label label-danger">In Active
                                        </span>
                                    </td>
                                    <%} %>
                                    <td class='hidden-1024'><%=item.Meta_CreatedDate.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.Meta_UpdatedDate.ToString("D") %></td>
                                    <td>
                                        <a href="/administration/application/MetaInformationdetail.aspx?MetaInformationid=<%=item.Meta_Id %>&pageId=1234"><i class="fa fa-edit fa-lg"></i></a>
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
</asp:Content>
