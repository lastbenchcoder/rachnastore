<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="invitation.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.invitation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
        List<Rachna.Teracotta.Project.Source.Models.Invitations> Invitations = null;
        Invitations = Rachna.Teracotta.Project.Source.Core.bal.bInvitations.List();
    %>

    <!--Modal-->
    <div class="modal fade" id="modalInvitation">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Invitation</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Store</label>
                        <asp:DropDownList ID="ddlStore" runat="server" class="form-control input-sm" Width="50%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Select Store" InitialValue="Select.." ControlToValidate="ddlStore" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="folderName" data-toggle="tooltip" title="Enter Email Id">Email Id&nbsp;&nbsp;<i class="fa fa-question-circle"></i></label>
                        <asp:TextBox ID="txtEmailId" TextMode="Email" runat="server" class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Email Id" ControlToValidate="txtEmailId" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="folderName" data-toggle="tooltip" title="Select Administrator Role">Role&nbsp;&nbsp;<i class="fa fa-question-circle"></i></label>
                        <asp:DropDownList ID="ddlRole" runat="server" class="form-control input-sm" Width="50%">
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
                    <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-success btn-sm" ValidationGroup="admin" OnClick="btnSubmit_Click" Style="float: right" />
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
                <h1>Invitation</h1>
            </div>
            <div class="pull-right">
                <a href="#modalInvitation" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Stores & Admin</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Invitation</a>
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
                            Invitation
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Code</th>
                                    <th>EmailId</th>
                                    <th>Role</th>
                                    <th>Activity Mail</th>
                                    <th>Status</th>
                                    <th>Registration Link</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in Invitations)
                                    { %>
                                <tr>
                                    <td><%=item.Invitation_Code %></td>
                                    <td><%=item.Invitation_EmailId %></td>
                                    <td><%=item.Role %></td>
                                    <%if (item.Send_Activity_Mail == 1)
                                        { %>
                                    <td>Yes</td>
                                    <%}
                                        else
                                        {%>
                                    <td>No</td>
                                    <%} %>
                                    <%if (item.Invitation_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.InActive.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success">Completed
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
                                    <td>
                                        <p><%=System.Configuration.ConfigurationSettings.AppSettings["DomainUrl"].ToString() %>/account/invitation.aspx?code=<%= item.Invitation_Code %>&emailid=<%= item.Invitation_EmailId %></p>
                                    </td>
                                    <td class='hidden-1024'><%=item.Invitation_CreatedDate.ToString("D") %></td>
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
