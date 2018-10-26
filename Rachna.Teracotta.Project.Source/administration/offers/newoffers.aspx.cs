using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.offers
{
    public partial class newoffers : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public newoffers()
        {
            context = new RachnaDBContext();
        }

        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : New Offers";
                List<Stores> Stores = context.Store.ToList();
                foreach (var item in Stores)
                {
                    ddlStore.Items.Add(new ListItem { Text = item.Store_Name, Value = item.Store_Id.ToString() });
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            string folderPath = "files/offers/";
            string fileName = "Offers_" + GetRandomNumber(1, 200) + "_ofs.png";

            Offers Offers = new Offers()
            {
                Administrators_Id = Administrators_Id,
                Store_Id = Convert.ToInt32(ddlStore.SelectedValue),
                Product_Id = (ddlOffersFor.Text == "Product") ? Convert.ToInt32(ddlOfferValue.SelectedValue) : 0,
                Category_Id = (ddlOffersFor.Text == "Category") ? Convert.ToInt32(ddlOfferValue.SelectedValue) : 0,
                Offer_On = ddlOffersFor.Text,
                Offer_Title = txtOfferTitle.Text,
                Offer_Description = txtDescription.Text,
                Offer_Banner = (imgInp.HasFile) ? folderPath + fileName : "content/noimage.png",
                Offer_CreatedDate = DateTime.Now,
                Offer_UpdateDate = DateTime.Now,
                Offer_StartsDate = Convert.ToDateTime(txtStartDate.Text),
                Offer_EndDate = Convert.ToDateTime(txtEndDate.Text),
                TotNumbers = Convert.ToInt32(txNoOfTimes.Text)
            };

            int maxAdminId = 1;
            if (context.Offers.ToList().Count > 0)
                maxAdminId = context.Offers.Max(m => m.Offer_Id);
            maxAdminId = (maxAdminId == 1 && context.Offers.ToList().Count > 0) ? (maxAdminId + 1) : maxAdminId;
            Offers.Offer_Code = "OFRRACH" + maxAdminId + "TERA" + (maxAdminId + 1);

            if (imgInp.HasFile)
                Upload(fileName);

            context.Offers.Add(Offers);
            context.SaveChanges();
            Response.Redirect("/administration/offers/offers.aspx?id=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }

        private void Upload(string fileName)
        {
            try
            {
                string folderPath = Server.MapPath("~/files/offers/");
                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                Stream strm = imgInp.PostedFile.InputStream;
                using (var image = System.Drawing.Image.FromStream(strm))
                {
                    int newWidth = 120; // New Width of Image in Pixel  
                    int newHeight = 120; // New Height of Image in Pixel  
                    var thumbImg = new Bitmap(newWidth, newHeight);
                    var thumbGraph = Graphics.FromImage(thumbImg);
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                    thumbGraph.DrawImage(image, imgRectangle);
                    // Save the file  
                    string targetPath = folderPath + fileName;
                    thumbImg.Save(targetPath, image.RawFormat);

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlOffersFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOfferValue.Items.Clear();
            ddlOfferValue.Items.Add("Select..");
            if (ddlOffersFor.Text == "Category")
            {
                List<SubCategories> SubCategories = context.SubCategory.Include("Category").ToList();
                foreach (var item in SubCategories)
                {
                    ddlOfferValue.Items.Add(new ListItem { Text = item.SubCategory_Title + "(" + item.Category.Category_Title + ")", Value = item.SubCategory_Id.ToString() });
                }
            }
            else if (ddlOffersFor.Text == "Product")
            {
                List<Product> Product = context.Product.ToList();
                foreach (var item in Product)
                {
                    ddlOfferValue.Items.Add(new ListItem { Text = item.Product_Title, Value = item.Product_Id.ToString() });
                }
            }
            else
            {
                ddlOfferValue.Items.Add(new ListItem { Text = "Rachna Universal Offer", Value = "100" });
            }
        }
    }
}