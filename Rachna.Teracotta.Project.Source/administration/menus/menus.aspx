<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="menus.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.menus.menus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.RMenu> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.RMenu.Include("Pages").Include("Admin").ToList();
    %>

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="/administration/default.aspx?ids=687324jhkjhkjh8798797987987&redirecturl=admin-home-<%=DateTime.Now %>">Home</a></li>
            <li class="active">Menu</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h5>New Menu</h5>
            </div>
            <div class="panel-body">
                <div class="container">
                    <div class="form-group col-lg-3">
                        <label data-toggle="tooltip" title="Enter Category Title">Title&nbsp;&nbsp;<i class="fa fa-question-circle"></i></label>
                        <asp:TextBox ID="txtCategory" runat="server" class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter title" ControlToValidate="txtCategory" ValidationGroup="admin"></asp:RequiredFieldValidator>
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
                    <div class="form-group col-lg-3" style="margin-top: 20px">
                        <label>&nbsp;</label>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                        <label>&nbsp;</label>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-default table-responsive">
            <div class="panel-heading">
                All Menus
                <span class="label label-info pull-right"><%=_RequestList.Count() %> Menus</span>
            </div>
            <div class="padding-md clearfix">

                <table class="table table-striped" id="dataTable">
                    <thead>
                        <tr>
                            <th>Menu Id</th>  
                            <th>Type</th>                          
                            <th>Title</th>
                            <th>Page</th>
                            <th>Status</th>
                            <th>CreatedBy</th>
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
                                <%=item.Menu_Id %></td>
                            <td>
                                <%=item.MenuType %></td>
                            <td><%=item.Title %></td>
                              <td><%=item.Pages.Title %></td>
                            <%if (item.Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
                                {%>
                            <td><span style="font-weight: bold; color: green">
                                <%=item.Status %>
                            </span></td>
                            <%}
                                else
                                { %>
                            <td><span style="font-weight: bold; color: red">
                                <%=item.Status %>
                            </span></td>
                            <%} %>
                            <td><%=item.Admin.FullName %></td>
                            <td><%=item.DateCreated %></td>
                            <td><%=item.DateUpdated %></td>
                            <td><a href="/administration/menus/menudetail.aspx?menuid=<%=item.Menu_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
                            <%
                                }
                            %>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
