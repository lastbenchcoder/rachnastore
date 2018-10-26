<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="functionalities.aspx.cs" ValidateRequest="false" Inherits="Rachna.Teracotta.Project.Source.administration.defectmanager.functionalities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Functionality> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.Functionality.Include("Administrators").ToList();
    %>


    <!--Modal-->
    <div class="modal fade" id="modalAddFunctionalities">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>New Functionality</h4>
                    <p>
                        All functionality of this application is created here. Functionalities may be Proposed, completed, inprogress. 
                        Every super admin can create the functionality with creater(developer).
                        Later developer can change the status of the functionality based on progress of the functionality.
                    </p>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <label data-toggle="tooltip" title="Enter Category Title">Title&nbsp;&nbsp;<i class="fa fa-question-circle"></i></label>
                        <asp:TextBox ID="txtCategory" runat="server" class="form-control input-sm" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Category title" ControlToValidate="txtCategory" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label data-toggle="tooltip" title="Enter Category Description">Description&nbsp;&nbsp;<i class="fa fa-question-circle"></i></label>
                        <asp:TextBox ID="txtSmallDescription" TextMode="MultiLine" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Enter Category Description" ControlToValidate="txtSmallDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Developer</label>
                        <a href="#" data-toggle="tooltip" title="Resolver to fix the defects"><i class="fa fa-question-circle"></i></a>
                        <asp:DropDownList ID="ddldeveloper" runat="server" class="form-control input-sm" Width="50%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Select Developer" InitialValue="Select.." ControlToValidate="ddldeveloper" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label data-toggle="tooltip" title="Select Category Status">Status&nbsp;&nbsp;<i class="fa fa-question-circle"></i></label>
                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control input-sm" Width="50%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Select Status" InitialValue="Select.." ControlToValidate="ddlStatus" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-sm btn-success" data-dismiss="modal" aria-hidden="true">Close</button>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
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
                <h1>Manage Functionality</h1>
            </div>
            <div class="pull-right">
                <a href="#modalAddFunctionalities" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">More...</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Manage Functionality</a>
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
                            Manage Functionality
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>Function_Id</th>
                                    <th>FunctionCode</th>
                                    <th>Title</th>
                                    <th>Status</th>
                                    <th>CreatedBy</th>
                                    <th>CreatedDate</th>
                                    <th>UpdatedDate</th>
                                    <th>Edit Detail</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var item in _RequestList)
                                    { %>
                                <tr>
                                    <td><%=item.Function_Id %></td>
                                    <td><%=item.FunctionCode %></td>
                                    <td><%=item.Title %></td>
                                    <%if (item.Status == Rachna.Teracotta.Project.Source.Entity.eFunctionalityStatus.Completed.ToString() || item.Status == Rachna.Teracotta.Project.Source.Entity.eFunctionalityStatus.Resolved.ToString())
                                        {%>
                                    <td class='hidden-350'>
                                        <span class="label label-success"><%=item.Status.ToUpper() %></span>
                                    </td>
                                    <%}
                                        else
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-danger"><%=item.Status.ToUpper() %></span>
                                    </td>
                                    <%} %>
                                    <td><%=item.Administrators.FullName %></td>
                                    <td><%=item.DateCreated %></td>
                                    <td><%=item.DateUpdated %></td>
                                    <td><a href="/administration/defectmanager/functdetail.aspx?id=<%=item.Function_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
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
            CKEDITOR.replace('<%=txtSmallDescription.ClientID %>', { filebrowserImageUploadUrl: '../../Upload.ashx' });
        });
    </script>
</asp:Content>
