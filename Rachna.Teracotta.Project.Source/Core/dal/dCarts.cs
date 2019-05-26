using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.Core.dal
{
    internal class dCarts
    {
        private RachnaDBContext context;
        internal dCarts()
        {
            context = new RachnaDBContext();
        }

        internal Carts Create(Carts Carts)
        {
            try
            {
                int maxCartsId = 0;
                if (context.Cart.ToList().Count > 0)
                    maxCartsId = context.Cart.Max(m => m.Cart_Id);
                maxCartsId = (maxCartsId > 0) ? (maxCartsId + 1) : 1;
                Carts.CartCode = "RT" + maxCartsId + "CARTCODE" + (maxCartsId + 1);
                context.Cart.Add(Carts);
                context.SaveChanges();
                return Carts;
            }
            catch (Exception ex)
            {
                Carts.ErrorMessage = ex.Message;
                return Carts;
            }            
        }

        internal List<Carts> List()
        {
            List<Carts> Carts = new List<Carts>();
            try
            {
                Carts = context.Cart.Include("Administrators").Include("Customer").ToList();
                return Carts;
            }
            catch (Exception ex)
            {
                Carts[0].ErrorMessage = ex.Message;
                return Carts;
            }
        }

        internal Carts Update(Carts Carts)
        {
            try
            {
                context.Entry(Carts).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return Carts;
            }
            catch (Exception ex)
            {
                Carts.ErrorMessage = ex.Message;
                return Carts;
            }
        }

        internal int Delete(Carts Carts)
        {
            try
            {
                context.Entry(Carts).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return 100;
            }
            catch (Exception ex)
            {
                Carts.ErrorMessage = ex.Message;
                return 404;
            }
        }
    }
}