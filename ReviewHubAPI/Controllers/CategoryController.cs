using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BEL;
using BLL;

namespace ReviewHubAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        [Route("api/Category/GetAll")]
        [HttpGet]
        public List<AdvertiseCategoryModel> GetAll()
        {
            return CategoryProvider.getAllAdvertiseCategory();
        }
    }
}
