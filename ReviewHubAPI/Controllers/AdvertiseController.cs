using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BEL;
using BLL;
namespace ReviewHubAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdvertiseController : ApiController
    {
        [Route("api/Advertise/GetAll")]
        [HttpGet]
        public List<AdvertiseModel> GetAll()
        {
            return AdvertiseProvider.getAllAdvertise();
        }
        [Route("api/Advertise/GetByCategory/{id}")]
        [HttpGet]
        public List<AdvertiseModel> getByCategory(int id)
        {
            return AdvertiseProvider.getByCategory(id);
        }
        [Route("api/Advertise/{id}")]
        [HttpGet]
        public AdvertiseDetailsModel Get(int id)
        {
            return AdvertiseProvider.get(id);
        }
        [Route("api/Adivertise/MostViewed")]
        [HttpGet]
        public List<AdvertiseModel> MostViewed()
        {
            return AdvertiseProvider.getMostViewedAdvertise(5);
        }
        [Route("api/Advertise/Create")]
        [HttpPost]
        public async Task<HttpResponseMessage> create()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/Uploads/Products");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                var postedFile = HttpContext.Current.Request.Files[0];
                string fileName = Timestamp.ToString() + postedFile.FileName;
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/Products/" + fileName);

                postedFile.SaveAs(filePath);


                AdvertiseCreateModel product = new AdvertiseCreateModel()
                {
                    Id = 0,
                    Title = provider.FormData.Get("Title"),
                    Description = provider.FormData.Get("Description"),
                    Views = 0,
                    AdvertiseCategoryId = Int32.Parse(provider.FormData.Get("AdvertiseCategoryId")),
                    UserId = Int32.Parse(provider.FormData.Get("UserId")),
                    Created_at = DateTime.Now,
                    ExpirationDate = Convert.ToDateTime(provider.FormData.Get("ExpirationDate")),
                    Image = fileName
                };

                AdvertiseProvider.create(product);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/Advertise/Edit")]
        [HttpPost]
        public async Task<HttpResponseMessage> edit()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/Uploads/Products");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                var postedFile = HttpContext.Current.Request.Files[0];
                string fileName = Timestamp.ToString() + postedFile.FileName;
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/Products/" + fileName);

                postedFile.SaveAs(filePath);


                AdvertiseCreateModel product = new AdvertiseCreateModel()
                {
                    Id = Int32.Parse(provider.FormData.Get("Id")),
                    Title = provider.FormData.Get("Title"),
                    Description = provider.FormData.Get("Description"),
                    Views = 0,
                    AdvertiseCategoryId = Int32.Parse(provider.FormData.Get("AdvertiseCategoryId")),
                    UserId = Int32.Parse(provider.FormData.Get("UserId")),
                    Created_at = DateTime.Now,
                    ExpirationDate = Convert.ToDateTime(provider.FormData.Get("ExpirationDate")),
                    Image = fileName
                };

                AdvertiseProvider.edit(product);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [Route("api/Advertise/Search/{search}")]
        [HttpGet]
        public List<AdvertiseModel> search(string search)
        {
            return AdvertiseProvider.search(search);
        }
        [Route("api/Advertise/Featured/Get")]
        [HttpGet]
        public List<FeaturedAdvertiseModel> getFeaturedAdvertises()
        {
            return AdvertiseProvider.getFeaturedAdvertises();
        }
        [Route("api/Advertise/Featured/Create")]
        [HttpPost]
        public void createFeaturedAdvertise(FeaturedAdvertiseCreateModel fad)
        {
            AdvertiseProvider.createFeaturedAdvertise(fad);
        }

    }
}
