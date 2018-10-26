<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="pagedetail.aspx.cs" ValidateRequest="false" Inherits="Rachna.Teracotta.Project.Source.administration.pages.pagedetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="/administration/default.aspx?ids=687324jhkjhkjh8798797987987&redirecturl=admin-home-<%=DateTime.Now %>">Home</a></li>
            <li><a href="/administration/pages/pages.aspx?redirecturl=admin-slider-rachna-teracotta">All Pages</a></li>
            <li class="active">Edit Page</li>
        </ul>
    </div>
    <!-- /breadcrumb-->
    <div class="padding-md">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Edit Page</h4>
                <asp:HiddenField ID="hdnPageId" runat="server" />
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label>Title</label>
                    <asp:TextBox ID="txtOfferTitle" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="Enter Title" ControlToValidate="txtOfferTitle" ValidationGroup="admin"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label data-toggle="tooltip" title="Enter Category Description">Description&nbsp;&nbsp;<i class="fa fa-question-circle"></i></label>
                    <asp:TextBox ID="txtSmallDescription" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtSmallDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                &nbsp;&nbsp;|&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="admin" OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=txtSmallDescription.ClientID %>', { filebrowserImageUploadUrl: '../../Upload.ashx' });
        });
    </script>
</asp:Content>
