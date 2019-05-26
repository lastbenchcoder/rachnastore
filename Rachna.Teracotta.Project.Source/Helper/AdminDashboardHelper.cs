using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Helper
{
    public class AdminDashboardHelper
    {
        public int TotalStores { get; set; }
        public int TotalAdministrator { get; set; }
        public int TotalInvitation { get; set; }
        public int TotalPendingInvitation { get; set; }
        public int TotalCategory { get; set; }
        public int TotalSubCategory { get; set; }
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }
        public int TotalTodaysOrders { get; set; }
        public int TotalCompletedOrders { get; set; }
        public int TotalCancelledOrders { get; set; }
        public int TotalRejectedOrders { get; set; }
        public int TotalItemsInCart { get; set; }
        public int TotalProductsPendingForReview { get; set; }
        public int TotalProductsPendingForApprove { get; set; }
        public int TotalProductsPendingForPublish { get; set; }
        public int TotalProductsPublished { get; set; }
        public int TotalProductsRejected { get; set; }
        public int TotalCustomer { get; set; }
        public List<Invitations> Invitations { get; set; }
        public Administrators Administrators { get; set; }
        public List<Product> ProdPendForReview { get; set; }
        public List<Product> ProdPendForApprove { get; set; }
        public List<Product> ProdPendForPublish { get; set; }
        public List<CustomerRequest> CustomerRequest { get; set; }
        public int prdQtyFlagActive { get; set; }
    }

    public class AdministratorDetail
    {
        private RachnaDBContext context;
        public AdministratorDetail()
        {
            context = new RachnaDBContext();
        }
        public AdminDashboardHelper GetDashBoardDetail(int adminId)
        {
            AdminDashboardHelper hlprAdminDashboard = new AdminDashboardHelper();
            List<Product> _products = context.Product.Include("SubCategory").Include("ProductBanner").Include("Admin").Include("Store").ToList();
            if (_products.Count > 0)
            {
                foreach (var item in _products)
                {
                    item.SubCategory.Category = context.Category.Where(m => m.Category_Id == item.SubCategory.Category_Id).FirstOrDefault();
                }
            }

            hlprAdminDashboard.TotalStores = context.Store.ToList().Count();
            hlprAdminDashboard.TotalAdministrator = context.Administrator.ToList().Count();
            hlprAdminDashboard.TotalInvitation = context.Invitation.ToList().Count();
            hlprAdminDashboard.TotalPendingInvitation = context.Invitation.ToList().Where(m => m.Invitation_Status == eStatus.InActive.ToString()).Count();
            hlprAdminDashboard.TotalCategory = context.Category.ToList().Count();
            hlprAdminDashboard.TotalSubCategory = context.SubCategory.ToList().Count();
            hlprAdminDashboard.TotalProducts = _products.Count();
            hlprAdminDashboard.TotalOrders = _products.Count();
            hlprAdminDashboard.TotalProductsPendingForReview = _products.Where(m => m.Product_Status == eProductStatus.ReviewPending.ToString()).Count();
            hlprAdminDashboard.TotalProductsPendingForApprove = _products.Where(m => m.Product_Status == eProductStatus.ApprovePending.ToString()).Count();
            hlprAdminDashboard.TotalProductsPendingForPublish = _products.Where(m => m.Product_Status == eProductStatus.PublishPending.ToString()).Count();
            hlprAdminDashboard.TotalProductsPublished = _products.Where(m => m.Product_Status == eProductStatus.Published.ToString()).Count();
            hlprAdminDashboard.TotalProductsRejected = _products.Where(m => m.Product_Status == eProductStatus.Rejected.ToString()).Count();
            hlprAdminDashboard.TotalItemsInCart = bCarts.List().ToList().Count();
            hlprAdminDashboard.TotalCustomer = context.Customer.ToList().Count();
            hlprAdminDashboard.Administrators = context.Administrator.ToList().Where(m => m.Administrators_Id == adminId).FirstOrDefault();

            hlprAdminDashboard.Invitations = context.Invitation.ToList();
            hlprAdminDashboard.ProdPendForReview = _products.Where(m => m.Product_Status == eProductStatus.ReviewPending.ToString()).ToList();
            hlprAdminDashboard.ProdPendForApprove = _products.Where(m => m.Product_Status == eProductStatus.ReviewCompleted.ToString()).ToList();
            hlprAdminDashboard.ProdPendForPublish = _products.Where(m => m.Product_Status == eProductStatus.Approved.ToString()).ToList();
            hlprAdminDashboard.CustomerRequest = context.CustomerRequest.Take(20).ToList();
            hlprAdminDashboard.prdQtyFlagActive = (_products.Where(m => m.Product_Qty_Alert >= m.Product_Qty).ToList().Count > 0) ? 1 : 0;

            return hlprAdminDashboard;
        }

        public AdminDashboardHelper GetVendorDashBoardDetail(int AdminId)
        {
            Administrators _admin = null;
            _admin = context.Administrator.Where(m => m.Administrators_Id == AdminId).FirstOrDefault(); ;

            AdminDashboardHelper hlprAdminDashboard = new AdminDashboardHelper();
            List<Product> _products = context.Product.Where(m => m.Store_Id == _admin.Store_Id).ToList();

            hlprAdminDashboard.TotalAdministrator = context.Administrator.ToList().Where(m => m.Store_Id == _admin.Store_Id).Count();
            hlprAdminDashboard.TotalInvitation = context.Invitation.ToList().Where(m => m.Store_Id == _admin.Store_Id).Count();
            hlprAdminDashboard.TotalPendingInvitation = context.Invitation.ToList().Where(m => m.Invitation_Status == eStatus.InActive.ToString() && m.Store_Id == _admin.Store_Id).Count();
            hlprAdminDashboard.TotalCategory = context.Category.ToList().Count();
            hlprAdminDashboard.TotalSubCategory = context.SubCategory.ToList().Count();
            hlprAdminDashboard.TotalProducts = _products.Count();
            hlprAdminDashboard.TotalOrders = _products.Count();
            hlprAdminDashboard.TotalProductsPendingForReview = _products.Where(m => m.Product_Status == eProductStatus.ReviewPending.ToString()).Count();
            hlprAdminDashboard.TotalProductsPendingForApprove = _products.Where(m => m.Product_Status == eProductStatus.ApprovePending.ToString()).Count();
            hlprAdminDashboard.TotalProductsPendingForPublish = _products.Where(m => m.Product_Status == eProductStatus.PublishPending.ToString()).Count();
            hlprAdminDashboard.TotalProductsPublished = _products.Where(m => m.Product_Status == eProductStatus.Published.ToString()).Count();
            hlprAdminDashboard.TotalProductsRejected = _products.Where(m => m.Product_Status == eProductStatus.Rejected.ToString()).Count();
            hlprAdminDashboard.TotalItemsInCart = bCarts.List().ToList().Where(m => m.Store_Id == _admin.Store_Id).Count();
            hlprAdminDashboard.prdQtyFlagActive = (_products.Where(m => m.Product_Qty_Alert >= m.Product_Qty && m.Store_Id == _admin.Store_Id).ToList().Count > 0) ? 1 : 0;

            return hlprAdminDashboard;
        }

        public int ApplicationCompletionStatus()
        {
            int appPercentage = 0;
            int Meta_Info = context.MetaInformation.ToList().Count;
            int App_Logo = context.Logo.ToList().Count;

            int App_Categories = context.Category.ToList().Count;
            int App_Slider = context.Slider.ToList().Count;

            int App_Product = context.Product.ToList().Count;
            int SocialNetwork = context.SocialNetworking.ToList().Count;
            int DealOfTheDay = context.DealOfTheDay.ToList().Count;
            int App_Best_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.Best.ToString()).ToList().Count;
            int App_Featured_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.Featured.ToString()).ToList().Count;
            int App_Hot_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.Hot.ToString()).ToList().Count;
            int App_Latest_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.Latest.ToString()).ToList().Count;
            int App_Top_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.Top.ToString()).ToList().Count;
            int App_Our_Choice_Product = context.ProductFeature.Where(m => m.Product_Feature_Type == eProductFeature.OurChoice.ToString()).ToList().Count;
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

            return appPercentage;
        }
    }
}