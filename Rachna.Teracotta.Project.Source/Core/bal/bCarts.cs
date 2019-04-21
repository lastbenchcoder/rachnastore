using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Helper;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bCarts
    {
        public static Carts Create(Carts Carts)
        {
            dCarts _dCarts = new dCarts();
            Carts= _dCarts.Create(Carts);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Carts", "New Carts " +
                    "( " + Carts.Cart_Id + "  and " + Carts.CartCode + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Carts Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return Carts;
        }

        public static List<Carts> List()
        {
            dCarts _dCarts = new dCarts();
            return _dCarts.List();
        }

        public static Carts Update(Carts Carts)
        {
            dCarts _dCarts = new dCarts();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Carts", "Carts Updation done on " +
                    "( " + Carts.Cart_Id + "  and " + Carts.CartCode + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Carts Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dCarts.Update(Carts);
        }

        public static int Delete(Carts Carts)
        {
            dCarts _dCarts = new dCarts();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Carts", "Carts Deletion done on" +
                    "( " + Carts.Cart_Id + "  and " + Carts.CartCode + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Carts Deletion", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dCarts.Delete(Carts);
        }
    }
}