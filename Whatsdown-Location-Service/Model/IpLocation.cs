using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whatsdown_Location_Service.Model
{
    public class IpLocation
    {
        public string ip { get; set; }
        public string country_name { get; set; }
        public string city { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }

        public IpLocation()
        {
        }
    }
}
