<%@ Page Title="" Language="C#" MasterPageFile="~/account/Message.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.account.logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center; margin-top: 10px; margin-bottom: 10px">
        <br />
        <br />
        <h4>
            <asp:Label ID="lblLogoutMessage" runat="server" ForeColor="green" Style="margin-bottom: 20px; margin-top: 20px"></asp:Label>
        </h4>
        <br />
        <a href="/account/login.aspx?a4rredirectUrl=login-administrator-home&pageId=1234HJHJKJ*7987979">Click Here to go to Home</a>
        <br />
        <br />
    </div>
</asp:Content>
