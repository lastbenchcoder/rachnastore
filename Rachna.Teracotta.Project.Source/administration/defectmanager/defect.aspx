<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="defect.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.defectmanager.defect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.FunctionalDefect> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.DefectsManager.Include("Administrators").Include("Functionality").ToList();
    %>

    <!--Modal-->
    <div class="modal fade" id="modalAddDefects">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>New Defect</h4>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="admin" Style="margin-left: 10px; margin-top: 10px" />
                </div>
                <div class="modal-body">
                    <div class="form-group col-xs-6">
                        <label>Functionality</label>
                        <a href="#" data-toggle="tooltip" title="Functionality having defects"><i class="fa fa-question-circle"></i></a>
                        <asp:DropDownList ID="ddlfunctionality" runat="server" class="form-control input-sm" Width="100%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Select Functionality" InitialValue="Select.." ControlToValidate="ddlfunctionality" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-xs-6">
                        <label>Resolver</label>
                        <a href="#" data-toggle="tooltip" title="Resolver to fix the defects"><i class="fa fa-question-circle"></i></a>
                        <asp:DropDownList ID="ddlresolver" runat="server" class="form-control input-sm" Width="100%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Select Resolver" InitialValue="Select.." ControlToValidate="ddlresolver" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-xs-6">
                        <label>Title</label>
                        <asp:TextBox ID="txtDefectTitle" runat="server" class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Enter Defect Title" Display="None" ControlToValidate="txtDefectTitle" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-xs-6">
                        <label>Description</label>
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control input-sm" Height="100px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Defect Description" Display="None" ControlToValidate="txtDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-xs-6">
                        <label>Screen</label>
                        <asp:Image ID="imgArticle" runat="server" ClientIDMode="Static" Width="100px" Height="100px" class="form-control" />
                        <label></label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ErrorMessage="Invalid Image !.." ControlToValidate="imgInp" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.PNG|.png)$" ValidationGroup="admin"></asp:RegularExpressionValidator>
                        <asp:FileUpload ID="imgInp" runat="server" ClientIDMode="Static" class="form-control input-sm" />
                        <label></label>
                        <script type="text/javascript">
                            function readURL(input) {
                                if (input.files && input.files[0]) {
                                    var reader = new FileReader();

                                    reader.onload = function (e) {
                                        $('#imgArticle').attr('src', e.target.result);
                                    }

                                    reader.readAsDataURL(input.files[0]);
                                }
                            }

                            $("#imgInp").change(function () {
                                readURL(this);
                            });
                        </script>
                    </div>
                    <div class="form-group col-xs-6">
                        <label>Status</label>
                        <a href="#" data-toggle="tooltip" title="Functionality having defects"><i class="fa fa-question-circle"></i></a>
                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control input-sm" Width="100%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="Select Status" InitialValue="Select.." ControlToValidate="ddlStatus" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-xs-6">
                        <label>Due Date</label>
                        <asp:TextBox ID="txtfixdate" TextMode="Date" runat="server" class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="Select Due Date" Display="None" ControlToValidate="txtfixdate" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-xs-6">
                        <label>Priority</label>
                        <a href="#" data-toggle="tooltip" title="Functionality having defects"><i class="fa fa-question-circle"></i></a>
                        <asp:DropDownList ID="ddlpriority" runat="server" class="form-control input-sm" Width="100%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="Select Priority" InitialValue="Select.." ControlToValidate="ddlpriority" ValidationGroup="admin"></asp:RequiredFieldValidator>
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
                <h1>All Defects</h1>
            </div>
            <div class="pull-right">
                <a href="#modalAddDefects" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
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
                    <a href="#">Manage Defects</a>
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
                            Manage Defects
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>DefectId</th>
                                    <th>Title</th>
                                    <th>CreatedBy</th>
                                    <th>Status</th>
                                    <th>DateCreated</th>
                                    <th>DateCreated</th>
                                    <th>Edit Detail</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var item in _RequestList)
                                    { %>
                                <tr>
                                    <td><span>#</span><%=item.Defect_Id %></td>
                                    <td><%=item.Title %></td>
                                    <td><%=item.Administrators.FullName %></td>
                                    <%if (item.Status == Rachna.Teracotta.Project.Source.Entity.eFunctionalityStatus.Completed.ToString())
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
                                    <td><%=item.CreatedDate.ToString("D") %></td>
                                    <td><%=item.UpdatedDate.ToString("D") %></td>
                                    <td><a href="/administration/defectmanager/defectdetail.aspx?id=<%=item.Defect_Id %>&requesttype=defectdetail"><i class="fa fa-edit fa-lg"></i></a></td>
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
