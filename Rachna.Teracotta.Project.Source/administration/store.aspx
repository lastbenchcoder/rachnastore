<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="store.aspx.cs" Inherits="Page3.Project.Source.administration.store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.Stores> _RequestList = null;        
        _RequestList = Rachna.Teracotta.Project.Source.Core.bal.bStores.List();
    %>

    <!--Modal-->
    <div class="modal fade" id="modalStores">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>New Store</h4>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <label>Store Name</label>
                        <asp:TextBox ID="txtStoreName" runat="server" class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Store Name" ControlToValidate="txtStoreName" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                        <label data-toggle="tooltip" title="Enter Category Description">Description&nbsp;&nbsp;<i class="fa fa-question-circle"></i></label>
                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control input-sm" Width="100%" Height="70"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Enter Store Description" ControlToValidate="txtDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="imgInp" ErrorMessage="Please select store logo" ValidationGroup="admin" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-sm btn-success" data-dismiss="modal" aria-hidden="true">Close</button>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success btn-sm" ValidationGroup="admin" OnClick="btnSubmit_Click" />
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
                <h1>All Store Information</h1>
            </div>
            <div class="pull-right">
                <a href="#modalStores" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
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
                    <a href="#">Add/View Stores</a>
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
                            Store Information
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Store Code</th>
                                    <th>Store Name</th>
                                    <th>Store Url</th>
                                    <th>Status</th>
                                    <th>DateCreated</th>
                                    <th>DateUpdated</th>
                                    <th>Edit Detail</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <img src="../<%=item.Store_Logo %>" style="height: 50px; width: 50px" /></td>
                                    <td><%=item.StoreCode %></td>
                                    <td><%=item.Store_Name %></td>
                                    <td><%=ConfigurationSettings.AppSettings["DomainUrl"].ToString()+item.Store_Url %></td>
                                    <%if (item.Store_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
                                        { %>
                                    <td class='hidden-350'>
                                        <span class="label label-success"><%=item.Store_Status %>
                                        </span>
                                    </td>
                                    <%}
                                        else
                                        {%>
                                    <td class='hidden-350'>
                                        <span class="label label-danger"><%=item.Store_Status %>
                                        </span>
                                    </td>
                                    <%} %>
                                    <td><%=item.Store_CreatedDate.ToString("D") %></td>
                                    <td><%=item.Store_UpdatedDate.ToString("D") %></td>
                                    <td><a href="/administration/storedetail.aspx?id=<%=item.Store_Id %>&requesttype=storedetail"><i class="fa fa-edit fa-lg"></i></a></td>
                                    <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
