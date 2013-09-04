using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthanolMap.Web.Models
{
    public class Station
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}