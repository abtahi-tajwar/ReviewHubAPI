using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BEL;
using BLL;
namespace ReviewHubAPI.Controllers
{
    public class AdvertiseController : ApiController
    {
        [Route("api/Advertise/GetAll")]
        [HttpGet]
        public List<AdvertiseModel> GetAll()
        {
            return AdvertiseProvider.getAllAdvertise();
        }
        
    }
}
