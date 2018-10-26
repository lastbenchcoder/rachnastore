<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="slider.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.home.slider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">






    <%
        List<Rachna.Teracotta.Project.Source.Models.Sliders> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.Slider.ToList();
        if (_RequestList.Count > 4)
        {
            btnSubmit.Enabled = false;
        }
        else
        {
            btnSubmit.Enabled = true;
        }
    %>
    <!--Modal-->
    <div class="modal fade" id="modalCategory">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>New Slider</h4>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <label>Banner</label>
                        <a href="#" data-toggle="tooltip" title="Slider Banner which displays in home page"><i class="fa fa-question-circle"></i></a>
                        <asp:Image ID="imgProduct" runat="server" ClientIDMode="Static" Width="100px" Height="100px" class="form-control" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Image !.." ControlToValidate="imgInp" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.PNG|.png)$" ValidationGroup="admin"></asp:RegularExpressionValidator>
                        <asp:FileUpload ID="imgInp" runat="server" ClientIDMode="Static" class="form-control input-sm" />
                        <label></label>
                        <script type="text/javascript">
                            function readURL(input) {
                                if (input.files && input.files[0]) {
                                    var reader = new FileReader();

                                    reader.onload = function (e) {
                                        $('#imgProduct').attr('src', e.target.result);
                                    }

                                    reader.readAsDataURL(input.files[0]);
                                }
                            }

                            $("#imgInp").change(function () {
                                readURL(this);
                            });
                        </script>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="imgInp" ErrorMessage="Please select banner" ValidationGroup="admin" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label>Alt Text</label>
                        <a href="#" data-toggle="tooltip" title="Altername text which will display on Slider"><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtAltText" runat="server" class="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>URL</label>
                        <a href="#" data-toggle="tooltip" title="Onclick of slider banner, URL will help to redirect to specific product or specific page."><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtImageUrl" runat="server" class="form-control input-sm"></asp:TextBox>
                        <p style="color: red">URL may be any specific Product or List of products by category page. It is must and should. If No Url please mention #(No redirection will be done). </p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Redirect Url" ControlToValidate="txtImageUrl" ValidationGroup="admin"></asp:RequiredFieldValidator>
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
                <h1>All Slider Information</h1>
            </div>
            <div class="pull-right">
                <a href="#" data-toggle="modal" data-target="#modalCategory" class="btn btn-info" style="margin-top: 15px">+ Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Home Page Slider</a>
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
                            Slider Information
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>SliderCode</th>
                                    <th>Redirect URL</th>
                                    <th>CreatedDate</th>
                                    <th>UpdatedDate</th>
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
                                        <img src="../../<%=item.Slider_Photo %>" style="height: 50px; width: 50px" />
                                    </td>
                                    <td><%=item.Slider_Code %></td>
                                    <td><%=item.Slider_RedirectUrl %></td>
                                    <td><%=item.Slider_CreatedDate.ToString("D") %></td>
                                    <td><%=item.Slider_UpdatedDate.ToString("D") %></td>
                                    <td><a href="/administration/home/sliderdetail.aspx?sliderId=<%=item.Slider_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                                    <%
                                        }
                                    %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
