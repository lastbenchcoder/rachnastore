using Rachna.Teracotta.Project.Source.Core.dal;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;

namespace Rachna.Teracotta.Project.Source.Core.bal
{
    public static class bProduct
    {
        public static Product Create(Product Product)
        {
            dProduct _dProduct = new dProduct();
            return _dProduct.Create(Product);
        }

        public static List<Product> List()
        {
            dProduct _dProduct = new dProduct();
            return _dProduct.List();
        }

        public static Product Update(Product Product)
        {
            dProduct _dProduct = new dProduct();
            return _dProduct.Update(Product);
        }

        public static int Delete(Product Product)
        {
            dProduct _dProduct = new dProduct();
            return _dProduct.Delete(Product);
        }
    }
}