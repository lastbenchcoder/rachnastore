using Rachna.Teracotta.Project.Source.App_Data;
using Rachna.Teracotta.Project.Source.Entity;
using Rachna.Teracotta.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.ViewModel
{
    public class SliderModel
    {
        public SliderModel()
        {
        }
        public List<Sliders> _sliders { get; set; }
        public List<Categories> _categories { get; set; }
        public List<Ads> _ads { get; set; }
    }

    public sealed class Slider
    {
        private static Slider instance = null;
        private static readonly object padlock = new object();

        public Slider()
        {
        }

        public static Slider Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Slider();
                        }
                    }
                }
                return instance;
            }
        }
        public SliderModel Get()
        {
            SliderModel _sliderModel = new SliderModel();
            using (var context = new RachnaDBContext())
            {
                _sliderModel._sliders = context.Slider.ToList();
                _sliderModel._categories = context.Category.Include("Admin").Where(m=>m.Category_Status== eStatus.Active.ToString()).ToList();
                foreach(var item in _sliderModel._categories)
                {
                    item.SubCategory= context.SubCategory.Include("Admin").Where(m => m.Category_Id==item.Category_Id && m.SubCategory_Status == eStatus.Active.ToString()).ToList();
                }
                _sliderModel._ads = context.Advertisement.ToList();
            }
            return _sliderModel;
        }
    }
}