<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="deleveryteam.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.salesmanagement.deleveryteam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="/administration/default.aspx?redirecturl=admin-home-RachnaTeracotta">Home</a></li>
            <li class="active">Category</li>
        </ul>
    </div>
    <!-- /breadcrumb-->

    <%
        List<Rachna.Teracotta.Project.Source.Models.DeleveryTeam> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.DeleveryTeam.Include("DeliveryMethod").ToList();
    %>

    <!--Modal-->
    <div class="modal fade" id="modalCategory">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>New Delevery Team</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Delevery Method</label>
                        <a href="#" data-toggle="tooltip" title="Category for Sub Category Creation"><i class="fa fa-question-circle"></i></a>
                        <asp:DropDownList ID="ddlStore" runat="server" class="form-control input-sm" Width="30%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ForeColor="Red" runat="server" ErrorMessage="Select Store" InitialValue="Select.." ControlToValidate="ddlStore" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Delevery Method</label>
                        <a href="#" data-toggle="tooltip" title="Category for Sub Category Creation"><i class="fa fa-question-circle"></i></a>
                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control input-sm" Width="30%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Select Method" InitialValue="Select.." ControlToValidate="ddlCategory" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Name</label>
                        <a href="#" data-toggle="tooltip" title="Sub Category Title"><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtCategory" runat="server" class="form-control input-sm" Width="30%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Name" ControlToValidate="txtCategory" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Description</label>
                        <a href="#" data-toggle="tooltip" title="Sub Category Description"><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtSmallDescription" TextMode="MultiLine" runat="server" class="form-control input-sm" Width="100%" Height="150"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtSmallDescription" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>EmailId</label>
                        <a href="#" data-toggle="tooltip" title="Sub Category Title"><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control input-sm" Width="30%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Enter EmailId" ControlToValidate="txtEmailId" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Phone</label>
                        <a href="#" data-toggle="tooltip" title="Sub Category Title"><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtPhone" runat="server" class="form-control input-sm" Width="30%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="Enter Phone" ControlToValidate="txtPhone" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Address</label>
                        <a href="#" data-toggle="tooltip" title="Sub Category Description"><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" class="form-control input-sm" Width="100%" Height="150"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="Enter Address" ControlToValidate="txtAddress" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>City</label>
                        <a href="#" data-toggle="tooltip" title="Sub Category Title"><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtCity" runat="server" class="form-control input-sm" Width="30%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="Enter City" ControlToValidate="txtCity" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>State</label>
                        <a href="#" data-toggle="tooltip" title="Sub Category Title"><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtState" runat="server" class="form-control input-sm" Width="30%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="Enter State" ControlToValidate="txtState" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Country</label>
                        <a href="#" data-toggle="tooltip" title="Sub Category Title"><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtCountry" runat="server" class="form-control input-sm" Width="30%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" runat="server" ErrorMessage="Enter Country" ControlToValidate="txtCountry" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Zip</label>
                        <a href="#" data-toggle="tooltip" title="Sub Category Title"><i class="fa fa-question-circle"></i></a>
                        <asp:TextBox ID="txtZip" runat="server" class="form-control input-sm" Width="30%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="Red" runat="server" ErrorMessage="Enter Zip" ControlToValidate="txtZip" ValidationGroup="admin"></asp:RequiredFieldValidator>
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

    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-8">
                    <h4>Manage Delevery Team</h4>
                    <p>
                        You can add, edit or delete your Delevery Team here. The list view allows you to see all created Delevery Team in a clearly arranged list and provides a search widget so you can easily find the Delevery Team you are searching for.
                    </p>
                </div>
                <div class="col-md-4">
                    <div style="float: right">
                        <a href="#" data-toggle="modal" data-target="#modalCategory" class="btn btn-info">+ Add New</a>
                    </div>
                </div>
            </div>
            <table class="table table-striped" id="dataTable">
                <thead>
                    <tr>
                        <th>TeamCode</th>
                        <th>Name</th>
                        <th>EmailId</th>
                        <th>Phone</th>
                        <th>Status</th>
                        <th>Method</th>
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
                            <%=item.TeamCode %></td>
                        <td>
                            <%=item.Name %>
                        </td>
                        <td><%=item.EmailId %></td>
                        <td><%=item.Phone %></td>
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
                        <td><%=item.DeliveryMethod.Title %></td>
                        <td><%=item.DateCreated %></td>
                        <td><%=item.DateUpdated %></td>
                        <td><a href="/administration/categories/deleveryteamdetail.aspx?catid=<%=item.TeamId %>"><i class="fa fa-edit fa-lg"></i></a></td>
                        <%
                            }
                        %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
