<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="defectedit.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.defectmanager.defectedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Update Functionality Defect</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="/administration/defectmanager/functionalities.aspx?redirectUrl=jhgj657657HGH.htm">Manage Defects</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">
                        <asp:Label ID="lblBreadCrumbTitle" runat="server"></asp:Label></a>
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
            <asp:HiddenField ID="hdnDefectId" runat="server" />
        </asp:Panel>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Update Functionality Defect</h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class='form-horizontal form-striped'>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Functionality</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblFunctionality" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Resolver</label>
                                <div class="col-sm-10">
                                    <asp:DropDownList ID="ddlresolver" runat="server" class="form-control input-sm" Width="100%">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server"
                                        ErrorMessage="Select Resolver" InitialValue="Select.." ControlToValidate="ddlresolver"
                                        ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Title</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDefectTitle" runat="server" class="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                        ErrorMessage="Enter Defect Title" Display="None" ControlToValidate="txtDefectTitle"
                                        ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Description</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" class="form-control input-sm" Height="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red"
                                        runat="server" ErrorMessage="Enter Defect Description" Display="None"
                                        ControlToValidate="txtDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2"></label>
                                <div class="col-sm-10">
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
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Status</label>
                                <div class="col-sm-10">
                                    <a href="#" data-toggle="tooltip" title="Functionality having defects"><i class="fa fa-question-circle"></i></a>
                                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-control input-sm" Width="100%">
                                        <asp:ListItem>Select..</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="Select Status"
                                        InitialValue="Select.." ControlToValidate="ddlStatus" ValidationGroup="admin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Date Updated</label>
                                <div class="col-sm-10">
                                  <asp:Label ID="lblFixDate" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                               <div class="form-group">
                                <label for="txtFirstName" class="control-label col-sm-2">Date Updated</label>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblpriority" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                            <div class="form-actions col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success btn-sm" 
                                    ValidationGroup="admin" OnClick="btnSubmit_Click" Style="float: right" />
                                &nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;
                                <a href="/administration/defectmanager/defectdetail.aspx?id=<%=hdnDefectId.Value %>&redirecturl=admin-store-rachna-teracotta">Cancel</a>
                            </div>
                        </div>
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
