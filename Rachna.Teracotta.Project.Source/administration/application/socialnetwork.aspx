<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="socialnetwork.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.application.socialnetwork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.SocialNetworking> SocialNetworking = null;
        SocialNetworking = Rachna.Teracotta.Project.Source.Core.bal.bSocialNetworking.List();
    %>

    <!--Modal-->
    <div class="modal fade" id="modalApplicationSocialNetworking">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Add New Application SocialNetworking</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Title</label>
                        <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Enter Title for Social Networking" ControlToValidate="txtTitle" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Image ID="imgArticle" runat="server" ClientIDMode="Static" Width="100px" Height="100px" class="form-control" />
                        <label></label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ErrorMessage="Invalid Image File Format, Should be .jpg, .JPG, .gif, .GIF, .PNG, .png, .jpeg !.."
                            ControlToValidate="imgInp" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.PNG|.png|.jpeg)$" ValidationGroup="admin"></asp:RegularExpressionValidator>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="imgInp" ErrorMessage="Please select Social Networking Icon" ValidationGroup="admin" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>&nbsp;</label>
                        <asp:CheckBox ID="chkIsDefault" runat="server" />
                        Is Active
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
                <h1>All Social Networkings</h1>
            </div>
            <div class="pull-right">
                <a href="#modalApplicationSocialNetworking" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
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
                    <a href="#">All Social Networkings</a>
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
                            Social Networking
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Title</th>
                                    <th>Created By</th>
                                    <th>Status</th>
                                    <th class='hidden-1024'>DateCreated</th>
                                    <th class='hidden-480'>DateUpdated</th>
                                    <th>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in SocialNetworking)
                                    { %>
                                <tr>
                                    <td>
                                        <img src="../../<%=item.Scl_Ntk_Icon%>" width="50" height="50" /></td>
                                    <td><%=item.Scl_Ntk_URL %></td>
                                    <td><%=item.Administrators.FullName %></td>
                                    <%if (item.Scl_Ntk_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
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
                                    <td class='hidden-1024'><%=item.Scl_Ntk_CreatedDate.ToString("D") %></td>
                                    <td class='hidden-480'><%=item.Scl_Ntk_UpdatedDate.ToString("D") %></td>
                                    <td>
                                        <a href="/administration/application/socialnetworkdetail.aspx?SocialNetworkingid=<%=item.Scl_Ntk_Id %>&pageId=1234"><i class="fa fa-edit fa-lg"></i></a>
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
