<%@ Page Title="" Language="C#" MasterPageFile="~/setup/security.Master" AutoEventWireup="true" CodeBehind="defaultdata.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.setup.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br />
    <a href="/setup/home.aspx/">Go Back</a>
    <br />
    <br />
    <h4>STORE</h4>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="store_id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="store_id" HeaderText="store_id" InsertVisible="False" ReadOnly="True" SortExpression="store_id" />
            <asp:BoundField DataField="store_code" HeaderText="store_code" SortExpression="store_code" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
            <asp:BoundField DataField="url" HeaderText="url" SortExpression="url" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RachnaConnectionString %>" SelectCommand="SELECT * FROM [tbl_store]"></asp:SqlDataSource>
    <br />
    <br />
     <h4>INVITATION</h4>
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="invitation_id" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField DataField="invitation_id" HeaderText="invitation_id" InsertVisible="False" ReadOnly="True" SortExpression="invitation_id" />
            <asp:BoundField DataField="invitation_code" HeaderText="invitation_code" SortExpression="invitation_code" />
            <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
            <asp:BoundField DataField="store_id" HeaderText="store_id" SortExpression="store_id" />
            <asp:BoundField DataField="emailid" HeaderText="emailid" SortExpression="emailid" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="activity_mail" HeaderText="activity_mail" SortExpression="activity_mail" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RachnaConnectionString %>" SelectCommand="SELECT * FROM [tbl_invitation]"></asp:SqlDataSource>
    <br />
     <h4>ADMINISTRATOR</h4>
    <br />
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="admin_id" DataSourceID="SqlDataSource4">
        <Columns>
            <asp:BoundField DataField="admin_id" HeaderText="admin_id" InsertVisible="False" ReadOnly="True" SortExpression="admin_id" />
            <asp:BoundField DataField="invitation_id" HeaderText="invitation_id" SortExpression="invitation_id" />
            <asp:BoundField DataField="store_id" HeaderText="store_id" SortExpression="store_id" />
            <asp:BoundField DataField="fullname" HeaderText="fullname" SortExpression="fullname" />
            <asp:BoundField DataField="emailid" HeaderText="emailid" SortExpression="emailid" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
            <asp:BoundField DataField="login_attempt" HeaderText="login_attempt" SortExpression="login_attempt" />
            <asp:BoundField DataField="activity_mail" HeaderText="activity_mail" SortExpression="activity_mail" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RachnaConnectionString %>" SelectCommand="SELECT * FROM [tbl_Admin]"></asp:SqlDataSource>
    <br />
        <br />
    <br />
     <h4>CUSTOMER</h4>
    <br />
    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataKeyNames="Customer_Id" DataSourceID="SqlDataSource5">
        <Columns>
            <asp:BoundField DataField="Customer_Id" HeaderText="Customer_Id" InsertVisible="False" ReadOnly="True" SortExpression="Customer_Id" />
            <asp:BoundField DataField="customer_code" HeaderText="customer_code" SortExpression="customer_code" />
            <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
            <asp:BoundField DataField="fullname" HeaderText="fullname" SortExpression="fullname" />
            <asp:BoundField DataField="emailid" HeaderText="emailid" SortExpression="emailid" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="login_attempt" HeaderText="login_attempt" SortExpression="login_attempt" />
            <asp:BoundField DataField="is_mail_verified" HeaderText="is_mail_verified" SortExpression="is_mail_verified" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RachnaConnectionString %>" SelectCommand="SELECT * FROM [tbl_customer]"></asp:SqlDataSource>
    <br />
        <br />
    <br />
     <h4>PAYMENT METHOD</h4>
    <br />
    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" DataKeyNames="Payment_Method_Id" DataSourceID="SqlDataSource6">
        <Columns>
            <asp:BoundField DataField="Payment_Method_Id" HeaderText="Payment_Method_Id" InsertVisible="False" ReadOnly="True" SortExpression="Payment_Method_Id" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
            <asp:BoundField DataField="DateUpdated" HeaderText="DateUpdated" SortExpression="DateUpdated" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:RachnaConnectionString %>" SelectCommand="SELECT * FROM [tbl_payment_method]"></asp:SqlDataSource>
    <br />
         <br />
        <br />
    <br />
     <h4>DELIVERY METHOD</h4>
    <br />
    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" DataKeyNames="DeliveryMethod_Id" DataSourceID="SqlDataSource7">
        <Columns>
            <asp:BoundField DataField="DeliveryMethod_Id" HeaderText="DeliveryMethod_Id" InsertVisible="False" ReadOnly="True" SortExpression="DeliveryMethod_Id" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
            <asp:BoundField DataField="DateUpdated" HeaderText="DateUpdated" SortExpression="DateUpdated" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:RachnaConnectionString %>" SelectCommand="SELECT * FROM [tbl_delivery]"></asp:SqlDataSource>
    <br />
            <br />
        <br />
    <br />
     <h4>PAGES</h4>
    <br />
    <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" DataKeyNames="Page_Id" DataSourceID="SqlDataSource8">
        <Columns>
            <asp:BoundField DataField="Page_Id" HeaderText="Page_Id" InsertVisible="False" ReadOnly="True" SortExpression="Page_Id" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
            <asp:BoundField DataField="DateUpdated" HeaderText="DateUpdated" SortExpression="DateUpdated" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="Administrators_Id" HeaderText="Administrators_Id" SortExpression="Administrators_Id" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:RachnaConnectionString %>" SelectCommand="SELECT * FROM [tbl_pages]"></asp:SqlDataSource>
    <br />
         <br />
        <br />
    <br />
     <h4>MENUS</h4>
    <br />
    <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="False" DataKeyNames="Menu_Id" DataSourceID="SqlDataSource9" CssClass="auto-style1">
        <Columns>
            <asp:BoundField DataField="Menu_Id" HeaderText="Menu_Id" InsertVisible="False" ReadOnly="True" SortExpression="Menu_Id" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="MenuType" HeaderText="MenuType" SortExpression="MenuType" />
            <asp:BoundField DataField="Page_Id" HeaderText="Page_Id" SortExpression="Page_Id" />
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
            <asp:BoundField DataField="DateUpdated" HeaderText="DateUpdated" SortExpression="DateUpdated" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="Administrators_Id" HeaderText="Administrators_Id" SortExpression="Administrators_Id" />
        </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:RachnaConnectionString %>" SelectCommand="SELECT * FROM [tbl_app_menu]"></asp:SqlDataSource>
    <br />
</asp:Content>
