<%@ Page Title="" Language="C#" MasterPageFile="~/setup/security.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.setup.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <h4>APPLICATION SETUP</h4>
    <br />
    You can set the application here, sample details will be addded to your database.
    <br />
    <br />
    <asp:Button ID="btnSetUp" runat="server" Text="SetUp Application" OnClick="btnSetUp_Click" class="btn btn-primary" />
    <br />
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></asp:Label>
    <br />
    <br />
    <br />
    <a href="/setup/defaultdata.aspx" class="btn btn-brown">What And All is created?</a>
    <br />
    <br />
    <br />
</asp:Content>
