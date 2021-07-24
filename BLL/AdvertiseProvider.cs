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
            foreach(var item in data)
            {
                ads.Add(new AdvertiseModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Image = item.Image,
                    Created_at = item.Created_at,
                    ExpirationDate = item.ExpirationDate,
                    Views = item.Views,
                    AdvertiseCategory = item.advertise_categories.Name,
                    UserId = item.UserId,
                    userName = item.user.Username
                });
            }
            return ads;
        }
    }
}
