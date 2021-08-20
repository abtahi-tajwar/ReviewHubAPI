using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdvertiseProvider
    {
        public static List<AdvertiseModel> getAllAdvertise()
        {
            var data = AdvertiseRepo.getAllAdvertise();
            List<AdvertiseModel> ads = new List<AdvertiseModel>();
            ads = AutoMapper.Mapper.Map<List<advertis>, List<AdvertiseModel>>(data);
            return ads;
        }
        public static List<AdvertiseModel> getByCategory(int catId)
        {
            var data = AdvertiseRepo.getByCategory(catId);
            return AutoMapper.Mapper.Map<List<advertis>, List<AdvertiseModel>>(data);
        }
        public static AdvertiseDetailsModel get(int id)
        {
            var data = AdvertiseRepo.get(id);
            //AdvertiseModel advertise = AutoMapper.Mapper.Map<advertis, AdvertiseModel>(data);
            AdvertiseDetailsModel advertise = AutoMapper.Mapper.Map<advertis, AdvertiseDetailsModel>(data);
            return advertise;
        }
        public static List<AdvertiseModel> getMostViewedAdvertise(int adNumbers = 5)
        {
            var data = AdvertiseRepo.getAllAdvertise();
            List<AdvertiseModel> ads = new List<AdvertiseModel>();
            ads = AutoMapper.Mapper.Map<List<advertis>, List<AdvertiseModel>>(data);
            var result = ads.OrderBy(ad => ad.Views).Take(adNumbers).ToList();
            return result;
        }
        public static void create(AdvertiseCreateModel ad)
        {
            advertis newAd = AutoMapper.Mapper.Map<AdvertiseCreateModel, advertis>(ad);
            AdvertiseRepo.create(newAd);
        }
        public static void edit(AdvertiseCreateModel ad)
        {
            advertis newAd = AutoMapper.Mapper.Map<AdvertiseCreateModel, advertis>(ad);
            AdvertiseRepo.edit(newAd);
        }
        public static List<AdvertiseModel> search(string search)
        {
            List<advertis> result = AdvertiseRepo.search(search);
            return AutoMapper.Mapper.Map<List<advertis>, List<AdvertiseModel>>(result);
        }
        public static List<FeaturedAdvertiseModel> getFeaturedAdvertises()
        {
            List<featured_advertises> result =  AdvertiseRepo.getFeaturedAdvertises();
            return AutoMapper.Mapper.Map<List<featured_advertises>, List<FeaturedAdvertiseModel>>(result);
        }
        public static void createFeaturedAdvertise(FeaturedAdvertiseCreateModel fad)
        {
            featured_advertises new_fad = AutoMapper.Mapper.Map<FeaturedAdvertiseCreateModel, featured_advertises>(fad);
            AdvertiseRepo.createFeaturedAdvertise(new_fad);
        }
        //public static List<AdvertiseModel> getMostReactedAdvertise(int adNumbers = 5)
        //{
        //    var data = AdvertiseRepo.getAllAdvertise();
        //    List<AdvertiseModel> ads = new List<AdvertiseModel>();
        //    ads = AutoMapper.Mapper.Map<List<advertis>, List<AdvertiseModel>>(data);
        //    var result = ads.OrderBy(ad => ).Take(adNumbers).ToList();
        //    return result;
        //}
    }
}
