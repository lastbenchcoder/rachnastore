using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;

using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rachna.Teracotta.Project.Source.administration.product
{
    public partial class excelupload : System.Web.UI.Page
    {
        private RachnaDBContext context;
        public excelupload()
        {
            context = new RachnaDBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Bulk Product Upload";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Upload();
            string folderPath = Server.MapPath("~/excelupload/");
            string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            string CurrentFilePath = folderPath + "\\" + fn;
            InsertExcelRecords(CurrentFilePath);
        }

        private void InsertExcelRecords(string FilePath)
        {

            List<Product> _products = new List<Product>();
            var csvData = System.IO.File.ReadAllLines(FilePath).Skip(1);
            int insertCount = 0;
            int updateCount = 0;
            try
            {
                //Execute a loop over the rows.
                foreach (string row in csvData)
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (row != ",,,,,,,,,,,,,,,,")
                        {
                            _products.Add(new Product
                            {
                                Product_Id = Convert.ToInt32(row.Split(',')[0]),
                                SubCategory_Id = Convert.ToInt32(row.Split(',')[1]),
                                Product_Title = row.Split(',')[2],
                                Product_Description = row.Split(',')[3],
                                Product_Specification = row.Split(',')[4],
                                Product_Qty = Convert.ToInt32(row.Split(',')[5]),
                                Product_Qty_Alert = Convert.ToInt32(row.Split(',')[6]),
                                Product_Delivery_Time = Convert.ToInt32(row.Split(',')[7]),
                                Product_Max_Purchase = Convert.ToInt32(row.Split(',')[8]),
                                Product_Mkt_Price = Convert.ToDecimal(row.Split(',')[9]),
                                Product_Our_Price = Convert.ToDecimal(row.Split(',')[10]),
                                Product_ShippingCharge = Convert.ToDecimal(row.Split(',')[11]),
                                Product_Has_Size = Convert.ToBoolean(row.Split(',')[12].ToLower()),
                                Product_Size = row.Split(',')[13],
                                Product_Avail_ZipCode = row.Split(',')[14],
                                Product_Discount = Convert.ToDecimal(row.Split(',')[15]),
                                Product_CreatedDate = DateTime.Now,
                                Product_UpdatedDate = DateTime.Now,
                                Product_Status = eProductStatus.ReviewPending.ToString()
                            });
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }

            int AdminId = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString());
            Administrators _admin = context.Administrator.ToList().Where(m => m.Administrators_Id == AdminId).FirstOrDefault();

            foreach (var item in _products)
            {
                SubCategories _subCategory = context.SubCategory.Where(m => m.SubCategory_Id == item.SubCategory_Id).FirstOrDefault();
                item.Administrators_Id = _admin.Administrators_Id;
                item.Store_Id = _admin.Store_Id;
                if (_subCategory != null)
                {
                    if (item.Product_Id == 0)
                    {
                        Product Product = new Product()
                        {
                            Store_Id = _admin.Store_Id,
                            Product_Title = item.Product_Title,
                            Product_Description = item.Product_Description,
                            Product_Specification = item.Product_Specification,
                            Administrators_Id = _admin.Administrators_Id,
                            Product_Qty = item.Product_Qty,
                            Product_Qty_Alert = item.Product_Qty_Alert,
                            Product_Delivery_Time = item.Product_Delivery_Time,
                            Product_Max_Purchase = item.Product_Max_Purchase,
                            Product_Mkt_Price = item.Product_Mkt_Price,
                            Product_Our_Price = item.Product_Our_Price,
                            Product_ShippingCharge = item.Product_ShippingCharge,
                            Product_Has_Size = item.Product_Has_Size,
                            Product_Size = (item.Product_Has_Size == true) ? item.Product_Size : "No Size",
                            Product_Avail_ZipCode = item.Product_Avail_ZipCode,
                            Product_Discount = item.Product_Discount,
                            SubCategory_Id = item.SubCategory_Id,
                            Product_CreatedDate = item.Product_CreatedDate,
                            Product_UpdatedDate = item.Product_UpdatedDate,
                            Product_Status = item.Product_Status
                        };
                        try
                        {
                            int maxAdminId = 1;
                            if (context.Product.ToList().Count > 0)
                                maxAdminId = context.Product.Max(m => m.Product_Id);
                            maxAdminId = (maxAdminId == 1 && context.Product.ToList().Count > 0) ? (maxAdminId + 1) : maxAdminId;
                            Product.ProductCode = "PRDTRACH" + maxAdminId + "TERA" + (maxAdminId + 1);
                            context.Product.Add(Product);
                            context.SaveChanges();

                            ProductHelper.CreateProductFlow(Product.Product_Id, Product.Product_Title, _admin.Administrators_Id, _admin.FullName, "New Product Created", Product.Product_Status);

                            item.Product_Id = Product.Product_Id;
                            insertCount = insertCount + 1;
                            ProductBanners ProductBanner = new ProductBanners()
                            {
                                Product_Id = Product.Product_Id,
                                Administrators_Id = Convert.ToInt32(Session[ConfigurationSettings.AppSettings["AdminSession"].ToString()].ToString()),
                                Product_Banner_Default = 1,
                                Product_Banner_Photo = "content/noimage.png",
                                Product_Banner_CreatedDate = DateTime.Now,
                                Product_Banner_UpdatedDate = DateTime.Now
                            };

                            int maxBnrAdminId = 1;
                            if (context.ProductBanner.ToList().Count > 0)
                                maxBnrAdminId = context.ProductBanner.Max(m => m.Product_Id);
                            maxBnrAdminId = (maxBnrAdminId == 1 && context.ProductBanner.ToList().Count > 0) ? (maxBnrAdminId + 1) : maxBnrAdminId;
                            ProductBanner.Product_BannerCode = "PRDBNRTRACH" + maxBnrAdminId + "TERA" + (maxBnrAdminId + 1);
                            context.ProductBanner.Add(ProductBanner);
                            context.SaveChanges();
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        Product _product = context.Product.ToList().Where(m => m.Product_Id == item.Product_Id).FirstOrDefault();
                        if (_product != null)
                        {
                            _product.Store_Id = _admin.Store_Id;
                            _product.Product_Title = item.Product_Title;
                            _product.Product_Description = item.Product_Description;
                            _product.Product_Specification = item.Product_Specification;
                            _product.Administrators_Id = _admin.Administrators_Id;
                            _product.Product_Qty = item.Product_Qty;
                            _product.Product_Qty_Alert = item.Product_Qty_Alert;
                            _product.Product_Delivery_Time = item.Product_Delivery_Time;
                            _product.Product_Max_Purchase = item.Product_Max_Purchase;
                            _product.Product_Mkt_Price = item.Product_Mkt_Price;
                            _product.Product_Our_Price = item.Product_Our_Price;
                            _product.Product_ShippingCharge = item.Product_ShippingCharge;
                            _product.Product_Size = item.Product_Size;
                            _product.Product_Avail_ZipCode = item.Product_Title;
                            _product.Product_Discount = item.Product_Discount;
                            _product.SubCategory_Id = item.SubCategory_Id;
                            _product.Product_UpdatedDate = item.Product_UpdatedDate;
                            _product.Product_Status = item.Product_Status;

                            try
                            {
                                updateCount = updateCount + 1;
                                context.Entry(_product).State = System.Data.Entity.EntityState.Modified;
                                context.SaveChanges();
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            item.Product_Status = "Invalid Product Id";
                        }
                    }
                }
                else
                {
                    item.Product_Status = "Invalid Sub Category Id";
                }
            }
            pnlErrorMessage.Attributes.Remove("class");
            pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
            pnlErrorMessage.Visible = true;
            lblMessage.Text = "We are done!! " + insertCount + " Products Inserted and " + updateCount + " Products Updated Successfully also we have dowloaded the updated excel. Please check your download folder.";

            DataTable dt = ConvertToDataTable(_products);

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Products.xls"));
            Response.ContentType = "application/ms-excel";
            string str = string.Empty;
            foreach (DataColumn dtcol in dt.Columns)
            {
                Response.Write(str + dtcol.ColumnName);
                str = "\t";
            }
            Response.Write("\n");
            foreach (DataRow dr in dt.Rows)
            {
                str = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Response.Write(str + Convert.ToString(dr[j]));
                    str = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }

        private void Upload()
        {
            try
            {
                string folderPath = Server.MapPath("~/excelupload/");
                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }
                else
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(folderPath);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }

                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string SaveLocation = folderPath + "\\" + fn;
                FileUpload1.PostedFile.SaveAs(SaveLocation);
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! Server error occured, please contact administrator.";
            }
        }

        public DataTable ConvertToDataTable(List<Product> data)
        {
            try
            {
                PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(Product));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (Product item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }

                if (table.AsEnumerable().All(dr => dr.IsNull("Store_Id")))
                    table.Columns.Remove("Store_Id");
                if (table.AsEnumerable().All(dr => dr.IsNull("SubCategory")))
                    table.Columns.Remove("SubCategory");
                if (table.AsEnumerable().All(dr => dr.IsNull("ProductBanner")))
                    table.Columns.Remove("ProductBanner");
                if (table.AsEnumerable().All(dr => dr.IsNull("Store")))
                    table.Columns.Remove("Store");
                if (table.AsEnumerable().All(dr => dr.IsNull("Administrators_Id")))
                    table.Columns.Remove("Administrators_Id");
                if (table.AsEnumerable().All(dr => dr.IsNull("Admin")))
                    table.Columns.Remove("Admin");
                if (table.AsEnumerable().All(dr => dr.IsNull("ProductFlow")))
                    table.Columns.Remove("ProductFlow");
                if (table.AsEnumerable().All(dr => dr.IsNull("Cart")))
                    table.Columns.Remove("Cart");
                if (table.AsEnumerable().All(dr => dr.IsNull("Order")))
                    table.Columns.Remove("Order");
                if (table.AsEnumerable().All(dr => dr.IsNull("ProdComments")))
                    table.Columns.Remove("ProdComments");
                return table;
            }
            catch
            {
                throw;
            }
        }
    }
}