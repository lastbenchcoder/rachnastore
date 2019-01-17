<%@ Page Title="" Language="C#" MasterPageFile="~/support/home/Home.Master" AutoEventWireup="true" CodeBehind="defectdetail.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.support.home.defectdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%
         List<Rachna.Teracotta.Project.Source.Models.FunctionalDefectStory> FunctionalDefectStory = null;
         if (Request.QueryString["defectid"] != null)
         {
             int defectId = Convert.ToInt32(Request.QueryString["defectid"].ToString());
             FunctionalDefectStory = Rachna.Teracotta.Project.Source.Core.bal.bFunctionalDefect.ListStory(defectId);
         }
    %>
    <div class="page-header">
        <div class="pull-left">
            <h1>
                <asp:Literal ID="ltlDefectTitle" runat="server"></asp:Literal>
            </h1>
        </div>
        <div class="pull-right">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn btn-info" />
            &nbsp &nbsp
                        <asp:Button ID="btnImageUpload" runat="server" Text="Upload Banner" class="btn btn-info" />
            &nbsp &nbsp
                        <asp:Button ID="btnApprove" runat="server" Text="Publish" class="btn btn-primary" />
            &nbsp &nbsp
                        <asp:HyperLink ID="btnRejectModel" runat="server" data-toggle="modal" data-target="#modalRejectProduct" class="btn btn-danger">Reject</asp:HyperLink>
            &nbsp &nbsp
                        <a href="/administration/product/products.aspx?redirecturl=admin-allproduct-RachnaTeracotta" class="btn btn-brown">Go Back</a>
            &nbsp &nbsp
        </div>
    </div>
    <div class="breadcrumbs">
        <ul>
            <li>
                <a href="/support/home/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Dashboard</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">Support</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="/support/home/defect.aspx?redirecturl=admin-defect-manager-rachna-teracott">Ticket</a>
                <i class="fa fa-angle-right"></i>
            </li>
            <li>
                <a href="#">
                    <asp:Literal runat="server" ID="ltlBc"></asp:Literal>
                </a>
            </li>
        </ul>
        <div class="close-bread">
            <a href="#">
                <i class="fa fa-times"></i>
            </a>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <div class="box">
                <div class="box-title">
                    <h3>Resolver :
                        <asp:Label ID="lblResolver" runat="server"></asp:Label>
                    </h3>
                </div>
                <div class="box-content">
                    <h1>h1. Heading 1</h1>
                    <h2>h2. Heading 2</h2>
                    <h3>h3. Heading 3</h3>
                    <h4>h4. Heading 4</h4>
                    <h5>h5. Heading 5</h5>
                    <h6>h6. Heading 6</h6>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="box">
                <div class="box-title">
                    <h3>Status :
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </h3>
                </div>
                <div class="box-content">
                    <%foreach (var item in FunctionalDefectStory)
                        { %>
                    <blockquote>
                        <p>
                            <%=item.Description %>
                        </p>
                        <small><%=item.Status %></small>
                    </blockquote>
                    <%} %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
