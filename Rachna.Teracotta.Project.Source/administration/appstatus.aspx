<%@ Page Title="" Language="C#" MasterPageFile="~/administration/Home.Master" AutoEventWireup="true" CodeBehind="appstatus.aspx.cs" Inherits="Rachna.Teracotta.Project.Source.administration.appstatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext context = new Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext();
        int appPercentage = 0;
        int Meta_Info = context.MetaInformation.ToList().Count;
        int App_Logo = context.Logo.ToList().Count;

        int App_Categories = context.Category.ToList().Count;
        int App_Slider = context.Slider.ToList().Count;

        int App_Product = context.Product.ToList().Count;
        int SocialNetwork = context.SocialNetworking.ToList().Count;
        int DealOfTheDay = context.DealOfTheDay.ToList().Count;
        int App_Best_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == Rachna.Teracotta.Project.Source.Entity.eProductFeature.Best.ToString()).ToList().Count;
        int App_Featured_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == Rachna.Teracotta.Project.Source.Entity.eProductFeature.Featured.ToString()).ToList().Count;
        int App_Hot_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == Rachna.Teracotta.Project.Source.Entity.eProductFeature.Hot.ToString()).ToList().Count;
        int App_Latest_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == Rachna.Teracotta.Project.Source.Entity.eProductFeature.Latest.ToString()).ToList().Count;
        int App_Top_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == Rachna.Teracotta.Project.Source.Entity.eProductFeature.Top.ToString()).ToList().Count;
        int App_Our_Choice_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == Rachna.Teracotta.Project.Source.Entity.eProductFeature.OurChoice.ToString()).ToList().Count;
        int TopEight = context.ProductEights.ToList().Count;

        if (Meta_Info > 0 && App_Logo > 0 && SocialNetwork > 0)
        {
            appPercentage = 30;
            if (App_Categories > 0)
                appPercentage = appPercentage + 10;
            if (App_Product > 7)
                appPercentage = appPercentage + 5;
            if (TopEight > 7)
                appPercentage = appPercentage + 5;
            if (DealOfTheDay > 0)
                appPercentage = 55;
            if (App_Best_Product > 0)
                appPercentage = appPercentage + 5;
            if (App_Featured_Product > 0)
                appPercentage = appPercentage + 5;
            if (App_Hot_Product > 0)
                appPercentage = appPercentage + 5;
            if (App_Top_Product > 0)
                appPercentage = appPercentage + 5;
            if (App_Latest_Product > 0)
                appPercentage = appPercentage + 5;
            if (App_Our_Choice_Product > 0)
                appPercentage = appPercentage + 10;
            if (App_Slider > 0)
                appPercentage = appPercentage + 10;
        }
        else
        {
            appPercentage = 0;
        }
    %>
    <div class="container-fluid">
        <div class="page-header">
            <div class="pull-left">
                <h1>Application Status</h1>
            </div>
        </div>
        <div class="breadcrumbs">
            <ul>
                <li>
                    <a href="/administration/default.aspx?redirectUrl=default-administrator-home&pageId=1234HJHJKJ*7987979">Home</a>
                    <i class="fa fa-angle-right"></i>
                </li>
                <li>
                    <a href="#">Application Status</a>
                    <i class="fa fa-angle-right"></i>
                </li>
            </ul>
            <div class="close-bread">
                <a href="#">
                    <i class="fa fa-times"></i>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="box box-color box-bordered">
                    <div>APPLICATION STATUS <%=appPercentage %> %</div>

                    <% 
                        if (appPercentage == 0)
                        {
                    %>
                    <h3>Application Status is 0%, Please find the reasons below</h3>
                    <ol>
                        <li>You should upload Meta Information</li>
                        <li>You should upload Logo</li>
                        <li>You should upload atleast one Social Network Information</li>
                    </ol>
                    <%}%>

                    <%  if (App_Categories < 0)
                        {%>
                    <h5>You should have atleast 1 Category and Sub Category</h5>
                    <%}
                        if (App_Product < 7)
                        {%>
                    <h5>You should have atleast 8 Products</h5>
                    <%}
                        if (TopEight < 7)
                        {%>
                    <h5>You should have Top 8 Products for better User interface</h5>
                    <%}
                        if (DealOfTheDay < 1)
                        {%>
                    <h5>You should have atleast 1 Deal of the day for better User interface</h5>
                    <%}
                        if (App_Best_Product < 1)
                        {%>
                    <h5>You should have atleast one Best Product for better User interface</h5>
                    <%}
                        if (App_Featured_Product < 1)
                        {%>
                    <h5>You should have atleast one Featured Product for better User interface</h5>
                    <%}
                        if (App_Hot_Product < 1)
                        {%>
                    <h5>You should have atleast one Hot Product for better User interface</h5>
                    <%}
                        if (App_Top_Product < 1)
                        {%>
                    <h5>You should have atleast one Top Product for better User interface</h5>
                    <%}
                        if (App_Latest_Product < 1)
                        {%>
                    <h5>You should have atleast one Latest Product for better User interface</h5>
                    <%}
                        if (App_Our_Choice_Product > 1)
                        {%>
                    <h5>You should have atleast one Our choice Product for better User interface</h5>
                    <%}
                        if (App_Slider < 1)
                        {%>
                    <h5>You should have atleast one Slider for better User interface</h5>
                    <%}%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
