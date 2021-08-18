using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReviewRepo
    {
        static ReviewHubEntities1 context;
        static ReviewRepo()
        {
            context = new ReviewHubEntities1();
        }
        public static List<review> getAll()
        {
            List<review> reviews = context.reviews.ToList();
            return reviews;
        }
    }
}
