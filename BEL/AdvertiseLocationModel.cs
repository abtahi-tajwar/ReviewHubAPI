using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class AdvertiseLocationModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public Nullable<int> Lat { get; set; }
        public Nullable<int> Lon { get; set; }
        public string Additional { get; set; }
    }
}
