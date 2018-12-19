<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="subcategory.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.categories.subcategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
        List<Rachna.Teracotta.Project.Source.Models.SubCategories> _RequestList = null;
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        _RequestList = context.SubCategory.Include("Category").Include("Admin").ToList();
    %>

    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>All Sub Categories</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Catalog</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Manage Sub Categories</a>
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
                            Sub Catrgory
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class="form-group col-lg-3" style="margin-top: 10px">
                            <label>Select Category</label>
                            <asp:DropDownList ID="ddlCategory" runat="server" class="form-control input-sm">
                                <asp:ListItem>Select..</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Select Category" InitialValue="Select.." ControlToValidate="ddlCategory" ValidationGroup="admin"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-lg-3" style="margin-top: 10px">
                            <label>Title</label>
                            <asp:TextBox ID="txtCategory" runat="server" class="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Enter Category title" ControlToValidate="txtCategory" ValidationGroup="admin"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-lg-3" style="margin-top: 32px">
                            <label>&nbsp;</label>
                             <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" ValidationGroup="admin" OnClick="btnSubmit_Click" />
                            <label>&nbsp;</label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                           Sub Catrgory
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th>SubCategoryCode</th>
                                    <th>Category</th>
                                    <th>SubCategory</th>
                                    <th>Status</th>
                                    <th>CreatedBy</th>
                                    <th>CreatedDate</th>
                                    <th>UpdatedDate</th>
                                    <th>Edit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% 
                                    foreach (var item in _RequestList)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <%=item.SubCategoryCode %></td>
                                    <td>
                                        <%=item.Category.Category_Title %>
                                    </td>
                                    <td><%=item.SubCategory_Title %></td>
                                    <%if (item.SubCategory_Status == Rachna.Teracotta.Project.Source.Entity.eStatus.Active.ToString())
                                        {%>
                                    <td><span style="font-weight: bold; color: green">
                                        <%=item.SubCategory_Status %>
                                    </span></td>
                                    <%}
                                        else
                                        { %>
                                    <td><span style="font-weight: bold; color: red">
                                        <%=item.SubCategory_Status %>
                                    </span></td>
                                    <%} %>
                                    <td><%=item.Admin.FullName %></td>
                                    <td><%=item.SubCategory_CreatedDate %></td>
                                    <td><%=item.SubCategory_UpdatedDate %></td>
                                    <td><a href="/administration/categories/subcategorydetail.aspx?catid=<%=item.SubCategory_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
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
