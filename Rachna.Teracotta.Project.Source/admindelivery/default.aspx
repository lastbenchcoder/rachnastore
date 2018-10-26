<%@ Page Title="" Language="C#" MasterPageFile="~/admindelivery/Account.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.admindelivery._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Authentication</h2>
    <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">
        <button type="button" class="close" data-dismiss="alert">×</button>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </asp:Panel>
    <div class="form-group">
        <div class="email controls">
            <asp:TextBox ID="txtDeliveryId" runat="server" placeholder="Your Auth Code" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDeliveryId" ErrorMessage="Enter valid Auth Code" ForeColor="Red" ValidationGroup="delivery"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="submit">
        <div class="remember">
            <label for="remember">&nbsp;</label>
        </div>
        <asp:Button ID="btnDelivery" runat="server" Text="Sign In" ValidationGroup="delivery" class="btn btn-success btn-sm pull-right" OnClick="btnDelivery_Click" />
    </div>
    <div class="forget">
        <span>&nbsp;</span>
    </div>
</asp:Content>
