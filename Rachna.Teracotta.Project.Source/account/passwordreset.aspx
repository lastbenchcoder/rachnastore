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
    <asp:ValidationSummary
        ID="ValidationSummary1"
        runat="server"
        HeaderText="Please Fix following error occurs....."
        ShowMessageBox="false"
        DisplayMode="BulletList"
        ShowSummary="true"
        BackColor="Snow"
        ForeColor="Red"
        Font-Italic="true"
        ValidationGroup="admin" />
    <div class="form-group">
        <div class="pw controls">
            <asp:TextBox ID="txtPassword" runat="server" placeholder="New Password" TextMode="Password" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ErrorMessage="Enter New Password" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="admin"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="Regex5" runat="server" ControlToValidate="txtPassword"
                ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}" Display="None"
                ErrorMessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ForeColor="Red" />
        </div>
    </div>
    <div class="form-group">
        <div class="pw controls">
            <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Confirm Password" TextMode="Password" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Confirm Password" Display="None" ControlToValidate="txtConfirmPassword" ForeColor="Red" ValidationGroup="admin"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConfirmPassword"
                ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}" Display="None"
                ErrorMessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ForeColor="Red" ValidationGroup="admin" />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword" Display="None" ControlToCompare="txtPassword"
                ErrorMessage="Both Passwords are not same, please provide same Password" ValidationGroup="admin"></asp:CompareValidator>
        </div>
    </div>
    <div class="submit">
        <asp:Button ID="btnResetPassword" runat="server" Text="Send Me" ValidationGroup="admin" class="btn btn-success btn-sm pull-right" OnClick="btnResetPassword_Click" />
    </div>
    <div class="forget">
        <a href="/account/login.aspx?a4rredirectUrl=login-administrator-home&pageId=1234HJHJKJ*7987979">
            <span>I Have Password, Login</span>
        </a>
    </div>
</asp:Content>
