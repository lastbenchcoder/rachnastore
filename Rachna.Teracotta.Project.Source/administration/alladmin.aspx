<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="alladmin.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.alladmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
        List<Rachna.Teracotta.Project.Source.Models.Administrators> Administrators = null;
        Administrators = Rachna.Teracotta.Project.Source.Core.bal.bAdministrator.List();
    %>

    <!--Modal-->
    <div class="modal fade" id="modalAdministrator">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Admin</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Store</label>
                        <asp:DropDownList ID="ddlStore" runat="server" class="form-control" Width="50%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="Select Store" InitialValue="Select.." ControlToValidate="ddlStore" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>FullName</label>
                        <asp:TextBox ID="txtFullname" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Enter Fullname" ControlToValidate="txtFullname" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="form-group">
                        <label>EmailId</label>
                        <asp:TextBox ID="txtEmailId" TextMode="Email" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Enter EmailId" ControlToValidate="txtEmailId" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Phone</label>
                        <asp:TextBox ID="txtPhone" TextMode="Phone" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Phone Number" ControlToValidate="txtPhone" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Role</label>
                        <asp:DropDownList ID="ddlRole" runat="server" class="form-control" Width="50%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Select Role" InitialValue="Select.." ControlToValidate="ddlRole" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Get Activity Mail</label>
                        <asp:CheckBox runat="server" ID="chkGetActivityMail"></asp:CheckBox>
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
                <h1>Administrators</h1>
            </div>
            <div class="pull-right">
                <a href="#modalAdministrator" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Administration</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">All Administrator</a>
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
                            Administrator
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>FullName</th>
                                    <th>EmailId</th>
                                    <th>Role</th>
                                    <th>Activity Mail</th>
                                    <th>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in Administrators)
                                    { %>
                                <tr>
                                    <td>
                                        <img src="../../<%=item.Photo%>" width="50" height="50" /></td>
                                    <td><%=item.FullName %></td>
                                    <td><%=item.EmailId %></td>
                                    <td><%=item.Admin_Role %></td>
                                    <%if (item.Send_Activity_Mail == 1)
                                    { %>
                                    <td>Yes</td>
                                    <%}
                                        else
                                        {%>
                                    <td>No</td>
                                    <%} %>
                                    <%if (item.Admin_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success"><%=item.Admin_Status %>
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
                                    <td class='hidden-1024'><%=item.Admin_CreatedDate.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.Admin_UpdatedDate.ToString("D") %></td>
                                    <td>
                                        <a href="/administration/profile.aspx?adminid=<%=item.Administrators_Id %>&pageId=1234"><i class="fa fa-edit fa-lg"></i></a>
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

