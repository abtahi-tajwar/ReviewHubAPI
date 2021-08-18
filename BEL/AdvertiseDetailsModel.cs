using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class AdvertiseDetailsModel
    {
        public AdvertiseDetailsModel()
        {
            this.Comments = new HashSet<AdvertiseCommentModel>();
            this.Reacts = new HashSet<AdvertiseReactModel>();
            this.Locations = new HashSet<AdvertiseLocationModel>();
            this.Reviews = new HashSet<ReviewModel>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public System.DateTime Created_at { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<int> Views { get; set; }
        public string AdvertiseCategory { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Username { get; set; }
        public ICollection<AdvertiseCommentModel> Comments { get; set; }
        public ICollection<AdvertiseReactModel> Reacts { get; set; }
        public ICollection<AdvertiseLocationModel> Locations { get; set; }
        public ICollection<ReviewModel> Reviews { get; set; }
    }
}
