using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using BEL;
using DAL;

namespace BLL
{
    
    public class CategoryProvider
    {
        public static List<AdvertiseCategoryModel> getAllAdvertiseCategory()
        {
            var data = CategoryRepo.AllAdvertiseCategories();
            List<AdvertiseCategoryModel> ad_cats = AutoMapper.Mapper.Map<List<advertise_categories>, List<AdvertiseCategoryModel>>(data);
            return ad_cats;
        }
    }
}
