<%@ Page Title="" Language="C#" MasterPageFile="~/setup/security.Master" AutoEventWireup="true" CodeBehind="security.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.setup.security" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="nav-justified">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Enter Security ID</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtSecurityId" runat="server" class="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSecurityId" ErrorMessage="Security Id Cannot be blank" ForeColor="Red" ValidationGroup="secid"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" ValidationGroup="secid"/>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblErrorMessage" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>
