using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace DAL
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryRepo
    {
        
        public static ReviewHubEntities1 context;
        static CategoryRepo()
        {
            context = new ReviewHubEntities1();
        }
        public static List<advertise_categories> AllAdvertiseCategories()
        { 
            var categories = context.advertise_categories.ToList();
            return categories;
        }

    }
}
