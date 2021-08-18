using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    class AdvertiseCreateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public System.DateTime Created_at { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<int> Views { get; set; }
        public int AdvertiseCategory { get; set; }
        public Nullable<int> UserId { get; set; }
    }
}
