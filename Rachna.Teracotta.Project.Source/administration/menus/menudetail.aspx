<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="menudetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.menus.menudetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="/administration/default.aspx?ids=687324jhkjhkjh8798797987987&redirecturl=admin-home-<%=DateTime.Now %>">Home</a></li>
            <li><a href="/administration/pages/pages.aspx?redirecturl=admin-slider-rachna-teracotta">All Pages</a></li>
            <li class="active">Edit Menu</li>
        </ul>
    </div>
    <!-- /breadcrumb-->
    <div class="padding-md">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Edit Menu</h4>
                <asp:HiddenField ID="hdnPageId" runat="server" />
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label>Title</label>
                    <asp:TextBox ID="txtOfferTitle" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="Enter Title" ControlToValidate="txtOfferTitle" ValidationGroup="admin"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-3">
                    <label>Select Menu Type</label>
                    <a href="#" data-toggle="tooltip" title="Select Menu Type, The place you need to display the menu."><i class="fa fa-question-circle"></i></a>
                    <asp:DropDownList ID="ddlmenutype" runat="server" class="form-control input-sm">
                        <asp:ListItem>Select..</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Select Menu Type" InitialValue="Select.." ControlToValidate="ddlmenutype" ValidationGroup="admin"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-lg-3">
                    <label>Select Page</label>
                    <a href="#" data-toggle="tooltip" title="Select the page to display on click of menu button."><i class="fa fa-question-circle"></i></a>
                    <asp:DropDownList ID="ddlpage" runat="server" class="form-control input-sm">
                        <asp:ListItem>Select..</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Select Page" InitialValue="Select.." ControlToValidate="ddlpage" ValidationGroup="admin"></asp:RequiredFieldValidator>
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                &nbsp;&nbsp;|&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn btn-primary" ValidationGroup="admin" OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
</asp:Content>
