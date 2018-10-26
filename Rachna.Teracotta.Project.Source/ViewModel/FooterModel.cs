using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class FooterModel
    {
        public List<SocialNetworking> _social { get; set; }
        public List<RMenu> _menu { get; set; }
    }
    public class Footer
    {
        public FooterModel Get()
        {
            FooterModel _footer = new FooterModel();
            using (var context = new RachnaDBContext())
            {
                _footer._social = context.SocialNetworking.Where(m => m.Scl_Ntk_Status == eStatus.Active.ToString()).ToList();
                _footer._menu = context.RMenu.ToList();
            }
            return _footer;
        }
    }
}