<%@ Page Title="" Language="C#" MasterPageFile="~/support/home/Home.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="functionality.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.support.home.functionality" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Functionality> Functionality = null;
        Functionality = Rachna.Teracotta.Project.Source.Core.bal.bFunctionality.List();
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Functionality</h1>
            </div>
            <div class="pull-right">
                <a href="#modalFunctionality" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/support/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Functionality</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">All Functionality</a>
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
                            Functionality
                        </h3>
                    </div>
                    <div class="box-content nopadding">
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
                                <%foreach (var item in Functionality)
                                    { %>
                                <tr>
                                    <td><%=item.FunctionCode %></td>
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
                                    <td class='hidden-1024'><%=item.DateCreated.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.DateUpdated.ToString("D") %></td>
                                    <td>
                                        <a href="/support/functionalitydetail.aspx?adminid=<%=item.Function_Id %>&pageId=1234"><i class="fa fa-edit fa-lg"></i></a>
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
    <!--Modal-->
    <div class="modal fade" id="modalFunctionality">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Functionality</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Developer</label>
                        <asp:DropDownList ID="ddlDeveloper" runat="server" class="form-control" Width="50%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server"
                            ErrorMessage="Select Developer" InitialValue="Select.." ControlToValidate="ddlDeveloper"
                            ValidationGroup="functionality"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Title</label>
                        <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Enter Functionality Title"
                            ControlToValidate="txtTitle" ValidationGroup="functionality"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Description</label>
                        <asp:TextBox ID="txtDescription1" TextMode="MultiLine" runat="server" class="form-control" placeholder="Description"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                            ErrorMessage="Enter Functionality Description" ControlToValidate="txtDescription1" ValidationGroup="functionality"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-sm btn-success" data-dismiss="modal" aria-hidden="true">Close</button>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success btn-sm"
                        ValidationGroup="functionality" Style="float: right" OnClick="btnSubmit_Click" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtDescription1.ClientID %>', { filebrowserImageUploadUrl: '../../Upload.ashx' });
        });
    </script>
</asp:Content>
