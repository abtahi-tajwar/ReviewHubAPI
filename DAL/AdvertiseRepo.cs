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
            var data = context.advertises.ToList();
            return data;
        }

        public static advertis get(int id)
        {
            return context.advertises.FirstOrDefault(ad => ad.Id == id);
        }
        public static advertis create(advertis ad)
        {
            advertis res = context.advertises.Add(ad);
            return res;
        }
        public static advertis edit(advertis ad)
        {
            advertis old = context.advertises.FirstOrDefault(a => a.Id == ad.Id);
            context.Entry(old).CurrentValues.SetValues(ad);
            context.SaveChanges();
            return ad;
        }
        public static advertis delete(int id)
        {
            advertis old = context.advertises.FirstOrDefault(a => a.Id == id);
            context.advertises.Remove(old);
            return old;
        }
    }
}
