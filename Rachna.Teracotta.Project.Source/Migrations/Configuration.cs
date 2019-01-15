namespace Rachna.Teracotta.Project.Source.Migrations
{
    using Models;
    using Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Configuration;
    using Rachna.Teracotta.Project.Source.App_Data;

    internal sealed class Configuration : DbMigrationsConfiguration<Rachna.Teracotta.Project.Source.App_Data.RachnaDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RachnaDBContext context)
        {

        }

        public void ApplicationSetUp()
        {
            using (var context = new RachnaDBContext())
            {
                context.Store.AddOrUpdate(
               p => p.Store_Name,
                    new Stores
                    {
                        StoreCode = "RT1STRECODE2",
                        Store_Name = "Rachna Teracotta EStore",
                        Store_Logo = "content/noimage.png",
                        Store_Url = ConfigurationSettings.AppSettings["CurrentDomain"].ToString(),
                        Store_Status = eStatus.Active.ToString(),
                        Store_CreatedDate = DateTime.Now,
                        Store_UpdatedDate = DateTime.Now
                    }
            );

                context.SaveChanges();

                context.Invitation.AddOrUpdate(
                   p => p.Invitation_EmailId,
                       new Invitations
                       {
                           Store_Id = context.Store.Where(m => m.Store_Name == "Rachna Teracotta EStore").FirstOrDefault().Store_Id,
                           Invitation_Code = "RT1INVTCODE2",
                           Invitation_EmailId = "admin@rachnateracotta.com",
                           Invitation_CreatedDate = DateTime.Now,
                           Invitation_Status = eStatus.InActive.ToString(),
                           Role = eRole.Super.ToString(),
                           Invitation_UpdatedDate = DateTime.Now
                       }
               );

                context.SaveChanges();

                context.Administrator.AddOrUpdate(
                   p => p.EmailId,
                       new Administrators
                       {
                           Invitation_Id = context.Invitation.Where(m => m.Invitation_EmailId == "admin@rachnateracotta.com").FirstOrDefault().Invitation_Id,
                           AdminCode = "RT1ADMCODE2",
                           FullName = "System",
                           EmailId = "admin@rachnateracotta.com",
                           Phone = "9999999999",
                           Description = "rachnateracotta admin description should be here",
                           Photo = "content/noimage.png",
                           Password = "Admin@123",
                           Admin_Status = eStatus.Active.ToString(),
                           Admin_Role = eRole.Super.ToString(),
                           Admin_CreatedDate = DateTime.Now,
                           Admin_UpdatedDate = DateTime.Now,
                           Admin_Login_Attempt = 0,
                           Store_Id = context.Store.Where(m => m.Store_Name == "Rachna Teracotta EStore").FirstOrDefault().Store_Id,
                       }
               );

                context.SaveChanges();

                context.Customer.AddOrUpdate(
                        p => p.Customers_FullName,
                            new Customers
                            {
                                CustomerCode = "RT1CUSTCODE2",
                                CustomerType = eCustomerType.guest.ToString(),
                                Customers_FullName = "Rachna Guest",
                                Customers_EmailId = "guest@rachnateracotta.com",
                                Customers_Phone = "5656789098",
                                Customers_Description = "Rachna Guest",
                                Customers_Login_Attempt = 0,
                                Customers_Password = "Aadmin@123",
                                Customers_Photo = "content/noimage.png",
                                IsEmailVerified = 1,
                                Customers_CreatedDate = DateTime.Now,
                                Customers_UpdatedDate = DateTime.Now,
                                Customers_Status = eStatus.Active.ToString()
                            }
                    );

                context.SaveChanges();

                context.PaymentMethod.AddOrUpdate(
                       p => p.Title,
                           new PaymentMethod
                           {
                               Title = "Cash On Delivery",
                               Description = "Cash on delivery (COD), sometimes called collect on delivery, is the sale of goods by mail order where payment is made on delivery rather than in advance.",
                               Status = eStatus.Active.ToString(),
                               DateCreated = DateTime.Now,
                               DateUpdated = DateTime.Now
                           },
                            new PaymentMethod
                            {
                                Title = "Net Banking",
                                Description = "You can pay your order payment through net banking facility of various bank accounts.",
                                Status = eStatus.InActive.ToString(),
                                DateCreated = DateTime.Now,
                                DateUpdated = DateTime.Now
                            },
                            new PaymentMethod
                            {
                                Title = "Credit/Debit Card",
                                Description = "You can pay your order payment through credit/debit card facility of various bank accounts.",
                                Status = eStatus.InActive.ToString(),
                                DateCreated = DateTime.Now,
                                DateUpdated = DateTime.Now
                            }
                   );

                context.SaveChanges();

                context.PaymentMethod.AddOrUpdate(
                       p => p.Title,
                           new PaymentMethod
                           {
                               Title = "Cash On Delivery",
                               Description = "Cash on delivery (COD), sometimes called collect on delivery, is the sale of goods by mail order where payment is made on delivery rather than in advance.",
                               Status = eStatus.Active.ToString(),
                               DateCreated = DateTime.Now,
                               DateUpdated = DateTime.Now
                           },
                            new PaymentMethod
                            {
                                Title = "Net Banking",
                                Description = "You can pay your order payment through net banking facility of various bank accounts.",
                                Status = eStatus.InActive.ToString(),
                                DateCreated = DateTime.Now,
                                DateUpdated = DateTime.Now
                            },
                            new PaymentMethod
                            {
                                Title = "Credit/Debit Card",
                                Description = "You can pay your order payment through credit/debit card facility of various bank accounts.",
                                Status = eStatus.InActive.ToString(),
                                DateCreated = DateTime.Now,
                                DateUpdated = DateTime.Now
                            }
                   );

                context.SaveChanges();

                context.DeliveryMethod.AddOrUpdate(
                      p => p.Title,
                          new DeliveryMethod
                          {
                              Title = "By Rachna Team",
                              Description = "Rachna Teracotta takes whole responsibility to deliever to the ordered product.",
                              Status = eStatus.Active.ToString(),
                              DateCreated = DateTime.Now,
                              DateUpdated = DateTime.Now
                          },
                           new DeliveryMethod
                           {
                               Title = "By Courier",
                               Description = "Other Courier Team takes responsibility to deliver the ordered product.",
                               Status = eStatus.Active.ToString(),
                               DateCreated = DateTime.Now,
                               DateUpdated = DateTime.Now
                           }
                  );

                context.SaveChanges();

                context.Pages.AddOrUpdate(
                      p => p.Title,
                          new Pages
                          {
                              Title = "Home",
                              Description = "Home",
                              Status = eStatus.Active.ToString(),
                              DateCreated = DateTime.Now,
                              DateUpdated = DateTime.Now,
                              Administrators_Id = context.Administrator.Where(m => m.EmailId == "admin@rachnateracotta.com").FirstOrDefault().Administrators_Id,
                          },
                           new Pages
                           {
                               Title = "Offers",
                               Description = "Offers",
                               Status = eStatus.Active.ToString(),
                               DateCreated = DateTime.Now,
                               DateUpdated = DateTime.Now,
                               Administrators_Id = context.Administrator.Where(m => m.EmailId == "admin@rachnateracotta.com").FirstOrDefault().Administrators_Id,
                           }
                  );

                context.SaveChanges();

                context.RMenu.AddOrUpdate(
                      p => p.Title,
                          new RMenu
                          {
                              Title = "Home",
                              MenuType = eMenu.Header.ToString(),
                              Page_Id = 1,
                              Status = eStatus.Active.ToString(),
                              DateCreated = DateTime.Now,
                              DateUpdated = DateTime.Now,
                              Administrators_Id = context.Administrator.Where(m => m.EmailId == "admin@rachnateracotta.com").FirstOrDefault().Administrators_Id,
                          },
                           new RMenu
                           {
                               Title = "Offers",
                               MenuType = eMenu.Header.ToString(),
                               Page_Id = 2,
                               Status = eStatus.Active.ToString(),
                               DateCreated = DateTime.Now,
                               DateUpdated = DateTime.Now,
                               Administrators_Id = context.Administrator.Where(m => m.EmailId == "admin@rachnateracotta.com").FirstOrDefault().Administrators_Id,
                           }
                  );

                context.SaveChanges();
            }
        }
    }
}
