using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdvertiseRepo
    {
        static ReviewHubEntities1 context;
        static AdvertiseRepo()
        {
            context = new ReviewHubEntities1();
        }
        public static List<advertis> getAllAdvertise()
        {
            var data = context.advertises.OrderByDescending(item => item.Id).ToList();
            return data;
        }
        public static List<advertis> getByCategory(int catId)
        {
            var data = context.advertises.Where(item => item.AdvertiseCategoryId == catId).OrderByDescending(item => item.Id).ToList();
            return data;
        }

        public static advertis get(int id)
        {
            return context.advertises.FirstOrDefault(ad => ad.Id == id);
        }
        public static void create(advertis ad)
        {
            context.advertises.Add(ad);
            context.SaveChanges();
        }
        public static void edit(advertis ad)
        {
            advertis old = context.advertises.FirstOrDefault(a => a.Id == ad.Id);
            context.Entry(old).CurrentValues.SetValues(ad);
            context.SaveChanges();
        }
        public static advertis delete(int id)
        {
            advertis old = context.advertises.FirstOrDefault(a => a.Id == id);
            context.advertises.Remove(old);
            return old;
        }
        public static List<advertis> search(string search)
        {
            return context.advertises.Where(ad =>
                            ad.Title.Contains(search) ||
                            ad.Description.Contains(search))
                        .ToList();
        }
        public static List<featured_advertises> getFeaturedAdvertises()
        {
            return context.featured_advertises.OrderByDescending(item => item.Id).ToList();
        }
        public static void createFeaturedAdvertise(featured_advertises fad)
        {
            context.featured_advertises.Add(fad);
            context.SaveChanges();
        }
    }
}
