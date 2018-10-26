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
    public partial class offerdetail : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public offerdetail()
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
            try
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Offer Detail";
                string id = Request.QueryString["offerid"].ToString();
                hdnOfferId.Value = id;
                if (!IsPostBack)
                {
                    LoadDetail(id);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/account/logout.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            int offerId = Convert.ToInt32(hdnOfferId.Value);
            Offers Offers1 = context.Offers.Where(m => m.Offer_Id == offerId).FirstOrDefault();

            Offers1.Offer_On = ddlOffersFor.Text;

            Offers1.Offer_Title = txtOfferTitle.Text;
            Offers1.Offer_Description = txtDescription.Text;
            Offers1.Offer_StartsDate = Convert.ToDateTime(txtStartDate.Text);
            Offers1.Offer_EndDate = Convert.ToDateTime(txtEndDate.Text);
            Offers1.TotNumbers = Convert.ToInt32(txNoOfTimes.Text);
            Offers1.Offer_UpdateDate = DateTime.Now;
            Offers1.Administrators_Id = Administrators_Id;
            Offers1.Product_Id = (ddlOffersFor.Text == "Product") ? Convert.ToInt32(ddlOfferValue.SelectedValue) : 0;
            Offers1.Category_Id = (ddlOffersFor.Text == "Category") ? Convert.ToInt32(ddlOfferValue.SelectedValue) : 0;
            Offers1.Store_Id = Convert.ToInt32(ddlStore.SelectedValue);

            if (imgInp.HasFile)
            {
                if (imgInp.HasFile)
                {
                    string filename = "Offers_" + GetRandomNumber(1, 200) + "_ofs.png";
                    string folderPath = "files/offers/";
                    Offers1.Offer_Banner = folderPath + filename;
                    string path = Server.MapPath("../" + Offers1.Offer_Banner);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists && Offers1.Offer_Banner != "content/noimage.png")//check file exsit or not
                    {
                        file.Delete();
                    }
                    Upload(filename);
                }
               
                Offers1.Offer_Code = "OFRRACH" + Offers1.Offer_Id + "TERA" + (Offers1.Offer_Id + 1);
                context.Entry(Offers1).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                Offers1.Offer_Code = "OFRRACH" + Offers1.Offer_Id + "TERA" + (Offers1.Offer_Id + 1);
                context.Entry(Offers1).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            LoadDetail(Offers1.Offer_Id.ToString());
            Response.Redirect("/administration/offers/offers.aspx?id=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }

        private void Upload(string file)
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
                    string targetPath = folderPath + file;
                    thumbImg.Save(targetPath, image.RawFormat);

                }
            }
            catch (Exception ex)
            {

            }
        }
        private void LoadDetail(string id)
        {
            try
            {
                List<Stores> Stores = context.Store.Where(m => m.Store_Status == eStatus.Active.ToString()).ToList();
                foreach (var item in Stores)
                {
                    ddlStore.Items.Add(new ListItem { Text = item.Store_Name, Value = item.Store_Id.ToString() });
                }

                int offerId = Convert.ToInt32(id);
                Offers Offers = context.Offers.Where(m => m.Offer_Id == offerId).FirstOrDefault();

                ddlStore.SelectedValue = Offers.Store_Id.ToString();
                ddlOffersFor.Text = Offers.Offer_On;
                txtOfferTitle.Text = Offers.Offer_Title;
                lblBcTitle.Text = Offers.Offer_Title;
                txtDescription.Text = Offers.Offer_Description;
                txNoOfTimes.Text = Offers.TotNumbers.ToString();
                imgProduct.ImageUrl = "../../" + Offers.Offer_Banner;
                txtStartDate.Text = Offers.Offer_StartsDate.ToString("dd/MM/yyyy");
                txtEndDate.Text = Offers.Offer_EndDate.ToString("dd/MM/yyyy");
                GetOfferFor(Offers.Product_Id != 0 ? Offers.Product_Id.ToString() : Offers.Category_Id.ToString());
            }
            catch (Exception ex)
            {

            }
        }

        protected void GetOfferFor(string selItem)
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

            ddlOfferValue.SelectedValue = selItem == "0" ? "100" : selItem;
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