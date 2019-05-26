
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.App_Data
{
    public class RachnaDBContext : DbContext
    {
        public RachnaDBContext() : base("name=RachnaConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RachnaDBContext, Migrations.Configuration>("RachnaConnectionString"));
        }

        public DbSet<Stores> Store { get; set; }
        public DbSet<Stores_Audit> Stores_Audit { get; set; }

        public DbSet<Invitations> Invitation { get; set; }
        public DbSet<Invitations_Audit> Invitations_Audit { get; set; }

        public DbSet<Administrators> Administrator { get; set; }
        public DbSet<Administrators_Audit> Administrator_Audit { get; set; }
        public DbSet<AdminChatting> AdminChatting { get; set; }
        public DbSet<AdminChatting_Audit> AdminChatting_Audit { get; set; }
        public DbSet<AdminActivity> AdminActivity { get; set; }

        public DbSet<UnderConstrunction> UnderConstrunction { get; set; }
        public DbSet<UnderConstrunction_Audit> UnderConstrunction_Audit { get; set; }

        public DbSet<Logo> Logo { get; set; }
        public DbSet<Logo_Audit> Logo_Audit { get; set; }

        public DbSet<SocialNetworking> SocialNetworking { get; set; }
        public DbSet<SocialNetworking_Audit> SocialNetworking_Audit { get; set; }

        public DbSet<MetaInformation> MetaInformation { get; set; }
        public DbSet<MetaInformation_Audit> MetaInformation_Audit { get; set; }

        public DbSet<ContactOwner> ContactOwner { get; set; }
        public DbSet<ContactOwner_Audit> ContactOwner_Audit { get; set; }

        public DbSet<Categories> Category { get; set; }
        public DbSet<Categories_Audit> Categories_Audit { get; set; }

        public DbSet<SubCategories> SubCategory { get; set; }
        public DbSet<SubCategories_Audit> SubCategories_Audit { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<Product_Audit> Product_Audit { get; set; }

        public DbSet<ProductBanners> ProductBanner { get; set; }
        public DbSet<ProductBanners_Audit> ProductBanners_Audit { get; set; }

        public DbSet<ProductFeatures> ProductFeature { get; set; }
        public DbSet<ProductFeatures_Audit> ProductFeatures_Audit { get; set; }

        public DbSet<ProductEight> ProductEights { get; set; }
        public DbSet<ProductEight_Audit> ProductEight_Audit { get; set; }

        public DbSet<ProductFlow> ProductFlow { get; set; }
        public DbSet<ProductFlow_Audit> ProductFlow_Audit { get; set; }

        public DbSet<ProdComments> ProdComments { get; set; }
        public DbSet<ProdComments_Audit> ProdComments_Audit { get; set; }

        public DbSet<Sliders> Slider { get; set; }
        public DbSet<Sliders_Audit> Sliders_Audit { get; set; }

        public DbSet<Ads> Advertisement { get; set; }
        public DbSet<Ads_Audit> Advertisement_Audit { get; set; }

        public DbSet<Customers> Customer { get; set; }
        public DbSet<Customers_Audit> Customers_Audit { get; set; }

        public DbSet<CustomerAddress> CustomerAddres { get; set; }
        public DbSet<CustomerAddress_Audit> CustomerAddress_Audit { get; set; }

        public DbSet<Carts> Cart { get; set; }
        public DbSet<Carts_Audit> Carts_Audit { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Audit> Order_Audit { get; set; }

        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderHistory_Audit> OrderHistories_Audit { get; set; }

        public DbSet<Videos> Video { get; set; }
        public DbSet<Videos_Audit> Video_Audit { get; set; }

        public DbSet<Subscription> Subscribe { get; set; }
        public DbSet<Subscription_Audit> Subscription_Audit { get; set; }

        public DbSet<CustomerSearchKey> CustomerSearchKey { get; set; }
        public DbSet<CustomerSearchKey_Audit> CustomerSearchKey_Audit { get; set; }

        public DbSet<VisitedProducts> VisitedProducts { get; set; }
        public DbSet<VisitedProducts_Audit> VisitedProducts_Audit { get; set; }

        public DbSet<Functionality> Functionality { get; set; }
        public DbSet<Functionality_Audit> Functionality_Audit { get; set; }

        public DbSet<FunctionalDefect> FunctionalDefect { get; set; }
        public DbSet<FunctionalDefect_Audit> FunctionalDefect_Audit { get; set; }

        public DbSet<FunctionalDefectStory> FunctionalDefectStory { get; set; }
        public DbSet<FunctionalDefectStory_Audit> FunctionalDefectStory_Audit { get; set; }

        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<PaymentMethod_Audit> PaymentMethod_Audit { get; set; }

        public DbSet<DeliveryMethod> DeliveryMethod { get; set; }
        public DbSet<DeliveryMethod_Audit> DeliveryMethod_Audit { get; set; }

        public DbSet<DeleveryTeam> DeleveryTeam { get; set; }
        public DbSet<DeleveryTeam_Audit> DeleveryTeam_Audit { get; set; }

        public DbSet<OrderDelivery> OrderDelivery { get; set; }
        public DbSet<OrderDelivery_Audit> OrderDelivery_Audit { get; set; }

        public DbSet<Offers> Offers { get; set; }
        public DbSet<Offers_Audit> Offers_Audit { get; set; }

        public DbSet<Pages> Pages { get; set; }
        public DbSet<Pages_Audit> Pages_Audit { get; set; }

        public DbSet<RMenu> RMenu { get; set; }
        public DbSet<RMenu_Audit> RMenu_Audit { get; set; }

        public DbSet<DealOfTheDay> DealOfTheDay { get; set; }
        public DbSet<DealOfTheDay_Audit> DealOfTheDay_Audit { get; set; }              

        public DbSet<CustomerRequest> CustomerRequest { get; set; }
        public DbSet<CustomerRequest_Audit> CustomerRequest_Audit { get; set; }

        public DbSet<EmailTracker> EmailTracker { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<UnderConstrunction>().ToTable("tbl_page_under_const");
            modelBuilder.Entity<UnderConstrunction_Audit>().ToTable("tbl_page_under_const_audit");

            modelBuilder.Entity<SocialNetworking>().ToTable("tbl_social_network");
            modelBuilder.Entity<SocialNetworking_Audit>().ToTable("tbl_social_network_audit");

            modelBuilder.Entity<MetaInformation>().ToTable("tbl_meta_info");
            modelBuilder.Entity<MetaInformation_Audit>().ToTable("tbl_meta_info_audit");

            modelBuilder.Entity<Stores>().ToTable("tbl_store");
            modelBuilder.Entity<Stores_Audit>().ToTable("tbl_store_audit");

            modelBuilder.Entity<Invitations>().ToTable("tbl_invitation");
            modelBuilder.Entity<Invitations_Audit>().ToTable("tbl_invitation_audit");

            modelBuilder.Entity<SubCategories>().ToTable("tbl_subcategory");
            modelBuilder.Entity<SubCategories_Audit>().ToTable("tbl_subcategory_audit");

            modelBuilder.Entity<Logo>().ToTable("tbl_logo");
            modelBuilder.Entity<Logo_Audit>().ToTable("tbl_logo_audit");

            modelBuilder.Entity<Product>().ToTable("tbl_product");
            modelBuilder.Entity<Product_Audit>().ToTable("tbl_product_audit");

            modelBuilder.Entity<ProductBanners>().ToTable("tbl_product_banner");
            modelBuilder.Entity<ProductBanners_Audit>().ToTable("tbl_product_banner_audit");

            modelBuilder.Entity<ProductFeatures>().ToTable("tbl_product_feature");
            modelBuilder.Entity<ProductFeatures_Audit>().ToTable("tbl_product_feature_audit");

            modelBuilder.Entity<ProductEight>().ToTable("tbl_product_eight");
            modelBuilder.Entity<ProductEight_Audit>().ToTable("tbl_product_eight_audit");

            modelBuilder.Entity<ProductFlow>().ToTable("tbl_product_flow");
            modelBuilder.Entity<ProductFlow_Audit>().ToTable("tbl_product_flow_audit");

            modelBuilder.Entity<ProdComments>().ToTable("tbl_product_comment");
            modelBuilder.Entity<ProdComments_Audit>().ToTable("tbl_product_comment_audit");

            modelBuilder.Entity<Sliders>().ToTable("tbl_slider");
            modelBuilder.Entity<Sliders_Audit>().ToTable("tbl_slider_audit");

            modelBuilder.Entity<Order>().ToTable("tbl_order");
            modelBuilder.Entity<Order_Audit>().ToTable("tbl_order_audit");

            modelBuilder.Entity<OrderHistory>().ToTable("tbl_order_history");
            modelBuilder.Entity<OrderHistory_Audit>().ToTable("tbl_order_history_audit");

            modelBuilder.Entity<Videos>().ToTable("tbl_video");
            modelBuilder.Entity<Videos_Audit>().ToTable("tbl_video_audit");

            modelBuilder.Entity<Subscription>().ToTable("tbl_email_subscription");
            modelBuilder.Entity<Subscription_Audit>().ToTable("tbl_email_subscription_audit");

            modelBuilder.Entity<CustomerSearchKey>().ToTable("tbl_customer_searchkey");
            modelBuilder.Entity<CustomerSearchKey_Audit>().ToTable("tbl_customer_searchkey_audit");

            modelBuilder.Entity<VisitedProducts>().ToTable("tbl_customer_visited_prd");
            modelBuilder.Entity<VisitedProducts_Audit>().ToTable("tbl_customer_visited_prd_audit");

            modelBuilder.Entity<Functionality>().ToTable("tbl_app_functionality");
            modelBuilder.Entity<Functionality_Audit>().ToTable("tbl_app_functionality_audit");

            modelBuilder.Entity<FunctionalDefect>().ToTable("tbl_functional_defect");
            modelBuilder.Entity<FunctionalDefect_Audit>().ToTable("tbl_functional_defect_audit");

            modelBuilder.Entity<FunctionalDefectStory>().ToTable("tbl_funct_defect_story");
            modelBuilder.Entity<FunctionalDefectStory_Audit>().ToTable("tbl_funct_defect_story_audit");

            modelBuilder.Entity<PaymentMethod>().ToTable("tbl_payment_method");
            modelBuilder.Entity<PaymentMethod_Audit>().ToTable("tbl_payment_method_audit");

            modelBuilder.Entity<DeliveryMethod>().ToTable("tbl_delivery");
            modelBuilder.Entity<DeliveryMethod_Audit>().ToTable("tbl_delivery_audit");

            modelBuilder.Entity<DeleveryTeam>().ToTable("tbl_delivery_team");
            modelBuilder.Entity<DeleveryTeam_Audit>().ToTable("tbl_delivery_team_audit");

            modelBuilder.Entity<OrderDelivery>().ToTable("tbl_order_delivery");
            modelBuilder.Entity<OrderDelivery_Audit>().ToTable("tbl_order_delivery_audit");

            modelBuilder.Entity<Offers>().ToTable("tbl_offers");
            modelBuilder.Entity<Offers_Audit>().ToTable("tbl_offers_audit");

            modelBuilder.Entity<Pages>().ToTable("tbl_pages");
            modelBuilder.Entity<Pages_Audit>().ToTable("tbl_pages_audit");

            modelBuilder.Entity<RMenu>().ToTable("tbl_app_menu");
            modelBuilder.Entity<RMenu_Audit>().ToTable("tbl_app_menu_audit");

            modelBuilder.Entity<DealOfTheDay>().ToTable("tbl_deal_of_the_day");
            modelBuilder.Entity<DealOfTheDay_Audit>().ToTable("tbl_deal_of_the_day_audit");

            modelBuilder.Entity<EmailTracker>().ToTable("tbl_email_tracker");
        }
    }
}