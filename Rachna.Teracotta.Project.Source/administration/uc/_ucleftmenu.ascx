<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_ucleftmenu.ascx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.uc._ucleftmenu" %>
<%@ Register TagPrefix="uc" TagName="ucOnlineUser" Src="~/administration/uc/_onlineusers.ascx" %>
<div id="left">
    <div class='search-form'>
        <div class="search-pane">
            <asp:TextBox ID="txtSearchHome" runat="server" name="search" placeholder="Product Id or Code..."></asp:TextBox>
            <asp:LinkButton ID="btnSearchPrdHome" runat="server" OnClick="btnSearchPrdHome_Click" type="submit"><i class="fa fa-search"></i></asp:LinkButton>
        </div>
    </div>
    <div class="subnav">
        <div class="subnav-title">
            <a href="#" class='toggle-subnav'>
                <i class="fa fa-angle-down"></i>
                <span>Application Content</span>
            </a>
        </div>
        <ul class="subnav-menu">
            <li class='dropdown'>
                <a href="#" data-toggle="dropdown">Application</a>
                <ul class="dropdown-menu">
                    <li>
                        <a href="/administration/application/logo.aspx?redirecturl=admin-pages-rachna-teracotta&page-id=gfhtyyen7777777sndbjsdfskjdfsd76876sdfsdfhdsfshdj">Logo</a>
                    </li>
                    <li>
                        <a href="/administration/application/socialnetwork.aspx?redirecturl=admin-pages-rachna-teracotta&page-id=gfhtyyen7777777sndbjsdfskjdfsd76876sdfsdfhdsfshdj">Social Network</a>
                    </li>
                    <li>
                        <a href="/administration/application/metainformation.aspx?redirecturl=admin-pages-rachna-teracotta&page-id=gfhtyyen7777777sndbjsdfskjdfsd76876sdfsdfhdsfshdj">Meta Information</a>
                    </li>
                    <li>
                        <a href="/administration/application/contact.aspx?redirecturl=admin-pages-rachna-teracotta&page-id=gfhtyyen7777777sndbjsdfskjdfsd76876sdfsdfhdsfshdj">Contact Information</a>
                    </li>
                    <li>
                        <a href="/administration/application/pageunderconstruction.aspx?redirecturl=pageunderconstruction-pages-rachna-teracotta&page-id=gfhtyyen7777777sndbjsdfskjdfsd76876sdfsdfhdsfshdj">Page Under Construction</a>
                    </li>
                </ul>
            </li>
            <li>
                <a href="/administration/home/slider.aspx?redirecturl=admin-slider-rachna-teracotta">Home Page Slider</a>
            </li>
            <li>
                <a href="/administration/home/advertisement.aspx?redirecturl=admin-advertisement-rachna-teracotta">Advertisement Area</a>
            </li>
            <li>
                <a href="/administration/home/featuredProducts.aspx?redirecturl=admin-featured-products-rachna-teracotta">Featured Products</a>
            </li>
            <li>
                <a href="/administration/home/topeight.aspx?redirecturl=admin-slider-rachna-teracotta">Top Eight Products</a>
            </li>
            <li class='dropdown'>
                <a href="#" data-toggle="dropdown">Page & Menus</a>
                <ul class="dropdown-menu">
                    <li>
                        <a href="/administration/pages/allpages.aspx?redirecturl=admin-pages-rachna-teracotta">Pages</a>
                    </li>
                    <li>
                        <a href="/administration/menus/menus.aspx?redirect-url=jhgj657657HGH.htm">Menus</a>
                    </li>
                </ul>
            </li>
            <li>
                <a href="#" id="addClass">Open in chat </a>
            </li>
        </ul>
       <uc:ucOnlineUser ID="ucOnlineUser" runat="server" />
    </div>
</div>
