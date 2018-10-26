<%@ Page Title="" Language="C#" MasterPageFile="~/account/Account.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.account.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>SIGN IN</h2>
    <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">
        <button type="button" class="close" data-dismiss="alert">×</button>
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    </asp:Panel>
    <div class="form-group">
        <div class="email controls">
            <asp:TextBox ID="txtUserName" runat="server" placeholder="Email Id" TextMode="Email" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Email Id" ControlToValidate="txtUserName" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="pw controls">
            <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="submit">
        <div class="remember">
            <input type="checkbox" name="remember" class='icheck-me' data-skin="square" data-color="blue" id="remember" />
            <label for="remember">Remember me</label>
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="Sign In" ValidationGroup="login" class="btn btn-success btn-sm pull-right" OnClick="btnLogin_Click" />
    </div>
    <div class="forget">
        <a href="/account/forgotpassword.aspx?redirectUrl=forget-administrator-home&pageId=1234HJHJKJ*7987979">
            <span>Forgot password?</span>
        </a>
    </div>
</asp:Content>
