<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="pageunderconstruction.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.application.pageunderconstruction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.UnderConstrunction> UnderConstrunction = null;
        UnderConstrunction = Rachna.Teracotta.Project.Source.Core.bal.bUnderConstrunction.List();
    %>

    <!--Modal-->
    <div class="modal fade" id="modalApplicationLogo">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Page Under Construction</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Title</label>
                        <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Enter Title for Logo" ControlToValidate="txtTitle" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Description</label>
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Enter Description for Logo" ControlToValidate="txtDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Is Default?</label>
                        <asp:CheckBox ID="chkIsDefault" runat="server" />
                        Is Default Message
                    </div>
                     <div class="form-group">
                        <label>Want to display Instead Home Page?</label>
                        <asp:CheckBox ID="chkDisplayInsteadHomePage" runat="server" />
                        Display Instead Home page
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
                <h1>All Messages for Page Under Construction</h1>
            </div>
            <div class="pull-right">
                <a href="#modalApplicationLogo" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
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
                    <a href="#">Page Under Construction</a>
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
                            Page Under Construction
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Title</th>
                                    <th>Description</th>
                                    <th>Created By</th>
                                    <th>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in UnderConstrunction)
                                    { %>
                                <tr>
                                    <td><%=item.UnderConst_Title %></td>
                                    <td><%=item.UnderConst_Description %></td>
                                    <td><%=item.Administrators.FullName %></td>
                                    <%if (item.UnderConst_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
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
                                    <td class='hidden-1024'><%=item.UnderConst_CreatedDate.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.UnderConst_UpdatedDate.ToString("D") %></td>
                                    <td>
                                        <a href="/administration/application/pgeundrconstdetail.aspx?UnderConstrunctionid=<%=item.UnderConst_Id %>&pageId=1234"><i class="fa fa-edit fa-lg"></i></a>
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
