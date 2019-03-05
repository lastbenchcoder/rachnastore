using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Core.bal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.categories
{
    public partial class categorydetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Category Update";
            if (!IsPostBack)
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["catid"].ToString());
                    Categories _category = null;
                    _category = bCategory.List().Where(m => m.Category_Id == id).FirstOrDefault();
                    txtCategory.Text = _category.Category_Title;
                    imgArticle.ImageUrl = "~/" + _category.Category_Photo;
                    txtAdministrator.Text = _category.Admin.FullName;
                    hdnCatId.Value = id.ToString();
                    lblBcTitle.Text = _category.Category_Title;
                    chkIsActive.Checked = (_category.Category_Status == eStatus.Active.ToString()) ? true : false;
                }
                catch (Exception ex)
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = ex.InnerException.InnerException.Message;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(hdnCatId.Value);
                Categories _otherCat = bCategory.List().Where(m => m.Category_Id != id && m.Category_Title == txtCategory.Text).FirstOrDefault();
                int adminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
                if (_otherCat == null)
                {
                    Categories Categories = bCategory.List().Where(m => m.Category_Id == id).FirstOrDefault();
                    Categories.Category_Title = txtCategory.Text;
                    Categories.Category_UpdatedDate = DateTime.Now;
                    Categories.Administrators_Id = adminId;
                    Categories.Category_Status = (chkIsActive.Checked) ? eStatus.Active.ToString() : eStatus.InActive.ToString();
                    if (imgInp.HasFile)
                    {
                        Categories.Category_Photo = "files/category/" + "Category_" + Categories.Category_Id + ".png";
                        string path = Server.MapPath("../" + Categories.Category_Photo);
                        FileInfo file = new FileInfo(path);
                        if (file.Exists)//check file exsit or not
                        {
                            file.Delete();
                        }
                        Upload(Categories.Category_Id);
                    }

                    Categories = bCategory.Update(Categories);

                    if (string.IsNullOrEmpty(Categories.ErrorMessage) && Categories.Category_Status==eStatus.InActive.ToString())
                    {
                        List<SubCategories> subCategories = new List<SubCategories>();
                        List<Product> products = new List<Product>();
                        subCategories = bSubCategory.List().Where(m => m.Category_Id == Categories.Category_Id && m.SubCategory_Status == eStatus.Active.ToString()).ToList();
                        foreach (var item113 in subCategories)
                        {
                            List<Product> productsTemp = new List<Product>();
                            productsTemp = bProduct.List().Where(m => m.Product_Status == eProductStatus.Published.ToString() && m.SubCategory.SubCategory_Id == item113.SubCategory_Id).ToList();
                            products.AddRange(productsTemp);
                        }

                        foreach(var item in products)
                        {
                            item.Product_Status = eProductStatus.ReviewPending.ToString();
                            bProduct.Update(item);
                            ProductHelper.CreateProductFlow(item.Product_Id, item.Product_Title, adminId, "System", "Category In Active : Product Updated and set to Review Pending Status", item.Product_Status);
                            bProduct.DeleteTopEight(item.Product_Id);
                            bProduct.DeleteProductFeature(item.Product_Id);
                            bProduct.DeleteCart(item.Product_Id);
                        }
                    }

                    ActivityHelper.Create("Update Category", "New Category Updated On " + DateTime.Now.ToString("D") + " Successfully and Title is " + Categories.Category_Title + ".", adminId);

                    Response.Redirect("/administration/categories/category.aspx?id=2000&redirecturl=admin-category-RachnaTeracotta");
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Category not updated successfully, category name should not be same as other";
                }

            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.InnerException.InnerException.Message;
            }
        }

        private void Upload(int categoryId)
        {
            try
            {
                string folderPath = Server.MapPath("~/files/category/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                imgInp.SaveAs(folderPath + Path.GetFileName("Category" + "_" + categoryId + ".png"));
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.InnerException.InnerException.Message;
            }
        }
    }
}