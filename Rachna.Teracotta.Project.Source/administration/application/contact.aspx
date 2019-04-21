<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.application.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%        
        List<Rachna.Teracotta.Project.Source.Models.ContactOwner> ContactOwner = null;
        ContactOwner = Rachna.Teracotta.Project.Source.Core.bal.bContactOwner.List();
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Contact Information</h1>
            </div>
            <div class="pull-right">
                <a href="/administration/application/newcontact.aspx?redId=7654765465456456SGGDSDGDGGGGGGGGGGGGGGGGG89709709&pageId=1234" class="btn btn-primary" style="margin-top: 15px" data-toggle="modal">Add New</a>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Application Content</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Application</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Contact Information</a>
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
                            Contact Information
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable dataTable-tools">
                            <thead>
                                <tr>
                                    <th>Title</th>
                                    <th>Address</th>
                                    <th>Other Detail</th>
                                    <th>Created By</th>
                                    <th>Can Submit Request?</th>
                                    <th>Status</th>
                                    <th>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in ContactOwner)
                                    { %>
                                <tr>
                                    <td><%=item.Contact_Title %></td>
                                    <td>
                                        <%=item.Contact_Address %>
                                        City  : <%=item.Contact_City %><br />
                                        State : <%=item.Contact_State %><br />
                                        Zip   : <%=item.Contact_ZipCode %>
                                    </td>
                                    <td>Email  : <%=item.Contact_EmailId %><br />
                                        Phone  : <%=item.Contact_Phone %><br />
                                        Fax    : <%=item.Contact_Fax %>
                                    </td>
                                    <td>
                                        <%=item.Administrators.FullName %>
                                    </td>
                                    <%if (item.Contact_Query_Submission == "Y")
                                        { %>
                                    <td class='hidden-350'>
                                        <span>Yes</span>
                                    </td>
                                    <%}
                                        else
                                        {%>
                                    <td class='hidden-350'>
                                        <span>No</span>
                                    </td>
                                    <%} %>
                                    <%if (item.Contact_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
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
                                    <td>
                                        <a href="/administration/application/contactdetail.aspx?ContactOwnerid=<%=item.Contact_Owner_Id %>&pageId=1234"><i class="fa fa-edit fa-lg"></i></a>
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
