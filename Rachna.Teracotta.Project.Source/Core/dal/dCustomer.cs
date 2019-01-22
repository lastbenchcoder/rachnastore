using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dCustomer
    {
        private RachnaDBContext context;
        internal dCustomer()
        {
            context = new RachnaDBContext();
        }

        internal Customers Create(Customers Customers)
        {
            try
            {
                int maxCustomersId = 1;
                if (context.Customer.ToList().Count > 0)
                    maxCustomersId = context.Customer.Max(m => m.Customer_Id);
                maxCustomersId = (context.Customer.ToList().Count > 0) ? (maxCustomersId + 1) : maxCustomersId;
                Customers.CustomerCode = "RT" + maxCustomersId + "CUSTCODE" + (maxCustomersId + 1);                
                context.Customer.Add(Customers);
                context.SaveChanges();
                return Customers;
            }
            catch (Exception ex)
            {
                Customers.ErrorMessage = ex.Message;
                return Customers;
            }
        }

        internal CustomerAddress CreateAddress(CustomerAddress CustomerAddress)
        {
            try
            {
                int maxCustomersId = 1;
                if (context.CustomerAddres.ToList().Count > 0)
                    maxCustomersId = context.CustomerAddres.Max(m => m.CustomerAddress_Id);
                maxCustomersId = (context.CustomerAddres.ToList().Count > 0) ? (maxCustomersId + 1) : maxCustomersId;
                CustomerAddress.CustomerAddress_Code = "RT" + maxCustomersId + "CUSTADRCODE" + (maxCustomersId + 1);
                context.CustomerAddres.Add(CustomerAddress);
                context.SaveChanges();
                return CustomerAddress;
            }
            catch (Exception ex)
            {
                CustomerAddress.ErrorMessage = ex.Message;
                return CustomerAddress;
            }
        }

        internal List<Customers> List()
        {
            List<Customers> Customers = new List<Customers>();
            try
            {
                Customers = context.Customer.Include("CustomerAddress").Include("Cart").Include("Orders").ToList();
                return Customers;
            }
            catch (Exception ex)
            {
                Customers[0].ErrorMessage = ex.Message;
                return Customers;
            }
        }

        internal List<CustomerAddress> ListAddress()
        {
            List<CustomerAddress> CustomerAddress = new List<CustomerAddress>();
            try
            {
                CustomerAddress = context.CustomerAddres.ToList();
                return CustomerAddress;
            }
            catch (Exception ex)
            {
                CustomerAddress[0].ErrorMessage = ex.Message;
                return CustomerAddress;
            }
        }

        internal Customers Update(Customers Customers)
        {
            try
            {
                var entity = context.Customer.Where(c => c.Customer_Id == Customers.Customer_Id).AsQueryable().FirstOrDefault();
                if (entity == null)
                {
                    context.Customer.Add(Customers);
                }
                else
                {
                    context.Entry(entity).CurrentValues.SetValues(Customers);
                }
                context.SaveChanges();
                return Customers;
            }
            catch (Exception ex)
            {
                Customers.ErrorMessage = ex.Message;
                return Customers;
            }
        }

        internal CustomerAddress UpdateCustomerAddress(CustomerAddress CustomerAddress)
        {
            try
            {
                var entity = context.CustomerAddres.Where(c => c.Customer_Id == CustomerAddress.CustomerAddress_Id).AsQueryable().FirstOrDefault();
                if (entity == null)
                {
                    context.CustomerAddres.Add(CustomerAddress);
                }
                else
                {
                    context.Entry(entity).CurrentValues.SetValues(CustomerAddress);
                }
                context.SaveChanges();
                return CustomerAddress;
            }
            catch (Exception ex)
            {
                CustomerAddress.ErrorMessage = ex.Message;
                return CustomerAddress;
            }
        }

        internal int Delete(Customers Customers)
        {
            try
            {
                context.Entry(Customers).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                Customers.ErrorMessage = ex.Message;
                return 404;
            }
        }

        internal int DeleteCustomerAddress(CustomerAddress CustomerAddress)
        {
            try
            {
                context.Entry(CustomerAddress).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                CustomerAddress.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}