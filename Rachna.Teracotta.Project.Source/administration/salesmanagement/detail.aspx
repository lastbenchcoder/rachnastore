<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.customer.detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
            width: 208px;
        }

        .auto-style2 {
            width: 208px;
        }

        .auto-style3 {
            width: 621px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%
        Rachna.Teracotta.Project.Source.Models.Customers _RequestList = null;
        using (var ctx = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext())
        {
            int customerId = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
            _RequestList = ctx.Customer.ToList().Where(m => m.Customer_Id == customerId).FirstOrDefault();

            if (_RequestList.Customers_FullName != null)
            {
                _RequestList.Cart = ctx.Cart.ToList().Where(m => m.Customer_Id == _RequestList.Customer_Id).ToList();
                _RequestList.Orders = ctx.Orders.ToList().Where(m => m.Customer_Id == _RequestList.Customer_Id).ToList();
                _RequestList.CustomerAddress = ctx.CustomerAddres.Where(m => m.Customer_Id == _RequestList.Customer_Id).ToList();
            }

            lblCustomerId.Text = _RequestList.Customer_Id.ToString();
            lblCustomerName.Text = _RequestList.Customers_FullName;
            lblDescription.Text = _RequestList.Customers_Description;

            grdAddress.DataSource = _RequestList.CustomerAddress;
            grdAddress.DataBind();

            grdCarts.DataSource = _RequestList.Cart;
            grdCarts.DataBind();

            grdOrders.DataSource = _RequestList.Orders;
            grdOrders.DataBind();
        }
    %>
    <div class="panel panel-default">
        <div style="margin-left: 20px">
            <table class="nav-justified">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="#336600"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Customer Id: </td>
                    <td class="auto-style3">&nbsp;&nbsp;
                    <asp:Label ID="lblCustomerId" runat="server"></asp:Label>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Customer Name:</td>
                    <td class="auto-style3">&nbsp;&nbsp;
                 <asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Customer Description :</td>
                    <td class="auto-style3">&nbsp;
                 <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Address</td>
                    <td class="auto-style3">

                        <asp:GridView ID="grdAddress" runat="server" class="table table-bordered table-condensed table-hover table-striped" Width="95%" Style="margin-left: 10px" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Customer_AddressLine1" HeaderText="Address Line 1" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="Customer_AddressLine2" HeaderText="Address Line 2" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="CustomerAddress_LandMark" HeaderText="Land Mark" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="CustomerAddress_City" HeaderText="City" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="CustomerAddress_State" HeaderText="State" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="CustomerAddress_Country" HeaderText="Country" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="CustomerAddress_ZipCode" HeaderText="ZipCode" SortExpression="Customer_Id" />
                            </Columns>
                            <EmptyDataTemplate>
                                No Address found...
                            </EmptyDataTemplate>
                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Carts</td>
                    <td class="auto-style3">

                        <asp:GridView ID="grdCarts" runat="server" class="table table-bordered table-condensed table-hover table-striped" Width="95%" Style="margin-left: 10px" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "../../"+ Eval("Product_Banner") %>' Width="100px" Height="100px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Ip_Address" HeaderText="Ip Address" SortExpression="Ip_Address" />
                                <asp:BoundField DataField="Product_Title" HeaderText="Size" SortExpression="Product_Title" />
                                <asp:BoundField DataField="Cart_Size" HeaderText="Size" SortExpression="Cart_Size" />
                                <asp:BoundField DataField="Product_Price" HeaderText="Product Price" SortExpression="Product_Price" />
                                <asp:BoundField DataField="Cart_Qty" HeaderText="Quantity" SortExpression="Cart_Qty" />
                                <asp:BoundField DataField="Cart_Price" HeaderText="Total Price" SortExpression="Cart_Price" />
                                <asp:BoundField DataField="Cart_Status" HeaderText="Status" SortExpression="Cart_Status" />
                            </Columns>
                            <EmptyDataTemplate>
                                No Carts found...
                            </EmptyDataTemplate>
                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Orders</td>
                    <td class="auto-style3">

                        <asp:GridView ID="grdOrders" class="table table-bordered table-condensed table-hover table-striped" Width="95%" Style="margin-left: 10px" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "../../"+ Eval("Product_Banner") %>' Width="100px" Height="100px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Product_Title" HeaderText="Size" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="Order_Size" HeaderText="Size" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="Product_Price" HeaderText="Product Price" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="Order_Qty" HeaderText="Quantity" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="Order_Price" HeaderText="Total Price" SortExpression="Customer_Id" />
                                <asp:BoundField DataField="Order_Status" HeaderText="Status" SortExpression="Customer_Id" />
                            </Columns>
                            <EmptyDataTemplate>
                                No Orders found...
                            </EmptyDataTemplate>
                        </asp:GridView>

                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

