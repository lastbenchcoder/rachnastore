<%@ Page Title="" Language="C#" MasterPageFile="~/account/Account.Master" AutoEventWireup="true" CodeBehind="passwordreset.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.account.passwordreset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>PASSWORD RESET</h2>
    <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">
        <button type="button" class="close" data-dismiss="alert">×</button>
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
        <asp:HiddenField ID="hdnEmailId" runat="server" />
    </asp:Panel>
    <div class="form-group">
        <div class="pw controls">
            <asp:TextBox ID="txtPassword" runat="server" placeholder="New Password" TextMode="Password" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter New Password" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ControlToValidate="txtPassword" ValidationGroup="login" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{5,8}$" runat="server" ErrorMessage="Minimum 5 and Maximum 8 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="form-group">
        <div class="pw controls">
            <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Confirm Password" TextMode="Password" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Confirm Password" ControlToValidate="txtConfirmPassword" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ControlToValidate="txtConfirmPassword" ValidationGroup="login" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{5,8}$" runat="server" ErrorMessage="Minimum 5 and Maximum 8 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
             <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not match" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red" ValidationGroup="login"></asp:CompareValidator>
        </div>
    </div>
    <div class="submit">
       <asp:Button ID="btnResetPassword" runat="server" Text="Send Me" ValidationGroup="login" class="btn btn-success btn-sm pull-right" OnClick="btnResetPassword_Click" />
    </div>
    <div class="forget">
        <a href="/account/login.aspx?a4rredirectUrl=login-administrator-home&pageId=1234HJHJKJ*7987979">
            <span>I Have Password, Login</span>
        </a>
    </div>
</asp:Content>
