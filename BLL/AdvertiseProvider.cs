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
