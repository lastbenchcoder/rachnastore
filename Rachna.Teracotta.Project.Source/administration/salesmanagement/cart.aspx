<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.salesmanagement.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            width: 413px;
        }

        .auto-style10 {
            width: 369px;
        }

        .auto-style11 {
            width: 369px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3>Store &amp; Carts</h3>
        </div>
        <div class="panel-body">
            <table style="width: 100%">
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style8"></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style11">Select Store&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="ddlStore" runat="server" class="form-control input-sm">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;
                    &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="Atlease select store" InitialValue="Select.." ControlToValidate="ddlStore" ValidationGroup="admin"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">Start date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtStartDate" type="date" runat="server" class="form-control input-sm"></asp:TextBox>

                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">End date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtEndDate" type="date" runat="server" class="form-control input-sm"></asp:TextBox>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Status&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control input-sm" Width="30%">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-success btn-sm" Text="Search" ValidationGroup="admin" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <div class="container-fluid" style="margin-top: 20px; margin-bottom: 20px; text-align: right">
                <asp:Button ID="btnExport" runat="server" Text="Export To Excel" class="btn btn-primary" OnClick="ExportToExcel" />
            </div>
            <div class="container">
                <asp:GridView ID="grdStoreCart" runat="server" AutoGenerateColumns="False" class="table table-striped grdStoreCart">
                    <Columns>
                        <asp:BoundField DataField="Cart_Id" HeaderText="CartId" />
                        <asp:ImageField DataImageUrlField="Product_Banner" DataImageUrlFormatString="../../{0}">
                            <ControlStyle Height="100px" Width="100px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="Customer_Id" HeaderText="CustomerId	" />
                        <asp:BoundField DataField="Customer_Name" HeaderText="CustomerName	" />
                        <asp:BoundField DataField="Cart_Qty" HeaderText="Qty	" />
                        <asp:BoundField DataField="Cart_Size" HeaderText="Size" />
                        <asp:HyperLinkField DataNavigateUrlFields="Product_Id" DataNavigateUrlFormatString="/administration/product/productsdetailstatic.aspx?Productid={0}" DataTextField="Product_Title" HeaderText="Product Title" />
                        <asp:BoundField DataField="DateCreated" HeaderText="Date" />
                        <asp:BoundField DataField="Cart_Status" HeaderText="Status" />
                    </Columns>
                    <EmptyDataTemplate>
                        &nbsp;No Carts found for your search
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
