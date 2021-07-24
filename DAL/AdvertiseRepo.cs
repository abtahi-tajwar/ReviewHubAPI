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
    }
}
