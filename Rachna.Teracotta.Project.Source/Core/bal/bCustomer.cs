using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bCustomer
    {
        public static Customers Create(Customers Customer)
        {
            dCustomer _dCustomer = new dCustomer();
            Customer = _dCustomer.Create(Customer);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Customer", "New SubCustomer creation " + Customer.Customers_EmailId +
                    "( " + Customer.Customer_Id + "  and " + Customer.CustomerCode + " ) successfully.",
                    1, DateTime.Now.ToString());


                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Customer Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return Customer;
        }

        public static CustomerAddress CreateAddress(CustomerAddress CustomerAddress)
        {
            dCustomer _dCustomer = new dCustomer();
            CustomerAddress = _dCustomer.CreateAddress(CustomerAddress);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Customer", "New Customer Address Creation " + CustomerAddress.Customer_AddressLine1 + CustomerAddress.Customer_AddressLine2 +
                    "( " + CustomerAddress.CustomerAddress_Id + "  and " + CustomerAddress.CustomerAddress_Code + " ) done successfully.",
                    1, DateTime.Now.ToString());


                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Customer Address Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return CustomerAddress;
        }

        public static List<Customers> List()
        {
            dCustomer _dCustomer = new dCustomer();
            return _dCustomer.List();
        }

        public static List<CustomerAddress> ListAddress()
        {
            dCustomer _dCustomer = new dCustomer();
            return _dCustomer.ListAddress();
        }

        public static Customers Update(Customers Customer)
        {
            dCustomer _dCustomer = new dCustomer();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Sub Customer", "Customer Updation done on " + Customer.Customers_EmailId +
                    "( " + Customer.Customer_Id + "  and " + Customer.CustomerCode + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Customer Updation ", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dCustomer.Update(Customer);
        }

        public static int Delete(Customers Customer)
        {
            dCustomer _dCustomer = new dCustomer();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Sub Customer", "Customer Deletion done on " + Customer.Customers_EmailId +
                    "( " + Customer.Customer_Id + "  and " + Customer.CustomerCode + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Customer Deletion ", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dCustomer.Delete(Customer);
        }
    }
}