using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class HeaderModel
    {
        public Logo _logo { get; set; }
        public List<Carts> _carts { get; set; }
        public List<RMenu> _menu { get; set; }
    }
    public class Header
    {
        public HeaderModel Get()
        {
            HeaderModel _header = new HeaderModel();
            CartModel CartModel=new CartModel();
            using (var context = new RachnaDBContext())
            {
                _header._logo = context.Logo.Where(m => m.Logo_Status == eStatus.Active.ToString()).FirstOrDefault();
                _header._carts = CartModel.GetCarts();
                _header._menu = context.RMenu.ToList();
            }
            return _header;
        }
    }
}