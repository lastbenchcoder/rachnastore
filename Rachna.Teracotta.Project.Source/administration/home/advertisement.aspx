<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="advertisement.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.home.advertisement" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
        List<Rachna.Teracotta.Project.Source.Models.Ads> _RequestList = null;
        _RequestList = Rachna.Teracotta.Project.Source.Core.bal.bAds.List();
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Advertisement</h1>
                <asp:HiddenField ID="hdnProductId" runat="server" />
                <asp:HiddenField ID="hdnProdId" runat="server" />
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Dashboard</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Application Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Home Page Section</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Advertisement</a>
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
                            Advertisement
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class="form-group">
                            <label class="control-label col-sm-2">Advertisement Type</label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlAddType" runat="server" class="form-control input-sm" Width="50%">
                                    <asp:ListItem>Select..</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server"
                                    ErrorMessage="Select Add Type" InitialValue="Select.." ControlToValidate="ddlAddType"
                                    ValidationGroup="admin"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">Redirect URL</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtImageUrl" runat="server" class="form-control input-sm" Width="50%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                    ErrorMessage="Enter Redirect Url" ControlToValidate="txtImageUrl" ValidationGroup="admin"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">Banner</label>
                            <div class="col-sm-10">
                                <asp:Image ID="imgProduct" runat="server" ClientIDMode="Static" Width="50px" Height="50px" class="form-control" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Image !.."
                                    ControlToValidate="imgInp" ForeColor="Red" ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.PNG|.png)$"
                                    ValidationGroup="admin"></asp:RegularExpressionValidator>
                                <asp:FileUpload ID="imgInp" runat="server" ClientIDMode="Static" class="form-control input-sm" Width="50%" />
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="imgInp"
                                    ErrorMessage="Please select banner" ValidationGroup="admin" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-actions col-sm-offset-2 col-sm-10">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-success hidden-print" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Advertisement
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable dataTable-tools">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>UniqueID</th>
                                    <th>Code</th>
                                    <th>Type</th>
                                    <th>Redirect URL</th>
                                    <th>Created By</th>
                                    <th>CreatedDate</th>
                                    <th>UpdatedDate</th>
                                    <th><i class="fa fa-edit fa-lg"></i></th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <img src="../../<%=item.Ads_Banner_Or_Source %>" style="height: 50px; width: 50px" />
                                    </td>
                                    <td><%=item.Ads_Id %></td>
                                    <td><%=item.AdsCode %></td>
                                    <td><%=item.Ads_Type %></td>
                                    <td><%=item.Ads_RedirectUrl %></td>
                                    <td><%=item.Administrators.FullName %></td>
                                    <td><%=item.Ads_CreatedDate.ToString("D") %></td>
                                    <td><%=item.Ads_UpdatedDate.ToString("D") %></td>
                                    <td><a href="/administration/home/advertisementdetail.aspx?adsId=<%=item.Ads_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                                </tr>
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
