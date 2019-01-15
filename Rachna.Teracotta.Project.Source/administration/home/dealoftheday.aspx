<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="dealoftheday.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.home.dealoftheday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<Rachna.Teracotta.Project.Source.Models.DealOfTheDay> _RequestList = null;
        _RequestList = Rachna.Teracotta.Project.Source.Core.bal.bDealOfTheDay.List();
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Deal Of The Day</h1>
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
                    <a href="#">Deal Of The Day</a>
                    <i class="fa fa-angle-right"></i>
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
                <div class="box box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-th-list"></i>Deal Of The Day Products

                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <div class="form-group col-lg-3" style="margin-top: 10px">
                            <label>Enter Product ID</label>
                            <asp:TextBox ID="txtProductSearch" runat="server" class="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server"
                                ErrorMessage="Enter Product Id" ControlToValidate="txtProductSearch" ValidationGroup="prdSearch">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-lg-3" style="margin-top: 32px">
                            <label>&nbsp;</label>
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-primary" Text="Search" ValidationGroup="prdSearch" />
                            <label>&nbsp;</label>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="pnlProduct" runat="server" Visible="false">
                <div class="col-sm-12">
                    <div class="box box-color box-bordered">
                        <div class="box-title">
                            <h3>
                                <i class="fa fa-table"></i>
                                Product Detail
                            </h3>
                        </div>
                        <div class="box-content nopadding">
                            <div class="box-content nopadding">
                                <div class='form-horizontal form-striped'>
                                    <div class="form-group">
                                        <label for="txtFirstName" class="control-label col-sm-2">&nbsp;</label>
                                        <div class="col-sm-10">
                                            <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtFirstName" class="control-label col-sm-2">Product Id</label>
                                        <div class="col-sm-10">
                                            <asp:Literal ID="lblId" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtFirstName" class="control-label col-sm-2">Product Title</label>
                                        <div class="col-sm-10">
                                            <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtFirstName" class="control-label col-sm-2">Product Actual Price</label>
                                        <div class="col-sm-10">
                                            <asp:Literal ID="ltlActualPrice" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtFirstName" class="control-label col-sm-2">Deal Price</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtDealPrice" runat="server" TextMode="Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server"
                                                ErrorMessage="Enter Deal Price" ControlToValidate="txtDealPrice" ValidationGroup="dealoftheday"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtFirstName" class="control-label col-sm-2">Deal Starts On :</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtStartDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server"
                                                ErrorMessage="Select Deal Day" ControlToValidate="txtStartDate" ValidationGroup="dealoftheday"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-actions col-sm-offset-2 col-sm-10 pull-right">
                                        <asp:Button ID="btnDealPrice" runat="server" class="btn btn-primary" Text="Save Changes"
                                            OnClick="btnDealPrice_Click" ValidationGroup="dealoftheday" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div class="box-title">
                        <h3>
                            <i class="fa fa-table"></i>
                            Product Deals
                        </h3>
                    </div>
                    <div class="box-content nopadding">
                        <table class="table table-hover table-nomargin table-bordered dataTable">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Product</th>
                                    <th>Actual Price</th>
                                    <th>Deal Price</th>
                                    <th>Deal Day</th>
                                    <td>Status</td>
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
                                        <img src="../../<%=item.Product.ProductBanner.Where(m=>m.Product_Banner_Default==1).FirstOrDefault().Product_Banner_Photo %>" style="height: 50px; width: 50px" />
                                    </td>
                                    <td><%=item.Product.Product_Title %></td>
                                    <td><%=item.Product.Product_Our_Price %></td>
                                    <td><%=item.Deal_Price %></td>
                                    <td><%=item.Deal_Starts_From.ToString("D") %></td>
                                    <td>
                                        <%if (item.Deal_Starts_From.Date >= DateTime.Now.Date)
                                            { %>
                                        <span class="label label-success">Active</span>
                                        <%}
                                        else
                                        { %>
                                        <span class="label label-danger">Expired</span>
                                        <%} %>
                                    </td>
                                    <td><%=item.Deal_CreatedDate.ToString("D") %></td>
                                    <td><%=item.Deal_UpdatedDate.ToString("D") %></td>
                                    <td><a href="/administration/home/dealofthedaydetail.aspx?dealId=<%=item.Deal_Id %>"><i class="fa fa-edit fa-lg"></i></a></td>
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
