<%@ Page Title="" Language="C#" MasterPageFile="~/account/Account.Master" AutoEventWireup="true" CodeBehind="invitation.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.account.invitation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Account Registration</h2>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">
            <button type="button" class="close" data-dismiss="alert">×</button>
            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
            <asp:HiddenField ID="hdnCode" runat="server" />
        </asp:Panel>
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="login" ForeColor="Red" />
        <asp:HiddenField ID="hdnInviteCode" runat="server" />
        <div class="form-group">
            <div class="email controls">
                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" ReadOnly="true" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="email controls">
                <asp:TextBox ID="txtPhone" TextMode="Phone" runat="server" placeholder="Phone Number" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ErrorMessage="Enter Phone Number" ControlToValidate="txtPhone" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="email controls">
                <asp:TextBox ID="txtPassword" runat="server" placeholder="New Password" TextMode="Password" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="None" runat="server" ErrorMessage="Enter New Password" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ControlToValidate="txtPassword" runat="server" Display="None" ValidationGroup="login" ID="RegularExpressionValidator3" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,15}$" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="email controls">
                <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Confirm Password" TextMode="Password" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Confirm Password" ControlToValidate="txtConfirmPassword" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="None" ControlToValidate="txtConfirmPassword" ValidationGroup="login" ID="RegularExpressionValidator1" runat="server" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,15}$" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="CompareValidator1" Display="None" runat="server" ErrorMessage="Password does not match" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red" ValidationGroup="login"></asp:CompareValidator>
            </div>
        </div>
        <div class="submit">
            <asp:Button ID="btnResetPassword" runat="server" Text="Submit" ValidationGroup="login" class="btn btn-success btn-sm pull-right" OnClick="btnResetPassword_Click" />
        </div>
        <div class="forget">
            <a href="/account/login.aspx?a4rredirectUrl=login-administrator-home&pageId=1234HJHJKJ*7987979">
                <span>Login</span>
            </a>
        </div>
    </asp:Panel>
</asp:Content>
