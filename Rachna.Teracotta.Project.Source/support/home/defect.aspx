<%@ Page Title="" Language="C#" MasterPageFile="~/support/home/Home.Master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="defect.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.support.home.defect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.FunctionalDefect> functionalDefect = null;
        functionalDefect = Rachna.Teracotta.Project.Source.Core.bal.bFunctionalDefect.List();
    %>

    <!--Modal-->
    <div class="modal fade" id="modalAdministrator">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Ticket</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Title</label>
                        <asp:TextBox ID="txtFullname" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Enter Titcket Title" ControlToValidate="txtFullname" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="form-group">
                        <label>Description</label>
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control" placeholder="Description"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server"
                            ErrorMessage="Enter Functionality Description" ControlToValidate="txtDescription" ValidationGroup="functionality"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Due Date</label>
                        <asp:TextBox ID="txtDueDate" type="date" runat="server" class="form-control" Width="50%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                            ErrorMessage="Due Date Required" ControlToValidate="txtDueDate" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Resolver</label>
                        <asp:DropDownList ID="ddlResolver" runat="server" class="form-control" Width="50%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                            ErrorMessage="Select Resolver" InitialValue="Select.." ControlToValidate="ddlResolver"
                            ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Priority</label>
                        <asp:RadioButtonList ID="rdoPriority" runat="server">
                            <asp:ListItem>High</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>Low</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server"
                            ErrorMessage="Please select resolver" ControlToValidate="ddlResolver"
                            ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control" Width="50%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server"
                            ErrorMessage="Select Status" InitialValue="Select.." ControlToValidate="ddlStatus"
                            ValidationGroup="admin"></asp:RequiredFieldValidator>
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
                <h1>Ticket Manager</h1>
            </div>
            <div class="pull-right">
                <a href="#modalAdministrator" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/support/home/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Dashboard</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Support</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Tickets</a>
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
                            Tickets
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Ticket Id</th>
                                    <th>Title</th>
                                    <th class='hidden-1024'>Due Date</th>
                                    <th>Priority</th>
                                    <th>Resolver</th>                                    
                                    <th>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in functionalDefect)
                                    { %>
                                <tr>
                                    <td><%=item.DefectCode %></td>
                                    <td><%=item.Title %></td>
                                    <td><%=item.FixDate.ToString("D") %></td>
                                    <td><%=item.Priority %></td>
                                    <td><%=item.Resolver.FullName %></td>
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
                                        <a href="/support/home/defectdetail.aspx?defectid=<%=item.Defect_Id %>&pageId=1234"><i class="fa fa-edit fa-lg"></i></a>
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
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtDescription.ClientID %>', { filebrowserImageUploadUrl: '../../Upload.ashx' });
        });
    </script>
</asp:Content>
